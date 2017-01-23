using System;
using System.Collections.Generic;

using FOReserva.DataAccess.Model;
using FOReserva.DataAccess.Domain;
using System.Data;

namespace FOReserva.DataAccess.DataAccessObject.M20
{    
    using Hotel = Domain.Hotel;
    using Restaurante = Domain.Restaurante;
    using Usuario = Domain.Usuario;

    /// <summary>
    /// Esta clase posee las instrucciones necesarias para ejecutar los procedimientos almacenados en la base de datos.
    /// </summary>
    public class DAORevision : DAO, IDAORevision
    {
        #region Patron Singleton DAORevision.
        private static DAORevision instance = null;

        /// <summary>
        /// Permite obtener una instancia de la clase DAORevision.
        /// </summary>
        /// <returns>Instancia DAORevision.</returns>
        public static DAORevision Singleton()
        {
            if (DAORevision.instance == null)
                DAORevision.instance = (DAORevision)FabricaDAO.CreateDAORevision();
            return DAORevision.instance;
        }
        #endregion

        #region Implementacion DAORevision.
        /// <summary>
        /// Permite almacear los cambios de una Revision (Exista o no).
        /// </summary>
        /// <param name="revision">Se espera una instancia Revision.</param>
        /// <returns>Es el resultado tras ejecutar la tarea, true si culmino correctamente o de lo contrario false.</returns>
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
                parametros.Add(FabricaDAO.asignarParametro(RecursoDAOM20.parametroRevisionId, SqlDbType.Int, iRevision._id.ToString(), false));
                parametros.Add(FabricaDAO.asignarParametro(RecursoDAOM20.parametroRevisionMensaje, SqlDbType.VarChar, iRevision.Mensaje.ToString(), false));
                parametros.Add(FabricaDAO.asignarParametro(RecursoDAOM20.parametroRevisionTipo, SqlDbType.Int, ((int)iRevision.Tipo).ToString(), false));
                parametros.Add(FabricaDAO.asignarParametro(RecursoDAOM20.parametroRevisionEstrellas, SqlDbType.Int, iRevision.Estrellas.ToString(), false));
                parametros.Add(FabricaDAO.asignarParametro(RecursoDAOM20.parametroRevisionPropietario, SqlDbType.Int, iRevision.Propietario._id.ToString(), false));
                parametros.Add(FabricaDAO.asignarParametro(RecursoDAOM20.parametroRevisionReferencia, SqlDbType.Int, iRevision.Referencia._id.ToString(), false));                
                
