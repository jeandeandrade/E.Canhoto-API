using E.CanhotoAPI.Models;
using E.CanhotoAPI.Repositorios.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace E.CanhotoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepostiorio _userRepostiorio;

        public UserController(IUserRepostiorio userRepostiorio)
        {
            _userRepostiorio = userRepostiorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> BuscarTodosOsUsuarios()
        {
            try
            {
                List<User> users = await _userRepostiorio.BuscarTodosOsUsuarios();
                return Ok(users);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro ao buscar todos os usuários: {ex.Message}");

                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao buscar todos os usuários. Por favor, tente novamente mais tarde.");

            }
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<List<User>>> BuscarPorId(int id)
        {
            try
            {
                User user = await _userRepostiorio.BuscarPorId(id);

                if (user == null)
                {
                    return NotFound("Usuario não encontrado");
                }

                return Ok(user);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro ao buscar o usuários com o ID {id}: {ex.Message}");

                return StatusCode(StatusCodes.Status500InternalServerError, $"Ocorreu um erro ao buscar o usuario que possui o ID {id}");
            }

        } 

        [HttpPost]
        public async Task<ActionResult<User>> Cadastrar([FromBody] User userModels)
        {
            try
            {
                User users = await _userRepostiorio.Adicionar(userModels);

                if (User == null)
                {
                    return NotFound("Usuario não encontrado");
                }

                return Ok(users);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro ao cadastrar o usuario {ex.Message}");

                return StatusCode(StatusCodes.Status500InternalServerError, $"Ocorreu um erro ao cadastrar o usuario");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<User>> Atualizar([FromBody] User userModels, int id)
        {
            try
            {
                userModels.Id = id;
                User users = await _userRepostiorio.Atualizar(userModels, id);
                return Ok(users);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro ao tentar editar o usuario do {id}: {ex.Message}");

                return StatusCode(StatusCodes.Status500InternalServerError, $"Ocorreu um erro ao editarr o usuario");
            }

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> Apagar(int id)
        {
            try
            {
                bool apagado = await _userRepostiorio.Apagar(id);

                if (!apagado)
                {
                    return NotFound("Usuário não encontrado");

                }

                return Ok(apagado);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro ao tentar apagar o usuario do {id}: {ex.Message}");

                return StatusCode(StatusCodes.Status500InternalServerError, $"Ocorreu um erro ao tentar deletar o usuario");
            }
        }
    }
}
