using DA.Context;
using DA.Helper;
using ET.UsuarioET;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vanidapp.Data.Helper;

namespace DA.UsuarioDA
{
    public class UsuarioDA:BaseContext
    {
        public async Task<long> Usuario_I(Usuario pUsuario)
        {
            long infoResultado;

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                ParameterHelper.NewParameter("@pUSIdTercero",SqlDbType.Int,4,ParameterDirection.Input,pUsuario.USIdTercero),
                ParameterHelper.NewParameter("@pUSUserName",SqlDbType.Int,4,ParameterDirection.Input,pUsuario.USUserName),
                ParameterHelper.NewParameter("@pUSPwd",SqlDbType.BigInt,20,ParameterDirection.Input,pUsuario.USPwd),
                ParameterHelper.NewParameter("@pUSPwdKey",SqlDbType.BigInt,20,ParameterDirection.Input,pUsuario.USPwdKey),
                ParameterHelper.NewParameter("@pUSIDRol",SqlDbType.BigInt,20,ParameterDirection.Input,pUsuario.USIDRol),
                ParameterHelper.NewParameter("@pUSCreationUser",SqlDbType.BigInt,20,ParameterDirection.Input,pUsuario.USUsuarioCreacion)
            };
            var command = this.Database.GetDbConnection().CreateCommand();
            command.CommandText = "[SECURITY].[Usuario_I]";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddRange(parameters.ToArray());
            await command.Connection.OpenAsync();
            infoResultado = (long)await command.ExecuteScalarAsync();
            await command.Connection.CloseAsync();
            return infoResultado;
        }
        public async Task<Usuario> UsuarioByUsername_G(string pNitEmpresa, string pUsername)
        {
            Usuario infoResultado;

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                ParameterHelper.NewParameter("@pNitEmpresa",SqlDbType.VarChar,100,ParameterDirection.Input,pNitEmpresa),
                ParameterHelper.NewParameter("@pUsername",SqlDbType.VarChar,100,ParameterDirection.Input,pUsername)
            };
            var command = this.Database.GetDbConnection().CreateCommand();
            command.CommandText = "[SECURITY].[UsuarioByUsername_G]";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddRange(parameters.ToArray());
            await command.Connection.OpenAsync();
            using (var reader = await command.ExecuteReaderAsync())
            {
                infoResultado = reader.Translate<Usuario>().ToList().FirstOrDefault();
            }
            await command.Connection.CloseAsync();
            return infoResultado;
        }
        public async Task<Usuario> UsuarioById_G(long pUSIdTercero)
        {
            Usuario infoResultado;

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                ParameterHelper.NewParameter("@pUSIdTercero",SqlDbType.BigInt, 22,ParameterDirection.Input, pUSIdTercero)
            };
            var command = this.Database.GetDbConnection().CreateCommand();
            command.CommandText = "[SECURITY].[UsuarioById_G]";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddRange(parameters.ToArray());
            await command.Connection.OpenAsync();
            using (var reader = await command.ExecuteReaderAsync())
            {
                infoResultado = reader.Translate<Usuario>().ToList().FirstOrDefault();
            }
            await command.Connection.CloseAsync();
            return infoResultado;
        }
        public async Task<bool> UsuarioPassword_U(Usuario pUsuario)
        {
            long infoResultado;

            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                ParameterHelper.NewParameter("@pIDTercero",SqlDbType.BigInt,8,ParameterDirection.Input,pUsuario.USIdTercero),
                ParameterHelper.NewParameter("@pPwdKey",SqlDbType.VarChar,256,ParameterDirection.Input,pUsuario.USPwdKey),
                ParameterHelper.NewParameter("@pPwd",SqlDbType.VarChar,256,ParameterDirection.Input,pUsuario.USPwd)
            };
            var command = this.Database.GetDbConnection().CreateCommand();
            command.CommandText = "[SECURITY].[UsuarioPassword_U]";
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddRange(parameters.ToArray());
            await command.Connection.OpenAsync();
            infoResultado = (long)await command.ExecuteScalarAsync();
            await command.Connection.CloseAsync();
            return infoResultado > 0;
        }
    }
}
