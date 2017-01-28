using FOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using FOReserva.DataAccess.Domain;
using FOReserva.DataAccess.Model;
using FOReserva.DataAccess.DataAccessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;


namespace FOReserva.DataAccess.DataAccessObject.M22Cruceros
{
    public class DAOReservaCrucero : DAO, IDAOReservaCrucero
    {

        public DAOReservaCrucero() { }

        int IDAO.Agregar(Entidad e)
        {
            List<Parametro> listaParametro = FabricaDAO.asignarListaDeParametro();
            ReservaCrucero reserva = (ReservaCrucero)e;

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

        List<Entidad> IDAOReservaCrucero.consultarCruceros()
        {
            List<Entidad> listaCruceros = new List<Entidad>();
            DataTable tablaDeDatos;
            List<Parametro> parametro = FabricaDAO.asignarListaDeParametro();
            String nombre;
            int id;
            Cruceros crucero;


            tablaDeDatos = EjecutarStoredProcedureTuplas(RecursoDAOReservaCrucero.ProcedimientoBuscarCruceros);

            foreach (DataRow row in tablaDeDatos.Rows)
            {
                id = Int32.Parse(row["cru_id"].ToString());
                nombre = row[RecursoDAOReservaCrucero.cru_nombre].ToString();
                crucero = new Cruceros(id, nombre);
                listaCruceros.Add(crucero);
            }
            return listaCruceros;
        }


        Entidad IDAOReservaCrucero.CambiarReserva(String id_reserva, String pasajeros, String status)
        {
            Entidad reserva = null;
            List<Parametro> listaParametro = FabricaDAO.asignarListaDeParametro();
            System.Diagnostics.Debug.WriteLine("se recibio " + id_reserva + pasajeros + "con estado " + status);
            listaParametro.Add(FabricaDAO.asignar(RecursoDAOReservaCrucero.id, SqlDbType.Int, id_reserva, false));
            listaParametro.Add(FabricaDAO.asignar(RecursoDAOReservaCrucero.cantidadPasajeros, SqlDbType.Int, pasajeros, false));
            listaParametro.Add(FabricaDAO.asignar(RecursoDAOReservaCrucero.status, SqlDbType.VarChar, status, false));
            EjecutarStoredProcedure(RecursoDAOReservaCrucero.ProcedimientoModificarReserva, listaParametro);


            return reserva;
        }

        Dictionary<int, Entidad> IDAO.ConsultarTodos()
        {
            Dictionary<int, Entidad> listaCruceros = new Dictionary<int, Entidad>();
            DataTable tabla;
            Entidad reservaPerfil;
            CruceroPerfil reserva;
            List<Parametro> parametro = FabricaDAO.asignarListaDeParametro();
            string nombre, origen, destino, status, fecha_reserva, fecha_ida, fecha_vuelta;
            int id_reserva, pasajeros;
            tabla = EjecutarStoredProcedureTuplas(RecursoDAOReservaCrucero.ProcedimientoCrucerosPerfil);

            foreach (DataRow row in tabla.Rows)
            {
                id_reserva = Int32.Parse(row["rc_id"].ToString());
                fecha_reserva = row["rc_fecha"].ToString();
                pasajeros = Int32.Parse(row["rc_cantidad_pasajeros"].ToString());
                nombre = row["crucero"].ToString();
                fecha_ida = row["icru_fecha_inicio"].ToString();
                fecha_vuelta = row["icru_fecha_fin"].ToString();
                origen = row["origen"].ToString();
                destino = row["destino"].ToString();
                status = row["rc_status"].ToString();
                //System.Diagnostics.Debug.WriteLine("hola "+id_reserva.ToString() + fecha_reserva+ pasajeros.ToString()+ nombre+ fecha_ida+ fecha_vuelta+ origen+ destino+ status);

                //reservaPerfil = FabricaEntidad.InstanciarCruceroPerfil(fecha_reserva, pasajeros, nombre, fecha_ida, fecha_vuelta, origen, destino, status);
                reserva = new CruceroPerfil(fecha_reserva, pasajeros, nombre, fecha_ida, fecha_vuelta, origen, destino, status);
                listaCruceros.Add(id_reserva, reserva);
            }
            return listaCruceros;
        }

        List<Entidad> IDAOReservaCrucero.buscarCrucerosItinerario(string id, string fecha_ida, string fecha_vuelta)
        {
            List<Entidad> listaCruceros = new List<Entidad>();
            Entidad reserva;
            DataTable tablaDeDatos;
            List<Parametro> listaParametro = FabricaDAO.asignarListaDeParametro();
            string nombreCrucero, fecha_inicio, fecha_fin, origen, destino, ruta;
            int cru_id;
            try
            {
                listaParametro.Add(FabricaDAO.asignar(RecursoDAOReservaCrucero.id_crucero, System.Data.SqlDbType.VarChar, id, false));
                listaParametro.Add(FabricaDAO.asignar(RecursoDAOReservaCrucero.fechaInicio, System.Data.SqlDbType.Date, fecha_ida, false));
                listaParametro.Add(FabricaDAO.asignar(RecursoDAOReservaCrucero.fechaVuelta, System.Data.SqlDbType.Date, fecha_vuelta, false));
                tablaDeDatos = EjecutarStoredProcedureTuplas(RecursoDAOReservaCrucero.ProcedimientoBuscarItinerarios, listaParametro);

                foreach (DataRow row in tablaDeDatos.Rows)
                {
                    cru_id = Int32.Parse(row["cru_id"].ToString());
                    nombreCrucero = row["nombreCrucero"].ToString();
                    fecha_inicio = row["icru_fecha_inicio"].ToString();
                    fecha_fin = row["icru_fecha_fin"].ToString();
                    origen = row["origen"].ToString();
                    destino = row["destino"].ToString();
                    ruta = row["rut_id"].ToString();
                    
                    reserva = FabricaEntidad.InstanciarItinerarioCrucero(cru_id, nombreCrucero, fecha_inicio, fecha_fin, origen, destino, ruta);
                    CruceroPerfil efe = (CruceroPerfil)reserva;
                    //System.Diagnostics.Debug.WriteLine("en dao con "+efe._id+efe._crucero+efe._fecha_inicio+efe._fecha_fin+efe._origen+efe._destino+efe._fk_ruta);
                    listaCruceros.Add(reserva);

                }
                return listaCruceros;
            }
            catch (Exception ex)
            {

            }
            return null;
        }

        int IDAOReservaCrucero.Eliminar(int id)
        {
            List<Parametro> listaParametro = FabricaDAO.asignarListaDeParametro();

            try
            {
                listaParametro.Add(FabricaDAO.asignar(RecursoDAOReservaCrucero.id_reserva, SqlDbType.Int, id.ToString(), false));
                EjecutarStoredProcedure(RecursoDAOReservaCrucero.ProcedimientoEliminarReserva, listaParametro);
                return 1;
            }
            catch (ArgumentNullException ex)
            {
                System.Diagnostics.Debug.WriteLine("id es nulo");
            }
            catch (ExceptionBD ex)
            {
                System.Diagnostics.Debug.WriteLine("problema con la base de datos");
            }
            catch (Exception ex)
            {
                throw new Exception("ha ocurrido un problema");
            }
            return 0;
        }
    }
}
