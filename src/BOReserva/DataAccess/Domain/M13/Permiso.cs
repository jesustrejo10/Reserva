﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.DataAccess.Domain
{
    public class Permiso : Entidad
    {
        public String _nombre { get; set; }

        public int _id { get; set; }

        public Modulo modulo { get; set; }

        public Permiso(int id, string nombre) : base(id)
        {
            this._nombre = nombre;
        }

        public Permiso()
        {
        }
    }
}