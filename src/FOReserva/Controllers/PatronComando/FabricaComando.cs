using FOReserva.Controllers.PatronComando;
using FOReserva.DataAccess.Domain;
using FOReserva.Controllers.PatronComando.M19;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.Controllers.PatronComando
{
    /// <summary>
    /// Fabrica de todos los comandos de la aplicacion.
    /// Esta clase es utilizada para instanciar a los comandos
    /// </summary>
    public class FabricaComando
    {
        #region M16 GestionReclamos

        #endregion

        #region M19 Reserva Automovil

        public enum comandoVista
        {
            CARGAR_LUGAR,
            CARGAR_AUTOS
        }

        public enum comandoReservaAuto
        {
            NULO,
            CONSULTAR_ID
        }

        public enum comandosGlobales
        {
            CREAR,
            ELIMINAR,
            ACTUALIZAR,
            CONSULTAR
        }

        #region Comandos Generales
        /// <summary>
        /// Metodo que recibe un comando para Crear, Actualizar, Eliminar o Consultar
        /// la variable comando recibe comandosGlobales.CREAR, comandosGlobales.ELIMINAR
        /// comandosGlobales.ACTUALIZAR, comandosGlobales.CONSULTAR 
        /// </summary>
        /// <param name="comando"></param>
        /// <returns>regresa un tipo Objecto que debe ser casteado segun sea el caso</returns>
        public static Object comandosReservaAutomovil(comandosGlobales comando, comandoReservaAuto comandoR, Entidad _objeto)
        {
            switch (comando)
            {
                case comandosGlobales.CREAR:
                    return new M19_COCrearReserva(_objeto);

                case comandosGlobales.ELIMINAR:
                    return new M19_COEliminarReserva(_objeto);

                case comandosGlobales.ACTUALIZAR:
                    return new M19_COActualizarReserva(_objeto);

                case comandosGlobales.CONSULTAR:

                    switch (comandoR)
                    {
                        case comandoReservaAuto.NULO:
                            break;
                        case comandoReservaAuto.CONSULTAR_ID:
                            return new M19_COConsultarReservaId(_objeto);
                    }
                    return new M19_COConsultarReserva(_objeto);

                default:
                    return new M19_COConsultarReserva(_objeto);
            }
        }
        #endregion


        #region Comandos de las interfaces Reserva Automovil
        /// <summary>
        /// Devuelve los objetos para inicializar los combobox de la vista reserva automovil
        /// </summary>
        /// <param name="comando"></param>
        /// <returns></returns>
        public static Object comandosVistaReservaAutomovil(comandoVista comando, Entidad _objeto)
        {
            switch (comando)
            {
                case comandoVista.CARGAR_LUGAR:
                    return new M19_COConsultarLugar();
                case comandoVista.CARGAR_AUTOS:
                    return new M19_COConsultarAutos(_objeto);
                default:
                    return new M19_COConsultarLugar();
            }

        }
        #endregion

        public static List<Lugar> listaLugares(Lugar lugar)
        {
            List<Lugar> lista = new List<Lugar>();
            lista.Add(lugar);
            return lista;
        }
        #endregion
    }
}