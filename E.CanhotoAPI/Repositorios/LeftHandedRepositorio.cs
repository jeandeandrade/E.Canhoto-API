using Microsoft.EntityFrameworkCore;
using E.CanhotoAPI.Data;
using E.CanhotoAPI.Models;
using E.CanhotoAPI.Repositorios.Interfaces;

namespace E.CanhotoAPI.Repositorios
{
    public class LeftHandedRepositorio : ILeftHandedRepositorio
    {
        private readonly ECanhotoAPIDBContext _dbcontext;

        public LeftHandedRepositorio(ECanhotoAPIDBContext eCanhotoAPIDBContext)
        {
            _dbcontext = eCanhotoAPIDBContext;
        }

        public async Task<LeftHanded> BuscarPorId(int id)
        {
            return await _dbcontext.LeftHanded.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<LeftHanded>> BuscarTodosOsCanhotos()
        {
            return await _dbcontext.LeftHanded
                .Include(x => x.User)
                .ToListAsync();
        }

        public async Task<LeftHanded> Adicionar(LeftHanded leftHanded)
        {
            await _dbcontext.LeftHanded.AddAsync(leftHanded);
            await _dbcontext.SaveChangesAsync();

            return leftHanded;
        }

        public async Task<LeftHanded> Atualizar(LeftHanded leftHanded, int id)
        {
            LeftHanded leftHandedPerId = await BuscarPorId(id);

            if (leftHandedPerId == null)
            {
                throw new Exception($"Canhoto para o ID: {id} não foi encontrado no banco de dados.");
            }

            leftHandedPerId.Categoria = leftHanded.Categoria;
            leftHandedPerId.ValorGasto = leftHanded.ValorGasto;
            leftHandedPerId.NotaFiscal = leftHanded.NotaFiscal;
            leftHandedPerId.UserId = leftHanded.UserId;
            leftHandedPerId.Status = leftHanded.Status;

            _dbcontext.LeftHanded.Update(leftHandedPerId);
            await _dbcontext.SaveChangesAsync();

            return leftHandedPerId;
        }

        public async Task<bool> Apagar(int id)
        {
            LeftHanded leftHandedPerId = await BuscarPorId(id);

            if (leftHandedPerId == null)
            {
                throw new Exception($"Canhoto para o ID: {id} não foi encontrado no banco de dados.");
            }

            _dbcontext.LeftHanded.Remove(leftHandedPerId);
            await _dbcontext.SaveChangesAsync();

            return true;
        }
    }
}
