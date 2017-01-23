using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.DataAccess.Domain
{
    ///<summary>
    ///Clase modulo de dominio
    ///</summary>
    public class Modulo : Entidad
    {
        ///<summary>
        ///nombre modulo
        ///</summary>
        public String _nombre { get; set; }

        ///<summary>
        ///id del modulo
        ///</summary>
        public int _idModulo { get; set; }

        ///<summary>
        ///Constructor
        ///</summary>
        public Modulo(int id, string nombre) : base(id)
        {
            this._nombre = nombre;
        }

        ///<summary>
        ///Constructor
        ///</summary>
        public Modulo()
        {
        }
    }
}