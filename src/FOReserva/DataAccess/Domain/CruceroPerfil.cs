using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.DataAccess.Domain
{
    public class CruceroPerfil : Entidad
    {

        public string _fechaReserva { get; set; }
        public int _cantidadPasajeros { get; set; }
        public int _fkUsuario { get; set; }
        public string _fkFecha { get; set; }
        public int _fkCrucero { get; set; }
        public int _fk_crucero { get; set; }
        public int _fkRuta { get; set; }
        public string _fk_ruta { get; set; }

        public string _id_reserva { get; set; }
        public string _fecha_inicio { get; set; }
        public string _fecha_fin { get; set; }
        public string _origen { get; set; }
        public string _destino { get; set; }
        public string _crucero { get; set; }
        public string _status { get; set; }
        public string _numeroPasajeros { get; set; }

        public CruceroPerfil(string fechaReserva, int cantidadPasajeros, string nombreCrucero, string fechaIda, string fechaRegreso, string origen, string destino, string status)
        {
            this._fechaReserva = fechaReserva;
            this._cantidadPasajeros = cantidadPasajeros;
            this._crucero = nombreCrucero;
            this._fecha_inicio = fechaIda;
            this._fecha_fin = fechaRegreso;
            this._origen = origen;
            this._destino = destino;
            this._status = status;
        }
   
        public CruceroPerfil(string crucero, string fechaIni, string fechaFin)
        {
            this._crucero = crucero;
            this._fecha_inicio = fechaIni;
            this._fecha_fin = fechaFin;
        }

        public CruceroPerfil(int idCrucero, string nombreCrucero, string fecha_inicio, string fecha_fin, string origen, string destino, string ruta)
        {
            this._id = idCrucero;
            this._crucero = nombreCrucero;
            this._fecha_inicio = fecha_inicio;
            this._fecha_fin = fecha_fin;
            this._origen = origen;
            this._destino = destino;
            this._fk_ruta = ruta;
        }

        /*public CruceroPerfil(string idCrucero, string origen, string destino, string crucero, string fechaIni, string fechaFin, string idRuta)
        {
            this._fk_crucero = idCrucero;
            this._origen = origen;
            this._destino = destino;
            this._crucero = crucero;
            this._fecha_inicio = fechaIni;
            this._fecha_fin = fechaFin;
            this._fk_ruta = idRuta;
        }*/

        public CruceroPerfil(string fechaReserva, int cantidadPasajeros, int usuario, int crucero, int ruta, string fecha, string estatus)
        {
            this._fechaReserva = fechaReserva;
            this._cantidadPasajeros = cantidadPasajeros;
            this._fkUsuario = usuario;
            this._fkCrucero = crucero;
            this._fkRuta = ruta;
            this._fkFecha = fecha;
            this._status = estatus;
        }
    }
}