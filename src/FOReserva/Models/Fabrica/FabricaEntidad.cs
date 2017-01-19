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
        public static Lugar inicializarLugar(int idLugar, string nombreLugar)
        {
            return new Lugar(idLugar, nombreLugar);
        }

        public static List<Lugar> inicializarListaLugar()
        {
            return new List<Lugar>();
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