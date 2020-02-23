using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using BL.NotificacionBL;
using ET;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SiigoHack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificacionController : ControllerBase
    {
        private INotificacionBL _notificacionBusiness;


        public NotificacionController(INotificacionBL pNotificacionBL)
        {
            _notificacionBusiness = pNotificacionBL;
        }

        [HttpGet("SendMailProveedor")]
        public async Task<ActionResult> SendMailProveedor(string pMail, string pNombreProducto, string pNombreProveedor)
        {
            RSV_Global<bool> infoResultado = new RSV_Global<bool>();

            try
            {
                infoResultado = await _notificacionBusiness.EnviarEmailProveedor(pNombreProveedor, pNombreProducto, pMail);
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