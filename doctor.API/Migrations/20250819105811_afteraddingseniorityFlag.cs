using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace doctor.API.Migrations
{
    /// <inheritdoc />
    public partial class afteraddingseniorityFlag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSenior",
                table: "Doctors",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 100,
                column: "IsSenior",
                value: false);

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 101,
                columns: new[] { "IsSenior", "Name" },
                values: new object[] { false, "Pranay" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSenior",
                table: "Doctors");

            migrationBuilder.UpdateData(
                table: "Doctors",
                keyColumn: "Id",
                keyValue: 101,
                column: "Name",
                value: "Ashfak");
        }
    }
}
