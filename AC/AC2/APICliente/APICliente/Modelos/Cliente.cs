using System.ComponentModel.DataAnnotations;

namespace APICliente.Modelos
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string? Nombres { get; set; }

        [Required]
        [StringLength(100)]
        public string? Apellidos { get; set; }

        [Required]
        [StringLength(1)] // Solo un carácter para el género
        public string? Genero { get; set; }

        [Required]
        public required DateTime Fecha_Nac { get; set; }

        [Required]
        [StringLength(20)]
        public string? Num_Doc { get; set; }

        [Required]
        [StringLength(15)] // Longitud estándar para un número de celular
        public string? Num_Cel { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string? Email { get; set; }
    }
}
