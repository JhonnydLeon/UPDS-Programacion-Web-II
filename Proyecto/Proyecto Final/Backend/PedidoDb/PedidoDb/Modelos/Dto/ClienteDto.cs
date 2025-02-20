using System.ComponentModel.DataAnnotations;

namespace PedidoDb.Modelos.Dto
{
    public class ClienteDto
    {
        
        public int Id { get; set; }

        
        public string Nombres { get; set; }

        
        public string Apellidos { get; set; }

        
        public string Genero { get; set; }

        
        public DateOnly Fecha_Nac { get; set; }

        public string Num_Doc { get; set; }

        public string Num_Cel { get; set; }

        public string Email { get; set; }
    }
}
