using FOReserva.Datos.Fabrica;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace FOReserva.Datos
{
    public abstract class DAO
    {

        #region Atributos
        private SqlConnection _conexion;
        private string _stringDeConexion;
        private SqlCommand _comandoSql;
        private string _query;
        #endregion

        #region Conexion y Desconexion de la BD

        /// <summary>
        /// Metodo para conectarse a la Base de Datos
        /// y se setea la variable conexion 
        /// el string de coneccion se obtiene por el archivo de 
        /// web.config, si es local debe cambierse en ese archivo 
        /// el string. para este caso ConfigurationManager.ConnectionStrings["StringLocal"].ConnectionString
        /// solo se cambia StringLocal si se usa ese, de lo contrario se coloca StringRemoto
        /// </summary>
        /// <returns>SqlConeection</returns>
        public SqlConnection conectarBD()
        {
            try
            {
                this.StringDeConexion = ConfigurationManager.ConnectionStrings["StringRemoto"].ConnectionString;
                this._conexion = FabricaDatosSql.asignarConexionSql(this.StringDeConexion);
            }

            catch (Exception ex)
            {


            }
            System.Diagnostics.Debug.WriteLine("Conecta Correctamente");
            return this._conexion;



        }

        /// <summary>
        /// Metodo para desconectar de la BD despues de ejecutada 
        /// operacion
        /// </summary>
        public void desconectarBD()
        {

            try
            {
                this._conexion.Close();
                this._conexion = null;
            }

            catch (Exception ex)
            {


            }
            System.Diagnostics.Debug.WriteLine("Desconecta Correctamente");
        }
        #endregion

        #region Ejecutar query
        /// <summary>
        /// Metodo que permite ejecutar el query 
        /// e.g. Select *from Lugar;
        /// </summary>
        /// <param name="query">String del query</param>
        /// <returns>SqlDataReader con los datos obtenidos de la ejecucion</returns>
        public SqlDataReader EjecutarQuery(string query)
        {
            try
            {
                conectarBD();

                using (this._conexion)
                {
                    this._comandoSql = FabricaDatosSql.asignarComandoSql(query, this._conexion);
                    SqlDataReader lecturaDeDatos = this._comandoSql.ExecuteReader();
                    return lecturaDeDatos;
                }


            }
            catch (SqlException ex)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                desconectarBD();
            }
        }
        #endregion

        #region Ejecutar Procedimientos
        /// <summary>
        /// Metodo para ejecutar un stored procedure para realizar el CRUD
        /// las consultas en este metodo se retorna como una lista
        /// </summary>
        /// <param name="query">El stored procedure a ejecutar</param>
        /// <param name="parametros">lista de los parametros a usar</param>
        /// <returns>List<Valores>Devuelve los valores de cada una de las columnas pertenecientes a la fila consultada</returns>
        public List<Columna> EjecutarStoredProcedure(string query, List<Parametro> parametros)
        {
            try
            {
                conectarBD();
                List<Columna> valorTabla = FabricaDatosSql.asignarListarColumnas();
                using (this._conexion)
                {

                    this._comandoSql = FabricaDatosSql.asignarComandoSql(query, this._conexion);
                    this._comandoSql.CommandType = CommandType.StoredProcedure;


                    AsignarParametros(parametros);


                    this._conexion.Open(); //Se abre la conexion 
                    this._comandoSql.ExecuteNonQuery();//Se ejecuta el query

                    if (this._comandoSql.Parameters != null)
                    {
                        foreach (SqlParameter parametro in this._comandoSql.Parameters)
                        {

                            if (parametro.Direction.Equals(ParameterDirection.Output))
                            {
                                Columna valor = FabricaDatosSql.asignarValorColumna(parametro.ParameterName, parametro.Value.ToString());
                                valorTabla.Add(valor);
                            }
                        }
                        if (valorTabla != null)
                        {
                            return valorTabla; //return ocurre si devuelve una consulta de la BD
                        }
                        else
                        {
                       
                        }
                    }
                    return null; // Esto ocurre si el procedimiento a ejecutar es para insertar, actualizar o eliminar
                }


            }
            catch (SqlException ex)
            {
                throw;
               
            }
            //catch (ParametroInvalidoException ex)
            //{
            //  
            //}
            catch (Exception ex)
            {
                throw;
       
            }
            finally
            {
                desconectarBD();
            }
        }



        /// <summary>
        /// Metodo para un Store Procedure y traerse una consulta de una o mas filas de la BD 
        /// </summary>
        /// <param name="parametros"></param>
        /// <param name="query"></param>
        /// <returns> Devuelve un DataTable</returns>
        public DataTable EjecutarStoredProcedure(List<Parametro> parametros, string query)
        {
            try
            {
                conectarBD();
                DataTable tablaDeDatos = FabricaDatosSql.asignarTablaDeDatos();
                SqlDataAdapter adaptadorDeDatos;

                using (this._conexion)
                {

                    this._comandoSql = FabricaDatosSql.asignarComandoSql(query, this._conexion);
                    this._comandoSql.CommandType = CommandType.StoredProcedure;

                    AsignarParametros(parametros);

                    this._conexion.Open();

                    adaptadorDeDatos = FabricaDatosSql.asignarAdaptadorDeDatos(this._comandoSql);

                    using (adaptadorDeDatos)
                    {
                        adaptadorDeDatos.Fill(tablaDeDatos);

                    }

                    return tablaDeDatos;
                }


            }
            catch (SqlException ex)
            {
                throw;
            }
            //catch (ParametroInvalidoException ex)
            //{
            //    
            //}
            catch (Exception ex)
            {
                throw;
          
            }
            finally
            {
                desconectarBD();
            }
        }

        #endregion

        #region Asignar Parametros de Entrada o Salida de Procedimiento
        /// <summary>
        /// Metodo para asignar los parametros al comando sql 
        /// </summary>
        /// <param name="parametros">Lista de parametros que van a la tabla en BD</param>
        public void AsignarParametros(List<Parametro> parametros)
        {
            foreach (Parametro parametro in parametros)
            {

                if (parametro != null && parametro.nombreAtributo != null)
                {
                    if (parametro.output)//Si es output, implica que se asignan las variables que va a retornar el procedimiento, e.g. @nombre OUTPUT en el store procedure
                    {
                        _comandoSql.Parameters.Add(parametro.nombreAtributo, parametro.tipoDeDato);
                        _comandoSql.Parameters[parametro.nombreAtributo].Direction = ParameterDirection.Output;
                    }
                    else if (parametro.Input)//Si es input, implica que se envian variables al procedimiento 
                    {
                        _comandoSql.Parameters.Add(parametro.nombreAtributo, parametro.tipoDeDato).Value = parametro.valorAtributo;
                        _comandoSql.Parameters[parametro.nombreAtributo].Direction = ParameterDirection.Input;
                    }
                    else
                    {
                        if (parametro.valorAtributo != null)//aqui se inicializan los parametros a insertar o actualizar en la BD
                        {
                            _comandoSql.Parameters.Add(parametro.nombreAtributo, parametro.tipoDeDato).Value = parametro.valorAtributo;

                        }
                        else
                        {
                             
                        }
                    }
                }
                else
                {
                           
                }

            }
        }
        #endregion

        #region Get y Set
        public SqlConnection Conexion
        {
            get
            {
                return _conexion;
            }

            set
            {
                _conexion = value;
            }
        }

        public string StringDeConexion
        {
            get
            {
                return _stringDeConexion;
            }

            set
            {
                _stringDeConexion = value;
            }
        }

        public SqlCommand ComandoSql
        {
            get
            {
                return _comandoSql;
            }

            set
            {
                _comandoSql = value;
            }
        }

        public string Query
        {
            get
            {
                return _query;
            }

            set
            {
                _query = value;
            }
        }
        #endregion

    }
}