using FOReserva.Models.gestion_reserva_automovil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FOReserva.Models.Fabrica
{
    public static class FabricaEntidad
    {

        #region Modulo 19

        public static List<CReservaAutomovilModelo> inicializarListaReserva()
        {
            return new List<CReservaAutomovilModelo>();
        }

        public static CReservaAutomovilModelo inicializarReserva(string fecha_ini, string fecha_fin, string horario_ini,
                                                                string horario_fin, int idUsuario, string idAuto, int idOri,
                                                                int idDest,int estatus)
        {
            return new CReservaAutomovilModelo(fecha_ini, fecha_fin, horario_ini, horario_fin, idUsuario, idAuto, idOri, idDest,estatus);
        }

        public static CReservaAutomovilModelo inicializarReserva(int id, string fecha_ini, string fecha_fin, string horario_ini,
                                                                string horario_fin, int idUsuario, string idAuto, int idOri, int idDest,
                                                                int estatus)
        {
            return new CReservaAutomovilModelo(id, fecha_ini, fecha_fin, horario_ini, horario_fin, idUsuario, idAuto, idOri, idDest, estatus);
        }

        public static CReservaAutomovilModelo inicializarReserva()
        {
            return new CReservaAutomovilModelo();
        }
        public static CLugar inicializarLugar(int idLugar, string nombreLugar)
        {
            return new CLugar(idLugar, nombreLugar);
        }

        public static List<CLugar> inicializarListaLugar()
        {
            return new List<CLugar>();
        }

        public static CUsuario inicializarUsuario(string nombre, string apellido, string correo, int id)
        {
            return new CUsuario(nombre,apellido,correo,id);
        }

        public static CUsuario inicializarUsuario(int id)
        {
            return new CUsuario(id);
        }

        public static CAutomovil inicializarAutomovil(string matricula, string modelo, string fabricante, int anio, double kilometraje, int cantPasajeros, string tipo, double precioCompra, double precioAlquiler, double penalidadDiaria, string fechaRegistro, string color, int disponibilidad, string transmision, int idCiudad)
        {
            return new CAutomovil(matricula, modelo, fabricante, anio, kilometraje, cantPasajeros, tipo, precioCompra, precioAlquiler, penalidadDiaria, fechaRegistro, color, disponibilidad, transmision, idCiudad);
        }

        #endregion

        #region Global

        public static List<Entidad> asignarListaDeEntidades()
        {
            return new List<Entidad>();
        }

        #endregion

    }
}