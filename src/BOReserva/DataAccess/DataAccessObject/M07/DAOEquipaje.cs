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

namespace BOReserva.DataAccess.DataAccessObject.M07
{
    /// <summary>
    /// Clase encargada de las consultas a BD de Equipaje
    /// </summary>
    public class DAOEquipaje: DAO, IDAOEquipaje
    {
        /// <summary>
        /// Constructor por defecto de la clase
        /// </summary>
        public DAOEquipaje() { }

        /// <summary>
        /// Metodo para hacer el insert de un equipaje en la BD
        /// </summary>
        /// <param name="e">Entidad que posteriormente será casteada a Equipaje</param>
        /// <returns>Codigo numerico segun respuesta de Insert</returns>
        int IDAO.Agregar(Entidad e)
        {
            Equipaje equipaje = (Equipaje)e;
            //reclamo._estadoReclamo = "Abierto";
            List<Parametro> listaParametro = FabricaDAO.asignarListaDeParametro();
            try
            {
                listaParametro.Add(FabricaDAO.asignarParametro(M07Equipaje.rec_fk_pasajero, SqlDbType.VarChar, equipaje._pasajero.ToString(), false));
                listaParametro.Add(FabricaDAO.asignarParametro(M07Equipaje.rec_descripcion, SqlDbType.VarChar, equipaje._descripcionReclamo, false));
                listaParametro.Add(FabricaDAO.asignarParametro(M07Equipaje.rec_fecha, SqlDbType.VarChar, reclamo._fechaReclamo, false));
                listaParametro.Add(FabricaDAO.asignarParametro(M07Equipaje.rec_status, SqlDbType.Int, reclamo._estadoReclamo, false));
                listaParametro.Add(FabricaDAO.asignarParametro(M07Equipaje.rec_fk_equipaje, SqlDbType.Int, reclamo._pasajero.ToString(), false));

                EjecutarStoredProcedure(M07Equipaje.procedimientoAgregarequipaje, listaParametro);
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
        /// Método para consultar un equipaje en la BD
        /// </summary>
        /// <param name="id">id del equipaje a consultar</param>
        /// <returns> equipaje conseguido</returns>
        Entidad IDAO.Consultar(int id)
        {
            List<Parametro> parametro = FabricaDAO.asignarListaDeParametro();
            int rec_id, rec_fk_pasajero, rec_fk_equipaje;
            String rec_descripcion, rec_fecha, rec_status;
            Entidad equipajeE = FabricaEntidad.InstanciarEquipaje();
            Equipaje equipaje = (Equipaje)equipajeE;
            try
            {
                parametro.Add(FabricaDAO.asignarParametro(M07Equipaje.rec_id, SqlDbType.Int, id.ToString(), false));
                DataTable filaequipaje = EjecutarStoredProcedureTuplas(M07Equipaje.procedimientoConsultarEquipajePorID, parametro);
                DataRow Fila = filaequipaje.Rows[0];

                rec_id = int.Parse(Fila[M07Equipaje.recId].ToString());
                rec_status = Fila[M07Equipaje.recStatus].ToString();
                rec_fk_pasajero = int.Parse(Fila[M07Equipaje.recFkPasajero].ToString());
                rec_fk_equipaje = int.Parse(Fila[M07Equipaje.recFkEquipaje].ToString());
                rec_descripcion = Fila[M07Equipaje.recDescripcion].ToString();
                String[] divisor = Fila[M07Equipaje.recFecha].ToString().Split(' ');
                rec_fecha = divisor[0];
                equipaje = (Equipaje)FabricaEntidad.InstanciarEquipaje(rec_id, rec_descripcion, rec_fecha, rec_status, rec_fk_pasajero, rec_fk_equipaje);

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
        /// <param name="e">Entidad que posteriormente será casteada a equipaje</param>
        /// <returns>retorna el equipaje</returns>
        Entidad IDAO.Modificar(Entidad e)
        {
            Equipaje equipaje = (Equipaje)e;
            List<Parametro> listaParametro = FabricaDAO.asignarListaDeParametro();
            try
            {
                listaParametro.Add(FabricaDAO.asignarParametro(M07Equipaje.rec_fk_pasajero, SqlDbType.VarChar, equipaje._pasajero.ToString(), false));
                listaParametro.Add(FabricaDAO.asignarParametro(M07Equipaje.rec_descripcion, SqlDbType.VarChar, equipaje._descripcionReclamo, false));
                listaParametro.Add(FabricaDAO.asignarParametro(M07Equipaje.rec_fecha, SqlDbType.VarChar, reclamo._fechaReclamo, false));
                listaParametro.Add(FabricaDAO.asignarParametro(M07Equipaje.rec_status, SqlDbType.Int, reclamo._estadoReclamo, false));
                listaParametro.Add(FabricaDAO.asignarParametro(M07Equipaje.rec_fk_equipaje, SqlDbType.Int, reclamo._pasajero.ToString(), false));

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
            List<Equipaje> listaequipajes = new List<Equipaje>();
            Dictionary<int, Entidad> listaequipajes = new Dictionary<int, Entidad>();
            SqlConnection conexion = Connection.getInstance(_connexionString);

            List<Equipaje> equipajes = FabricaEntidad.InstanciarListaEquipaje();
            List<Parametro> parametro = FabricaDAO.asignarListaDeParametro();
            DataTable tablaDeDatos;
            int rec_id, rec_fk_pasajero, rec_fk_equipaje;
            String rec_titulo, rec_descripcion, rec_fecha, rec_estatus;
            int placeholder = 0;
            try
            {
                parametro.Add(FabricaDAO.asignarParametro(M07Equipaje.rec_id, SqlDbType.Int, placeholder.ToString(), false));
                tablaDeDatos = EjecutarStoredProcedureTuplas(M07Equipaje.procedimientoConsultarEquipajePorID, parametro);
                foreach (DataRow filaequipaje in tablaDeDatos.Rows)
                {
                    rec_id = int.Parse(filaequipaje[M07Equipaje.recId].ToString());
                    rec_estatus = filaequipaje[M07Equipaje.recStatus].ToString();
                    rec_fk_pasajero = int.Parse(filaequipaje[M07Equipaje.recFkPasajero].ToString());
                    rec_fk_equipaje = int.Parse(filaequipaje[M07Equipaje.recFkEquipaje].ToString());
                    rec_descripcion = filaequipaje[M07Equipaje.recDescripcion].ToString();
                    String[] divisor = filaequipaje[M07Equipaje.recFecha].ToString().Split(' ');
                    rec_fecha = divisor[0];
                    Equipaje equipaje = (Equipaje)FabricaEntidad.InstanciarEquipaje(rec_id, rec_descripcion, rec_fecha, rec_estatus, rec_fk_pasajero, rec_fk_equipaje);
                    listaequipajes.Add(rec_id, equipaje);
                }
                return listaequipajes;
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
                parametro.Add(FabricaDAO.asignarParametro(M07Equipaje.rec_id, SqlDbType.Int, id.ToString(), false));
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