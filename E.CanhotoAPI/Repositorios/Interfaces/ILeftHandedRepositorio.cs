using E.CanhotoAPI.DTO;
using E.CanhotoAPI.Models;

namespace E.CanhotoAPI.Repositorios.Interfaces
{
    public interface ILeftHandedRepositorio
    {
        Task<List<CanhotosResponse>> BuscarTodosOsCanhotos();
        Task<CanhotosResponse> BuscarPorId(int id);
        Task<LeftHanded> Adicionar(LeftHanded leftHanded);
        Task<CanhotosResponse> Atualizar(LeftHanded leftHanded, int id);
        Task<bool> Apagar(int id);
    }
}
