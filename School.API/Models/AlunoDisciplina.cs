namespace School.API.Models
{
    public class AlunoDisciplina
    {
        public AlunoDisciplina() { }

        public AlunoDisciplina(int alunoId, Disciplina disciplinaId)
        {
            this.AlunoId = alunoId;
            this.DisciplinaId = disciplinaId;
        }

        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; }
        public Disciplina DisciplinaId { get; set; }
        public Disciplina Disciplina { get; set; }
    }
}