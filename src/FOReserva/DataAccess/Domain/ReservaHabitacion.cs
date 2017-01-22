using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.DataAccess.Domain
{
    public class ReservaHabitacion : Entidad
    {
        public String _fecha_reserva { get; set; }
        public String _fecha_llegada { get; set; }
        public String _estado { get; set; }
        public String _cant_dias { get; set; }
        public String _fk_habitacion { get; set; }
        public String _fk_usuario { get; set; }
        public String _id { get; set; }
        public int _idR { get; set; }
        public String _lugar { get; set; }
        public String _hotel { get; set; }
        public int _id_hotel { get; set; }
        public int _cantidad { get; set; }
        public int _id_usuario { get; set; }

        public ReservaHabitacion() { }

        public ReservaHabitacion(String fecha_reserva, String fecha_llegada, String estado, String cant_dias, String fk_habitacion, String fk_usuario)
        {
            this._fecha_reserva = fecha_reserva;
            this._fecha_llegada = fecha_llegada;
            this._estado = estado;
            this._cant_dias = cant_dias;
            this._fk_habitacion = fk_habitacion;
            this._fk_usuario = fk_usuario;
        }

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

        public ReservaHabitacion(String nombre_lugar, String nombre_hotel, int cant_habitaciones)
        {
            this._lugar = nombre_lugar;
            this._hotel = nombre_hotel;
            this._cantidad = cant_habitaciones;
        }

        public ReservaHabitacion(int idlugar,String lugar) 
        {
            this._idR = idlugar;
            this._lugar = lugar;
        }

        public ReservaHabitacion(int cant_dias, String fecha_llegada, int hotel, int usuario )
        {
            this._cantidad = cant_dias;
            this._fecha_llegada = fecha_llegada;
            this._id_hotel = hotel;
            this._id_usuario = usuario;

        }

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