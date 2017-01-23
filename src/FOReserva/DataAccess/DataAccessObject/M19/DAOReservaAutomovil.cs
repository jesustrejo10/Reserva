using FOReserva.DataAccess.DataAccessObject.InterfacesDAO;
using FOReserva.DataAccess.DataAccessObject;
using FOReserva.DataAccess.Domain;
using FOReserva.DataAccess.Model;
using FOReserva.Models.gestion_reserva_automovil;
using FOReserva.DataAccess.DataAccessObject.M19;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using FOReserva.Excepciones.M19;
using FOReserva.Excepciones;
using System.Data.SqlClient;

namespace FOReserva.DataAccess.DataAccessObject.M19
{
    /// <summary>
    /// Clase Dao Reserva Automovil para realizar los procedimientos de base de datos
    /// </summary>
    public class DAOReservaAutomovil : DAO, IDAOReservaAutomovil
    {

        /// <summary>
        /// Metodo para consultar las reservaciones de autos por usuario
        /// </summary>
        /// <param name="_restaurant">Variable tipo en entidad que luego debe ser casteada a su tipo para metodos get y set</param>
        /// <returns>Lista de Entidades, ya que se devuelve mas de una fila de la BD, se debe castear a su respectiva clase en el Modelo</returns>

        public List<Entidad> Consultar(Entidad _usuario)
        {
            //Metodo para escribir en el archivo log.xml que se ha ingresado en el metodo
            Log.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            RecursoDAOM19.MensajeInicioMetodoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            List<Parametro> parametro = FabricaDAO.asignarListaDeParametro();
            List<Entidad> listaDeReservas = FabricaEntidad.asignarListaDeEntidades();
            DataTable tablaDeDatos;
            Entidad reserva;
            CUsuario usuario = (CUsuario)_usuario; //Se castea a tipo Usuario para poder utilizar sus metodos 

            //Atributos tabla Reserva Automovil
            int _id;
            string _fecha_ini;
            string _fecha_fin;
            string _hora_ini;
            string _hora_fin;
            int _idUsuario;
            string _idAutomovil;
            string fabricante;
            string modelo;
            string _LugarOri;
            string _LugarDest;
            int _estatus;

            try
            {
                // Parametro de entrada para la consulta: el id del usuario
                parametro.Add(FabricaDAO.asignarParametro(RecursoDAOM19.raut_fk_usuario, SqlDbType.Int, usuario._id.ToString(), false));

                tablaDeDatos = EjecutarStoredProcedureTuplas(RecursoDAOM19.procedimientoConsultar, parametro);

                foreach (DataRow filareserva in tablaDeDatos.Rows)
                {
                    _id = int.Parse(filareserva[RecursoDAOM19.reservaId].ToString());
                    _fecha_ini = filareserva[RecursoDAOM19.reservaFechaIni].ToString();
                    _fecha_fin = filareserva[RecursoDAOM19.reservaFechaFin].ToString();
                    _hora_ini = filareserva[RecursoDAOM19.reservaHoraIni].ToString();
                    _hora_fin = filareserva[RecursoDAOM19.reservaHoraFin].ToString();
                    _idUsuario = int.Parse(filareserva[RecursoDAOM19.reservaUsuarioFk].ToString());
                    _idAutomovil = filareserva[RecursoDAOM19.reservaAutomovilFk].ToString();
                    fabricante = filareserva[RecursoDAOM19.autFabricante].ToString();
                    modelo = filareserva[RecursoDAOM19.autModelo].ToString();
                    _LugarOri = filareserva[RecursoDAOM19.origen].ToString();
                    _LugarDest = filareserva[RecursoDAOM19.destino].ToString();
                    _estatus = int.Parse(filareserva[RecursoDAOM19.reservaEstatus].ToString());

                    CAutomovil automovil = FabricaEntidad.inicializarAutomovil(_idAutomovil, modelo, fabricante);
                    CLugar ori = FabricaEntidad.inicializarLugar(_LugarOri);
                    CLugar dest = FabricaEntidad.inicializarLugar(_LugarDest);

                    // INICIALIZO LA RESERVA
                    reserva = FabricaEntidad.inicializarReserva(_id, _fecha_ini, _fecha_fin, _hora_ini, _hora_fin,
                                                                _idUsuario, _estatus, automovil, ori, dest);
                    listaDeReservas.Add(reserva);
                }

                return listaDeReservas;
            }
            catch (ArgumentNullException ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM19("Reserva-404", "Argumento con valor invalido", ex);
            }
            catch (FormatException ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM19("Reserva-404", "Datos con un formato invalido", ex);
            }
            catch (SqlException ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM19("Reserva-404", "Error Conexion Base de Datos", ex);
            }
            catch (ExceptionBD ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM19("Reserva-404", "Error Conexion Base de Datos", ex);
            }
            catch (Exception ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM19("Reserva-404", "Error al realizar operacion ", ex);
            }
        }

