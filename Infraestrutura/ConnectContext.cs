using Microsoft.EntityFrameworkCore;
using CPTMBack.Domain.Model.TblPrincipais.PT_EFLUENTEAggregate;
using CPTMBack.Domain.Model.TblPrincipais.RT_EFLUENTEAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_MUNICIPIOAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_LINHA_CPTMAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_VIA_CPTMAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_STATUS_DESVIO_AMBIENTALAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_STATUS_REGISTROAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_DEPTO_MEIO_AMBIENTEAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_TRECHO_SENTIDOAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_PERFIL_USUARIOAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_ESTACAO_CPTMAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_NATUREZA_PGAAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_AREA_GESTORA_CPTMAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_PROPRIETARIOAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_SIM_NAOAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_TIPO_ATIVIDADEAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_TIPO_DRAAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_TIPO_ATIV_CPTMAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_LOCAL_ATIVIDADEAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_ORIGEM_EFLUENTEAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_FONTE_GERADORAAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_TIPO_DESTINACAOAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_TIPO_VEICULOAggregate;
using CPTMBack.Domain.Model.TblSistema.TB_USUARIOAggregate;
using CPTMBack.Domain.Model.TblSistema.TB_LOG_ACAOAggregate;
using CPTMBack.Domain.Model.TblSistema.TB_LOG_SINCRONIZACAOAggregate;

namespace CPTMBack.Infraestrutura
{
    public class ConnectContext : DbContext
    {
        // Tabelas principais
        public DbSet<PT_EFLUENTE> PT_EFLUENTE { get; set; }
        public DbSet<RT_EFLUENTE> RT_EFLUENTE { get; set; }

        // Domínios GEA
        public DbSet<TB_MUNICIPIO> TB_MUNICIPIO { get; set; }
        public DbSet<TB_LINHA_CPTM> TB_LINHA_CPTM { get; set; }
        public DbSet<TB_VIA_CPTM> TB_VIA_CPTM { get; set; }
        public DbSet<TB_STATUS_DESVIO_AMBIENTAL> TB_STATUS_DESVIO_AMBIENTAL { get; set; }
        public DbSet<TB_STATUS_REGISTRO> TB_STATUS_REGISTRO { get; set; }
        public DbSet<TB_DEPTO_MEIO_AMBIENTE> TB_DEPTO_MEIO_AMBIENTE { get; set; }
        public DbSet<TB_TRECHO_SENTIDO> TB_TRECHO_SENTIDO { get; set; }
        public DbSet<TB_ESTACAO_CPTM> TB_ESTACAO_CPTM { get; set; }
        public DbSet<TB_NATUREZA_PGA> TB_NATUREZA_PGA { get; set; }
        public DbSet<TB_AREA_GESTORA_CPTM> TB_AREA_GESTORA_CPTM { get; set; }
        public DbSet<TB_PROPRIETARIO> TB_PROPRIETARIO { get; set; }
        public DbSet<TB_SIM_NAO> TB_SIM_NAO { get; set; }

        // Domínios EF (Efluentes)
        public DbSet<TB_TIPO_ATIVIDADE> TB_TIPO_ATIVIDADE { get; set; }
        public DbSet<TB_TIPO_DRA> TB_TIPO_DRA { get; set; }
        public DbSet<TB_TIPO_ATIV_CPTM> TB_TIPO_ATIV_CPTM { get; set; }
        public DbSet<TB_LOCAL_ATIVIDADE> TB_LOCAL_ATIVIDADE { get; set; }
        public DbSet<TB_ORIGEM_EFLUENTE> TB_ORIGEM_EFLUENTE { get; set; }
        public DbSet<TB_FONTE_GERADORA> TB_FONTE_GERADORA { get; set; }
        public DbSet<TB_TIPO_DESTINACAO> TB_TIPO_DESTINACAO { get; set; }
        public DbSet<TB_TIPO_VEICULO> TB_TIPO_VEICULO { get; set; }

        // Sistema
        public DbSet<TB_PERFIL_USUARIO> TB_PERFIL_USUARIO { get; set; }
        public DbSet<TB_USUARIO> TB_USUARIO { get; set; }
        public DbSet<TB_LOG_ACAO> TB_LOG_ACAO { get; set; }
        public DbSet<TB_LOG_SINCRONIZACAO> TB_LOG_SINCRONIZACAO { get; set; }

