using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BOReserva.Models.gestion_usuarios
{
    public class PersistenciaUsuario
    {
        /// <summary>
        /// Método para agregar un usuario
        /// </summary>
        /// <param name="usuario">Es el objeto que se va a agregar a la BD</param>
        /// <returns>Retorna true si se agrega en la BD</returns>
        public bool Agregar(CUsuario usuario)
        {
            Parametro parametro;
            try
            {
                List<Parametro> parametros = new List<Parametro>();
                parametro = new Parametro("@usu_nombre", SqlDbType.VarChar, ((CUsuario)usuario).nombreUsuario, false);
                parametros.Add(parametro);
                parametro = new Parametro("@usu_apellido", SqlDbType.VarChar, ((CUsuario)usuario).nombreUsuario, false);
                parametros.Add(parametro);

            }

        }
    }
}