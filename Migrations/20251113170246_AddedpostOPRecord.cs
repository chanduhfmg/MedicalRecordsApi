using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalRecordApi.Migrations
{
    /// <inheritdoc />
    public partial class AddedpostOPRecord : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EndoscopyPostProcedureRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EndoscopyProcedureRecordId = table.Column<int>(type: "int", nullable: false),
                    Patient = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateOfBirth = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    AdmissionDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    AdmissionTime = table.Column<TimeSpan>(type: "time(6)", nullable: true),
                    OperativeProcedure = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BP = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HeartRate = table.Column<int>(type: "int", nullable: true),
                    Respiration = table.Column<int>(type: "int", nullable: true),
                    O2Sat = table.Column<int>(type: "int", nullable: true),
                    On = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IVAmtOnAdmission = table.Column<int>(type: "int", nullable: true),
                    TotalInfused = table.Column<int>(type: "int", nullable: true),
                    TimeSiteDC = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AbdomenSoft = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    PassingFlatus = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    NauseaVomiting = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    OralFluidsTolerated = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    Notes = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PainLevel = table.Column<int>(type: "int", nullable: false),
                    Location = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Action = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Reassessment = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NursingNotes = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AdditionalOrders = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhysicianName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhysicianDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    DischargeCriteriaMet = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    StableVitalSigns = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    ClearedByAnesthesiologist = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    InstructionsReviewed = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    InstructionsReviewedBy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PostOpInstructionsGiven = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    PostOpInstructionsGivenBy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PatientDischargeType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PatientDischargeTime = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EndoscopyPostProcedureRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EndoscopyPostProcedureRecords_EndoscopyProcedureRecords_Endo~",
                        column: x => x.EndoscopyProcedureRecordId,
                        principalTable: "EndoscopyProcedureRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AldreteScoreDto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EndoscopyPostProcedureRecordId = table.Column<int>(type: "int", nullable: false),
                    ActivityAd = table.Column<int>(type: "int", nullable: true),
                    Activity10 = table.Column<int>(type: "int", nullable: true),
                    Activity20 = table.Column<int>(type: "int", nullable: true),
                    ActivityDC = table.Column<int>(type: "int", nullable: true),
                    RespirationAd = table.Column<int>(type: "int", nullable: true),
                    Respiration10 = table.Column<int>(type: "int", nullable: true),
                    Respiration20 = table.Column<int>(type: "int", nullable: true),
                    RespirationDC = table.Column<int>(type: "int", nullable: true),
                    ConsciousnessAd = table.Column<int>(type: "int", nullable: true),
                    Consciousness10 = table.Column<int>(type: "int", nullable: true),
                    Consciousness20 = table.Column<int>(type: "int", nullable: true),
                    ConsciousnessDC = table.Column<int>(type: "int", nullable: true),
                    O2SatAd = table.Column<int>(type: "int", nullable: true),
                    O2Sat10 = table.Column<int>(type: "int", nullable: true),
                    O2Sat20 = table.Column<int>(type: "int", nullable: true),
                    O2SatDC = table.Column<int>(type: "int", nullable: true),
                    CirculationAd = table.Column<int>(type: "int", nullable: true),
                    Circulation10 = table.Column<int>(type: "int", nullable: true),
                    Circulation20 = table.Column<int>(type: "int", nullable: true),
                    CirculationDC = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AldreteScoreDto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AldreteScoreDto_EndoscopyPostProcedureRecords_EndoscopyPostP~",
                        column: x => x.EndoscopyPostProcedureRecordId,
                        principalTable: "EndoscopyPostProcedureRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AssessmentMonitoringRowDto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EndoscopyPostProcedureRecordId = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BP = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Pulse = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Resp = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    O2 = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    O2Sat = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssessmentMonitoringRowDto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssessmentMonitoringRowDto_EndoscopyPostProcedureRecords_End~",
                        column: x => x.EndoscopyPostProcedureRecordId,
                        principalTable: "EndoscopyPostProcedureRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "NursingMedicationEntryDto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    EndoscopyPostProcedureRecordId = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Medication = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Route = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nurse = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Response = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NursingMedicationEntryDto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NursingMedicationEntryDto_EndoscopyPostProcedureRecords_Endo~",
                        column: x => x.EndoscopyPostProcedureRecordId,
                        principalTable: "EndoscopyPostProcedureRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_AldreteScoreDto_EndoscopyPostProcedureRecordId",
                table: "AldreteScoreDto",
                column: "EndoscopyPostProcedureRecordId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AssessmentMonitoringRowDto_EndoscopyPostProcedureRecordId",
                table: "AssessmentMonitoringRowDto",
                column: "EndoscopyPostProcedureRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_EndoscopyPostProcedureRecords_EndoscopyProcedureRecordId",
                table: "EndoscopyPostProcedureRecords",
                column: "EndoscopyProcedureRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_NursingMedicationEntryDto_EndoscopyPostProcedureRecordId",
                table: "NursingMedicationEntryDto",
                column: "EndoscopyPostProcedureRecordId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AldreteScoreDto");

            migrationBuilder.DropTable(
                name: "AssessmentMonitoringRowDto");

            migrationBuilder.DropTable(
                name: "NursingMedicationEntryDto");

            migrationBuilder.DropTable(
                name: "EndoscopyPostProcedureRecords");
        }
    }
}
