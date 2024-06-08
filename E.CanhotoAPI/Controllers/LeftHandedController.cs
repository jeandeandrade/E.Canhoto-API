using E.CanhotoAPI.DTO;
using E.CanhotoAPI.Models;
using E.CanhotoAPI.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
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
            List<CanhotosResponse> leftHandeds = await _leftHandedRepositorio.BuscarTodosOsCanhotos();
            return Ok(leftHandeds);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<CanhotosResponse>>> BuscarPorId(int id)
        {
            CanhotosResponse leftHanded = await _leftHandedRepositorio.BuscarPorId(id);
            return Ok(leftHanded);
        }

        [HttpPost]
        public async Task<ActionResult<LeftHanded>> Cadastrar([FromBody] LeftHanded leftHandedModels)
        {
            LeftHanded leftHandeds = await _leftHandedRepositorio.Adicionar(leftHandedModels);

            return Ok(leftHandeds);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CanhotosResponse>> Atualizar([FromBody] LeftHanded leftHandedModels, int id)
        {
            leftHandedModels.Id = id;
            CanhotosResponse leftHanded = await _leftHandedRepositorio.Atualizar(leftHandedModels, id);

            return Ok(leftHanded);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<LeftHanded>> Apagar(int id)
        {
            bool apagado = await _leftHandedRepositorio.Apagar(id);

            return Ok(apagado);
        }
    }
}
