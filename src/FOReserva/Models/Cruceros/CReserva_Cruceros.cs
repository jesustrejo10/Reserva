using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace FOReserva.Models.Cruceros
{
    public class CReserva_Cruceros
    {
        public string _fecha { get; set; }
        public int _cantidadPasajeros { get; set; }
        public int _fkUsuario { get; set; }
        public string _fkFecha { get; set; }
        public int _fkCrucero { get; set; }
        public string _fk_crucero { get; set; }
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


        public CReserva_Cruceros() { }

        public CReserva_Cruceros(string fecha, int cantidadPasajeros, int fkUsuario, string fkFecha, int fkCrucero, int fkRuta)
        {
            this._fecha = fecha;
            this._cantidadPasajeros = cantidadPasajeros;
            this._fkUsuario = fkUsuario;
            this._fkFecha = fkFecha;
            this._fkCrucero = fkCrucero;
            this._fkRuta = fkRuta;
        }

        public CReserva_Cruceros(string fecha, string origen, string destino, string crucero, string fechaIni, string fechaFin)
        {
            this._fecha = fecha;
            this._origen = origen;
            this._destino = destino;
            this._crucero = crucero;
            this._fecha_inicio = fechaIni;
            this._fecha_fin = fechaFin;
        }

        public CReserva_Cruceros(string origen, string destino, string crucero, string fechaIni, string fechaFin)
        {
            this._origen = origen;
            this._destino = destino;
            this._crucero = crucero;
            this._fecha_inicio = fechaIni;
            this._fecha_fin = fechaFin;
        }

        public CReserva_Cruceros(string crucero, string fechaIni, string fechaFin)
        {
            this._crucero = crucero;
            this._fecha_inicio = fechaIni;
            this._fecha_fin = fechaFin;
        }
        

        public CReserva_Cruceros(string fechaReserva, int cantidadPasajeros, int usuario, int crucero, int ruta, string fecha)
        {
            this._fecha = fechaReserva;
            this._cantidadPasajeros = cantidadPasajeros;
            this._fkUsuario = usuario;
            this._fkCrucero = crucero;
            this._fkRuta = ruta;
            this._fkFecha = fecha;
        }

        
        public CReserva_Cruceros(string fechaReserva, int cantidadPasajeros, int usuario, int crucero, int ruta, string fecha, string estatus)
        {
            this._fecha = fechaReserva;
            this._cantidadPasajeros = cantidadPasajeros;
            this._fkUsuario = usuario;
            this._fkCrucero = crucero;
            this._fkRuta = ruta;
            this._fkFecha = fecha;
            this._status = estatus;
        }

        public CReserva_Cruceros(string fechaReserva,int cantidadPasajeros,string nombre_crucero,string lugarOrigen,string lugarDestino,string fechaIda,string fechaVuelta, string estatus)
        {
            this._fecha = fechaReserva;
            this._cantidadPasajeros = cantidadPasajeros;
            this._crucero = nombre_crucero;
            this._origen = lugarOrigen;
            this._destino = lugarDestino;
            this._fecha_inicio = fechaIda;
            this._fecha_fin = fechaVuelta;
            this._status = estatus;
        }
        public CReserva_Cruceros(string idreserva, string fechaReserva, int cantidadPasajeros, string nombre_crucero, string lugarOrigen, string lugarDestino, string fechaIda, string fechaVuelta, string estatus)
        {
            this._id_reserva = idreserva;
            this._fecha = fechaReserva;
            this._cantidadPasajeros = cantidadPasajeros;
            this._crucero = nombre_crucero;
            this._origen = lugarOrigen;
            this._destino = lugarDestino;
            this._fecha_inicio = fechaIda;
            this._fecha_fin = fechaVuelta;
            this._status = estatus;
        }

        public CReserva_Cruceros(string idCrucero, string origen, string destino, string crucero, string fechaIni, string fechaFin, string idRuta)
        {
            this._fk_crucero = idCrucero;
            this._origen = origen;
            this._destino = destino;
            this._crucero = crucero;
            this._fecha_inicio = fechaIni;
            this._fecha_fin = fechaFin;
            this._fk_ruta = idRuta;
        }

        public CReserva_Cruceros(string idCrucero, string origen, string destino, string crucero, string fechaIni, string fechaFin, string numPasajeros, string idRuta)
        {
            this._crucero= idCrucero;
            this._origen = origen;
            this._destino = destino;
            this._fk_crucero = crucero;
            this._fecha_inicio = fechaIni;
            this._fecha_fin = fechaFin;
            this._numeroPasajeros= numPasajeros;
            this._fk_ruta = idRuta;
        }

        


    }
}