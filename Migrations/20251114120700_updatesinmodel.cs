using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalRecordApi.Migrations
{
    /// <inheritdoc />
    public partial class updatesinmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EndoscopyPostProcedureRecords_EndoscopyProcedureRecords_Endo~",
                table: "EndoscopyPostProcedureRecords");

            migrationBuilder.DropIndex(
                name: "IX_EndoscopyPostProcedureRecords_EndoscopyProcedureRecordId",
                table: "EndoscopyPostProcedureRecords");

            migrationBuilder.AlterColumn<string>(
                name: "Time",
                table: "NursingMedicationEntries",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Route",
                table: "NursingMedicationEntries",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Response",
                table: "NursingMedicationEntries",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Nurse",
                table: "NursingMedicationEntries",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Medication",
                table: "NursingMedicationEntries",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Reassessment",
                table: "EndoscopyPostProcedureRecords",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "OperativeProcedure",
                table: "EndoscopyPostProcedureRecords",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "EndoscopyPostProcedureRecords",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "EndoscopyPostProcedureRecords",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "EndoscopyPostProcedureRecords",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "BP",
                table: "EndoscopyPostProcedureRecords",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Action",
                table: "EndoscopyPostProcedureRecords",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "NursingMedicationEntries",
                keyColumn: "Time",
                keyValue: null,
                column: "Time",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Time",
                table: "NursingMedicationEntries",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "NursingMedicationEntries",
                keyColumn: "Route",
                keyValue: null,
                column: "Route",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Route",
                table: "NursingMedicationEntries",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "NursingMedicationEntries",
                keyColumn: "Response",
                keyValue: null,
                column: "Response",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Response",
                table: "NursingMedicationEntries",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "NursingMedicationEntries",
                keyColumn: "Nurse",
                keyValue: null,
                column: "Nurse",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Nurse",
                table: "NursingMedicationEntries",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "NursingMedicationEntries",
                keyColumn: "Medication",
                keyValue: null,
                column: "Medication",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Medication",
                table: "NursingMedicationEntries",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "EndoscopyPostProcedureRecords",
                keyColumn: "Reassessment",
                keyValue: null,
                column: "Reassessment",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Reassessment",
                table: "EndoscopyPostProcedureRecords",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "EndoscopyPostProcedureRecords",
                keyColumn: "OperativeProcedure",
                keyValue: null,
                column: "OperativeProcedure",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "OperativeProcedure",
                table: "EndoscopyPostProcedureRecords",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "EndoscopyPostProcedureRecords",
                keyColumn: "Notes",
                keyValue: null,
                column: "Notes",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Notes",
                table: "EndoscopyPostProcedureRecords",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "EndoscopyPostProcedureRecords",
                keyColumn: "Location",
                keyValue: null,
                column: "Location",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "EndoscopyPostProcedureRecords",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "EndoscopyPostProcedureRecords",
                keyColumn: "Description",
                keyValue: null,
                column: "Description",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "EndoscopyPostProcedureRecords",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "EndoscopyPostProcedureRecords",
                keyColumn: "BP",
                keyValue: null,
                column: "BP",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "BP",
                table: "EndoscopyPostProcedureRecords",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "EndoscopyPostProcedureRecords",
                keyColumn: "Action",
                keyValue: null,
                column: "Action",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Action",
                table: "EndoscopyPostProcedureRecords",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_EndoscopyPostProcedureRecords_EndoscopyProcedureRecordId",
                table: "EndoscopyPostProcedureRecords",
                column: "EndoscopyProcedureRecordId");

            migrationBuilder.AddForeignKey(
                name: "FK_EndoscopyPostProcedureRecords_EndoscopyProcedureRecords_Endo~",
                table: "EndoscopyPostProcedureRecords",
                column: "EndoscopyProcedureRecordId",
                principalTable: "EndoscopyProcedureRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
