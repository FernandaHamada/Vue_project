using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using project_api.Data;
using project_api.Models;

namespace project_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : Controller
    {
        public IRepository _repository { get; }
        public ProfessorController(IRepository repository)
        {
            _repository = repository;

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _repository.GetAllProfessoresAsync(true);

                return Ok(result);
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }

        }

        [HttpGet("{ProfessorId}")]
        public async Task<IActionResult> GetProfessorById(int ProfessorId)
        {
            try
            {
                var result = await _repository.GetProfessorAsyncById(ProfessorId, true);

                return Ok(result);
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }

        }

        [HttpPost]
        public async Task<IActionResult> post(Professor model)
        {
            try
            {
                _repository.Add(model);
                if (await _repository.SaveChangesAsync())
                {
                    return Created($"/api/Professor/{model.Id}", model);
                }
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }

            return BadRequest();

        }

        [HttpPut("{ProfessorId}")]
        public async Task<IActionResult> Put(int ProfessorId, Professor model)
        {
            try
            {
                var professor = await _repository.GetProfessorAsyncById(ProfessorId, false);
                if (professor == null)
                {
                    return NotFound();
                }
                _repository.Update(model);

                if (await _repository.SaveChangesAsync())
                {
                    return Created($"/api/Professor/{model.Id}", model);
                }
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }
            return BadRequest();

        }

        [HttpDelete("{ProfessorId}")]
        public async Task<IActionResult> Delete(int ProfessorId)
        {
            try
            {
                var professor = await _repository.GetAlunoAsyncById(ProfessorId, false);
                if (professor == null)
                {
                    return NotFound();
                }
                _repository.Delete(professor);
                if (await _repository.SaveChangesAsync())
                {
                    return Ok();
                }
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }

            return BadRequest();

        }
    }
}