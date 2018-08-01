using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ResourceManagement.Data;

namespace ResourceManagement.API.Migrations
{
    [DbContext(typeof(ResourceManagementContext))]
    partial class ResourceManagementContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ResourceManagement.Model.EngagementResource", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ProjectId")
                        .HasColumnName("ProjectId");

                    b.Property<int>("ResourceId")
                        .HasColumnName("ResourceId");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("ResourceId");

                    b.ToTable("EngagementResource");
                });

            modelBuilder.Entity("ResourceManagement.Model.Projects", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<bool?>("Status");

                    b.HasKey("Id");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("ResourceManagement.Model.ResourceInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Avatar");

                    b.Property<int>("BusinessUnitId");

                    b.Property<int>("CreatedBy");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("EmailID");

                    b.Property<DateTime>("JoiningDate");

                    b.Property<string>("Mobile");

                    b.Property<int>("ModifiedBy");

                    b.Property<DateTime>("ModifiedOn");

                    b.Property<string>("Name")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasMaxLength(100);

                    b.Property<string>("Password");

                    b.Property<int>("ResourceTypeId");

                    b.Property<bool>("Status");

                    b.Property<int>("SystemUserId");

                    b.HasKey("Id");

                    b.ToTable("ResourceInfo");
                });

            modelBuilder.Entity("ResourceManagement.Model.TimeSheetEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ResourceInfoId")
                        .HasColumnName("ResourceId");

                    b.Property<int>("TimeSheetInfoId")
                        .HasColumnName("TimeSheetInfoId");

                    b.HasKey("Id");

                    b.HasIndex("ResourceInfoId");

                    b.HasIndex("TimeSheetInfoId");

                    b.ToTable("TimeSheetEntry");
                });

            modelBuilder.Entity("ResourceManagement.Model.TimeSheetInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BillingStatus");

                    b.Property<DateTime>("Date");

                    b.Property<int>("Hours");

                    b.Property<int>("ProjectId");

                    b.Property<int>("ResourceId");

                    b.Property<string>("Task");

                    b.Property<string>("TaskDetails");

                    b.HasKey("Id");

                    b.ToTable("TimeSheet");
                });

            modelBuilder.Entity("ResourceManagement.Model.EngagementResource", b =>
                {
                    b.HasOne("ResourceManagement.Model.Projects", "project")
                        .WithMany()
                        .HasForeignKey("ProjectId");

                    b.HasOne("ResourceManagement.Model.ResourceInfo", "resource")
                        .WithMany()
                        .HasForeignKey("ResourceId");
                });

            modelBuilder.Entity("ResourceManagement.Model.TimeSheetEntry", b =>
                {
                    b.HasOne("ResourceManagement.Model.ResourceInfo", "ResourceInfo")
                        .WithMany()
                        .HasForeignKey("ResourceInfoId");

                    b.HasOne("ResourceManagement.Model.TimeSheetInfo", "TimeSheetInfo")
                        .WithMany()
                        .HasForeignKey("TimeSheetInfoId");
                });
        }
    }
}
