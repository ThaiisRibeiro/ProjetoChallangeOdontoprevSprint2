﻿// <auto-generated />
using System;
using Infrastructure.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20241031183838_sprint2dotnetbd")]
    partial class sprint2dotnetbd
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Domain.Entities.Agendamento", b =>
                {
                    b.Property<int>("id_agendamento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_agendamento"));

                    b.Property<DateTime>("data_agendamento")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("data_agendamento ");

                    b.Property<DateTime>("data_atendimento")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("data_atendimento ");

                    b.Property<int>("id_clinica")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("id_clinica  ");

                    b.Property<int>("id_dentista")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("id_dentista  ");

                    b.Property<int>("id_paciente")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("id_paciente ");

                    b.Property<int>("id_tabela_preco")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("id_tabela_preco  ");

                    b.HasKey("id_agendamento");

                    b.ToTable("Dotnet_Agendamentos");
                });

            modelBuilder.Entity("Domain.Entities.Clinica", b =>
                {
                    b.Property<int>("id_clinica")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_clinica"));

                    b.Property<string>("cnpj")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("cnpj");

                    b.Property<string>("endereco")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("endereco ");

                    b.Property<int>("id_dentista")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("id_dentista ");

                    b.Property<string>("nome_clinica")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("nome_clinica ");

                    b.HasKey("id_clinica");

                    b.ToTable("Dotnet_Clinicas");
                });

            modelBuilder.Entity("Domain.Entities.ContasPagar", b =>
                {
                    b.Property<int>("id_conta_pagar")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_conta_pagar"));

                    b.Property<DateTime>("data_emissao")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("data_emissao ");

                    b.Property<DateTime>("data_vencimento")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("data_vencimento  ");

                    b.Property<int>("id_clinica")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("id_clinica ");

                    b.Property<double>("valor")
                        .HasColumnType("BINARY_DOUBLE")
                        .HasColumnName("valor ");

                    b.HasKey("id_conta_pagar");

                    b.ToTable("Dotnet_Contas_Pagar");
                });

            modelBuilder.Entity("Domain.Entities.ContasReceber", b =>
                {
                    b.Property<int>("id_conta_receber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_conta_receber"));

                    b.Property<DateTime>("data_emissao")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("data_emissao ");

                    b.Property<DateTime>("data_vencimento")
                        .HasColumnType("TIMESTAMP(7)")
                        .HasColumnName("data_vencimento  ");

                    b.Property<int>("id_paciente")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("id_paciente ");

                    b.Property<double>("valor")
                        .HasColumnType("BINARY_DOUBLE")
                        .HasColumnName("valor ");

                    b.HasKey("id_conta_receber");

                    b.ToTable("Dotnet_Contas_Receber");
                });

            modelBuilder.Entity("Domain.Entities.Dentista", b =>
                {
                    b.Property<int>("id_dentista")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_dentista"));

                    b.Property<string>("cpf")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("cpf_cnpj");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("email  ");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("nome");

                    b.Property<string>("numero_cro")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("telefone")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("telefone ");

                    b.HasKey("id_dentista");

                    b.ToTable("Dotnet_Dentistas");
                });

            modelBuilder.Entity("Domain.Entities.Fraude", b =>
                {
                    b.Property<int>("id_fraude")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_fraude"));

                    b.Property<string>("descricao")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("descricao ");

                    b.Property<int>("id_agendamento")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("id_agendamento ");

                    b.Property<int>("id_clinica")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("id_clinica   ");

                    b.Property<int>("id_dentista")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("id_dentista  ");

                    b.Property<int>("id_paciente")
                        .HasColumnType("NUMBER(10)")
                        .HasColumnName("id_paciente ");

                    b.Property<string>("tipo_fraude")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("tipo_fraude  ");

                    b.HasKey("id_fraude");

                    b.ToTable("Dotnet_Fraudes");
                });

            modelBuilder.Entity("Domain.Entities.Paciente", b =>
                {
                    b.Property<int>("id_paciente")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_paciente"));

                    b.Property<string>("cpf_cnpj")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("cpf_cnpj");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("endereco")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("endereco");

                    b.Property<string>("nome")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("nome");

                    b.Property<string>("senha")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("telefone")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("tipo_paciente")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("id_paciente");

                    b.ToTable("Dotnet_Pacientes");
                });

            modelBuilder.Entity("Domain.Entities.TabelaPreco", b =>
                {
                    b.Property<int>("id_tabela_preco")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NUMBER(10)");

                    OraclePropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_tabela_preco"));

                    b.Property<string>("descricao")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("descricao ");

                    b.Property<string>("nome_procedimento")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)")
                        .HasColumnName("nome_procedimento ");

                    b.Property<double>("valor")
                        .HasColumnType("BINARY_DOUBLE")
                        .HasColumnName("valor ");

                    b.HasKey("id_tabela_preco");

                    b.ToTable("Dotnet_Tabela_Precos");
                });
#pragma warning restore 612, 618
        }
    }
}
