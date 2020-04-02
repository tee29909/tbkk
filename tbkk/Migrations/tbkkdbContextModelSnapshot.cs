﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using tbkk.Models;

namespace tbkk.Migrations
{
    [DbContext(typeof(tbkkdbContext))]
    partial class tbkkdbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("tbkk.Models.Canteen", b =>
                {
                    b.Property<int>("CanteenID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Call")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Line")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CanteenID");

                    b.ToTable("Canteen");
                });

            modelBuilder.Entity("tbkk.Models.CarQueue", b =>
                {
                    b.Property<int>("CarQueueID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarNumber")
                        .HasColumnType("int");

                    b.Property<int>("CarQueue_CarTypeID")
                        .HasColumnType("int");

                    b.Property<int>("CarQueue_OTID")
                        .HasColumnType("int");

                    b.Property<int>("CarQueue_PartID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CarQueueID");

                    b.HasIndex("CarQueue_CarTypeID");

                    b.HasIndex("CarQueue_OTID");

                    b.HasIndex("CarQueue_PartID");

                    b.ToTable("CarQueue");
                });

            modelBuilder.Entity("tbkk.Models.CarType", b =>
                {
                    b.Property<int>("CarTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompanyCarID")
                        .HasColumnType("int");

                    b.Property<string>("NameCar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Seat")
                        .HasColumnType("int");

                    b.HasKey("CarTypeID");

                    b.HasIndex("CompanyCarID");

                    b.ToTable("CarType");
                });

            modelBuilder.Entity("tbkk.Models.Company", b =>
                {
                    b.Property<int>("CompanyID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CompanyID");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("tbkk.Models.CompanyCar", b =>
                {
                    b.Property<int>("CompanyCarID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Call")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Company_CompanyID")
                        .HasColumnType("int");

                    b.Property<string>("Line")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameCompanyCar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Seat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CompanyCarID");

                    b.HasIndex("Company_CompanyID");

                    b.ToTable("CompanyCar");
                });

            modelBuilder.Entity("tbkk.Models.Department", b =>
                {
                    b.Property<int>("DepartmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DepartmentName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DepartmentID");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("tbkk.Models.DetailCarQueue", b =>
                {
                    b.Property<int>("DetailCarQueueID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DetailCarQueue_CarQueueID")
                        .HasColumnType("int");

                    b.Property<int>("DetailCarQueue_EmployeeID")
                        .HasColumnType("int");

                    b.HasKey("DetailCarQueueID");

                    b.HasIndex("DetailCarQueue_CarQueueID");

                    b.HasIndex("DetailCarQueue_EmployeeID");

                    b.ToTable("DetailCarQueue");
                });

            modelBuilder.Entity("tbkk.Models.DetailOT", b =>
                {
                    b.Property<int>("DetailOTID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Employee_EmpID")
                        .HasColumnType("int");

                    b.Property<int?>("Employee_UserAdd_EmpID")
                        .HasColumnType("int");

                    b.Property<int>("FoodSet_FoodSetID")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("Hour")
                        .HasColumnType("time");

                    b.Property<int>("OT_OTID")
                        .HasColumnType("int");

                    b.Property<int>("Point_PointID")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TimeEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TimeStart")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DetailOTID");

                    b.HasIndex("Employee_EmpID");

                    b.HasIndex("Employee_UserAdd_EmpID");

                    b.HasIndex("FoodSet_FoodSetID");

                    b.HasIndex("OT_OTID");

                    b.HasIndex("Point_PointID");

                    b.ToTable("DetailOT");
                });

            modelBuilder.Entity("tbkk.Models.Employee", b =>
                {
                    b.Property<int>("EmployeeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Addr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Call")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Employee_CompanyID")
                        .HasColumnType("int");

                    b.Property<int>("Employee_DepartmentID")
                        .HasColumnType("int");

                    b.Property<int>("Employee_EmployeeTypeID")
                        .HasColumnType("int");

                    b.Property<int>("Employee_LocationID")
                        .HasColumnType("int");

                    b.Property<int>("Employee_Num")
                        .HasColumnType("int");

                    b.Property<int>("Employee_PositionID")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Line")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeID");

                    b.HasIndex("Employee_CompanyID");

                    b.HasIndex("Employee_DepartmentID");

                    b.HasIndex("Employee_EmployeeTypeID");

                    b.HasIndex("Employee_LocationID");

                    b.HasIndex("Employee_PositionID");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("tbkk.Models.EmployeeType", b =>
                {
                    b.Property<int>("EmployeeTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmployeeTypeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeTypeID");

                    b.ToTable("EmployeeType");
                });

            modelBuilder.Entity("tbkk.Models.FoodSet", b =>
                {
                    b.Property<int>("FoodSetID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Canteen_CanteenID")
                        .HasColumnType("int");

                    b.Property<string>("FoodSetcoManul")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameSet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("FoodSetID");

                    b.HasIndex("Canteen_CanteenID");

                    b.ToTable("FoodSet");
                });

            modelBuilder.Entity("tbkk.Models.LineToken", b =>
                {
                    b.Property<int>("LineTokenID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Company_CompanyID")
                        .HasColumnType("int");

                    b.Property<string>("TokenCar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TokenFood")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LineTokenID");

                    b.HasIndex("Company_CompanyID");

                    b.ToTable("LineToken");
                });

            modelBuilder.Entity("tbkk.Models.Location", b =>
                {
                    b.Property<int>("LocationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("LocationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LocationID");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("tbkk.Models.Login", b =>
                {
                    b.Property<int>("LoginID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Login_EmployeeID")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LoginID");

                    b.HasIndex("Login_EmployeeID");

                    b.ToTable("Login");
                });

            modelBuilder.Entity("tbkk.Models.OT", b =>
                {
                    b.Property<int>("OTID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("OT_CompanyID")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TimeStart")
                        .HasColumnType("datetime2");

                    b.Property<string>("TypStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeOT")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.HasKey("OTID");

                    b.HasIndex("OT_CompanyID");

                    b.ToTable("OT");
                });

            modelBuilder.Entity("tbkk.Models.Part", b =>
                {
                    b.Property<int>("PartID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.HasKey("PartID");

                    b.ToTable("Part");
                });

            modelBuilder.Entity("tbkk.Models.Point", b =>
                {
                    b.Property<int>("PointID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NamePoint")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Point_PartID")
                        .HasColumnType("int");

                    b.HasKey("PointID");

                    b.HasIndex("Point_PartID");

                    b.ToTable("Point");
                });

            modelBuilder.Entity("tbkk.Models.Position", b =>
                {
                    b.Property<int>("PositionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PositionName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PositionID");

                    b.ToTable("Position");
                });

            modelBuilder.Entity("tbkk.Models.CarQueue", b =>
                {
                    b.HasOne("tbkk.Models.CarType", "CarType")
                        .WithMany()
                        .HasForeignKey("CarQueue_CarTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("tbkk.Models.OT", "OT")
                        .WithMany()
                        .HasForeignKey("CarQueue_OTID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("tbkk.Models.Part", "Part")
                        .WithMany()
                        .HasForeignKey("CarQueue_PartID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("tbkk.Models.CarType", b =>
                {
                    b.HasOne("tbkk.Models.CompanyCar", "CompanyCar")
                        .WithMany()
                        .HasForeignKey("CompanyCarID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("tbkk.Models.CompanyCar", b =>
                {
                    b.HasOne("tbkk.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("Company_CompanyID");
                });

            modelBuilder.Entity("tbkk.Models.DetailCarQueue", b =>
                {
                    b.HasOne("tbkk.Models.CarQueue", "CarQueue")
                        .WithMany()
                        .HasForeignKey("DetailCarQueue_CarQueueID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("tbkk.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("DetailCarQueue_EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("tbkk.Models.DetailOT", b =>
                {
                    b.HasOne("tbkk.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("Employee_EmpID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("tbkk.Models.Employee", "EmployeeAdd")
                        .WithMany()
                        .HasForeignKey("Employee_UserAdd_EmpID");

                    b.HasOne("tbkk.Models.FoodSet", "FoodSet")
                        .WithMany()
                        .HasForeignKey("FoodSet_FoodSetID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("tbkk.Models.OT", "OT")
                        .WithMany()
                        .HasForeignKey("OT_OTID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("tbkk.Models.Point", "Point")
                        .WithMany()
                        .HasForeignKey("Point_PointID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("tbkk.Models.Employee", b =>
                {
                    b.HasOne("tbkk.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("Employee_CompanyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("tbkk.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("Employee_DepartmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("tbkk.Models.EmployeeType", "EmployeeType")
                        .WithMany()
                        .HasForeignKey("Employee_EmployeeTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("tbkk.Models.Location", "Location")
                        .WithMany()
                        .HasForeignKey("Employee_LocationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("tbkk.Models.Position", "Position")
                        .WithMany()
                        .HasForeignKey("Employee_PositionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("tbkk.Models.FoodSet", b =>
                {
                    b.HasOne("tbkk.Models.Canteen", "Canteen")
                        .WithMany()
                        .HasForeignKey("Canteen_CanteenID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("tbkk.Models.LineToken", b =>
                {
                    b.HasOne("tbkk.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("Company_CompanyID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("tbkk.Models.Login", b =>
                {
                    b.HasOne("tbkk.Models.Employee", "Employee")
                        .WithMany()
                        .HasForeignKey("Login_EmployeeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("tbkk.Models.OT", b =>
                {
                    b.HasOne("tbkk.Models.Company", "Company")
                        .WithMany()
                        .HasForeignKey("OT_CompanyID");
                });

            modelBuilder.Entity("tbkk.Models.Point", b =>
                {
                    b.HasOne("tbkk.Models.Part", "Part")
                        .WithMany()
                        .HasForeignKey("Point_PartID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
