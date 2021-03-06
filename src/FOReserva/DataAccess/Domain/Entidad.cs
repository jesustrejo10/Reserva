﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.DataAccess.Domain
{
    /// <summary>
    /// Clase entidad, utilizada para poder acceder a todas las clases del DAO
    /// </summary>
    public class Entidad
    {
        /// <summary>
        /// Atributo propio de la clase entidad.
        /// utilizado para acceder a cada registro.
        /// </summary>
        public int _id { get; set; }

        /// <summary>
        /// Constructor Base.
        /// </summary>
        public Entidad()
        {
            this._id = 0;
        }

        /// <summary>
        /// Constructor con ID.
        /// </summary>
        /// <param name="ID"></param>
        public Entidad(int ID)
        {
            this._id = ID;
        }
    }
}