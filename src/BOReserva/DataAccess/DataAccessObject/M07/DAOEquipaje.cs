using BOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using BOReserva.DataAccess.DataAccessObject.M07;
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
    /// <summary>
    /// Clase DAO para Equipaje
    /// </summary>
    public class DAOEquipaje: DAO, IDAOEquipaje
    {
        /// <summary>
        /// Constructor de la clase
        /// </summary>
        public DAOEquipaje() { }


        /// <summary>
        /// Metodo para hacer el insert de un reclamo de equipaje en la BD
        /// </summary>
        /// <param name="e">Entidad que posteriormente será casteada a Reclamo</param>
        /// <returns>Codigo numerico segun respuesta de Insert</returns>
        int IDAO.Agregar(Entidad e)
        {
            Equipaje equipaje = (Equipaje)e;

            List<Parametro> listaParametro = FabricaDAO.asignarListaDeParametro();
            try
            {
                listaParametro.Add(FabricaDAO.asignarParametro(M07Equipaje.equ_peso, SqlDbType.VarChar, equipaje._peso.ToString(), false));
                listaParametro.Add(FabricaDAO.asignarParametro(M07Equipaje.equ_fk_pase_abordaje, SqlDbType.VarChar, equipaje._abordaje.ToString(), false));

                EjecutarStoredProcedure(M07Equipaje.procedimientoAgregarEquipaje, listaParametro);
                return 1;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("Ocurrio un SqlException");
                Debug.WriteLine(ex.ToString());
                return 2;
            }
            catch (NullReferenceException ex)
            {
                Debug.WriteLine("Ocurrio una NullReferenceException");
                Debug.WriteLine(ex.ToString());
                return 3;
            }
            catch (ArgumentNullException ex)
            {
                Debug.WriteLine("Ocurrio una ArgumentNullException");
                Debug.WriteLine(ex.ToString());
                return 4;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Ocurrio una Exception");
                Debug.WriteLine(ex.ToString());
                return 5;
            }
        }

        /// <summary>
        /// Método para consultar equipaje en la BD
        /// </summary>
        /// <param name="id">id del equipaje a consultar</param>
        /// <returns> equipaje conseguido</returns>
        Entidad IDAO.Consultar(int id)
        {
            List<Parametro> parametro = FabricaDAO.asignarListaDeParametro();
            int equ_id, equ_peso, equ_fk_abordaje;
            Entidad equipajeE = FabricaEntidad.InstanciarEquipaje();
            Equipaje equipaje = (Equipaje)equipajeE;
            try
            {
                parametro.Add(FabricaDAO.asignarParametro(M07Equipaje.equ_id, SqlDbType.Int, id.ToString(), false));
                DataTable filaEquipaje = EjecutarStoredProcedureTuplas(M07Equipaje.procedimientoConsultarEquipajePorID, parametro);
                DataRow Fila = filaEquipaje.Rows[0];

                equ_id = int.Parse(Fila[M07Equipaje.equID].ToString());
                equ_peso = int.Parse(Fila[M07Equipaje.equPeso].ToString());
                equ_fk_abordaje = int.Parse(Fila[M07Equipaje.equFkPaseAbordaje].ToString());
                equipaje = (Equipaje)FabricaEntidad.InstanciarEquipaje(equ_id, equ_peso, equ_fk_abordaje);

                return equipaje;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.ToString());
                return null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return null;
            }
        }

        /// <summary>
        /// Método para modificar un equipaje
        /// </summary>
        /// <param name="e">Entidad que posteriormente será casteada a Equipaje</param>
        /// <returns>retorna el equipaje</returns>
        Entidad IDAO.Modificar(Entidad e)
        {
            Equipaje equipaje = (Equipaje)e;
            List<Parametro> listaParametro = FabricaDAO.asignarListaDeParametro();
            try
            {
                listaParametro.Add(FabricaDAO.asignarParametro(M07Equipaje.equ_peso, SqlDbType.VarChar, equipaje._peso.ToString(), false));
                listaParametro.Add(FabricaDAO.asignarParametro(M07Equipaje.equ_fk_pase_abordaje, SqlDbType.VarChar, equipaje._abordaje.ToString(), false));

                EjecutarStoredProcedure(M07Equipaje.procedimientoEditarEquipaje, listaParametro);
                return equipaje;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("Ocurrio un SqlException");
                Debug.WriteLine(ex.ToString());
                return null;
            }
            catch (NullReferenceException ex)
            {
                Debug.WriteLine("Ocurrio una NullReferenceException");
                Debug.WriteLine(ex.ToString());
                return null;
            }
            catch (ArgumentNullException ex)
            {
                Debug.WriteLine("Ocurrio una ArgumentNullException");
                Debug.WriteLine(ex.ToString());
                return null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Ocurrio una Exception");
                Debug.WriteLine(ex.ToString());
                return null;
            }
        }

        /// <summary>
        /// Método para consultar todos los equipajes en la BD
        /// </summary>
        /// <returns> Lista de equipajes</returns>
        Dictionary<int, Entidad> IDAO.ConsultarTodos()
        {
            List<Equipaje> listaequipaje = new List<Equipaje>();
            Dictionary<int, Entidad> listaEquipaje = new Dictionary<int, Entidad>();
            SqlConnection conexion = Connection.getInstance(_connexionString);

            List<Equipaje> equipajes = FabricaEntidad.InstanciarListaEquipaje();
            List<Parametro> parametro = FabricaDAO.asignarListaDeParametro();
            DataTable tablaDeDatos;
            int equ_id, equ_peso, equ_fk_abordaje;
            int placeholder = 0;
            try
            {
                parametro.Add(FabricaDAO.asignarParametro(M07Equipaje.equ_id, SqlDbType.Int, placeholder.ToString(), false));
                tablaDeDatos = EjecutarStoredProcedureTuplas(M07Equipaje.procedimientoConsultarEquipajePorID, parametro);
                foreach (DataRow filaEquipaje in tablaDeDatos.Rows)
                {
                    equ_id = int.Parse(filaEquipaje[M07Equipaje.equID].ToString());
                    equ_peso = int.Parse(filaEquipaje[M07Equipaje.equPeso].ToString());
                    equ_fk_abordaje = int.Parse(filaEquipaje[M07Equipaje.equFkPaseAbordaje].ToString());

                    Equipaje equipaje = (Equipaje)FabricaEntidad.InstanciarEquipaje(equ_id, equ_peso, equ_fk_abordaje);
                    listaEquipaje.Add(equ_id, equipaje);
                }
                return listaEquipaje;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.ToString());
                return null;
            }
        }
        
        /// <summary>
        /// Método para eliminar equipaje
        /// </summary>
        /// <param name="id">id del equipaje a eliminar</param>
        /// <returns>codigo numerico segun resultado</returns>
        public int Eliminar(int id)
        {
            try
            {
                List<Parametro> parametro = FabricaDAO.asignarListaDeParametro();
                parametro.Add(FabricaDAO.asignarParametro(M07Equipaje.equ_id, SqlDbType.Int, id.ToString(), false));
                EjecutarStoredProcedure(M07Equipaje.procedimientoConsultarEquipajePorID, parametro);
                return 1;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("Ocurrio un SqlException");
                Debug.WriteLine(ex.ToString());
                return 2;
            }
            catch (NullReferenceException ex)
            {
                Debug.WriteLine("Ocurrio una NullReferenceException");
                Debug.WriteLine(ex.ToString());
                return 3;
            }
            catch (ArgumentNullException ex)
            {
                Debug.WriteLine("Ocurrio una ArgumentNullException");
                Debug.WriteLine(ex.ToString());
                return 4;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Ocurrio una Exception");
                Debug.WriteLine(ex.ToString());
                return 5;
            }
        }
        
    }
}