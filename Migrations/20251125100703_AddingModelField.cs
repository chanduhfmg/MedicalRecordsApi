using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalRecordApi.Migrations
{
    /// <inheritdoc />
    public partial class AddingModelField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "facility",
                table: "EndoscopyProcedureRecords",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "facility",
                table: "EndoscopyProcedureRecords");
        }
    }
}
