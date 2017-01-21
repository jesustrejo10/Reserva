using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.Models.gestion_automoviles;
using BOReserva.DataAccess.DataAccessObject.M08;
using BOReserva.DataAccess.Domain;
using BOReserva.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BOReserva.Excepciones.M08;
using BOReserva.Excepciones;

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
            catch (ArgumentNullException ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM08("Reserva-404", "Argumento con valor invalido", ex);
            }
            catch (FormatException ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM08("Reserva-404", "Datos con un formato invalido", ex);
            }
            catch (SqlException ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM08("Reserva-404", "Error Conexion Base de Datos", ex);
            }
            catch (ExceptionBD ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM08("Reserva-404", "Error Conexion Base de Datos", ex);
            }
            catch (Exception ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM08("Reserva-404", "Error al realizar operacion ", ex);
            }
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
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM08.disponibilidad,    SqlDbType.Int,     automovil.disponibilidad.ToString(),    false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM08.transmision,       SqlDbType.VarChar,  automovil.transmision,                  false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM08.fk_ciudad,         SqlDbType.Int,      automovil.ciudad.ToString(),            false));

                EjecutarStoredProcedure(RecursoDAOM08.procedimientoAgregarAutomovil, listaParametro);

                return true;
            }
            catch (ArgumentNullException ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM08("Reserva-404", "Argumento con valor invalido", ex);
            }
            catch (FormatException ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM08("Reserva-404", "Datos con un formato invalido", ex);
            }
            catch (SqlException ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM08("Reserva-404", "Error Conexion Base de Datos", ex);
            }
            catch (ExceptionBD ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM08("Reserva-404", "Error Conexion Base de Datos", ex);
            }
            catch (Exception ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM08("Reserva-404", "Error al realizar operacion ", ex);
            }
        }


        public Entidad Consultar(Entidad e)
        {
            //Metodo para escribir en el archivo log.xml que se ha ingresado en el metodo
            Log.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            RecursoDAOM08.MensajeInicioMetodoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            Log.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            RecursoDAOM08.MensajeInicioMetodoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            //Se castea de tipo Entidad a tipo Automovil
            Automovil automovil = (Automovil)e;
            List<Parametro> listaParametro = FabricaDAO.asignarListaDeParametro();

            //Atributos tabla Automovil 
            String matricula;
            String modelo;
            String fabricante;
            String anio;
            String kilometraje;
            String cantpasajero; 
            String tipovehiculo;
            String preciocompra;
            String precioalquiler;
            String penalidaddiaria;
            String fecharegistro;
            String color;      
            String disponibilidad;
            String transmision;
            String fk_ciudad;
            String ciudad;
            String pais;
            Entidad entidad;

            try
            {
                //Aqui se asignan los valores que recibe el procedimieto para realizar el select, se repite tantas veces como atributos
                //se requiera en el where, para este caso solo el ID del Automovil @rst_id (parametro que recibe el store procedure)
                //se coloca true en Input 
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM08.matricula, SqlDbType.VarChar, automovil.matricula, false));

                //Se devuelve la fila del Automovil consultado segun el Id, para este caso solo se devuelve una fila
                DataTable filaAutomovil = EjecutarStoredProcedureTuplas(RecursoDAOM08.procedimientoConsultarAutomovilMatricula, listaParametro);

                //Se guarda la fila devuelta de la base de datos
                DataRow Fila = filaAutomovil.Rows[0];

                //Se preinicializan los atrubutos de la clase Automovil
                matricula = Fila[RecursoDAOM08.matricula].ToString();
                modelo = Fila[RecursoDAOM08.modelo].ToString();
                fabricante = Fila[RecursoDAOM08.fabricante].ToString();
                anio = Fila[RecursoDAOM08.anio].ToString();
                kilometraje = Fila[RecursoDAOM08.kilometraje].ToString();
                cantpasajero = Fila[RecursoDAOM08.cantpasajero].ToString();
                tipovehiculo = Fila[RecursoDAOM08.tipovehiculo].ToString();
                preciocompra = Fila[RecursoDAOM08.preciocompra].ToString();
                precioalquiler = Fila[RecursoDAOM08.precioalquiler].ToString();
                penalidaddiaria = Fila[RecursoDAOM08.penalidaddiaria].ToString();
                fecharegistro = Fila[RecursoDAOM08.fecharegistro].ToString();
                color = Fila[RecursoDAOM08.color].ToString();
                disponibilidad = Fila[RecursoDAOM08.disponibilidad].ToString();
                transmision = Fila[RecursoDAOM08.transmision].ToString();
                pais = Fila[RecursoDAOM08.pais].ToString();
                ciudad = Fila[RecursoDAOM08.ciudad].ToString();
                fk_ciudad = Fila[RecursoDAOM08.fk_ciudad].ToString();


                entidad = FabricaEntidad.CrearAutomovil(matricula, modelo, fabricante, anio, kilometraje, cantpasajero, tipovehiculo, preciocompra, precioalquiler, penalidaddiaria, fecharegistro, color, disponibilidad, transmision, pais, ciudad, fk_ciudad);

                //se retorna la entidad de Automovil a mostrar en la vista
                return entidad;
            }
            catch (ArgumentNullException ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM08("Reserva-404", "Argumento con valor invalido", ex);
            }
            catch (FormatException ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM08("Reserva-404", "Datos con un formato invalido", ex);
            }
            catch (SqlException ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM08("Reserva-404", "Error Conexion Base de Datos", ex);
            }
            catch (ExceptionBD ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM08("Reserva-404", "Error Conexion Base de Datos", ex);
            }
            catch (Exception ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM08("Reserva-404", "Error al realizar operacion ", ex);
            }
        }


        public List<Entidad> ConsultarTodos()
        {
            //Metodo para escribir en el archivo log.xml que se ha ingresado en el metodo
            Log.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            RecursoDAOM08.MensajeInicioMetodoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            List<Parametro> parametro = FabricaDAO.asignarListaDeParametro();
            List<Entidad> listaDeAutomoviles = FabricaEntidad.asignarListaDeEntidades();
            DataTable tablaDeDatos;
            Entidad auto;

            //Atributos tabla Automovil 
            String matricula;
            String modelo;
            String fabricante;
            String anio;
            String kilometraje;
            String cantpasajero;
            String tipovehiculo;
            String preciocompra;
            String precioalquiler;
            String penalidaddiaria;
            String fecharegistro;
            String color;
            String disponibilidad;
            String transmision;
            String fk_ciudad;
            String ciudad;
            String pais;
            

            try
            {
                //el metodo Ejecutar Store procedure recibe la lista de parametros como el query, este ultimo es el nombre del procedimietno en la BD
                //e.g. dbo.M10_ConsultarRestarurante
                tablaDeDatos = EjecutarStoredProcedureTuplas(RecursoDAOM08.procedimientoConsultarAutomovil);

                foreach (DataRow Fila in tablaDeDatos.Rows)
                {
                    //Se preinicializan los atrubutos de la clase Automovil
                    matricula = Fila[RecursoDAOM08.matricula].ToString();
                    modelo = Fila[RecursoDAOM08.modelo].ToString();
                    fabricante = Fila[RecursoDAOM08.fabricante].ToString();
                    anio = Fila[RecursoDAOM08.anio].ToString();
                    kilometraje = Fila[RecursoDAOM08.kilometraje].ToString();
                    cantpasajero = Fila[RecursoDAOM08.cantpasajero].ToString();
                    tipovehiculo = Fila[RecursoDAOM08.tipovehiculo].ToString();
                    preciocompra = Fila[RecursoDAOM08.preciocompra].ToString();
                    precioalquiler = Fila[RecursoDAOM08.precioalquiler].ToString();
                    penalidaddiaria = Fila[RecursoDAOM08.penalidaddiaria].ToString();
                    fecharegistro = Fila[RecursoDAOM08.fecharegistro].ToString();
                    color = Fila[RecursoDAOM08.color].ToString();
                    disponibilidad = Fila[RecursoDAOM08.disponibilidad].ToString();
                    transmision = Fila[RecursoDAOM08.transmision].ToString();
                    pais = Fila[RecursoDAOM08.pais].ToString();
                    ciudad = Fila[RecursoDAOM08.ciudad].ToString();
                    fk_ciudad = Fila[RecursoDAOM08.fk_ciudad].ToString();
                    //se crea el objeto Automovil
                    auto = FabricaEntidad.CrearAutomovil(matricula, modelo, fabricante, anio, kilometraje, cantpasajero, tipovehiculo, preciocompra, precioalquiler, penalidaddiaria, fecharegistro, color, disponibilidad, transmision, pais, ciudad, fk_ciudad);
                    //se agregan los Automovil a la lista
                    listaDeAutomoviles.Add(auto);
                }

                return listaDeAutomoviles; //se retorna la lista de Automovil a mostrar por la vista
            }
            catch (ArgumentNullException ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM08("Reserva-404", "Argumento con valor invalido", ex);
            }
            catch (FormatException ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM08("Reserva-404", "Datos con un formato invalido", ex);
            }
            catch (SqlException ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM08("Reserva-404", "Error Conexion Base de Datos", ex);
            }
            catch (ExceptionBD ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM08("Reserva-404", "Error Conexion Base de Datos", ex);
            }
            catch (Exception ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM08("Reserva-404", "Error al realizar operacion ", ex);
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
            catch (ArgumentNullException ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM08("Reserva-404", "Argumento con valor invalido", ex);
            }
            catch (FormatException ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM08("Reserva-404", "Datos con un formato invalido", ex);
            }
            catch (SqlException ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM08("Reserva-404", "Error Conexion Base de Datos", ex);
            }
            catch (ExceptionBD ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM08("Reserva-404", "Error Conexion Base de Datos", ex);
            }
            catch (Exception ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM08("Reserva-404", "Error al realizar operacion ", ex);
            }
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
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM08.disponibilidad, SqlDbType.Int, automovil.disponibilidad.ToString(), false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM08.transmision, SqlDbType.VarChar, automovil.transmision, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM08.fk_ciudad, SqlDbType.Int, automovil.ciudad.ToString(), false));

                EjecutarStoredProcedure(RecursoDAOM08.procedimientoModificarAutomovil, listaParametro);

                return true;
            }
            catch (ArgumentNullException ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM08("Reserva-404", "Argumento con valor invalido", ex);
            }
            catch (FormatException ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM08("Reserva-404", "Datos con un formato invalido", ex);
            }
            catch (SqlException ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM08("Reserva-404", "Error Conexion Base de Datos", ex);
            }
            catch (ExceptionBD ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM08("Reserva-404", "Error Conexion Base de Datos", ex);
            }
            catch (Exception ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM08("Reserva-404", "Error al realizar operacion ", ex);
            }
        }
    }
}
