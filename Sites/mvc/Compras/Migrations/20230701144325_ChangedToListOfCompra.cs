using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Compras.Migrations
{
    /// <inheritdoc />
    public partial class ChangedToListOfCompra : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Compras_CompraId",
                table: "Clientes");

            migrationBuilder.DropIndex(
                name: "IX_Clientes_CompraId",
                table: "Clientes");

            migrationBuilder.DropColumn(
                name: "CompraId",
                table: "Clientes");

            migrationBuilder.AddColumn<int>(
                name: "ClienteId",
                table: "Compras",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Compras_ClienteId",
                table: "Compras",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Compras_Clientes_ClienteId",
                table: "Compras",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Compras_Clientes_ClienteId",
                table: "Compras");

            migrationBuilder.DropIndex(
                name: "IX_Compras_ClienteId",
                table: "Compras");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Compras");

            migrationBuilder.AddColumn<int>(
                name: "CompraId",
                table: "Clientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_CompraId",
                table: "Clientes",
                column: "CompraId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Compras_CompraId",
                table: "Clientes",
                column: "CompraId",
                principalTable: "Compras",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
