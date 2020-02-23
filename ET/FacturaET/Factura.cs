using System;
using System.Collections.Generic;
using System.Text;

namespace ET.FacturaET
{

    public class Factura
    {
        public int FCNumero { get; set; }
        public string FCPrefijo { get; set; }
        public int FCSucursal { get; set; }
        public DateTime FCFecha { get; set; }
        public int FCCliente { get; set; }
        public int FCVendedor { get; set; }
        public object FCSubTotal { get; set; }
        public object FCTotalIva { get; set; }
        public object FCTotalDescuento { get; set; }
        public object FCTotalNeto { get; set; }
        public string FCObservaciones { get; set; }
        public int FCUusarioCrea { get; set; }
        public DateTime FCFechaCrea { get; set; }
    }

    public class FacturaDetallada
    {
        public Factura Encabezado { get; set; }
        public List<FacturaDetalle> Detalle { get; set; }
    }

}
