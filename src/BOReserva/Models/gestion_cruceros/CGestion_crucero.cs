using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Models.gestion_cruceros
{
    public class CGestion_crucero
    {

        public int _idCrucero { get; set; }
        public String _nombreCrucero { get; set; }
        public String _companiaCrucero { get; set; }
        public int _capacidadCrucero { get; set; }
        public String _estatus { get; set; }
        public String _imagen { get; set; }
        public CGestion_cabina[] _cabina { get; set; }
        public List<CGestion_cabina> cabinas { get; set; }

        public CGestion_crucero(string _nombreCrucero, string _companiaCrucero, int _capacidadCrucero)
        {
            this._nombreCrucero = _nombreCrucero;
            this._companiaCrucero = _companiaCrucero;
            this._capacidadCrucero = _capacidadCrucero;
        }

        public CGestion_crucero()
        {
        }

        public CGestion_crucero(int _idCrucero, string _nombreCrucero, string _companiaCrucero, int _capacidadCrucero)
        {
            this._idCrucero = _idCrucero;
            this._nombreCrucero = _nombreCrucero;
            this._companiaCrucero = _companiaCrucero;
            this._capacidadCrucero = _capacidadCrucero;
        }

        public void AgregarCrucero(CGestion_crucero crucero)
        {
            ConexionBD cbd = new ConexionBD();
            cbd.insertarCruceros(crucero);
        }

        public void ModificarCrucero(CGestion_crucero crucero)
        {
            ConexionBD cbd = new ConexionBD();
            cbd.modificarCruceros(crucero);
        }

        public void EliminarCrucero(int id_crucero)
        {
            ConexionBD cbd = new ConexionBD();
            cbd.eliminarCrucero(id_crucero);
        }

        public void cambiarEstatusCruceros(int id_crucero)
        {
            ConexionBD cbd = new ConexionBD();
            cbd.cambiarEstado(id_crucero);
        }
    }
}