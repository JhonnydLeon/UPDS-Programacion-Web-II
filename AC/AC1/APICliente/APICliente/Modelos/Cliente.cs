using System.ComponentModel.DataAnnotations;

namespace APICliente.Modelos
{
    public class Cliente
    {
        [Key]
        public int Id {  get; set; }

        [Required]
        public string Nombres { get; set; }

        [Required]

        public String apellidos { get; set; }


        [Required]
        public string Direccion { get; set; }

        [Required]
        public string Telefono { get; set; }
    }
}
