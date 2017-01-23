using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.DataAccess.Domain
{
    /// <summary>
    /// Clase Creada para crear Ciudad Habitacion 
    /// </summary>
    public class CiudadHab : Entidad
    {
        public int _idR;
        public String _lugar;
        /// <summary>
        /// Constructor de Ciudad Habitacion
        /// </summary>
        /// <param name="idLugar">El id de Lugar</param>
        /// <param name="Lugar">Nombre del Lugar</param>
           public CiudadHab(int idlugar,String lugar) 
        {
            this._idR = idlugar;
            this._lugar = lugar;
        }

    }
}