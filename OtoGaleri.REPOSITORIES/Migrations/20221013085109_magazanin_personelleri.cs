using Microsoft.EntityFrameworkCore.Migrations;

namespace OtoGaleri.REPOSITORIES.Migrations
{
    public partial class magazanin_personelleri : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Magazalar_Kullanicilar_MagazaYetkiliID",
                table: "Magazalar");

            migrationBuilder.DropIndex(
                name: "IX_Magazalar_MagazaYetkiliID",
                table: "Magazalar");

            migrationBuilder.DropColumn(
                name: "MagazaYetkiliID",
                table: "Magazalar");

            migrationBuilder.AddColumn<int>(
                name: "MagazaID",
                table: "Kullanicilar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Kullanicilar_MagazaID",
                table: "Kullanicilar",
                column: "MagazaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Kullanicilar_Magazalar_MagazaID",
                table: "Kullanicilar",
                column: "MagazaID",
                principalTable: "Magazalar",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kullanicilar_Magazalar_MagazaID",
                table: "Kullanicilar");

            migrationBuilder.DropIndex(
                name: "IX_Kullanicilar_MagazaID",
                table: "Kullanicilar");

            migrationBuilder.DropColumn(
                name: "MagazaID",
                table: "Kullanicilar");

            migrationBuilder.AddColumn<int>(
                name: "MagazaYetkiliID",
                table: "Magazalar",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Magazalar_MagazaYetkiliID",
                table: "Magazalar",
                column: "MagazaYetkiliID",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Magazalar_Kullanicilar_MagazaYetkiliID",
                table: "Magazalar",
                column: "MagazaYetkiliID",
                principalTable: "Kullanicilar",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
