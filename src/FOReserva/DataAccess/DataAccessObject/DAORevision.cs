using FOReserva.DataAccess.DataAccessObject.Common;
using FOReserva.DataAccess.DataAccessObject.Common.Interface;
using FOReserva.Models.Hoteles;
using FOReserva.Models.Revision;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FOReserva.Models.Restaurantes;
using FOReserva.Models.Usuarios;
using FOReserva.Models.ReservaHabitacion;

namespace FOReserva.DataAccess.DataAccessObject
{
    public class DAORevision : FOReserva.DataAccess.DataAccessObject.Common.DAO, IDAORevision
    {
        #region Patron Singleton DAORevision.
        private static DAORevision instance = null;

        public static DAORevision Singleton()
        {
            if (DAORevision.instance == null)
                DAORevision.instance = (DAORevision)FabricDAO.CreateDAORevision();
            return DAORevision.instance;
        }
        #endregion

        #region Implementacion DAORevision.
        public enum TipoValoracion { Positiva, Negativa };
        public enum TipoRevision { Restaurante = 1, Hotel = 2 };

        private DAOResult GuardarRevicion(CRevision revision, int usuario_id, TipoRevision tipo, int referencia_id) {
            int status = -1;
            string message = String.Empty;
            DAOResult result = null;
            this.OpenConnection();
            result = this.ExecuteStoreProcedureWithResult(
                name: "M20_GuardarRevision",
                parameters: new
                {
                    @rev_id = revision.Id,
                    @rev_mensaje = revision.Mensaje,
                    @rev_tipo = (int)tipo,
                    @rev_puntuacion = revision.Puntuacion,
                    @rev_FK_usu_id = usuario_id,
                    @rev_FK_res_ref = referencia_id,

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
            this.CloseConnection();
            return result;
        }

        public DAOResult GuardarRevision(CRevision revision, CUsuario usuario, CReservaHabitacion reservaHabitacion)
        {
            return this.GuardarRevicion(revision, usuario.Codigo, TipoRevision.Hotel, reservaHabitacion.Codigo);
        }

        public DAOResult GuardarRevision(CRevision revision, CUsuario usuario, CRestaurantModel restaurante)
        {
            return this.GuardarRevicion(revision, usuario.Codigo, TipoRevision.Restaurante, restaurante.Id);
        }
                
        public DAOResult AplicarValoracion(CRevision revision, TipoValoracion tipo)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}