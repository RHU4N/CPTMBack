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
                    PK_CD_MEIO_AMBIENTE_CPTM = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false),
                    TX_NR_ELEMENTO_MONITORAMENTO = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    TX_NM_ELEMENTO_MONITORAMENTO = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    TX_SIGLA_DEPTO_MEIO_AMBIENTE = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    TX_STATUS_DO_DESVIO_AMBIENTAL = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    TX_STATUS_DO_REGISTRO_NO_BD = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    TX_MUNICIPIO = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    TX_LINHA_CPTM = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    TX_VIA_CPTM = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    TX_TRECHO_E_SENTIDO_CPTM = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    TX_KM_POSTE = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    TX_ESTACAO_CPTM = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    NR_LAT_GRAU_DECIMAL_WGS84 = table.Column<decimal>(type: "DECIMAL(18,8)", precision: 18, scale: 8, nullable: true),
                    NR_LONG_GRAU_DECIMAL_WGS84 = table.Column<decimal>(type: "DECIMAL(18,8)", precision: 18, scale: 8, nullable: true),
                    NR_LAT_METROS_SIRGAS2000 = table.Column<decimal>(type: "DECIMAL(18,3)", precision: 18, scale: 3, nullable: true),
                    NR_LONG_METROS_SIRGAS2000 = table.Column<decimal>(type: "DECIMAL(18,3)", precision: 18, scale: 3, nullable: true),
                    TX_NM_LOCAL_ESCOPO_CONTRATUAL = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    TX_TIPO_DE_FORMULARIO = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    DT_DATA_EMISSAO_FORMULARIO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    NR_NUMERO_DE_FORMULARIO = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    TX_AUTOR_PF_DO_FORMULARIO = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    TX_NATUREZA_DO_PGA = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    TX_NOME_PJ_EXECUTORA = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    TX_TIPO_ATIVIDADE_LISTADA = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    TX_TIPO_ATIVIDADE_N_LISTADA = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    TX_TIPO_DRA_LISTADO = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    TX_TIPO_DRA_N_LISTADO = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    TX_ID_DRA = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    DT_VALIDADE_DRA = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    TX_ANALISE_CPTM_APROVACAO = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    TX_TIPO_ATIVIDADE_CPTM = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    TX_NM_LOCAL_ATIV = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    TX_NM_LOCAL_ATIV_COMPLEMENTO = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    TX_ORIGEM_EFLUENTE = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    TX_FONTE_GERADORA = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    NR_QUANTIDADE_L = table.Column<decimal>(type: "DECIMAL(18,8)", precision: 18, scale: 8, nullable: true),
                    TX_TIPO_DESTINACAO = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    TX_TIPO_VEICULO = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    TX_ID_VEICULO = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    TX_ID_GUIA_REMESSA = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    NR_DISTANCIA_DA_VIA_M = table.Column<decimal>(type: "DECIMAL(10,2)", precision: 10, scale: 2, nullable: true),
                    TX_OFERECE_RISCO_SISTEMA_CPTM = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    TX_PROPRIETARIO = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    TX_OBS_CADASTRAMENTO = table.Column<string>(type: "NVARCHAR2(2000)", maxLength: 2000, nullable: true),
                    DT_DATA_DO_CADASTRAMENTO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: true),
                    HR_HORA_DO_CADASTRAMENTO = table.Column<string>(type: "NVARCHAR2(5)", maxLength: 5, nullable: true),
                    TX_AUTOR_PJ_DO_CADASTRO = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    TX_AUTOR_PF_DO_CADASTRO = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    TX_NM_RESPONSAVEL_CADASTRO = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    TX_RP_RESPONSAVEL_CADASTRO = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    TX_DRT_RESPONSAVEL_CADASTRO = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    TX_NOME_PJ_DA_CONTRATADA = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    TX_NR_CONTRATO_CONTRATADA = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    TX_NM_AREA_GESTORA_CPTM = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    TX_ID_AREA_GESTORA_CPTM = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    TX_SIGLA_AREA_GESTORA_CPTM = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    TX_NOME_PF_DA_REPRESENTANTE = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    TX_NOME_PJ_DA_SUPERVISORA = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    TX_NR_CONTRATO_SUPERVISORA = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    TX_NM_ARQUIVO_FDC_RELACIONADO = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    PK_CD_ARQUIVO_FDC_RELACIONADO = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    TX_NM_ARQUIVO_RVT_RELACIONADO = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    PK_CD_ELEMENTO_DE_MONITOR_RVT = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    TX_NM_ARQUIVO_DAC_RELACIONADO = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    PK_CD_ELEMENTO_DE_MONITOR_DAC = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    TX_NM_ARQUIVO_CNC_RELACIONADO = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    PK_CD_ELEMENTO_DE_MONITOR_CNC = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    PK_CD_CODIGO_NO_ULTIMO_RRA = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    PK_CD_CEDOC = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    TX_NOME_FOTO_01 = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    TX_NOME_FOTO_02 = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    TX_NOME_FOTO_03 = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true),
                    TX_NOME_FOTO_04 = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: true)
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
                name: "TB_AREA_GESTORA_CPTM",
                columns: table => new
                {
                    ID_AREA_GESTORA = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DS_AREA_GESTORA = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_AREA_GESTORA_CPTM", x => x.ID_AREA_GESTORA);
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
                name: "TB_ESTACAO_CPTM",
                columns: table => new
                {
                    ID_ESTACAO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DS_ESTACAO = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ESTACAO_CPTM", x => x.ID_ESTACAO);
                });

            migrationBuilder.CreateTable(
                name: "TB_FONTE_GERADORA",
                columns: table => new
                {
                    ID_FONTE_GERADORA = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DS_FONTE_GERADORA = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_FONTE_GERADORA", x => x.ID_FONTE_GERADORA);
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
                name: "TB_LOCAL_ATIVIDADE",
                columns: table => new
                {
                    ID_LOCAL_ATIVIDADE = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DS_LOCAL_ATIVIDADE = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_LOCAL_ATIVIDADE", x => x.ID_LOCAL_ATIVIDADE);
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
                name: "TB_NATUREZA_PGA",
                columns: table => new
                {
                    ID_NATUREZA = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DS_NATUREZA = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_NATUREZA_PGA", x => x.ID_NATUREZA);
                });

            migrationBuilder.CreateTable(
                name: "TB_ORIGEM_EFLUENTE",
                columns: table => new
                {
                    ID_ORIGEM_EFLUENTE = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DS_ORIGEM_EFLUENTE = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_ORIGEM_EFLUENTE", x => x.ID_ORIGEM_EFLUENTE);
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
                name: "TB_PROPRIETARIO",
                columns: table => new
                {
                    ID_PROPRIETARIO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DS_PROPRIETARIO = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PROPRIETARIO", x => x.ID_PROPRIETARIO);
                });

            migrationBuilder.CreateTable(
                name: "TB_SIM_NAO",
                columns: table => new
                {
                    ID_SIM_NAO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DS_SIM_NAO = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_SIM_NAO", x => x.ID_SIM_NAO);
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
                name: "TB_TIPO_ATIV_CPTM",
                columns: table => new
                {
                    ID_TIPO_ATIV_CPTM = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DS_TIPO_ATIV_CPTM = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_TIPO_ATIV_CPTM", x => x.ID_TIPO_ATIV_CPTM);
                });

            migrationBuilder.CreateTable(
                name: "TB_TIPO_ATIVIDADE",
                columns: table => new
                {
                    ID_TIPO_ATIVIDADE = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DS_TIPO_ATIVIDADE = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_TIPO_ATIVIDADE", x => x.ID_TIPO_ATIVIDADE);
                });

            migrationBuilder.CreateTable(
                name: "TB_TIPO_DESTINACAO",
                columns: table => new
                {
                    ID_TIPO_DESTINACAO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DS_TIPO_DESTINACAO = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_TIPO_DESTINACAO", x => x.ID_TIPO_DESTINACAO);
                });

            migrationBuilder.CreateTable(
                name: "TB_TIPO_DRA",
                columns: table => new
                {
                    ID_TIPO_DRA = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DS_TIPO_DRA = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_TIPO_DRA", x => x.ID_TIPO_DRA);
                });

            migrationBuilder.CreateTable(
                name: "TB_TIPO_VEICULO",
                columns: table => new
                {
                    ID_TIPO_VEICULO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DS_TIPO_VEICULO = table.Column<string>(type: "NVARCHAR2(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_TIPO_VEICULO", x => x.ID_TIPO_VEICULO);
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
                table: "TB_AREA_GESTORA_CPTM",
                columns: new[] { "ID_AREA_GESTORA", "DS_AREA_GESTORA" },
                values: new object[,]
                {
                    { 1, "(DE.GEA.0000) GERENCIA DE MEIO AMBIENTE [ID.10-14-4-0-0000]" },
                    { 2, "(DE.GEA.DEAE.0000) DEPTO. DE MEIO AMBIENTE - EMPREENDIMENTOS [ID.10-14-4-1-0000]" },
                    { 3, "(DE.GEA.DEAO.0000) DEPTO. DE MEIO AMBIENTE - OPERACAO [ID.10-14-4-2-0000]" },
                    { 4, "(DE.GEF.0000) GERENCIA DE EMPREENDIMENTOS [ID.10-14-6-0-0000]" },
                    { 5, "(DE.GEP.0000) GERENCIA DE PROJETOS [ID.10-14-1-0-0000]" },
                    { 6, "(DO.GOF.0000) GERENCIA DE MANUT. DE EQUIPAMENTOS FIXOS [ID.10-15-5-0-0000]" },
                    { 7, "(DO.GOV.0000) GERENCIA DE MANUT. DE VIA PERMANENTE E ESTRUTURA CIVIL [ID.10-15-6-0-0000]" },
                    { 8, "(DO.GOR.0000) GERENCIA MANUT. MAT RODANTE E OFICINAS [ID.10-15-3-0-0000]" },
                    { 9, "(DO.GOO.0000) GERENCIA GERAL DE OPERACAO [ID.10-16-1-0-0000]" },
                    { 10, "(DP.GPN.0000) GERENCIA DE NOVOS NEGOCIOS [ID.10-13-4-0-0000]" },
                    { 11, "Não se aplica(m)" },
                    { 12, "Inexistente(s)" },
                    { 13, "Indefinido(a)(s)" },
                    { 14, "Não avaliado(a)(s)" }
                });

            migrationBuilder.InsertData(
                table: "TB_DEPTO_MEIO_AMBIENTE",
                columns: new[] { "ID_DEPTO", "DS_DEPTO" },
                values: new object[,]
                {
                    { 1, "GEA" },
                    { 2, "GEA.DEAE" },
                    { 3, "GEA.DEAO" },
                    { 4, "Não se aplica(m)" },
                    { 5, "Inexistente(s)" },
                    { 6, "Indefinido(a)(s)" },
                    { 7, "Não avaliado(a)(s)" }
                });

            migrationBuilder.InsertData(
                table: "TB_ESTACAO_CPTM",
                columns: new[] { "ID_ESTACAO", "DS_ESTACAO" },
                values: new object[,]
                {
                    { 1, "Estação Aeroporto Guarulhos" },
                    { 2, "Estação Água Branca" },
                    { 3, "Estação Aracaré" },
                    { 4, "Estação Baltazar Fidelis" },
                    { 5, "Estação Barueri" },
                    { 6, "Estação Botujuru" },
                    { 7, "Estação Brás" },
                    { 8, "Estação Brás Cubas" },
                    { 9, "Estação Caieiras" },
                    { 10, "Estação Calmon Viana" },
                    { 11, "Estação Campo Limpo Paulista" },
                    { 12, "Estação Capuava" },
                    { 13, "Estação Carapicuíba" },
                    { 14, "Estação Corinthians - Itaquera" },
                    { 15, "Estação Dom Bosco" },
                    { 16, "Estação Engenheiro Goulart" },
                    { 17, "Estação Engenheiro Manoel Feio" },
                    { 18, "Estação Estudantes" },
                    { 19, "Estação Ferraz de Vasconcelos" },
                    { 20, "Estação Francisco Morato" },
                    { 21, "Estação Franco da Rocha" },
                    { 22, "Estação Guaianazes" },
                    { 23, "Estação Guarulhos Cecap" },
                    { 24, "Estação Ipiranga" },
                    { 25, "Estação Itapevi" },
                    { 26, "Estação Itaquaquecetuba" },
                    { 27, "Estação Jandira" },
                    { 28, "Estação Jardim Romano" },
                    { 29, "Estação José Bonifácio" },
                    { 30, "Estação Jundiaí" },
                    { 31, "Estação Jundiapeba" },
                    { 32, "Estação Lapa (Linha 7)" },
                    { 33, "Estação Lapa (Linha 8)" },
                    { 34, "Estação Luz" },
                    { 35, "Estação Mauá" },
                    { 36, "Estação Mogi das Cruzes" },
                    { 37, "Estação Osasco" },
                    { 38, "Estação Palmeiras - Barra Funda" },
                    { 39, "Estação Perus" },
                    { 40, "Estação Piqueri" },
                    { 41, "Estação Pirituba" },
                    { 42, "Estação Poá" },
                    { 43, "Estação Prefeito Celso Daniel - Santo André" },
                    { 44, "Estação Ribeirão Pires" },
                    { 45, "Estação Rio Grande da Serra" },
                    { 46, "Estação Roosevelt/Brás" },
                    { 47, "Estação Santo André" },
                    { 48, "Estação São Caetano" },
                    { 49, "Estação São Miguel Paulista" },
                    { 50, "Estação Suzano" },
                    { 51, "Estação Tamanduateí" },
                    { 52, "Estação Tatuapé" },
                    { 53, "Estação USP Leste" },
                    { 54, "Estação Utinga" },
                    { 55, "Estação Várzea Paulista" },
                    { 56, "Estação Vila Aurora" },
                    { 57, "Estação Vila Clarisse" },
                    { 58, "Não se aplica(m)" },
                    { 59, "Inexistente(s)" },
                    { 60, "Indefinido(a)(s)" },
                    { 61, "Não avaliado(a)(s)" }
                });

            migrationBuilder.InsertData(
                table: "TB_FONTE_GERADORA",
                columns: new[] { "ID_FONTE_GERADORA", "DS_FONTE_GERADORA" },
                values: new object[,]
                {
                    { 1, "Atividade de obra" },
                    { 2, "Banheiro químico" },
                    { 3, "Banheiros/vestiários/refeitórios" },
                    { 4, "Fossa séptica" },
                    { 5, "Lavagem de trens/peças" },
                    { 6, "Manutenção ETE" },
                    { 7, "Valas de manutenção" },
                    { 8, "Outro(a)(s)" },
                    { 9, "Indefinido(a)(s)" },
                    { 10, "Não se aplica(m)" },
                    { 11, "Inexistente(s)" },
                    { 12, "Não avaliado(a)(s)" }
                });

            migrationBuilder.InsertData(
                table: "TB_LINHA_CPTM",
                columns: new[] { "ID_LINHA", "DS_LINHA" },
                values: new object[,]
                {
                    { 1, "Linha 07 - Rubi" },
                    { 2, "Linha 08 - Diamante" },
                    { 3, "Linha 09 - Esmeralda" },
                    { 4, "Linha 10 - Turquesa" },
                    { 5, "Linha 11 - Coral" },
                    { 6, "Linha 12 - Safira" },
                    { 7, "Linha 13 - Jade" },
                    { 8, "Linha 05 - Lilás" },
                    { 9, "Linha JJ - Baixada Santista" },
                    { 10, "Sem linha associada" },
                    { 11, "Linha não informada" },
                    { 12, "Não se aplica(m)" },
                    { 13, "Inexistente(s)" },
                    { 14, "Indefinido(a)(s)" },
                    { 15, "Não avaliado(a)(s)" }
                });

            migrationBuilder.InsertData(
                table: "TB_LOCAL_ATIVIDADE",
                columns: new[] { "ID_LOCAL_ATIVIDADE", "DS_LOCAL_ATIVIDADE" },
                values: new object[,]
                {
                    { 1, "Abrigo" },
                    { 2, "Base de manutenção" },
                    { 3, "Cabine Primária" },
                    { 4, "Cabine Seccionadora" },
                    { 5, "Estação" },
                    { 6, "Lavador de TUE" },
                    { 7, "Oficina" },
                    { 8, "Pátio" },
                    { 9, "Prédio administrativo" },
                    { 10, "Prédio de apoio" },
                    { 11, "Sala técnica" },
                    { 12, "Subestação" },
                    { 13, "Trecho - Km/poste" },
                    { 14, "Vários" },
                    { 15, "Outro(a)(s)" },
                    { 16, "Indefinido(a)(s)" },
                    { 17, "Não se aplica(m)" },
                    { 18, "Inexistente(s)" },
                    { 19, "Não avaliado(a)(s)" }
                });

            migrationBuilder.InsertData(
                table: "TB_MUNICIPIO",
                columns: new[] { "ID_MUNICIPIO", "DS_MUNICIPIO" },
                values: new object[,]
                {
                    { 1, "Arujá" },
                    { 2, "Barueri" },
                    { 3, "Biritiba-Mirim" },
                    { 4, "Caieiras" },
                    { 5, "Cajamar" },
                    { 6, "Campo Limpo Paulista" },
                    { 7, "Carapicuíba" },
                    { 8, "Cotia" },
                    { 9, "Diadema" },
                    { 10, "Embu" },
                    { 11, "Embu-Guaçu" },
                    { 12, "Ferraz de Vasconcelos" },
                    { 13, "Francisco Morato" },
                    { 14, "Franco da Rocha" },
                    { 15, "Guararema" },
                    { 16, "Guarulhos" },
                    { 17, "Itapecerica da Serra" },
                    { 18, "Itapevi" },
                    { 19, "Itaquaquecetuba" },
                    { 20, "Jandira" },
                    { 21, "Jundiaí" },
                    { 22, "Juqutiba" },
                    { 23, "Mairinque" },
                    { 24, "Mairiporã" },
                    { 25, "Mauá" },
                    { 26, "Mogi das Cruzes" },
                    { 27, "Osasco" },
                    { 28, "Pirapora do Bom Jesus" },
                    { 29, "Poá" },
                    { 30, "Ribeirão Pires" },
                    { 31, "Rio Grande da Serra" },
                    { 32, "Salesópolis" },
                    { 33, "Santa Isabel" },
                    { 34, "Santana de Parnaíba" },
                    { 35, "Santo André" },
                    { 36, "Santos" },
                    { 37, "São Bernardo do Campo" },
                    { 38, "São Caetano do Sul" },
                    { 39, "São Lourenço da Serra" },
                    { 40, "São Paulo" },
                    { 41, "São Roque" },
                    { 42, "São Vicente" },
                    { 43, "Suzano" },
                    { 44, "Taboão da Serra" },
                    { 45, "Vargem Grande Paulista" },
                    { 46, "Várzea Paulista" },
                    { 47, "Diversos (Ver Observação)" },
                    { 48, "Não se aplica(m)" },
                    { 49, "Inexistente(s)" },
                    { 50, "Indefinido(a)(s)" },
                    { 51, "Não avaliado(a)(s)" }
                });

            migrationBuilder.InsertData(
                table: "TB_NATUREZA_PGA",
                columns: new[] { "ID_NATUREZA", "DS_NATUREZA" },
                values: new object[,]
                {
                    { 1, "Áreas Ambientalmente Protegidas" },
                    { 2, "Áreas Contaminadas" },
                    { 3, "Arqueologia" },
                    { 4, "Comunicação Social" },
                    { 5, "Documentação" },
                    { 6, "Efluente" },
                    { 7, "Emissões Atmosféricas" },
                    { 8, "Erosões e Movimentos de Massa" },
                    { 9, "Fauna" },
                    { 10, "Gerenciamento de Solo" },
                    { 11, "Lançamentos Irregulares" },
                    { 12, "Patrimônio Histórico" },
                    { 13, "Produtos Perigosos" },
                    { 14, "Recursos Hídricos" },
                    { 15, "Resíduos Sólidos" },
                    { 16, "Ruído e Vibração" },
                    { 17, "Segmentação Urbana" },
                    { 18, "Sinalização e Isolamento" },
                    { 19, "Sistema de Drenagem, Inundações e Alagamentos" },
                    { 20, "Vegetação" },
                    { 21, "Não se aplica(m)" },
                    { 22, "Inexistente(s)" },
                    { 23, "Indefinido(a)(s)" },
                    { 24, "Não avaliado(a)(s)" }
                });

            migrationBuilder.InsertData(
                table: "TB_ORIGEM_EFLUENTE",
                columns: new[] { "ID_ORIGEM_EFLUENTE", "DS_ORIGEM_EFLUENTE" },
                values: new object[,]
                {
                    { 1, "Doméstico/Sanitário" },
                    { 2, "Fundação" },
                    { 3, "Industrial" },
                    { 4, "Outro(a)(s)" },
                    { 5, "Indefinido(a)(s)" },
                    { 6, "Não se aplica(m)" },
                    { 7, "Inexistente(s)" },
                    { 8, "Não avaliado(a)(s)" }
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
                table: "TB_PROPRIETARIO",
                columns: new[] { "ID_PROPRIETARIO", "DS_PROPRIETARIO" },
                values: new object[,]
                {
                    { 1, "CPTM - Titularidade" },
                    { 2, "CPTM - Posse" },
                    { 3, "Metrô" },
                    { 4, "Alienado" },
                    { 5, "MRS" },
                    { 6, "RFSA" },
                    { 7, "RFSA/SPU" },
                    { 8, "CBTU" },
                    { 9, "Pessoa Jurídica" },
                    { 10, "Pessoa Física" },
                    { 11, "Indefinido" },
                    { 12, "FEPASA" },
                    { 13, "Permuta" },
                    { 14, "Prefeitura de Guarulhos" },
                    { 15, "DAEE" },
                    { 16, "USP Leste" },
                    { 17, "GRU - Aeroporto" },
                    { 18, "CCR - Rodovia Dutra" },
                    { 19, "Ecopistas" },
                    { 20, "CDHU" },
                    { 21, "Não se aplica(m)" },
                    { 22, "Inexistente(s)" },
                    { 23, "Não avaliado(a)(s)" }
                });

            migrationBuilder.InsertData(
                table: "TB_SIM_NAO",
                columns: new[] { "ID_SIM_NAO", "DS_SIM_NAO" },
                values: new object[,]
                {
                    { 1, "Sim" },
                    { 2, "Não" },
                    { 3, "Não Informado" },
                    { 4, "Não se aplica(m)" },
                    { 5, "Inexistente(s)" },
                    { 6, "Indefinido(a)(s)" },
                    { 7, "Não avaliado(a)(s)" }
                });

            migrationBuilder.InsertData(
                table: "TB_STATUS_DESVIO_AMBIENTAL",
                columns: new[] { "ID_STATUS", "DS_STATUS" },
                values: new object[,]
                {
                    { 1, "Não Regularizado" },
                    { 2, "Regularizado" },
                    { 3, "Não se aplica(m)" },
                    { 4, "Inexistente(s)" },
                    { 5, "Indefinido(a)(s)" },
                    { 6, "Não avaliado(a)(s)" }
                });

            migrationBuilder.InsertData(
                table: "TB_STATUS_REGISTRO",
                columns: new[] { "ID_STATUS", "DS_STATUS" },
                values: new object[,]
                {
                    { 1, "Ativo" },
                    { 2, "Inativo" },
                    { 3, "Não se aplica(m)" },
                    { 4, "Inexistente(s)" },
                    { 5, "Indefinido(a)(s)" },
                    { 6, "Não avaliado(a)(s)" }
                });

            migrationBuilder.InsertData(
                table: "TB_TIPO_ATIVIDADE",
                columns: new[] { "ID_TIPO_ATIVIDADE", "DS_TIPO_ATIVIDADE" },
                values: new object[,]
                {
                    { 1, "Estação de Tratamento de Efluente" },
                    { 2, "Transporte" },
                    { 3, "Outro(a)(s)" },
                    { 4, "Indefinido(a)(s)" },
                    { 5, "Não se aplica(m)" },
                    { 6, "Inexistente(s)" },
                    { 7, "Não avaliado(a)(s)" }
                });

            migrationBuilder.InsertData(
                table: "TB_TIPO_ATIV_CPTM",
                columns: new[] { "ID_TIPO_ATIV_CPTM", "DS_TIPO_ATIV_CPTM" },
                values: new object[,]
                {
                    { 1, "Empreendimento/Obra" },
                    { 2, "Manutenção" },
                    { 3, "Operação" },
                    { 4, "Outro(a)(s)" },
                    { 5, "Indefinido(a)(s)" },
                    { 6, "Não se aplica(m)" },
                    { 7, "Inexistente(s)" },
                    { 8, "Não avaliado(a)(s)" }
                });

            migrationBuilder.InsertData(
                table: "TB_TIPO_DESTINACAO",
                columns: new[] { "ID_TIPO_DESTINACAO", "DS_TIPO_DESTINACAO" },
                values: new object[,]
                {
                    { 1, "Esgotamento e transporte" },
                    { 2, "Interligação em rede coletora" },
                    { 3, "Lançamento em galeria de águas pluviais" },
                    { 4, "Reinfiltração" },
                    { 5, "Tratamento em ETE" },
                    { 6, "Outro(a)(s)" },
                    { 7, "Indefinido(a)(s)" },
                    { 8, "Não se aplica(m)" },
                    { 9, "Inexistente(s)" },
                    { 10, "Não avaliado(a)(s)" }
                });

            migrationBuilder.InsertData(
                table: "TB_TIPO_DRA",
                columns: new[] { "ID_TIPO_DRA", "DS_TIPO_DRA" },
                values: new object[,]
                {
                    { 1, "Cadastro Técnico Federal (IBAMA) - CTF/IBAMA" },
                    { 2, "Certificado de Dispensa de Licença - CDL" },
                    { 3, "Certificado de Movimentação de Resíduos de Interesse Ambiental - CADRI" },
                    { 4, "Declaração de Movimentação de Resíduos - DMR" },
                    { 5, "Ficha de Informações de Segurança de Produtos Químicos - FISPQ" },
                    { 6, "Licença de Operação - LO" },
                    { 7, "Manifesto de Transporte de Resíduos - MTR" },
                    { 8, "Outro(a)(s)" },
                    { 9, "Indefinido(a)(s)" },
                    { 10, "Não se aplica(m)" },
                    { 11, "Inexistente(s)" },
                    { 12, "Não avaliado(a)(s)" }
                });

            migrationBuilder.InsertData(
                table: "TB_TIPO_VEICULO",
                columns: new[] { "ID_TIPO_VEICULO", "DS_TIPO_VEICULO" },
                values: new object[,]
                {
                    { 1, "Caminhão" },
                    { 2, "Outro(a)(s)" },
                    { 3, "Indefinido(a)(s)" },
                    { 4, "Não se aplica(m)" },
                    { 5, "Inexistente(s)" },
                    { 6, "Não avaliado(a)(s)" }
                });

            migrationBuilder.InsertData(
                table: "TB_TRECHO_SENTIDO",
                columns: new[] { "ID_TRECHO", "DS_TRECHO" },
                values: new object[,]
                {
                    { 1, "Estação Aeroporto Guarulhos - Estação Guarulhos - Cecap" },
                    { 2, "Estação Água Branca - Estação Lapa" },
                    { 3, "Estação Barra Funda - Estação Luz" },
                    { 4, "Estação Caieiras - Estação Franco da Rocha" },
                    { 5, "Estação Campo Limpo Paulista - Estação Botujuru" },
                    { 6, "Estação Corinthians - Itaquera - Estação Tatuapé" },
                    { 7, "Estação Francisco Morato - Estação Baltazar Fidelis" },
                    { 8, "Estação Guarulhos - Cecap - Estação Engenheiro Goulart" },
                    { 9, "Estação Ipiranga - Estação Tamanduateí" },
                    { 10, "Estação Jundiapeba - Estação Suzano" },
                    { 11, "Estação Lapa (Linha 07) - Estação Água Branca" },
                    { 12, "Estação Luz - Estação Barra Funda" },
                    { 13, "Estação Mogi das Cruzes - Estação Estudantes" },
                    { 14, "Estação Palmeiras - Barra Funda - Estação Água Branca" },
                    { 15, "Estação Perus - Estação Caieiras" },
                    { 16, "Estação Pirituba - Estação Vila Clarisse" },
                    { 17, "Estação Ribeirão Pires - Estação Rio Grande da Serra" },
                    { 18, "Estação Roosevelt/Brás - Estação Luz" },
                    { 19, "Estação Santo André - Estação Capuava" },
                    { 20, "Estação Suzano - Estação Calmon Viana" },
                    { 21, "Estação Tatuapé - Estação Engenheiro Goulart" },
                    { 22, "Estação Várzea Paulista - Estação Jundiaí" },
                    { 23, "Final dos Trilhos - Estação Estudantes" },
                    { 24, "Não se aplica(m)" },
                    { 25, "Inexistente(s)" },
                    { 26, "Indefinido(a)(s)" },
                    { 27, "Não avaliado(a)(s)" }
                });

            migrationBuilder.InsertData(
                table: "TB_VIA_CPTM",
                columns: new[] { "ID_VIA", "DS_VIA" },
                values: new object[,]
                {
                    { 1, "Via 01" },
                    { 2, "Via 02" },
                    { 3, "Via 03" },
                    { 4, "Via 04" },
                    { 5, "Via 05" },
                    { 6, "Via 06" },
                    { 7, "Via 08" },
                    { 8, "Via 09" },
                    { 9, "Via 10" },
                    { 10, "Via 01S - Trecho 1" },
                    { 11, "Via 01S - Trecho 2" },
                    { 12, "Via 02S - Trecho 1" },
                    { 13, "Via 02S - Trecho 2" },
                    { 14, "Via 03S - Trecho 2" },
                    { 15, "Via 03E - Trecho 2" },
                    { 16, "Via 04E - Trecho 2" },
                    { 17, "Via Auxiliar" },
                    { 18, "Via Variante" },
                    { 19, "Travessão - AMV" },
                    { 20, "Não se aplica(m)" },
                    { 21, "Inexistente(s)" },
                    { 22, "Indefinido(a)(s)" },
                    { 23, "Não avaliado(a)(s)" }
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
                name: "TB_AREA_GESTORA_CPTM");

            migrationBuilder.DropTable(
                name: "TB_DEPTO_MEIO_AMBIENTE");

            migrationBuilder.DropTable(
                name: "TB_ESTACAO_CPTM");

            migrationBuilder.DropTable(
                name: "TB_FONTE_GERADORA");

            migrationBuilder.DropTable(
                name: "TB_LINHA_CPTM");

            migrationBuilder.DropTable(
                name: "TB_LOCAL_ATIVIDADE");

            migrationBuilder.DropTable(
                name: "TB_LOG_ACAO");

            migrationBuilder.DropTable(
                name: "TB_LOG_SINCRONIZACAO");

            migrationBuilder.DropTable(
                name: "TB_MUNICIPIO");

            migrationBuilder.DropTable(
                name: "TB_NATUREZA_PGA");

            migrationBuilder.DropTable(
                name: "TB_ORIGEM_EFLUENTE");

            migrationBuilder.DropTable(
                name: "TB_PERFIL_USUARIO");

            migrationBuilder.DropTable(
                name: "TB_PROPRIETARIO");

            migrationBuilder.DropTable(
                name: "TB_SIM_NAO");

            migrationBuilder.DropTable(
                name: "TB_STATUS_DESVIO_AMBIENTAL");

            migrationBuilder.DropTable(
                name: "TB_STATUS_REGISTRO");

            migrationBuilder.DropTable(
                name: "TB_TIPO_ATIV_CPTM");

            migrationBuilder.DropTable(
                name: "TB_TIPO_ATIVIDADE");

            migrationBuilder.DropTable(
                name: "TB_TIPO_DESTINACAO");

            migrationBuilder.DropTable(
                name: "TB_TIPO_DRA");

            migrationBuilder.DropTable(
                name: "TB_TIPO_VEICULO");

            migrationBuilder.DropTable(
                name: "TB_TRECHO_SENTIDO");

            migrationBuilder.DropTable(
                name: "TB_USUARIO");

            migrationBuilder.DropTable(
                name: "TB_VIA_CPTM");
        }
    }
}
