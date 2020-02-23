using BL.Common;
using DA.ProductDA;
using ET;
using ET.ProductoET;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace BL.ProductoBL
{
    public class ProductoBL : IProductoBL
    {
        private readonly AppSettings _appSettings;
        private readonly ProductoDA _productoDA;

        public ProductoBL(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
            _productoDA = new ProductoDA { ConnectionString = this._appSettings.ConnectionString };
        }

        public async Task<RSV_Global<List<Producto>>> Autocomplete(string pValorBusqueda)
        {
            RSV_Global<List<Producto>> infoResultado = new RSV_Global<List<Producto>>();

            try
            {
                //Envio la contraseña a generar
                infoResultado.Datos = await _productoDA.ProductoAutocomplet_G(pValorBusqueda);
                infoResultado.Exitoso = true;
            }
            catch (Exception ex)
            {
                infoResultado.Exitoso = false;
                infoResultado.Error = new Error(ex, $"Se presento un error en el método {((MethodInfo)MethodBase.GetCurrentMethod()).Name.ToString()}. {ex.Message}");
            }

            return infoResultado;
        }

        public Task<RSV_Global<bool>> Delete(int id, long idUsuMod)
        {
            throw new NotImplementedException();
        }

        public Task<RSV_Global<List<Producto>>> GetAll(int quantity = -1)
        {
            throw new NotImplementedException();
        }

        public Task<RSV_Global<List<Producto>>> GetAllBy(Expression<Func<Producto, bool>> condition)
        {
            throw new NotImplementedException();
        }

        public Task<Producto> GetBy(Expression<Func<Producto, bool>> condition)
        {
            throw new NotImplementedException();
        }

        public async Task<RSV_Global<Producto>> GetById(long id)
        {
            RSV_Global<Producto> infoResultado = new RSV_Global<Producto>();

            try
            {
                //Envio la contraseña a generar
                infoResultado.Datos = await _productoDA.ProductoById(id);
                infoResultado.Exitoso = true;
            }
            catch (Exception ex)
            {
                infoResultado.Exitoso = false;
                infoResultado.Error = new Error(ex, $"Se presento un error en el método {((MethodInfo)MethodBase.GetCurrentMethod()).Name.ToString()}. {ex.Message}");
            }

            return infoResultado;
        }

        public async Task<RSV_Global<Producto>> GetSaldoGlobal(int pID)
        {
            RSV_Global<Producto> infoResultado = new RSV_Global<Producto>();

            try
            {
                //Envio la contraseña a generar
                infoResultado.Datos = await _productoDA.ProductoSaldoGlobal_G(pID);
                infoResultado.Exitoso = true;
            }
            catch (Exception ex)
            {
                infoResultado.Exitoso = false;
                infoResultado.Error = new Error(ex, $"Se presento un error en el método {((MethodInfo)MethodBase.GetCurrentMethod()).Name.ToString()}. {ex.Message}");
            }

            return infoResultado;            
        }

        public Task<RSV_Global<Producto>> Insert(Producto entity)
        {
            throw new NotImplementedException();
        }

        public Task<RSV_Global<Producto>> Update(Producto entity)
        {
            throw new NotImplementedException();
        }
    }
}
