using FiltroCalculo.Clases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PrograWebPractica2.Models;
using System.Diagnostics.Contracts;

namespace PrograWebPractica2.Pages.RazorPages
{
    public class CalculoPageModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public Cliente ClienteFiltrto { get; set; } = new Cliente() { Nombre="Pepe", Apellido="Martinez", CiNit=1234567};
        [BindProperty(SupportsGet = true)]
        public Producto[] ProductosFiltro { get; set; } = new Producto[]
        {
            new Producto {Nombre = "Dulces", Precio  = 2.5, Cantidad = 10},
            new Producto {Nombre = "Papas", Precio  = 7.5, Cantidad = 3},
            new Producto {Nombre = "Gaseosa", Precio  = 15, Cantidad = 1},
            new Producto {Nombre = "Vodka", Precio  = 35, Cantidad = 4}
        };
        public  int PrecioTotal { get; set; }
        //lo de arriba son las variables que recibira la pagina de calculo

        public CalculoModel Calculo { get; set; }
        public void OnGet()
        {
        }
        public double CalcularTotal()
        {
            double total = 0;
            foreach (var producto in ProductosFiltro)
            {
                total += producto.Precio;
            }
            return total;
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid == false)
            {
                return Page();
            }
            //En lugar de index esta la ruta para la pagina RESUMEN y el nombre de las variables que utiliza en lugar de Client_ Productos_ y PrecioTotal
            return RedirectToPage("/Index", new { Cliente_ = Calculo.ClienteCalculo, Productos_= Calculo.ProductosCalculo, PrecioTotal = Calculo.PrecioTotalCalculo });
        }
    }
}
