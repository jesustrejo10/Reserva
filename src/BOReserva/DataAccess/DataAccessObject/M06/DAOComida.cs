using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using BOReserva.DataAccess.Model;

using System;
using System.Collections.Generic;
using System.Data;
using BOReserva.DataAccess.DataAccessObject.M06;
using System.Data.SqlClient;

namespace BOReserva.DataAccess.DataAccessObject
{
    public class DAOComida : DAO, IDAOComida 
    {
        public bool crear(Entidad entidad) {
            Comida comida = (Comida)entidad;
            List<Parametro> lista = FabricaDAO.asignarListaDeParametro();

            try
            {
                lista.Add(FabricaDAO.asignarParametro(RecursoM06.com_nombre, SqlDbType.VarChar, comida._nombre, false));
                lista.Add(FabricaDAO.asignarParametro(RecursoM06.com_tipo, SqlDbType.VarChar, comida._tipo, false));
                lista.Add(FabricaDAO.asignarParametro(RecursoM06.com_estatus, SqlDbType.Int, comida._estatus.ToString(), false));
                lista.Add(FabricaDAO.asignarParametro(RecursoM06.com_descripcion, SqlDbType.VarChar, comida._descripcion, false));

                EjecutarStoredProcedure(RecursoM06.procedimientoAgregarComida, lista);
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
    }
}