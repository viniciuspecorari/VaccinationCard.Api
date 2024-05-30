using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VaccinationCard.Api.Migrations
{
    /// <inheritdoc />
    public partial class InicializeModelDose : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Doses",
                columns: new[] { "Id", "DoseType" },
                values: new object[,]
                {
                    { 1, "1º Dose" },
                    { 2, "2º Dose" },
                    { 3, "3º Dose" },
                    { 4, "4º Dose (Reforço)" },
                    { 5, "5º Dose (Reforço)" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Doses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Doses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Doses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Doses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Doses",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
