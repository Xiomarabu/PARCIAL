using data.repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using model;

namespace Parcialxio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class clientecontrollercs : ControllerBase
    {
        public readonly iclienterepositorio _clienterepositorio;
        public clientecontrollercs(iclienterepositorio clienterepositorio)
        {
            _clienterepositorio = clienterepositorio;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> getclientebyId(int id)
        {
            return Ok(await _clienterepositorio.getClienteById(id));
        }
        [HttpPost]
        public async Task<IActionResult> InsertClientes([FromBody] cliente cliente )
        {
            if(cliente == null)
            {
                return BadRequest();
            }
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            bool created = await _clienterepositorio.insertCliente(cliente);
            return Ok(created);
            
        }
        [HttpPut]
        public async Task<IActionResult> updatecliente([FromBody] cliente cliente)
        {
            if (cliente == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            bool update = await _clienterepositorio.updateCliente(cliente);
            return Ok(update);
        }
        [HttpDelete]
        public async Task<ActionResult>DeleteClienteById(int id)
        {
            return Ok(await _clienterepositorio.deleteCliente(id));
        }
    }
}
