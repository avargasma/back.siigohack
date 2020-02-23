using ET;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BL.NotificacionBL
{
    public interface INotificacionBL
    {
        public Task<RSV_Global<bool>> EnviarEmailProveedor(string pNombreProveedor, string pNombreProducto, string pMail);
        public Task<RSV_Global<bool>> EnviarEmailCliente(string pNombreCliente, string pMail);
    }
}