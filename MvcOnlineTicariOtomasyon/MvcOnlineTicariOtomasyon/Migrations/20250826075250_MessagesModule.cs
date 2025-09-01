using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcOnlineTicariOtomasyon.Migrations
{
    /// <inheritdoc />
    public partial class MessagesModule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mesajlars",
                columns: table => new
                {
                    Mesajlarid = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gonderici = table.Column<string>(type: "Varchar(50)", maxLength: 50, nullable: false),
                    Alici = table.Column<string>(type: "Varchar(50)", maxLength: 50, nullable: false),
                    Konu = table.Column<string>(type: "Varchar(50)", maxLength: 50, nullable: false),
                    Icerik = table.Column<string>(type: "Varchar(2000)", maxLength: 2000, nullable: false),
                    Tarih = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mesajlars", x => x.Mesajlarid);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Mesajlars");
        }
    }
}
