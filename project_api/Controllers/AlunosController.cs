using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using project_api.Data;
using project_api.Models;

namespace project_api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController : Controller
    {
        public IRepository _repository { get; }
        public AlunosController(IRepository repository)
        {
            _repository = repository;

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _repository.GetAllAlunosAsync(true);

                return Ok(result);
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }

        }

        [HttpGet("{AlunoId}")]
        public async Task<IActionResult> GetByAlunoId(int AlunoId)
        {
            try
            {
                var result = await _repository.GetAlunoAsyncById(AlunoId, true);

                return Ok(result);
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }

        }

        [HttpGet("ByProfessor/{ProfessorId}")]
        public async Task<IActionResult> GetByProfessorId(int ProfessorId)
        {
            try
            {
                var result = await _repository.GetAlunosAsyncByProfessorId(ProfessorId, true);

                return Ok(result);
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }

        }

        [HttpPost]
        public async Task<IActionResult> post(Aluno model)
        {
            try
            {
                _repository.Add(model);

                if (await _repository.SaveChangesAsync())
                {
                    return Created($"/api/aluno/{model.Id}", model);
                }
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }

            return BadRequest();

        }

        [HttpPut("{AlunoId}")]
        public async Task<IActionResult> put(int AlunoId, Aluno model)
        {
            try
            {
                var aluno = await _repository.GetAlunoAsyncById(AlunoId, false);
                if (aluno == null)
                {
                    return NotFound();
                }
                _repository.Update(model);

                if (await _repository.SaveChangesAsync())
                {
                    aluno = await _repository.GetAlunoAsyncById(AlunoId, true);
                    return Created($"/api/aluno/{model.Id}", aluno);
                }
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status500InternalServerError, "Banco de Dados Falhou");
            }
            return BadRequest();

        }

        [HttpDelete("{AlunoId}")]
        public async Task<IActionResult> delete(int AlunoId)
        {
            try
            {
                var aluno = await _repository.GetAlunoAsyncById(AlunoId, false);
                if (aluno == null)
                {
                    return NotFound();
                }
                _repository.Delete(aluno);
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