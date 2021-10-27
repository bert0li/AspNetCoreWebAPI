using School.API.Models;

namespace School.API.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        bool SaveChanges();

        // Alunos
        Aluno[] GetAllAlunos(bool incluirProfessor = false);
        Aluno[] GetAllAlunosByDisciplinaId(int id, bool incluirProfessor = false);
        Aluno GetAlunoById(int id, bool incluirProfessor = false);

        // Professores
        Professor[] GetAllProfessores(bool incluirAlunos = false);
        Professor[] GetAllProfessoresByDisciplinaId(int id, bool incluirAlunos = false);
        Professor GetProfessorById(int id, bool incluirAlunos = false);
    }
}