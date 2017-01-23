using FOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.Models.gestion_reserva_automovil
{
    public class CUsuario : Entidad
    {
        #region Atributos
        public string _correo { get; set; }
        public string _nombre { get; set; }
        public string _apellido { get; set; }        
        #endregion

        #region Constructores
        public CUsuario()
        {
        }

        public CUsuario(string nombre, string apellido, string correo, int id)
        {
           this._correo = correo;
           this._nombre = nombre;
           this._apellido = apellido;
           this._id = id;
        }

        public CUsuario(int id)
        {
            this._id = id;
        }

        #endregion
    }
}