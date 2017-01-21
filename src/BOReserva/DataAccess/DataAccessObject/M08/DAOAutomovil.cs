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

        public Entidad Consultar(int id)
        {
            throw new NotImplementedException();
        }

        public Dictionary<int, Entidad> ConsultarTodos()
        {
            throw new NotImplementedException();
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
