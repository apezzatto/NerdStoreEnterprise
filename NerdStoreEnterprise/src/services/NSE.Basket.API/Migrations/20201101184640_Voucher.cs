using Microsoft.EntityFrameworkCore.Migrations;

namespace NSE.Basket.API.Migrations
{
    public partial class Voucher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarrinhoItens_CarrinhoCliente_CarrinhoId",
                table: "CarrinhoItens");

            migrationBuilder.AddColumn<decimal>(
                name: "Desconto",
                table: "CarrinhoCliente",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "VoucherUtilizado",
                table: "CarrinhoCliente",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "VoucherCodigo",
                table: "CarrinhoCliente",
                type: "varchar(50)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Percentual",
                table: "CarrinhoCliente",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TipoDesconto",
                table: "CarrinhoCliente",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ValorDesconto",
                table: "CarrinhoCliente",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_CarrinhoItens_CarrinhoCliente_CarrinhoId",
                table: "CarrinhoItens",
                column: "CarrinhoId",
                principalTable: "CarrinhoCliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarrinhoItens_CarrinhoCliente_CarrinhoId",
                table: "CarrinhoItens");

            migrationBuilder.DropColumn(
                name: "Desconto",
                table: "CarrinhoCliente");

            migrationBuilder.DropColumn(
                name: "VoucherUtilizado",
                table: "CarrinhoCliente");

            migrationBuilder.DropColumn(
                name: "VoucherCodigo",
                table: "CarrinhoCliente");

            migrationBuilder.DropColumn(
                name: "Percentual",
                table: "CarrinhoCliente");

            migrationBuilder.DropColumn(
                name: "TipoDesconto",
                table: "CarrinhoCliente");

            migrationBuilder.DropColumn(
                name: "ValorDesconto",
                table: "CarrinhoCliente");

            migrationBuilder.AddForeignKey(
                name: "FK_CarrinhoItens_CarrinhoCliente_CarrinhoId",
                table: "CarrinhoItens",
                column: "CarrinhoId",
                principalTable: "CarrinhoCliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
