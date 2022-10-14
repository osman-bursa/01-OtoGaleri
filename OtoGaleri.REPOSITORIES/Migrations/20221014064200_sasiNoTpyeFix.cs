using Microsoft.EntityFrameworkCore.Migrations;

namespace OtoGaleri.REPOSITORIES.Migrations
{
    public partial class sasiNoTpyeFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "SasiIX",
                table: "Araclar");

            migrationBuilder.AlterColumn<int>(
                name: "SasiNo",
                table: "Araclar",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "SasiIX",
                table: "Araclar",
                column: "SasiNo",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "SasiIX",
                table: "Araclar");

            migrationBuilder.AlterColumn<string>(
                name: "SasiNo",
                table: "Araclar",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "SasiIX",
                table: "Araclar",
                column: "SasiNo",
                unique: true,
                filter: "[SasiNo] IS NOT NULL");
        }
    }
}
