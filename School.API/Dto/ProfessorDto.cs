namespace School.API.Dto
{
    /// <summary>
    /// DTO de Professor para retorno
    /// </summary>
    public class ProfessorDto
    {
        public int Id { get; set; }
        public int Registro { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Telefone { get; set; }
        public bool Ativo { get; set; } = true;
    }
}