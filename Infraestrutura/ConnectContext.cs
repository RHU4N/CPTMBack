using Microsoft.EntityFrameworkCore;
using CPTMBack.Domain.Model.TblPrincipais.PT_EFLUENTEAggregate;
using CPTMBack.Domain.Model.TblPrincipais.RT_EFLUENTEAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_MUNICIPIOAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_LINHA_CPTMAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_VIA_CPTMAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_STATUS_DESVIO_AMBIENTALAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_STATUS_REGISTROAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_DEPTO_MEIO_AMBIENTEAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_TIPO_EFLUENTEAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_TRECHO_SENTIDOAggregate;
using CPTMBack.Domain.Model.TblDominio.TB_PERFIL_USUARIOAggregate;
using CPTMBack.Domain.Model.TblSistema.TB_USUARIOAggregate;
using CPTMBack.Domain.Model.TblSistema.TB_LOG_ACAOAggregate;
using CPTMBack.Domain.Model.TblSistema.TB_LOG_SINCRONIZACAOAggregate;

namespace CPTMBack.Infraestrutura
{
    public class ConnectContext : DbContext
    {
        public DbSet<PT_EFLUENTE> PT_EFLUENTE { get; set; }
        public DbSet<RT_EFLUENTE> RT_EFLUENTE { get; set; }
        public DbSet<TB_MUNICIPIO> TB_MUNICIPIO { get; set; }
        public DbSet<TB_LINHA_CPTM> TB_LINHA_CPTM { get; set; }
        public DbSet<TB_VIA_CPTM> TB_VIA_CPTM { get; set; }
        public DbSet<TB_STATUS_DESVIO_AMBIENTAL> TB_STATUS_DESVIO_AMBIENTAL { get; set; }
        public DbSet<TB_STATUS_REGISTRO> TB_STATUS_REGISTRO { get; set; }
        public DbSet<TB_DEPTO_MEIO_AMBIENTE> TB_DEPTO_MEIO_AMBIENTE { get; set; }
        public DbSet<TB_TIPO_EFLUENTE> TB_TIPO_EFLUENTE { get; set; }
        public DbSet<TB_TRECHO_SENTIDO> TB_TRECHO_SENTIDO { get; set; }
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

            // Configurar tipos decimais para PT_EFLUENTE
            modelBuilder.Entity<PT_EFLUENTE>()
                .Property(x => x.txCoordenadaX)
                .HasPrecision(18, 8);

            modelBuilder.Entity<PT_EFLUENTE>()
                .Property(x => x.txCoordenadaY)
                .HasPrecision(18, 8);

            modelBuilder.Entity<PT_EFLUENTE>()
                .Property(x => x.txVolumeEfluente)
                .HasPrecision(18, 2);

            modelBuilder.Entity<PT_EFLUENTE>()
                .Property(x => x.txPh)
                .HasPrecision(10, 2);

            modelBuilder.Entity<PT_EFLUENTE>()
                .Property(x => x.txTemperatura)
                .HasPrecision(10, 2);

            // Seed Data - TB_PERFIL_USUARIO
            modelBuilder.Entity<TB_PERFIL_USUARIO>().HasData(
                new TB_PERFIL_USUARIO(1, "ADMINISTRADOR"),
                new TB_PERFIL_USUARIO(2, "USUARIO_CAMPO")
            );

            // Seed Data - TB_STATUS_REGISTRO
            modelBuilder.Entity<TB_STATUS_REGISTRO>().HasData(
                new TB_STATUS_REGISTRO(1, "ATIVO"),
                new TB_STATUS_REGISTRO(2, "INATIVO"),
                new TB_STATUS_REGISTRO(3, "PENDENTE"),
                new TB_STATUS_REGISTRO(4, "SINCRONIZADO")
            );

            // Seed Data - TB_STATUS_DESVIO_AMBIENTAL
            modelBuilder.Entity<TB_STATUS_DESVIO_AMBIENTAL>().HasData(
                new TB_STATUS_DESVIO_AMBIENTAL(1, "ABERTO"),
                new TB_STATUS_DESVIO_AMBIENTAL(2, "EM_ANALISE"),
                new TB_STATUS_DESVIO_AMBIENTAL(3, "RESOLVIDO"),
                new TB_STATUS_DESVIO_AMBIENTAL(4, "CANCELADO")
            );

            // Seed Data - TB_VIA_CPTM
            modelBuilder.Entity<TB_VIA_CPTM>().HasData(
                new TB_VIA_CPTM(1, "VIA_1"),
                new TB_VIA_CPTM(2, "VIA_2")
            );

            // Seed Data - TB_LINHA_CPTM
            modelBuilder.Entity<TB_LINHA_CPTM>().HasData(
                new TB_LINHA_CPTM(1, "LINHA_7"),
                new TB_LINHA_CPTM(2, "LINHA_8"),
                new TB_LINHA_CPTM(3, "LINHA_9"),
                new TB_LINHA_CPTM(4, "LINHA_10"),
                new TB_LINHA_CPTM(5, "LINHA_11"),
                new TB_LINHA_CPTM(6, "LINHA_12"),
                new TB_LINHA_CPTM(7, "LINHA_13")
            );

            // Seed Data - TB_DEPTO_MEIO_AMBIENTE
            modelBuilder.Entity<TB_DEPTO_MEIO_AMBIENTE>().HasData(
                new TB_DEPTO_MEIO_AMBIENTE(1, "NORTE"),
                new TB_DEPTO_MEIO_AMBIENTE(2, "SUL"),
                new TB_DEPTO_MEIO_AMBIENTE(3, "LESTE"),
                new TB_DEPTO_MEIO_AMBIENTE(4, "OESTE")
            );

            // Seed Data - TB_TIPO_EFLUENTE
            modelBuilder.Entity<TB_TIPO_EFLUENTE>().HasData(
                new TB_TIPO_EFLUENTE(1, "ESGOTO"),
                new TB_TIPO_EFLUENTE(2, "OLEO"),
                new TB_TIPO_EFLUENTE(3, "QUIMICO"),
                new TB_TIPO_EFLUENTE(4, "INDUSTRIAL"),
                new TB_TIPO_EFLUENTE(5, "AGUA_CONTAMINADA")
            );
        }
    }
}