        /// <summary>
        /// Metodo que retorna reserva segun el id
        /// </summary>
        /// <param name="_reserva"></param>
        /// <returns>Entidad</returns>
        public Entidad consultarReservaId(Entidad _reserva)
        {
            //Metodo para escribir en el archivo log.xml que se ha ingresado en el metodo
            Log.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            RecursoDAOM19.MensajeInicioMetodoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            //Se castea de tipo Entidad a tipo Reserva Automovil
            CReservaAutomovil resv = (CReservaAutomovil)_reserva;
            List<Parametro> listaParametro = FabricaDAO.asignarListaDeParametro();

            int idReserva;
            String fechaIni;
            String fechaFin;
            String horaIni;
            String horaFin;
            int idUsuario;
            String idAutomovil;
            String modelo;
            String fabricante;
            string _LugarOri;
            string _LugarDest;
            int estatus;
            Entidad reserva;

            try
            {
                //Aqui se asignan los valores que recibe el procedimieto para realizar el select
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM19.raut_id, SqlDbType.Int, resv._id.ToString(), false));

                //Se devuelve la fila de la reserva de automovil consultado segun el Id, para este caso solo se devuelve una fila
                DataTable filareserva = EjecutarStoredProcedureTuplas(RecursoDAOM19.procedimientoConsultarReservaAutomovilId, listaParametro);

                //Se guarda la fila devuelta de la base de datos
                DataRow Fila = filareserva.Rows[0];

                //Se preinicializan los atributos de la clase reserva 
                idReserva = int.Parse(Fila[RecursoDAOM19.reservaId].ToString());
                fechaIni = Fila[RecursoDAOM19.reservaFechaIni].ToString();
                fechaFin = Fila[RecursoDAOM19.reservaFechaFin].ToString();
                horaIni = Fila[RecursoDAOM19.reservaHoraIni].ToString();
                horaFin = Fila[RecursoDAOM19.reservaHoraFin].ToString();
                idUsuario = int.Parse(Fila[RecursoDAOM19.reservaUsuarioFk].ToString());
                idAutomovil = Fila[RecursoDAOM19.reservaAutomovilFk].ToString();
                fabricante = Fila[RecursoDAOM19.autFabricante].ToString();
                modelo = Fila[RecursoDAOM19.autModelo].ToString();
                _LugarOri = Fila[RecursoDAOM19.origen].ToString();
                _LugarDest = Fila[RecursoDAOM19.destino].ToString();
                estatus = int.Parse(Fila[RecursoDAOM19.reservaEstatus].ToString());

                CAutomovil automovil = FabricaEntidad.inicializarAutomovil(idAutomovil, modelo, fabricante);
                CLugar ori = FabricaEntidad.inicializarLugar(_LugarOri);
                CLugar dest = FabricaEntidad.inicializarLugar(_LugarDest);

                // INICIALIZO LA RESERVA
                reserva = FabricaEntidad.inicializarReserva(idReserva, fechaIni, fechaFin, horaIni, horaFin,
                                                            idUsuario, estatus, automovil, ori, dest);

