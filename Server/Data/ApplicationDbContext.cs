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
                .HasMany<Review>(s => s.Reviews)
                .WithOne(r => r.Smartphone)
                .HasForeignKey(r => r.SmartphoneId);

            builder.Entity<Smartphone>()
                .HasMany<Rating>(s => s.Ratings)
                .WithOne(r => r.Smartphone)
                .HasForeignKey(r => r.SmartphoneId);

            builder.Entity<Smartphone>()
                .HasMany<Picture>(pd => pd.Pictures)
                .WithOne(p => p.Smartphone)
                .HasForeignKey(p => p.SmartphoneId);

            builder.Entity<Smartphone>()
               .HasOne<Processor>(sm => sm.Processor)
               .WithMany(p => p.Smartphones)
               .HasForeignKey(sm => sm.ProcessorId);

            builder.Entity<Smartphone>()
               .HasOne<Category>(sm => sm.Category)
               .WithMany(c => c.Smartphones)
               .HasForeignKey(sm => sm.CategoryId);

            builder.Entity<Smartphone>()
              .HasOne<Manufacturer>(sm => sm.Manufacturer)
               .WithMany(m => m.Smartphones)
               .HasForeignKey(sm => sm.ManufacturerId);

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
                .HasMany<Comment>(r => r.Comments)
                .WithOne(c => c.Review)
                .HasForeignKey(c => c.CommentId);

            builder.Entity<Review>()
                .HasMany<Rating>(rev => rev.Ratings)
                .WithOne(rat => rat.Review)
                .HasForeignKey(rat => rat.RatingId);
        }

        public DbSet<Smartphone> Smartphones { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Processor> Processors { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public new virtual DbSet<DeviceFlowCodes> DeviceFlowCodes { get; set; }
    }
}