using FOReserva.Models.ORM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;

namespace FOReserva.Models.ReservaHabitacion
{
    using Usuario = TMPUsuario;
    using Errores;
    using Hotel = TMPHotel;

    public class Cvista_ReservaHabitacion
    {
        public enum EstadoReserva { Ocupando, Activo, Expiro, Cancelo }

        public Hotel Hotel { get; set; }
        public Usuario Usuario { get; set; }
        public int Id { get; set; }
        public int Habitacion { get; set; }
        public System.DateTime FechaLlegada { get; set; }
        public int CantidadDias { get; set; }
        public Nullable<System.DateTime> FechaPartida { get; set; }
        public EstadoReserva Estado { get; set; }

        public Cvista_ReservaHabitacion() : base()
        {
            
        }

        public static List<Cvista_ReservaHabitacion> ReservasDeUsuario(int usu_id)
        {
            try
            {
                var registros = from datos in DB.Singleton().M20_UsuarioHistorialReservaHabitacion(id_usuario: usu_id)
                                select new Cvista_ReservaHabitacion
                                {
                                    Hotel = new Hotel
                                    {
                                        Codigo = datos.hot_id,
                                        Nombre = datos.hot_nombre
                                    },
                                    Usuario = new Usuario
                                    {
                                        Codigo = datos.usu_id,
                                        Nombre = datos.fullname
                                    },
                                    Id = datos.rha_id,
                                    Habitacion = datos.rha_habitacion,
                                    CantidadDias = datos.rha_cantidad_dias,
                                    FechaLlegada = datos.rha_fecha_llegada,
                                    FechaPartida = datos.rha_fecha_partida,
                                    Estado = (EstadoReserva)datos.rha_estado
                                };

                return registros.ToList();
            }
            catch (Exception ex)
            {
                Utilidad.RegistrarLog(new ReservaHabitacionException("Ocurrio un problema al obtener mis reservas.", ex));
            }
            return null;
        }

        public static List<Cvista_ReservaHabitacion> ReservasEnHotel(int hot_id)
        {
            try
            {
                var registros = from datos in DB.Singleton().M20_HotelHistorialReservaHabitacion(id_hotel: hot_id)
                                select new Cvista_ReservaHabitacion
                                {
                                    Hotel = new Hotel
                                    {
                                        Codigo = datos.hot_id,
                                        Nombre = datos.hot_nombre
                                    },
                                    Usuario = new Usuario
                                    {
                                        Codigo = datos.usu_id,
                                        Nombre = datos.fullname
                                    },
                                    Id = datos.rha_id,
                                    Habitacion = datos.rha_habitacion,
                                    CantidadDias = datos.rha_cantidad_dias,
                                    FechaLlegada = datos.rha_fecha_llegada,
                                    FechaPartida = datos.rha_fecha_partida,
                                    Estado = (EstadoReserva)datos.rha_estado
                                };

                return registros.ToList();
            }
            catch (Exception ex)
            {
                Utilidad.RegistrarLog(new ReservaHabitacionException("Ocurrio un problema al obtener mis reservas.", ex));
            }
            return null;
        }

        public void CargarDesdeDB()
        {
            try
            {
                if (this.Id < 1)
                    throw new ReservaHabitacionException("Se requiere el Id de la reserva para cargar la informacion de la base de datos.");
                var registro = from data in DB.Singleton().M20_DetalleReservaHabitacion(id_reserva: Id)
                                select data;
                var datos = registro.First();
                if (datos != null) { 
                    this.Hotel = new Hotel
                    {
                        Codigo = datos.hot_id,
                        Nombre = datos.hot_nombre
                    };
                this.Usuario = new Usuario
                {
                    Codigo = datos.usu_id,
                    Nombre = datos.fullname
                };
                this.Habitacion = datos.rha_habitacion;
                this.CantidadDias = datos.rha_cantidad_dias;
                this.FechaLlegada = datos.rha_fecha_llegada;
                this.FechaPartida = datos.rha_fecha_partida;
                this.Estado = (EstadoReserva)datos.rha_estado;
                }
            }
            catch (Exception ex)
            {
                Utilidad.RegistrarLog(new ReservaHabitacionException(String.Format("Ocurrio un problema al obtener la reserva con id ({0}).", Id), ex));
            }
        }

        public void GuardarEnLaDB() {

        }
    }
}