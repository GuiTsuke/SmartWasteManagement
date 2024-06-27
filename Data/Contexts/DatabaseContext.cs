using Fiap.Web.SmartWasteManagement.Models;
using Fiap.Web.SmartWasteManagement.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Web.SmartWasteManagement.Data.Contexts
{
    public class DatabaseContext : DbContext
    {

        public DatabaseContext()
        {

        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        public virtual DbSet<CaminhaoModel> Caminhoes { get; set; }
        public virtual DbSet<MoradorModel> Moradores { get; set; }
        public virtual DbSet<NotificacaoModel> Notificacoes { get; set; }
        public virtual DbSet<RecipienteModel> Recipientes { get; set; }
        public virtual DbSet<RotaModel> Rotas { get; set; }
        public virtual DbSet<AgendamentoColetaModel> Agendamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CaminhaoModel>(entity =>
            {
                entity.ToTable("TBL_CAMINHOES");
                entity.HasKey(e => e.Codigo);
                entity.Property(e => e.Codigo).ValueGeneratedOnAdd().HasColumnName("CD_CAMINHAO");
                entity.Property(e => e.Placa).HasMaxLength(100).HasColumnName("DS_PLACA").IsRequired();
                entity.Property(e => e.CapacidadeCarga).HasColumnName("VL_CAPACIDADE_CARGA").IsRequired();
                entity.Property(e => e.Status).HasColumnName("CD_STATUS").IsRequired();
                entity.Property(e => e.LocalizacaoAtual).HasColumnName("DS_LOCALIZACAO_ATUAL");

            });

            modelBuilder.Entity<MoradorModel>(entity =>
            {
                entity.ToTable("TBL_MORADORES");
                entity.HasKey(e => e.Codigo);
                entity.Property(e => e.Codigo).ValueGeneratedOnAdd().HasColumnName("CD_MORADOR");
                entity.Property(e => e.Nome).IsRequired().HasMaxLength(100).HasColumnName("DS_NOME");
                entity.Property(e => e.Endereco).IsRequired().HasMaxLength(200).HasColumnName("DS_ENDERECO");
                entity.Property(e => e.Telefone).HasMaxLength(20).HasColumnName("DS_TELEFONE");
                entity.Property(e => e.Email).HasMaxLength(100).HasColumnName("DS_EMAIL");
            });

            modelBuilder.Entity<NotificacaoModel>(entity =>
            {
                entity.ToTable("TBL_NOTIFICACOES");
                entity.HasKey(e => e.Codigo);
                entity.Property(e => e.Codigo).ValueGeneratedOnAdd().HasColumnName("CD_NOTIFICACAO");
                entity.Property(e => e.DataEnvio).IsRequired().HasColumnName("DT_ENVIO");
                entity.Property(e => e.Tipo).IsRequired().HasMaxLength(50).HasColumnName("CD_STATUS_NOTIFICACAO");
                entity.Property(e => e.Leitura).IsRequired().HasMaxLength(20).HasColumnName("CD_STATUS_LEITURA");
                entity.Property(e => e.CodigoRecipiente).HasColumnName("CD_RECIPIENTE");
                entity.Property(e => e.CodigoMorador).HasColumnName("CD_MORADOR");

                entity.HasOne(e => e.Recipiente)
                      .WithMany(r => r.Notificacoes)
                      .HasForeignKey(e => e.CodigoRecipiente);

                entity.HasOne(e => e.Morador)
                      .WithMany(m => m.Notificacoes)
                      .HasForeignKey(e => e.CodigoMorador);
            });

            modelBuilder.Entity<RecipienteModel>(entity =>
            {
                entity.ToTable("TBL_RECIPIENTES");
                entity.HasKey(e => e.Codigo);
                entity.Property(e => e.Codigo).ValueGeneratedOnAdd().HasColumnName("CD_RECIPIENTE");
                entity.Property(e => e.Endereco).IsRequired().HasMaxLength(200).HasColumnName("DS_ENDERECO");
                entity.Property(e => e.TipoResiduo).IsRequired().HasMaxLength(50).HasColumnName("DS_TIPO_RESIDUOS");
                entity.Property(e => e.NivelOcupacaoAtual).IsRequired().HasColumnName("VL_NIVEL_OCUPACAO");
                entity.Property(e => e.CapacidadeTotal).IsRequired().HasColumnName("VL_CAPACIDADE_TOTAL");
                entity.Property(e => e.CodigoMorador).HasColumnName("CD_MORADOR");

                entity.HasOne(e => e.Morador)
                      .WithMany(m => m.Recipientes)
                      .HasForeignKey(e => e.CodigoMorador);
            });

            modelBuilder.Entity<RotaModel>(entity =>
            {
                entity.ToTable("TBL_ROTAS");
                entity.HasKey(e => e.Codigo);
                entity.Property(e => e.Codigo).ValueGeneratedOnAdd().HasColumnName("CD_ROTA");
                entity.Property(e => e.DataColeta).IsRequired().HasColumnName("DT_COLETA");
                entity.Property(e => e.HoraInicio).IsRequired().HasColumnName("DT_HORA_INICIO");
                entity.Property(e => e.HoraFim).IsRequired().HasColumnName("DT_HORA_FIM");
                entity.Property(e => e.PontosColeta).IsRequired().HasColumnName("DS_PONTOS_COLETA");
                entity.Property(e => e.CodigoCaminhao).HasColumnName("CD_CAMINHAO");

                entity.HasOne(e => e.Caminhao)
                      .WithMany(c => c.Rotas)
                      .HasForeignKey(e => e.CodigoCaminhao);
            });

            modelBuilder.Entity<AgendamentoColetaModel>(entity =>
            {
                entity.ToTable("TBL_AGENDAMENTOS_COLETA");
                entity.HasKey(e => e.Codigo);
                entity.Property(e => e.Codigo).ValueGeneratedOnAdd().HasColumnName("CD_AGENDAMENTO_COLETA");
                entity.Property(e => e.DataAgendamento).IsRequired().HasColumnName("DT_AGENDAMENTO");
                entity.Property(e => e.CodigoRecipiente).HasColumnName("CD_RECIPIENTE");
                entity.Property(e => e.CodigoRota).HasColumnName("CD_ROTA");

                entity.HasOne(e => e.Recipiente)
                      .WithMany(r => r.Agendamentos)
                      .HasForeignKey(e => e.CodigoRecipiente);

                entity.HasOne(e => e.Rota)
                      .WithMany(r => r.Agendamentos)
                      .HasForeignKey(e => e.CodigoRota);
            });
        }

    }
}