        public ConnectContext(DbContextOptions<ConnectContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseOracle("Data Source=CPTM;User Id=cptm;Password=cptm;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Precisão das coordenadas geográficas
            modelBuilder.Entity<PT_EFLUENTE>()
                .Property(x => x.nrLatGrauDecimalWgs84)
                .HasPrecision(18, 8);

            modelBuilder.Entity<PT_EFLUENTE>()
                .Property(x => x.nrLongGrauDecimalWgs84)
                .HasPrecision(18, 8);

            modelBuilder.Entity<PT_EFLUENTE>()
                .Property(x => x.nrLatMetrosSirgas2000)
                .HasPrecision(18, 3);

            modelBuilder.Entity<PT_EFLUENTE>()
                .Property(x => x.nrLongMetrosSirgas2000)
                .HasPrecision(18, 3);

            modelBuilder.Entity<PT_EFLUENTE>()
                .Property(x => x.nrQuantidadeL)
                .HasPrecision(18, 8);

            modelBuilder.Entity<PT_EFLUENTE>()
                .Property(x => x.nrDistanciaDaViaM)
                .HasPrecision(10, 2);

            // =====================================================================
            // SEEDS - Perfil de Usuário
            // =====================================================================
            modelBuilder.Entity<TB_PERFIL_USUARIO>().HasData(
                new TB_PERFIL_USUARIO(1, "ADMINISTRADOR"),
                new TB_PERFIL_USUARIO(2, "USUARIO_CAMPO")
            );

            // =====================================================================
            // SEEDS - GEA_TX_SIGLA_DEPTO_MEIO_AMBIENTE → TB_DEPTO_MEIO_AMBIENTE
            // =====================================================================
            modelBuilder.Entity<TB_DEPTO_MEIO_AMBIENTE>().HasData(
                new TB_DEPTO_MEIO_AMBIENTE(1, "GEA"),
                new TB_DEPTO_MEIO_AMBIENTE(2, "GEA.DEAE"),
                new TB_DEPTO_MEIO_AMBIENTE(3, "GEA.DEAO"),
                new TB_DEPTO_MEIO_AMBIENTE(4, "Não se aplica(m)"),
                new TB_DEPTO_MEIO_AMBIENTE(5, "Inexistente(s)"),
                new TB_DEPTO_MEIO_AMBIENTE(6, "Indefinido(a)(s)"),
                new TB_DEPTO_MEIO_AMBIENTE(7, "Não avaliado(a)(s)")
            );

            // =====================================================================
            // SEEDS - GEA_TX_STATUS_DO_DESVIO_AMBIENTAL → TB_STATUS_DESVIO_AMBIENTAL
            // =====================================================================
            modelBuilder.Entity<TB_STATUS_DESVIO_AMBIENTAL>().HasData(
                new TB_STATUS_DESVIO_AMBIENTAL(1, "Não Regularizado"),
                new TB_STATUS_DESVIO_AMBIENTAL(2, "Regularizado"),
                new TB_STATUS_DESVIO_AMBIENTAL(3, "Não se aplica(m)"),
                new TB_STATUS_DESVIO_AMBIENTAL(4, "Inexistente(s)"),
                new TB_STATUS_DESVIO_AMBIENTAL(5, "Indefinido(a)(s)"),
                new TB_STATUS_DESVIO_AMBIENTAL(6, "Não avaliado(a)(s)")
            );

            // =====================================================================
            // SEEDS - GEA_TX_STATUS_DO_REGISTRO_NO_BD → TB_STATUS_REGISTRO
            // =====================================================================
            modelBuilder.Entity<TB_STATUS_REGISTRO>().HasData(
                new TB_STATUS_REGISTRO(1, "Ativo"),
                new TB_STATUS_REGISTRO(2, "Inativo"),
                new TB_STATUS_REGISTRO(3, "Não se aplica(m)"),
                new TB_STATUS_REGISTRO(4, "Inexistente(s)"),
                new TB_STATUS_REGISTRO(5, "Indefinido(a)(s)"),
                new TB_STATUS_REGISTRO(6, "Não avaliado(a)(s)")
            );

            // =====================================================================
            // SEEDS - GEA_TX_MUNICIPIO → TB_MUNICIPIO
            // =====================================================================
            modelBuilder.Entity<TB_MUNICIPIO>().HasData(
                new TB_MUNICIPIO(1, "Arujá"),
                new TB_MUNICIPIO(2, "Barueri"),
                new TB_MUNICIPIO(3, "Biritiba-Mirim"),
                new TB_MUNICIPIO(4, "Caieiras"),
                new TB_MUNICIPIO(5, "Cajamar"),
                new TB_MUNICIPIO(6, "Campo Limpo Paulista"),
                new TB_MUNICIPIO(7, "Carapicuíba"),
                new TB_MUNICIPIO(8, "Cotia"),
                new TB_MUNICIPIO(9, "Diadema"),
                new TB_MUNICIPIO(10, "Embu"),
                new TB_MUNICIPIO(11, "Embu-Guaçu"),
                new TB_MUNICIPIO(12, "Ferraz de Vasconcelos"),
                new TB_MUNICIPIO(13, "Francisco Morato"),
                new TB_MUNICIPIO(14, "Franco da Rocha"),
                new TB_MUNICIPIO(15, "Guararema"),
                new TB_MUNICIPIO(16, "Guarulhos"),
                new TB_MUNICIPIO(17, "Itapecerica da Serra"),
                new TB_MUNICIPIO(18, "Itapevi"),
                new TB_MUNICIPIO(19, "Itaquaquecetuba"),
                new TB_MUNICIPIO(20, "Jandira"),
                new TB_MUNICIPIO(21, "Jundiaí"),
                new TB_MUNICIPIO(22, "Juqutiba"),
                new TB_MUNICIPIO(23, "Mairinque"),
                new TB_MUNICIPIO(24, "Mairiporã"),
                new TB_MUNICIPIO(25, "Mauá"),
                new TB_MUNICIPIO(26, "Mogi das Cruzes"),
                new TB_MUNICIPIO(27, "Osasco"),
                new TB_MUNICIPIO(28, "Pirapora do Bom Jesus"),
                new TB_MUNICIPIO(29, "Poá"),
                new TB_MUNICIPIO(30, "Ribeirão Pires"),
                new TB_MUNICIPIO(31, "Rio Grande da Serra"),
                new TB_MUNICIPIO(32, "Salesópolis"),
                new TB_MUNICIPIO(33, "Santa Isabel"),
                new TB_MUNICIPIO(34, "Santana de Parnaíba"),
                new TB_MUNICIPIO(35, "Santo André"),
                new TB_MUNICIPIO(36, "Santos"),
                new TB_MUNICIPIO(37, "São Bernardo do Campo"),
                new TB_MUNICIPIO(38, "São Caetano do Sul"),
                new TB_MUNICIPIO(39, "São Lourenço da Serra"),
                new TB_MUNICIPIO(40, "São Paulo"),
                new TB_MUNICIPIO(41, "São Roque"),
                new TB_MUNICIPIO(42, "São Vicente"),
                new TB_MUNICIPIO(43, "Suzano"),
                new TB_MUNICIPIO(44, "Taboão da Serra"),
                new TB_MUNICIPIO(45, "Vargem Grande Paulista"),
                new TB_MUNICIPIO(46, "Várzea Paulista"),
                new TB_MUNICIPIO(47, "Diversos (Ver Observação)"),
                new TB_MUNICIPIO(48, "Não se aplica(m)"),
                new TB_MUNICIPIO(49, "Inexistente(s)"),
                new TB_MUNICIPIO(50, "Indefinido(a)(s)"),
                new TB_MUNICIPIO(51, "Não avaliado(a)(s)")
            );

            // =====================================================================
            // SEEDS - GEA_TX_LINHA_CPTM → TB_LINHA_CPTM
            // =====================================================================
            modelBuilder.Entity<TB_LINHA_CPTM>().HasData(
                new TB_LINHA_CPTM(1, "Linha 07 - Rubi"),
                new TB_LINHA_CPTM(2, "Linha 08 - Diamante"),
                new TB_LINHA_CPTM(3, "Linha 09 - Esmeralda"),
                new TB_LINHA_CPTM(4, "Linha 10 - Turquesa"),
                new TB_LINHA_CPTM(5, "Linha 11 - Coral"),
                new TB_LINHA_CPTM(6, "Linha 12 - Safira"),
                new TB_LINHA_CPTM(7, "Linha 13 - Jade"),
                new TB_LINHA_CPTM(8, "Linha 05 - Lilás"),
                new TB_LINHA_CPTM(9, "Linha JJ - Baixada Santista"),
                new TB_LINHA_CPTM(10, "Sem linha associada"),
                new TB_LINHA_CPTM(11, "Linha não informada"),
                new TB_LINHA_CPTM(12, "Não se aplica(m)"),
                new TB_LINHA_CPTM(13, "Inexistente(s)"),
                new TB_LINHA_CPTM(14, "Indefinido(a)(s)"),
                new TB_LINHA_CPTM(15, "Não avaliado(a)(s)")
            );

            // =====================================================================
            // SEEDS - GEA_TX_VIA_CPTM → TB_VIA_CPTM
            // =====================================================================
            modelBuilder.Entity<TB_VIA_CPTM>().HasData(
                new TB_VIA_CPTM(1, "Via 01"),
                new TB_VIA_CPTM(2, "Via 02"),
                new TB_VIA_CPTM(3, "Via 03"),
                new TB_VIA_CPTM(4, "Via 04"),
                new TB_VIA_CPTM(5, "Via 05"),
                new TB_VIA_CPTM(6, "Via 06"),
                new TB_VIA_CPTM(7, "Via 08"),
                new TB_VIA_CPTM(8, "Via 09"),
                new TB_VIA_CPTM(9, "Via 10"),
                new TB_VIA_CPTM(10, "Via 01S - Trecho 1"),
                new TB_VIA_CPTM(11, "Via 01S - Trecho 2"),
                new TB_VIA_CPTM(12, "Via 02S - Trecho 1"),
                new TB_VIA_CPTM(13, "Via 02S - Trecho 2"),
                new TB_VIA_CPTM(14, "Via 03S - Trecho 2"),
                new TB_VIA_CPTM(15, "Via 03E - Trecho 2"),
                new TB_VIA_CPTM(16, "Via 04E - Trecho 2"),
                new TB_VIA_CPTM(17, "Via Auxiliar"),
                new TB_VIA_CPTM(18, "Via Variante"),
                new TB_VIA_CPTM(19, "Travessão - AMV"),
                new TB_VIA_CPTM(20, "Não se aplica(m)"),
                new TB_VIA_CPTM(21, "Inexistente(s)"),
                new TB_VIA_CPTM(22, "Indefinido(a)(s)"),
                new TB_VIA_CPTM(23, "Não avaliado(a)(s)")
            );

            // =====================================================================
            // SEEDS - GEA_TX_TRECHO_E_SENTIDO_CPTM → TB_TRECHO_SENTIDO (representativo)
            // =====================================================================
            modelBuilder.Entity<TB_TRECHO_SENTIDO>().HasData(
                new TB_TRECHO_SENTIDO(1, "Estação Aeroporto Guarulhos - Estação Guarulhos - Cecap"),
                new TB_TRECHO_SENTIDO(2, "Estação Água Branca - Estação Lapa"),
                new TB_TRECHO_SENTIDO(3, "Estação Barra Funda - Estação Luz"),
                new TB_TRECHO_SENTIDO(4, "Estação Caieiras - Estação Franco da Rocha"),
                new TB_TRECHO_SENTIDO(5, "Estação Campo Limpo Paulista - Estação Botujuru"),
                new TB_TRECHO_SENTIDO(6, "Estação Corinthians - Itaquera - Estação Tatuapé"),
                new TB_TRECHO_SENTIDO(7, "Estação Francisco Morato - Estação Baltazar Fidelis"),
                new TB_TRECHO_SENTIDO(8, "Estação Guarulhos - Cecap - Estação Engenheiro Goulart"),
                new TB_TRECHO_SENTIDO(9, "Estação Ipiranga - Estação Tamanduateí"),
                new TB_TRECHO_SENTIDO(10, "Estação Jundiapeba - Estação Suzano"),
                new TB_TRECHO_SENTIDO(11, "Estação Lapa (Linha 07) - Estação Água Branca"),
                new TB_TRECHO_SENTIDO(12, "Estação Luz - Estação Barra Funda"),
                new TB_TRECHO_SENTIDO(13, "Estação Mogi das Cruzes - Estação Estudantes"),
                new TB_TRECHO_SENTIDO(14, "Estação Palmeiras - Barra Funda - Estação Água Branca"),
                new TB_TRECHO_SENTIDO(15, "Estação Perus - Estação Caieiras"),
                new TB_TRECHO_SENTIDO(16, "Estação Pirituba - Estação Vila Clarisse"),
                new TB_TRECHO_SENTIDO(17, "Estação Ribeirão Pires - Estação Rio Grande da Serra"),
                new TB_TRECHO_SENTIDO(18, "Estação Roosevelt/Brás - Estação Luz"),
                new TB_TRECHO_SENTIDO(19, "Estação Santo André - Estação Capuava"),
                new TB_TRECHO_SENTIDO(20, "Estação Suzano - Estação Calmon Viana"),
                new TB_TRECHO_SENTIDO(21, "Estação Tatuapé - Estação Engenheiro Goulart"),
                new TB_TRECHO_SENTIDO(22, "Estação Várzea Paulista - Estação Jundiaí"),
                new TB_TRECHO_SENTIDO(23, "Final dos Trilhos - Estação Estudantes"),
                new TB_TRECHO_SENTIDO(24, "Não se aplica(m)"),
                new TB_TRECHO_SENTIDO(25, "Inexistente(s)"),
                new TB_TRECHO_SENTIDO(26, "Indefinido(a)(s)"),
                new TB_TRECHO_SENTIDO(27, "Não avaliado(a)(s)")
            );

            // =====================================================================
            // SEEDS - GEA_TX_ESTACAO_CPTM → TB_ESTACAO_CPTM (representativo)
            // =====================================================================
            modelBuilder.Entity<TB_ESTACAO_CPTM>().HasData(
                new TB_ESTACAO_CPTM(1, "Estação Aeroporto Guarulhos"),
                new TB_ESTACAO_CPTM(2, "Estação Água Branca"),
                new TB_ESTACAO_CPTM(3, "Estação Aracaré"),
                new TB_ESTACAO_CPTM(4, "Estação Baltazar Fidelis"),
                new TB_ESTACAO_CPTM(5, "Estação Barueri"),
                new TB_ESTACAO_CPTM(6, "Estação Botujuru"),
                new TB_ESTACAO_CPTM(7, "Estação Brás"),
                new TB_ESTACAO_CPTM(8, "Estação Brás Cubas"),
                new TB_ESTACAO_CPTM(9, "Estação Caieiras"),
                new TB_ESTACAO_CPTM(10, "Estação Calmon Viana"),
                new TB_ESTACAO_CPTM(11, "Estação Campo Limpo Paulista"),
                new TB_ESTACAO_CPTM(12, "Estação Capuava"),
                new TB_ESTACAO_CPTM(13, "Estação Carapicuíba"),
                new TB_ESTACAO_CPTM(14, "Estação Corinthians - Itaquera"),
                new TB_ESTACAO_CPTM(15, "Estação Dom Bosco"),
                new TB_ESTACAO_CPTM(16, "Estação Engenheiro Goulart"),
                new TB_ESTACAO_CPTM(17, "Estação Engenheiro Manoel Feio"),
                new TB_ESTACAO_CPTM(18, "Estação Estudantes"),
                new TB_ESTACAO_CPTM(19, "Estação Ferraz de Vasconcelos"),
                new TB_ESTACAO_CPTM(20, "Estação Francisco Morato"),
                new TB_ESTACAO_CPTM(21, "Estação Franco da Rocha"),
                new TB_ESTACAO_CPTM(22, "Estação Guaianazes"),
                new TB_ESTACAO_CPTM(23, "Estação Guarulhos Cecap"),
                new TB_ESTACAO_CPTM(24, "Estação Ipiranga"),
                new TB_ESTACAO_CPTM(25, "Estação Itapevi"),
                new TB_ESTACAO_CPTM(26, "Estação Itaquaquecetuba"),
                new TB_ESTACAO_CPTM(27, "Estação Jandira"),
                new TB_ESTACAO_CPTM(28, "Estação Jardim Romano"),
                new TB_ESTACAO_CPTM(29, "Estação José Bonifácio"),
                new TB_ESTACAO_CPTM(30, "Estação Jundiaí"),
                new TB_ESTACAO_CPTM(31, "Estação Jundiapeba"),
                new TB_ESTACAO_CPTM(32, "Estação Lapa (Linha 7)"),
                new TB_ESTACAO_CPTM(33, "Estação Lapa (Linha 8)"),
                new TB_ESTACAO_CPTM(34, "Estação Luz"),
                new TB_ESTACAO_CPTM(35, "Estação Mauá"),
                new TB_ESTACAO_CPTM(36, "Estação Mogi das Cruzes"),
                new TB_ESTACAO_CPTM(37, "Estação Osasco"),
                new TB_ESTACAO_CPTM(38, "Estação Palmeiras - Barra Funda"),
                new TB_ESTACAO_CPTM(39, "Estação Perus"),
                new TB_ESTACAO_CPTM(40, "Estação Piqueri"),
                new TB_ESTACAO_CPTM(41, "Estação Pirituba"),
                new TB_ESTACAO_CPTM(42, "Estação Poá"),
                new TB_ESTACAO_CPTM(43, "Estação Prefeito Celso Daniel - Santo André"),
                new TB_ESTACAO_CPTM(44, "Estação Ribeirão Pires"),
                new TB_ESTACAO_CPTM(45, "Estação Rio Grande da Serra"),
                new TB_ESTACAO_CPTM(46, "Estação Roosevelt/Brás"),
                new TB_ESTACAO_CPTM(47, "Estação Santo André"),
                new TB_ESTACAO_CPTM(48, "Estação São Caetano"),
                new TB_ESTACAO_CPTM(49, "Estação São Miguel Paulista"),
                new TB_ESTACAO_CPTM(50, "Estação Suzano"),
                new TB_ESTACAO_CPTM(51, "Estação Tamanduateí"),
                new TB_ESTACAO_CPTM(52, "Estação Tatuapé"),
                new TB_ESTACAO_CPTM(53, "Estação USP Leste"),
                new TB_ESTACAO_CPTM(54, "Estação Utinga"),
                new TB_ESTACAO_CPTM(55, "Estação Várzea Paulista"),
                new TB_ESTACAO_CPTM(56, "Estação Vila Aurora"),
                new TB_ESTACAO_CPTM(57, "Estação Vila Clarisse"),
                new TB_ESTACAO_CPTM(58, "Não se aplica(m)"),
                new TB_ESTACAO_CPTM(59, "Inexistente(s)"),
                new TB_ESTACAO_CPTM(60, "Indefinido(a)(s)"),
                new TB_ESTACAO_CPTM(61, "Não avaliado(a)(s)")
            );

            // =====================================================================
            // SEEDS - GEA_TX_NATUREZA_DO_PGA → TB_NATUREZA_PGA
            // =====================================================================
            modelBuilder.Entity<TB_NATUREZA_PGA>().HasData(
                new TB_NATUREZA_PGA(1, "Áreas Ambientalmente Protegidas"),
                new TB_NATUREZA_PGA(2, "Áreas Contaminadas"),
                new TB_NATUREZA_PGA(3, "Arqueologia"),
                new TB_NATUREZA_PGA(4, "Comunicação Social"),
                new TB_NATUREZA_PGA(5, "Documentação"),
                new TB_NATUREZA_PGA(6, "Efluente"),
                new TB_NATUREZA_PGA(7, "Emissões Atmosféricas"),
                new TB_NATUREZA_PGA(8, "Erosões e Movimentos de Massa"),
                new TB_NATUREZA_PGA(9, "Fauna"),
                new TB_NATUREZA_PGA(10, "Gerenciamento de Solo"),
                new TB_NATUREZA_PGA(11, "Lançamentos Irregulares"),
                new TB_NATUREZA_PGA(12, "Patrimônio Histórico"),
                new TB_NATUREZA_PGA(13, "Produtos Perigosos"),
                new TB_NATUREZA_PGA(14, "Recursos Hídricos"),
                new TB_NATUREZA_PGA(15, "Resíduos Sólidos"),
                new TB_NATUREZA_PGA(16, "Ruído e Vibração"),
                new TB_NATUREZA_PGA(17, "Segmentação Urbana"),
                new TB_NATUREZA_PGA(18, "Sinalização e Isolamento"),
                new TB_NATUREZA_PGA(19, "Sistema de Drenagem, Inundações e Alagamentos"),
                new TB_NATUREZA_PGA(20, "Vegetação"),
                new TB_NATUREZA_PGA(21, "Não se aplica(m)"),
                new TB_NATUREZA_PGA(22, "Inexistente(s)"),
                new TB_NATUREZA_PGA(23, "Indefinido(a)(s)"),
                new TB_NATUREZA_PGA(24, "Não avaliado(a)(s)")
            );

            // =====================================================================
            // SEEDS - GEA_TX_PROPRIETARIO → TB_PROPRIETARIO
            // =====================================================================
            modelBuilder.Entity<TB_PROPRIETARIO>().HasData(
                new TB_PROPRIETARIO(1, "CPTM - Titularidade"),
                new TB_PROPRIETARIO(2, "CPTM - Posse"),
                new TB_PROPRIETARIO(3, "Metrô"),
                new TB_PROPRIETARIO(4, "Alienado"),
                new TB_PROPRIETARIO(5, "MRS"),
                new TB_PROPRIETARIO(6, "RFSA"),
                new TB_PROPRIETARIO(7, "RFSA/SPU"),
                new TB_PROPRIETARIO(8, "CBTU"),
                new TB_PROPRIETARIO(9, "Pessoa Jurídica"),
                new TB_PROPRIETARIO(10, "Pessoa Física"),
                new TB_PROPRIETARIO(11, "Indefinido"),
                new TB_PROPRIETARIO(12, "FEPASA"),
                new TB_PROPRIETARIO(13, "Permuta"),
                new TB_PROPRIETARIO(14, "Prefeitura de Guarulhos"),
                new TB_PROPRIETARIO(15, "DAEE"),
                new TB_PROPRIETARIO(16, "USP Leste"),
                new TB_PROPRIETARIO(17, "GRU - Aeroporto"),
                new TB_PROPRIETARIO(18, "CCR - Rodovia Dutra"),
                new TB_PROPRIETARIO(19, "Ecopistas"),
                new TB_PROPRIETARIO(20, "CDHU"),
                new TB_PROPRIETARIO(21, "Não se aplica(m)"),
                new TB_PROPRIETARIO(22, "Inexistente(s)"),
                new TB_PROPRIETARIO(23, "Não avaliado(a)(s)")
            );

            // =====================================================================
            // SEEDS - GEA_SIM_NAO → TB_SIM_NAO
            // =====================================================================
            modelBuilder.Entity<TB_SIM_NAO>().HasData(
                new TB_SIM_NAO(1, "Sim"),
                new TB_SIM_NAO(2, "Não"),
                new TB_SIM_NAO(3, "Não Informado"),
                new TB_SIM_NAO(4, "Não se aplica(m)"),
                new TB_SIM_NAO(5, "Inexistente(s)"),
                new TB_SIM_NAO(6, "Indefinido(a)(s)"),
                new TB_SIM_NAO(7, "Não avaliado(a)(s)")
            );

            // =====================================================================
            // SEEDS - EF_TX_TIPO_ATIVIDADE_LISTADA → TB_TIPO_ATIVIDADE
            // =====================================================================
            modelBuilder.Entity<TB_TIPO_ATIVIDADE>().HasData(
                new TB_TIPO_ATIVIDADE(1, "Estação de Tratamento de Efluente"),
                new TB_TIPO_ATIVIDADE(2, "Transporte"),
                new TB_TIPO_ATIVIDADE(3, "Outro(a)(s)"),
                new TB_TIPO_ATIVIDADE(4, "Indefinido(a)(s)"),
                new TB_TIPO_ATIVIDADE(5, "Não se aplica(m)"),
                new TB_TIPO_ATIVIDADE(6, "Inexistente(s)"),
                new TB_TIPO_ATIVIDADE(7, "Não avaliado(a)(s)")
            );

            // =====================================================================
            // SEEDS - EF_TX_TIPO_DRA_LISTADO → TB_TIPO_DRA
            // =====================================================================
            modelBuilder.Entity<TB_TIPO_DRA>().HasData(
                new TB_TIPO_DRA(1, "Cadastro Técnico Federal (IBAMA) - CTF/IBAMA"),
                new TB_TIPO_DRA(2, "Certificado de Dispensa de Licença - CDL"),
                new TB_TIPO_DRA(3, "Certificado de Movimentação de Resíduos de Interesse Ambiental - CADRI"),
                new TB_TIPO_DRA(4, "Declaração de Movimentação de Resíduos - DMR"),
                new TB_TIPO_DRA(5, "Ficha de Informações de Segurança de Produtos Químicos - FISPQ"),
                new TB_TIPO_DRA(6, "Licença de Operação - LO"),
                new TB_TIPO_DRA(7, "Manifesto de Transporte de Resíduos - MTR"),
                new TB_TIPO_DRA(8, "Outro(a)(s)"),
                new TB_TIPO_DRA(9, "Indefinido(a)(s)"),
                new TB_TIPO_DRA(10, "Não se aplica(m)"),
                new TB_TIPO_DRA(11, "Inexistente(s)"),
                new TB_TIPO_DRA(12, "Não avaliado(a)(s)")
            );

            // =====================================================================
            // SEEDS - EF_TX_TIPO_ATIVIDADE_CPTM → TB_TIPO_ATIV_CPTM
            // =====================================================================
            modelBuilder.Entity<TB_TIPO_ATIV_CPTM>().HasData(
                new TB_TIPO_ATIV_CPTM(1, "Empreendimento/Obra"),
                new TB_TIPO_ATIV_CPTM(2, "Manutenção"),
                new TB_TIPO_ATIV_CPTM(3, "Operação"),
                new TB_TIPO_ATIV_CPTM(4, "Outro(a)(s)"),
                new TB_TIPO_ATIV_CPTM(5, "Indefinido(a)(s)"),
                new TB_TIPO_ATIV_CPTM(6, "Não se aplica(m)"),
                new TB_TIPO_ATIV_CPTM(7, "Inexistente(s)"),
                new TB_TIPO_ATIV_CPTM(8, "Não avaliado(a)(s)")
            );

            // =====================================================================
            // SEEDS - EF_TX_NM_LOCAL_ATIV → TB_LOCAL_ATIVIDADE
            // =====================================================================
            modelBuilder.Entity<TB_LOCAL_ATIVIDADE>().HasData(
                new TB_LOCAL_ATIVIDADE(1, "Abrigo"),
                new TB_LOCAL_ATIVIDADE(2, "Base de manutenção"),
                new TB_LOCAL_ATIVIDADE(3, "Cabine Primária"),
                new TB_LOCAL_ATIVIDADE(4, "Cabine Seccionadora"),
                new TB_LOCAL_ATIVIDADE(5, "Estação"),
                new TB_LOCAL_ATIVIDADE(6, "Lavador de TUE"),
                new TB_LOCAL_ATIVIDADE(7, "Oficina"),
                new TB_LOCAL_ATIVIDADE(8, "Pátio"),
                new TB_LOCAL_ATIVIDADE(9, "Prédio administrativo"),
                new TB_LOCAL_ATIVIDADE(10, "Prédio de apoio"),
                new TB_LOCAL_ATIVIDADE(11, "Sala técnica"),
                new TB_LOCAL_ATIVIDADE(12, "Subestação"),
                new TB_LOCAL_ATIVIDADE(13, "Trecho - Km/poste"),
                new TB_LOCAL_ATIVIDADE(14, "Vários"),
                new TB_LOCAL_ATIVIDADE(15, "Outro(a)(s)"),
                new TB_LOCAL_ATIVIDADE(16, "Indefinido(a)(s)"),
                new TB_LOCAL_ATIVIDADE(17, "Não se aplica(m)"),
                new TB_LOCAL_ATIVIDADE(18, "Inexistente(s)"),
                new TB_LOCAL_ATIVIDADE(19, "Não avaliado(a)(s)")
            );

            // =====================================================================
            // SEEDS - EF_TX_ORIGEM_EFLUENTE → TB_ORIGEM_EFLUENTE
            // =====================================================================
            modelBuilder.Entity<TB_ORIGEM_EFLUENTE>().HasData(
                new TB_ORIGEM_EFLUENTE(1, "Doméstico/Sanitário"),
                new TB_ORIGEM_EFLUENTE(2, "Fundação"),
                new TB_ORIGEM_EFLUENTE(3, "Industrial"),
                new TB_ORIGEM_EFLUENTE(4, "Outro(a)(s)"),
                new TB_ORIGEM_EFLUENTE(5, "Indefinido(a)(s)"),
                new TB_ORIGEM_EFLUENTE(6, "Não se aplica(m)"),
                new TB_ORIGEM_EFLUENTE(7, "Inexistente(s)"),
                new TB_ORIGEM_EFLUENTE(8, "Não avaliado(a)(s)")
            );

            // =====================================================================
            // SEEDS - EF_TX_FONTE_GERADORA → TB_FONTE_GERADORA
            // =====================================================================
            modelBuilder.Entity<TB_FONTE_GERADORA>().HasData(
                new TB_FONTE_GERADORA(1, "Atividade de obra"),
                new TB_FONTE_GERADORA(2, "Banheiro químico"),
                new TB_FONTE_GERADORA(3, "Banheiros/vestiários/refeitórios"),
                new TB_FONTE_GERADORA(4, "Fossa séptica"),
                new TB_FONTE_GERADORA(5, "Lavagem de trens/peças"),
                new TB_FONTE_GERADORA(6, "Manutenção ETE"),
                new TB_FONTE_GERADORA(7, "Valas de manutenção"),
                new TB_FONTE_GERADORA(8, "Outro(a)(s)"),
                new TB_FONTE_GERADORA(9, "Indefinido(a)(s)"),
                new TB_FONTE_GERADORA(10, "Não se aplica(m)"),
                new TB_FONTE_GERADORA(11, "Inexistente(s)"),
                new TB_FONTE_GERADORA(12, "Não avaliado(a)(s)")
            );

            // =====================================================================
            // SEEDS - EF_TX_TIPO_DESTINACAO → TB_TIPO_DESTINACAO
            // =====================================================================
            modelBuilder.Entity<TB_TIPO_DESTINACAO>().HasData(
                new TB_TIPO_DESTINACAO(1, "Esgotamento e transporte"),
                new TB_TIPO_DESTINACAO(2, "Interligação em rede coletora"),
                new TB_TIPO_DESTINACAO(3, "Lançamento em galeria de águas pluviais"),
                new TB_TIPO_DESTINACAO(4, "Reinfiltração"),
                new TB_TIPO_DESTINACAO(5, "Tratamento em ETE"),
                new TB_TIPO_DESTINACAO(6, "Outro(a)(s)"),
                new TB_TIPO_DESTINACAO(7, "Indefinido(a)(s)"),
                new TB_TIPO_DESTINACAO(8, "Não se aplica(m)"),
                new TB_TIPO_DESTINACAO(9, "Inexistente(s)"),
                new TB_TIPO_DESTINACAO(10, "Não avaliado(a)(s)")
            );

            // =====================================================================
            // SEEDS - EF_TX_TIPO_VEICULO → TB_TIPO_VEICULO
            // =====================================================================
            modelBuilder.Entity<TB_TIPO_VEICULO>().HasData(
                new TB_TIPO_VEICULO(1, "Caminhão"),
                new TB_TIPO_VEICULO(2, "Outro(a)(s)"),
                new TB_TIPO_VEICULO(3, "Indefinido(a)(s)"),
                new TB_TIPO_VEICULO(4, "Não se aplica(m)"),
                new TB_TIPO_VEICULO(5, "Inexistente(s)"),
                new TB_TIPO_VEICULO(6, "Não avaliado(a)(s)")
            );

            // =====================================================================
            // SEEDS - GEA_TX_AREA_GESTORA_CPTM → TB_AREA_GESTORA_CPTM (principais)
            // =====================================================================
            modelBuilder.Entity<TB_AREA_GESTORA_CPTM>().HasData(
                new TB_AREA_GESTORA_CPTM(1, "(DE.GEA.0000) GERENCIA DE MEIO AMBIENTE [ID.10-14-4-0-0000]"),
                new TB_AREA_GESTORA_CPTM(2, "(DE.GEA.DEAE.0000) DEPTO. DE MEIO AMBIENTE - EMPREENDIMENTOS [ID.10-14-4-1-0000]"),
                new TB_AREA_GESTORA_CPTM(3, "(DE.GEA.DEAO.0000) DEPTO. DE MEIO AMBIENTE - OPERACAO [ID.10-14-4-2-0000]"),
                new TB_AREA_GESTORA_CPTM(4, "(DE.GEF.0000) GERENCIA DE EMPREENDIMENTOS [ID.10-14-6-0-0000]"),
                new TB_AREA_GESTORA_CPTM(5, "(DE.GEP.0000) GERENCIA DE PROJETOS [ID.10-14-1-0-0000]"),
                new TB_AREA_GESTORA_CPTM(6, "(DO.GOF.0000) GERENCIA DE MANUT. DE EQUIPAMENTOS FIXOS [ID.10-15-5-0-0000]"),
                new TB_AREA_GESTORA_CPTM(7, "(DO.GOV.0000) GERENCIA DE MANUT. DE VIA PERMANENTE E ESTRUTURA CIVIL [ID.10-15-6-0-0000]"),
                new TB_AREA_GESTORA_CPTM(8, "(DO.GOR.0000) GERENCIA MANUT. MAT RODANTE E OFICINAS [ID.10-15-3-0-0000]"),
                new TB_AREA_GESTORA_CPTM(9, "(DO.GOO.0000) GERENCIA GERAL DE OPERACAO [ID.10-16-1-0-0000]"),
                new TB_AREA_GESTORA_CPTM(10, "(DP.GPN.0000) GERENCIA DE NOVOS NEGOCIOS [ID.10-13-4-0-0000]"),
                new TB_AREA_GESTORA_CPTM(11, "Não se aplica(m)"),
                new TB_AREA_GESTORA_CPTM(12, "Inexistente(s)"),
                new TB_AREA_GESTORA_CPTM(13, "Indefinido(a)(s)"),
                new TB_AREA_GESTORA_CPTM(14, "Não avaliado(a)(s)")
            );
        }
    }
}
