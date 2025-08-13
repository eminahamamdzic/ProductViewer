using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductViewer.Migrations
{
    /// <inheritdoc />
    public partial class Izvjestaj : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aktivnosti_Proizvodi_ProizvodID",
                table: "Aktivnosti");

            migrationBuilder.DropForeignKey(
                name: "FK_Izvjestaji_Proizvodi_ProizvodID",
                table: "Izvjestaji");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Proizvodi",
                table: "Proizvodi");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Korisnici",
                table: "Korisnici");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Izvjestaji",
                table: "Izvjestaji");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Aktivnosti",
                table: "Aktivnosti");

            migrationBuilder.RenameTable(
                name: "Proizvodi",
                newName: "Proizvod");

            migrationBuilder.RenameTable(
                name: "Korisnici",
                newName: "Korisnik");

            migrationBuilder.RenameTable(
                name: "Izvjestaji",
                newName: "Izvjestaj");

            migrationBuilder.RenameTable(
                name: "Aktivnosti",
                newName: "Aktivnost");

            migrationBuilder.RenameIndex(
                name: "IX_Izvjestaji_ProizvodID",
                table: "Izvjestaj",
                newName: "IX_Izvjestaj_ProizvodID");

            migrationBuilder.RenameIndex(
                name: "IX_Aktivnosti_ProizvodID",
                table: "Aktivnost",
                newName: "IX_Aktivnost_ProizvodID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Proizvod",
                table: "Proizvod",
                column: "ProizvodID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Korisnik",
                table: "Korisnik",
                column: "KorisnikID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Izvjestaj",
                table: "Izvjestaj",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Aktivnost",
                table: "Aktivnost",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Aktivnost_Proizvod_ProizvodID",
                table: "Aktivnost",
                column: "ProizvodID",
                principalTable: "Proizvod",
                principalColumn: "ProizvodID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Izvjestaj_Proizvod_ProizvodID",
                table: "Izvjestaj",
                column: "ProizvodID",
                principalTable: "Proizvod",
                principalColumn: "ProizvodID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aktivnost_Proizvod_ProizvodID",
                table: "Aktivnost");

            migrationBuilder.DropForeignKey(
                name: "FK_Izvjestaj_Proizvod_ProizvodID",
                table: "Izvjestaj");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Proizvod",
                table: "Proizvod");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Korisnik",
                table: "Korisnik");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Izvjestaj",
                table: "Izvjestaj");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Aktivnost",
                table: "Aktivnost");

            migrationBuilder.RenameTable(
                name: "Proizvod",
                newName: "Proizvodi");

            migrationBuilder.RenameTable(
                name: "Korisnik",
                newName: "Korisnici");

            migrationBuilder.RenameTable(
                name: "Izvjestaj",
                newName: "Izvjestaji");

            migrationBuilder.RenameTable(
                name: "Aktivnost",
                newName: "Aktivnosti");

            migrationBuilder.RenameIndex(
                name: "IX_Izvjestaj_ProizvodID",
                table: "Izvjestaji",
                newName: "IX_Izvjestaji_ProizvodID");

            migrationBuilder.RenameIndex(
                name: "IX_Aktivnost_ProizvodID",
                table: "Aktivnosti",
                newName: "IX_Aktivnosti_ProizvodID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Proizvodi",
                table: "Proizvodi",
                column: "ProizvodID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Korisnici",
                table: "Korisnici",
                column: "KorisnikID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Izvjestaji",
                table: "Izvjestaji",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Aktivnosti",
                table: "Aktivnosti",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Aktivnosti_Proizvodi_ProizvodID",
                table: "Aktivnosti",
                column: "ProizvodID",
                principalTable: "Proizvodi",
                principalColumn: "ProizvodID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Izvjestaji_Proizvodi_ProizvodID",
                table: "Izvjestaji",
                column: "ProizvodID",
                principalTable: "Proizvodi",
                principalColumn: "ProizvodID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
