using AutoMapper;
using School.API.Dto;
using School.API.Models;

namespace School.API.Help
{
    public class SchoolProfile : Profile
    {
        public SchoolProfile()
        {
            // Toda vez que estiver trabalhando com Aluno eu quero que ele seja mapeado para o AlunoDto
            CreateMap<Aluno, AlunoDto>()
                .ForMember
                (
                    // [destino é o AlunoDto] e o nome e sobrenome do ALuno esta sendo setado no nome do AlunoDto
                    destino => destino.Nome,
                    opcao => opcao.MapFrom(m => $"{m.Nome} {m.Sobrenome}")
                )
                .ForMember
                (
                    destino => destino.Idade,
                    opcao => opcao.MapFrom(m => m.DataNascimento.GetIdadeAtual())
                )
                .ReverseMap();

            //CreateMap<Aluno, AlunoDto>().ReverseMap();
            
            CreateMap<Aluno, AlunoRegistrarDto>().ReverseMap();
        }
    }
}