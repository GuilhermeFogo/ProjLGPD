﻿// <auto-generated />
using System;
using LGPD.Repository.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LGPD.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220605002058_UserBoll")]
    partial class UserBoll
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LGPD.Modal.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Consentimento")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EnderecoId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("LGPD.Modal.Dados", b =>
                {
                    b.Property<int>("id_dado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Dados_Senssiveis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dados_regulares")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_dado");

                    b.ToTable("Dados");
                });

            modelBuilder.Entity("LGPD.Modal.DataMapping", b =>
                {
                    b.Property<int>("Id_DataMapping")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Area")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Empresa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ProcessoId")
                        .HasColumnType("int");

                    b.Property<string>("Responsavel")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_DataMapping");

                    b.HasIndex("ProcessoId");

                    b.ToTable("DataMappings");
                });

            modelBuilder.Entity("LGPD.Modal.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bairo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CEP")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Complemento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rua")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("LGPD.Modal.Processo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Armazenamento_Digital")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Armazenamento_Fisico")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("BaseLegal")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Compartilhamento_Externo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Compartilhamento_interno")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Controlador")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Dadoid_dado")
                        .HasColumnType("int");

                    b.Property<string>("Descricao_processo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Destino_final")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Macroprocesso")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Operador")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subprocesso")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("descricaoBase")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Dadoid_dado");

                    b.ToTable("Processos");
                });

            modelBuilder.Entity("LGPD.Modal.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativado")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Senha")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("LGPD.Modal.Cliente", b =>
                {
                    b.HasOne("LGPD.Modal.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId");

                    b.Navigation("Endereco");
                });

            modelBuilder.Entity("LGPD.Modal.DataMapping", b =>
                {
                    b.HasOne("LGPD.Modal.Processo", "Processo")
                        .WithMany()
                        .HasForeignKey("ProcessoId");

                    b.Navigation("Processo");
                });

            modelBuilder.Entity("LGPD.Modal.Processo", b =>
                {
                    b.HasOne("LGPD.Modal.Dados", "Dado")
                        .WithMany()
                        .HasForeignKey("Dadoid_dado");

                    b.Navigation("Dado");
                });
#pragma warning restore 612, 618
        }
    }
}
