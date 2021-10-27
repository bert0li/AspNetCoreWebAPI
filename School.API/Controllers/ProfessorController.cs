using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.API.Data;
using School.API.Models;

namespace School.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        private readonly SchoolContexto _contexto;
        public ProfessorController(SchoolContexto contexto) 
        {
            _contexto = contexto;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var professores = _contexto.Professores.ToList();

            if (professores == null) return BadRequest("Professores não encontrados");

            return Ok(professores);
        }

        [HttpGet("byId")]
        public IActionResult GetById(int id)
        {
            var professorPesquisa = _contexto.Professores.FirstOrDefault(f => f.Id == id);

            if (professorPesquisa == null) return BadRequest($"Professor com [ID:{id}] não econtrando.");

            return Ok(professorPesquisa);
        }

        [HttpGet("byName")]
        public IActionResult GetbyNome(string nome)
        {
            var professorPesquisa = _contexto.Professores.FirstOrDefault(f => f.Nome == nome );

            if (professorPesquisa == null) return BadRequest($"Professor com o [NOME:{nome}] não encontrando.");

            return Ok(professorPesquisa);
        }

        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            _contexto.Add(professor);
            _contexto.SaveChanges();

            return Ok(professor);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            var professorPesquisa = _contexto.Professores.AsNoTracking().FirstOrDefault(f => f.Id == id);

            if (professorPesquisa == null) return BadRequest("Professor com [ID:{id}] não encontrado.");

            _contexto.Update(professor);
            _contexto.SaveChanges();

            return Ok(professor);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor professor)
        {
            var professorPesquisa = _contexto.Professores.AsNoTracking().FirstOrDefault(f => f.Id == id);

            if (professorPesquisa == null) return BadRequest("Professor com [ID:{id}] não encontrado.");

            _contexto.Update(professor);
            _contexto.SaveChanges();

            return Ok(professor);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var professorPesquisa = _contexto.Professores.FirstOrDefault(f => f.Id == id);
            
            if (professorPesquisa == null) return BadRequest("Professor com [ID:{id}] não encontrado.");

            _contexto.Remove(professorPesquisa);
            _contexto.SaveChanges();

            return Ok("Professor deletado.");
        }
    }
}