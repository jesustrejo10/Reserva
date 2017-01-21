﻿using BOReserva.DataAccess.DataAccessObject;
using BOReserva.DataAccess.DataAccessObject.M08;
using BOReserva.DataAccess.Domain;
using BOReserva.Models.gestion_restaurantes;
using System;
using System.Collections.Generic;
using System.Data;
using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Model;
using System.Data.SqlClient;
//using BOReserva.Excepciones.M08;
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
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM08.disponibilidad,     SqlDbType.Int,     automovil.disponibilidad.ToString(),    false));
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

            //Log.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            //RecursoDAOM08.MensajeInicioMetodoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            //Se castea de tipo Entidad a tipo Restaurant
            Automovil automovil = (Automovil)e;
            List<Parametro> parametro = FabricaDAO.asignarListaDeParametro();

            //Atributos tabla Restaurant 
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
            Entidad auto;

            try
            {
                //Aqui se asignan los valores que recibe el procedimieto para realizar el select, se repite tantas veces como atributos
                //se requiera en el where, para este caso solo el ID del restaurante @rst_id (parametro que recibe el store procedure)
                //se coloca true en Input 
                parametro.Add(FabricaDAO.asignarParametro(RecursoDAOM08.matricula, SqlDbType.Int, automovil.matricula, false));

                //Se devuelve la fila del restaurante consultado segun el Id, para este caso solo se devuelve una fila
                DataTable filaAuto = EjecutarStoredProcedureTuplas(RecursoDAOM08.procedimientoConsultarAutomovilMatricula, parametro);

                //Se guarda la fila devuelta de la base de datos
                DataRow Fila = filaAuto.Rows[0];

                //Se preinicializan los atrubutos de la clase restaurant
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
                fk_ciudad = Fila[RecursoDAOM08.fk_ciudad].ToString();

                auto = FabricaEntidad.InstanciarAutomovil(matricula, modelo, fabricante, anio, kilometraje, cantpasajero, tipovehiculo, preciocompra, precioalquiler, penalidaddiaria, fecharegistro, color, disponibilidad, transmision, "", "", fk_ciudad);
                
                //se retorna la entidad de restaurant a mostrar en la vista
                return auto;
            }
            /*catch (ArgumentNullException ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new RecursoDAOM08("Reserva-404", "Argumento con valor invalido", ex);
            }
            catch (FormatException ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new RecursoDAOM08("Reserva-404", "Datos con un formato invalido", ex);
            }
            catch (SqlException ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new RecursoDAOM08("Reserva-404", "Error Conexion Base de Datos", ex);
            }
            catch (ExceptionBD ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new RecursoDAOM08("Reserva-404", "Error Conexion Base de Datos", ex);
            }
            catch (Exception ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new RecursoDAOM08("Reserva-404", "Error al realizar operacion ", ex);
            }*/
            catch (Exception ex)
            {
                throw;
            }
        }


        public List<Entidad> ConsultarTodos()
        {
            //Metodo para escribir en el archivo log.xml que se ha ingresado en el metodo
            //Log.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            //RecursoDAOM10.MensajeInicioMetodoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            List<Parametro> parametro = FabricaDAO.asignarListaDeParametro();
            List<Entidad> listaDeAutomoviles = FabricaEntidad.asignarListaDeEntidades();
            DataTable tablaDeDatos;
            Entidad automovil;

            //Atributos tabla Restaurant 
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
            Entidad auto;

            try
            {
                //Aqui se asignan los valores que recibe el procedimieto para realizar el select, se repite tantas veces como atributos
                //se requiera en el where, para este caso solo el ID de Lugar @lug_id (parametro que recibe el store procedure)
                parametro.Add(FabricaDAO.asignarParametro(RecursoDAOM08.lug_id, SqlDbType.Int, lugar._id.ToString(), false));

                //el metodo Ejecutar Store procedure recibe la lista de parametros como el query, este ultimo es el nombre del procedimietno en la BD
                //e.g. dbo.M10_ConsultarRestarurante
                tablaDeDatos = EjecutarStoredProcedureTuplas(RecursoDAOM08.procedimientoConsultarAutomovil, "");

                foreach (DataRow filarestaurant in tablaDeDatos.Rows)
                {
                    //Se preinicializan los atributos que componen la entidad restaurant
                    idRestaurant = int.Parse(filarestaurant[RecursoDAOM08.restaurantId].ToString());
                    nombreRestaurant = filarestaurant[RecursoDAOM08.restaurantNombre].ToString();
                    descripcionRestaurant = filarestaurant[RecursoDAOM08.restaurantDescripcion].ToString();
                    direccionRestaurant = filarestaurant[RecursoDAOM08.restaurantDireccion].ToString();
                    telefonoRestaurant = filarestaurant[RecursoDAOM08.restaurantTelefono].ToString();
                    horaIni = filarestaurant[RecursoDAOM08.restaurantHoraApertura].ToString();
                    horaFin = filarestaurant[RecursoDAOM08.restaurantHoraCierra].ToString();
                    nombreLugar = filarestaurant[RecursoDAOM08.LugarNombre].ToString();
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
