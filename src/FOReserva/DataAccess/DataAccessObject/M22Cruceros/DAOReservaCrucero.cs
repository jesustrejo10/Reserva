using FOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using FOReserva.DataAccess.Domain;
using FOReserva.DataAccess.Model;
using FOReserva.DataAccess.DataAccessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace FOReserva.DataAccess.DataAccessObject.M22Cruceros
{
    public class DAOReservaCrucero : DAO, IDAOReservaCrucero
    {

        public DAOReservaCrucero() { }

        int IDAO.Agregar(Entidad e)
        {
            List<Parametro> listaParametro = FabricaDAO.asignarListaDeParametro();
            ReservaCrucero reserva = (ReservaCrucero) e;

            try
            {
                listaParametro.Add(FabricaDAO.asignar(RecursoDAOReservaCrucero.fechaReserva, System.Data.SqlDbType.Date, reserva._fechaReserva.ToString("MMMM dd, yyyy"), false));
                listaParametro.Add(FabricaDAO.asignar(RecursoDAOReservaCrucero.cantidadPasajeros, System.Data.SqlDbType.Int, reserva._cantidadPasajeros.ToString(), false));
                listaParametro.Add(FabricaDAO.asignar(RecursoDAOReservaCrucero.usuario, System.Data.SqlDbType.Int, reserva._usuario.ToString(), false));
                listaParametro.Add(FabricaDAO.asignar(RecursoDAOReservaCrucero.crucero, System.Data.SqlDbType.Int, reserva._crucero.ToString(), false));
                listaParametro.Add(FabricaDAO.asignar(RecursoDAOReservaCrucero.ruta, System.Data.SqlDbType.Int, reserva._ruta.ToString(), false));
                listaParametro.Add(FabricaDAO.asignar(RecursoDAOReservaCrucero.fechaInicio, System.Data.SqlDbType.Date, reserva._fechaInicio.ToString("MMMM dd, yyyy"), false));
                listaParametro.Add(FabricaDAO.asignar(RecursoDAOReservaCrucero.status, System.Data.SqlDbType.VarChar, reserva._status, false));
                EjecutarStoredProcedure(RecursoDAOReservaCrucero.ProcedimientoAgregarReserva, listaParametro);

                return 1;
            }
            
            catch (NullReferenceException ex)
            {
                
            }
            catch (ArgumentNullException ex)
            {
               
            }
            
            catch (Exception ex)
            {
                
            }
            return 0;
        }


    }
}
