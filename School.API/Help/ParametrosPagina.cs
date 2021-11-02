namespace School.API.Help
{
    public class ParametrosPagina
    {
        public const int QuantidadeMaximaItens = 50;
        public int NumeroPagina { get; set; } = 1;
        private int quantidadeItens = 10;
        public int QuantidadeItens
        {
            get { return quantidadeItens; }
            
            set { quantidadeItens = (value > QuantidadeMaximaItens) ? QuantidadeMaximaItens : value; }
        }
        public int? Matricula { get; set; } = null;
        public string Nome { get; set; } = string.Empty;
        public int? Ativo { get; set; } = null;
    }
}