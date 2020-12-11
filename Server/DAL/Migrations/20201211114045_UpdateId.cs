using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class UpdateId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PetPassports_Collars_CollarId",
                table: "PetPassports");

            migrationBuilder.DropForeignKey(
                name: "FK_PetPassports_BloodTests_IdealBloodTestId",
                table: "PetPassports");

            migrationBuilder.AlterColumn<int>(
                name: "IdealBloodTestId",
                table: "PetPassports",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CollarId",
                table: "PetPassports",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_PetPassports_Collars_CollarId",
                table: "PetPassports",
                column: "CollarId",
                principalTable: "Collars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PetPassports_BloodTests_IdealBloodTestId",
                table: "PetPassports",
                column: "IdealBloodTestId",
                principalTable: "BloodTests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PetPassports_Collars_CollarId",
                table: "PetPassports");

            migrationBuilder.DropForeignKey(
                name: "FK_PetPassports_BloodTests_IdealBloodTestId",
                table: "PetPassports");

            migrationBuilder.AlterColumn<int>(
                name: "IdealBloodTestId",
                table: "PetPassports",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CollarId",
                table: "PetPassports",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PetPassports_Collars_CollarId",
                table: "PetPassports",
                column: "CollarId",
                principalTable: "Collars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PetPassports_BloodTests_IdealBloodTestId",
                table: "PetPassports",
                column: "IdealBloodTestId",
                principalTable: "BloodTests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
