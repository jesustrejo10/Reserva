using BOReserva.Controllers.PatronComando;
using BOReserva.DataAccess.DataAccessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.M10.Comando.gestion_restaurantes
{
    /// <summary>
    /// Clase comando para cargar los Horarios de los Restaurante
    /// </summary>
    public class M10_COCargarHorario : Command<List<String>>
    {
        /// <summary>
        /// Metodo para cargar horarios en el combobox
        /// </summary>
        /// <returns></returns>
        public override List<string> ejecutar()
        {
            return FabricaDAO.listarHorario();
        }
    }
}