using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CPTMBack.Migrations
{
    /// <inheritdoc />
    public partial class FixHoraCadastramento_MaxLength8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "FL_PRIMEIRO_ACESSO",
                table: "TB_USUARIO",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "NUMBER(1)");

            migrationBuilder.AlterColumn<int>(
                name: "FL_ATIVO",
                table: "TB_USUARIO",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "NUMBER(1)");

            migrationBuilder.AlterColumn<string>(
                name: "HR_HORA_DO_CADASTRAMENTO",
                table: "PT_EFLUENTE",
                type: "NVARCHAR2(8)",
                maxLength: 8,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(5)",
                oldMaxLength: 5,
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "FL_PRIMEIRO_ACESSO",
                table: "TB_USUARIO",
                type: "NUMBER(1)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AlterColumn<bool>(
                name: "FL_ATIVO",
                table: "TB_USUARIO",
                type: "NUMBER(1)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AlterColumn<string>(
                name: "HR_HORA_DO_CADASTRAMENTO",
                table: "PT_EFLUENTE",
                type: "NVARCHAR2(5)",
                maxLength: 5,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR2(8)",
                oldMaxLength: 8,
                oldNullable: true);
        }
    }
}
