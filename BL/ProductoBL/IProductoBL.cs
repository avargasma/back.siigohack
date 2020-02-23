using ET;
using ET.ProductoET;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BL.ProductoBL
{
    public interface IProductoBL : Interface.IBaseBusiness<Producto>
    {
        public Task<RSV_Global<List<Producto>>> Autocomplete(string pValorBusqueda);
        public Task<RSV_Global<Producto>> GetSaldoGlobal(int pID);
     }

}
