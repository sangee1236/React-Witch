using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ResourceManagement.Model;
using System.Linq;

namespace ResourceManagement.Data
{
    public class ResourceManagementContext : DbContext
    {
        // Resource table dbset
        public DbSet<ResourceInfo> Resources { get; set; }

        //sangee
        public DbSet<TimeSheetInfo> TimeSheet { get; set; }

        public DbSet<Projects> Projects { get; set; }

        public DbSet<TimeSheetEntry> TimeSheetEntry { get; set; }

        public DbSet<EngagementResource> EngagementResource { get; set; }

        //
        public ResourceManagementContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.Entity<ResourceInfo>()
             .ToTable("ResourceInfo");


            //  modelBuilder.Entity<EngagementResource>()
            //     .HasKey(t => new { t.ProjectId ,t.ResourceId });

            //modelBuilder.Entity<EngagementResource>()
            //    .HasOne(t => t.resource)
            //    .WithMany(x=>x.EngagementResource)
            //.HasMany(t => t.Project)
            //.WithMany(t => t.Resource);


            modelBuilder.Entity<ResourceInfo>()
               .Property(u => u.Name) // name is made mandatory                                    
               .IsConcurrencyToken()  // .Property(a => a.RowVersion) - concurrency control
               .ValueGeneratedOnAddOrUpdate()
               .HasMaxLength(100)
               .IsRequired();

            #region EngagementResource
            modelBuilder.Entity<EngagementResource>()
                .Property(u => u.ProjectId)
                .HasColumnName("ProjectId");

            modelBuilder.Entity<EngagementResource>()
                .Property(u => u.ResourceId)
                .HasColumnName("ResourceId");
            #endregion

            #region TimesheetEntry
            modelBuilder.Entity<TimeSheetEntry>()
                            .Property(u => u.ResourceInfoId)
                            .HasColumnName("ResourceId");

            modelBuilder.Entity<TimeSheetEntry>()
                          .Property(u => u.TimeSheetInfoId)
                          .HasColumnName("TimeSheetInfoId");
            #endregion
        }
    }
}
