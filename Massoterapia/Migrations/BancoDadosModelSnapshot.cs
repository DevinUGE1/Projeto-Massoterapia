﻿// <auto-generated />
using System;
using Massoterapia.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Massoterapia.Migrations
{
    [DbContext(typeof(BancoDados))]
    partial class BancoDadosModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Massoterapia.Models.Administrador", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Administradores");
                });

            modelBuilder.Entity("Massoterapia.Models.Avaliacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Comentario")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("IdTratamento")
                        .HasColumnType("int");

                    b.Property<string>("Nota")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.HasKey("Id");

                    b.HasIndex("IdTratamento");

                    b.ToTable("Avaliacaos");
                });

            modelBuilder.Entity("Massoterapia.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Celular")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefone")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Massoterapia.Models.Profissional", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Amaromaterapia")
                        .HasColumnType("int");

                    b.Property<int>("Auriculoterapia")
                        .HasColumnType("int");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<int>("BambuTerapia")
                        .HasColumnType("int");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Complemento")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("Cromoterapia")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<int>("DoIn")
                        .HasColumnType("int");

                    b.Property<int>("DrenagemLinfatica")
                        .HasColumnType("int");

                    b.Property<int>("MassagemDesportiva")
                        .HasColumnType("int");

                    b.Property<int>("MassagemModeladora")
                        .HasColumnType("int");

                    b.Property<int>("MassagemRelaxante")
                        .HasColumnType("int");

                    b.Property<int>("Maxoterapia")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("PedrasQuentes")
                        .HasColumnType("int");

                    b.Property<int>("QuickMassagem")
                        .HasColumnType("int");

                    b.Property<int>("Reflexologia")
                        .HasColumnType("int");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Shiatsu")
                        .HasColumnType("int");

                    b.Property<int>("ShiatsuDaCadeira")
                        .HasColumnType("int");

                    b.Property<int>("TemAKinesioTape")
                        .HasColumnType("int");

                    b.Property<int>("VentoSaterapia")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Profissionais");
                });

            modelBuilder.Entity("Massoterapia.Models.RegistroViewModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Amaromaterapia")
                        .HasColumnType("bit");

                    b.Property<bool>("Auriculoterapia")
                        .HasColumnType("bit");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<bool>("BambuTerapia")
                        .HasColumnType("bit");

                    b.Property<string>("Celular")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Complemento")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<bool>("Cromoterapia")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<bool>("DoIn")
                        .HasColumnType("bit");

                    b.Property<bool>("DrenagemLinfatica")
                        .HasColumnType("bit");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int?>("IdPerfil")
                        .HasColumnType("int");

                    b.Property<bool>("MassagemDesportiva")
                        .HasColumnType("bit");

                    b.Property<bool>("MassagemModeladora")
                        .HasColumnType("bit");

                    b.Property<bool>("MassagemRelaxante")
                        .HasColumnType("bit");

                    b.Property<bool>("Maxoterapia")
                        .HasColumnType("bit");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<bool>("PedrasQuentes")
                        .HasColumnType("bit");

                    b.Property<int>("Perfil")
                        .HasColumnType("int");

                    b.Property<bool>("QuickMassagem")
                        .HasColumnType("bit");

                    b.Property<bool>("Reflexologia")
                        .HasColumnType("bit");

                    b.Property<string>("Rua")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Sexo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Shiatsu")
                        .HasColumnType("bit");

                    b.Property<bool>("ShiatsuDaCadeira")
                        .HasColumnType("bit");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<bool>("TemAKinesioTape")
                        .HasColumnType("bit");

                    b.Property<bool>("VentoSaterapia")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("RegistroViewModel");
                });

            modelBuilder.Entity("Massoterapia.Models.Tratamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Data")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdCliente")
                        .HasColumnType("int");

                    b.Property<int>("IdProfissional")
                        .HasColumnType("int");

                    b.Property<string>("TecnicaTratamento")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<bool>("TratamentoFinalizado")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("IdCliente");

                    b.HasIndex("IdProfissional");

                    b.ToTable("Tratamentos");
                });

            modelBuilder.Entity("Massoterapia.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int?>("IdPerfil")
                        .HasColumnType("int");

                    b.Property<string>("Imagem")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Perfil")
                        .HasColumnType("int");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Massoterapia.Models.Avaliacao", b =>
                {
                    b.HasOne("Massoterapia.Models.Tratamento", "tratamento")
                        .WithMany("avaliacaos")
                        .HasForeignKey("IdTratamento")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("tratamento");
                });

            modelBuilder.Entity("Massoterapia.Models.Tratamento", b =>
                {
                    b.HasOne("Massoterapia.Models.Cliente", "Cliente")
                        .WithMany("Tratamentos")
                        .HasForeignKey("IdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Massoterapia.Models.Profissional", "profissional")
                        .WithMany("Tratamentos")
                        .HasForeignKey("IdProfissional")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cliente");

                    b.Navigation("profissional");
                });

            modelBuilder.Entity("Massoterapia.Models.Cliente", b =>
                {
                    b.Navigation("Tratamentos");
                });

            modelBuilder.Entity("Massoterapia.Models.Profissional", b =>
                {
                    b.Navigation("Tratamentos");
                });

            modelBuilder.Entity("Massoterapia.Models.Tratamento", b =>
                {
                    b.Navigation("avaliacaos");
                });
#pragma warning restore 612, 618
        }
    }
}
