using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcOnlineTicariOtomasyon.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    Adminid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciAd = table.Column<string>(type: "Varchar(10)", maxLength: 10, nullable: false),
                    Sifre = table.Column<string>(type: "Varchar(30)", maxLength: 30, nullable: false),
                    Yetki = table.Column<string>(type: "Char(1)", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.Adminid);
                });

            migrationBuilder.CreateTable(
                name: "Departmans",
                columns: table => new
                {
                    Departmanid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmanAd = table.Column<string>(type: "Varchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departmans", x => x.Departmanid);
                });

            migrationBuilder.CreateTable(
                name: "Faturalars",
                columns: table => new
                {
                    Faturalarid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FaturaSeriNo = table.Column<string>(type: "Char(1)", maxLength: 1, nullable: false),
                    FaturaSiraNo = table.Column<string>(type: "Varchar(6)", maxLength: 6, nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VergiDairesi = table.Column<string>(type: "Varchar(60)", maxLength: 60, nullable: false),
                    Saat = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TeslimEden = table.Column<string>(type: "Varchar(30)", maxLength: 30, nullable: false),
                    TeslimAlan = table.Column<string>(type: "Varchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faturalars", x => x.Faturalarid);
                });

            migrationBuilder.CreateTable(
                name: "Giders",
                columns: table => new
                {
                    Giderid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Aciklama = table.Column<string>(type: "Varchar(100)", maxLength: 100, nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tutar = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Giders", x => x.Giderid);
                });

            migrationBuilder.CreateTable(
                name: "Kategoris",
                columns: table => new
                {
                    Kategoriid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategoriAd = table.Column<string>(type: "Varchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategoris", x => x.Kategoriid);
                });

            migrationBuilder.CreateTable(
                name: "SatisHarekets",
                columns: table => new
                {
                    Satishareketid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Adet = table.Column<int>(type: "int", nullable: false),
                    Fiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ToplamTutar = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SatisHarekets", x => x.Satishareketid);
                });

            migrationBuilder.CreateTable(
                name: "FaturaKalems",
                columns: table => new
                {
                    Faturakalemid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Aciklama = table.Column<string>(type: "Varchar(100)", maxLength: 100, nullable: false),
                    Miktar = table.Column<int>(type: "int", nullable: false),
                    BirimFiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Tutar = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Faturalarid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FaturaKalems", x => x.Faturakalemid);
                    table.ForeignKey(
                        name: "FK_FaturaKalems_Faturalars_Faturalarid",
                        column: x => x.Faturalarid,
                        principalTable: "Faturalars",
                        principalColumn: "Faturalarid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carilers",
                columns: table => new
                {
                    Cariid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CariAd = table.Column<string>(type: "Varchar(30)", maxLength: 30, nullable: false),
                    CariSoyad = table.Column<string>(type: "Varchar(30)", maxLength: 30, nullable: false),
                    CariSehir = table.Column<string>(type: "Varchar(13)", maxLength: 13, nullable: false),
                    CariMail = table.Column<string>(type: "Varchar(50)", maxLength: 50, nullable: false),
                    Satishareketid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carilers", x => x.Cariid);
                    table.ForeignKey(
                        name: "FK_Carilers_SatisHarekets_Satishareketid",
                        column: x => x.Satishareketid,
                        principalTable: "SatisHarekets",
                        principalColumn: "Satishareketid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Personels",
                columns: table => new
                {
                    Personelid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonelAd = table.Column<string>(type: "Varchar(30)", maxLength: 30, nullable: false),
                    PersonelSoyad = table.Column<string>(type: "Varchar(30)", maxLength: 30, nullable: false),
                    PersonelGorsel = table.Column<string>(type: "Varchar(250)", maxLength: 250, nullable: false),
                    Satishareketid = table.Column<int>(type: "int", nullable: false),
                    Departmanid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personels", x => x.Personelid);
                    table.ForeignKey(
                        name: "FK_Personels_Departmans_Departmanid",
                        column: x => x.Departmanid,
                        principalTable: "Departmans",
                        principalColumn: "Departmanid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Personels_SatisHarekets_Satishareketid",
                        column: x => x.Satishareketid,
                        principalTable: "SatisHarekets",
                        principalColumn: "Satishareketid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Uruns",
                columns: table => new
                {
                    Urunid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrunAd = table.Column<string>(type: "Varchar(30)", maxLength: 30, nullable: false),
                    Marka = table.Column<string>(type: "Varchar(30)", maxLength: 30, nullable: false),
                    Stok = table.Column<short>(type: "smallint", nullable: false),
                    AlisFiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SatisFiyat = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Durum = table.Column<bool>(type: "bit", nullable: false),
                    UrunGorsel = table.Column<string>(type: "Varchar(250)", maxLength: 250, nullable: false),
                    Kategoriid = table.Column<int>(type: "int", nullable: false),
                    Satishareketid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uruns", x => x.Urunid);
                    table.ForeignKey(
                        name: "FK_Uruns_Kategoris_Kategoriid",
                        column: x => x.Kategoriid,
                        principalTable: "Kategoris",
                        principalColumn: "Kategoriid",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Uruns_SatisHarekets_Satishareketid",
                        column: x => x.Satishareketid,
                        principalTable: "SatisHarekets",
                        principalColumn: "Satishareketid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carilers_Satishareketid",
                table: "Carilers",
                column: "Satishareketid");

            migrationBuilder.CreateIndex(
                name: "IX_FaturaKalems_Faturalarid",
                table: "FaturaKalems",
                column: "Faturalarid");

            migrationBuilder.CreateIndex(
                name: "IX_Personels_Departmanid",
                table: "Personels",
                column: "Departmanid");

            migrationBuilder.CreateIndex(
                name: "IX_Personels_Satishareketid",
                table: "Personels",
                column: "Satishareketid");

            migrationBuilder.CreateIndex(
                name: "IX_Uruns_Kategoriid",
                table: "Uruns",
                column: "Kategoriid");

            migrationBuilder.CreateIndex(
                name: "IX_Uruns_Satishareketid",
                table: "Uruns",
                column: "Satishareketid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Carilers");

            migrationBuilder.DropTable(
                name: "FaturaKalems");

            migrationBuilder.DropTable(
                name: "Giders");

            migrationBuilder.DropTable(
                name: "Personels");

            migrationBuilder.DropTable(
                name: "Uruns");

            migrationBuilder.DropTable(
                name: "Faturalars");

            migrationBuilder.DropTable(
                name: "Departmans");

            migrationBuilder.DropTable(
                name: "Kategoris");

            migrationBuilder.DropTable(
                name: "SatisHarekets");
        }
    }
}
