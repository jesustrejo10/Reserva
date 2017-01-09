using BOReserva.LogicaReserva.Comando.gestion_restaurantes;
using BOReserva.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BOReserva.LogicaReserva.Fabrica
{
    public static class FabricaComando
    {
        #region Modulo 1
        #endregion

        #region Modulo 2
        #endregion

        #region Modulo 3
        #endregion

        #region Modulo 4
        #endregion

        #region Modulo 5
        #endregion

        #region Modulo 6
        #endregion

        #region Modulo 7
        #endregion

        #region Modulo 8
        #endregion

        #region Modulo 9
        #endregion

        #region Modulo 10 Gestion Restaurante

        #region Comandos Generales 
        /// <summary>
        /// Metodo que recibe un comando para Crear, Actualizar, Eliminar o Consultar
        /// la variable comando recibe comandosGlobales.CREAR, comandosGlobales.ELIMINAR
        /// comandosGlobales.ACTUALIZAR, comandosGlobales.CONSULTAR 
        /// </summary>
        /// <param name="comando"></param>
        /// <returns>regresa un tipo Objecto que debe ser casteado segun sea el caso</returns>
        public static Object comandosRestaurant(comandosGlobales comando, Entidad _objeto)
        {
            switch (comando)
            {
                case comandosGlobales.CREAR:
                    return new comandoCrearRestaurant(_objeto);

                case comandosGlobales.ELIMINAR:
                    return new comandoEliminarRestaurant(_objeto);

                case comandosGlobales.ACTUALIZAR:
                    return new comandoActualizarRestaurant(_objeto);

                case comandosGlobales.CONSULTAR:
                    return new comandoConsultarRestaurant(_objeto);
                default:
                    return new comandoConsultarRestaurant(_objeto);
            }
        }
        #endregion
        #region comandos de las interfaces Restaurant
        public static Object comandosVistaRestaurant(comandoVista comando)
        {
            switch (comando)
            {
                case comandoVista.CARGAR_LUGAR:
                    return new comandoConsultarLugar();
                case comandoVista.CARGAR_HORA:
                    return new comandoCargarHorario();
                default:
                    return new comandoConsultarLugar();
            }

        }
        #endregion


        public enum comandoVista
        {
            CARGAR_LUGAR,
            CARGAR_HORA
        }



        //#region Crear Restaurant

        //#endregion

        //#region Actualizar Restaurant

        //#endregion

        //#region Eliminar Restaurant

        //#endregion

        //#region Consultar Restaurant

        //#endregion

        #endregion

        #region Modulo 11
        #endregion

        #region Modulo 12
        #endregion

        #region Modulo 13
        #endregion

        #region Modulo 14
        #endregion

        #region Comandos Globales

        public enum comandosGlobales
        {
            CREAR,
            ELIMINAR,
            ACTUALIZAR,
            CONSULTAR
        }

        public static List<Lugar> listaLugares(Lugar lugar)
        {
            List<Lugar> lista = new List<Lugar>();
            lista.Add(lugar);
            return lista;
        }
        #endregion
    }
}