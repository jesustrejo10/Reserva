using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.Domain;
using BOReserva.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace BOReserva.DataAccess.DataAccessObject.M09
{
    public class DAOHabitacion : DAO, IDAOHabitacion
    {

        int IDAO.Agregar(Entidad e)
        {
            throw new NotImplementedException();
        }

        Entidad IDAO.Modificar(Entidad e)
        {
            throw new NotImplementedException();
        }

        Entidad IDAO.Consultar(int id)
        {
            throw new NotImplementedException();
        }

        int IDAO.Eliminar(int id)
        {
            throw new NotImplementedException();
        }

        Dictionary<int, Entidad> IDAO.ConsultarTodos()
        {
            throw new NotImplementedException();
        }

        string IDAOHabitacion.Agregarhab(Hotel hotel, int precio)
        {
            SqlConnection conexion = Connection.getInstance(_connexionString);
            List<Parametro> listaParametro;
            try
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
            catch (SqlException ex)
            {
                Debug.WriteLine("Ocurrio un SqlException");
                Debug.WriteLine(ex.ToString());
                conexion.Close();
                return ex.Message;
            }
            catch (NullReferenceException ex)
            {
                Debug.WriteLine("Ocurrio una NullReferenceException");
                Debug.WriteLine(ex.ToString());
                conexion.Close();
                return ex.Message;
            }
            catch (ArgumentNullException ex)
            {
                Debug.WriteLine("Ocurrio una ArgumentNullException");
                Debug.WriteLine(ex.ToString());
                conexion.Close();
                return ex.Message;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Ocurrio una Exception");
                Debug.WriteLine(ex.ToString());
                conexion.Close();
                return ex.Message;
            }
        }
    }
}