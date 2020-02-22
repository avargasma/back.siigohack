using BL.Common;
using DA.ProductDA;
using ET.ProductET;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BL.ProductBL
{
    public class ProductBL : IProductBL
    {
        private readonly AppSettings _appSettings;
        private readonly ProductDA mProductDA;

        public ProductBL(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;

            mProductDA = new ProductDA { ConnectionString = this._appSettings.ConnectionString };
        }

        public Task<bool> Delete(int id, long idUsuMod)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Product>> GetAll(int quantity = -1)
        {
            try
            {
                return await mProductDA.Product_G();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Task<List<Product>> GetAllBy(Expression<Func<Product, bool>> condition)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetBy(Expression<Func<Product, bool>> condition)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Product> Insert(Product entity)
        {
            throw new NotImplementedException();
        }

        public Task<Product> Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
