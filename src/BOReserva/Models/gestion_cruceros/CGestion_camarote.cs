using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Models.gestion_cruceros
{
    public class CGestion_camarote
    {
        public int _cantidadCama { get; set; }
        public String _tipoCama { get; set; }
        public String _estatus { get; set; }

        public CGestion_camarote(int cantidadCama, String tipoCama, String estatus)
        {
            _cantidadCama = cantidadCama;
            _tipoCama = tipoCama;
            _estatus = estatus;
        }

        public CGestion_camarote()
        {
            _cantidadCama = 0;
            _tipoCama = null;
            _estatus = null;
        }

    }
}