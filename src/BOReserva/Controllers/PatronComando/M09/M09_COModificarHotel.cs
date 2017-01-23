﻿using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using BOReserva.DataAccess.Model;
using BOReserva.Excepciones.M09;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando.M09
{
    /// <summary>
    /// Comando Modificar Hoteles
    /// </summary>
    public class M09_COModificarHotel : Command<String>
    {
        Hotel _hotel;
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        /// <param name="hotel">Hotel a modificar</param>
        /// <param name="id">Identificador del hotel a modificar</param>
        public M09_COModificarHotel(Entidad hotel, int id) { 
            this._hotel = (Hotel) hotel;
            this._hotel._id = id;
        }
        /// <summary>
        /// Metodo implementado proveniente de la clase abstracta Command
        /// </summary>
        /// <returns>Retorna un String</returns>
        public override String ejecutar(){
            try
            {
<<<<<<< HEAD
                IDAO daoHotel = FabricaDAO.instanciarDaoHotel();
                Entidad test = daoHotel.Modificar(_hotel);
                Hotel hotel = (Hotel)test;
                //Actualice un Hotel en BD. necesito refrescarlo en Cache
                Cache.actualizarMapHoteles(hotel);
                return "Se modifico el hotel exitosamente, sera redirigido al listado de hoteles";
            }
=======
            IDAO daoHotel = FabricaDAO.instanciarDaoHotel();
            Entidad test = daoHotel.Modificar(_hotel);
            Hotel hotel = (Hotel)test;
            //Actualice un Hotel en BD. necesito refrescarlo en Cache
            Cache.actualizarMapHoteles(hotel);
            return ResourceM09Command.ModificoCorrectamente;
        }
>>>>>>> 05edc1d97746531a894babd5536930cec65c6478
            catch (ReservaExceptionM09 ex)
            {
                return (ex.Codigo);
            }
        }

    }
}