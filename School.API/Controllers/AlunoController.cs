using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.API.Data;
using School.API.Dto;
using School.API.Help;
using School.API.Models;

namespace School.API.Controllers
{
    /// <summary>
    /// Controller Aluno
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AlunoController : ControllerBase
    {
        public readonly IRepository _repo;
        private readonly IMapper _mapper;
        
        public AlunoController(IRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        /// <summary>
        /// Método resposável por retornar todos os alunos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ParametrosPagina parametrosPagina)
        {
            var alunos = await _repo.GetAllAlunosAsync(parametrosPagina, true);
            var alunosDto = _mapper.Map<IEnumerable<AlunoDto>>(alunos);

            Response.AddPaginacao(alunos.PaginaAtual, alunos.QuantidadeItens, alunos.TotalContadorPagina, alunos.TotalPaginas);

            return Ok(alunosDto);
        }


        /// <summary>
        /// Método responsável por retornar um aluno por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        //[HttpGet("{id:int}")]
        [HttpGet("byId")] //QueryString
        public IActionResult GetById(int id)
        {
            var aluno = _repo.GetAlunoById(id, false);

            if (aluno == null) return BadRequest($"O aluno com [ID:{id}] não foi encontrado.");

            var alunoDto = _mapper.Map<AlunoDto>(aluno);

            return Ok(alunoDto);
        }

        /*
        //[HttpGet("{nome}")]
        [HttpGet("byName")]
        public IActionResult GetByNome(string nome, string sobrenome)
        {
            var aluno = _contexto.Alunos.FirstOrDefault(f => f.Nome.Contains(nome) && f.Sobrenome.Contains(sobrenome));

            if (aluno == null) return BadRequest($"O aluno com [Nome:{nome}] não foi encontrado.");

            return Ok(aluno);
        }
        */

        /// <summary>
        /// Método responsável por inserir um novo aluno
        /// </summary>
        /// <param name="alunoRegistrarDto"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(AlunoRegistrarDto alunoRegistrarDto)
        {
            var aluno = _mapper.Map<Aluno>(alunoRegistrarDto);

            _repo.Add(aluno);

            if (_repo.SaveChanges())
                return Created($"/api/aluno/{alunoRegistrarDto.Id}", _mapper.Map<AlunoDto>(aluno));
            else
                return BadRequest("Aluno não cadastrado.");
        }

        /// <summary>
        /// Método reponsável por atulizar aluno e retornar o novo aluno
        /// </summary>
        /// <param name="id"></param>
        /// <param name="alunoRegistrarDto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, AlunoRegistrarDto alunoRegistrarDto)
        {
            var alunoPesquisa = _repo.GetAlunoById(id);

            if (alunoPesquisa == null) return BadRequest($"Aluno com [ID:{id}] não encontrado");

            _mapper.Map(alunoRegistrarDto, alunoPesquisa);

            _repo.Update(alunoPesquisa);

            if (_repo.SaveChanges())
                return Created($"/api/aluno/{alunoRegistrarDto.Id}", _mapper.Map<AlunoDto>(alunoPesquisa));
            else
                return BadRequest("Não atualizado.");
        }

        /// <summary>
        /// Método reponsável por atualizar uma parte do aluno
        /// </summary>
        /// <param name="id"></param>
        /// <param name="alunoRegistrarDto"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, AlunoRegistrarDto alunoRegistrarDto)
        {
            var alunoPesquisa = _repo.GetAlunoById(id);

            if (alunoPesquisa == null) return BadRequest($"Aluno com [ID:{id}] não encontrado");

            _mapper.Map(alunoRegistrarDto, alunoPesquisa);

            _repo.Update(alunoPesquisa);

            if (_repo.SaveChanges())
                return Created($"/api/aluno/{alunoRegistrarDto.Id}", _mapper.Map<AlunoDto>(alunoPesquisa));
            else
                return BadRequest("Não atualizado.");
        }

        /// <summary>
        /// Método reponsável por deletar um aluno
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var alunoPesquisa = _repo.GetAlunoById(id);

            if (alunoPesquisa == null) return BadRequest($"Aluno com [ID:{id}] não encontrado");

            _repo.Delete(alunoPesquisa);

            if (_repo.SaveChanges())
                return Ok("Aluno deletado.");
            else
                return BadRequest("Aluno não deletado");
        }
    }
}