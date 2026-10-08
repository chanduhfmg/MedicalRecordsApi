using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MedicalRecordApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EndoscopyProcedureRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PatientName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DOB = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    ProcedureDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    TimeIn = table.Column<TimeSpan>(type: "time(6)", nullable: true),
                    ProcedureRoom = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ReferringPhysician = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Anesthesiologist = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Assistant = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NPOSince = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PrepTaken = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GlassesRemoved = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DenturesRemoved = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PregnancyVerified = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PreOpDiagnosis = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProcedureStart = table.Column<TimeSpan>(type: "time(6)", nullable: true),
                    ProcedureStop = table.Column<TimeSpan>(type: "time(6)", nullable: true),
                    CorrectPatient = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CorrectProcedure = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AllergiesVerified = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    VerifiedWithStaff = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsEGD = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsColonoscopy = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsFlexSig = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IsBanding = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    EndoscopeId = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CauteryNA = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CauteryCut = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CauteryCo = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SpecimenCount = table.Column<int>(type: "int", nullable: true),
                    ProcedureNotes = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IVNone = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IVStarted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    IVSite = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LiB = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NursingNotes = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AnesthesiaTIVA = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AnesthesiaConsciousSedation = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AnesthesiaGA = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AnesthesiaNone = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    MonitorEKG = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    MonitorETCO2 = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    MonitorNIBP = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    MonitorPulseOx = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    BP = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HR = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RespRate = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SpO2 = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Oxygen = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PACUTransferTime = table.Column<TimeSpan>(type: "time(6)", nullable: true),
                    PhotosOnFile = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EndoscopyProcedureRecords", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EndoscopyProcedureRecords");
        }
    }
}
