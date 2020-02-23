using System;
using System.Collections.Generic;

namespace ET.ProductoET
{

    public class Producto
    {
        public int PRId { get; set; }
        public string PRNombre { get; set; }
        public string PRDescripcion { get; set; }
        public Decimal PRPrecio { get; set; }
        public int PRImpuesto { get; set; }
        public Decimal PRPorcentajeImpuesto { get; set; }
        public string PRINombrempuesto { get; set; }
        public int PRUsuarioCreo { get; set; }
        public object PRFechaCrea { get; set; }
        public int PRUsuarioMod { get; set; }
        public object PRFechaMod { get; set; }
        public bool PRActivo { get; set; }
        public string PRCodigoBarras { get; set; }
        public int PRSaldo { get; set; }
    }
}
