﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OtoGaleri.REPOSITORIES.Context;

namespace OtoGaleri.REPOSITORIES.Migrations
{
    [DbContext(typeof(OtoGaleriDbContext))]
    partial class OtoGaleriDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OtoGaleri.ENTITIES.Entities.Arac", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("AktifMi")
                        .HasColumnType("bit");

                    b.Property<int>("AracTipi")
                        .HasColumnType("int");

                    b.Property<DateTime>("DegistirilmeTarihi")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EklenmeTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("Fiyati")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KullaniciID")
                        .HasColumnType("int");

                    b.Property<int>("MagazaID")
                        .HasColumnType("int");

                    b.Property<string>("Markasi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Modeli")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("MotorHacmi")
                        .HasColumnType("float");

                    b.Property<int>("SasiNo")
                        .HasColumnType("int");

                    b.Property<int>("Sehir")
                        .HasColumnType("int");

                    b.Property<DateTime>("UretimTarihi")
                        .HasColumnType("datetime2");

                    b.Property<int>("VitesTipi")
                        .HasColumnType("int");

                    b.Property<int>("YakitTuru")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("KullaniciID");

                    b.HasIndex("MagazaID");

                    b.HasIndex(new[] { "SasiNo" }, "SasiIX")
                        .IsUnique();

                    b.ToTable("Araclar");
                });

            modelBuilder.Entity("OtoGaleri.ENTITIES.Entities.Kullanici", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Adres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("AktifMi")
                        .HasColumnType("bit");

                    b.Property<bool>("Cinsiyet")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DegistirilmeTarihi")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DogumTarihi")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EklenmeTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MagazaID")
                        .HasColumnType("int");

                    b.Property<string>("Meslegi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Parola")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilFotoURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Rolu")
                        .HasColumnType("int");

                    b.Property<string>("Soyadi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Uyrugu")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("MagazaID");

                    b.ToTable("Kullanicilar");
                });

            modelBuilder.Entity("OtoGaleri.ENTITIES.Entities.Magaza", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adresi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("AktifMi")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DegistirilmeTarihi")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EklenmeTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("KurulusTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("LogoURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MagazaAdi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Sehir")
                        .HasColumnType("int");

                    b.Property<string>("Telefonu")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("WebSitesi")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Magazalar");
                });

            modelBuilder.Entity("OtoGaleri.ENTITIES.Entities.Arac", b =>
                {
                    b.HasOne("OtoGaleri.ENTITIES.Entities.Kullanici", "AracinSahibi")
                        .WithMany("Araclari")
                        .HasForeignKey("KullaniciID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OtoGaleri.ENTITIES.Entities.Magaza", "AracinMagazasi")
                        .WithMany("MagazaninAraclari")
                        .HasForeignKey("MagazaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AracinMagazasi");

                    b.Navigation("AracinSahibi");
                });

            modelBuilder.Entity("OtoGaleri.ENTITIES.Entities.Kullanici", b =>
                {
                    b.HasOne("OtoGaleri.ENTITIES.Entities.Magaza", "PersonelinMagazasi")
                        .WithMany("MagazaninPersonelleri")
                        .HasForeignKey("MagazaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonelinMagazasi");
                });

            modelBuilder.Entity("OtoGaleri.ENTITIES.Entities.Kullanici", b =>
                {
                    b.Navigation("Araclari");
                });

            modelBuilder.Entity("OtoGaleri.ENTITIES.Entities.Magaza", b =>
                {
                    b.Navigation("MagazaninAraclari");

                    b.Navigation("MagazaninPersonelleri");
                });
#pragma warning restore 612, 618
        }
    }
}
