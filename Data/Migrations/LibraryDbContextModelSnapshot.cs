﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using LibraryData;

namespace LibraryData.Migrations
{
    [DbContext(typeof(LibraryDbContext))]
    partial class LibraryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LibraryData.Models.BranchHours", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("BranchId");

                    b.Property<int>("CloseTime");

                    b.Property<int>("DayOfWeek");

                    b.Property<int>("OpenTime");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.ToTable("BranchHours");
                });

            modelBuilder.Entity("LibraryData.Models.Checkout", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("LibraryAssetId");

                    b.Property<int?>("LibraryCardId");

                    b.Property<DateTime>("Since");

                    b.Property<DateTime>("Until");

                    b.HasKey("Id");

                    b.HasIndex("LibraryAssetId");

                    b.HasIndex("LibraryCardId");

                    b.ToTable("Checkouts");
                });

            modelBuilder.Entity("LibraryData.Models.CheckoutHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("CheckedIn");

                    b.Property<DateTime>("CheckedOut");

                    b.Property<int>("LibraryAssetId");

                    b.Property<int>("LibraryCardId");

                    b.HasKey("Id");

                    b.HasIndex("LibraryAssetId");

                    b.HasIndex("LibraryCardId");

                    b.ToTable("CheckoutHistories");
                });

            modelBuilder.Entity("LibraryData.Models.Hold", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("HoldPlaced");

                    b.Property<int?>("LibraryAssetId");

                    b.Property<int?>("LibraryCardId");

                    b.HasKey("Id");

                    b.HasIndex("LibraryAssetId");

                    b.HasIndex("LibraryCardId");

                    b.ToTable("Holds");
                });

            modelBuilder.Entity("LibraryData.Models.LibraryAsset", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Cost");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("ImageUrl");

                    b.Property<int?>("LocationId");

                    b.Property<int>("NumberOfCopies");

                    b.Property<int>("StatusId");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<int>("Year");

                    b.HasKey("Id");

                    b.HasIndex("LocationId");

                    b.HasIndex("StatusId");

                    b.ToTable("LibraryAssets");

                    b.HasDiscriminator<string>("Discriminator").HasValue("LibraryAsset");
                });

            modelBuilder.Entity("LibraryData.Models.LibraryBranch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<string>("Description");

                    b.Property<string>("ImageUrl");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<DateTime>("OpenDate");

                    b.Property<string>("Telephone")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("LibraryBranches");
                });

            modelBuilder.Entity("LibraryData.Models.LibraryCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<decimal>("Fees");

                    b.HasKey("Id");

                    b.ToTable("LibraryCards");
                });

            modelBuilder.Entity("LibraryData.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Author");

                    b.Property<string>("Content")
                        .IsRequired();

                    b.Property<string>("Date")
                        .IsRequired();

                    b.Property<string>("ImageUrl")
                        .IsRequired();

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("LibraryData.Models.Patron", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address")
                        .IsRequired();

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Gender");

                    b.Property<int?>("HomeLibraryBranchId");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<int>("LibraryCardId");

                    b.Property<string>("Telephone");

                    b.HasKey("Id");

                    b.HasIndex("HomeLibraryBranchId");

                    b.HasIndex("LibraryCardId");

                    b.ToTable("Patrons");
                });

            modelBuilder.Entity("LibraryData.Models.Status", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("Statuses");
                });

            modelBuilder.Entity("LibraryData.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("LibraryData.Models.Book", b =>
                {
                    b.HasBaseType("LibraryData.Models.LibraryAsset");

                    b.Property<string>("Author")
                        .IsRequired();

                    b.Property<string>("DeweyIndex")
                        .IsRequired();

                    b.Property<string>("ISBN")
                        .IsRequired();

                    b.ToTable("Book");

                    b.HasDiscriminator().HasValue("Book");
                });

            modelBuilder.Entity("LibraryData.Models.BranchHours", b =>
                {
                    b.HasOne("LibraryData.Models.LibraryBranch", "Branch")
                        .WithMany()
                        .HasForeignKey("BranchId");
                });

            modelBuilder.Entity("LibraryData.Models.Checkout", b =>
                {
                    b.HasOne("LibraryData.Models.LibraryAsset", "LibraryAsset")
                        .WithMany()
                        .HasForeignKey("LibraryAssetId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LibraryData.Models.LibraryCard", "LibraryCard")
                        .WithMany("Checkouts")
                        .HasForeignKey("LibraryCardId");
                });

            modelBuilder.Entity("LibraryData.Models.CheckoutHistory", b =>
                {
                    b.HasOne("LibraryData.Models.LibraryAsset", "LibraryAsset")
                        .WithMany()
                        .HasForeignKey("LibraryAssetId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LibraryData.Models.LibraryCard", "LibraryCard")
                        .WithMany()
                        .HasForeignKey("LibraryCardId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LibraryData.Models.Hold", b =>
                {
                    b.HasOne("LibraryData.Models.LibraryAsset", "LibraryAsset")
                        .WithMany()
                        .HasForeignKey("LibraryAssetId");

                    b.HasOne("LibraryData.Models.LibraryCard", "LibraryCard")
                        .WithMany()
                        .HasForeignKey("LibraryCardId");
                });

            modelBuilder.Entity("LibraryData.Models.LibraryAsset", b =>
                {
                    b.HasOne("LibraryData.Models.LibraryBranch", "Location")
                        .WithMany("LibraryAssets")
                        .HasForeignKey("LocationId");

                    b.HasOne("LibraryData.Models.Status", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LibraryData.Models.Movie", b =>
                {
                    b.HasOne("LibraryData.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("LibraryData.Models.Patron", b =>
                {
                    b.HasOne("LibraryData.Models.LibraryBranch", "HomeLibraryBranch")
                        .WithMany("Patrons")
                        .HasForeignKey("HomeLibraryBranchId");

                    b.HasOne("LibraryData.Models.LibraryCard", "LibraryCard")
                        .WithMany()
                        .HasForeignKey("LibraryCardId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("LibraryData.Models.User")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("LibraryData.Models.User")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LibraryData.Models.User")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
