using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RealEstateApp.Areas.Identity.Data;

namespace RealEstateApp.Areas.Identity.Data;

public class authContext : IdentityDbContext<authUser>
{
    public authContext(DbContextOptions<authContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
        builder.ApplyConfiguration(new ApplicationUserEntityConfiguratiion());
    }
}

internal class ApplicationUserEntityConfiguratiion : IEntityTypeConfiguration<authUser>
{
    public void Configure(EntityTypeBuilder<authUser> builder)
    {
        // Assuming 'Namee' is a custom property in your authUser class
        builder.Property(x => x.Namee).HasMaxLength(255);
        builder.Property(x => x.phone);
    }
}