using Facturador.Web.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Facturador.Web.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class UnitofMeasurementController : ControllerBase
    {

        private readonly InvoiceContext _context;
        public UnitofMeasurementController(InvoiceContext context)
        {
            _context = context;
        }

        //// GET: List of UnitofMeasurement 
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<UnitOfMeasurement> listUnit = _context.UnitOfMeasurements.ToList();
                if (listUnit == null) { return StatusCode(StatusCodes.Status404NotFound, new { isSuccess = "Registro no encontrado" }); }
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = "Listado encontrado", listUnit }); ;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        // GET: Unico Item de UnitofMeasurement 
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var unitFound = _context.UnitOfMeasurements.Find(id);
                if (unitFound == null) { return StatusCode(StatusCodes.Status404NotFound, new { isSuccess = "Registro no encontrado" }); }
                return StatusCode(StatusCodes.Status200OK, new { isSuccess = "Registro encontrado", unitFound});

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        ////// POST: Creacion de un item  UnitOfMeasurement 
        //[HttpPost]
        //public IEnumerable<String> Post()
        //{
        //    //Falta defininir DTOs
        //    return ;
        //}

        //// PUT api/<UnitofMeasurementController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)

        //{
        //}


        // DELETE api/<UnitofMeasurementController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var unitFound = _context.UnitOfMeasurements.Find(id);
                if (unitFound == null) { return StatusCode(StatusCodes.Status404NotFound, new { isSuccess = "Registro no encontrado" }); }
                _context.UnitOfMeasurements.Remove(unitFound);
                _context.SaveChanges();

               return StatusCode(StatusCodes.Status200OK, new { isSuccess = "Eliminado correctamente" });

            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
