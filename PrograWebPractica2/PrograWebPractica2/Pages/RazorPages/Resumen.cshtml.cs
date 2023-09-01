using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using sistema_ventas.Clases;

namespace sistema_ventas.Pages.Paginas
{
    public class ResumenModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string nombre { get; set; }
        [BindProperty(SupportsGet = true)]
        public string apellido { get; set; }
        [BindProperty(SupportsGet = true)]
        public int ci { get; set; }
        [BindProperty(SupportsGet = true)]
        public int total { get; set; }
        public void OnGet()
        {
            if (string.IsNullOrEmpty(nombre))
            {
                nombre = "Gregorio";
            }
            if (string.IsNullOrEmpty(apellido))
            {
                apellido = "Dávila";
            }
            if (int.Equals(ci,0))
            {
                ci = 156325;
            }
            if (int.Equals(total, 0))
            {
                total = 500;
            }
        }
       
        
    }
}
