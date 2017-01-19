using FOReserva.DataAccess.DataAccessObject.Common;
using FOReserva.DataAccess.DataAccessObject.Common.Interface;
using FOReserva.Models.Hoteles;
using FOReserva.Models.Revision;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FOReserva.Models.Restaurantes;

namespace FOReserva.DataAccess.DataAccessObject
{
    public class DAORevision : FOReserva.DataAccess.DataAccessObject.Common.DAO, IDAORevision
    {
        #region Patron Singleton DAORevision.
        private static IDAO instance = null;

        private static IDAO Singleton()
        {
            if (DAORevision.instance == null)
                DAORevision.instance = FabricDAO.CreateDAORevision();
            return DAORevision.instance;
        }
        #endregion

        #region Implementacion DAORevision.
        public enum TipoValoracion { Positiva, Negativa };
        public DAOResult AgregarRevicion(CRevision revision, CHotel hotel) {
            int status = -1;
            string message = String.Empty;
            DAOResult result = this.ExecuteStoreProcedureWithResult(
                name: "M20_AgregarRevision",
                parameters: new
                {
                    @rev_fecha = revision.Fecha,
                    @rev_mensaje = revision.Mensaje,
                    @rev_tipo = revision.Tipo,
                    @rev_puntuacion = revision.Puntuacion/*,
                    @rev_referencia = revision.Hotel or revision.Restaurante
                    */
                },
                doThis: (reader) => {
                    status = reader.GetInt32(0);
                    message = reader.GetString(1);                    
                }
            );
            if (result.ProcessFinishCorrectly) { 
                result.ProcessFinishCorrectly = status == 0;
                result.Message = message;
            }
            
            return result;
        }

        public DAOResult AgregarRevision(CRevision revision, CHotel hotel)
        {
            throw new NotImplementedException();
        }

        public DAOResult AgregarRevision(CRevision revision, CRestaurantModel restaurante)
        {
            throw new NotImplementedException();
        }

        public DAOResult AplicarValoracion(CRevision revision, TipoValoracion hotel)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}