using DA.Context;
using DA.Helper;
using ET.ProductoET;
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
    public class ProductoDA: BaseContext
    {
        public async Task<List<Producto>> Product_G()
        {
            List<Producto> infoResultado = new List<Producto>();

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
                infoResultado = reader.Translate<Producto>().ToList();
            }

            await command.Connection.CloseAsync();

            return infoResultado;
        }

    }
}
