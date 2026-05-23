using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcOnlineTicariOtomasyon.Migrations
{
    /// <inheritdoc />
    public partial class EditRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carilers_SatisHarekets_Satishareketid",
                table: "Carilers");

            migrationBuilder.DropForeignKey(
                name: "FK_Personels_SatisHarekets_Satishareketid",
                table: "Personels");

            migrationBuilder.DropForeignKey(
                name: "FK_Uruns_SatisHarekets_Satishareketid",
                table: "Uruns");

            migrationBuilder.DropIndex(
                name: "IX_Uruns_Satishareketid",
                table: "Uruns");

            migrationBuilder.DropIndex(
                name: "IX_Personels_Satishareketid",
                table: "Personels");

            migrationBuilder.DropIndex(
                name: "IX_Carilers_Satishareketid",
                table: "Carilers");

            migrationBuilder.DropColumn(
                name: "Satishareketid",
                table: "Uruns");

            migrationBuilder.DropColumn(
                name: "Satishareketid",
                table: "Personels");

            migrationBuilder.DropColumn(
                name: "Satishareketid",
                table: "Carilers");

            migrationBuilder.AddColumn<int>(
                name: "CarilerCariid",
                table: "SatisHarekets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Personelid",
                table: "SatisHarekets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Urunid",
                table: "SatisHarekets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SatisHarekets_CarilerCariid",
                table: "SatisHarekets",
                column: "CarilerCariid");

            migrationBuilder.CreateIndex(
                name: "IX_SatisHarekets_Personelid",
                table: "SatisHarekets",
                column: "Personelid");

            migrationBuilder.CreateIndex(
                name: "IX_SatisHarekets_Urunid",
                table: "SatisHarekets",
                column: "Urunid");

            migrationBuilder.AddForeignKey(
                name: "FK_SatisHarekets_Carilers_CarilerCariid",
                table: "SatisHarekets",
                column: "CarilerCariid",
                principalTable: "Carilers",
                principalColumn: "Cariid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SatisHarekets_Personels_Personelid",
                table: "SatisHarekets",
                column: "Personelid",
                principalTable: "Personels",
                principalColumn: "Personelid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SatisHarekets_Uruns_Urunid",
                table: "SatisHarekets",
                column: "Urunid",
                principalTable: "Uruns",
                principalColumn: "Urunid",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SatisHarekets_Carilers_CarilerCariid",
                table: "SatisHarekets");

            migrationBuilder.DropForeignKey(
                name: "FK_SatisHarekets_Personels_Personelid",
                table: "SatisHarekets");

            migrationBuilder.DropForeignKey(
                name: "FK_SatisHarekets_Uruns_Urunid",
                table: "SatisHarekets");

            migrationBuilder.DropIndex(
                name: "IX_SatisHarekets_CarilerCariid",
                table: "SatisHarekets");

            migrationBuilder.DropIndex(
                name: "IX_SatisHarekets_Personelid",
                table: "SatisHarekets");

            migrationBuilder.DropIndex(
                name: "IX_SatisHarekets_Urunid",
                table: "SatisHarekets");

            migrationBuilder.DropColumn(
                name: "CarilerCariid",
                table: "SatisHarekets");

            migrationBuilder.DropColumn(
                name: "Personelid",
                table: "SatisHarekets");

            migrationBuilder.DropColumn(
                name: "Urunid",
                table: "SatisHarekets");

            migrationBuilder.AddColumn<int>(
                name: "Satishareketid",
                table: "Uruns",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Satishareketid",
                table: "Personels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Satishareketid",
                table: "Carilers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Uruns_Satishareketid",
                table: "Uruns",
                column: "Satishareketid");

            migrationBuilder.CreateIndex(
                name: "IX_Personels_Satishareketid",
                table: "Personels",
                column: "Satishareketid");

            migrationBuilder.CreateIndex(
                name: "IX_Carilers_Satishareketid",
                table: "Carilers",
                column: "Satishareketid");

            migrationBuilder.AddForeignKey(
                name: "FK_Carilers_SatisHarekets_Satishareketid",
                table: "Carilers",
                column: "Satishareketid",
                principalTable: "SatisHarekets",
                principalColumn: "Satishareketid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Personels_SatisHarekets_Satishareketid",
                table: "Personels",
                column: "Satishareketid",
                principalTable: "SatisHarekets",
                principalColumn: "Satishareketid",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Uruns_SatisHarekets_Satishareketid",
                table: "Uruns",
                column: "Satishareketid",
                principalTable: "SatisHarekets",
                principalColumn: "Satishareketid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
