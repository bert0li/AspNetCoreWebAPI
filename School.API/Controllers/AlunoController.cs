using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.API.Data;
using School.API.Dto;
using School.API.Models;

namespace School.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        public readonly IRepository _repo;
        private readonly IMapper _mapper;

        public AlunoController(IRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var alunos = _repo.GetAllAlunos(true);
            
            return Ok(_mapper.Map<IEnumerable<AlunoDto>>(alunos));
        }

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