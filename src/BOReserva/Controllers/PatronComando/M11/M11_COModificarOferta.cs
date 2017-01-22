using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using System;
using System.Diagnostics;

namespace BOReserva.Controllers.PatronComando.M11
{
    /// <summary>
    /// Comando Modificar Oferta
    /// </summary>
    public class M11_COModificarOferta : Command<String>
    {
        Oferta _oferta;
        int valor;

        /// <summary>
        /// Se asignan los parámetros a la entidad que será modificada
        /// </summary>
        /// <param name="oferta">La entidad que se va a modificar</param>
        /// <param name="id">El id de la entidad que se va a modificar</param>
        public M11_COModificarOferta(Entidad oferta, int id)
        {
            this._oferta = (Oferta)oferta;
            this.valor = id;
        }

        public override String ejecutar()
        {
            Debug.WriteLine("ENTRÓ A EJECUTAR");
            Debug.WriteLine("ENTRÓ A EJECUTAR " + _oferta._nombreOferta);
            Debug.WriteLine("ENTRÓ A EJECUTAR " + valor);

            IDAOOferta daoOferta = FabricaDAO.instanciarDaoOferta();
            int test = daoOferta.Modificar(_oferta, valor);
            return test.ToString();
         }

           /* public override String ejecutar(){

                return null; //por ahora porque lo de arriba es lo que se debe descomentar
        }*/
    }
}