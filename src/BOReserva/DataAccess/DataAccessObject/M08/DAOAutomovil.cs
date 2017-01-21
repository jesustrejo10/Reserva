using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.Models.gestion_automoviles;
using BOReserva.DataAccess.DataAccessObject.M08;
using BOReserva.DataAccess.Domain;
using BOReserva.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace BOReserva.DataAccess.DataAccessObject
{
    public class DAOAutomovil : DAO, IDAOAutomovil
    {
        public bool ActivarDesactivar(Entidad e)
        {
            Automovil automovil = (Automovil)e;
            List<Parametro> parametro = FabricaDAO.asignarListaDeParametro();
            try
            {
                parametro.Add(FabricaDAO.asignarParametro(RecursoDAOM08.aut_matricula, SqlDbType.VarChar, automovil.matricula, false));

                EjecutarStoredProcedure(RecursoDAOM08.procedimientoCambiarEstatus, parametro);

                return true;
            }
            catch (Exception)
            {
                throw;
            }
            return false; 
        }


        public bool Agregar(Entidad e)
        {
            Automovil automovil = (Automovil)e;
            List<Parametro> listaParametro = FabricaDAO.asignarListaDeParametro();
            try
            {
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM08.matricula,         SqlDbType.VarChar,  automovil.matricula,                    false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM08.modelo,            SqlDbType.VarChar,  automovil.modelo,                       false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM08.fabricante,        SqlDbType.VarChar,  automovil.fabricante,                   false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM08.anio,              SqlDbType.Int,      automovil.anio.ToString(),              false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM08.kilometraje,       SqlDbType.VarChar,  automovil.kilometraje.ToString(),       false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM08.cantpasajero,      SqlDbType.Decimal,  automovil.cantpasajeros.ToString(),     false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM08.tipovehiculo,      SqlDbType.Int,      automovil.tipovehiculo,                 false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM08.preciocompra,      SqlDbType.Decimal,  automovil.preciocompra.ToString(),      false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM08.precioalquiler,    SqlDbType.Decimal,  automovil.precioalquiler.ToString(),    false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM08.penalidaddiaria,   SqlDbType.Decimal,  automovil.penalidaddiaria.ToString(),   false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM08.fecharegistro,     SqlDbType.Date,     automovil.fecharegistro.ToString(),     false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM08.color,             SqlDbType.VarChar,  automovil.color,                        false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM08.disponibilida,     SqlDbType.Int,      automovil.disponibilidad.ToString(),    false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM08.transmision,       SqlDbType.VarChar,  automovil.transmision,                  false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM08.fk_ciudad,         SqlDbType.Int,      automovil.ciudad.ToString(),            false));

                EjecutarStoredProcedure(RecursoDAOM08.procedimientoAgregarAutomovil, listaParametro);

                return true;
            }
            catch (Exception)
            {
                throw;
            }
            return false;
        }


        public Entidad Consultar(Entidad e)
        {
            //Metodo para escribir en el archivo log.xml que se ha ingresado en el metodo
            Log.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            RecursoDAOM10.MensajeInicioMetodoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            //Se castea de tipo Entidad a tipo Restaurant
            CRestauranteModelo rest = (CRestauranteModelo)_restaurant;
            List<Parametro> listaParametro = FabricaDAO.asignarListaDeParametro();

            //Atributos tabla Restaurant 
            int idRestaurant;
            String nombreRestaurant;
            String descripcionRestaurant;
            String direccionRestaurant;
            String telefonoRestaurant;
            String horaIni;
            String horaFin;
            String idLugar;
            Entidad restaurant;

            try
            {
                //Aqui se asignan los valores que recibe el procedimieto para realizar el select, se repite tantas veces como atributos
                //se requiera en el where, para este caso solo el ID del restaurante @rst_id (parametro que recibe el store procedure)
                //se coloca true en Input 
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM10.rst_id, SqlDbType.Int, rest._id.ToString(), false));

                //Se devuelve la fila del restaurante consultado segun el Id, para este caso solo se devuelve una fila
                DataTable filarestaurant = EjecutarStoredProcedureTuplas(RecursoDAOM10.procedimientoConsultarRestaurantId, listaParametro);

                //Se guarda la fila devuelta de la base de datos
                DataRow Fila = filarestaurant.Rows[0];

                //Se preinicializan los atrubutos de la clase restaurant 
                idRestaurant = int.Parse(Fila[RecursoDAOM10.restaurantId].ToString());
                nombreRestaurant = Fila[RecursoDAOM10.restaurantNombre].ToString();
                descripcionRestaurant = Fila[RecursoDAOM10.restaurantDescripcion].ToString();
                direccionRestaurant = Fila[RecursoDAOM10.restaurantDireccion].ToString();
                telefonoRestaurant = Fila[RecursoDAOM10.restaurantTelefono].ToString();
                horaIni = Fila[RecursoDAOM10.restaurantHoraApertura].ToString();
                horaFin = Fila[RecursoDAOM10.restaurantHoraCierra].ToString();
                idLugar = Fila[RecursoDAOM10.LugarIdFk].ToString();
                restaurant = FabricaEntidad.crearRestaurant(idRestaurant, nombreRestaurant, direccionRestaurant, telefonoRestaurant, descripcionRestaurant, horaIni, horaFin, int.Parse(idLugar));

                //se retorna la entidad de restaurant a mostrar en la vista
                return restaurant;
            }
            catch (ArgumentNullException ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM10("Reserva-404", "Argumento con valor invalido", ex);
            }
            catch (FormatException ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM10("Reserva-404", "Datos con un formato invalido", ex);
            }
            catch (SqlException ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM10("Reserva-404", "Error Conexion Base de Datos", ex);
            }
            catch (ExceptionBD ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM10("Reserva-404", "Error Conexion Base de Datos", ex);
            }
            catch (Exception ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM10("Reserva-404", "Error al realizar operacion ", ex);
            }
        }


        public List<Entidad> ConsultarTodos()
        {
            //Metodo para escribir en el archivo log.xml que se ha ingresado en el metodo
            Log.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            RecursoDAOM10.MensajeInicioMetodoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            List<Parametro> parametro = FabricaDAO.asignarListaDeParametro();
            List<Entidad> listaDeRestaurant = FabricaEntidad.asignarListaDeEntidades();
            DataTable tablaDeDatos;
            Entidad restaurant;
            Lugar lugar = (Lugar)_lugar; //Se castea a tipo Lugar para poder utilizar sus metodos 

            //Atributos tabla Restaurant 
            int idRestaurant;
            String nombreRestaurant;
            String descripcionRestaurant;
            String direccionRestaurant;
            String telefonoRestaurant;
            String horaIni;
            String horaFin;
            String nombreLugar;

            try
            {
                //Aqui se asignan los valores que recibe el procedimieto para realizar el select, se repite tantas veces como atributos
                //se requiera en el where, para este caso solo el ID de Lugar @lug_id (parametro que recibe el store procedure)
                parametro.Add(FabricaDAO.asignarParametro(RecursoDAOM10.lug_id, SqlDbType.Int, lugar._id.ToString(), false));

                //el metodo Ejecutar Store procedure recibe la lista de parametros como el query, este ultimo es el nombre del procedimietno en la BD
                //e.g. dbo.M10_ConsultarRestarurante
                tablaDeDatos = EjecutarStoredProcedureTuplas(RecursoDAOM10.procedimientoConsultar, parametro);

                foreach (DataRow filarestaurant in tablaDeDatos.Rows)
                {
                    //Se preinicializan los atributos que componen la entidad restaurant
                    idRestaurant = int.Parse(filarestaurant[RecursoDAOM10.restaurantId].ToString());
                    nombreRestaurant = filarestaurant[RecursoDAOM10.restaurantNombre].ToString();
                    descripcionRestaurant = filarestaurant[RecursoDAOM10.restaurantDescripcion].ToString();
                    direccionRestaurant = filarestaurant[RecursoDAOM10.restaurantDireccion].ToString();
                    telefonoRestaurant = filarestaurant[RecursoDAOM10.restaurantTelefono].ToString();
                    horaIni = filarestaurant[RecursoDAOM10.restaurantHoraApertura].ToString();
                    horaFin = filarestaurant[RecursoDAOM10.restaurantHoraCierra].ToString();
                    nombreLugar = filarestaurant[RecursoDAOM10.LugarNombre].ToString();
                    //se crea el objeto restaurant
                    restaurant = FabricaEntidad.crearRestaurant(idRestaurant, nombreRestaurant, direccionRestaurant, telefonoRestaurant, descripcionRestaurant, horaIni, horaFin, 0);
                    //se agregan los restaurantes a la lista
                    listaDeRestaurant.Add(restaurant);
                }

                return listaDeRestaurant; //se retorna la lista de restaurante a mostrar por la vista
            }
            catch (ArgumentNullException ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM10("Reserva-404", "Argumento con valor invalido", ex);
            }
            catch (FormatException ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM10("Reserva-404", "Datos con un formato invalido", ex);
            }
            catch (SqlException ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM10("Reserva-404", "Error Conexion Base de Datos", ex);
            }
            catch (ExceptionBD ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM10("Reserva-404", "Error Conexion Base de Datos", ex);
            }
            catch (Exception ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM10("Reserva-404", "Error al realizar operacion ", ex);
            }
        }


        public bool Eliminar(Entidad e)
        {
            Automovil automovil = (Automovil)e;
            List<Parametro> parametro = FabricaDAO.asignarListaDeParametro();
            try
            {
                parametro.Add(FabricaDAO.asignarParametro(RecursoDAOM08.aut_matricula, SqlDbType.VarChar, automovil.matricula, false));

                EjecutarStoredProcedure(RecursoDAOM08.procedimientoEliminarAutomovil, parametro);

                return true;
            }
            catch (Exception)
            {
                throw;
            }
            return false;
        }


        public bool Modificar(Entidad e)
        {
            Automovil automovil = (Automovil)e;
            List<Parametro> listaParametro = FabricaDAO.asignarListaDeParametro();
            try
            {
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM08.matricula, SqlDbType.VarChar, automovil.matricula, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM08.modelo, SqlDbType.VarChar, automovil.modelo, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM08.fabricante, SqlDbType.VarChar, automovil.fabricante, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM08.anio, SqlDbType.Int, automovil.anio.ToString(), false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM08.kilometraje, SqlDbType.VarChar, automovil.kilometraje.ToString(), false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM08.cantpasajero, SqlDbType.Decimal, automovil.cantpasajeros.ToString(), false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM08.tipovehiculo, SqlDbType.Int, automovil.tipovehiculo, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM08.preciocompra, SqlDbType.Decimal, automovil.preciocompra.ToString(), false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM08.precioalquiler, SqlDbType.Decimal, automovil.precioalquiler.ToString(), false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM08.penalidaddiaria, SqlDbType.Decimal, automovil.penalidaddiaria.ToString(), false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM08.fecharegistro, SqlDbType.Date, automovil.fecharegistro.ToString(), false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM08.color, SqlDbType.VarChar, automovil.color, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM08.disponibilida, SqlDbType.Int, automovil.disponibilidad.ToString(), false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM08.transmision, SqlDbType.VarChar, automovil.transmision, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM08.fk_ciudad, SqlDbType.Int, automovil.ciudad.ToString(), false));

                EjecutarStoredProcedure(RecursoDAOM08.procedimientoModificarAutomovil, listaParametro);

                return true;
            }
            catch (Exception)
            {
                throw;
            }
            return false;
        }
    }
}
