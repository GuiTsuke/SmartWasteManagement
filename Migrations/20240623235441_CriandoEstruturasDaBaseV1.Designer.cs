﻿// <auto-generated />
using System;
using Fiap.Web.SmartWasteManagement.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace Fiap.Web.SmartWasteManagement.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240623235441_CriandoEstruturasDaBaseV1")]
    partial class CriandoEstruturasDaBaseV1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Fiap.Web.SmartWasteManagement.Models.AgendamentoColetaModel", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("CD_AGENDAMENTO_COLETA");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Codigo"));

                    b.Property<int>("CodigoRecipiente")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("CD_RECIPIENTE");

                    b.Property<int>("CodigoRota")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("CD_ROTA");

                    b.Property<DateTime>("DataAgendamento")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("DT_AGENDAMENTO");

                    b.HasKey("Codigo");

                    b.HasIndex("CodigoRecipiente");

                    b.HasIndex("CodigoRota");

                    b.ToTable("TBL_AGENDAMENTOS_COLETA", (string)null);
                });

            modelBuilder.Entity("Fiap.Web.SmartWasteManagement.Models.CaminhaoModel", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("CD_CAMINHAO");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Codigo"));

                    b.Property<decimal>("CapacidadeCarga")
                        .HasColumnType("DECIMAL(18, 2)")
                        .HasColumnName("VL_CAPACIDADE_CARGA");

                    b.Property<string>("LocalizacaoAtual")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("DS_LOCALIZACAO_ATUAL");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR2(100)")
                        .HasColumnName("DS_PLACA");

                    b.Property<int>("Status")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("CD_STATUS");

                    b.HasKey("Codigo");

                    b.ToTable("TBL_CAMINHOES", (string)null);
                });

            modelBuilder.Entity("Fiap.Web.SmartWasteManagement.Models.MoradorModel", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("CD_MORADOR");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Codigo"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR2(100)")
                        .HasColumnName("DS_EMAIL");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("NVARCHAR2(200)")
                        .HasColumnName("DS_ENDERECO");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR2(100)")
                        .HasColumnName("DS_NOME");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("NVARCHAR2(20)")
                        .HasColumnName("DS_TELEFONE");

                    b.HasKey("Codigo");

                    b.ToTable("TBL_MORADORES", (string)null);
                });

            modelBuilder.Entity("Fiap.Web.SmartWasteManagement.Models.NotificacaoModel", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("CD_NOTIFICACAO");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Codigo"));

                    b.Property<int>("CodigoMorador")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("CD_MORADOR");

                    b.Property<int>("CodigoRecipiente")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("CD_RECIPIENTE");

                    b.Property<DateTime>("DataEnvio")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("DT_ENVIO");

                    b.Property<int>("Leitura")
                        .HasMaxLength(20)
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("CD_STATUS_LEITURA");

                    b.Property<int>("Tipo")
                        .HasMaxLength(50)
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("CD_STATUS_NOTIFICACAO");

                    b.HasKey("Codigo");

                    b.HasIndex("CodigoMorador");

                    b.HasIndex("CodigoRecipiente");

                    b.ToTable("TBL_NOTIFICACOES", (string)null);
                });

            modelBuilder.Entity("Fiap.Web.SmartWasteManagement.Models.RecipienteModel", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("CD_RECIPIENTE");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Codigo"));

                    b.Property<decimal>("CapacidadeTotal")
                        .HasColumnType("DECIMAL(18, 2)")
                        .HasColumnName("VL_CAPACIDADE_TOTAL");

                    b.Property<int>("CodigoMorador")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("CD_MORADOR");

                    b.Property<string>("Endereco")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("NVARCHAR2(200)")
                        .HasColumnName("DS_ENDERECO");

                    b.Property<decimal>("NivelOcupacaoAtual")
                        .HasColumnType("DECIMAL(18, 2)")
                        .HasColumnName("VL_NIVEL_OCUPACAO");

                    b.Property<int>("TipoResiduo")
                        .HasMaxLength(50)
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("DS_TIPO_RESIDUOS");

                    b.HasKey("Codigo");

                    b.HasIndex("CodigoMorador");

                    b.ToTable("TBL_RECIPIENTES", (string)null);
                });

            modelBuilder.Entity("Fiap.Web.SmartWasteManagement.Models.RotaModel", b =>
                {
                    b.Property<int>("Codigo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("CD_ROTA");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Codigo"));

                    b.Property<int>("CodigoCaminhao")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("CD_CAMINHAO");

                    b.Property<DateTime>("DataColeta")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("DT_COLETA");

                    b.Property<DateTime>("HoraFim")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("DT_HORA_FIM");

                    b.Property<DateTime>("HoraInicio")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("DT_HORA_INICIO");

                    b.Property<string>("PontosColeta")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("DS_PONTOS_COLETA");

                    b.HasKey("Codigo");

                    b.HasIndex("CodigoCaminhao");

                    b.ToTable("TBL_ROTAS", (string)null);
                });

            modelBuilder.Entity("Fiap.Web.SmartWasteManagement.Models.AgendamentoColetaModel", b =>
                {
                    b.HasOne("Fiap.Web.SmartWasteManagement.Models.RecipienteModel", "Recipiente")
                        .WithMany("Agendamentos")
                        .HasForeignKey("CodigoRecipiente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fiap.Web.SmartWasteManagement.Models.RotaModel", "Rota")
                        .WithMany("Agendamentos")
                        .HasForeignKey("CodigoRota")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Recipiente");

                    b.Navigation("Rota");
                });

            modelBuilder.Entity("Fiap.Web.SmartWasteManagement.Models.NotificacaoModel", b =>
                {
                    b.HasOne("Fiap.Web.SmartWasteManagement.Models.MoradorModel", "Morador")
                        .WithMany("Notificacoes")
                        .HasForeignKey("CodigoMorador")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fiap.Web.SmartWasteManagement.Models.RecipienteModel", "Recipiente")
                        .WithMany("Notificacoes")
                        .HasForeignKey("CodigoRecipiente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Morador");

                    b.Navigation("Recipiente");
                });

            modelBuilder.Entity("Fiap.Web.SmartWasteManagement.Models.RecipienteModel", b =>
                {
                    b.HasOne("Fiap.Web.SmartWasteManagement.Models.MoradorModel", "Morador")
                        .WithMany("Recipientes")
                        .HasForeignKey("CodigoMorador")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Morador");
                });

            modelBuilder.Entity("Fiap.Web.SmartWasteManagement.Models.RotaModel", b =>
                {
                    b.HasOne("Fiap.Web.SmartWasteManagement.Models.CaminhaoModel", "Caminhao")
                        .WithMany("Rotas")
                        .HasForeignKey("CodigoCaminhao")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Caminhao");
                });

            modelBuilder.Entity("Fiap.Web.SmartWasteManagement.Models.CaminhaoModel", b =>
                {
                    b.Navigation("Rotas");
                });

            modelBuilder.Entity("Fiap.Web.SmartWasteManagement.Models.MoradorModel", b =>
                {
                    b.Navigation("Notificacoes");

                    b.Navigation("Recipientes");
                });

            modelBuilder.Entity("Fiap.Web.SmartWasteManagement.Models.RecipienteModel", b =>
                {
                    b.Navigation("Agendamentos");

                    b.Navigation("Notificacoes");
                });

            modelBuilder.Entity("Fiap.Web.SmartWasteManagement.Models.RotaModel", b =>
                {
                    b.Navigation("Agendamentos");
                });
#pragma warning restore 612, 618
        }
    }
}
