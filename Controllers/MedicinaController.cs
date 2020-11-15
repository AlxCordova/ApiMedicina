using System.Threading.Tasks;
using ApiMedicina;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicaPWA.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicinaController : ControllerBase
    {
        private Conexion dbConexion;
        public MedicinaController() { dbConexion = Conectar.GetConexion(); }

        // GET: api/<MedicinaController>
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await dbConexion.Medicina.ToArrayAsync());
        }

        // GET api/<MedicinaController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var medicina = await dbConexion.Medicina.SingleOrDefaultAsync(a => a.ID_MEDICINA == id);
            if (medicina != null)
            {
                return Ok(medicina);
            }
            else
            {
                return NotFound();
            }
        }

        // POST api/<MedicinaController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] E_Medicina medicina)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            await dbConexion.Medicina.AddAsync(medicina);
            dbConexion.SaveChanges();
            return Created("api/medicina", medicina);
        }

        // PUT api/<MedicinaController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] E_Medicina medicina)
        {
            var v_medicina = await dbConexion.Medicina.SingleOrDefaultAsync(a => a.ID_MEDICINA == id);
            if (v_medicina != null && ModelState.IsValid)
            {
                dbConexion.Entry(v_medicina).CurrentValues.SetValues(medicina);
                dbConexion.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/<MedicinaController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var medicina = await dbConexion.Medicina.SingleOrDefaultAsync(a => a.ID_MEDICINA == id);
            if (medicina != null)
            {
                dbConexion.Medicina.Remove(medicina);
                dbConexion.SaveChanges();
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
