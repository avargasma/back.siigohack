using DA.Context;
using DA.Helper;
using ET.ProductET;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Vanidapp.Data.Helper;

namespace DA.ProductDA
{
    public class ProductDA: BaseContext
    {
        public async Task<List<Product>> Product_G()
        {
            List<Product> infoResultado = new List<Product>();

            //List<SqlParameter> parameters = new List<SqlParameter>()
            //{
            //    ParameterHelper.NewParameter("@plngID", SqlDbType.Int, 4, ParameterDirection.Input, pID)
            //};

            var command = this.Database.GetDbConnection().CreateCommand();
            command.CommandText = "Product_G";
            command.CommandType = CommandType.StoredProcedure;
            await command.Connection.OpenAsync();
            using (var reader = await command.ExecuteReaderAsync())
            {
                infoResultado = reader.Translate<Product>().ToList();
            }

            await command.Connection.CloseAsync();

            return infoResultado;
        }

    }
}
