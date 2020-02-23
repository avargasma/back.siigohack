using BL.Common;
using DA.UsuarioDA;
using ET;
using ET.UsuarioET;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BL.UsuarioBL
{
    public class UsuarioBL : IUsuarioBL
    {
        private readonly AppSettings _appSettings;
        private readonly UsuarioDA _usuarioDA;

        public UsuarioBL(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
            _usuarioDA = new UsuarioDA { ConnectionString = this._appSettings.ConnectionString };
        }

        public Task<RSV_Global<bool>> Delete(int id, long idUsuMod)
        {
            throw new NotImplementedException();
        }

        public Task<RSV_Global<List<Usuario>>> GetAll(int quantity = -1)
        {
            throw new NotImplementedException();
        }

        public Task<RSV_Global<List<Usuario>>> GetAllBy(Expression<Func<Usuario, bool>> condition)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> GetBy(Expression<Func<Usuario, bool>> condition)
        {
            throw new NotImplementedException();
        }

        public async Task<RSV_Global<Usuario>> GetById(long id)
        {
            RSV_Global<Usuario> infoResultado = new RSV_Global<Usuario>();
            try
            {
                infoResultado.Datos = new Usuario();
                infoResultado.Datos = await _usuarioDA.UsuarioById_G(id);
                infoResultado.Exitoso = true;
            }
            catch (Exception ex)
            {
                infoResultado.Exitoso = false;
                infoResultado.Error = new Error(ex, $"Se presento un error en el método {((MethodInfo)MethodBase.GetCurrentMethod()).Name.ToString()}. {ex.Message}");
            }

            return infoResultado;
        }

        public async Task<RSV_Global<bool>> ChangePassword(long pID, string pPassword)
        {
            RSV_Global<Usuario> infoUsuario = null;
            RSV_Global<bool> infoResultado = new RSV_Global<bool>();
            string key, pwd;

            try
            {
                //Verifico el usuario
                infoUsuario = await GetById(pID);

                if (!infoUsuario.Exitoso)
                {
                    infoResultado.Error = infoUsuario.Error;
                    infoResultado.Exitoso = false;
                    return infoResultado;
                }

                //Validación de código usado

                //Genero el Key
                key = System.Web.Helpers.Crypto.GenerateSalt();
                pwd = System.Web.Helpers.Crypto.HashPassword(key + pPassword);

                //Envio la contraseña a generar
                infoUsuario.Datos.USPwdKey = key;
                infoUsuario.Datos.USPwd = pwd;
                infoResultado.Datos = await _usuarioDA.UsuarioPassword_U(infoUsuario.Datos);
                infoResultado.Exitoso = true;
            }
            catch (Exception ex)
            {
                infoResultado.Exitoso = false;
                infoResultado.Error = new Error(ex, $"Se presento un error en el método {((MethodInfo)MethodBase.GetCurrentMethod()).Name.ToString()}. {ex.Message}");
            }

            return infoResultado;
        }

        public Task<RSV_Global<Usuario>> Insert(Usuario entity)
        {
            throw new NotImplementedException();
        }

        public Task<RSV_Global<Usuario>> Update(Usuario entity)
        {
            throw new NotImplementedException();
        }
    }
}
