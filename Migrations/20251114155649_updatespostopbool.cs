using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalRecordApi.Migrations
{
    /// <inheritdoc />
    public partial class updatespostopbool : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "PostOp",
                table: "EndoscopyProcedureRecords",
                type: "tinyint(1)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostOp",
                table: "EndoscopyProcedureRecords");
        }
    }
}
