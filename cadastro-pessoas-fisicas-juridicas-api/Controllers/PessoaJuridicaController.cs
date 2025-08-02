using cadastro_pessoas_fisicas_juridicas_api.Application.DTOs;
using cadastro_pessoas_fisicas_juridicas_api.Application.UsesCases.PessoaJuridicaUC;
using Microsoft.AspNetCore.Mvc;

namespace cadastro_pessoas_fisicas_juridicas_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoaJuridicaController : ControllerBase
    {
        private readonly CadastrarPessoaJuridicaUseCase _cadastrar;
        private readonly ConsultarPessoaJuridicaUseCase _consultar;
        private readonly EditarPessoaJuridicaUseCase _editar;
        private readonly ExcluirPessoaJuridicaUseCase _excluir;

        public PessoaJuridicaController(
            CadastrarPessoaJuridicaUseCase cadastrar,
            ConsultarPessoaJuridicaUseCase consultar,
            EditarPessoaJuridicaUseCase editar,
            ExcluirPessoaJuridicaUseCase excluir)
        {
            _cadastrar = cadastrar;
            _consultar = consultar;
            _editar = editar;
            _excluir = excluir;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PessoaJuridicaRequestDto dto)
        {
            var id = await _cadastrar.ExecuteAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id }, null);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _consultar.ObterPorIdAsync(id);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _consultar.ListarTodosAsync();
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PessoaJuridicaRequestDto dto)
        {
            await _editar.ExecuteAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _excluir.ExecuteAsync(id);
            return NoContent();
        }
    }
}
