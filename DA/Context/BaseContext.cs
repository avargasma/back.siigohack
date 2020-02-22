using Microsoft.EntityFrameworkCore;


namespace DA.Context
{
    public class BaseContext : DbContext
    {
        private string _connectionString;
        public string ConnectionString { get => _connectionString; set => _connectionString = value; }


        public BaseContext(string strConexion)
        {
            this._connectionString = strConexion;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!string.IsNullOrEmpty(_connectionString))
            {
                optionsBuilder.UseSqlServer(this._connectionString);
            }
        }

        public BaseContext()
        {

        }

        //internal VanidadAppContext GetContextSeguridad()
        //{
        //    Data.Context.VanidadAppContext db = null;

        //    if (!string.IsNullOrEmpty(this.ConnectionString))
        //    {
        //        db = new VanidadAppContext(this.ConnectionString);
        //    }

        //    return db;
        //}

        //internal VanidadAppContext GetContext()
        //{
        //    VanidadAppContext db = null;

        //    if (!string.IsNullOrEmpty(this.ConnectionString))
        //    {
        //        db = new VanidadAppContext(this.ConnectionString);
        //    }

        //    return db;
        //}
    }
}
