using FiltroCalculo.Clases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace sistema_ventas.Pages.Paginas
{
    public class ResumenModel : PageModel
    {
        //[BindProperty(SupportsGet = true)]
        //public Cliente ClienteResumen { get; set; }
       
        [BindProperty(SupportsGet =true)]
        public string nombreR { get; set; }
        [BindProperty(SupportsGet = true)]
        public string apellidoR { get; set; }
        [BindProperty(SupportsGet = true)]
        public string ciR { get; set; }
        [BindProperty(SupportsGet = true)]
        public string totalV { get; set; }
        public double descuento { get; set; }

        public double total { get; set; }
        public void OnGet()
        {
            if (string.IsNullOrEmpty(nombreR))
            {
                nombreR = "Gregorio Dávila";
            }
            

            if (int.Equals(Convert.ToInt32(ciR), 0))
            {
                ciR = "6745765364";
            }
            if (int.Equals(Convert.ToInt32(totalV), 0))
            {
                totalV = "1000";
                total = Convert.ToInt32(totalV);
            }

        }
       
    }
}
