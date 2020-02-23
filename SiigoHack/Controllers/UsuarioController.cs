using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using BL.UsuarioBL;
using ET;
using ET.UsuarioET;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SiigoHack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioBL wUsuarioBL;

        public UsuarioController(IUsuarioBL pUsuarioBL)
        {
            wUsuarioBL = pUsuarioBL;
        }

        [HttpGet("GetById")]
        //[HttpPost("GetById")]
        public async Task<ActionResult> GetById(long pUSIdTercero)
        {
            RSV_Global<Usuario> infoResultado = new RSV_Global<Usuario>();

            try
            {
                infoResultado = await wUsuarioBL.GetById(pUSIdTercero);
            }
            catch (Exception ex)
            {
                infoResultado.Error = new Error(ex, $"Se presento un error en el metodo {((MethodInfo)MethodBase.GetCurrentMethod()).Name.ToString()}. {ex.Message}");
                infoResultado.Exitoso = false;
            }

            return Ok(infoResultado);
        }

        [HttpPost("ChangePassword")]
        public async Task<ActionResult> ChangePassword(int id, string password)
        {

            RSV_Global<bool> infoResultado = new RSV_Global<bool>();

            try
            {
                infoResultado = await wUsuarioBL.ChangePassword(id, password);
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