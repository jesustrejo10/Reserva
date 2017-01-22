using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using BOReserva.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BOReserva.DataAccess.DataAccessObject
{
    abstract public class DAO : IDAO
    {
        protected String _connexionString = ConfigurationManager.ConnectionStrings["StringRemoto"].ConnectionString;
        private SqlConnection conexion;
        // El String de conexion se encuentra en el archivo Web.config
        private SqlCommand comando;

        public int Agregar(Entidad e)
        {
            throw new NotImplementedException();
        }

        public Entidad Modificar(Entidad e)
        {
            throw new NotImplementedException();
        }

        public Entidad Consultar(int id)
        {
            throw new NotImplementedException();
        }

        public Dictionary<int, Entidad> ConsultarTodos()
        {
            throw new NotImplementedException();
        }


        #region Conectar con la Base de Datos
        /// <summary>
        /// Metodo para realizar la conexion a la base de datos
        /// Excepciones posibles: 
        /// SqlException: Excepciones sql
        /// </summary>
        public SqlConnection Conectar()
        {

            try
            {
                //conexion = Connection.getInstance(_connexionString);
                conexion = new SqlConnection(_connexionString);
            }

            catch (Exception ex)
            {
                throw new ExceptionBD(RecursoBD.Cod_Error_Conexion, RecursoBD.Error_Conexion, ex);
            }

            return conexion;

        }
        #endregion

        #region Desconectar de la Base de Datos
        /// <summary>
        /// Metodo para cerrar la sesion con la base de datos
        /// Excepciones posibles: 
        /// SqlException: Atrapa los errores que pueden existir en el sql server internamente
        /// </summary>
        public void Desconectar()
        {

            try
            {
                this.conexion.Close();
            }

            catch (Exception ex)
            {
                throw new ExceptionBD(RecursoBD.Cod_Error_Desconexion, RecursoBD.Error_Desconexión, ex);

            }

        }

        public void Desconectar(SqlConnection conec)
        {

            try
            {
                conec.Close();
            }

            catch (Exception ex)
            {
                throw new ExceptionBD(RecursoBD.Cod_Error_Desconexion, RecursoBD.Error_Desconexión, ex);
            }

        }
        #endregion

        #region Ejecutar Stored Procedure Parametrizado

        /// <summary>
        /// Metodo para ejecutar un procedimiento almacenado en la bd
        /// </summary>
        /// <param name="parametros">Lista de parametros que se le va a asociar</param>
        /// <param name="query">Cadena con el query a ejecutar</param>
        public List<ResultadoBD> EjecutarStoredProcedure(string query, List<Parametro> parametros)
        {
            try
            {
                Conectar();
                List<ResultadoBD> resultados = new List<ResultadoBD>();
                using (conexion)
                {

                    comando = new SqlCommand(query, conexion);
                    comando.CommandType = CommandType.StoredProcedure;
                    AsignarParametros(parametros);
                    if (conexion.State == ConnectionState.Closed)
                    {
                        conexion.Open();
                    }
                    comando.ExecuteNonQuery();
                    if (comando.Parameters != null)
                    {
                        foreach (SqlParameter parameter in comando.Parameters)
                        {
                            if (parameter.Direction.Equals(ParameterDirection.Output))
                            {
                                ResultadoBD resultado = new ResultadoBD(parameter.ParameterName, parameter.Value.ToString());
                                resultados.Add(resultado);
                            }
                        }
                        if (resultados != null)
                        {
                            return resultados;
                        }
                        else
                        {
                            throw new ExceptionBD(RecursoBD.Cod_Error_Parametro, RecursoBD.Error_Parametro, new ExceptionBD());
                        }
                    }

                    return null;
                }
            }
            catch (SqlException ex)
            {
                //throw new ExceptionBD(RecursoBD.Cod_Error_General, RecursoBD.Error_General, ex);
                throw ex;
            }
            catch (Exception ex)
            {
                throw new ExceptionBD(RecursoBD.Cod_Error_General, RecursoBD.Error_General, ex); ;
            }
            finally
            {
                Desconectar();
            }
        }

        /// <summary>
        /// Metodo para asignar los parametros a un comando
        /// </summary>
        /// <param name="parametros">Lista de parametros que se le va a asociar</param>
        public void AsignarParametros(List<Parametro> parametros)
        {
            foreach (Parametro parametro in parametros)
            {
                if (parametro != null && parametro.etiqueta != null && parametro.tipoDato != null &&
                    parametro.esOutput != null)
                {
                    if (parametro.esOutput)
                    {
                        comando.Parameters.Add(parametro.etiqueta, parametro.tipoDato, 32000);
                        comando.Parameters[parametro.etiqueta].Direction = ParameterDirection.Output;
                    }
                    else
                    {
                        if (parametro.valor != null)
                        {
                            comando.Parameters.Add(new SqlParameter(parametro.etiqueta, parametro.tipoDato, 32000));
                            comando.Parameters[parametro.etiqueta].Value = parametro.valor;
                        }
                        else
                        {
                            throw new ExceptionBD(RecursoBD.Cod_Error_Parametro, RecursoBD.Error_Parametro, new ExceptionBD());
                        }
                    }
                }
                else
                {
                    throw new ExceptionBD(RecursoBD.Cod_Error_Parametro, RecursoBD.Error_Parametro, new ExceptionBD());
                }

            }
        }

        #endregion

        #region Ejecutar Stored Procedure Multiples Tuplas

        public DataTable EjecutarStoredProcedureTuplas(string query)
        {
            try
            {
                Conectar();
                DataTable dataTable = new DataTable();
                using (conexion)
                {

                    comando = new SqlCommand(query, conexion);
                    comando.CommandType = CommandType.StoredProcedure;
                    conexion.Open();
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(comando))
                    {
                        dataAdapter.Fill(dataTable);
                        System.Diagnostics.Debug.WriteLine(dataAdapter);
                        System.Diagnostics.Debug.WriteLine(dataTable);
                    }

                    return dataTable;
                }


            }
            catch (SqlException ex)
            {
                throw new ExceptionBD(RecursoBD.Cod_Error_General, RecursoBD.Error_General, ex);
            }

            catch (Exception ex)
            {
                throw new ExceptionBD(RecursoBD.Cod_Error_General, RecursoBD.Error_General, ex);
            }
            finally
            {
                Desconectar();
            }
        }


        /// <summary>
        /// Metodo para ejecutar un procedimiento almacenado en la bd que devuelve un DataTable
        /// </summary>
        /// <param name="parametros">Lista de parametros que se le va a asociar</param>
        /// <param name="query">Cadena con el query a ejecutar</param>
        public DataTable EjecutarStoredProcedureTuplas(string query, List<Parametro> parametros)
        {
            try
            {
                Conectar();
                DataTable dataTable = new DataTable();
                using (conexion)
                {

                    comando = new SqlCommand(query, conexion);
                    comando.CommandType = CommandType.StoredProcedure;
                    AsignarParametros(parametros);
                    conexion.Open();
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(comando))
                    {
                        dataAdapter.Fill(dataTable);
                        System.Diagnostics.Debug.WriteLine(dataAdapter);
                        System.Diagnostics.Debug.WriteLine(dataTable);
                    }

                    return dataTable;
                }


            }
            catch (SqlException ex)
            {
                throw new ExceptionBD(RecursoBD.Cod_Error_General, RecursoBD.Error_General, ex);
            }
            catch (Exception ex)
            {
                throw new ExceptionBD(RecursoBD.Cod_Error_General, RecursoBD.Error_General, ex);
            }
            finally
            {
                Desconectar();
            }
        }
        #endregion

    }
}
