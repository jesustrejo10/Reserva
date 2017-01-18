using FOReserva.DataAccess.DataAccessObject.Common;
using FOReserva.Models.Revision;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.DataAccess.DataAccessObject
{
    public class DAORevision : DAO
    {
        private static DAORevision instance = null;

        public static DAORevision Singleton() {
            if (DAORevision.instance == null)
                DAORevision.instance = FabricDAO.CreateDAORevicion();
            return DAORevision.instance;
        }

        public DAOResult AgregarRevicion(CRevision revision) {
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
    }
}