using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuanLyNongNghiepAPI.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AddressMAC",
                table: "Sensor",
                newName: "Symbol");

            migrationBuilder.RenameColumn(
                name: "AddressIP",
                table: "Sensor",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "AddressMAC",
                table: "Gateway",
                newName: "Symbol");

            migrationBuilder.RenameColumn(
                name: "AddressIP",
                table: "Gateway",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "CategoryName",
                table: "Category",
                newName: "Symbol");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Sensor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Gateway",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Category",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Category",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Sensor");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Gateway");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Category");

            migrationBuilder.RenameColumn(
                name: "Symbol",
                table: "Sensor",
                newName: "AddressMAC");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Sensor",
                newName: "AddressIP");

            migrationBuilder.RenameColumn(
                name: "Symbol",
                table: "Gateway",
                newName: "AddressMAC");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Gateway",
                newName: "AddressIP");

            migrationBuilder.RenameColumn(
                name: "Symbol",
                table: "Category",
                newName: "CategoryName");
        }
    }
}
