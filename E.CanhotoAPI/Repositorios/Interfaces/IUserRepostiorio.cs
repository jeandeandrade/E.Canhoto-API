using E.CanhotoAPI.Models;

namespace E.CanhotoAPI.Repositorios.Interfaces
{
    public interface IUserRepostiorio
    {
        Task<List<User>> BuscarTodosOsUsuarios();
        Task<User> BuscarPorId(int id);
        Task<User> Adicionar(User user);
        Task<User> Atualizar(User user, int id);
        Task<bool> Apagar(int id);
    }
}
