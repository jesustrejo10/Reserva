using System;
using System.Collections.Generic;
using FOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using FOReserva.DataAccess.Domain;
using FOReserva.DataAccess.Model;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Data;
using FOReserva.DataAccess.DataAccessObject.M16;

namespace FOReserva.DataAccess.DataAccessObject
{
    /// <summary>
    /// Clase encargada de las consultas a la BD relacionada con los reclamos
    /// </summary>
    public class DAOReclamo : DAO, IDAOReclamo
    {
        /// <summary>
        /// Constructor por defecto de la clase
        /// </summary>
        public DAOReclamo(){}

        /// <summary>
        /// Metodo para guardar un reclamo en la BD
        /// </summary>
        /// <param name="e">Entidad que posteriormente será casteada a Reclamo</param>
        /// <returns>Integer con el codigo de respuesta</returns>
        int IDAO.Agregar(Entidad e)
        {
            Reclamo reclamo = (Reclamo)e;
            List<Parametro> listaParametro = FabricaDAO.asignarListaDeParametro();
            try
            {
                listaParametro.Add(FabricaDAO.asignarParametro(M16Reclamos.rec_titulo, SqlDbType.VarChar, reclamo._tituloReclamo, false));
                listaParametro.Add(FabricaDAO.asignarParametro(M16Reclamos.rec_descripcion, SqlDbType.VarChar, reclamo._detalleReclamo, false));
                listaParametro.Add(FabricaDAO.asignarParametro(M16Reclamos.rec_fecha, SqlDbType.VarChar, reclamo._fechaReclamo, false));
                listaParametro.Add(FabricaDAO.asignarParametro(M16Reclamos.rec_estatus, SqlDbType.Int, reclamo._estadoReclamo.ToString(), false));
                listaParametro.Add(FabricaDAO.asignarParametro(M16Reclamos.rec_fk_usuario, SqlDbType.Int, reclamo._usuarioReclamo.ToString(), false));

                EjecutarStoredProcedure(M16Reclamos.procedimientoAgregarReclamo, listaParametro);
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
        /// Procedimiento para obtener todos los reclamos de un usuario
        /// </summary>
        /// <param name="_idUsuario"> id del usuario a consultar sus reclamos</param>
        /// <returns>Lista con los reclamos realizdos por el usuario</returns>
        public List<Reclamo> ConsultarReclamosPorUsuario(int _idUsuario)
        {
            List<Reclamo> reclamos = FabricaEntidad.instanciarListaReclamo();
            List<Parametro> parametro = FabricaDAO.asignarListaDeParametro();
            DataTable tablaDeDatos;
            int rec_id, rec_estatus, rec_fk_usuario;
            String rec_titulo, rec_descripcion, rec_fecha;
            try
            {
                parametro.Add(FabricaDAO.asignarParametro(M16Reclamos.rec_fk_usuario, SqlDbType.Int, _idUsuario.ToString(), false));
                tablaDeDatos = EjecutarStoredProcedureTuplas(M16Reclamos.procedimientoConsultarReclamosUsuario, parametro);
                foreach (DataRow filaReclamo in tablaDeDatos.Rows)
                {
                    rec_id = int.Parse(filaReclamo[M16Reclamos.recId].ToString());
                    rec_estatus = int.Parse(filaReclamo[M16Reclamos.recEstatus].ToString());
                    rec_fk_usuario = int.Parse(filaReclamo[M16Reclamos.recFkUsuario].ToString());
                    rec_titulo = filaReclamo[M16Reclamos.rectitulo].ToString();
                    rec_descripcion = filaReclamo[M16Reclamos.recDescripcion].ToString();
                    String[] divisor = filaReclamo[M16Reclamos.recFecha].ToString().Split(' ');
                    rec_fecha = divisor[0];
                    Reclamo reclamo = (Reclamo) FabricaEntidad.InstanciarReclamo(rec_id, rec_titulo, rec_descripcion, rec_fecha, rec_estatus, rec_fk_usuario);
                    reclamos.Add(reclamo);
                }
            }
            catch(SqlException ex)
            {
                Debug.WriteLine(ex.ToString());
                return null;
            }

            return reclamos;
        }

        /// <summary>
        /// Metodo para eliminar un reclamo en la BD
        /// </summary>
        /// <param name="_idReclamo">id del reclamo que será eliminado</param>
        /// <returns>Integer con el codigo de respuesta</returns>
        public int EliminarReclamo(int _idReclamo)
        {
            try
            {
                List<Parametro> parametro = FabricaDAO.asignarListaDeParametro();
                parametro.Add(FabricaDAO.asignarParametro(M16Reclamos.rec_id, SqlDbType.Int, _idReclamo.ToString(), false));
                EjecutarStoredProcedure(M16Reclamos.procedimientoEliminarReclamo, parametro);
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
        /// Procedimiento para modificar un reclamo
        /// </summary>
        /// <param name="reclamo">La entidad reclamo con los datos a modificar</param>
        /// <returns>Codigo representativo del resultado de la operacion</returns>
        public int ModificarReclamo(Reclamo reclamo)
        {
            List<Parametro> listaParametro = FabricaDAO.asignarListaDeParametro();
            try
            {
                listaParametro.Add(FabricaDAO.asignarParametro(M16Reclamos.rec_titulo, SqlDbType.VarChar, reclamo._tituloReclamo, false));
                listaParametro.Add(FabricaDAO.asignarParametro(M16Reclamos.rec_descripcion, SqlDbType.VarChar, reclamo._detalleReclamo, false));
                listaParametro.Add(FabricaDAO.asignarParametro(M16Reclamos.rec_fecha, SqlDbType.VarChar, reclamo._fechaReclamo, false));
                listaParametro.Add(FabricaDAO.asignarParametro(M16Reclamos.rec_id, SqlDbType.Int, reclamo._idReclamo.ToString(), false));
                EjecutarStoredProcedure(M16Reclamos.procedimientoModificarReclamo, listaParametro);
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


        Entidad IDAO.Modificar(Entidad e)
        {
            throw new NotImplementedException();
        }

        public new Dictionary<int, Entidad> ConsultarTodos()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Metodo para conocer los datos de un reclamo
        /// </summary>
        /// <param name="id">Id del comando a consultar</param>
        /// <returns>Entidad que podra ser casteada a Reclamo con los datos del mismo</returns>
        public new Entidad Consultar(int id)
        {
            List<Parametro> parametro = FabricaDAO.asignarListaDeParametro();
            int rec_id, rec_estatus, rec_fk_usuario;
            String rec_titulo, rec_descripcion, rec_fecha;
            Entidad reclamoE = FabricaEntidad.InstanciarReclamo();
            Reclamo reclamo = (Reclamo)reclamoE;
            try
            {
                parametro.Add(FabricaDAO.asignarParametro(M16Reclamos.rec_id, SqlDbType.Int, id.ToString(), false));
                DataTable filaReclamo = EjecutarStoredProcedureTuplas(M16Reclamos.procedimientoConsultarReclamoPorId, parametro);
                DataRow Fila = filaReclamo.Rows[0];

                rec_id = int.Parse(Fila[M16Reclamos.recId].ToString());
                rec_estatus = int.Parse(Fila[M16Reclamos.recEstatus].ToString());
                rec_fk_usuario = int.Parse(Fila[M16Reclamos.recFkUsuario].ToString());
                rec_titulo = Fila[M16Reclamos.rectitulo].ToString();
                rec_descripcion = Fila[M16Reclamos.recDescripcion].ToString();
                String[] divisor = Fila[M16Reclamos.recFecha].ToString().Split(' ');
                rec_fecha = divisor[0];
                reclamo = (Reclamo)FabricaEntidad.InstanciarReclamo(rec_id, rec_titulo, rec_descripcion, rec_fecha, rec_estatus, rec_fk_usuario);

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


    }
}