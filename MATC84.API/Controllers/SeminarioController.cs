using System;
using System.Threading.Tasks;
using MATC84.Application.Contracts;
using MATC84.Domain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MATC84.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SeminarioController : ControllerBase
    {
        private readonly ISeminarioService seminarioService;

        public SeminarioController(ISeminarioService seminarioService)
        {
            this.seminarioService = seminarioService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var seminario = await this.seminarioService.GetAllSeminarios();
                if (seminario == null) return NoContent();

                return Ok(seminario);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao recuperar seminários. Erro: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var seminario = await this.seminarioService.GetSeminarioById(id);
                if (seminario == null) return NoContent();

                return Ok(seminario);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao recuperar seminários. Erro: {ex.Message}");
            }
        }

        [HttpGet("tema/{tema}")]
        public async Task<IActionResult> GetByTema(string tema)
        {
            try
            {
                var seminario = await this.seminarioService.GetAllSeminariosByTema(tema);
                if (seminario == null) return NoContent();

                return Ok(seminario);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao recuperar seminários por tema. Erro: {ex.Message}");
            }
        }

        [HttpGet("pessoa/{nome}")]
        public async Task<IActionResult> GetByPessoa(string nome)
        {
            try
            {
                var seminario = await this.seminarioService.GetAllSeminariosByPessoa(nome);
                if (seminario == null) return NoContent();

                return Ok(seminario);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao recuperar seminários por pessoa. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Seminario model)
        {
            try
            {
                var seminario = await this.seminarioService.AddSeminario(model);
                if (seminario == null) return NoContent();

                return Ok(seminario);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao adicionar seminário. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Seminario model)
        {
            try
            {
                var seminario = await this.seminarioService.UpdateSeminario(id, model);
                if (seminario == null) return NoContent();

                return Ok(seminario);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao atualizar seminário. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return await this.seminarioService.DeleteSeminario(id) ?
                            Ok("Deletado.") :
                            BadRequest("Seminário não deletado.");

            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar deletar seminário. Erro: {ex.Message}");
                throw;
            }
        }
    }
}