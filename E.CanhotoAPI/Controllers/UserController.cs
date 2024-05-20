using E.CanhotoAPI.Models;
using E.CanhotoAPI.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
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
            List<User> users = await _userRepostiorio.BuscarTodosOsUsuarios();
            return Ok(users);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<List<User>>> BuscarPorId(int id)
        {
            User user = await _userRepostiorio.BuscarPorId(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<User>> Cadastrar([FromBody] User userModels)
        {
            User users = await _userRepostiorio.Adicionar(userModels);

            return Ok(users);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<User>> Atualizar([FromBody] User userModels, int id)
        {
            userModels.Id = id;
            User users = await _userRepostiorio.Atualizar(userModels, id);

            return Ok(users);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> Apagar(int id)
        {
            bool apagado = await _userRepostiorio.Apagar(id);

            return Ok(apagado);
        }
    }
}
