using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using BOReserva.DataAccess.Model;
using BOReserva.Excepciones;
using BOReserva.Excepciones.M09;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;


namespace BOReserva.DataAccess.DataAccessObject.M09

{
    /// <summary>
    /// Clase para el manejo de los hoteles en la BD
    /// </summary>
    public class DAOHotel:  DAO, IDAOHotel {
        /// <summary>
        /// Constructor del metodo
        /// </summary>
        public DAOHotel() {}

        /// <summary>
        /// Metodo implementado de IDAO para agregar hoteles a la BD
        /// </summary>
        /// <param name="e">Hotel a agregar</param>
        /// <returns>Retorna un _idHotel entero</returns>
        int IDAO.Agregar(Entidad e)
        {
            List<Parametro> listaParametro = FabricaDAO.asignarListaDeParametro();
            Hotel hotel = (Hotel)e;

            try
            {
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM09.hot_nombre, SqlDbType.VarChar, hotel._nombre, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM09.hot_pagina, SqlDbType.VarChar, hotel._paginaWeb, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM09.hot_email, SqlDbType.VarChar, hotel._email, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM09.hot_cantidad_habitaciones, SqlDbType.Int, hotel._capacidad.ToString(), false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM09.hot_direccion, SqlDbType.VarChar, hotel._direccion, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM09.hot_estrellas, SqlDbType.Int, hotel._clasificacion.ToString(), false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM09.hot_fk_ciudad, SqlDbType.Int, hotel._ciudad._id.ToString(), false));
                EjecutarStoredProcedure(RecursoDAOM09.ProcedimientoAgregarHotel, listaParametro);

