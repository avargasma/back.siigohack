using System;
using System.Collections.Generic;
using System.Text;

namespace ET.UsuarioET
{
    public class Usuario
    {
        public int USIdTercero { get; set; }
        public string USUserName { get; set; }
        public string USPwd { get; set; }
        public string USPwdKey { get; set; }
        public int USIDRol { get; set; }
        public bool USActive { get; set; }
        public int USUsuarioCreacion { get; set; }
        public DateTime USFechaCreacion { get; set; }
        public int USUsuarioModificacion { get; set; }
        public DateTime USFechaMoficacion { get; set; }
    }

}
