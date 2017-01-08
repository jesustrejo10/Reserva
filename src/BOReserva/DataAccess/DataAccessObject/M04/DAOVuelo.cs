using BOReserva.DataAccess.DataAccessObject.M04;
using BOReserva.DataAccess.Domain;
using BOReserva.DataAccess.Model;
using BOReserva.DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BOReserva.DataAccess.DAO
{
    public class DAOVuelo : DAO, IDAOVuelo
    {
        public int Agregar(Entidad e)
        {
            throw new NotImplementedException();
        }

        public Entidad Modificar(Entidad e)
        {
            throw new NotImplementedException();
        }

        public Entidad Consultar(int id)
        {
            throw new NotImplementedException();
        }

        public Entidad Consultar(Entidad e)
        {
            throw new NotImplementedException();
        }

        public List<Entidad> ConsultarTodos()
        {
            DataTable resultado;
            Entidad objVuelo;
            List<Entidad> lista;
            try
            {
                resultado = EjecutarStoredProcedureTuplas(RecursoVuelo.ListarVuelos);
                Conectar();
                if (resultado != null)
                {
                    lista = new List<Entidad>();
                    foreach (DataRow row in resultado.Rows)
                    {
                        DateTime fechaDespegue = DateTime.Parse(row[RecursoVuelo.fechaDespegue].ToString());
                        string codigoVuelo = row[RecursoVuelo.codVuelo].ToString();
                        string status = row[RecursoVuelo.status].ToString();
                        DateTime fechaAterrizaje = DateTime.Parse(row[RecursoVuelo.fechaAterrizaje].ToString());
                        int id = int.Parse(row[RecursoVuelo.idVuelo].ToString());
                        int idAvion = int.Parse(row[RecursoVuelo.idAvion].ToString());
                        int idRuta = int.Parse(row[RecursoVuelo.idRuta].ToString());
                        objVuelo = FabricaEntidad.crearVuelo(id, codigoVuelo, idRuta, fechaDespegue, status,
                                                             fechaAterrizaje, idAvion);
                        lista.Add(objVuelo);
                    }
                    return lista;
                }

            }
            catch (ArgumentNullException ex)
            {
                throw ex;
            }
            catch (FormatException ex)
            {
                throw ex;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }
        
    }
}