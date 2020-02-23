using BL.Interface;
using ET;
using ET.UsuarioET;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BL.UsuarioBL
{
    public interface IUsuarioBL:IBaseBusiness<Usuario>
    {
        public Task<RSV_Global<bool>> ChangePassword(long pID, string pPassword);
    }
}
