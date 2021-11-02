namespace School.API.Help
{
    public class HeaderPagina
    {
        public int PaginaAtual { get; set; }
        public int QuantidadeItensPorPagina { get; set; }
        public int TotalItens { get; set; }
        public int TotalPagina { get; set; }

        public HeaderPagina(int paginaAtual, int quantidadeItensPorPagina, int totalItens, int totalPagina)
        {
            this.PaginaAtual = paginaAtual;
            this.QuantidadeItensPorPagina = quantidadeItensPorPagina;
            this.TotalItens = totalItens;
            this.TotalPagina = totalPagina;
        }
    }
}