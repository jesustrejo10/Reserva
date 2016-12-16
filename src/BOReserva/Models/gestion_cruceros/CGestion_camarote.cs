using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Models.gestion_cruceros
{
    public class CGestion_camarote
    {
        public int _fkCabina { get; set; }
        public int _fkCrucero { get; set; }
        internal List<CGestion_camarote> camarote;

        public CGestion_camarote(int _cantidadCama, string _tipoCama, int _fkCabina)
        {
            this._cantidadCama = _cantidadCama;
            this._tipoCama = _tipoCama;
            this._fkCabina = _fkCabina;
        }

        public CGestion_camarote()
        {
        }

        public class GGestion_camarote
        {
        }
        public int _idCamarote { get; set; }
        public int _cantidadCama { get; set; }
        public String _tipoCama { get; set; }
        public String _estatus { get; set; }
        

        public void AgregarCamarote(CGestion_camarote camarote)
        {
            ConexionBD cbd = new ConexionBD();
            cbd.insertarCamarote(camarote);
        }



        public void cambioEstatusCamarote(int id_camarote)
        {
            ConexionBD cbd = new ConexionBD();
            cbd.estatusCamarote(id_camarote);
        }
    }
}