using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.DataAccess.Domain
{
    public class Ciudad : Entidad
    {
        public String _nombre { get; set; }
        public Pais _pais { get; set; }
        public int _fkPais { get; set; }

        public Ciudad(int id, String nombre, Pais pais) {
            this._id = id;
            this._nombre = nombre;
            this._pais = pais;
        }

        public Ciudad(int id, String nombre, int fkPais)
        {
            this._id = id;
            this._nombre = nombre;
            this._fkPais = fkPais;
        }

        public Ciudad() { }
    }
}