using BL.Common;
using DA.ProductDA;
using ET;
using ET.ProductoET;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BL.ProductoBL
{
    public class ProductoBL : IProductoBL
    {
        private readonly AppSettings _appSettings;
        private readonly ProductoDA mProductoDA;

        public ProductoBL(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;

            mProductoDA = new ProductoDA { ConnectionString = this._appSettings.ConnectionString };
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

        public Task<RSV_Global<Producto>> GetById(long id)
        {
            throw new NotImplementedException();
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
