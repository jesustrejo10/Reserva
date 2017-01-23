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
    /// Clase encargada de las consultas a BD de Reclamo Equipaje
    /// </summary>
    public class DAOReclamoEquipaje: DAO, IDAOReclamoEquipaje
    {        
        /// <summary>
        /// Constructor por defecto de la clase
        /// </summary>
        public DAOReclamoEquipaje() { }

        /// <summary>
        /// Metodo para hacer el insert de un reclamo de equipaje en la BD
        /// </summary>
        /// <param name="e">Entidad que posteriormente será casteada a Reclamo</param>
        /// <returns>Codigo numerico segun respuesta de Insert</returns>
        int IDAO.Agregar(Entidad e)
        {
            ReclamoEquipaje reclamo = (ReclamoEquipaje)e;
            //reclamo._estadoReclamo = "Abierto";
            List<Parametro> listaParametro = FabricaDAO.asignarListaDeParametro();
            try
            {
                listaParametro.Add(FabricaDAO.asignarParametro(M07ReclamoEquipaje.rec_fk_pasajero, SqlDbType.VarChar, reclamo._pasajero.ToString(), false));
                listaParametro.Add(FabricaDAO.asignarParametro(M07ReclamoEquipaje.rec_descripcion, SqlDbType.VarChar, reclamo._descripcionReclamo, false));
                listaParametro.Add(FabricaDAO.asignarParametro(M07ReclamoEquipaje.rec_fecha, SqlDbType.VarChar, reclamo._fechaReclamo, false));
                listaParametro.Add(FabricaDAO.asignarParametro(M07ReclamoEquipaje.rec_status, SqlDbType.Int, reclamo._estadoReclamo, false));
                listaParametro.Add(FabricaDAO.asignarParametro(M07ReclamoEquipaje.rec_fk_equipaje, SqlDbType.Int, reclamo._pasajero.ToString(), false));

                EjecutarStoredProcedure(M07ReclamoEquipaje.procedimientoAgregarReclamo, listaParametro);
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
        /// Método para consultar un reclamo en la BD
        /// </summary>
        /// <param name="id">id del reclamo a consultar</param>
        /// <returns> reclamo conseguido</returns>
        Entidad IDAO.Consultar(int id)
        {
            List<Parametro> parametro = FabricaDAO.asignarListaDeParametro();
            int rec_id, rec_fk_pasajero, rec_fk_equipaje;
            String rec_descripcion, rec_fecha, rec_status;
            Entidad reclamoE = FabricaEntidad.InstanciarReclamoEquipaje();
            ReclamoEquipaje reclamo = (ReclamoEquipaje)reclamoE;
            try
            {
                parametro.Add(FabricaDAO.asignarParametro(M07ReclamoEquipaje.rec_id, SqlDbType.Int, id.ToString(), false));
                DataTable filaReclamo = EjecutarStoredProcedureTuplas(M07ReclamoEquipaje.procedimientoConsultarReclamoPorID, parametro);
                DataRow Fila = filaReclamo.Rows[0];

                rec_id = int.Parse(Fila[M07ReclamoEquipaje.recId].ToString());
                rec_status = Fila[M07ReclamoEquipaje.recStatus].ToString();
                rec_fk_pasajero = int.Parse(Fila[M07ReclamoEquipaje.recFkPasajero].ToString());
                rec_fk_equipaje = int.Parse(Fila[M07ReclamoEquipaje.recFkEquipaje].ToString());
                rec_descripcion = Fila[M07ReclamoEquipaje.recDescripcion].ToString();
                String[] divisor = Fila[M07ReclamoEquipaje.recFecha].ToString().Split(' ');
                rec_fecha = divisor[0];
                reclamo = (ReclamoEquipaje)FabricaEntidad.InstanciarReclamoEquipaje(rec_id, rec_descripcion, rec_fecha, rec_status, rec_fk_pasajero, rec_fk_equipaje);

                return reclamo;
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
        /// Método para modificar un reclamo
        /// </summary>
        /// <param name="e">Entidad que posteriormente será casteada a Reclamo</param>
        /// <returns>retorna el reclamo</returns>
        Entidad IDAO.Modificar(Entidad e)
        {
            ReclamoEquipaje reclamo = (ReclamoEquipaje)e;
            List<Parametro> listaParametro = FabricaDAO.asignarListaDeParametro();
            try
            {
                listaParametro.Add(FabricaDAO.asignarParametro(M07ReclamoEquipaje.rec_fk_pasajero, SqlDbType.VarChar, reclamo._pasajero.ToString(), false));
                listaParametro.Add(FabricaDAO.asignarParametro(M07ReclamoEquipaje.rec_descripcion, SqlDbType.VarChar, reclamo._descripcionReclamo, false));
                listaParametro.Add(FabricaDAO.asignarParametro(M07ReclamoEquipaje.rec_fecha, SqlDbType.VarChar, reclamo._fechaReclamo, false));
                listaParametro.Add(FabricaDAO.asignarParametro(M07ReclamoEquipaje.rec_status, SqlDbType.Int, reclamo._estadoReclamo, false));
                listaParametro.Add(FabricaDAO.asignarParametro(M07ReclamoEquipaje.rec_fk_equipaje, SqlDbType.Int, reclamo._pasajero.ToString(), false));

                EjecutarStoredProcedure(M07ReclamoEquipaje.procedimientoEditarReclamo, listaParametro);
                return reclamo;
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
        /// Método para consultar todos los reclamos de equipaje en la BD
        /// </summary>
        /// <returns> Lista de reclamos de equipaje</returns>
        Dictionary<int, Entidad> IDAO.ConsultarTodos()
        {
            List<ReclamoEquipaje> listareclamos = new List<ReclamoEquipaje>();
            Dictionary<int, Entidad> listaReclamos = new Dictionary<int, Entidad>();
            SqlConnection conexion = Connection.getInstance(_connexionString);

            List<ReclamoEquipaje> reclamos = FabricaEntidad.InstanciarListaReclamoEquipaje();
            List<Parametro> parametro = FabricaDAO.asignarListaDeParametro();
            DataTable tablaDeDatos;
            int rec_id, rec_fk_pasajero, rec_fk_equipaje;
            String rec_titulo, rec_descripcion, rec_fecha, rec_estatus;
            int placeholder = 0;
            try
            {
                parametro.Add(FabricaDAO.asignarParametro(M07ReclamoEquipaje.rec_id, SqlDbType.Int, placeholder.ToString(), false));
                tablaDeDatos = EjecutarStoredProcedureTuplas(M07ReclamoEquipaje.procedimientoConsultarReclamoPorID, parametro);
                foreach (DataRow filaReclamo in tablaDeDatos.Rows)
                {
                    rec_id = int.Parse(filaReclamo[M07ReclamoEquipaje.recId].ToString());
                    rec_estatus = filaReclamo[M07ReclamoEquipaje.recStatus].ToString();
                    rec_fk_pasajero = int.Parse(filaReclamo[M07ReclamoEquipaje.recFkPasajero].ToString());
                    rec_fk_equipaje = int.Parse(filaReclamo[M07ReclamoEquipaje.recFkEquipaje].ToString());
                    rec_descripcion = filaReclamo[M07ReclamoEquipaje.recDescripcion].ToString();
                    String[] divisor = filaReclamo[M07ReclamoEquipaje.recFecha].ToString().Split(' ');
                    rec_fecha = divisor[0];
                    ReclamoEquipaje reclamo = (ReclamoEquipaje)FabricaEntidad.InstanciarReclamoEquipaje(rec_id, rec_descripcion, rec_fecha, rec_estatus, rec_fk_pasajero, rec_fk_equipaje);
                    listaReclamos.Add(rec_id, reclamo);
                }
                return listaReclamos;
            }
            catch (SqlException ex)
            {
                Debug.WriteLine(ex.ToString());
                return null;
            }
        }
        
        /// <summary>
        /// Método para eliminar reclamo equipaje
        /// </summary>
        /// <param name="id">id del reclamo equipaje a eliminar</param>
        /// <returns>codigo numerico segun resultado</returns>
        public int Eliminar(int id)
        {
            try
            {
                List<Parametro> parametro = FabricaDAO.asignarListaDeParametro();
                parametro.Add(FabricaDAO.asignarParametro(M07ReclamoEquipaje.rec_id, SqlDbType.Int, id.ToString(), false));
                EjecutarStoredProcedure(M07ReclamoEquipaje.procedimientoConsultarReclamoPorID, parametro);
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
        /// Edicion status del reclamo equipaje
        /// </summary>
        /// <param name="id">ID reclamo equipaje a editar</param>
        /// <param name="estado">Status a cambiar</param>
        /// <returns>codigo numerico segun resultado</returns>
        public int modificarEstado(int id, string estado)
        {
            try
            {
                List<Parametro> parametro = FabricaDAO.asignarListaDeParametro();
                parametro.Add(FabricaDAO.asignarParametro(M07ReclamoEquipaje.rec_id, SqlDbType.Int, id.ToString(), false));
                parametro.Add(FabricaDAO.asignarParametro(M07ReclamoEquipaje.rec_status, SqlDbType.Int, estado, false));
                EjecutarStoredProcedure(M07ReclamoEquipaje.procedimientoEditarReclamoEstado, parametro);
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