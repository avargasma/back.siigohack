using BL.Common;
using DA.TerceroDA;
using ET;
using ET.TerceroET;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BL.TerceroBL
{
    public class TerceroBL : ITerceroBL
    {
        private readonly AppSettings _appSettings;
        private readonly TerceroDA _terceroDA;

        public TerceroBL(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
            _terceroDA = new TerceroDA { ConnectionString = this._appSettings.ConnectionString };
        }

        public Task<RSV_Global<bool>> Delete(int id, long idUsuMod)
        {
            throw new NotImplementedException();
        }

        public Task<RSV_Global<List<Tercero>>> GetAll(int quantity = -1)
        {
            throw new NotImplementedException();
        }

        public Task<RSV_Global<List<Tercero>>> GetAllBy(Expression<Func<Tercero, bool>> condition)
        {
            throw new NotImplementedException();
        }

        public Task<Tercero> GetBy(Expression<Func<Tercero, bool>> condition)
        {
            throw new NotImplementedException();
        }

        public Task<RSV_Global<Tercero>> GetById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<RSV_Global<Tercero>> Insert(Tercero entity)
        {
            throw new NotImplementedException();
        }

        public async Task<RSV_Global<Tercero>> GetByNit(long pNit)
        {
            RSV_Global<Tercero> infoResultado = new RSV_Global<Tercero>();

            try
            {
                //Envio la contraseña a generar
                infoResultado.Datos = await _terceroDA.TerceroByNit_G(pNit);
                infoResultado.Exitoso = true;
            }
            catch (Exception ex)
            {
                infoResultado.Exitoso = false;
                infoResultado.Error = new Error(ex, $"Se presento un error en el método {((MethodInfo)MethodBase.GetCurrentMethod()).Name.ToString()}. {ex.Message}");
            }

            return infoResultado;
        }

        public Task<RSV_Global<Tercero>> Update(Tercero entity)
        {
            throw new NotImplementedException();
        }
    }
}
