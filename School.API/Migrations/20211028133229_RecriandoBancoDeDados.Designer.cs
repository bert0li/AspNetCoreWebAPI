// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using School.API.Data;

namespace School.API.Migrations
{
    [DbContext(typeof(SchoolContexto))]
    [Migration("20211028133229_RecriandoBancoDeDados")]
    partial class RecriandoBancoDeDados
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0");

            modelBuilder.Entity("School.API.Models.Aluno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Ativo")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DataFim")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("TEXT");

                    b.Property<int>("Matricula")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<string>("Sobrenome")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefone")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Alunos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Ativo = true,
                            DataInicio = new DateTime(2021, 10, 28, 10, 32, 28, 956, DateTimeKind.Local).AddTicks(6503),
                            DataNascimento = new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Matricula = 1,
                            Nome = "Marta",
                            Sobrenome = "Kent",
                            Telefone = "33225555"
                        },
                        new
                        {
                            Id = 2,
                            Ativo = true,
                            DataInicio = new DateTime(2021, 10, 28, 10, 32, 28, 957, DateTimeKind.Local).AddTicks(1126),
                            DataNascimento = new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Matricula = 2,
                            Nome = "Paula",
                            Sobrenome = "Isabela",
                            Telefone = "3354288"
                        },
                        new
                        {
                            Id = 3,
                            Ativo = true,
                            DataInicio = new DateTime(2021, 10, 28, 10, 32, 28, 957, DateTimeKind.Local).AddTicks(1253),
                            DataNascimento = new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Matricula = 3,
                            Nome = "Laura",
                            Sobrenome = "Antonia",
                            Telefone = "55668899"
                        },
                        new
                        {
                            Id = 4,
                            Ativo = true,
                            DataInicio = new DateTime(2021, 10, 28, 10, 32, 28, 957, DateTimeKind.Local).AddTicks(1274),
                            DataNascimento = new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Matricula = 4,
                            Nome = "Luiza",
                            Sobrenome = "Maria",
                            Telefone = "6565659"
                        },
                        new
                        {
                            Id = 5,
                            Ativo = true,
                            DataInicio = new DateTime(2021, 10, 28, 10, 32, 28, 957, DateTimeKind.Local).AddTicks(1291),
                            DataNascimento = new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Matricula = 5,
                            Nome = "Lucas",
                            Sobrenome = "Machado",
                            Telefone = "565685415"
                        },
                        new
                        {
                            Id = 6,
                            Ativo = true,
                            DataInicio = new DateTime(2021, 10, 28, 10, 32, 28, 957, DateTimeKind.Local).AddTicks(1315),
                            DataNascimento = new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Matricula = 6,
                            Nome = "Pedro",
                            Sobrenome = "Alvares",
                            Telefone = "456454545"
                        },
                        new
                        {
                            Id = 7,
                            Ativo = true,
                            DataInicio = new DateTime(2021, 10, 28, 10, 32, 28, 957, DateTimeKind.Local).AddTicks(1332),
                            DataNascimento = new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Matricula = 7,
                            Nome = "Paulo",
                            Sobrenome = "José",
                            Telefone = "9874512"
                        });
                });

            modelBuilder.Entity("School.API.Models.AlunoCurso", b =>
                {
                    b.Property<int>("AlunoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CursoId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DataFim")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("TEXT");

                    b.HasKey("AlunoId", "CursoId");

                    b.HasIndex("CursoId");

                    b.ToTable("AlunosCursos");
                });

            modelBuilder.Entity("School.API.Models.AlunoDisciplina", b =>
                {
                    b.Property<int>("AlunoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DisciplinaId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DataFim")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("TEXT");

                    b.Property<int?>("Nota")
                        .HasColumnType("INTEGER");

                    b.HasKey("AlunoId", "DisciplinaId");

                    b.HasIndex("DisciplinaId");

                    b.ToTable("AlunosDisciplinas");

                    b.HasData(
                        new
                        {
                            AlunoId = 1,
                            DisciplinaId = 2,
                            DataInicio = new DateTime(2021, 10, 28, 10, 32, 28, 957, DateTimeKind.Local).AddTicks(4587)
                        },
                        new
                        {
                            AlunoId = 1,
                            DisciplinaId = 4,
                            DataInicio = new DateTime(2021, 10, 28, 10, 32, 28, 957, DateTimeKind.Local).AddTicks(5775)
                        },
                        new
                        {
                            AlunoId = 1,
                            DisciplinaId = 5,
                            DataInicio = new DateTime(2021, 10, 28, 10, 32, 28, 957, DateTimeKind.Local).AddTicks(5826)
                        },
                        new
                        {
                            AlunoId = 2,
                            DisciplinaId = 1,
                            DataInicio = new DateTime(2021, 10, 28, 10, 32, 28, 957, DateTimeKind.Local).AddTicks(5829)
                        },
                        new
                        {
                            AlunoId = 2,
                            DisciplinaId = 2,
                            DataInicio = new DateTime(2021, 10, 28, 10, 32, 28, 957, DateTimeKind.Local).AddTicks(5832)
                        },
                        new
                        {
                            AlunoId = 2,
                            DisciplinaId = 5,
                            DataInicio = new DateTime(2021, 10, 28, 10, 32, 28, 957, DateTimeKind.Local).AddTicks(5838)
                        },
                        new
                        {
                            AlunoId = 3,
                            DisciplinaId = 1,
                            DataInicio = new DateTime(2021, 10, 28, 10, 32, 28, 957, DateTimeKind.Local).AddTicks(5841)
                        },
                        new
                        {
                            AlunoId = 3,
                            DisciplinaId = 2,
                            DataInicio = new DateTime(2021, 10, 28, 10, 32, 28, 957, DateTimeKind.Local).AddTicks(5844)
                        },
                        new
                        {
                            AlunoId = 3,
                            DisciplinaId = 3,
                            DataInicio = new DateTime(2021, 10, 28, 10, 32, 28, 957, DateTimeKind.Local).AddTicks(5847)
                        },
                        new
                        {
                            AlunoId = 4,
                            DisciplinaId = 1,
                            DataInicio = new DateTime(2021, 10, 28, 10, 32, 28, 957, DateTimeKind.Local).AddTicks(5851)
                        },
                        new
                        {
                            AlunoId = 4,
                            DisciplinaId = 4,
                            DataInicio = new DateTime(2021, 10, 28, 10, 32, 28, 957, DateTimeKind.Local).AddTicks(5854)
                        },
                        new
                        {
                            AlunoId = 4,
                            DisciplinaId = 5,
                            DataInicio = new DateTime(2021, 10, 28, 10, 32, 28, 957, DateTimeKind.Local).AddTicks(5857)
                        },
                        new
                        {
                            AlunoId = 5,
                            DisciplinaId = 4,
                            DataInicio = new DateTime(2021, 10, 28, 10, 32, 28, 957, DateTimeKind.Local).AddTicks(5859)
                        },
                        new
                        {
                            AlunoId = 5,
                            DisciplinaId = 5,
                            DataInicio = new DateTime(2021, 10, 28, 10, 32, 28, 957, DateTimeKind.Local).AddTicks(5862)
                        },
                        new
                        {
                            AlunoId = 6,
                            DisciplinaId = 1,
                            DataInicio = new DateTime(2021, 10, 28, 10, 32, 28, 957, DateTimeKind.Local).AddTicks(5865)
                        },
                        new
                        {
                            AlunoId = 6,
                            DisciplinaId = 2,
                            DataInicio = new DateTime(2021, 10, 28, 10, 32, 28, 957, DateTimeKind.Local).AddTicks(5867)
                        },
                        new
                        {
                            AlunoId = 6,
                            DisciplinaId = 3,
                            DataInicio = new DateTime(2021, 10, 28, 10, 32, 28, 957, DateTimeKind.Local).AddTicks(5870)
                        },
                        new
                        {
                            AlunoId = 6,
                            DisciplinaId = 4,
                            DataInicio = new DateTime(2021, 10, 28, 10, 32, 28, 957, DateTimeKind.Local).AddTicks(5875)
                        },
                        new
                        {
                            AlunoId = 7,
                            DisciplinaId = 1,
                            DataInicio = new DateTime(2021, 10, 28, 10, 32, 28, 957, DateTimeKind.Local).AddTicks(5878)
                        },
                        new
                        {
                            AlunoId = 7,
                            DisciplinaId = 2,
                            DataInicio = new DateTime(2021, 10, 28, 10, 32, 28, 957, DateTimeKind.Local).AddTicks(5880)
                        },
                        new
                        {
                            AlunoId = 7,
                            DisciplinaId = 3,
                            DataInicio = new DateTime(2021, 10, 28, 10, 32, 28, 957, DateTimeKind.Local).AddTicks(5883)
                        },
                        new
                        {
                            AlunoId = 7,
                            DisciplinaId = 4,
                            DataInicio = new DateTime(2021, 10, 28, 10, 32, 28, 957, DateTimeKind.Local).AddTicks(5886)
                        },
                        new
                        {
                            AlunoId = 7,
                            DisciplinaId = 5,
                            DataInicio = new DateTime(2021, 10, 28, 10, 32, 28, 957, DateTimeKind.Local).AddTicks(5888)
                        });
                });

            modelBuilder.Entity("School.API.Models.Curso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Cursos");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Tecnologia da Informação"
                        },
                        new
                        {
                            Id = 2,
                            Nome = "Sistemas de Informação"
                        },
                        new
                        {
                            Id = 3,
                            Nome = "Ciência da Computação"
                        });
                });

            modelBuilder.Entity("School.API.Models.Disciplina", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CargaHoraria")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CursoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MyProperty")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<int?>("PrerequisitoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProfessorId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CursoId");

                    b.HasIndex("PrerequisitoId");

                    b.HasIndex("ProfessorId");

                    b.ToTable("Disciplinas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CargaHoraria = 0,
                            CursoId = 1,
                            MyProperty = 0,
                            Nome = "Matemática",
                            ProfessorId = 1
                        },
                        new
                        {
                            Id = 2,
                            CargaHoraria = 0,
                            CursoId = 3,
                            MyProperty = 0,
                            Nome = "Matemática",
                            ProfessorId = 1
                        },
                        new
                        {
                            Id = 3,
                            CargaHoraria = 0,
                            CursoId = 3,
                            MyProperty = 0,
                            Nome = "Física",
                            ProfessorId = 2
                        },
                        new
                        {
                            Id = 4,
                            CargaHoraria = 0,
                            CursoId = 1,
                            MyProperty = 0,
                            Nome = "Português",
                            ProfessorId = 3
                        },
                        new
                        {
                            Id = 5,
                            CargaHoraria = 0,
                            CursoId = 1,
                            MyProperty = 0,
                            Nome = "Inglês",
                            ProfessorId = 4
                        },
                        new
                        {
                            Id = 6,
                            CargaHoraria = 0,
                            CursoId = 2,
                            MyProperty = 0,
                            Nome = "Inglês",
                            ProfessorId = 4
                        },
                        new
                        {
                            Id = 7,
                            CargaHoraria = 0,
                            CursoId = 3,
                            MyProperty = 0,
                            Nome = "Inglês",
                            ProfessorId = 4
                        },
                        new
                        {
                            Id = 8,
                            CargaHoraria = 0,
                            CursoId = 1,
                            MyProperty = 0,
                            Nome = "Programação",
                            ProfessorId = 5
                        },
                        new
                        {
                            Id = 9,
                            CargaHoraria = 0,
                            CursoId = 2,
                            MyProperty = 0,
                            Nome = "Programação",
                            ProfessorId = 5
                        },
                        new
                        {
                            Id = 10,
                            CargaHoraria = 0,
                            CursoId = 3,
                            MyProperty = 0,
                            Nome = "Programação",
                            ProfessorId = 5
                        });
                });

            modelBuilder.Entity("School.API.Models.Professor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Ativo")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DataFim")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataInicio")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<int>("Registro")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Sobrenome")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefone")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Professores");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Ativo = true,
                            DataInicio = new DateTime(2021, 10, 28, 10, 32, 28, 951, DateTimeKind.Local).AddTicks(2690),
                            Nome = "Lauro",
                            Registro = 1,
                            Sobrenome = "Oliveria"
                        },
                        new
                        {
                            Id = 2,
                            Ativo = true,
                            DataInicio = new DateTime(2021, 10, 28, 10, 32, 28, 952, DateTimeKind.Local).AddTicks(2942),
                            Nome = "Roberto",
                            Registro = 2,
                            Sobrenome = "Soares"
                        },
                        new
                        {
                            Id = 3,
                            Ativo = true,
                            DataInicio = new DateTime(2021, 10, 28, 10, 32, 28, 952, DateTimeKind.Local).AddTicks(2998),
                            Nome = "Ronaldo",
                            Registro = 3,
                            Sobrenome = "Marconi"
                        },
                        new
                        {
                            Id = 4,
                            Ativo = true,
                            DataInicio = new DateTime(2021, 10, 28, 10, 32, 28, 952, DateTimeKind.Local).AddTicks(3001),
                            Nome = "Rodrigo",
                            Registro = 4,
                            Sobrenome = "Carvalho"
                        },
                        new
                        {
                            Id = 5,
                            Ativo = true,
                            DataInicio = new DateTime(2021, 10, 28, 10, 32, 28, 952, DateTimeKind.Local).AddTicks(3002),
                            Nome = "Alexandre",
                            Registro = 5,
                            Sobrenome = "Montanha"
                        });
                });

            modelBuilder.Entity("School.API.Models.AlunoCurso", b =>
                {
                    b.HasOne("School.API.Models.Aluno", "Aluno")
                        .WithMany()
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("School.API.Models.Curso", "Curso")
                        .WithMany()
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("School.API.Models.AlunoDisciplina", b =>
                {
                    b.HasOne("School.API.Models.Aluno", "Aluno")
                        .WithMany("AlunosDisciplinas")
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("School.API.Models.Disciplina", "Disciplina")
                        .WithMany("AlunosDisciplinas")
                        .HasForeignKey("DisciplinaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("School.API.Models.Disciplina", b =>
                {
                    b.HasOne("School.API.Models.Curso", "Curso")
                        .WithMany("Disciplinas")
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("School.API.Models.Disciplina", "Prerequisito")
                        .WithMany()
                        .HasForeignKey("PrerequisitoId");

                    b.HasOne("School.API.Models.Professor", "Professor")
                        .WithMany("Disciplinas")
                        .HasForeignKey("ProfessorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
