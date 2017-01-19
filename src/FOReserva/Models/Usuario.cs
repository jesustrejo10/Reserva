using FOReserva.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace FOReserva.Models
{
    public class Usuario : Entidad
    {
        #region Atributos
        public string _correo { get; set; }
        public string _nombre { get; set; }
        public string _apellido { get; set; }
        public int _id;
        #endregion

        #region Constructores
        public Usuario()
        {
        }

        public Usuario(string nombre, string apellido, string correo, int id)
        {
           this._correo = correo;
           this._nombre = nombre;
           this._apellido = apellido;
           this._id = id;
        }

        public Usuario(int id)
        {
            this._id = id;
        }

        #endregion

         public int Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }
    }
}