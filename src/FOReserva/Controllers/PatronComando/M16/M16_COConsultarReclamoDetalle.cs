using FOReserva.Controllers.PatronComando;
using FOReserva.DataAccess.DataAccessObject;
using FOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using FOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando
{
    /// <summary>
    /// Metodo que se encarga de consultar los detalles de un reclamo en la BD
    /// </summary>
    public class M16_COConsultarReclamoDetalle : Command<Entidad>
    {
        int valor;

        /// <summary>
        /// Metodo constructor del comando
        /// </summary>
        /// <param name="idReclamo">Id del reclamo a editar</param>
        public M16_COConsultarReclamoDetalle(int idReclamo)
        {
            this.valor = idReclamo;
        }
        /// <summary>
        /// Sobre escritura del metodo ejecutar de la clase Comando.
        /// Se encarga de llamar al DAO y devolver la respuesta al controlador.
        /// </summary>
        /// <returns>
        /// Retorna una Entidad
        /// </returns>
        public override Entidad ejecutar()
        {
            IDAO daoReclamo = FabricaDAO.instanciarDaoReclamo();
            Entidad reclamo = daoReclamo.Consultar(valor);
            return reclamo;
        }
    }

}
