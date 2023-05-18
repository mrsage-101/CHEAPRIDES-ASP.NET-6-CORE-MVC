﻿// <auto-generated />
using CHEAPRIDES.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CHEAPRIDES.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CHEAPRIDES.Models.CarRegShow", b =>
                {
                    b.Property<int>("Carid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Carid"));

                    b.Property<bool>("avialability")
                        .HasColumnType("bit");

                    b.Property<string>("cMake")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cModel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cRegNum")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("pId")
                        .HasColumnType("int");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.HasKey("Carid");

                    b.HasIndex("pId");

                    b.ToTable("CarRegShows");
                });

            modelBuilder.Entity("CHEAPRIDES.Models.PersonInfo", b =>
                {
                    b.Property<int>("pId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("pId"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Contact")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.HasKey("pId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("CHEAPRIDES.Models.PersonLogin", b =>
                {
                    b.Property<int>("pId")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("nvarchar(1)");

                    b.HasKey("pId");

                    b.ToTable("PersonLogin");
                });

            modelBuilder.Entity("CHEAPRIDES.Models.RideBooking", b =>
                {
                    b.Property<int>("Bookingid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Bookingid"));

                    b.Property<int>("Carid")
                        .HasColumnType("int");

                    b.Property<string>("Droplocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Fare")
                        .HasColumnType("int");

                    b.Property<string>("Pickuplocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Bookingid");

                    b.HasIndex("Carid");

                    b.ToTable("RideBookings");
                });

            modelBuilder.Entity("CHEAPRIDES.Models.CarRegShow", b =>
                {
                    b.HasOne("CHEAPRIDES.Models.PersonInfo", "PersonInfos1")
                        .WithMany("CarRegShows")
                        .HasForeignKey("pId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonInfos1");
                });

            modelBuilder.Entity("CHEAPRIDES.Models.PersonLogin", b =>
                {
                    b.HasOne("CHEAPRIDES.Models.PersonInfo", "PersonInfo")
                        .WithOne("PersonLogins")
                        .HasForeignKey("CHEAPRIDES.Models.PersonLogin", "pId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonInfo");
                });

            modelBuilder.Entity("CHEAPRIDES.Models.RideBooking", b =>
                {
                    b.HasOne("CHEAPRIDES.Models.CarRegShow", "CarRegShow")
                        .WithMany("RideBookings")
                        .HasForeignKey("Carid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarRegShow");
                });

            modelBuilder.Entity("CHEAPRIDES.Models.CarRegShow", b =>
                {
                    b.Navigation("RideBookings");
                });

            modelBuilder.Entity("CHEAPRIDES.Models.PersonInfo", b =>
                {
                    b.Navigation("CarRegShows");

                    b.Navigation("PersonLogins");
                });
#pragma warning restore 612, 618
        }
    }
}
