using Microsoft.AspNetCore.Mvc;

namespace School.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfessorController : ControllerBase
    {
        public ProfessorController() { }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Professores: A, B e C");
        }
    }
}