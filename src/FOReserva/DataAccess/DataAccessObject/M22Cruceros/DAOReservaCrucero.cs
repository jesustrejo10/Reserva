using FOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using FOReserva.DataAccess.Domain;
using FOReserva.DataAccess.Model;
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

            listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOReservaCrucero.fechaReserva, System.Data.SqlDbType.Date, reserva._fechaReserva, false));
            listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOReservaCrucero.cantidadPasajeros, System.Data.SqlDbType.Int, reserva._cantidadPasajeros, false));
            listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOReservaCrucero.usuario, System.Data.SqlDbType.Int, reserva._usuario, false));
            listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOReservaCrucero.crucero, System.Data.SqlDbType.Int, reserva._crucero, false));
            listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOReservaCrucero.ruta, System.Data.SqlDbType.Int, reserva._ruta, false));
            listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOReservaCrucero.fechaInicio, System.Data.SqlDbType.Date, reserva._fechaInicio, false));
            listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOReservaCrucero.status, System.Data.SqlDbType.VarChar, reserva._status, false));
            EjecutarStoredProcedure(RecursoDAOReservaCrucero.ProcedimientoAgregarReserva, listaParametro);

            return 1;
        }


    }
}
