using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CPTMBack.Migrations
{
    /// <inheritdoc />
    public partial class AddFirstAccessFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "FL_PRIMEIRO_ACESSO",
                table: "TB_USUARIO",
                type: "NUMBER(1)",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DT_ULTIMA_TROCA_SENHA",
                table: "TB_USUARIO",
                type: "TIMESTAMP(7)",
                nullable: true);

            // Usuarios ja existentes nao devem ser forcados a trocar a senha
            migrationBuilder.Sql("UPDATE TB_USUARIO SET FL_PRIMEIRO_ACESSO = 0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FL_PRIMEIRO_ACESSO",
                table: "TB_USUARIO");

            migrationBuilder.DropColumn(
                name: "DT_ULTIMA_TROCA_SENHA",
                table: "TB_USUARIO");
        }
    }
}
