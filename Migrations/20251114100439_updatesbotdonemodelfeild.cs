using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalRecordApi.Migrations
{
    /// <inheritdoc />
    public partial class updatesbotdonemodelfeild : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AldreteScoreDto_EndoscopyPostProcedureRecords_EndoscopyPostP~",
                table: "AldreteScoreDto");

            migrationBuilder.DropForeignKey(
                name: "FK_AssessmentMonitoringRowDto_EndoscopyPostProcedureRecords_End~",
                table: "AssessmentMonitoringRowDto");

            migrationBuilder.DropForeignKey(
                name: "FK_NursingMedicationEntryDto_EndoscopyPostProcedureRecords_Endo~",
                table: "NursingMedicationEntryDto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NursingMedicationEntryDto",
                table: "NursingMedicationEntryDto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssessmentMonitoringRowDto",
                table: "AssessmentMonitoringRowDto");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AldreteScoreDto",
                table: "AldreteScoreDto");

            migrationBuilder.RenameTable(
                name: "NursingMedicationEntryDto",
                newName: "NursingMedicationEntries");

            migrationBuilder.RenameTable(
                name: "AssessmentMonitoringRowDto",
                newName: "AssessmentMonitoringRows");

            migrationBuilder.RenameTable(
                name: "AldreteScoreDto",
                newName: "AldreteScores");

            migrationBuilder.RenameIndex(
                name: "IX_NursingMedicationEntryDto_EndoscopyPostProcedureRecordId",
                table: "NursingMedicationEntries",
                newName: "IX_NursingMedicationEntries_EndoscopyPostProcedureRecordId");

            migrationBuilder.RenameIndex(
                name: "IX_AssessmentMonitoringRowDto_EndoscopyPostProcedureRecordId",
                table: "AssessmentMonitoringRows",
                newName: "IX_AssessmentMonitoringRows_EndoscopyPostProcedureRecordId");

            migrationBuilder.RenameIndex(
                name: "IX_AldreteScoreDto_EndoscopyPostProcedureRecordId",
                table: "AldreteScores",
                newName: "IX_AldreteScores_EndoscopyPostProcedureRecordId");

            migrationBuilder.AddColumn<string>(
                name: "AccNo",
                table: "EndoscopyProcedureRecords",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<bool>(
                name: "BotJobDone",
                table: "EndoscopyProcedureRecords",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "AccNo",
                table: "EndoscopyPostProcedureRecords",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NursingMedicationEntries",
                table: "NursingMedicationEntries",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssessmentMonitoringRows",
                table: "AssessmentMonitoringRows",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AldreteScores",
                table: "AldreteScores",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AldreteScores_EndoscopyPostProcedureRecords_EndoscopyPostPro~",
                table: "AldreteScores",
                column: "EndoscopyPostProcedureRecordId",
                principalTable: "EndoscopyPostProcedureRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssessmentMonitoringRows_EndoscopyPostProcedureRecords_Endos~",
                table: "AssessmentMonitoringRows",
                column: "EndoscopyPostProcedureRecordId",
                principalTable: "EndoscopyPostProcedureRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NursingMedicationEntries_EndoscopyPostProcedureRecords_Endos~",
                table: "NursingMedicationEntries",
                column: "EndoscopyPostProcedureRecordId",
                principalTable: "EndoscopyPostProcedureRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AldreteScores_EndoscopyPostProcedureRecords_EndoscopyPostPro~",
                table: "AldreteScores");

            migrationBuilder.DropForeignKey(
                name: "FK_AssessmentMonitoringRows_EndoscopyPostProcedureRecords_Endos~",
                table: "AssessmentMonitoringRows");

            migrationBuilder.DropForeignKey(
                name: "FK_NursingMedicationEntries_EndoscopyPostProcedureRecords_Endos~",
                table: "NursingMedicationEntries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_NursingMedicationEntries",
                table: "NursingMedicationEntries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssessmentMonitoringRows",
                table: "AssessmentMonitoringRows");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AldreteScores",
                table: "AldreteScores");

            migrationBuilder.DropColumn(
                name: "AccNo",
                table: "EndoscopyProcedureRecords");

            migrationBuilder.DropColumn(
                name: "BotJobDone",
                table: "EndoscopyProcedureRecords");

            migrationBuilder.DropColumn(
                name: "AccNo",
                table: "EndoscopyPostProcedureRecords");

            migrationBuilder.RenameTable(
                name: "NursingMedicationEntries",
                newName: "NursingMedicationEntryDto");

            migrationBuilder.RenameTable(
                name: "AssessmentMonitoringRows",
                newName: "AssessmentMonitoringRowDto");

            migrationBuilder.RenameTable(
                name: "AldreteScores",
                newName: "AldreteScoreDto");

            migrationBuilder.RenameIndex(
                name: "IX_NursingMedicationEntries_EndoscopyPostProcedureRecordId",
                table: "NursingMedicationEntryDto",
                newName: "IX_NursingMedicationEntryDto_EndoscopyPostProcedureRecordId");

            migrationBuilder.RenameIndex(
                name: "IX_AssessmentMonitoringRows_EndoscopyPostProcedureRecordId",
                table: "AssessmentMonitoringRowDto",
                newName: "IX_AssessmentMonitoringRowDto_EndoscopyPostProcedureRecordId");

            migrationBuilder.RenameIndex(
                name: "IX_AldreteScores_EndoscopyPostProcedureRecordId",
                table: "AldreteScoreDto",
                newName: "IX_AldreteScoreDto_EndoscopyPostProcedureRecordId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_NursingMedicationEntryDto",
                table: "NursingMedicationEntryDto",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssessmentMonitoringRowDto",
                table: "AssessmentMonitoringRowDto",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AldreteScoreDto",
                table: "AldreteScoreDto",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AldreteScoreDto_EndoscopyPostProcedureRecords_EndoscopyPostP~",
                table: "AldreteScoreDto",
                column: "EndoscopyPostProcedureRecordId",
                principalTable: "EndoscopyPostProcedureRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AssessmentMonitoringRowDto_EndoscopyPostProcedureRecords_End~",
                table: "AssessmentMonitoringRowDto",
                column: "EndoscopyPostProcedureRecordId",
                principalTable: "EndoscopyPostProcedureRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_NursingMedicationEntryDto_EndoscopyPostProcedureRecords_Endo~",
                table: "NursingMedicationEntryDto",
                column: "EndoscopyPostProcedureRecordId",
                principalTable: "EndoscopyPostProcedureRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
