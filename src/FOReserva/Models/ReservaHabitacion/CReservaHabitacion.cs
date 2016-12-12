using FOReserva.Models.Hoteles;
using FOReserva.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.Models.ReservaHabitacion
{
    using Errores;
    using Usuario = CUsuario;
    using Hotel = CHotel;
    using ORM;

    public class CReservaHabitacion
    {
        public enum EstadoReserva { Ocupando, Activo, Expiro, Cancelo }

        public Hotel Hotel { get; set; }
        public Usuario Usuario { get; set; }
        public int Codigo { get; set; }
        public int Habitacion { get; set; }
        public System.DateTime FechaLlegada { get; set; }

        public int CantidadDias { get; set; }
        public Nullable<System.DateTime> FechaPartida { get; set; }
        public EstadoReserva Estado { get; set; }

        public CReservaHabitacion()
        {

        }

        internal static List<Hotel> BuscarHoteles(int id_ciudad, DateTime fecha_llegada, int cantidad_dias)
        {
            try
            {
                var registros = from datos in DB.Singleton().M20_BuscarHotelesPorCiudad(id_ciudad, cantidad_dias, fecha_llegada)
                                select new Hotel
                                {
                                    Codigo = datos.hot_id,
                                    Nombre = datos.hot_nombre,
                                    EmailContacto = datos.hot_email,
                                    CantidadHabitacionesDisponible = datos.hot_cantidad_habitaciones_disponible.Value
                                };

                return registros.ToList();
            }
            catch (Exception ex)
            {
                Utilidad.RegistrarLog(new ReservaHabitacionException("Ocurrio un problema al obtener los hoteles.", ex));
            }
            return null;
        }

        public static bool GenerarReserva(Cvista_ReservarHabitacion reserva)
        {
            try
            {
                var resultado = from datos in DB.Singleton().M20_GenerarReservaHabitacion(reserva.HotId, reserva.UsuId, reserva.CantidadDias, reserva.FechaLlegada)
                                select datos;

                return resultado.First().Estatus == 0;
            }
            catch (Exception ex)
            {
                Utilidad.RegistrarLog(new ReservaHabitacionException("Ocurrio un problema al obtener los hoteles.", ex));
            }
            return false;
        }

        public static List<CCiudad> ObtenerCiudades()
        {
            try
            {
                var registros = from datos in DB.Singleton().M20_ObtenerCiudades()
                                select new CCiudad
                                {
                                    Codigo = datos.lug_id,
                                    Nombre = datos.lug_nombre
                                };

                return registros.ToList();
            }
            catch (Exception ex)
            {
                Utilidad.RegistrarLog(new ReservaHabitacionException("Ocurrio un problema al obtener las ciudades.", ex));
            }
            return null;
        }

        public static List<CReservaHabitacion> ReservasDeUsuario(int usu_id)
        {
            try
            {
                var registros = from datos in DB.Singleton().M20_UsuarioHistorialReservaHabitacion(id_usuario: usu_id)
                                select new CReservaHabitacion
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
                                    Codigo = datos.rha_id,
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

        public static List<CReservaHabitacion> ReservasEnHotel(int hot_id)
        {
            try
            {
                var registros = from datos in DB.Singleton().M20_HotelHistorialReservaHabitacion(id_hotel: hot_id)
                                select new CReservaHabitacion
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
                                    Codigo = datos.rha_id,
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
                if (this.Codigo < 1)
                    throw new ReservaHabitacionException("Se requiere el Id de la reserva para cargar la informacion de la base de datos.");
                var registro = from data in DB.Singleton().M20_DetalleReservaHabitacion(id_reserva: Codigo)
                               select data;
                var datos = registro.First();
                if (datos != null)
                {
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
                Utilidad.RegistrarLog(new ReservaHabitacionException(String.Format("Ocurrio un problema al obtener la reserva con id ({0}).", Codigo), ex));
            }
        }

        public void GuardarEnLaDB()
        {

        }
    
    }
}