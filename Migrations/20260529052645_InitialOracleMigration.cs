using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CPTMBack.Migrations
{
    /// <inheritdoc />
    public partial class InitialOracleMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PT_EFLUENTE",
                columns: table => new
                {
                    PK_CD_MEIO_AMBIENTE_CPTM = table.Column<string>(type: "NVARCHAR2(450)", nullable: false),
                    ID_DEPTO_MEIO_AMBIENTE = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ID_STATUS_DESVIO = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ID_STATUS_REGISTRO = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ID_MUNICIPIO = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ID_LINHA = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ID_VIA = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ID_TRECHO = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ID_TIPO_EFLUENTE = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TX_NR_ELEMENTO_MONITORAMENTO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    TX_NM_ELEMENTO_MONITORAMENTO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    TX_KM_POSTE = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    TX_ENDERECO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    TX_COORDENADA_X = table.Column<decimal>(type: "DECIMAL(18,8)", precision: 18, scale: 8, nullable: true),
                    TX_COORDENADA_Y = table.Column<decimal>(type: "DECIMAL(18,8)", precision: 18, scale: 8, nullable: true),
                    DT_REGISTRO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    DT_ATUALIZACAO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    TX_NOME_TECNICO_RESPONSAVEL = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    TX_EMAIL_TECNICO_RESPONSAVEL = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    TX_TELEFONE_TECNICO_RESPONSAVEL = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    TX_EMPRESA_CONTRATADA = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    TX_NUMERO_CONTRATO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    TX_PROCESSO_AMBIENTAL = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    TX_ORIGEM_EFLUENTE = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    TX_DESTINACAO_EFLUENTE = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    TX_VOLUME_EFLUENTE = table.Column<decimal>(type: "DECIMAL(18,2)", precision: 18, scale: 2, nullable: true),
                    TX_UNIDADE_VOLUME = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    TX_COR_EFLUENTE = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    TX_ODOR_EFLUENTE = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    TX_PH = table.Column<decimal>(type: "DECIMAL(10,2)", precision: 10, scale: 2, nullable: true),
                    TX_TEMPERATURA = table.Column<decimal>(type: "DECIMAL(10,2)", precision: 10, scale: 2, nullable: true),
                    TX_OBSERVACAO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    TX_LINK_MAPA = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    TX_NOME_FOTO_01 = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    TX_NOME_FOTO_02 = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    TX_NOME_FOTO_03 = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    TX_NOME_FOTO_04 = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PT_EFLUENTE", x => x.PK_CD_MEIO_AMBIENTE_CPTM);
                });

            migrationBuilder.CreateTable(
                name: "RT_EFLUENTE",
                columns: table => new
                {
                    ATTACHMENTID = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    REL_OBJECTID = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CONTENT_TYPE = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ATT_NAME = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DATA_SIZE = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    DATA = table.Column<byte[]>(type: "RAW(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RT_EFLUENTE", x => x.ATTACHMENTID);
                });

            migrationBuilder.CreateTable(
                name: "TB_DEPTO_MEIO_AMBIENTE",
                columns: table => new
                {
                    ID_DEPTO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DS_DEPTO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_DEPTO_MEIO_AMBIENTE", x => x.ID_DEPTO);
                });

            migrationBuilder.CreateTable(
                name: "TB_LINHA_CPTM",
                columns: table => new
                {
                    ID_LINHA = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DS_LINHA = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_LINHA_CPTM", x => x.ID_LINHA);
                });

            migrationBuilder.CreateTable(
                name: "TB_LOG_ACAO",
                columns: table => new
                {
                    ID_LOG = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ID_USUARIO = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DS_ACAO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    NM_TABELA = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ID_REGISTRO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DT_ACAO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    DS_IP = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_LOG_ACAO", x => x.ID_LOG);
                });

            migrationBuilder.CreateTable(
                name: "TB_LOG_SINCRONIZACAO",
                columns: table => new
                {
                    ID_LOG = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    ID_USUARIO = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DT_SINCRONIZACAO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    DS_STATUS = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DS_MENSAGEM = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_LOG_SINCRONIZACAO", x => x.ID_LOG);
                });

            migrationBuilder.CreateTable(
                name: "TB_MUNICIPIO",
                columns: table => new
                {
                    ID_MUNICIPIO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DS_MUNICIPIO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_MUNICIPIO", x => x.ID_MUNICIPIO);
                });

            migrationBuilder.CreateTable(
                name: "TB_PERFIL_USUARIO",
                columns: table => new
                {
                    ID_PERFIL = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DS_PERFIL = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PERFIL_USUARIO", x => x.ID_PERFIL);
                });

            migrationBuilder.CreateTable(
                name: "TB_STATUS_DESVIO_AMBIENTAL",
                columns: table => new
                {
                    ID_STATUS = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DS_STATUS = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_STATUS_DESVIO_AMBIENTAL", x => x.ID_STATUS);
                });

            migrationBuilder.CreateTable(
                name: "TB_STATUS_REGISTRO",
                columns: table => new
                {
                    ID_STATUS = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DS_STATUS = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_STATUS_REGISTRO", x => x.ID_STATUS);
                });

            migrationBuilder.CreateTable(
                name: "TB_TIPO_EFLUENTE",
                columns: table => new
                {
                    ID_TIPO_EFLUENTE = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DS_TIPO_EFLUENTE = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_TIPO_EFLUENTE", x => x.ID_TIPO_EFLUENTE);
                });

            migrationBuilder.CreateTable(
                name: "TB_TRECHO_SENTIDO",
                columns: table => new
                {
                    ID_TRECHO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DS_TRECHO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_TRECHO_SENTIDO", x => x.ID_TRECHO);
                });

            migrationBuilder.CreateTable(
                name: "TB_USUARIO",
                columns: table => new
                {
                    ID_USUARIO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NM_USUARIO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DS_LOGIN = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DS_EMAIL = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DS_SENHA_HASH = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ID_PERFIL = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    FL_ATIVO = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    DT_CADASTRO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    DT_ATUALIZACAO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USUARIO", x => x.ID_USUARIO);
                });

            migrationBuilder.CreateTable(
                name: "TB_VIA_CPTM",
                columns: table => new
                {
                    ID_VIA = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DS_VIA = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_VIA_CPTM", x => x.ID_VIA);
                });

            migrationBuilder.InsertData(
                table: "TB_DEPTO_MEIO_AMBIENTE",
                columns: new[] { "ID_DEPTO", "DS_DEPTO" },
                values: new object[,]
                {
                    { 1, "NORTE" },
                    { 2, "SUL" },
                    { 3, "LESTE" },
                    { 4, "OESTE" }
                });

            migrationBuilder.InsertData(
                table: "TB_LINHA_CPTM",
                columns: new[] { "ID_LINHA", "DS_LINHA" },
                values: new object[,]
                {
                    { 1, "LINHA_7" },
                    { 2, "LINHA_8" },
                    { 3, "LINHA_9" },
                    { 4, "LINHA_10" },
                    { 5, "LINHA_11" },
                    { 6, "LINHA_12" },
                    { 7, "LINHA_13" }
                });

            migrationBuilder.InsertData(
                table: "TB_PERFIL_USUARIO",
                columns: new[] { "ID_PERFIL", "DS_PERFIL" },
                values: new object[,]
                {
                    { 1, "ADMINISTRADOR" },
                    { 2, "USUARIO_CAMPO" }
                });

            migrationBuilder.InsertData(
                table: "TB_STATUS_DESVIO_AMBIENTAL",
                columns: new[] { "ID_STATUS", "DS_STATUS" },
                values: new object[,]
                {
                    { 1, "ABERTO" },
                    { 2, "EM_ANALISE" },
                    { 3, "RESOLVIDO" },
                    { 4, "CANCELADO" }
                });

            migrationBuilder.InsertData(
                table: "TB_STATUS_REGISTRO",
                columns: new[] { "ID_STATUS", "DS_STATUS" },
                values: new object[,]
                {
                    { 1, "ATIVO" },
                    { 2, "INATIVO" },
                    { 3, "PENDENTE" },
                    { 4, "SINCRONIZADO" }
                });

            migrationBuilder.InsertData(
                table: "TB_TIPO_EFLUENTE",
                columns: new[] { "ID_TIPO_EFLUENTE", "DS_TIPO_EFLUENTE" },
                values: new object[,]
                {
                    { 1, "ESGOTO" },
                    { 2, "OLEO" },
                    { 3, "QUIMICO" },
                    { 4, "INDUSTRIAL" },
                    { 5, "AGUA_CONTAMINADA" }
                });

            migrationBuilder.InsertData(
                table: "TB_VIA_CPTM",
                columns: new[] { "ID_VIA", "DS_VIA" },
                values: new object[,]
                {
                    { 1, "VIA_1" },
                    { 2, "VIA_2" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PT_EFLUENTE");

            migrationBuilder.DropTable(
                name: "RT_EFLUENTE");

            migrationBuilder.DropTable(
                name: "TB_DEPTO_MEIO_AMBIENTE");

            migrationBuilder.DropTable(
                name: "TB_LINHA_CPTM");

            migrationBuilder.DropTable(
                name: "TB_LOG_ACAO");

            migrationBuilder.DropTable(
                name: "TB_LOG_SINCRONIZACAO");

            migrationBuilder.DropTable(
                name: "TB_MUNICIPIO");

            migrationBuilder.DropTable(
                name: "TB_PERFIL_USUARIO");

            migrationBuilder.DropTable(
                name: "TB_STATUS_DESVIO_AMBIENTAL");

            migrationBuilder.DropTable(
                name: "TB_STATUS_REGISTRO");

            migrationBuilder.DropTable(
                name: "TB_TIPO_EFLUENTE");

            migrationBuilder.DropTable(
                name: "TB_TRECHO_SENTIDO");

            migrationBuilder.DropTable(
                name: "TB_USUARIO");

            migrationBuilder.DropTable(
                name: "TB_VIA_CPTM");
        }
    }
}
