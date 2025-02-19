using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AntecipacaoRecebivel.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InsertNotaFiscal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NotaFiscal",
                columns: table => new
                {
                    Numero = table.Column<int>(type: "int", nullable: false),
                    EmpresaCNPJ = table.Column<string>(type: "nvarchar(14)", nullable: false),
                    Valor = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Vencimento = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotaFiscal", x => x.Numero);
                    table.ForeignKey(
                        name: "FK_NotaFiscal_Empresa_EmpresaCNPJ",
                        column: x => x.EmpresaCNPJ,
                        principalTable: "Empresa",
                        principalColumn: "Cnpj",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NotaFiscal_EmpresaCNPJ",
                table: "NotaFiscal",
                column: "EmpresaCNPJ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NotaFiscal");
        }
    }
}
