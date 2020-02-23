using BL.Interface;
using ET;
using ET.TerceroET;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BL.TerceroBL
{
    public interface ITerceroBL:IBaseBusiness<Tercero>
    {
        public Task<RSV_Global<Tercero>>GetByNit(long pNit);
    }
}
