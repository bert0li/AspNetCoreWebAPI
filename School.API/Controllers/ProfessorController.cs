using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.API.Data;
using School.API.Models;

namespace School.API.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProfessorController : ControllerBase
    {
        private readonly IRepository _repo;

        public ProfessorController(IRepository repo) 
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var professores = _repo.GetAllProfessores(true);

            if (professores == null) return BadRequest("Professores não encontrados");

            return Ok(professores);
        }

        [HttpGet("byId")]
        public IActionResult GetById(int id)
        {
            var professorPesquisa = _repo.GetProfessorById(id);

            if (professorPesquisa == null) return BadRequest($"Professor com [ID:{id}] não econtrando.");

            return Ok(professorPesquisa);
        }
        
        /*
        [HttpGet("byName")]
        public IActionResult GetbyNome(string nome)
        {
            var professorPesquisa = _

            if (professorPesquisa == null) return BadRequest($"Professor com o [NOME:{nome}] não encontrando.");

            return Ok(professorPesquisa);
        }
        */

        [HttpPost]
        public IActionResult Post(Professor professor)
        {
            _repo.Add(professor);

            if (_repo.SaveChanges())
                return Ok(professor);
            else
                return BadRequest("Professor não cadastrado.");
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Professor professor)
        {
            var professorPesquisa = _repo.GetProfessorById(id);

            if (professorPesquisa == null) return BadRequest("Professor com [ID:{id}] não encontrado.");

            _repo.Update(professor);
            _repo.SaveChanges();

            return Ok(professor);
        }

        [HttpPatch("{id}")]
        public IActionResult Patch(int id, Professor professor)
        {
            var professorPesquisa = _repo.GetProfessorById(id);

            if (professorPesquisa == null) return BadRequest("Professor com [ID:{id}] não encontrado.");

            _repo.Update(professor);
            _repo.SaveChanges();

            return Ok(professor);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var professorPesquisa = _repo.GetProfessorById(id);
            
            if (professorPesquisa == null) return BadRequest("Professor com [ID:{id}] não encontrado.");

            _repo.Delete(professorPesquisa);
            _repo.SaveChanges();

            return Ok("Professor deletado.");
        }
    }
}