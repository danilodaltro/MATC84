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
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaService pessoaService;

        public PessoaController(IPessoaService pessoaService)
        {
            this.pessoaService = pessoaService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var pessoa = await this.pessoaService.GetAllPessoas();
                if (pessoa == null) return NoContent();

                return Ok(pessoa);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao recuperar pessoas. Erro: {ex.Message}");
            }
        }

        [HttpGet("id/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var pessoa = await this.pessoaService.GetPessoaById(id);
                if (pessoa == null) return NoContent();

                return Ok(pessoa);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao recuperar pessoa por id. Erro: {ex.Message}");
            }
        }

        [HttpGet("nome/{nome}")]
        public async Task<IActionResult> GetByNome(string nome)
        {
            try
            {
                var pessoa = await this.pessoaService.GetAllPessoasByNome(nome);
                if (pessoa == null) return NoContent();

                return Ok(pessoa);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao recuperar pessoas por nome. Erro: {ex.Message}");
            }
        }

        [HttpGet("idade/{idade}")]
        public async Task<IActionResult> GetByIdade(int idade)
        {
            try
            {
                var pessoa = await this.pessoaService.GetAllPessoasByIdade(idade);
                if (pessoa == null) return NoContent();

                return Ok(pessoa);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao recuperar pessoa por idade. Erro: {ex.Message}");
            }
        }

        [HttpGet("matricula/{matricula}")]
        public async Task<IActionResult> GetByMatricula(string matricula)
        {
            try
            {
                var pessoa = await this.pessoaService.GetPessoaByMatricula(matricula);
                if (pessoa == null) return NoContent();

                return Ok(pessoa);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao recuperar pessoa por matricula. Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Pessoa model)
        {
            try
            {
                var pessoa = await this.pessoaService.AddPessoa(model);
                if (pessoa == null) return NoContent();

                return Ok(pessoa);

            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar adicionar pessoa. Erro: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Pessoa model)
        {
            try
            {
                var pessoa = await this.pessoaService.UpdatePessoa(id, model);
                if (pessoa == null) return NoContent();

                return Ok(pessoa);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar atualizar pessoa. Erro: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return await this.pessoaService.DeletePessoa(id) ?
                            Ok("Deletada.") :
                            BadRequest("Pessoa não deletada.");

            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                $"Erro ao tentar deletar pessoa. Erro: {ex.Message}");
                throw;
            }
        }
    }
}