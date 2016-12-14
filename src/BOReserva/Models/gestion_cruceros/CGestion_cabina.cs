using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Models.gestion_cruceros
{
    public class CGestion_cabina
    {
        public CGestion_cabina(string _nombreCabina, float _precioCabina)
        {
            this._nombreCabina = _nombreCabina;
            this._precioCabina = _precioCabina;
        }

        public CGestion_cabina()
        {
        }

        public CGestion_cabina(string _nombreCabina, float _precioCabina, int _fkCrucero) : this(_nombreCabina, _precioCabina)
        {
            this._fkCrucero = _fkCrucero;
        }

        public int _idCabina { get; set; }
        public String _nombreCabina { get; set; }
        public float _precioCabina { get; set; }
        public String _estatus { get; set; }
        public CGestion_camarote[] _camarote { get; set; }
        public int _fkCrucero { get; set; }
        public List<CGestion_cabina> cabinas { get; set; }

        public void AgregarCabinas(CGestion_cabina cabina)
        {
            ConexionBD cbd = new ConexionBD();
            cbd.insertarCabinas(cabina);
        }

        public void cambioEstatusCabina(int id_cabina)
        {
            ConexionBD cbd = new ConexionBD();
            cbd.estatusCabina(id_cabina);
        }
    }
}