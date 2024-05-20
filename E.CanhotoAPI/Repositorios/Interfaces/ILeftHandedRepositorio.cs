using E.CanhotoAPI.Models;

namespace E.CanhotoAPI.Repositorios.Interfaces
{
    public interface ILeftHandedRepositorio
    {
        Task<List<LeftHanded>> BuscarTodosOsCanhotos();
        Task<LeftHanded> BuscarPorId(int id);
        Task<LeftHanded> Adicionar(LeftHanded leftHanded);
        Task<LeftHanded> Atualizar(LeftHanded leftHanded, int id);
        Task<bool> Apagar(int id);
    }
}