                return 1;
            }
            catch (SqlException ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);               
                throw new ReservaExceptionM09(ex.Message, ex);
            }
            catch (NullReferenceException ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM09(ex.Message, ex); 
            }
            catch (ArgumentNullException ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex); 
                throw new ReservaExceptionM09(ex.Message, ex);
            }
            catch (ExceptionBD ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex); 
                throw new ReservaExceptionM09(ex.Message, ex);
            }
            catch (LogException exi)
            {
                throw new ReservaExceptionM09(exi.Message, exi);
            }
            catch (Exception ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM09(ex.Message, ex);
            }
           
        }

        /// <summary>
        /// Metodo implementado de IDAO para modificar hoteles de la BD
        /// </summary>
        /// <param name="e">Hotel a modificar</param>
        /// <returns>Retorna el hotel</returns>
        Entidad IDAO.Modificar(Entidad e)
        {
            Hotel hotel = (Hotel)e;
            List<Parametro> listaParametro = FabricaDAO.asignarListaDeParametro();
            
            try
            {
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM09.hot_nombre, SqlDbType.VarChar, hotel._nombre, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM09.hot_pagina, SqlDbType.VarChar, hotel._paginaWeb, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM09.hot_email, SqlDbType.VarChar, hotel._email, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM09.hot_direccion, SqlDbType.VarChar, hotel._direccion, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM09.hot_estrellas, SqlDbType.Int, hotel._clasificacion.ToString(), false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM09.hot_id, SqlDbType.Int, hotel._id.ToString(), false));

                EjecutarStoredProcedure(RecursoDAOM09.ProcedimientoModificarHotel, listaParametro);

                return hotel;
            }
            catch (SqlException ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex); 
                throw new ReservaExceptionM09(ex.Message, ex);
            }
            catch (NullReferenceException ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM09(ex.Message, ex);
            }
            catch (ArgumentNullException ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM09(ex.Message, ex);
            }
            catch (ExceptionBD ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM09(ex.Message, ex);
            }
            catch (Exception ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM09(ex.Message, ex);
            }
        }

        /// <summary>
        /// Metodo implementado de IDAO para consultar un hotel de la BD
        /// </summary>
        /// <param name="id">Id del hotel a buscar</param>
        /// <returns>Retorna el hotel</returns>
        Entidad IDAO.Consultar(int id)
        {
            DataTable tablaDeDatos;
            List<Parametro> parametro = FabricaDAO.asignarListaDeParametro();

            Pais pais;
            Ciudad ciudad;
            Hotel hotel = null;
            int idCiudad;
            String nombreCiudad;
            int idPais;
            String nombrePais;
            int preciohab;
            int idHotel;

            try
            {

                parametro.Add(FabricaDAO.asignarParametro(RecursoDAOM09.hot_id, SqlDbType.Int, id.ToString(), false));
                
                tablaDeDatos = EjecutarStoredProcedureTuplas(RecursoDAOM09.ProcedimientoConsultarHotel, parametro);

                foreach (DataRow row in tablaDeDatos.Rows)
                {
                    idPais = Int32.Parse(row[RecursoDAOM09.id_pais].ToString());
                    nombrePais = row[RecursoDAOM09.nombre_pais].ToString();
                    pais = new Pais(idPais, nombrePais);

                    idCiudad = Int32.Parse(row[RecursoDAOM09.id_ciudad].ToString());
                    nombreCiudad = row[RecursoDAOM09.nombre_ciudad].ToString();
                    ciudad = new Ciudad(idCiudad, nombreCiudad, pais);

                    idHotel = Int32.Parse(row["hot_id"].ToString());
                    hotel = new Hotel(
                            idHotel,
                            row["hot_nombre"].ToString(),
                            row["hot_direccion"].ToString(),
                            row["hot_email"].ToString(),
                            row["hot_url_pagina"].ToString(),
                            Int32.Parse(row["hot_estrellas"].ToString()),
                            Int32.Parse(row["hot_cantidad_habitaciones"].ToString()),
                            ciudad,
                            Int32.Parse(row["hot_disponibilidad"].ToString())
                            );

                    
                }
                parametro = FabricaDAO.asignarListaDeParametro();
                parametro.Add(FabricaDAO.asignarParametro(RecursoDAOM09.hot_id, SqlDbType.Int, id.ToString(), false));

                tablaDeDatos = EjecutarStoredProcedureTuplas(RecursoDAOM09.ProcedimientoConsultarHabitacion, parametro);

                foreach (DataRow row in tablaDeDatos.Rows)
                {
                    preciohab = Int32.Parse(row[RecursoDAOM09.hab_precio].ToString());
                    hotel._precio = preciohab;
                }
                return hotel;
            }
            catch (SqlException ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex); 
                throw new ReservaExceptionM09(ex.Message, ex);
            }
            catch (NullReferenceException ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex); 
                throw new ReservaExceptionM09(ex.Message, ex);
            }
            catch (ArgumentNullException ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM09(ex.Message, ex);
            }
            catch (ExceptionBD ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex); 
                throw new ReservaExceptionM09(ex.Message, ex);
            }
            catch (Exception ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex); 
                throw new ReservaExceptionM09(ex.Message, ex);
            }
        }

        /// <summary>
        /// Metodo implementado de IDAO para consultar los hoteles de la BD
        /// </summary>
        /// <returns>Retorna el listado de hoteles</returns>
        Dictionary<int, Entidad> IDAO.ConsultarTodos()
        {
            Dictionary<int, Entidad> listaHoteles = new Dictionary<int, Entidad>();
            DataTable tablaDeDatos;
            List<Parametro> parametro = FabricaDAO.asignarListaDeParametro();

            Pais pais;
            Ciudad ciudad;
            Hotel hotel;
            int idCiudad;
            String nombreCiudad;
            int idPais;
            String nombrePais;

            int idHotel;

            try
            {

                tablaDeDatos = EjecutarStoredProcedureTuplas(RecursoDAOM09.ProcedimientoConsultarTodos, parametro);

                foreach (DataRow row in tablaDeDatos.Rows)
                {
                    idPais = Int32.Parse(row[RecursoDAOM09.id_pais].ToString());
                    nombrePais = row[RecursoDAOM09.nombre_pais].ToString();
                    pais = new Pais(idPais, nombrePais);

                    idCiudad = Int32.Parse(row[RecursoDAOM09.id_ciudad].ToString());
                    nombreCiudad = row[RecursoDAOM09.nombre_ciudad].ToString();
                    ciudad = new Ciudad(idCiudad, nombreCiudad, pais);

                    idHotel = Int32.Parse(row["hot_id"].ToString());
                    hotel = new Hotel(
                            idHotel,
                            row["hot_nombre"].ToString(),
                            row["hot_direccion"].ToString(),
                            row["hot_email"].ToString(),
                            row["hot_url_pagina"].ToString(),
                            Int32.Parse(row["hot_estrellas"].ToString()),
                            Int32.Parse(row["hot_cantidad_habitaciones"].ToString()),
                            ciudad,
                            Int32.Parse(row["hot_disponibilidad"].ToString())
                            );
                    listaHoteles.Add(idHotel, hotel);
                    
                }
                return listaHoteles;
            }
            catch (SqlException ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM09(ex.Message, ex);
            }
            catch (NullReferenceException ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM09(ex.Message, ex);
            }
            catch (ArgumentNullException ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM09(ex.Message, ex);
            }
            catch (ExceptionBD ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM09(ex.Message, ex);
            }
            catch (Exception ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM09(ex.Message, ex);
            }
        }

        /// <summary>
        /// Metodo implementado de IDAO para eliminar hoteles de la BD
        /// </summary>
        /// <param name="id">Id del hotel a eliminar</param>
        /// <returns>Retorna un string</returns>
        string IDAOHotel.eliminarHotel(int id)
        {
            List<Parametro> listaParametro = FabricaDAO.asignarListaDeParametro();

            try
            {
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM09.hot_id, SqlDbType.Int, id.ToString(), false));
                EjecutarStoredProcedure(RecursoDAOM09.ProcedimientoEliminarHotel, listaParametro);

                return "1";
            }
            catch (SqlException ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex); 
                throw new ReservaExceptionM09(ex.Message, ex);
            }
            catch (NullReferenceException ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM09(ex.Message, ex);
            }
            catch (ArgumentNullException ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM09(ex.Message, ex);
            }
            catch (ExceptionBD ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM09(ex.Message, ex);
            }
            catch (Exception ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex); 
                throw new ReservaExceptionM09(ex.Message, ex);
            }
        }

        /// <summary>
        /// Metodo implementado de IDAO para cambiar la disponibilidad de los hoteles de la BD
        /// </summary>
        /// <param name="e">Hotel a modificar</param>
        /// <param name="disponibilidad">Estatus nuevo</param>
        /// <returns></returns>
        Entidad IDAOHotel.disponibilidadHotel(Entidad e, int disponibilidad)
        {
            Hotel hotel = (Hotel)e;
            List<Parametro> listaParametro = FabricaDAO.asignarListaDeParametro();

            try
            {
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM09.hot_id, SqlDbType.Int, hotel._id.ToString(), false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM09.hot_disponible, SqlDbType.Int, disponibilidad.ToString(), false));

                EjecutarStoredProcedure(RecursoDAOM09.ProcedimientoCambiarDisponibilidad, listaParametro);

                return hotel;
            }
            catch (SqlException ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM09(ex.Message, ex);
            }
            catch (NullReferenceException ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM09(ex.Message, ex);
            }
            catch (ArgumentNullException ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex); 
                throw new ReservaExceptionM09(ex.Message, ex);
            }
            catch (ExceptionBD ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM09(ex.Message, ex);
            }
            catch (Exception ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex); 
                throw new ReservaExceptionM09(ex.Message, ex);
            }
        }

    }
}
