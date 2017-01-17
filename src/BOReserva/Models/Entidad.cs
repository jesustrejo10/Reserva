using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Models
{
    public abstract class Entidad
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public Entidad()
        {
            Id = 0;
        }

        public Entidad(int id)
        {
            Id = id;
        }
    }
}