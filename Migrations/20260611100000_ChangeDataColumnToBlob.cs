using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CPTMBack.Migrations
{
    /// <inheritdoc />
    public partial class ChangeDataColumnToBlob : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Oracle nao suporta ALTER COLUMN de RAW para BLOB diretamente.
            // Adiciona nova coluna BLOB, descarta a coluna RAW antiga e renomeia.
            migrationBuilder.Sql("ALTER TABLE \"RT_EFLUENTE\" ADD \"DATA_BLOB\" BLOB");
            migrationBuilder.Sql("ALTER TABLE \"RT_EFLUENTE\" DROP COLUMN \"DATA\"");
            migrationBuilder.Sql("ALTER TABLE \"RT_EFLUENTE\" RENAME COLUMN \"DATA_BLOB\" TO \"DATA\"");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("ALTER TABLE \"RT_EFLUENTE\" ADD \"DATA_RAW\" RAW(2000)");
            migrationBuilder.Sql("ALTER TABLE \"RT_EFLUENTE\" DROP COLUMN \"DATA\"");
            migrationBuilder.Sql("ALTER TABLE \"RT_EFLUENTE\" RENAME COLUMN \"DATA_RAW\" TO \"DATA\"");
        }
    }
}
