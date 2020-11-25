﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using project_api.Data;

namespace project_api.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("project_api.Models.Aluno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DataNasc");

                    b.Property<string>("Nome");

                    b.Property<int>("ProfessorId");

                    b.Property<string>("Sobrenome");

                    b.HasKey("Id");

                    b.HasIndex("ProfessorId");

                    b.ToTable("Alunos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DataNasc = "31/08/2000",
                            Nome = "Mario",
                            ProfessorId = 1,
                            Sobrenome = "José"
                        },
                        new
                        {
                            Id = 2,
                            DataNasc = "20/01/1990",
                            Nome = "Joana",
                            ProfessorId = 2,
                            Sobrenome = "Paula"
                        },
                        new
                        {
                            Id = 3,
                            DataNasc = "25/06/1981",
                            Nome = "Alexa",
                            ProfessorId = 3,
                            Sobrenome = "Ferraz"
                        });
                });

            modelBuilder.Entity("project_api.Models.Professor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("Professores");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Fernanda"
                        },
                        new
                        {
                            Id = 2,
                            Nome = "Paulo"
                        },
                        new
                        {
                            Id = 3,
                            Nome = "Luis"
                        });
                });

            modelBuilder.Entity("project_api.Models.Aluno", b =>
                {
                    b.HasOne("project_api.Models.Professor", "Professor")
                        .WithMany("Alunos")
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}