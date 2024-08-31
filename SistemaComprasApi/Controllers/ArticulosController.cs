// Controllers/ArticulosController.cs
using Microsoft.AspNetCore.Mvc;
using SistemaComprasApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace SistemaComprasApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticulosController : ControllerBase
    {
        private static readonly List<Articulo> Articulos = new List<Articulo>
        {
            new Articulo { Codigo = "K1020", Descripcion = "Colchon Telgo", Precio = 10256.12, Deposito = 1 },
            new Articulo { Codigo = "K1024", Descripcion = "Sommier Telgo", Precio = 14256.12, Deposito = 1 },
            new Articulo { Codigo = "K1026", Descripcion = "Sommier Seally", Precio = 13256.12, Deposito = 1 },
            new Articulo { Codigo = "F1026", Descripcion = "Almohada Seally", Precio = 0, Deposito = 1 },
            new Articulo { Codigo = "K!°1026", Descripcion = "Sommier Seally", Precio = -13256.12, Deposito = 8 }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Articulo>> GetArticulos()
        {
            var articulosFiltrados = Articulos.Where(a => 
                a.Precio > 0 && 
                a.Deposito == 1 && 
                !a.Descripcion.Any(c => !char.IsLetterOrDigit(c) && !char.IsWhiteSpace(c)));

            return Ok(articulosFiltrados);
        }
    }
}
