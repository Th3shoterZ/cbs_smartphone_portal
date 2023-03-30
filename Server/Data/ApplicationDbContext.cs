using Duende.IdentityServer.EntityFramework.Entities;
using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SmartphonePortal_Vervoort_Wagner.Server.Models;

namespace SmartphonePortal_Vervoort_Wagner.Server.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "User", NormalizedName = "USER", Id = Guid.NewGuid().ToString(), ConcurrencyStamp = Guid.NewGuid().ToString() });
            builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Admin", NormalizedName = "ADMIN", Id = Guid.NewGuid().ToString(), ConcurrencyStamp = Guid.NewGuid().ToString() });

            builder.Entity<Smartphone>()
                .HasOne<PhoneDetails>(s => s.PhoneDetails)
                .WithOne(i => i.Smartphone)
                .HasForeignKey<PhoneDetails>(p => p.SmartphoneId);

            builder.Entity<Smartphone>()
                .HasMany<Review>(s => s.Reviews)
                .WithOne(r => r.Smartphone)
                .HasForeignKey(r => r.SmartphoneId);

            builder.Entity<Smartphone>()
                .HasMany<Rating>(s => s.Ratings)
                .WithOne(r => r.Smartphone)
                .HasForeignKey(r => r.SmartphoneId);

            builder.Entity<PhoneDetails>()
                .HasMany<Picture>(pd => pd.Pictures)
                .WithOne(p => p.PhoneDetails)
                .HasForeignKey(p => p.PhoneDetailsId);

            builder.Entity<Processor>()
               .HasMany<PhoneDetails>(p => p.PhoneDetails)
               .WithOne(p => p.Processor)
               .HasForeignKey(p => p.PhoneDetailsId);

            builder.Entity<ApplicationUser>()
                .HasMany<Rating>(u => u.Ratings)
                .WithOne(r => r.User)
                .HasForeignKey(r => r.UserId);

            builder.Entity<ApplicationUser>()
                .HasMany<Review>(u => u.Reviews)
                .WithOne(r => r.User)
                .HasForeignKey(r => r.UserId);

            builder.Entity<ApplicationUser>()
               .HasMany<Comment>(u => u.Comments)
               .WithOne(c => c.User)
               .HasForeignKey(c => c.UserId);

            builder.Entity<Review>()
                .HasMany<Comment>(c => c.Comments)
                .WithOne(r => r.Review)
                .HasForeignKey(r => r.CommentId);
        }

        public DbSet<Smartphone> Smartphones { get; set; }
        public DbSet<PhoneDetails> PhoneDetails { get; set; }
        public DbSet<Processor> Processors { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public new virtual DbSet<DeviceFlowCodes> DeviceFlowCodes { get; set; }
    }
}