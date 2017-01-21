using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FOReserva.DataAccess.Model;
using FOReserva.DataAccess.Domain;
using System.Data;
using FOReserva.DataAccess.DataAccessObject.Common.Interface;

namespace FOReserva.DataAccess.DataAccessObject.M20
{
    public class DAORevision : DAO, IDAORevision
    {
        #region Patron Singleton DAORevision.
        private static DAORevision instance = null;

        public static DAORevision Singleton()
        {
            if (DAORevision.instance == null)
                DAORevision.instance = (DAORevision)FabricaDAO.CreateDAORevision();
            return DAORevision.instance;
        }
        #endregion

        #region Implementacion DAORevision.        
        public bool GuardarRevision(Entidad revision)
        {            
            List<Parametro> parametros = null;
            Revision iRevision = null;
            try
            {
                if (!(revision is Revision))
                    throw new DAOM20Exception("La entidad revision debe ser de tipo Revision.");

                iRevision = (Revision)revision;

                parametros = FabricaDAO.asignarListaDeParametro();
                parametros.Add(FabricaDAO.asignarParametro(RecursoDAOM20.parametroRevisionID, SqlDbType.Int, iRevision._id.ToString(), false));
                parametros.Add(FabricaDAO.asignarParametro(RecursoDAOM20.parametroRevisionMensaje, SqlDbType.VarChar, iRevision.Mensaje.ToString(), false));
                parametros.Add(FabricaDAO.asignarParametro(RecursoDAOM20.parametroRevisionTipo, SqlDbType.Int, ((int)iRevision.Tipo).ToString(), false));
                parametros.Add(FabricaDAO.asignarParametro(RecursoDAOM20.parametroRevisionPuntuacion, SqlDbType.Int, iRevision.Puntuacion.ToString(), false));
                parametros.Add(FabricaDAO.asignarParametro(RecursoDAOM20.parametroRevisionIDUsuario, SqlDbType.Int, iRevision.Usuario._id.ToString(), false));
                parametros.Add(FabricaDAO.asignarParametro(RecursoDAOM20.parametroReferencia, SqlDbType.Int, iRevision.Referencia._id.ToString(), false));                
                
                EjecutarStoredProcedure(RecursoDAOM20.procedimientoGuardarRevision, parametros);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
            return false;
        }

        public bool AplicarValoracion(Entidad revision)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}