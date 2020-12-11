using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Passports");

            migrationBuilder.DropTable(
                name: "Pets");

            migrationBuilder.CreateTable(
                name: "PetPassports",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    DOB = table.Column<DateTime>(nullable: false),
                    Weight = table.Column<float>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    CollarId = table.Column<int>(nullable: false),
                    IdealBloodTestId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetPassports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PetPassports_Collars_CollarId",
                        column: x => x.CollarId,
                        principalTable: "Collars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PetPassports_BloodTests_IdealBloodTestId",
                        column: x => x.IdealBloodTestId,
                        principalTable: "BloodTests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PetPassports_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Records",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(nullable: false),
                    PetId = table.Column<int>(nullable: false),
                    VaccinationStateId = table.Column<int>(nullable: false),
                    VaccinationId = table.Column<int>(nullable: false),
                    BloodTestId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Records", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Records_BloodTests_BloodTestId",
                        column: x => x.BloodTestId,
                        principalTable: "BloodTests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Records_PetPassports_PetId",
                        column: x => x.PetId,
                        principalTable: "PetPassports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Records_Vaccinations_VaccinationId",
                        column: x => x.VaccinationId,
                        principalTable: "Vaccinations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Records_VaccinationStates_VaccinationStateId",
                        column: x => x.VaccinationStateId,
                        principalTable: "VaccinationStates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PetPassports_CollarId",
                table: "PetPassports",
                column: "CollarId");

            migrationBuilder.CreateIndex(
                name: "IX_PetPassports_IdealBloodTestId",
                table: "PetPassports",
                column: "IdealBloodTestId");

            migrationBuilder.CreateIndex(
                name: "IX_PetPassports_UserId",
                table: "PetPassports",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Records_BloodTestId",
                table: "Records",
                column: "BloodTestId");

            migrationBuilder.CreateIndex(
                name: "IX_Records_PetId",
                table: "Records",
                column: "PetId");

            migrationBuilder.CreateIndex(
                name: "IX_Records_VaccinationId",
                table: "Records",
                column: "VaccinationId");

            migrationBuilder.CreateIndex(
                name: "IX_Records_VaccinationStateId",
                table: "Records",
                column: "VaccinationStateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Records");

            migrationBuilder.DropTable(
                name: "PetPassports");

            migrationBuilder.CreateTable(
                name: "Pets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CollarId = table.Column<int>(type: "int", nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdealBloodTestId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pets_Collars_CollarId",
                        column: x => x.CollarId,
                        principalTable: "Collars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pets_BloodTests_IdealBloodTestId",
                        column: x => x.IdealBloodTestId,
                        principalTable: "BloodTests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pets_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Passports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BloodTestId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PetId = table.Column<int>(type: "int", nullable: false),
                    VaccinationId = table.Column<int>(type: "int", nullable: false),
                    VaccinationStateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Passports_BloodTests_BloodTestId",
                        column: x => x.BloodTestId,
                        principalTable: "BloodTests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Passports_Pets_PetId",
                        column: x => x.PetId,
                        principalTable: "Pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Passports_Vaccinations_VaccinationId",
                        column: x => x.VaccinationId,
                        principalTable: "Vaccinations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Passports_VaccinationStates_VaccinationStateId",
                        column: x => x.VaccinationStateId,
                        principalTable: "VaccinationStates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Passports_BloodTestId",
                table: "Passports",
                column: "BloodTestId");

            migrationBuilder.CreateIndex(
                name: "IX_Passports_PetId",
                table: "Passports",
                column: "PetId");

            migrationBuilder.CreateIndex(
                name: "IX_Passports_VaccinationId",
                table: "Passports",
                column: "VaccinationId");

            migrationBuilder.CreateIndex(
                name: "IX_Passports_VaccinationStateId",
                table: "Passports",
                column: "VaccinationStateId");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_CollarId",
                table: "Pets",
                column: "CollarId");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_IdealBloodTestId",
                table: "Pets",
                column: "IdealBloodTestId");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_UserId",
                table: "Pets",
                column: "UserId");
        }
    }
}
