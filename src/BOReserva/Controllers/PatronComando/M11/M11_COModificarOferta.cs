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
    /// Comando Modificar Oferta
    /// </summary>
    public class M11_COModificarOferta : Command<String>
    {
        Oferta _oferta;
        int _idmodificar;

        public M11_COModificarOferta(Entidad oferta, int id)
        {
            this._oferta = (Oferta)oferta;
            this._oferta._id = id;
        }

        /*    public override String ejecutar(){
                IDAO daoOferta = FabricaDAO.instanciarDaoOferta();
                Entidad test = daoOferta.Modificar(_oferta);
                Oferta oferta = (Oferta)test;
                return oferta._nombre;
        }*/

            public override String ejecutar(){

                return null; //por ahora porque lo de arriba es lo que se debe descomentar
        }
    }
}