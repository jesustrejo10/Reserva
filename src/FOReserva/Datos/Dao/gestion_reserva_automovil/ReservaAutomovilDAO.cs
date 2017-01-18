using FOReserva.Datos.Fabrica;
using FOReserva.Datos.InterfazDao.gestion_reserva_automovil;
using FOReserva.Models;
using FOReserva.Models.Fabrica;
using FOReserva.Models.Autos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace FOReserva.Datos.Dao.gestion_reserva_automovil
{
    public class ReservaAutomovilDAO : DAO, IReservaAutomovilDAO
    {

        /// <summary>
        /// Metodo para consultar restaurant segun el id de Lugar
        /// </summary>
        /// <param name="_restaurant">Variable tipo en entidad que luego debe ser casteada a su tipo para metodos get y set</param>
        /// <returns>Lista de Entidades, ya que se devuelve mas de una fila de la BD, se debe castear a su respectiva clase en el Modelo</returns>
        public List<Entidad> Consultar(Entidad _lugar)
        {
            return null;
        }

        /// <summary>
        /// Metodo que retorna restauran segun el id
        /// </summary>
        /// <param name="_restaurant"></param>
        /// <returns>Entidad</returns>
        public Entidad consultarRestaurantId(Entidad _restaurant)
        {
            return null;
        }

        /// <summary>
        /// Metodo para agregar restaurant
        /// </summary>
        /// <param name="_restaurant"></param>
        /// <returns>Se retorna true si fue exitoso</returns>
        public bool Crear(Entidad _restaurant)
        {
            return true;
        }

        /// <summary>
        /// Metodo para eliminar restaurante 
        /// </summary>
        /// <param name="_restaurant"></param>
        /// <returns>Retorna true si fue exitso</returns>
        public bool Eliminar(Entidad _restaurant)
        {
            return true;
        }

        /// <summary>
        /// Metodo para retornar lista de Lugares
        /// </summary>
        /// <returns>Se retorna una lista de entidad que luego debe ser casteada a su respectiva clase en el Modelo</returns>
        public List<Entidad> ListarLugar()
        {
            return null;
        }
    }
}