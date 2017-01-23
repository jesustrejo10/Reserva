using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.DataAccess.Domain
{
    /// <summary>
    /// Clase Creada para crear el objeto Reserva Habitacion
    /// </summary>
    public class ReservaHabitacion : Entidad
    {
        public String _fecha_reserva { get; set; }
        public String _fecha_llegada { get; set; }
        public String _estado { get; set; }
        public String _cant_dias { get; set; }
        public String _fk_habitacion { get; set; }
        public String _fk_usuario { get; set; }
        public new String _id { get; set; }
        public int _idR { get; set; }
        public String _lugar { get; set; }
        public String _hotel { get; set; }
        public int _id_hotel { get; set; }
        public int _cantidad { get; set; }
        public int _id_usuario { get; set; }

        public ReservaHabitacion() { }
        /// <summary>
        /// Constructor de Reserva Habitacion
        /// </summary>
        /// <param name="fecha_reserva">La fecha de la reserva</param>
        /// <param name="fecha_llegada">La fecha de llegada</param>
        /// <param name="estado">Estado de la reserva</param>
        /// <param name="cant_dias">Cantidad de dias</param>
        /// <param name="fk_habitacion">Fk de la Habitacion</param>
        /// <param name="fk_usuario">Fk del usuario</param>
        public ReservaHabitacion(String fecha_reserva, String fecha_llegada, String estado, String cant_dias, String fk_habitacion, String fk_usuario)
        {
            this._fecha_reserva = fecha_reserva;
            this._fecha_llegada = fecha_llegada;
            this._estado = estado;
            this._cant_dias = cant_dias;
            this._fk_habitacion = fk_habitacion;
            this._fk_usuario = fk_usuario;
        }
        /// <summary>
        /// Constructor de Reserva Habitacion
        /// </summary>
        /// <param name="fecha_reserva">La fecha de la reserva</param>
        /// <param name="fecha_llegada">La fecha de llegada</param>
        /// <param name="estado">Estado de la reserva</param>
        /// <param name="cant_dias">Cantidad de dias</param>
        /// <param name="fk_habitacion">Fk de la Habitacion</param>
        /// <param name="fk_usuario">Fk del usuario</param>
        /// <param name="id">Id de la reserva</param>
        public ReservaHabitacion(String fecha_reserva, String fecha_llegada, String estado, String cant_dias, String fk_habitacion, String fk_usuario, String id)
        {
            this._fecha_reserva = fecha_reserva;
            this._fecha_llegada = fecha_llegada;
            this._estado = estado;
            this._cant_dias = cant_dias;
            this._fk_habitacion = fk_habitacion;
            this._fk_usuario = fk_usuario;
            this._id = id;
        }
        /// <summary>
        /// Constructor de Reserva Habitacion
        /// </summary>
        /// <param name="fecha_reserva">La fecha de la reserva</param>
        /// <param name="fecha_llegada">La fecha de llegada</param>
        /// <param name="estado">Estado de la reserva</param>
        /// <param name="cant_dias">Cantidad de dias</param>
        /// <param name="fk_habitacion">Fk de la Habitacion</param>
        /// <param name="fk_usuario">Fk del usuario</param>
        /// <param name="id">Id de la reserva</param>
        public ReservaHabitacion(String fecha_reserva, String fecha_llegada, String estado, String cant_dias, String fk_habitacion, String fk_usuario, int id)
        {
            this._fecha_reserva = fecha_reserva;
            this._fecha_llegada = fecha_llegada;
            this._estado = estado;
            this._cant_dias = cant_dias;
            this._fk_habitacion = fk_habitacion;
            this._fk_usuario = fk_usuario;
            this._idR = id;
        }
        /// <summary>
        /// Constructor de Reserva Habitacion
        /// </summary>
        /// <param name="nombre_lugar">Nombre del Lugar</param>
        /// <param name="nombre_hotel">Nombre del Hotel</param>
        /// <param name="cant_habitaciones">Cantidad de Habitaciones</param>
        public ReservaHabitacion(String nombre_lugar, String nombre_hotel, int cant_habitaciones)
        {
            this._lugar = nombre_lugar;
            this._hotel = nombre_hotel;
            this._cantidad = cant_habitaciones;
        }
        /// <summary>
        /// Constructor de Reserva Habitacion
        /// </summary>
        /// <param name="nombre_lugar">Nombre del Lugar</param>
        /// <param name="id_lugar">Id del Lugar</param>
        public ReservaHabitacion(int idlugar,String lugar) 
        {
            this._idR = idlugar;
            this._lugar = lugar;
        }
        /// <summary>
        /// Constructor de Reserva Habitacion
        /// </summary>
        /// <param name="fecha_llegada">La fecha de llegada</param>
        /// <param name="cant_dias">Cantidad de dias</param>
        /// <param name="hotel">Fk de la Habitacion</param>
        /// <param name="usuario">Fk del usuario</param>
        public ReservaHabitacion(int cant_dias, String fecha_llegada, int hotel, int usuario )
        {
            this._cantidad = cant_dias;
            this._fecha_llegada = fecha_llegada;
            this._id_hotel = hotel;
            this._id_usuario = usuario;

        }
        /// <summary>
        /// Constructor de Reserva Habitacion
        /// </summary>
        /// <param name="fecha_reserva">La fecha de la reserva</param>
        /// <param name="fecha_llegada">La fecha de llegada</param>
        /// <param name="estado">Estado de la reserva</param>
        /// <param name="cant_dias">Cantidad de dias</param>
        /// <param name="name">Fk de la Habitacion</param>
        public ReservaHabitacion(String cant_dias, String fecha_reserva, String fecha_llegada, String estado, String name)
        {
            this._cant_dias = cant_dias; 
            this._fecha_reserva = fecha_reserva;
            this._fecha_llegada = fecha_llegada;
            this._estado = estado;            
            this._fk_habitacion = name;

        }

    }
}