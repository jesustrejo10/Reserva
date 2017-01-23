using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando.M11
{
    /// <summary>
    /// Comando Consultar Oferta
    /// </summary>
    public class M11_COConsultarOferta : Command<Entidad>
    {
        int valor;

        public M11_COConsultarOferta(int value)
        {
            this.valor = value;
        }

        ///// <summary>
        ///// Sobreescritura del metodo ejecutar de la clase Comando.
        ///// Se encarga de llamar al DAO y devolver la respuesta al controlador.
        ///// </summary>
        ///// <returns>
        ///// Retorna una Entidad
        ///// </returns>
        public override Entidad ejecutar()
        {
            IDAO daoOferta = FabricaDAO.instanciarDaoOferta();
            Entidad oferta = daoOferta.Consultar(valor);
            return oferta;
        }
    }
}