using System.ComponentModel.DataAnnotations;

namespace PedidoDb.Modelos
{
    public class Venta
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int IdCliente { get; set; }

        [Required]
        public int IdTrabajador { get; set; }

        [Required]
        public DateOnly Fecha { get; set; }

        [Required]
        public string Tipo_Comp { get; set; }

        [Required]
        public decimal Iva { get; set; }
    }
}
