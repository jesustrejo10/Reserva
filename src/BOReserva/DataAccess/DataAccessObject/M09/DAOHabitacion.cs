﻿using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
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
    /// Clase Dao Habitacion
    /// </summary>
    public class DAOHabitacion : DAO, IDAOHabitacion
    {

        /// <summary>
        /// Metodo proveniente de IDAO (No aplica)
        /// </summary>
        /// <param name="e"></param>
        /// <returns>Retorna NotImplementedException()</returns>
        int IDAO.Agregar(Entidad e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Metodo proveniente de IDAO (No aplica)
        /// </summary>
        /// <param name="e"></param>
        /// <returns>Retorna NotImplementedException()</returns>
        Entidad IDAO.Modificar(Entidad e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Metodo proveniente de IDAO (No aplica)
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Retorna NotImplementedException()</returns>
        Entidad IDAO.Consultar(int id)
        {
            throw new NotImplementedException();
        }

        

        /// <summary>
        /// Metodo proveniente de IDAO (No aplica)
        /// </summary>
        /// <returns>Retorna NotImplementedException()</returns>
        Dictionary<int, Entidad> IDAO.ConsultarTodos()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Implementacion del metodo proveniente de IDAOHabitacion para agregar habitaciones a la BD
        /// </summary>
        /// <param name="hotel">Hotel al cual se le agregaran habitaciones</param>
        /// <param name="precio">Precio por habitacion</param>
        /// <returns>Retorna un string</returns>
        string IDAOHabitacion.Agregarhab(Hotel hotel, int precio)
        {
            List<Parametro> listaParametro;
            try
            {
                if (hotel._capacidad < 100)
                {
                    for (int i = 1; i <= hotel._capacidad; i++)
                    {
                        listaParametro = FabricaDAO.asignarListaDeParametro();
                        listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM09.hot_nombre, SqlDbType.VarChar, hotel._nombre, false));
                        listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM09.hab_precio, SqlDbType.Int, Convert.ToString(precio), false));
                        EjecutarStoredProcedure(RecursoDAOM09.ProcedimientoAgregarHabitacion, listaParametro);
                    }
                    return "1";
                }
                else
                {
                    return "0";
                }
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
            catch (Exception ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM09(ex.Message, ex);
            }
        }
    }
}