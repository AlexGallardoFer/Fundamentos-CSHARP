using Formacion.CSharp.Database.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Formacion.CSharp.WebApi1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly NorthwindContext _context;

        public ProductosController(NorthwindContext context)
        {
            _context = context;
        }

        // GET /api/productos
        [HttpGet()]
        public ActionResult Get()
        {
            var productos = _context.Products
                .ToList();

            return Ok(productos);
        }

        // GET /api/productos/11
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            if (id < 1)
                return BadRequest(new { Message = "Las referencias tienen que ser números positivos" });

            var producto = _context.Products
                .Where(r => r.ProductID == id)
                .FirstOrDefault();

            if (producto == null)
                return NotFound(new {Message = "El producto no existe."});
            else
                return Ok(producto);
        }

        // POST /api/productos
        [HttpPost()]
        public ActionResult Post(Product producto)
        {
            if (_context.Products == null)
                return Problem("La entidad productos no existe (es Null)");

            try
            {
                _context.Products.Add(producto);
                _context.SaveChanges();

                //return CreatedAtAction("Get", new {id = producto.ProductID}, producto);

                return Created($"https://localhost:7282/api/Productos/{producto.ProductID}", producto);
            }
            catch (DbUpdateException ex)
            {
                if (ProductoExiste(producto.ProductID))
                    return Conflict(new { Message = $"El producto {producto.ProductID} ya existe." });
                else
                    return Conflict(new { ex.Message });
            }
            catch (Exception ex)
            {
                return Conflict(new { ex.Message });
            }
        }

        // PUT /api/productos/11
        [HttpPut("{id}")]
        public ActionResult Put(int id, Product producto)
        {
            if (id != producto.ProductID)
                return BadRequest(new {Message = "Los identificadores no son válidos."});
            try
            {
                _context.Update(producto);
                _context.SaveChanges();

                return NoContent();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                if (!ProductoExiste(producto.ProductID))
                    return Conflict(new { Message = $"El producto {producto.ProductID} no existe." });
                else
                return Conflict(new { ex.Message });
            }
            catch (Exception ex)
            {
                return Conflict(new { ex.Message });
            }
        }

        // DELETE /api/productos/11
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {            
            // Opción 1 con FIND
            var producto = _context.Products.Find(id);

            // Opción 2 con WHERE
            //var producto = _context.Products
            //    .Where(x => x.ProductID == id)
            //    .FirstOrDefault();

            if (producto == null)
                return NotFound(new {Message = "El producto no existe."});

            try
            {
                _context.Products.Remove(producto);
                _context.SaveChanges();

                return Ok();
            }
            catch (Exception ex)
            {
                return Conflict(new { ex.Message });
            }
        }

        private bool ProductoExiste(int id)
        {
            return _context.Products.Any(x => x.ProductID == id);
        }
    }
}
