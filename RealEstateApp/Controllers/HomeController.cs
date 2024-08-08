using Microsoft.AspNetCore.Mvc;
using RealEstateApp.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using RealEstateApp.Areas.Identity.Data;
using RealEstateApp.Data;
using Microsoft.AspNetCore.Authorization;
using System.IO;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;

namespace RealEstateApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<authUser> _userManager;
        private readonly SignInManager<authUser> _signInManager;
        private readonly ApplicationDbContext _context;
        private readonly authContext _contextAuth;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public HomeController(IWebHostEnvironment webHostEnvironment ,ApplicationDbContext context ,authContext contextAuth ,SignInManager<authUser> signInManager, UserManager<authUser> userManager ,ILogger<HomeController> logger)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _contextAuth = contextAuth;
            _webHostEnvironment = webHostEnvironment;
    }

        public IActionResult Index()
        {
            if (_signInManager.IsSignedIn(User))
            {
                var user_ID =  _userManager.GetUserId(User);
                var user = _context.Users.SingleOrDefault(x => x.userID == user_ID);
                if (user == null)
                {
                    var user1 = _contextAuth.Users.SingleOrDefault(x => x.Id == user_ID);
                    var NewUser = new User
                    {
                        userID = user_ID,
                        Name = user1.Namee,

                        Email = user1.Email,
                        Phone = user1.phone,
                        Password = user1.PasswordHash,
                        CreationDatetime = DateTime.Now,
                    };
                    _context.Users.Add(NewUser);
                    _context.SaveChanges();
                }
                    Console.WriteLine(user_ID); 
                
            }
            var property = _context.Properties.ToList();
           
            ViewBag.property = property;
            return View();
        }

        [Route("view")]
        public IActionResult ViewProperty(Guid p)
        {

            var property = _context.Properties.SingleOrDefault(x => x.Id == p);

            if (property == null)
            {
                Console.WriteLine("sssssssssssssssssss");
                return NotFound();
            }
            var images = _context.PropertyImages.Where(x => x.Property_Id == p).ToList();
            ViewBag.images = images;
            return View(property);
          
        }
        [Route("add")]
        [Authorize]
        public IActionResult AddProperty()
        {
            return View();
        }
        [HttpPost]
       
        
        public  IActionResult AddProperty1(Models.Property property, List<IFormFile> PropertyImages)
        {
            Console.WriteLine("here");
            Console.WriteLine(ModelState.IsValid);
            if (true)
            {
                var user_ID = _userManager.GetUserId(User);
                var user = _context.Users.SingleOrDefault(x => x.userID == user_ID);
                // Save property details
                property.Id = Guid.NewGuid();
                property.User_id = user.Id;
                property.mainImage = $"{property.Id}_{PropertyImages[0].FileName}";
                _context.Properties.Add(property);
                 _context.SaveChanges();

                // Save images
                if (PropertyImages != null && PropertyImages.Count > 0)
                {
                    foreach (var file in PropertyImages)
                    {
                        if (file.Length > 0)
                        {
                            var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "Images", $"{property.Id}_{file.FileName}");


                            using (FileStream stream = new FileStream(imagePath, FileMode.Create))
                            {
                                file.CopyTo(stream);
                                stream.Close();
                            }
                            // Save image path in the database
                            var propertyImage = new PropertyImages
                            {
                                Id = Guid.NewGuid(),
                                Property_Id = property.Id,
                                Image = $"{property.Id}_{file.FileName}",
                            };
                            _context.PropertyImages.Add(propertyImage);
                            _context.SaveChanges();
                        }
                    }
                    
                }

                return RedirectToAction(nameof(Index)); // Or wherever you want to redirect after successful addition
            }
            return RedirectToAction(nameof(Index));
        }

       

[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
