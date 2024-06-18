using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SPA.Migrations.SecondDb
{
    /// <inheritdoc />
    public partial class ChangelogUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Table",
                table: "ChangeLogs",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Table",
                table: "ChangeLogs");
        }
    }
}
