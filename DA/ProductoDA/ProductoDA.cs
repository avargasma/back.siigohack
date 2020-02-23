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

        public async Task<List<Producto>> ProductoAutocomplet_G(string pValorBusqueda)
        {
            List<Producto> infoResultado = new List<Producto>();

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                ParameterHelper.NewParameter("@pValorBusqueda", SqlDbType.VarChar, 200, ParameterDirection.Input, pValorBusqueda)
            };

            var command = this.Database.GetDbConnection().CreateCommand();
            command.CommandText = "[GENERAL].[ProductoAutocomplete_G]";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddRange(parameters.ToArray());
            await command.Connection.OpenAsync();
            using (var reader = await command.ExecuteReaderAsync())
            {
                infoResultado = reader.Translate<Producto>().ToList();
            }

            await command.Connection.CloseAsync();

            return infoResultado;
        }


        public async Task<Producto> ProductoById(long pIdProd)
        {
            Producto infoResultado;

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                ParameterHelper.NewParameter("@pPRId",SqlDbType.BigInt,20,ParameterDirection.Input,pIdProd)
            };
            var command = this.Database.GetDbConnection().CreateCommand();
            command.CommandText = "[Producto].[ProductoById_G]";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddRange(parameters.ToArray());
            await command.Connection.OpenAsync();
            using (var reader = await command.ExecuteReaderAsync())
            {
                infoResultado = reader.Translate<Producto>().ToList().FirstOrDefault();
            }
            await command.Connection.CloseAsync();
            return infoResultado;
        }


    }
}
