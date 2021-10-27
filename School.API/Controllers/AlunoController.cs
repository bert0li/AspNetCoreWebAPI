using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.API.Data;
using School.API.Models;

namespace School.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly SchoolContexto _contexto;

        public AlunoController(SchoolContexto contexto)
        {
            _contexto = contexto;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_contexto.Alunos);
        }

        //[HttpGet("{id:int}")]
        [HttpGet("byId")] //QueryString
        public IActionResult GetById(int id)
        {
            var aluno = _contexto.Alunos.FirstOrDefault(f => f.Id == id);

            if (aluno == null) return BadRequest($"O aluno com [ID:{id}] não foi encontrado.");

            return Ok(aluno);
        }

        //[HttpGet("{nome}")]
        [HttpGet("byName")]
        public IActionResult GetByNome(string nome, string sobrenome)
        {
            var aluno = _contexto.Alunos.FirstOrDefault(f => f.Nome.Contains(nome) && f.Sobrenome.Contains(sobrenome));

            if (aluno == null) return BadRequest($"O aluno com [Nome:{nome}] não foi encontrado.");

            return Ok(aluno);
        }

        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            _contexto.Add(aluno);
            _contexto.SaveChanges();

            return Ok(aluno);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            var alunoPesquisa = _contexto.Alunos.AsNoTracking().FirstOrDefault(f => f.Id == id);

            if (alunoPesquisa == null) return BadRequest($"Aluno com [ID:{id}] não encontrado");

            _contexto.Update(aluno);
            _contexto.SaveChanges();

            return Ok(aluno);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            var alunoPesquisa = _contexto.Alunos.AsNoTracking().FirstOrDefault(f => f.Id == id);

            if (alunoPesquisa == null) return BadRequest($"Aluno com [ID:{id}] não encontrado");

            _contexto.Update(aluno);
            _contexto.SaveChanges();

            return Ok(aluno);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var alunoPesquisa = _contexto.Alunos.FirstOrDefault(f => f.Id == id);

            if (alunoPesquisa == null) return BadRequest($"Aluno com [ID:{id}] não encontrado");

            _contexto.Remove(alunoPesquisa);
            _contexto.SaveChanges();

            return Ok("Aluno deletado.");
        }
    }
}