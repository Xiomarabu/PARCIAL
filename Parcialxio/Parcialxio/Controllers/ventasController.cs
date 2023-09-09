using data.repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using model;

namespace Parcialxio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ventasController : ControllerBase
    {
        public readonly iventasrepositorio _ventasrepositorio;
        public ventasController(iventasrepositorio ventasrepositorio)
        {
            _ventasrepositorio = ventasrepositorio;
        }
        [HttpPost]
        public async Task <IActionResult> insertventas([FromBody] ventas ventas)
        {
            if(ventas == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            bool created = await _ventasrepositorio.insertventas(ventas);
            return Ok(created);
        }
    }
}
