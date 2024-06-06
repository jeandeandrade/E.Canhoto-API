using E.CanhotoAPI.Enums;
using E.CanhotoAPI.Models;

namespace E.CanhotoAPI.DTO
{
    public class CanhotosResponse
    {
        public int IdCanhoto { get; set; }
        public int NotaFiscal { get; set; }
        public double ValorGasto { get; set; }
        public CategoriaLeftHanded Categoria { get; set; }
        public DateTime Data { get; set; }
        public StatusLeftHanded Status { get; set; }
        public int? UserId { get; set; }
        public string UserName { get; set; }
    }
}
