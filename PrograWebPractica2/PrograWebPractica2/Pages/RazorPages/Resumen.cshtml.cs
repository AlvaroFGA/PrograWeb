using FiltroCalculo.Clases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace sistema_ventas.Pages.Paginas
{
    public class ResumenModel : PageModel
    {
        //[BindProperty(SupportsGet = true)]
        //public Cliente ClienteResumen { get; set; }
        [BindProperty(SupportsGet = true)]
        public string nombreR { get; set; }
        [BindProperty(SupportsGet = true)]
        public string apellidoR { get; set; }
        [BindProperty(SupportsGet = true)]
        public int ciR { get; set; }
        public double total { get; set; }
        public double descuento { get; set; }

        public void OnGet()
        {
            if (string.IsNullOrEmpty(nombreR))
            {
                nombreR = "Gregorio";
            }
            if (string.IsNullOrEmpty(apellidoR))
            {
                apellidoR = "Dávila";
            }
            if (int.Equals(ciR, 0))
            {
                ciR = 156325;
            }
            if (int.Equals(total, 0))
            {
                total = 500;
            }
        }
       
    }
}
