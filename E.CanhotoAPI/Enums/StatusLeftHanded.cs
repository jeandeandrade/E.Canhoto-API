using System.ComponentModel;

namespace E.CanhotoAPI.Enums
{
    public enum StatusLeftHanded
    {
        [Description("Reprovado")]
        Reprovado = 0,
        [Description("Aprovado")]
        Aprovado = 1,
        [Description("Pendente")]
        Pendente = 2,
    }
}
