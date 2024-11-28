using System.ComponentModel.DataAnnotations;

namespace FogachoWebHeladeria.Models
{
    public class AF_Helado
    {
        [Key]
        public int AF_IdHeladeria { get; set; }
        [Required]
        public string? AF_Nombre { get; set; }
        [Required]
        public string? AF_Sabor { get; set; }
        [Required]
        public AF_Categoria AF_Categorias { get; set; }
        [Required]
        [Range(0.01, 50.00)]
        public decimal AF_Precio { get; set; }
        [Required]
        public bool AF_Queso { get; set; }

    }
}
