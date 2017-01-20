using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BOReserva.Models.gestion_vuelo
{
    public class CrearVueloMO : VueloViewModel
    {
        
        /// <summary>
        /// Constructor con ciudadesOrigen y comboVuelo
        /// </summary>
        /// <param name="ciudadesOrigen"> lista de ciudades con rutas areas activas</param>
        /// <param name="combo">Lista de los valors del combo de status del vuelo</param>
        public CrearVueloMO(IEnumerable<SelectListItem> ciudadesOrigen, IEnumerable<SelectListItem> comboStatus)
        {
            this._ciudadesOrigen = ciudadesOrigen;
            this._comboStatus = comboStatus;
        }
    }
}