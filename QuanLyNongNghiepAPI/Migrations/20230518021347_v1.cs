using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyNongNghiepAPI.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admin",
                columns: table => new
                {
                    AdminID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admin", x => x.AdminID);
                });

            migrationBuilder.CreateTable(
                name: "Area",
                columns: table => new
                {
                    AreaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area", x => x.AreaID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "System",
                columns: table => new
                {
                    SystemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())"),
                    AreaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_System", x => x.SystemID);
                    table.ForeignKey(
                        name: "FK_System_Area_AreaID",
                        column: x => x.AreaID,
                        principalTable: "Area",
                        principalColumn: "AreaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserArea",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false),
                    AreaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserArea", x => new { x.UserID, x.AreaID });
                    table.ForeignKey(
                        name: "FK_UserArea_Area_AreaID",
                        column: x => x.AreaID,
                        principalTable: "Area",
                        principalColumn: "AreaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserArea_User_UserID",
                        column: x => x.UserID,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Guest",
                columns: table => new
                {
                    GuestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SystemID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guest", x => x.GuestID);
                    table.ForeignKey(
                        name: "FK_Guest_System_SystemID",
                        column: x => x.SystemID,
                        principalTable: "System",
                        principalColumn: "SystemID");
                });

            migrationBuilder.CreateTable(
                name: "ResponseGateway",
                columns: table => new
                {
                    ResponseGatewayID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())"),
                    SystemID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponseGateway", x => x.ResponseGatewayID);
                    table.ForeignKey(
                        name: "FK_ResponseGateway_System_SystemID",
                        column: x => x.SystemID,
                        principalTable: "System",
                        principalColumn: "SystemID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sensor",
                columns: table => new
                {
                    SensorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Symbol = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SystemID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sensor", x => x.SensorID);
                    table.ForeignKey(
                        name: "FK_Sensor_System_SystemID",
                        column: x => x.SystemID,
                        principalTable: "System",
                        principalColumn: "SystemID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SystemProcess",
                columns: table => new
                {
                    SystemProcessID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NotificationType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDone = table.Column<bool>(type: "bit", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SystemID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemProcess", x => x.SystemProcessID);
                    table.ForeignKey(
                        name: "FK_SystemProcess_System_SystemID",
                        column: x => x.SystemID,
                        principalTable: "System",
                        principalColumn: "SystemID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SensorData",
                columns: table => new
                {
                    SensorDataID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<double>(type: "float", nullable: false),
                    SensorID = table.Column<int>(type: "int", nullable: false),
                    ResponseGatewayID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SensorData", x => x.SensorDataID);
                    table.ForeignKey(
                        name: "FK_SensorData_ResponseGateway_ResponseGatewayID",
                        column: x => x.ResponseGatewayID,
                        principalTable: "ResponseGateway",
                        principalColumn: "ResponseGatewayID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SensorData_Sensor_SensorID",
                        column: x => x.SensorID,
                        principalTable: "Sensor",
                        principalColumn: "SensorID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SystemProcessCondition",
                columns: table => new
                {
                    SystemProcessConditionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ValueMin = table.Column<double>(type: "float", nullable: true),
                    ValueMax = table.Column<double>(type: "float", nullable: true),
                    ValueAvg = table.Column<double>(type: "float", nullable: true),
                    Step = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SensorID = table.Column<int>(type: "int", nullable: false),
                    SystemProcessID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemProcessCondition", x => x.SystemProcessConditionID);
                    table.ForeignKey(
                        name: "FK_SystemProcessCondition_Sensor_SensorID",
                        column: x => x.SensorID,
                        principalTable: "Sensor",
                        principalColumn: "SensorID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SystemProcessCondition_SystemProcess_SystemProcessID",
                        column: x => x.SystemProcessID,
                        principalTable: "SystemProcess",
                        principalColumn: "SystemProcessID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SystemProcessNote",
                columns: table => new
                {
                    SystemProcessNoteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NotificationType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDone = table.Column<bool>(type: "bit", nullable: false),
                    CreateAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "(getdate())"),
                    SystemProcessID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemProcessNote", x => x.SystemProcessNoteID);
                    table.ForeignKey(
                        name: "FK_SystemProcessNote_SystemProcess_SystemProcessID",
                        column: x => x.SystemProcessID,
                        principalTable: "SystemProcess",
                        principalColumn: "SystemProcessID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admin_Username",
                table: "Admin",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Guest_SystemID",
                table: "Guest",
                column: "SystemID");

            migrationBuilder.CreateIndex(
                name: "IX_Guest_Username",
                table: "Guest",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ResponseGateway_SystemID",
                table: "ResponseGateway",
                column: "SystemID");

            migrationBuilder.CreateIndex(
                name: "IX_Sensor_SystemID",
                table: "Sensor",
                column: "SystemID");

            migrationBuilder.CreateIndex(
                name: "IX_SensorData_ResponseGatewayID",
                table: "SensorData",
                column: "ResponseGatewayID");

            migrationBuilder.CreateIndex(
                name: "IX_SensorData_SensorID",
                table: "SensorData",
                column: "SensorID");

            migrationBuilder.CreateIndex(
                name: "IX_System_Address",
                table: "System",
                column: "Address",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_System_AreaID",
                table: "System",
                column: "AreaID");

            migrationBuilder.CreateIndex(
                name: "IX_SystemProcess_SystemID",
                table: "SystemProcess",
                column: "SystemID");

            migrationBuilder.CreateIndex(
                name: "IX_SystemProcessCondition_SensorID",
                table: "SystemProcessCondition",
                column: "SensorID");

            migrationBuilder.CreateIndex(
                name: "IX_SystemProcessCondition_SystemProcessID",
                table: "SystemProcessCondition",
                column: "SystemProcessID");

            migrationBuilder.CreateIndex(
                name: "IX_SystemProcessNote_SystemProcessID",
                table: "SystemProcessNote",
                column: "SystemProcessID");

            migrationBuilder.CreateIndex(
                name: "IX_User_Username",
                table: "User",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserArea_AreaID",
                table: "UserArea",
                column: "AreaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admin");

            migrationBuilder.DropTable(
                name: "Guest");

            migrationBuilder.DropTable(
                name: "SensorData");

            migrationBuilder.DropTable(
                name: "SystemProcessCondition");

            migrationBuilder.DropTable(
                name: "SystemProcessNote");

            migrationBuilder.DropTable(
                name: "UserArea");

            migrationBuilder.DropTable(
                name: "ResponseGateway");

            migrationBuilder.DropTable(
                name: "Sensor");

            migrationBuilder.DropTable(
                name: "SystemProcess");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "System");

            migrationBuilder.DropTable(
                name: "Area");
        }
    }
}
