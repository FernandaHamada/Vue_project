using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using project_api.Models;

namespace project_api.project_api.Data {
    public class DataContext : DbContext {
        public DataContext (DbContextOptions<DataContext> options) : base (options) { }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Professor> Professores { get; set; }

        protected override void OnModelCreating (ModelBuilder builder) {
            builder.Entity<Professor> ()
                .HasData (
                    new List<Professor> () {
                        new Professor () {
                                Id = 1,
                                    Nome = "Fernanda"
                            },
                            new Professor () {
                                Id = 2,
                                    Nome = "Paulo"
                            },
                            new Professor () {
                                Id = 3,
                                    Nome = "Luis"
                            }
                    }
                );

            builder.Entity<Aluno> ()
                .HasData (
                    new List<Aluno> () {
                        new Aluno () {
                                Id = 1,
                                    Nome = "Mario",
                                    Sobrenome = "José",
                                    DataNasc = "31/08/2000",
                                    ProfessorId = 1
                            },
                            new Aluno () {
                                Id = 2,
                                    Nome = "Joana",
                                    Sobrenome = "Paula",
                                    DataNasc = "20/01/1990",
                                    ProfessorId = 2
                            },
                            new Aluno () {
                                Id = 3,
                                    Nome = "Alexa",
                                    Sobrenome = "Ferraz",
                                    DataNasc = "25/06/1981",
                                    ProfessorId = 3
                            }
                    }
                );
        }
    }
}