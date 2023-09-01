using FiltroCalculo.Clases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace PrograWebPractica2.Pages.RazorPages
{
    public class DatosModel : PageModel
    {
		[BindProperty]
        public Cliente ClienteN { get; set; } = new Cliente();

		[BindProperty]
		public Producto[] ProductosFiltro1 { get; set; } = new Producto[]
        {
            new Producto {Nombre = "Boligrafos", Precio  = 2.5, Cantidad = 0},
            new Producto {Nombre = "Cuadernos", Precio  = 7.5, Cantidad = 0},
            new Producto {Nombre = "Lapices de colores", Precio  = 15, Cantidad = 0},
            new Producto {Nombre = "Borradores", Precio  = 35, Cantidad = 0}
        };
		[BindProperty]
		public Producto[] Productos { get; set; } = new Producto[]
		{
			new Producto {Nombre = "Boligrafos", Precio  = 2.5, Cantidad = 0},
			new Producto {Nombre = "Cuadernos", Precio  = 7.5, Cantidad = 0},
			new Producto {Nombre = "Lapices de colores", Precio  = 15, Cantidad = 0},
			new Producto {Nombre = "Borradores", Precio  = 35, Cantidad = 0}
		};

		public string nom = "hol";

		public int Precio = 0;
        public void OnGet()
        {

        }

		public IActionResult OnPost()
		{
			string cadCliente = ClienteN.Nombre + '/' + ClienteN.Apellido + '/' + ClienteN.CiNit;
			string cadProductos = "";
			foreach(var producto in Productos)
			{
				cadProductos = cadProductos + producto.Nombre + "/" + producto.Precio + "/" + producto.Cantidad + "|";
			}
			if (ModelState.IsValid == false)
			{
				return Page();
			}
			return RedirectToPage("/RazorPages/CalculoPage", new { cliente = cadCliente, productos = cadProductos});
		}

		public void mostrarPrecio(Producto producto)
        {
            

        }
    }
}
