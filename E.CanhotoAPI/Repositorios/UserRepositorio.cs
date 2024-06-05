using Microsoft.EntityFrameworkCore;
using E.CanhotoAPI.Data;
using E.CanhotoAPI.Models;
using E.CanhotoAPI.Repositorios.Interfaces;

namespace E.CanhotoAPI.Repositorios
{
    public class UserRepositorio : IUserRepostiorio
    {
        private readonly ECanhotoAPIDBContext _dbcontext;

        public UserRepositorio(ECanhotoAPIDBContext eCanhotoAPIDBContext)
        {
            _dbcontext = eCanhotoAPIDBContext;
        }

        public async Task<User> BuscarPorId(int id)
        {
            return await _dbcontext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<User>> BuscarTodosOsUsuarios()
        {
            return await _dbcontext.Users.ToListAsync();
        }

        public async Task<User> Adicionar(User user)
        {
            await _dbcontext.Users.AddAsync(user);
            await _dbcontext.SaveChangesAsync();

            return user;
        }

        public async Task<User> Atualizar(User user, int id)
        {
            User userPerId = await BuscarPorId(id);

            if (userPerId == null)
            {
                throw new Exception($"Usuario para o ID: {id} não foi encontrado no banco de dados.");
            }

            userPerId.Nome = user.Nome;
            userPerId.Email = user.Email;
            userPerId.Funcao = user.Funcao;

            _dbcontext.Users.Update(userPerId);
            await _dbcontext.SaveChangesAsync();

            return userPerId;
        }


        public async Task<bool> Apagar(int id)
        {
            User userPerId = await BuscarPorId(id);

            if (userPerId == null)
            {
                throw new Exception($"Usuario para o ID: {id} não foi encontrado no banco de dados.");
            }

            _dbcontext.Users.Remove(userPerId);
            await _dbcontext.SaveChangesAsync();

            return true;
        }
    }
}