                return reserva;

            }
            catch (ArgumentNullException ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM19("Reserva-404", "Argumento con valor invalido", ex);
            }
            catch (FormatException ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM19("Reserva-404", "Datos con un formato invalido", ex);
            }
            catch (SqlException ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM19("Reserva-404", "Error Conexion Base de Datos", ex);
            }
            catch (ExceptionBD ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM19("Reserva-404", "Error Conexion Base de Datos", ex);
            }
            catch (Exception ex)
            {

                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM19("Reserva-404", "Error al realizar operacion ", ex);
            }

        }

        /// <summary>
        /// Metodo para consultar automoviles segun el id de Lugar
        /// </summary>
        /// <param name="_automovil">Variable tipo en entidad que luego debe ser casteada a su tipo para metodos get y set</param>
        /// <returns>Lista de Entidades, ya que se devuelve mas de una fila de la BD, se debe castear a su respectiva clase en el Modelo</returns>
        public List<Entidad> ConsultarAutosPorIdCiudad(Entidad _lugar)
        {
            //Metodo para escribir en el archivo log.xml que se ha ingresado en el metodo
            Log.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            RecursoDAOM19.MensajeInicioMetodoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            List<Parametro> parametro = FabricaDAO.asignarListaDeParametro();
            List<Entidad> listaDeAutomovil = FabricaEntidad.asignarListaDeEntidades();
            DataTable tablaDeDatos;
            Entidad automovil;
            CLugar lugar = (CLugar)_lugar; //Se castea a tipo Lugar para poder utilizar sus metodos 

            //Atributos tabla Automovil 
            String matricula;
            String modelo;
            String fabricante;
            int anio;
            double kilometraje;
            int cantPasajeros;
            String tipo;
            double precioCompra;
            double precioAlquiler;
            double penalidadDiaria;
            String fechaRegistro;
            String color;
            int disponibilidad;
            String transmision;
            int idCiudad;

            try
            {
                //Aqui se asignan los valores que recibe el procedimiento para realizar el select
                parametro.Add(FabricaDAO.asignarParametro(RecursoDAOM19.raut_fk_ciudad_entrega, SqlDbType.Int, lugar._id.ToString(), false));

                //el metodo Ejecutar Store procedure recibe la lista de parametros como el query, este ultimo es el nombre del procedimietno en la BD
                tablaDeDatos = EjecutarStoredProcedureTuplas(RecursoDAOM19.procedimientoConsultarAutosCiudad, parametro);

                foreach (DataRow Fila in tablaDeDatos.Rows)
                {
                    matricula = Fila[RecursoDAOM19.autMatricula].ToString();
                    modelo = Fila[RecursoDAOM19.autModelo].ToString();
                    fabricante = Fila[RecursoDAOM19.autFabricante].ToString();
                    anio = int.Parse(Fila[RecursoDAOM19.autAnio].ToString());
                    kilometraje = double.Parse(Fila[RecursoDAOM19.autKilometraje].ToString());
                    cantPasajeros = int.Parse(Fila[RecursoDAOM19.autCantpasajeros].ToString());
                    tipo = Fila[RecursoDAOM19.autTipo].ToString();
                    precioCompra = double.Parse(Fila[RecursoDAOM19.autPreciocompra].ToString());
                    precioAlquiler = double.Parse(Fila[RecursoDAOM19.autPrecioalquiler].ToString());
                    penalidadDiaria = double.Parse(Fila[RecursoDAOM19.autPenalidaddiaria].ToString());
                    fechaRegistro = Fila[RecursoDAOM19.autFecharegistro].ToString();
                    color = Fila[RecursoDAOM19.autColor].ToString();
                    disponibilidad = int.Parse(Fila[RecursoDAOM19.autDisponibilidad].ToString());
                    transmision = Fila[RecursoDAOM19.autTransmision].ToString();
                    idCiudad = int.Parse(Fila[RecursoDAOM19.autFk_ciudad].ToString());
                    automovil = FabricaEntidad.inicializarAutomovil(matricula, modelo, fabricante, anio, kilometraje, cantPasajeros, tipo, precioCompra, precioAlquiler, penalidadDiaria, fechaRegistro, color, disponibilidad, transmision, idCiudad);
                    listaDeAutomovil.Add(automovil);
                }

                return listaDeAutomovil;
            }
            catch (ArgumentNullException ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM19("Reserva-404", "Argumento con valor invalido", ex);
            }
            catch (FormatException ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM19("Reserva-404", "Datos con un formato invalido", ex);
            }
            catch (SqlException ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM19("Reserva-404", "Error Conexion Base de Datos", ex);
            }
            catch (ExceptionBD ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM19("Reserva-404", "Error Conexion Base de Datos", ex);
            }
            catch (Exception ex)
            {

                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM19("Reserva-404", "Error al realizar operacion ", ex);
            }
        }

        /// <summary>
        /// Metodo para agregar reserva de automovil
        /// </summary>
        /// <param name="_reserva"></param>
        /// <returns>Se retorna true si fue exitoso</returns>
        public bool Crear(Entidad _reserva)
        {
            //Metodo para escribir en el archivo log.xml que se ha ingresado en el metodo
            Log.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            RecursoDAOM19.MensajeInicioMetodoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            CReservaAutomovil res = (CReservaAutomovil)_reserva;
            List<Parametro> listaParametro = FabricaDAO.asignarListaDeParametro();

            try
            {
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM19.raut_fecha_ini, SqlDbType.VarChar, res._fecha_ini, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM19.raut_fecha_fin, SqlDbType.VarChar, res._fecha_fin, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM19.raut_hora_ini, SqlDbType.VarChar, res._hora_ini, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM19.raut_hora_fin, SqlDbType.VarChar, res._hora_fin, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM19.raut_fk_usuario, SqlDbType.Int, res._idUsuario.ToString(), false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM19.raut_fk_automovil, SqlDbType.VarChar, res._idAutomovil, false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM19.raut_fk_ciudad_devolucion, SqlDbType.Int, res._idLugarDest.ToString(), false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM19.raut_fk_ciudad_entrega, SqlDbType.Int, res._idLugarOri.ToString(), false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM19.raut_estatus, SqlDbType.Int, res._estatus.ToString(), false));

                EjecutarStoredProcedure(RecursoDAOM19.procedimientoAgregar, listaParametro);
            }
            catch (ArgumentNullException ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM19("Reserva-404", "Argumento con valor invalido", ex);
            }
            catch (FormatException ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM19("Reserva-404", "Datos con un formato invalido", ex);
            }
            catch (SqlException ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM19("Reserva-404", "Error Conexion Base de Datos", ex);
            }
            catch (ExceptionBD ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM19("Reserva-404", "Error Conexion Base de Datos", ex);
            }
            catch (Exception ex)
            {

                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM19("Reserva-404", "Error al realizar operacion ", ex);
            }
            System.Diagnostics.Debug.WriteLine(res._fecha_ini);

            return true;
        }

        /// <summary>
        /// Metodo para eliminar reserva de automovil
        /// Se encarga de cambiar el estatus de la reserva a cancelada
        /// </summary>
        /// <param name="_reserva"></param>
        /// <returns>Retorna true si fue exitoso</returns>
        public bool Eliminar(Entidad _reserva)
        {
            //Metodo para escribir en el archivo log.xml que se ha ingresado en el metodo
            Log.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            RecursoDAOM19.MensajeInicioMetodoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            CReservaAutomovil res = (CReservaAutomovil)_reserva;
            List<Parametro> parametro = FabricaDAO.asignarListaDeParametro();

            try
            {
                parametro.Add(FabricaDAO.asignarParametro(RecursoDAOM19.raut_id, SqlDbType.Int, res._id.ToString(), false));
                EjecutarStoredProcedure(RecursoDAOM19.procedimientoEliminar, parametro);
            }
            catch (ArgumentNullException ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM19("Reserva-404", "Argumento con valor invalido", ex);
            }
            catch (FormatException ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM19("Reserva-404", "Datos con un formato invalido", ex);
            }
            catch (SqlException ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM19("Reserva-404", "Error Conexion Base de Datos", ex);
            }
            catch (ExceptionBD ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM19("Reserva-404", "Error Conexion Base de Datos", ex);
            }
            catch (Exception ex)
            {

                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM19("Reserva-404", "Error al realizar operacion ", ex);
            }
            return false;
        }

        /// <summary>
        /// Metodo para retornar lista de Lugares
        /// </summary>
        /// <returns>Se retorna una lista de entidad que luego debe ser casteada a su respectiva clase en el Modelo</returns>
        public List<Entidad> ListarLugar()
        {
            //Metodo para escribir en el archivo log.xml que se ha ingresado en el metodo
            Log.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            RecursoDAOM19.MensajeInicioMetodoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            List<Parametro> parametro = FabricaDAO.asignarListaDeParametro();
            List<Entidad> listaDeLugares = FabricaEntidad.asignarListaDeEntidades();
            Entidad lugar;
            DataTable tablaDeDatos;
            int idLugar;
            String nombreLugar;

            try
            {
                tablaDeDatos = EjecutarStoredProcedureTuplas(RecursoDAOM19.procedimientoConsultarLugar, parametro);
                listaDeLugares.Add(FabricaEntidad.inicializarLugar(0, ""));

                foreach (DataRow filaLugar in tablaDeDatos.Rows)
                {
                    idLugar = int.Parse(filaLugar[RecursoDAOM19.LugarId].ToString());
                    nombreLugar = filaLugar[RecursoDAOM19.LugarNombre].ToString();
                    lugar = FabricaEntidad.inicializarLugar(idLugar, nombreLugar);
                    listaDeLugares.Add(lugar);
                }

                return listaDeLugares;
            }
            catch (ArgumentNullException ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM19("Reserva-404", "Argumento con valor invalido", ex);
            }
            catch (FormatException ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM19("Reserva-404", "Datos con un formato invalido", ex);
            }
            catch (SqlException ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM19("Reserva-404", "Error Conexion Base de Datos", ex);
            }
            catch (ExceptionBD ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM19("Reserva-404", "Error Conexion Base de Datos", ex);
            }
            catch (Exception ex)
            {

                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM19("Reserva-404", "Error al realizar operacion ", ex);
            }
        }

        /// <summary>
        /// Metodo para modificar reserva
        /// </summary>
        /// <param name="_reserva"></param>
        /// <returns>Se retorna true de ser exitoso</returns>
        public bool Modificar(Entidad _reserva)
        {
            //Metodo para escribir en el archivo log.xml que se ha ingresado en el metodo
            Log.EscribirInfo(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name,
            RecursoDAOM19.MensajeInicioMetodoLogger, System.Reflection.MethodBase.GetCurrentMethod().Name);

            CReservaAutomovil resv = (CReservaAutomovil)_reserva;
            List<Parametro> listaParametro = FabricaDAO.asignarListaDeParametro();

            try
            {
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM19.raut_id, SqlDbType.Int, resv._id.ToString(), false));
                listaParametro.Add(FabricaDAO.asignarParametro(RecursoDAOM19.raut_hora_fin, SqlDbType.VarChar, resv._hora_fin, false));

                EjecutarStoredProcedure(RecursoDAOM19.procedimientoActualizar, listaParametro);
            }
            catch (ArgumentNullException ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM19("Reserva-404", "Argumento con valor invalido", ex);
            }
            catch (FormatException ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM19("Reserva-404", "Datos con un formato invalido", ex);
            }
            catch (SqlException ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM19("Reserva-404", "Error Conexion Base de Datos", ex);
            }
            catch (ExceptionBD ex)
            {
                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM19("Reserva-404", "Error Conexion Base de Datos", ex);
            }
            catch (Exception ex)
            {

                Log.EscribirError(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Name, ex);
                throw new ReservaExceptionM19("Reserva-404", "Error al realizar operacion ", ex);
            }

            return true;
        }

        #region Metodos No implementados
        Entidad IDAO.Modificar(Entidad e)
        {
            throw new NotImplementedException();
        }

        public Dictionary<int, Entidad> ConsultarTodos()
        {
            throw new NotImplementedException();
        }

        public int Agregar(Entidad e)
        {
            throw new NotImplementedException();
        }

        public Entidad Consultar(int id)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}