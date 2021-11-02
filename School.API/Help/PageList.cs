using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace School.API.Help
{
    /// <summary>
    /// Recurso responsável por páginar nossas entidades
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PageList<T> : List<T>
    {
        public int PaginaAtual { get; set; }
        public int TotalPaginas { get; set; }
        public int QuantidadeItens { get; set; }
        public int TotalContadorPagina { get; set; }

        public PageList(List<T> itens, int totalContadorPagina, int numeroPagina, int quantidadeItens)
        {
            TotalContadorPagina = totalContadorPagina;
            QuantidadeItens = quantidadeItens;
            PaginaAtual = numeroPagina;
            TotalPaginas = (int)Math.Ceiling(totalContadorPagina / (double)numeroPagina);
            this.AddRange(itens);
        }

        public static async Task<PageList<T>> CriarAsync(IQueryable<T> source, int numeroPagina, int quantidadeItens)
        {
            var contador = await source.CountAsync();
            var itens = await source.Skip((numeroPagina -1) * quantidadeItens)
                                    .Take(quantidadeItens)
                                    .ToListAsync();

            return new PageList<T>(itens, contador, numeroPagina, quantidadeItens);
        }
    }
}