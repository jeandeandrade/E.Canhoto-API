﻿using E.CanhotoAPI.Enums;

namespace E.CanhotoAPI.Models
{
    public class LeftHanded
    {
        public int Id { get; set; }
        public CategoriaLeftHanded Categoria { get; set; }
        public double ValorGasto { get; set; }
        public int NotaFiscal { get; set; }
        public DateTime Data {  get; set; }
        public StatusLeftHanded Status { get; set; }
        public int? UserId { get; set; }

        public virtual User? User { get; set; }
    }
}
