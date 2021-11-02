using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace School.API.Help
{
    public static class Extensions
    {
        public static void AddPaginacao(this HttpResponse response, int paginaAtual,int quantidadeItens, int totalItens, int totalPagina)
        {
            var headerPagina = new HeaderPagina(paginaAtual, quantidadeItens, totalItens, totalPagina);

            var camelCaseFormartter = new JsonSerializerSettings();
            camelCaseFormartter.ContractResolver = new CamelCasePropertyNamesContractResolver();

            response.Headers.Add("Pagination", JsonConvert.SerializeObject(headerPagina, camelCaseFormartter));
            response.Headers.Add("Access-Control-Expose-Header", "Pagination");
        }
    }
} 