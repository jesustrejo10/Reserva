using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BOReserva.Models.gestion_cruceros
{

    /// <summary>
    /// Clase constructura de Gestion de Cabinas
    /// </summary>
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
        public IEnumerable<SelectListItem> _listaCruceros { get; set; }

        public string _cruceroNombre { get; set; }

        /// <summary>
        /// Metodo para agregar cabinas
        /// </summary>
        public void AgregarCabinas(CGestion_cabina cabina)
        {
            ConexionBD cbd = new ConexionBD();
            cbd.insertarCabinas(cabina);
        }

        /// <summary>
        /// Metodo para cambiar el status de la cabina
        /// </summary>
        public void cambioEstatusCabina(int id_cabina)
        {
            ConexionBD cbd = new ConexionBD();
            cbd.estatusCabina(id_cabina);
        }
    }
}