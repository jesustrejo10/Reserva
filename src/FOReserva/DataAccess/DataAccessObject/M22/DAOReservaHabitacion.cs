using FOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using FOReserva.DataAccess.Domain;
using FOReserva.DataAccess.Model;
using FOReserva.Models;
using FOReserva.Models.Hoteles;
using FOReserva.Models.ReservaHabitacion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace FOReserva.DataAccess.DataAccessObject.M22
{
    public class DAOReservaHabitacion : DAO, IDAOReservaHabitacion
    {

        public DAOReservaHabitacion() { }

        int IDAO.Agregar(Entidad e)
        {
            List<Parametro> listaParametro = FabricaDAO.asignarListaDeParametro();
            ReservaHabitacion reserva= (ReservaHabitacion)e;

            try
            {
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM22.rha_cantidad_dias, SqlDbType.Int, reserva._cantidad.ToString(), false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM22.rha_fecha_llegada, SqlDbType.VarChar, reserva._fecha_llegada, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM22.rha_fk_hab_id, SqlDbType.Int, reserva._id_hotel.ToString(), false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM22.rha_fk_usu_id, SqlDbType.Int, reserva._id_usuario.ToString(), false));
                EjecutarStoredProcedure(RecursoDAOM22.ProcedimientoAgregarReservaHabitacion, listaParametro);

                return 1;
            }
            catch (SqlException ex)
            {
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

        String IDAOReservaHabitacion.eliminarReservaHabitacion(int id)
        {
            List<Parametro> listaParametro = FabricaDAO.asignarListaDeParametro();

            try
            {
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM22.rha_id, SqlDbType.Int, id.ToString(), false));
                EjecutarStoredProcedure(RecursoDAOM22.ProcedimientoEliminarReservaHabitacion, listaParametro);

                return "1";
            }
            catch (SqlException ex)
            {
                return ex.Message;
            }
        }
        String IDAOReservaHabitacion.modificarReservaHabitacion(int idreserva,int cant_dias)
        {
           
            List<Parametro> listaParametro = FabricaDAO.asignarListaDeParametro();

            try
            {
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM22.rha_cantidad_dias, SqlDbType.Int, cant_dias.ToString(), false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM22.rha_id, SqlDbType.Int, idreserva.ToString(), false));
                EjecutarStoredProcedure(RecursoDAOM22.ProcedimientoModificarReservaHabitacion, listaParametro);

                return "1";
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.ToString());
                return "0";
            }
        }
        Entidad IDAO.Modificar(Entidad e)
        {
            ReservaHabitacion reserva = (ReservaHabitacion)e;
            List<Parametro> listaParametro = FabricaDAO.asignarListaDeParametro();

            try
            {
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM22.rha_cantidad_dias, SqlDbType.Int, reserva._cant_dias.ToString(), false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM22.rha_fecha_reservacion, SqlDbType.VarChar, reserva._fecha_reserva, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM22.rha_estado, SqlDbType.Int, reserva._estado.ToString(), false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM22.rha_fecha_llegada, SqlDbType.VarChar, reserva._fecha_llegada, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM22.rha_fk_hab_id, SqlDbType.Int, reserva._fk_habitacion.ToString(), false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM22.rha_fk_usu_id, SqlDbType.Int, reserva._fk_usuario.ToString(), false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM22.rha_id, SqlDbType.Int, reserva._id, false));
                EjecutarStoredProcedure(RecursoDAOM22.ProcedimientoModificarReservaHabitacion, listaParametro);

                reserva._estado = "1";
                return reserva;
            }
            catch (SqlException ex)
            {

                reserva._estado = ex.Message;
                Entidad resultado = reserva;
                return resultado;
            }
        }

        Entidad IDAO.Consultar(int id)
        {
            DataTable tablaDeDatos;
            List<Parametro> parametro = FabricaDAO.asignarListaDeParametro();

            ReservaHabitacion reserva;

            int id_hotel;
            String nombre_hotel;


            int idReservaHabitacion;

            try
            {

                parametro.Add(FabricaDAO.asignarParametro(RecursoDAOM22.id_usuario, SqlDbType.Int, id.ToString(), false));

                tablaDeDatos = EjecutarStoredProcedureTuplas(RecursoDAOM22.ProcedimientoConsultarReservaHabitacion, parametro);

                foreach (DataRow row in tablaDeDatos.Rows)
                {
                    /*id_usu = Int32.Parse(row[RecursoDAOM22.id_usuario].ToString());
                    nombre_usu = row[RecursoDAOM22.nombre_usuario].ToString();
                    usuario = new Usuario(id_usu, nombre_usu);*/

                    /*id_hotel = Int32.Parse(row[RecursoDAOM22.id_hotel].ToString());
                    nombre_hotel = row[RecursoDAOM22.nombre_hotel].ToString();
                    habitacion = new ReservaHabitacion(id_hotel, nombre_hotel);*/

                    idReservaHabitacion = Int32.Parse(row["rha_id"].ToString());
                    reserva = new ReservaHabitacion(
                            /*Int32.Parse*/(row["rha_cantidad_dias"].ToString()),
                            row["rha_fecha_reservacion"].ToString(),
                            row["rha_fecha_llegada"].ToString(),
                            /*Int32.Parse*/(row["rha_estado"].ToString()),           
                            /*Int32.Parse*/(row["rha_fk_hot_id"].ToString()),
                            /*Int32.Parse*/(row["rha_fk_usu_id"].ToString()),
                            idReservaHabitacion
                            );

                    return reserva;
                }
                return null;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.ToString());
                return null;
            }
        }

        Dictionary<int, Entidad> IDAOReservaHabitacion.ConsultarTodosHabitacion(int id)
        {
            Dictionary<int,Entidad> listaReservas = new Dictionary<int,Entidad>();
            DataTable tablaDeDatos;
            List<Parametro> parametro = FabricaDAO.asignarListaDeParametro();

            ReservaHabitacion reserva;

            int idReserva;

            try
            {
                parametro.Add(FabricaDAO.asignarParametro(RecursoDAOM22.rha_fk_usu_id, SqlDbType.Int, id.ToString(), false));
                tablaDeDatos = EjecutarStoredProcedureTuplas(RecursoDAOM22.ProcedimientoConsultarTodos, parametro);

                foreach (DataRow row in tablaDeDatos.Rows)
                {

                    idReserva = Int32.Parse(row["rha_id"].ToString());
                    reserva = new ReservaHabitacion(
                        /*Int32.Parse*/(row["rha_cantidad_dias"].ToString()),
                            row["rha_fecha_reservacion"].ToString(),
                            row["rha_fecha_llegada"].ToString(),
                        /*Int32.Parse*/(row["rha_estado"].ToString()),                            
                        /*Int32.Parse*/(row["hot_nombre"].ToString())
                            );
                    listaReservas.Add(idReserva, reserva);

                }
                return listaReservas;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.ToString());
                return null;
            }
        }

        /// <summary>
        /// Metodo para consultar hoteles segun el id de Lugar
        /// </summary>
        /// <param name="">Variable tipo en entidad que luego debe ser casteada a su tipo para metodos get y set</param>
        /// <returns>Lista de Entidades, ya que se devuelve mas de una fila de la BD, se debe castear a su respectiva clase en el Modelo</returns>
         Dictionary<int,Entidad> IDAOReservaHabitacion.ConsultarHotelesPorIdCiudad(int _lugar)
        {
            List<Parametro> parametro = FabricaDAO.asignarListaDeParametro();
            Dictionary<int,Entidad> listaHoteles = new Dictionary<int,Entidad>();
            DataTable tablaDeDatos;

            CHotel hotel;

            int id_hotel;


            try
            {
                parametro.Add(FabricaDAO.asignarParametro(RecursoDAOM22.hot_fk_ciudad, SqlDbType.Int, _lugar.ToString(), false));
                tablaDeDatos = EjecutarStoredProcedureTuplas(RecursoDAOM22.ProcedimientoConsultarHotelesPorCiudad, parametro);

                foreach (DataRow row in tablaDeDatos.Rows)
                {

                    id_hotel = Int32.Parse(row["hot_id"].ToString());
                    hotel = new CHotel(
                            row["hot_nombre"].ToString(),
                            Int32.Parse(row["hot_cantidad_habitaciones"].ToString())
                            );
                    listaHoteles.Add(id_hotel, hotel);

                }
                return listaHoteles;
           
            }
            catch (Exception)
            {

                throw;
            }
        }
         /*
         List<Entidad> IDAOReservaHabitacion.ObtenerCiudades()
        {

            DataTable tablaDeDatos;
            List<Parametro> parametro = FabricaDAO.asignarListaDeParametro();
            List<Entidad> listaDeLugares = FabricaEntidad.asignarListaDeEntidades();
           
            Entidad lugar;

            int idLugar;
            String nombreLugar;

            try
            {
                //Aqui se asignan los valores que recibe el procedimiento para realizar el select
                //parametro.Add(FabricaDAO.asignarParametro(RecursoDAOM22.id_lugar, SqlDbType.Int,lugar._id.ToString(), false));
                tablaDeDatos = EjecutarStoredProcedureTuplas(RecursoDAOM22.ProcedimientoListarCiudades, parametro);


                foreach (DataRow filaLugar in tablaDeDatos.Rows)
                {
                    idLugar = int.Parse(filaLugar[RecursoDAOM22.id_lugar].ToString());
                    nombreLugar = filaLugar[RecursoDAOM22.nombre_lugar].ToString();
                    lugar = new CCiudad(idLugar, nombreLugar);
                    listaDeLugares.Add(lugar);
                }

                return listaDeLugares;

            }
            catch (Exception)
            {

                throw;
            }
        }*/

         List<CiudadHab> IDAOReservaHabitacion.ObtenerCiudades()
         {
             List<CiudadHab> listaCiudades = new List<CiudadHab>();
             DataTable tablaDeDatos;
             List<Parametro> parametro = FabricaDAO.asignarListaDeParametro();

             CiudadHab reserva;
             

             try
             {

                 tablaDeDatos = EjecutarStoredProcedureTuplas(RecursoDAOM22.ProcedimientoListarCiudades,parametro);

                 foreach (DataRow row in tablaDeDatos.Rows)
                 {


                     reserva = new CiudadHab(
                             Int32.Parse(row["lug_id"].ToString()),( row["lug_nombre"].ToString())
                             );
                     listaCiudades.Add(reserva);

                 }
                 return listaCiudades;
             }
             catch (SqlException ex)
             {
                 Debug.WriteLine(ex.ToString());
                 return null;
             }
         }

        }


    }
