using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ProductViewer.Migrations
{
    /// <inheritdoc />
    public partial class Kategorija : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Korisnik",
                table: "Korisnik");

            migrationBuilder.DropColumn(
                name: "KorisnikID",
                table: "Korisnik");

            migrationBuilder.AddColumn<string>(
                name: "KorisnikID",
                table: "Proizvod",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "Korisnik",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Korisnik",
                table: "Korisnik",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Proizvod_KorisnikID",
                table: "Proizvod",
                column: "KorisnikID");

            migrationBuilder.AddForeignKey(
                name: "FK_Korisnik_AspNetUsers_Id",
                table: "Korisnik",
                column: "Id",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Proizvod_Korisnik_KorisnikID",
                table: "Proizvod",
                column: "KorisnikID",
                principalTable: "Korisnik",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Korisnik_AspNetUsers_Id",
                table: "Korisnik");

            migrationBuilder.DropForeignKey(
                name: "FK_Proizvod_Korisnik_KorisnikID",
                table: "Proizvod");

            migrationBuilder.DropIndex(
                name: "IX_Proizvod_KorisnikID",
                table: "Proizvod");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Korisnik",
                table: "Korisnik");

            migrationBuilder.DropColumn(
                name: "KorisnikID",
                table: "Proizvod");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Korisnik");

            migrationBuilder.AddColumn<int>(
                name: "KorisnikID",
                table: "Korisnik",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Korisnik",
                table: "Korisnik",
                column: "KorisnikID");
        }
    }
}
