using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace tbkk.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Canteen",
                columns: table => new
                {
                    CanteenID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Line = table.Column<string>(nullable: true),
                    Call = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Canteen", x => x.CanteenID);
                });

            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    CompanyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.CompanyID);
                });

            migrationBuilder.CreateTable(
                name: "CompanyCar",
                columns: table => new
                {
                    CompanyCarID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameCompanyCar = table.Column<string>(nullable: true),
                    Seat = table.Column<string>(nullable: true),
                    Line = table.Column<string>(nullable: true),
                    Call = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyCar", x => x.CompanyCarID);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    DepartmentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepartmentID);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeType",
                columns: table => new
                {
                    EmployeeTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeType", x => x.EmployeeTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Location",
                columns: table => new
                {
                    LocationID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationName = table.Column<string>(nullable: true),
                    Note = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.LocationID);
                });

            migrationBuilder.CreateTable(
                name: "OT",
                columns: table => new
                {
                    OTID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeStart = table.Column<DateTime>(nullable: false),
                    TimeEnd = table.Column<DateTime>(nullable: false),
                    TypeOT = table.Column<string>(nullable: true),
                    TypStatus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OT", x => x.OTID);
                });

            migrationBuilder.CreateTable(
                name: "Part",
                columns: table => new
                {
                    PartID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Part", x => x.PartID);
                });

            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    PositionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PositionName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.PositionID);
                });

            migrationBuilder.CreateTable(
                name: "FoodSet",
                columns: table => new
                {
                    FoodSetID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodSetcoManul = table.Column<string>(nullable: true),
                    NameSet = table.Column<string>(nullable: true),
                    Canteen_CanteenID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodSet", x => x.FoodSetID);
                    table.ForeignKey(
                        name: "FK_FoodSet_Canteen_Canteen_CanteenID",
                        column: x => x.Canteen_CanteenID,
                        principalTable: "Canteen",
                        principalColumn: "CanteenID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarType",
                columns: table => new
                {
                    CarTypeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameCar = table.Column<string>(nullable: true),
                    Seat = table.Column<string>(nullable: true),
                    CompanyCarID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarType", x => x.CarTypeID);
                    table.ForeignKey(
                        name: "FK_CarType_CompanyCar_CompanyCarID",
                        column: x => x.CompanyCarID,
                        principalTable: "CompanyCar",
                        principalColumn: "CompanyCarID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Call = table.Column<string>(nullable: true),
                    Line = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Addr = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    Company_CompanyID = table.Column<int>(nullable: false),
                    Department_DepartmentID = table.Column<int>(nullable: false),
                    Location_LocationID = table.Column<int>(nullable: false),
                    EmployeeType_EmployeeTypeID = table.Column<int>(nullable: false),
                    Position_PositionID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeID);
                    table.ForeignKey(
                        name: "FK_Employee_Company_Company_CompanyID",
                        column: x => x.Company_CompanyID,
                        principalTable: "Company",
                        principalColumn: "CompanyID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employee_Department_Department_DepartmentID",
                        column: x => x.Department_DepartmentID,
                        principalTable: "Department",
                        principalColumn: "DepartmentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employee_EmployeeType_EmployeeType_EmployeeTypeID",
                        column: x => x.EmployeeType_EmployeeTypeID,
                        principalTable: "EmployeeType",
                        principalColumn: "EmployeeTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employee_Location_Location_LocationID",
                        column: x => x.Location_LocationID,
                        principalTable: "Location",
                        principalColumn: "LocationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employee_Position_Position_PositionID",
                        column: x => x.Position_PositionID,
                        principalTable: "Position",
                        principalColumn: "PositionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetailOT",
                columns: table => new
                {
                    DetailOTID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeStart = table.Column<DateTime>(nullable: false),
                    TimeEnd = table.Column<DateTime>(nullable: false),
                    Hour = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    CarNumber = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Part_PaetID = table.Column<int>(nullable: false),
                    FoodSet_FoodSetID = table.Column<int>(nullable: false),
                    CarType_CarTypeID = table.Column<int>(nullable: false),
                    OT_OTID = table.Column<int>(nullable: false),
                    Employee_EmpID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailOT", x => x.DetailOTID);
                    table.ForeignKey(
                        name: "FK_DetailOT_CarType_CarType_CarTypeID",
                        column: x => x.CarType_CarTypeID,
                        principalTable: "CarType",
                        principalColumn: "CarTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetailOT_Employee_Employee_EmpID",
                        column: x => x.Employee_EmpID,
                        principalTable: "Employee",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetailOT_FoodSet_FoodSet_FoodSetID",
                        column: x => x.FoodSet_FoodSetID,
                        principalTable: "FoodSet",
                        principalColumn: "FoodSetID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetailOT_OT_OT_OTID",
                        column: x => x.OT_OTID,
                        principalTable: "OT",
                        principalColumn: "OTID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetailOT_Part_Part_PaetID",
                        column: x => x.Part_PaetID,
                        principalTable: "Part",
                        principalColumn: "PartID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Login",
                columns: table => new
                {
                    LoginID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Employee_EmployeeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Login", x => x.LoginID);
                    table.ForeignKey(
                        name: "FK_Login_Employee_Employee_EmployeeID",
                        column: x => x.Employee_EmployeeID,
                        principalTable: "Employee",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarType_CompanyCarID",
                table: "CarType",
                column: "CompanyCarID");

            migrationBuilder.CreateIndex(
                name: "IX_DetailOT_CarType_CarTypeID",
                table: "DetailOT",
                column: "CarType_CarTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_DetailOT_Employee_EmpID",
                table: "DetailOT",
                column: "Employee_EmpID");

            migrationBuilder.CreateIndex(
                name: "IX_DetailOT_FoodSet_FoodSetID",
                table: "DetailOT",
                column: "FoodSet_FoodSetID");

            migrationBuilder.CreateIndex(
                name: "IX_DetailOT_OT_OTID",
                table: "DetailOT",
                column: "OT_OTID");

            migrationBuilder.CreateIndex(
                name: "IX_DetailOT_Part_PaetID",
                table: "DetailOT",
                column: "Part_PaetID");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Company_CompanyID",
                table: "Employee",
                column: "Company_CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Department_DepartmentID",
                table: "Employee",
                column: "Department_DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_EmployeeType_EmployeeTypeID",
                table: "Employee",
                column: "EmployeeType_EmployeeTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Location_LocationID",
                table: "Employee",
                column: "Location_LocationID");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Position_PositionID",
                table: "Employee",
                column: "Position_PositionID");

            migrationBuilder.CreateIndex(
                name: "IX_FoodSet_Canteen_CanteenID",
                table: "FoodSet",
                column: "Canteen_CanteenID");

            migrationBuilder.CreateIndex(
                name: "IX_Login_Employee_EmployeeID",
                table: "Login",
                column: "Employee_EmployeeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetailOT");

            migrationBuilder.DropTable(
                name: "Login");

            migrationBuilder.DropTable(
                name: "CarType");

            migrationBuilder.DropTable(
                name: "FoodSet");

            migrationBuilder.DropTable(
                name: "OT");

            migrationBuilder.DropTable(
                name: "Part");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "CompanyCar");

            migrationBuilder.DropTable(
                name: "Canteen");

            migrationBuilder.DropTable(
                name: "Company");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "EmployeeType");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Position");
        }
    }
}