                EjecutarStoredProcedure(RecursoDAOM20.procedimientoGuardarRevision, parametros);
                return true;
            }
            catch (Exception ex)
            {
                Models.Utilidad.RegistrarLog(new DAOM20Exception("Ocurrio un problema al intentar ejecutar DAORevision.GuardarRevision.", ex));
            }
            return false;
        }

        /// <summary>
        /// Permite almacear los cambios de una Valoracion(Exista o no) de una Revision.
        /// </summary>
        /// <param name="valoracion">Se espera una instancia de Valoracion.</param>
        /// <returns>Es el resultado tras ejecutar la tarea, true si culmino correctamente o de lo contrario false.</returns>
        public bool GuardarValoracion(Entidad valoracion)
        {
            List<Parametro> parametros = null;
            RevisionValoracion iValoracion = null;
            try
            {
                if (!(valoracion is RevisionValoracion))
                    throw new DAOM20Exception("La entidad revision debe ser de tipo RevisionValoracion.");

                iValoracion = (RevisionValoracion)valoracion;

                parametros = FabricaDAO.asignarListaDeParametro();
                parametros.Add(FabricaDAO.asignarParametro(RecursoDAOM20.parametroValoracionId, SqlDbType.Int, iValoracion._id.ToString(), false));
                parametros.Add(FabricaDAO.asignarParametro(RecursoDAOM20.parametroValoracionPropietario, SqlDbType.VarChar, iValoracion.Propietario._id.ToString(), false));
                parametros.Add(FabricaDAO.asignarParametro(RecursoDAOM20.parametroValoracionPunto, SqlDbType.Int, ((int)iValoracion.Punto).ToString(), false));
                parametros.Add(FabricaDAO.asignarParametro(RecursoDAOM20.parametroValoracionRevision, SqlDbType.Int, iValoracion.Revision._id.ToString(), false));

                EjecutarStoredProcedure(RecursoDAOM20.procedimientoGuardarValoracion, parametros);
                return true;
            }
            catch (Exception ex)
            {
                Models.Utilidad.RegistrarLog(new DAOM20Exception("Ocurrio un problema al intentar ejecutar DAORevision.GuardarValoracion.", ex));
            }
            return false;
        }

        /// <summary>
        /// Permite almacear los cambios de una Valoracion(Exista o no) de una Revision.
        /// </summary>
        /// <param name="revision">Se espera una instancia Valoracion.</param>
        /// <returns>Es el resultado tras ejecutar la tarea, true si culmino correctamente o de lo contrario false.</returns>
        public bool BorrarRevision(Entidad revision)
        {
            List<Parametro> parametros = null;
            Revision iRevision = null;
            try
            {
                if (!(revision is Revision))
                    throw new DAOM20Exception("La entidad revision debe ser de tipo Revision.");

                iRevision = (Revision)revision;

                parametros = FabricaDAO.asignarListaDeParametro();
                parametros.Add(FabricaDAO.asignarParametro(RecursoDAOM20.parametroRevisionId, SqlDbType.Int, iRevision._id.ToString(), false));
                if (iRevision.Propietario != null)
                {
                    parametros.Add(FabricaDAO.asignarParametro(RecursoDAOM20.parametroRevisionPropietario, SqlDbType.Int, iRevision.Propietario._id.ToString(), false));
                }
                else if (iRevision.Referencia != null)
                {
                    parametros.Add(FabricaDAO.asignarParametro(RecursoDAOM20.parametroRevisionTipo, SqlDbType.Int, ((int)iRevision.Tipo).ToString(), false));
                    parametros.Add(FabricaDAO.asignarParametro(RecursoDAOM20.parametroRevisionReferencia, SqlDbType.Int, iRevision.Referencia._id.ToString(), false));
                }

                EjecutarStoredProcedure(RecursoDAOM20.procedimientoBorrarRevision, parametros);
                return true;
            }
            catch (Exception ex)
            {
                Models.Utilidad.RegistrarLog(new DAOM20Exception("Ocurrio un problema al intentar ejecutar DAORevision.BorrarRevision.", ex));
            }
            return false;
        }

        /// <summary>
        /// Permite obtener las revisiones de una referencia (Hotel | Restaurante) con sus puntos y estrellas.
        /// </summary>
        /// <param name="referencia">Se espera una instancia de Hotel o Restaurante.</param>
        /// <returns>Revisiones de la referencia indicada.</returns>
        public List<Revision> ObtenerRevisionesPorReferencia(Entidad referencia)
        {
            List<Revision> revisiones = null;
            List<Parametro> parametros = null;
                        
            int tipo = 0;
            try
            {
                if (referencia is Hotel)
                    tipo = 2;
                else if (referencia is Restaurante)
                    tipo = 1;
                else
                    throw new DAOM20Exception("La entidad referencia debe ser de tipo Hotel o Restaurante.");

                parametros = FabricaDAO.asignarListaDeParametro();                
                parametros.Add(FabricaDAO.asignarParametro(RecursoDAOM20.parametroRevisionTipo, SqlDbType.Int, ((int)tipo).ToString(), false));                
                parametros.Add(FabricaDAO.asignarParametro(RecursoDAOM20.parametroRevisionReferencia, SqlDbType.Int, referencia._id.ToString(), false));

                var resultado = EjecutarStoredProcedureTuplas(RecursoDAOM20.procedimientoObtenerRevisionesPorReferencia, parametros);
                revisiones = new List<Revision>();
                foreach (DataRow revision in resultado.Rows) {
                    revisiones.Add(new Revision
                    {
                        Id = (int)revision[RecursoDAOM20.parametroRevisionId],
                        Fecha = (DateTime)revision[RecursoDAOM20.parametroRevisionFecha],
                        Mensaje = (string)revision[RecursoDAOM20.parametroRevisionMensaje],
                        Estrellas = (decimal)revision[RecursoDAOM20.parametroRevisionEstrellas],
                        Tipo = (EnumTipoRevision)revision[RecursoDAOM20.parametroRevisionTipo],
                        Propietario = new Usuario {
                            Id = (int)revision[RecursoDAOM20.parametroRevisionPropietario],
                            Nombre = (string)revision[RecursoDAOM20.parametroRevisionPropietarioNombre]
                        },
                        Referencia = new Entidad {
                            _id = (int)revision[RecursoDAOM20.parametroRevisionReferencia]
                        }
                    });
                }
            }
            catch (Exception ex)
            {
                Models.Utilidad.RegistrarLog(new DAOM20Exception("Ocurrio un problema al intentar ejecutar DAORevision.ObtenerRevisionesPorReferencia.", ex));
            }
            return revisiones;
        }

        /// <summary>
        /// Permite obtener el promedio de estrellas de una referencia(Hotel | Restaurante).
        /// </summary>
        /// <param name="referencia">Se espera una instancia de Hotel o Restaurante.</param>
        /// <returns>Valoracion de la referencia indicada.</returns>
        public ReferenciaValorada ObtenerValoracionPorReferencia(Entidad referencia)
        {
            ReferenciaValorada valoracion = null;
            List<Parametro> parametros = null;
            int tipo = 0;
            try
            {
                if (referencia is Hotel)
                    tipo = 2;
                else if (referencia is Restaurante)
                    tipo = 1;
                else
                    throw new DAOM20Exception("La entidad referencia debe ser de tipo Hotel o Restaurante.");

                parametros = FabricaDAO.asignarListaDeParametro();
                parametros.Add(FabricaDAO.asignarParametro(RecursoDAOM20.parametroRevisionTipo, SqlDbType.Int, ((int)tipo).ToString(), false));
                parametros.Add(FabricaDAO.asignarParametro(RecursoDAOM20.parametroRevisionReferencia, SqlDbType.Int, referencia._id.ToString(), false));

                DataTable respuesta = EjecutarStoredProcedureTuplas(RecursoDAOM20.procedimientoObtenerValoracionPorReferencia, parametros);
                valoracion = new ReferenciaValorada
                {
                    Id = (int)respuesta.Rows[0][RecursoDAOM20.parametroRevisionReferencia],
                    Estrellas = (decimal)respuesta.Rows[0][RecursoDAOM20.parametroReferenciaEstrellas],
                    Tipo = (EnumTipoRevision)tipo
                };
            }
            catch (Exception ex)
            {
                Models.Utilidad.RegistrarLog(new DAOM20Exception("Ocurrio un problema al intentar ejecutar DAORevision.ObtenerRevisionesPorReferencia.", ex));
            }
            return valoracion;
        }
        #endregion
    }
}