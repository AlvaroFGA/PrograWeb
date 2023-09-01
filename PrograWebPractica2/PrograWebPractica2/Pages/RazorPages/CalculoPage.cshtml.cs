using FiltroCalculo.Clases;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PrograWebPractica2.Models;
using System.Diagnostics.Contracts;

namespace PrograWebPractica2.Pages.RazorPages
{
    public class CalculoPageModel : PageModel
    {
        public Cliente ClienteFiltrto { get; set; } = new Cliente() { Nombre="Pepe", Apellido="Martinez", CiNit=1234567};
        public Producto[] ProductosFiltro { get; set; }
        public  int PrecioTotal { get; set; }
        //lo de arriba son las variables que recibira la pagina de calculo

        public CalculoModel Calculo { get; set; }
        public void OnGet(string cliente, string productos)
        {
            List<Producto> pro = new List<Producto>();
            string[] campos = cliente.Split('/');
            ClienteFiltrto.Nombre = campos[0];
            ClienteFiltrto.Apellido = campos[1];
            ClienteFiltrto.CiNit = Convert.ToInt32(campos[2]);

            string[] lineproduc = productos.Split("|");
            for(int i = 0; i < lineproduc.Length; i++)
            {
                string[] datosPro = lineproduc[i].Split("/");
                Producto tempPro;
                if (datosPro.Length == 3)
                {
                    tempPro = new Producto { Nombre = datosPro[0], Precio = Convert.ToDouble(datosPro[1]), Cantidad = Convert.ToInt32(datosPro[2]) };
                    if (tempPro.Cantidad != 0)
                    {
                        pro.Add(tempPro);
                    }
                }
            }
			Producto[] productosFiltro = new Producto[pro.Count];
            for(int i = 0; i < pro.Count; i++)
            {
                productosFiltro[i] = pro[i];
            }
            ProductosFiltro = productosFiltro;
		}
        public double CalcularTotal()
        {
            double total = 0;
            foreach (var producto in ProductosFiltro)
            {
                total += producto.Precio * producto.Cantidad;
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
            return RedirectToPage("/RazorPages/Resumen", new { nombreR= ClienteFiltrto.Nombre,apellidoR = ClienteFiltrto.Apellido, ciR = ClienteFiltrto.CiNit, PrecioTotal = Calculo.PrecioTotalCalculo });
        }
    }
}
