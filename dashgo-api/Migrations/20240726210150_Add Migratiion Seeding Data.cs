using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace dashgo_api.Migrations
{
    /// <inheritdoc />
    public partial class AddMigratiionSeedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { new Guid("386391a8-52c9-4c4b-899e-231bd7344e70"), "Apartamento" },
                    { new Guid("39f0a24a-1e18-435d-bc44-48744b6c2a03"), "Casa" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("386391a8-52c9-4c4b-899e-231bd7344e70"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("39f0a24a-1e18-435d-bc44-48744b6c2a03"));
        }
    }
}
