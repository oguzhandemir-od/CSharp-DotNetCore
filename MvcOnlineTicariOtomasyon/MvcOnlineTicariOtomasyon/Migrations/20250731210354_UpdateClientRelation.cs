using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcOnlineTicariOtomasyon.Migrations
{
    /// <inheritdoc />
    public partial class UpdateClientRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SatisHarekets_Carilers_CarilerCariid",
                table: "SatisHarekets");

            migrationBuilder.DropIndex(
                name: "IX_SatisHarekets_CarilerCariid",
                table: "SatisHarekets");

            migrationBuilder.DropColumn(
                name: "CarilerCariid",
                table: "SatisHarekets");

            migrationBuilder.CreateIndex(
                name: "IX_SatisHarekets_Cariid",
                table: "SatisHarekets",
                column: "Cariid");

            migrationBuilder.AddForeignKey(
                name: "FK_SatisHarekets_Carilers_Cariid",
                table: "SatisHarekets",
                column: "Cariid",
                principalTable: "Carilers",
                principalColumn: "Cariid",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SatisHarekets_Carilers_Cariid",
                table: "SatisHarekets");

            migrationBuilder.DropIndex(
                name: "IX_SatisHarekets_Cariid",
                table: "SatisHarekets");

            migrationBuilder.AddColumn<int>(
                name: "CarilerCariid",
                table: "SatisHarekets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SatisHarekets_CarilerCariid",
                table: "SatisHarekets",
                column: "CarilerCariid");

            migrationBuilder.AddForeignKey(
                name: "FK_SatisHarekets_Carilers_CarilerCariid",
                table: "SatisHarekets",
                column: "CarilerCariid",
                principalTable: "Carilers",
                principalColumn: "Cariid",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
