using data.repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using model;

namespace Parcialxio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class empleadocontroller : ControllerBase
    {
        public readonly iempleadorepositorio _empleadorepositorio;
        public empleadocontroller(iempleadorepositorio empleadorepositorio)
        {
            _empleadorepositorio = empleadorepositorio;
        }


        [HttpPost]
        public async Task<IActionResult> insertempleado([FromBody] empleado empleado)
        {
            if(empleado == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            bool created = await _empleadorepositorio.insertempleado(empleado);
            return Ok(created);
           
        }
        [HttpGet]
        public async Task<IActionResult> getempleado()
        {
            return Ok(await _empleadorepositorio.getempleado());
        } 
    }
}
