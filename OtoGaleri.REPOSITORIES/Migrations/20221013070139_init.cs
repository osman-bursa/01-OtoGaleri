using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OtoGaleri.REPOSITORIES.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kullanicilar",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Soyadi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Meslegi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Uyrugu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cinsiyet = table.Column<bool>(type: "bit", nullable: false),
                    ProfilFotoURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Parola = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DogumTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rolu = table.Column<int>(type: "int", nullable: false),
                    AktifMi = table.Column<bool>(type: "bit", nullable: false),
                    EklenmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanicilar", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Magazalar",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MagazaAdi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KurulusTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Adresi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sehir = table.Column<int>(type: "int", nullable: false),
                    Telefonu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogoURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WebSitesi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MagazaYetkiliID = table.Column<int>(type: "int", nullable: false),
                    AktifMi = table.Column<bool>(type: "bit", nullable: false),
                    EklenmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Magazalar", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Magazalar_Kullanicilar_MagazaYetkiliID",
                        column: x => x.MagazaYetkiliID,
                        principalTable: "Kullanicilar",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Araclar",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SasiNo = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Markasi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Modeli = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MotorHacmi = table.Column<double>(type: "float", nullable: false),
                    Fiyati = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VitesTipi = table.Column<int>(type: "int", nullable: false),
                    YakitTuru = table.Column<int>(type: "int", nullable: false),
                    UretimTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AracTipi = table.Column<int>(type: "int", nullable: false),
                    Sehir = table.Column<int>(type: "int", nullable: false),
                    KullaniciID = table.Column<int>(type: "int", nullable: false),
                    MagazaID = table.Column<int>(type: "int", nullable: false),
                    AktifMi = table.Column<bool>(type: "bit", nullable: false),
                    EklenmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DegistirilmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Araclar", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Araclar_Kullanicilar_KullaniciID",
                        column: x => x.KullaniciID,
                        principalTable: "Kullanicilar",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Araclar_Magazalar_MagazaID",
                        column: x => x.MagazaID,
                        principalTable: "Magazalar",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Araclar_KullaniciID",
                table: "Araclar",
                column: "KullaniciID");

            migrationBuilder.CreateIndex(
                name: "IX_Araclar_MagazaID",
                table: "Araclar",
                column: "MagazaID");

            migrationBuilder.CreateIndex(
                name: "SasiIX",
                table: "Araclar",
                column: "SasiNo",
                unique: true,
                filter: "[SasiNo] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Magazalar_MagazaYetkiliID",
                table: "Magazalar",
                column: "MagazaYetkiliID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Araclar");

            migrationBuilder.DropTable(
                name: "Magazalar");

            migrationBuilder.DropTable(
                name: "Kullanicilar");
        }
    }
}
