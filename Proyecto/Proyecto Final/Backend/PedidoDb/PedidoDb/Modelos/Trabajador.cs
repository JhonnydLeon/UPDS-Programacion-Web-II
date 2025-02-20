using System.ComponentModel.DataAnnotations;

namespace PedidoDb.Modelos
{
    public class Trabajador
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Nombres { get; set; }

        [Required]
        public string Apellidos { get; set; }

        [Required]
        public string Genero { get; set; }

        [Required]
        public DateOnly Fecha_Nac { get; set; }

        [Required]
        public string Num_Doc { get; set; }

        [Required]
        public string Direccion { get; set; }

        [Required]
        public string Telefono { get; set; }

        public string Email { get; set; }

        
    }
}
