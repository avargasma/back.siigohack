using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using BL.TerceroBL;
using ET;
using ET.TerceroET;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SiigoHack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TerceroController : ControllerBase
    {
        private ITerceroBL _terceroBL;

        public TerceroController(ITerceroBL pUsuarioBL)
        {
            _terceroBL = pUsuarioBL;
        }

        [HttpGet("GetByNit")]
        public async Task<ActionResult> GetByNit(long pNit)
        {
            RSV_Global<Tercero> infoResultado = new RSV_Global<Tercero>();

            try
            {
                infoResultado = await _terceroBL.GetByNit(pNit);
            }
            catch (Exception ex)
            {
                infoResultado.Error = new Error(ex, $"Se presento un error en el metodo {((MethodInfo)MethodBase.GetCurrentMethod()).Name.ToString()}. {ex.Message}");
                infoResultado.Exitoso = false;
            }

            return Ok(infoResultado);
        }

    }
}