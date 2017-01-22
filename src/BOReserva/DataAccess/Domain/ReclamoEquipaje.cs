using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.DataAccess.Domain
{
    /// <summary>
    /// Clase Reclamo de Equipaje
    /// </summary>
    public class ReclamoEquipaje : Entidad
    {
        public String _descripcionReclamo { get; set; }
        public String _fechaReclamo { get; set; }
        public String _estadoReclamo { get; set; }
        public int _pasajero { get; set; }
        public int _equipaje { get; set; }

        /// <summary>
        /// constructor de la clase sin parametros
        /// </summary>
        public ReclamoEquipaje() { }

        /// <summary>
        /// Constructor de la clase con parametros
        /// </summary>
        /// <param name="descripcionReclamo">Descripcion del reclamo</param>
        /// <param name="fechaReclamo">Fecha del reclamo</param>
        /// <param name="estadoReclamo">Estado del reclamo (abierto, cerrado)</param>
        /// <param name="pasajero">Pasajero involucrado</param>
        /// <param name="equipaje">Equipaje extraviado</param>
        public ReclamoEquipaje(String descripcionReclamo, String fechaReclamo, String estadoReclamo, int pasajero, int equipaje)
        {
            this._descripcionReclamo = descripcionReclamo;
            this._fechaReclamo = fechaReclamo;
            this._estadoReclamo = estadoReclamo;
            this._pasajero = pasajero;
            this._equipaje = equipaje;
        }

        /// <summary>
        /// Constructor de la clase con ID
        /// </summary>
        /// <param name="id">ID a asignar</param>
		/// <param name="descripcionReclamo">Descripcion del reclamo</param>
        /// <param name="fechaReclamo">Fecha del reclamo</param>
        /// <param name="estadoReclamo">Estado del reclamo (abierto, cerrado)</param>
        /// <param name="pasajero">Pasajero involucrado</param>
        /// <param name="equipaje">Equipaje extraviado</param>
        public ReclamoEquipaje(int id, String descripcionReclamo, String fechaReclamo, String estadoReclamo, int pasajero, int equipaje)
        {
            this._id = id;
            this._descripcionReclamo = descripcionReclamo;
            this._fechaReclamo = fechaReclamo;
            this._estadoReclamo = estadoReclamo;
            this._pasajero = pasajero;
            this._equipaje = equipaje;
        }
    }
}