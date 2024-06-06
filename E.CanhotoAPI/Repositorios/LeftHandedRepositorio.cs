using Microsoft.EntityFrameworkCore;
using E.CanhotoAPI.Data;
using E.CanhotoAPI.Models;
using E.CanhotoAPI.Repositorios.Interfaces;
using E.CanhotoAPI.DTO;

namespace E.CanhotoAPI.Repositorios
{
    public class LeftHandedRepositorio : ILeftHandedRepositorio
    {
        private readonly ECanhotoAPIDBContext _dbcontext;

        public LeftHandedRepositorio(ECanhotoAPIDBContext eCanhotoAPIDBContext)
        {
            _dbcontext = eCanhotoAPIDBContext;
        }

        public async Task<CanhotosResponse> BuscarPorId(int id)
        {
            return await _dbcontext.LeftHanded
                .Include(x => x.User)
                .Select(x => new CanhotosResponse
                {
                    IdCanhoto = x.Id,
                    NotaFiscal = x.NotaFiscal,
                    ValorGasto = x.ValorGasto,
                    Categoria = x.Categoria,
                    Data = x.Data,
                    Status = x.Status,
                    UserId = x.UserId,
                    UserName = x.User.Nome
                })
                .FirstOrDefaultAsync(x => x.IdCanhoto == id);
        }

        public async Task<List<CanhotosResponse>> BuscarTodosOsCanhotos()
        {
            return await _dbcontext.LeftHanded
                .Include(x => x.User)
                .Select(x => new CanhotosResponse
                {
                    IdCanhoto = x.Id,
                    NotaFiscal = x.NotaFiscal,
                    ValorGasto = x.ValorGasto,
                    Categoria = x.Categoria,
                    Data = x.Data,
                    Status = x.Status,
                    UserId = x.UserId,
                    UserName = x.User.Nome
                })
                .ToListAsync();
        }

        // Falta esse método
        public async Task<LeftHanded> Adicionar(LeftHanded leftHanded)
        {
            await _dbcontext.LeftHanded.AddAsync(leftHanded);
            await _dbcontext.SaveChangesAsync();

            return leftHanded;
        }

        public async Task<CanhotosResponse> Atualizar(LeftHanded leftHanded, int id)
        {
            CanhotosResponse leftHandedPerId = await BuscarPorId(id);

            LeftHanded canhoto = new LeftHanded()
            {
                Id = id,
                NotaFiscal = leftHandedPerId.NotaFiscal,
                ValorGasto = leftHandedPerId.ValorGasto,
                Categoria = leftHandedPerId.Categoria,
                Data = leftHandedPerId.Data,
                Status = leftHandedPerId.Status,
                UserId = leftHandedPerId.UserId,
            };

            if (leftHandedPerId == null)
            {
                throw new Exception($"Canhoto para o ID: {id} não foi encontrado no banco de dados.");
            }

            canhoto.Status = leftHanded.Status;

            _dbcontext.LeftHanded.Update(canhoto);
            await _dbcontext.SaveChangesAsync();

            return leftHandedPerId;
        }

        public async Task<bool> Apagar(int id)
        {
            CanhotosResponse leftHandedPerId = await BuscarPorId(id);

            LeftHanded canhoto = new LeftHanded()
            {
                Id = id,
                NotaFiscal = leftHandedPerId.NotaFiscal,
                ValorGasto = leftHandedPerId.ValorGasto,
                Categoria = leftHandedPerId.Categoria,
                Data = leftHandedPerId.Data,
                Status = leftHandedPerId.Status,
                UserId = leftHandedPerId.UserId,
            };

            if (leftHandedPerId == null)
            {
                throw new Exception($"Canhoto para o ID: {id} não foi encontrado no banco de dados.");
            }

            _dbcontext.LeftHanded.Remove(canhoto);
            await _dbcontext.SaveChangesAsync();

            return true;
        }
    }
}
