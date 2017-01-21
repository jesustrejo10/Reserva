using FOReserva.Controllers.PatronComando;
using FOReserva.Controllers.PatronComando.M16;
using FOReserva.DataAccess.Domain;
using FOReserva.Controllers.PatronComando.M19;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BOReserva.Controllers.PatronComando;

namespace FOReserva.Controllers.PatronComando
{
    /// <summary>
    /// Fabrica de todos los comandos de la aplicacion.
    /// Esta clase es utilizada para instanciar a los comandos
    /// </summary>
    public class FabricaComando
    {
        #region M16 GestionReclamos
        /// <summary>
        /// Metodo creado con la finalidad de instanciar el comando
        /// M09_COAgregarReclamo
        /// </summary>
        /// <param name="e">Recibe la una entidad de tipo Reclamo</param>
        /// <returns>Retorna un comando con el parametro adjuntado como atributo.</returns>
        public static Command<String> crearM16AgregarReclamo(Entidad e)
        {

            return new M16_COAgregarReclamo((Reclamo)e);

        }

        public static Command<List<Reclamo>> consultarReclamosDeUsuario(int _idUsuario)
        {

            return new M16_COConsultarReclamos(_idUsuario);

        }

        public static Command<int> modificarReclamo(Reclamo reclamo)
        {
            return new M16_COModificarReclamo(reclamo);
        }

        public static Command<int> eliminarReclamo(int _idReclamo)
        {
            return new M16_COEliminarReclamo(_idReclamo);
        }

        public static Command<Entidad> consultarReclamo(int idReclamo)
        {

            return new M16_COConsultarReclamoDetalle(idReclamo);

        }
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