using Microsoft.AspNetCore.Mvc;
using ExamenAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamenAPI.Controllers;

    [Route("api/[controller]")]
    [ApiController]
public class ProductosController : ControllerBase
    {

    private readonly ProyectoContext _context;

    public ProductosController(ProyectoContext context)
    {
        _context = context;
    }

    // GET: api/Productos
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Producto>>> GetProductos()
    {
        // Incluir la categoría relacionada en la consulta
        return await _context.Productos.Include(p => p.Categoria).ToListAsync();

    }

    [HttpGet("search")]
    public async Task<ActionResult<IEnumerable<Producto>>> SearchGamesByName(string name)
    {
        var games = await _context.Producto
            .Where(g => g.nombreProducto.Contains(name))
            .ToListAsync();

        if (games == null || games.Count == 0)
        {
            return NotFound("No se encontraron juegos con ese nombre.");
        }

        return games;
    }

}



