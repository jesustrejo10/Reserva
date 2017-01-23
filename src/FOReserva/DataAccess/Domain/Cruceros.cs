using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.DataAccess.Domain
{
    public class Cruceros : Entidad
    {
        //public int _id { get; set; }
        public string _nombre { get; set; }

        public Cruceros()
        {

        }

        public Cruceros(int id, String nombre)
        {
            this._id = id;
            this._nombre = nombre;
        }
    }

    
}