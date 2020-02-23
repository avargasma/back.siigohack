using DA.Context;
using DA.Helper;
using ET.TerceroET;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vanidapp.Data.Helper;

namespace DA.TerceroDA
{
    public class TerceroDA:BaseContext
    {
        public async Task<Tercero> TerceroByNit_G(long pNit)
        {
            Tercero infoResultado;

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                ParameterHelper.NewParameter("@pNit",SqlDbType.BigInt,20,ParameterDirection.Input,pNit)
            };
            var command = this.Database.GetDbConnection().CreateCommand();
            command.CommandText = "[GENERAL].[TerceroByNit_G]";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddRange(parameters.ToArray());
            await command.Connection.OpenAsync();
            using (var reader = await command.ExecuteReaderAsync())
            {
                infoResultado = reader.Translate<Tercero>().ToList().FirstOrDefault();
            }
            await command.Connection.CloseAsync();
            return infoResultado;
        }
    }
}
