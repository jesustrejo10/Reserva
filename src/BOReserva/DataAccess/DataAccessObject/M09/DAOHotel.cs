using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using BOReserva.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace BOReserva.DataAccess.DataAccessObject.M09
{
    public class DAOHotel:  DAO, IDAOHotel {

        public DAOHotel() {}


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
                //M09_Exception exception = new M09_Exception(ex, M09_Exception.messageHelper(ex), this.GetType().ToString());
                Debug.WriteLine("Ocurrio un SqlException");
                Debug.WriteLine(ex.ToString());
                return 2;
            }
            catch (NullReferenceException ex)
            {
                Debug.WriteLine("Ocurrio una NullReferenceException");
                Debug.WriteLine(ex.ToString());
                return 3;
            }
            catch (ArgumentNullException ex)
            {
                Debug.WriteLine("Ocurrio una ArgumentNullException");
                Debug.WriteLine(ex.ToString());
                return 4;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Ocurrio una Exception");
                Debug.WriteLine(ex.ToString());
                return 5;
            }
        }

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

                hotel._nombre = "1";
                return hotel;
            }
            catch (SqlException ex)
            {
              
                hotel._nombre = ex.Message;
                Entidad resultado = hotel;
                return resultado;
            }
        }

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
                    nombreCiudad = row[RecursoDAOM09.id_ciudad].ToString();
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
                Debug.WriteLine(ex.ToString());
                return null;
            }
        }

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
                    nombreCiudad = row[RecursoDAOM09.id_ciudad].ToString();
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
                Debug.WriteLine(ex.ToString());
                return null;
            }
        }

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
                return ex.Message;
            }
        }

        string IDAOHotel.disponibilidadHotel(Entidad e, int disponibilidad)
        {
            Hotel hotel = (Hotel)e;
            List<Parametro> listaParametro = FabricaDAO.asignarListaDeParametro();

            try
            {
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM09.hot_id, SqlDbType.Int, hotel._id.ToString(), false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM09.hot_disponible, SqlDbType.Int, disponibilidad.ToString(), false));

                EjecutarStoredProcedure(RecursoDAOM09.ProcedimientoCambiarDisponibilidad, listaParametro);

                return "1";
            }
            catch (SqlException ex)
            {
                return ex.Message;
            }
        }


    }
}
