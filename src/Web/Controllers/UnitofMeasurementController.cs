using Facturador.Web.Reverse;
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

        //BD - Enlace
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
                if (listUnit == null) { return NotFound("No se encontraron registros"); }
                return Ok(listUnit);

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
                var UnitFound = _context.UnitOfMeasurements.Find(id);
                if (UnitFound == null) { return NotFound("Registro no encontrado"); }
                return Ok(UnitFound);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        //// POST: Creacion de un item  UnitOfMeasurement 
        [HttpPost]
        public IEnumerable<String> Post()
        {
            try
            {
                var uom = new UnitOfMeasurement { Code = "012", Unit = "test" };
                _context.UnitOfMeasurements.Add(uom);
                _context.SaveChanges();
                var id = _context.ContextId;
                return new string[] { "id insertado: " + uom.Id, "value2" };

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // PUT api/<UnitofMeasurementController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)

        {
        }





        // DELETE api/<UnitofMeasurementController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var UnitFound = _context.UnitOfMeasurements.Find(id);
                if (UnitFound == null) { return NotFound("Registro no encontrado"); }
                _context.UnitOfMeasurements.Remove(UnitFound);
                _context.SaveChanges();

               return Ok("Regitro eliminado correctamente");

            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
