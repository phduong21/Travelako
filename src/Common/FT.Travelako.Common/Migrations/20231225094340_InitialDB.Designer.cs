﻿// <auto-generated />
using System;
using FT.Travelako.Common.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FT.Travelako.Common.Migrations
{
    [DbContext(typeof(TravelkoContext))]
    [Migration("20231225094340_InitialDB")]
    partial class InitialDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("FT.Travelako.Common.Entities.Booking", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<long>("TotalCost")
                        .HasColumnType("bigint");

                    b.Property<Guid>("TravelId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TravelId");

                    b.HasIndex("UserId");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("FT.Travelako.Common.Entities.Coupon", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Condition")
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Discount")
                        .HasColumnType("int");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserCouponId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UserCouponId1")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserCouponId");

                    b.HasIndex("UserCouponId1")
                        .IsUnique()
                        .HasFilter("[UserCouponId1] IS NOT NULL");

                    b.ToTable("Coupons");
                });

            modelBuilder.Entity("FT.Travelako.Common.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("FT.Travelako.Common.Entities.Travel", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HotelPrice")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HotelTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Images")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Province")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Tag")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Thumbnail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TrafficType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Travels");
                });

            modelBuilder.Entity("FT.Travelako.Common.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Personalization")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserCouponId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UserCouponId1")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserCouponId");

                    b.HasIndex("UserCouponId1")
                        .IsUnique()
                        .HasFilter("[UserCouponId1] IS NOT NULL");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("FT.Travelako.Common.Entities.UserCoupon", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Modified")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("UserCoupons");
                });

            modelBuilder.Entity("FT.Travelako.Common.Entities.Booking", b =>
                {
                    b.HasOne("FT.Travelako.Common.Entities.Travel", "Travel")
                        .WithMany("Bookings")
                        .HasForeignKey("TravelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FT.Travelako.Common.Entities.User", "User")
                        .WithMany("Bookings")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Travel");

                    b.Navigation("User");
                });

            modelBuilder.Entity("FT.Travelako.Common.Entities.Coupon", b =>
                {
                    b.HasOne("FT.Travelako.Common.Entities.UserCoupon", "UserCoupon")
                        .WithMany("Coupons")
                        .HasForeignKey("UserCouponId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FT.Travelako.Common.Entities.UserCoupon", null)
                        .WithOne("Coupon")
                        .HasForeignKey("FT.Travelako.Common.Entities.Coupon", "UserCouponId1");

                    b.Navigation("UserCoupon");
                });

            modelBuilder.Entity("FT.Travelako.Common.Entities.User", b =>
                {
                    b.HasOne("FT.Travelako.Common.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FT.Travelako.Common.Entities.UserCoupon", "UserCoupon")
                        .WithMany("Users")
                        .HasForeignKey("UserCouponId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FT.Travelako.Common.Entities.UserCoupon", null)
                        .WithOne("User")
                        .HasForeignKey("FT.Travelako.Common.Entities.User", "UserCouponId1");

                    b.Navigation("Role");

                    b.Navigation("UserCoupon");
                });

            modelBuilder.Entity("FT.Travelako.Common.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("FT.Travelako.Common.Entities.Travel", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("FT.Travelako.Common.Entities.User", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("FT.Travelako.Common.Entities.UserCoupon", b =>
                {
                    b.Navigation("Coupon")
                        .IsRequired();

                    b.Navigation("Coupons");

                    b.Navigation("User")
                        .IsRequired();

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
