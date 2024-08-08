using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RealEstateApp.Models
{
    public class Property : AuditEntity<Guid>
    {
       

        
       
        public string? OfferType { get; set; } 
        public string? ownerName { get; set; }
        public string? OfferPeriod { get; set; }
       
       
        public string? Title { get; set; }
        public string? postalNum { get; set; }
        public string? propertyNum { get; set; }
        public string? ownerNum { get; set; }

       public string? mainImage { get; set; }
        public bool Available { get; set; }

        public string? status { get; set; }
        public int? AreaMeters { get; set; }

        public string? Property_Type_id { get; set; }
        public int? Price { get; set; }
        public string? Location { get; set; }
        public string? Description { get; set; }

        public int? Age { get; set; }

        public string? Direction { get; set; }
        public int? NumOfRooms { get; set; }
        public int? NumOfBathrooms { get; set; }
        public int? NumOfFloors { get; set; }
        public string? ContactNumber { get; set; }
        public string? OfficeNumber { get; set; }

        public bool SchoolService { get; set; }
        public bool WaterService { get; set; }
        public bool SupermarketService { get; set; }
        public bool GasStationService { get; set; }
        public bool ParkingService { get; set; }
        public bool PetsService { get; set; }
        public bool HospitalService { get; set; }
        public bool ElectricityService { get; set; }

        [ForeignKey("User")]
        public string User_id { get; set; }
        public virtual User User { get; set; }

    }
}
