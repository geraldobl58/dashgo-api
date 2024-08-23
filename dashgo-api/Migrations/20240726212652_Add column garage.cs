using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dashgo_api.Migrations
{
    /// <inheritdoc />
    public partial class Addcolumngarage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Graage",
                table: "Properties",
                newName: "Garage");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Garage",
                table: "Properties",
                newName: "Graage");
        }
    }
}
