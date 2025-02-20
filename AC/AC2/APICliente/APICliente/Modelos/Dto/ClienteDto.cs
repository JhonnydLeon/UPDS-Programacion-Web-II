using System.ComponentModel.DataAnnotations;

namespace APICliente.Modelos.Dto
{
    public class ClienteDto
    {

        public int Id { get; set; }
        public required string Nombres { get; set; }
        public required string Apellidos { get; set; }

        public required string Genero { get; set; }
        public required DateTime Fecha_Nac { get; set; }
        public required string Num_Doc { get; set; }
        public required string Num_Cel { get; set; }
        public required string Email { get; set; }
    }
}

