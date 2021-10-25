using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using School.API.Models;

namespace School.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        public List<Aluno> Alunos = new List<Aluno>() 
        {
            new Aluno() {Id = 1, Nome = "Marcos", Sobrenome = "Almeida", Telefone = "123456789"},
            new Aluno() {Id = 2, Nome = "Marta", Sobrenome = "Kente", Telefone = "987654321"},
            new Aluno() {Id = 3, Nome = "Laura", Sobrenome = "Maria", Telefone = "13579248"}
        };

        public AlunoController() { }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(Alunos);
        }

        //[HttpGet("{id:int}")]
        [HttpGet("byId")] //QueryString
        public IActionResult GetById(int id)
        {
            var aluno = Alunos.FirstOrDefault(f => f.Id == id);

            if (aluno == null) return BadRequest($"O aluno com [ID:{id}] não foi encontrado.");

            return Ok(aluno);
        }

        //[HttpGet("{nome}")]
        [HttpGet("byName")]
        public IActionResult GetByNome(string nome, string sobrenome)
        {
            var aluno = Alunos.FirstOrDefault(f => f.Nome.Contains(nome) && f.Sobrenome.Contains(sobrenome));

            if (aluno == null) return BadRequest($"O aluno com [Nome:{nome}] não foi encontrado.");

            return Ok(aluno);
        }

        [HttpPost]
        public IActionResult Post(Aluno aluno)
        {
            return Ok(aluno);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Aluno aluno)
        {
            return Ok(aluno);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Aluno aluno)
        {
            return Ok(aluno);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }
    }
}