using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace tbkk.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Company",
                columns: table => new
                {
                    CompanyID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: false),
                    Status = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Company", x => x.CompanyID);
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    DepartmentID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(nullable: false),
                    Image = table.Column<string>(nullable: false),
                    Status = table.Column<string>(nullable: false)
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
                    LocationName = table.Column<string>(nullable: false),
                    Note = table.Column<string>(nullable: false),
                    Status = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Location", x => x.LocationID);
                });

            migrationBuilder.CreateTable(
                name: "Part",
                columns: table => new
                {
                    PartID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false)
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
                name: "Canteen",
                columns: table => new
                {
                    CanteenID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Line = table.Column<string>(nullable: true),
                    Call = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Canteen_CompanyID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Canteen", x => x.CanteenID);
                    table.ForeignKey(
                        name: "FK_Canteen_Company_Canteen_CompanyID",
                        column: x => x.Canteen_CompanyID,
                        principalTable: "Company",
                        principalColumn: "CompanyID",
                        onDelete: ReferentialAction.Restrict);
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
                    Status = table.Column<string>(nullable: true),
                    Company_CompanyID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyCar", x => x.CompanyCarID);
                    table.ForeignKey(
                        name: "FK_CompanyCar_Company_Company_CompanyID",
                        column: x => x.Company_CompanyID,
                        principalTable: "Company",
                        principalColumn: "CompanyID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LineToken",
                columns: table => new
                {
                    LineTokenID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TokenCar = table.Column<string>(nullable: false),
                    TokenFood = table.Column<string>(nullable: false),
                    Company_CompanyID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineToken", x => x.LineTokenID);
                    table.ForeignKey(
                        name: "FK_LineToken_Company_Company_CompanyID",
                        column: x => x.Company_CompanyID,
                        principalTable: "Company",
                        principalColumn: "CompanyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OT",
                columns: table => new
                {
                    OTID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TimeStart = table.Column<DateTime>(nullable: false),
                    TimeEnd = table.Column<DateTime>(nullable: false),
                    date = table.Column<DateTime>(nullable: false),
                    TypeOT = table.Column<string>(nullable: true),
                    TypStatus = table.Column<string>(nullable: true),
                    OT_CompanyID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OT", x => x.OTID);
                    table.ForeignKey(
                        name: "FK_OT_Company_OT_CompanyID",
                        column: x => x.OT_CompanyID,
                        principalTable: "Company",
                        principalColumn: "CompanyID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Point",
                columns: table => new
                {
                    PointID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NamePoint = table.Column<string>(nullable: true),
                    Point_PartID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Point", x => x.PointID);
                    table.ForeignKey(
                        name: "FK_Point_Part_Point_PartID",
                        column: x => x.Point_PartID,
                        principalTable: "Part",
                        principalColumn: "PartID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Employee_Num = table.Column<int>(nullable: false),
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
                    Employee_CompanyID = table.Column<int>(nullable: false),
                    Employee_DepartmentID = table.Column<int>(nullable: false),
                    Employee_LocationID = table.Column<int>(nullable: false),
                    Employee_EmployeeTypeID = table.Column<int>(nullable: false),
                    Employee_PositionID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeID);
                    table.ForeignKey(
                        name: "FK_Employee_Company_Employee_CompanyID",
                        column: x => x.Employee_CompanyID,
                        principalTable: "Company",
                        principalColumn: "CompanyID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employee_Department_Employee_DepartmentID",
                        column: x => x.Employee_DepartmentID,
                        principalTable: "Department",
                        principalColumn: "DepartmentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employee_EmployeeType_Employee_EmployeeTypeID",
                        column: x => x.Employee_EmployeeTypeID,
                        principalTable: "EmployeeType",
                        principalColumn: "EmployeeTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employee_Location_Employee_LocationID",
                        column: x => x.Employee_LocationID,
                        principalTable: "Location",
                        principalColumn: "LocationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employee_Position_Employee_PositionID",
                        column: x => x.Employee_PositionID,
                        principalTable: "Position",
                        principalColumn: "PositionID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FoodSet",
                columns: table => new
                {
                    FoodSetID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodSetcoManul = table.Column<string>(nullable: true),
                    NameSet = table.Column<string>(nullable: true),
                    Price = table.Column<int>(nullable: false),
                    Status = table.Column<string>(nullable: true),
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
                    Seat = table.Column<int>(nullable: false),
                    Status = table.Column<string>(nullable: true),
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
                name: "Login",
                columns: table => new
                {
                    LoginID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Login_EmployeeID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Login", x => x.LoginID);
                    table.ForeignKey(
                        name: "FK_Login_Employee_Login_EmployeeID",
                        column: x => x.Login_EmployeeID,
                        principalTable: "Employee",
                        principalColumn: "EmployeeID",
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
                    Hour = table.Column<TimeSpan>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    Point_PointID = table.Column<int>(nullable: false),
                    FoodSet_FoodSetID = table.Column<int>(nullable: false),
                    OT_OTID = table.Column<int>(nullable: false),
                    Employee_EmpID = table.Column<int>(nullable: false),
                    Employee_UserAdd_EmpID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailOT", x => x.DetailOTID);
                    table.ForeignKey(
                        name: "FK_DetailOT_Employee_Employee_EmpID",
                        column: x => x.Employee_EmpID,
                        principalTable: "Employee",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetailOT_Employee_Employee_UserAdd_EmpID",
                        column: x => x.Employee_UserAdd_EmpID,
                        principalTable: "Employee",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Restrict);
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
                        name: "FK_DetailOT_Point_Point_PointID",
                        column: x => x.Point_PointID,
                        principalTable: "Point",
                        principalColumn: "PointID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarQueue",
                columns: table => new
                {
                    CarQueueID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarNumber = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    Time = table.Column<DateTime>(nullable: false),
                    CarQueue_OTID = table.Column<int>(nullable: false),
                    CarQueue_CarTypeID = table.Column<int>(nullable: false),
                    CarQueue_PartID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarQueue", x => x.CarQueueID);
                    table.ForeignKey(
                        name: "FK_CarQueue_CarType_CarQueue_CarTypeID",
                        column: x => x.CarQueue_CarTypeID,
                        principalTable: "CarType",
                        principalColumn: "CarTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarQueue_OT_CarQueue_OTID",
                        column: x => x.CarQueue_OTID,
                        principalTable: "OT",
                        principalColumn: "OTID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarQueue_Part_CarQueue_PartID",
                        column: x => x.CarQueue_PartID,
                        principalTable: "Part",
                        principalColumn: "PartID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetailCarQueue",
                columns: table => new
                {
                    DetailCarQueueID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DetailCarQueue_EmployeeID = table.Column<int>(nullable: false),
                    DetailCarQueue_CarQueueID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailCarQueue", x => x.DetailCarQueueID);
                    table.ForeignKey(
                        name: "FK_DetailCarQueue_CarQueue_DetailCarQueue_CarQueueID",
                        column: x => x.DetailCarQueue_CarQueueID,
                        principalTable: "CarQueue",
                        principalColumn: "CarQueueID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetailCarQueue_Employee_DetailCarQueue_EmployeeID",
                        column: x => x.DetailCarQueue_EmployeeID,
                        principalTable: "Employee",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Canteen_Canteen_CompanyID",
                table: "Canteen",
                column: "Canteen_CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_CarQueue_CarQueue_CarTypeID",
                table: "CarQueue",
                column: "CarQueue_CarTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_CarQueue_CarQueue_OTID",
                table: "CarQueue",
                column: "CarQueue_OTID");

            migrationBuilder.CreateIndex(
                name: "IX_CarQueue_CarQueue_PartID",
                table: "CarQueue",
                column: "CarQueue_PartID");

            migrationBuilder.CreateIndex(
                name: "IX_CarType_CompanyCarID",
                table: "CarType",
                column: "CompanyCarID");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyCar_Company_CompanyID",
                table: "CompanyCar",
                column: "Company_CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_DetailCarQueue_DetailCarQueue_CarQueueID",
                table: "DetailCarQueue",
                column: "DetailCarQueue_CarQueueID");

            migrationBuilder.CreateIndex(
                name: "IX_DetailCarQueue_DetailCarQueue_EmployeeID",
                table: "DetailCarQueue",
                column: "DetailCarQueue_EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_DetailOT_Employee_EmpID",
                table: "DetailOT",
                column: "Employee_EmpID");

            migrationBuilder.CreateIndex(
                name: "IX_DetailOT_Employee_UserAdd_EmpID",
                table: "DetailOT",
                column: "Employee_UserAdd_EmpID");

            migrationBuilder.CreateIndex(
                name: "IX_DetailOT_FoodSet_FoodSetID",
                table: "DetailOT",
                column: "FoodSet_FoodSetID");

            migrationBuilder.CreateIndex(
                name: "IX_DetailOT_OT_OTID",
                table: "DetailOT",
                column: "OT_OTID");

            migrationBuilder.CreateIndex(
                name: "IX_DetailOT_Point_PointID",
                table: "DetailOT",
                column: "Point_PointID");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Employee_CompanyID",
                table: "Employee",
                column: "Employee_CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Employee_DepartmentID",
                table: "Employee",
                column: "Employee_DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Employee_EmployeeTypeID",
                table: "Employee",
                column: "Employee_EmployeeTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Employee_LocationID",
                table: "Employee",
                column: "Employee_LocationID");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_Employee_PositionID",
                table: "Employee",
                column: "Employee_PositionID");

            migrationBuilder.CreateIndex(
                name: "IX_FoodSet_Canteen_CanteenID",
                table: "FoodSet",
                column: "Canteen_CanteenID");

            migrationBuilder.CreateIndex(
                name: "IX_LineToken_Company_CompanyID",
                table: "LineToken",
                column: "Company_CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_Login_Login_EmployeeID",
                table: "Login",
                column: "Login_EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_OT_OT_CompanyID",
                table: "OT",
                column: "OT_CompanyID");

            migrationBuilder.CreateIndex(
                name: "IX_Point_Point_PartID",
                table: "Point",
                column: "Point_PartID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetailCarQueue");

            migrationBuilder.DropTable(
                name: "DetailOT");

            migrationBuilder.DropTable(
                name: "LineToken");

            migrationBuilder.DropTable(
                name: "Login");

            migrationBuilder.DropTable(
                name: "CarQueue");

            migrationBuilder.DropTable(
                name: "FoodSet");

            migrationBuilder.DropTable(
                name: "Point");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "CarType");

            migrationBuilder.DropTable(
                name: "OT");

            migrationBuilder.DropTable(
                name: "Canteen");

            migrationBuilder.DropTable(
                name: "Part");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "EmployeeType");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Position");

            migrationBuilder.DropTable(
                name: "CompanyCar");

            migrationBuilder.DropTable(
                name: "Company");
        }
    }
}
