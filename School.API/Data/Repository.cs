using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using School.API.Help;
using School.API.Models;

namespace School.API.Data
{
    public class Repository : IRepository
    {
        private readonly SchoolContexto _contexto;

        public Repository(SchoolContexto contexto)
        {
            _contexto = contexto;
        }

        public void Add<T>(T entity) where T : class
        {
            _contexto.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _contexto.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _contexto.Remove(entity);
        }

        public bool SaveChanges()
        {
            return (_contexto.SaveChanges() > 0);
        }

        public Aluno[] GetAllAlunos(bool incluirProfessor = false)
        {
            IQueryable<Aluno> query = _contexto.Alunos;

            if (incluirProfessor)
            {
                query = query.Include(i => i.AlunosDisciplinas)
                             .ThenInclude(t => t.Disciplina)
                             .ThenInclude(t => t.Professor);
            }

            query = query.AsNoTracking().OrderBy(o => o.Id);

            return query.ToArray();
        }

        public async Task<PageList<Aluno>> GetAllAlunosAsync(ParametrosPagina parametrosPagina, bool incluirProfessor = false)
        {
            IQueryable<Aluno> query = _contexto.Alunos;

            if (incluirProfessor)
            {
                query = query.Include(i => i.AlunosDisciplinas)
                             .ThenInclude(t => t.Disciplina)
                             .ThenInclude(t => t.Professor);
            }

            query = query.AsNoTracking().OrderBy(o => o.Id);

            if (!string.IsNullOrEmpty(parametrosPagina.Nome))
                query = query.Where(w => w.Nome.ToUpper().Contains(parametrosPagina.Nome.ToUpper()) || w.Sobrenome.ToUpper().Contains(parametrosPagina.Nome.ToUpper()));

            if (parametrosPagina.Matricula > 0)
                query = query.Where(w => w.Matricula == parametrosPagina.Matricula);

            if (parametrosPagina.Ativo != null)
                query = query.Where(w => w.Ativo == (parametrosPagina.Ativo != 0));

            //return await query.ToListAsync();
            return await PageList<Aluno>.CriarAsync(query, parametrosPagina.NumeroPagina, parametrosPagina.QuantidadeItens);
        }

        public Aluno[] GetAllAlunosByDisciplinaId(int id, bool incluirProfessor = false)
        {
            IQueryable<Aluno> query = _contexto.Alunos;

            if (incluirProfessor)
            {
                query = query.Include(i => i.AlunosDisciplinas)
                             .ThenInclude(t => t.Disciplina)
                             .ThenInclude(t => t.Professor);
            }

            query = query.AsNoTracking()
                         .Where(w => w.AlunosDisciplinas.Any(a => a.DisciplinaId == id))
                         .OrderBy(o => o.Id);

            return query.ToArray();
        }

        public Aluno GetAlunoById(int id, bool incluirProfessor = false)
        {
            IQueryable<Aluno> query = _contexto.Alunos;

            if (incluirProfessor)
            {
                query = query.Include(i => i.AlunosDisciplinas)
                             .ThenInclude(t => t.Disciplina)
                             .ThenInclude(t => t.Professor);
            }

            query = query.AsNoTracking()
                         .Where(w => w.Id == id)
                         .OrderBy(o => o.Id);

            return query.FirstOrDefault();
        }

        public Professor[] GetAllProfessores(bool incluirAlunos = false)
        {
            IQueryable<Professor> query = _contexto.Professores;

            if (incluirAlunos)
            {
                query = query.Include(i => i.Disciplinas)
                             .ThenInclude(t => t.AlunosDisciplinas)
                             .ThenInclude(t => t.Aluno);
            }

            query = query.AsNoTracking().OrderBy(o => o.Id);

            return query.ToArray();
        }

        public Professor[] GetAllProfessoresByDisciplinaId(int id, bool incluirAlunos = false)
        {
            IQueryable<Professor> query = _contexto.Professores;

            if (incluirAlunos)
            {
                query = query.Include(i => i.Disciplinas)
                             .ThenInclude(t => t.AlunosDisciplinas)
                             .ThenInclude(t => t.Aluno);
            }

            query = query.Where(w => w.Disciplinas.Any(a => a.AlunosDisciplinas.Any(a => a.DisciplinaId == id)))
                         .OrderBy(o => o.Id);

            return query.ToArray();
        }

        public Professor GetProfessorById(int id, bool incluirAlunos = false)
        {
            IQueryable<Professor> query = _contexto.Professores;

            if (incluirAlunos)
            {
                query = query.Include(i => i.Disciplinas)
                             .ThenInclude(t => t.AlunosDisciplinas)
                             .ThenInclude(t => t.Aluno);
            }

            query = query.AsNoTracking()
                         .Where(w => w.Id == id)
                         .OrderBy(o => o.Id);

            return query.FirstOrDefault();
        }
    }
}