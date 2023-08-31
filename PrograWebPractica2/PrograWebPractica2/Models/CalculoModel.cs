using FiltroCalculo.Clases;

namespace PrograWebPractica2.Models
{
    public class CalculoModel
    {
        public Cliente ClienteCalculo { get; set; } = null;
        public Producto[] ProductosCalculo { get; set; } = null;
        public int PrecioTotalCalculo { get; set; }
    }
}
