using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Application.Migrations
{
    /// <inheritdoc />
    public partial class cc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_livre_AdherentId",
                table: "livre",
                column: "AdherentId");

            migrationBuilder.AddForeignKey(
                name: "FK_livre_adherents_AdherentId",
                table: "livre",
                column: "AdherentId",
                principalTable: "adherents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_livre_adherents_AdherentId",
                table: "livre");

            migrationBuilder.DropIndex(
                name: "IX_livre_AdherentId",
                table: "livre");
        }
    }
}
