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
            // Oracle-safe: add as nullable first, backfill, then add NOT NULL constraint
            migrationBuilder.AddColumn<bool>(
                name: "FL_PRIMEIRO_ACESSO",
                table: "TB_USUARIO",
                type: "NUMBER(1)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DT_ULTIMA_TROCA_SENHA",
                table: "TB_USUARIO",
                type: "TIMESTAMP(7)",
                nullable: true);

            // Usuarios ja existentes nao devem ser forcados a trocar senha
            migrationBuilder.Sql("UPDATE TB_USUARIO SET FL_PRIMEIRO_ACESSO = 0 WHERE FL_PRIMEIRO_ACESSO IS NULL");

            // Torna a coluna NOT NULL apos o backfill (Oracle exige que nao haja NULLs antes)
            migrationBuilder.Sql("ALTER TABLE TB_USUARIO MODIFY FL_PRIMEIRO_ACESSO NUMBER(1) DEFAULT 0 NOT NULL");
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
