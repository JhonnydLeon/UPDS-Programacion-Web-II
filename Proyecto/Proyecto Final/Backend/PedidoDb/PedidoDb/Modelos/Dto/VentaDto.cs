using System.ComponentModel.DataAnnotations;

namespace PedidoDb.Modelos.Dto
{
    public class VentaDto
    {
        
        public int Id { get; set; }

        
        public int IdCliente { get; set; }

        
        public int IdTrabajador { get; set; }

        
        public DateOnly Fecha { get; set; }

        
        public string Tipo_Comp { get; set; }

        
        public decimal Iva { get; set; }
    }
}
