using Microsoft.EntityFrameworkCore.Migrations;

namespace DLL.Migrations
{
    public partial class UpdatedPatientModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_MedicalClaims_MedicalClaimId",
                table: "Patients");

            migrationBuilder.AlterColumn<int>(
                name: "MedicalClaimId",
                table: "Patients",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "MedicalAidNumber",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_MedicalClaims_MedicalClaimId",
                table: "Patients",
                column: "MedicalClaimId",
                principalTable: "MedicalClaims",
                principalColumn: "MedicalClaimId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_MedicalClaims_MedicalClaimId",
                table: "Patients");

            migrationBuilder.AlterColumn<int>(
                name: "MedicalClaimId",
                table: "Patients",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MedicalAidNumber",
                table: "Patients",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_MedicalClaims_MedicalClaimId",
                table: "Patients",
                column: "MedicalClaimId",
                principalTable: "MedicalClaims",
                principalColumn: "MedicalClaimId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
