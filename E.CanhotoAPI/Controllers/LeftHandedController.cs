using E.CanhotoAPI.DTO;
using E.CanhotoAPI.Models;
using E.CanhotoAPI.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E.CanhotoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeftHandedController : ControllerBase
    {
        private readonly ILeftHandedRepositorio _leftHandedRepositorio;

        public LeftHandedController(ILeftHandedRepositorio leftHandedRepositorio)
        {
            _leftHandedRepositorio = leftHandedRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<CanhotosResponse>>> BuscarCanhotos()
        {
            try
            {
                List<CanhotosResponse> leftHandeds = await _leftHandedRepositorio.BuscarTodosOsCanhotos();
                return Ok(leftHandeds);
            }
            catch (Exception ex)
            {
                // Log da exceção
                Console.WriteLine($"Ocorreu um erro ao buscar todos os canhotos: {ex.Message}");

                // Retorno de uma resposta de erro com status 500 (Internal Server Error)
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao buscar todos os canhotos. Por favor, tente novamente mais tarde.");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<CanhotosResponse>>> BuscarPorId(int id)
        {
            try
            {
                CanhotosResponse leftHanded = await _leftHandedRepositorio.BuscarPorId(id);

                if (leftHanded == null)
                {
                    return NotFound("Canhoto não encontrado");
                }

                return Ok(leftHanded);
            }
            catch (Exception ex)
            {
                // Log da exceção
                Console.WriteLine($"Ocorreu um erro ao buscar o canhoto com o ID {id}: {ex.Message}");

                // Retorno de uma resposta de erro com status 500 (Internal Server Error)
                return StatusCode(StatusCodes.Status500InternalServerError, $"Ocorreu um erro ao buscar o canhoto com o ID {id}. Por favor, tente novamente mais tarde.");
            }
        }

        [HttpPost]
        public async Task<ActionResult<LeftHanded>> Cadastrar([FromBody] LeftHanded leftHandedModels)
        {
            try
            {
                LeftHanded leftHandeds = await _leftHandedRepositorio.Adicionar(leftHandedModels);

                if (leftHandeds == null)
                {
                    return NotFound("Canhoto não encontrado");
                }

                return Ok(leftHandeds);
            }
            catch (Exception ex)
            {
                // Log da exceção
                Console.WriteLine($"Ocorreu um erro ao cadastrar o canhoto: {ex.Message}");

                // Retorno de uma resposta de erro com status 500 (Internal Server Error)
                return StatusCode(StatusCodes.Status500InternalServerError, $"Ocorreu um erro ao cadastrar o canhoto. Por favor, tente novamente mais tarde.");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CanhotosResponse>> Atualizar([FromBody] LeftHanded leftHandedModels, int id)
        {
            try
            {
                leftHandedModels.Id = id;
                CanhotosResponse leftHanded = await _leftHandedRepositorio.Atualizar(leftHandedModels, id);
                return Ok(leftHanded);
            }
            catch (Exception ex)
            {
                // Log da exceção
                Console.WriteLine($"Ocorreu um erro ao tentar editar o canhoto com o ID {id}: {ex.Message}");

                // Retorno de uma resposta de erro com status 500 (Internal Server Error)
                return StatusCode(StatusCodes.Status500InternalServerError, $"Ocorreu um erro ao editar o canhoto com o ID {id}. Por favor, tente novamente mais tarde.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<LeftHanded>> Apagar(int id)
        {
            try
            {
                bool apagado = await _leftHandedRepositorio.Apagar(id);

                if (!apagado)
                {
                    return NotFound("Canhoto não encontrado");
                }

                return Ok(apagado);
            }
            catch (Exception ex)
            {
                // Log da exceção
                Console.WriteLine($"Ocorreu um erro ao tentar apagar o canhoto com o ID {id}: {ex.Message}");

                // Retorno de uma resposta de erro com status 500 (Internal Server Error)
                return StatusCode(StatusCodes.Status500InternalServerError, $"Ocorreu um erro ao apagar o canhoto com o ID {id}. Por favor, tente novamente mais tarde.");
            }
        }
    }
}
