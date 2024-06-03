using E.CanhotoAPI.Enums;
using E.CanhotoAPI.Models;

namespace E.CanhotoAPI.DTO
{
    public class CanhotosResponse
    {
        public int IdCanhoto { get; set; }
        public int NotaFiscal { get; set; }
        public double ValorGasto { get; set; }
        public string? Nome { get; set; }
        public CategoriaLeftHanded Categoria { get; set; }
        public DateTime Data { get; set; }
        public CanhotosResponse(LeftHanded canhoto)
        {
            IdCanhoto = canhoto.Id;
            NotaFiscal = canhoto.NotaFiscal;
            ValorGasto = canhoto.ValorGasto;
            Nome = canhoto.Nome;
            Categoria = canhoto.Categoria;
            Data = canhoto.Data;
        }
    }
}
