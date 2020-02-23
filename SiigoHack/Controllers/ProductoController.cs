using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using BL.ProductoBL;
using ET;
using ET.ProductoET;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SiigoHack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private IProductoBL _productBusiness;


        public ProductoController(IProductoBL pProductBL)
        {
            _productBusiness = pProductBL;
        }


        [HttpGet("Autocomplete")]
        public async Task<ActionResult> Autocomplete(string pValorBusqueda)
        {
            RSV_Global<List<Producto>> infoResultado = new RSV_Global<List<Producto>>();

            try
            {
                infoResultado = await _productBusiness.Autocomplete(pValorBusqueda);
            }
            catch (Exception ex)
            {
                infoResultado.Error = new Error(ex, $"Se presento un error en el metodo {((MethodInfo)MethodBase.GetCurrentMethod()).Name.ToString()}. {ex.Message}");
                infoResultado.Exitoso = false;
            }

            return Ok(infoResultado);
        }


        [HttpGet("GetSaldoGlobal")]
        public async Task<ActionResult> GetSaldoGlobal(int pID)
        {
            RSV_Global<Producto> infoResultado = new RSV_Global<Producto>();

            try
            {
                infoResultado = await _productBusiness.GetSaldoGlobal(pID);
            }
            catch (Exception ex)
            {
                infoResultado.Error = new Error(ex, $"Se presento un error en el metodo {((MethodInfo)MethodBase.GetCurrentMethod()).Name.ToString()}. {ex.Message}");
                infoResultado.Exitoso = false;
            }

            return Ok(infoResultado);
        }

        // GET: api/Login
        [HttpGet]
        public async Task<ActionResult<RSV_Global<List<Producto>>>> Get()
        {            
            try
            {
                return await _productBusiness.GetAll();
            }
            catch (Exception ex)
            {
                return BadRequest(null);
            }
        }

        // GET: api/Login/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Login
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Login/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
