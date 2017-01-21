using FOReserva.Models;
using FOReserva.Models.Reclamos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FOReserva.Models.gestion_reserva_automovil;

namespace FOReserva.DataAccess.Domain
{
    /// <summary>
    /// Clase Creada con la finalidad de instanciar a cualquier objeto dentro del Dominio

    /// </summary>
    public class FabricaEntidad
    {

        public static List<Entidad> asignarListaDeEntidades()
        {
            return new List<Entidad>();
        }
        #region M16 Reclamos
        public static Entidad InstanciarReclamo (CAgregarReclamo reclamo)
        {
            String _tituloReclamo = reclamo._tituloReclamo;
            String _detalleReclamo = reclamo._detalleReclamo;
            String _fechaReclamo = reclamo._fechaReclamo;
            int _estadoReclamo = 1;
            int _usuarioReclamo = reclamo._usuarioReclamo;
            return new Reclamo(_tituloReclamo, _detalleReclamo, _fechaReclamo, _estadoReclamo, _usuarioReclamo);
        }
        #endregion


        #region Modulo 19

        public static List<CReservaAutomovil> inicializarListaReserva()
        {
            return new List<CReservaAutomovil>();
        }

        public static CReservaAutomovil inicializarReserva(string fecha_ini, string fecha_fin, string horario_ini,
                                                           string horario_fin, int idUsuario, int estatus, CAutomovil auto,
                                                           CLugar origen, CLugar destino)
        {
            return new CReservaAutomovil(fecha_ini, fecha_fin, horario_ini, horario_fin, idUsuario, estatus, auto, origen,destino);
        }

        public static CReservaAutomovil inicializarReserva(int id, string fecha_ini, string fecha_fin, string horario_ini,
                                                           string horario_fin, int idUsuario, int estatus, CAutomovil auto,
                                                           CLugar origen, CLugar destino)
        {
            return new CReservaAutomovil(id, fecha_ini, fecha_fin, horario_ini, horario_fin, idUsuario, estatus, auto, origen, destino);
        }

        public static CReservaAutomovil inicializarReserva()
        {
            return new CReservaAutomovil();
        }

        public static CLugar inicializarLugar(int idLugar, string nombreLugar)
        {
            return new CLugar(idLugar, nombreLugar);
        }

        public static CLugar inicializarLugar(string nombreLugar)
        {
            return new CLugar(nombreLugar);
        }


        public static List<Lugar> inicializarListaLugar()
        {
            return new List<Lugar>();
        }

        public static CUsuario inicializarUsuario(string nombre, string apellido, string correo, int id)
        {
            return new CUsuario(nombre, apellido, correo, id);
        }

        public static CUsuario inicializarUsuario(int id)
        {
            return new CUsuario(id);
        }

        public static CAutomovil inicializarAutomovil(string matricula, string modelo, string fabricante, int anio, double kilometraje, int cantPasajeros, string tipo, double precioCompra, double precioAlquiler, double penalidadDiaria, string fechaRegistro, string color, int disponibilidad, string transmision, int idCiudad)
        {
            return new CAutomovil(matricula, modelo, fabricante, anio, kilometraje, cantPasajeros, tipo, precioCompra, precioAlquiler, penalidadDiaria, fechaRegistro, color, disponibilidad, transmision, idCiudad);
        }

        public static CAutomovil inicializarAutomovil(string matricula, string modelo, string fabricante)
        {
            return new CAutomovil(matricula, modelo, fabricante); 
        }

        public static CAutomovil inicializarAutomovil(string matricula)
        {
            return new CAutomovil(matricula);
        }

        #endregion

    }
}
