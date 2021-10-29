using System.Collections;
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
    /// <summary>
    /// Controller Professo
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ProfessorController : ControllerBase
    {
        private readonly IRepository _repo;
        private readonly IMapper _mapper;

        public ProfessorController(IRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        /// <summary>
        /// Método resposável por retornar todos os alunos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var professores = _repo.GetAllProfessores(true);

            if (professores == null) return BadRequest("Professores não encontrados");

            return Ok(_mapper.Map<IEnumerable<ProfessorDto>>(professores));
        }

         /// <summary>
         /// Método responsável por retornar um professor por id
         /// </summary>
         /// <param name="id"></param>
         /// <returns></returns>
        [HttpGet("byId")]
        public IActionResult GetById(int id)
        {
            var professorPesquisa = _repo.GetProfessorById(id);

            if (professorPesquisa == null) return BadRequest($"Professor com [ID:{id}] não econtrando.");

            var alunoDto = _mapper.Map<ProfessorDto>(professorPesquisa);

            return Ok(alunoDto);
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

        /// <summary>
        /// Método responsável por inserir um novo aluno
        /// </summary>
        /// <param name="professorRegistrarDto"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(ProfessorRegistrarDto professorRegistrarDto)
        {
            var professor = _mapper.Map<Professor>(professorRegistrarDto);

            _repo.Add(professor);

            if (_repo.SaveChanges())
                return Created($"api/professor/{professorRegistrarDto.Id}", _mapper.Map<ProfessorDto>(professor));
            else
                return BadRequest("Professor não cadastrado.");
        }

        /// <summary>
        /// Método reponsável por atulizar aluno e retornar o novo professor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="professorRegistrarDto"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, ProfessorRegistrarDto professorRegistrarDto)
        {
            var professorPesquisa = _repo.GetProfessorById(id);

            if (professorPesquisa == null) return BadRequest("Professor com [ID:{id}] não encontrado.");

            _mapper.Map(professorRegistrarDto, professorPesquisa);
            _repo.Update(professorPesquisa);

            if (_repo.SaveChanges())
                return Created($"api/professor/{professorRegistrarDto.Id}", _mapper.Map<ProfessorDto>(professorPesquisa));
            else
                return BadRequest("Não atualizado");

        }

        /// <summary>
        /// Método reponsável por atualizar uma parte do professor
        /// </summary>
        /// <param name="id"></param>
        /// <param name="professorRegistrarDto"></param>
        /// <returns></returns>
        [HttpPatch("{id}")]
        public IActionResult Patch(int id, ProfessorRegistrarDto professorRegistrarDto)
        {
            var professorPesquisa = _repo.GetProfessorById(id);

            if (professorPesquisa == null) return BadRequest("Professor com [ID:{id}] não encontrado.");

            _mapper.Map(professorRegistrarDto, professorPesquisa);
            _repo.Update(professorPesquisa);

            if (_repo.SaveChanges())
                return Created($"api/professor/{professorRegistrarDto.Id}", _mapper.Map<ProfessorDto>(professorPesquisa));
            else
                return BadRequest("Não atualizado");
        }

        /// <summary>
        /// Método responsável por Deletar um professor
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var professorPesquisa = _repo.GetProfessorById(id);

            if (professorPesquisa == null) return BadRequest("Professor com [ID:{id}] não encontrado.");

            _repo.Delete(professorPesquisa);

            if (_repo.SaveChanges())
                return Ok("Professor deletado.");
            else
                return BadRequest("Aluno não deletado");
        }
    }
}