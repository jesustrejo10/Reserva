using FOReserva.Datos.Fabrica;
using FOReserva.Datos.InterfazDao.gestion_reserva_automovil;
using FOReserva.Models;
using FOReserva.Models.Fabrica;
using FOReserva.Models.gestion_reserva_automovil;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace FOReserva.Datos.Dao.gestion_reserva_automovil
{
    public class ReservaAutomovilDAO : DAO, IReservaAutomovilDAO
    {

        /// <summary>
        /// Metodo para consultar las reservaciones de autos por usuario
        /// </summary>
        /// <param name="_restaurant">Variable tipo en entidad que luego debe ser casteada a su tipo para metodos get y set</param>
        /// <returns>Lista de Entidades, ya que se devuelve mas de una fila de la BD, se debe castear a su respectiva clase en el Modelo</returns>
        
        public List<Entidad>Consultar(Entidad _usuario)
        {
            List<Parametro> parametro = FabricaDatosSql.asignarListaDeParametro();
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
            int _idLugarOri; 
            int _idLugarDest;
            int _estatus;

            try
            {
                //Aqui se asignan los valores que recibe el procedimieto para realizar el select, se repite tantas veces como atributos
                //se requiera en el where, para este caso solo el ID de Lugar @lug_id (parametro que recibe el store procedure)
                //se coloca true en Input 
                parametro.Add(FabricaDatosSql.asignarParametro(RecursoDAOM19.raut_fk_usuario, SqlDbType.Int, usuario._id.ToString(), true, false));

                tablaDeDatos = EjecutarStoredProcedure(parametro, RecursoDAOM19.procedimientoConsultar);

                foreach (DataRow filareserva in tablaDeDatos.Rows)
                {
                    _id = int.Parse(filareserva[RecursoDAOM19.reservaId].ToString());
                    _fecha_ini = filareserva[RecursoDAOM19.reservaFechaIni].ToString();
                    _fecha_fin = filareserva[RecursoDAOM19.reservaFechaFin].ToString();
                    _hora_ini = filareserva[RecursoDAOM19.reservaHoraIni].ToString();
                    _hora_fin = filareserva[RecursoDAOM19.reservaHoraFin].ToString();
                    _idUsuario = int.Parse(filareserva[RecursoDAOM19.reservaUsuarioFk].ToString());
                    _idAutomovil = filareserva[RecursoDAOM19.reservaAutomovilFk].ToString();
                    _idLugarOri = int.Parse(filareserva[RecursoDAOM19.reservaCiudadEntFk].ToString());
                    _idLugarDest = int.Parse(filareserva[RecursoDAOM19.reservaCiudadDevFk].ToString());
                    _estatus = int.Parse(filareserva[RecursoDAOM19.reservaEstatus].ToString());
                    reserva = FabricaEntidad.inicializarReserva(_id,_fecha_ini, _fecha_fin, _hora_ini, _hora_fin,
                                                                _idUsuario, _idAutomovil,_idLugarOri, _idLugarDest,
                                                                _estatus);
                    listaDeReservas.Add(reserva);
                }

                return listaDeReservas;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Metodo que retorna reserva segun el id
        /// </summary>
        /// <param name="_reserva"></param>
        /// <returns>Entidad</returns>
        public Entidad consultarReservaId(Entidad _reserva)
        {
            //Se castea de tipo Entidad a tipo Reserva Automovil
            CReservaAutomovilModelo resv = (CReservaAutomovilModelo)_reserva;
            List<Parametro> listaParametro = FabricaDatosSql.asignarListaDeParametro();

            int idReserva;
            String fechaIni;
            String fechaFin;
            String horaIni;
            String horaFin;
            int idUsuario;
            String idAutomovil;
            int ciudadDevo;
            int ciudadEnt;
            int estatus;
            Entidad reserva;

            try
            {
                //Aqui se asignan los valores que recibe el procedimieto para realizar el select
                listaParametro.Add(FabricaDatosSql.asignarParametro(RecursoDAOM19.raut_id, SqlDbType.Int, resv._id.ToString(), true, false));

                //Se devuelve la fila del restaurante consultado segun el Id, para este caso solo se devuelve una fila
                DataTable filareserva = EjecutarStoredProcedure(listaParametro, RecursoDAOM19.procedimientoConsultarReservaAutomovilId);

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
                ciudadDevo = int.Parse(Fila[RecursoDAOM19.reservaCiudadDevFk].ToString());
                ciudadEnt = int.Parse(Fila[RecursoDAOM19.reservaCiudadEntFk].ToString());
                estatus = int.Parse(Fila[RecursoDAOM19.reservaEstatus].ToString());
                reserva = FabricaEntidad.inicializarReserva(idReserva, fechaIni, fechaFin, horaIni, horaFin, idUsuario, idAutomovil, ciudadEnt, ciudadDevo, estatus);


                return reserva;

            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// Metodo para consultar automoviles segun el id de Lugar
        /// </summary>
        /// <param name="_automovil">Variable tipo en entidad que luego debe ser casteada a su tipo para metodos get y set</param>
        /// <returns>Lista de Entidades, ya que se devuelve mas de una fila de la BD, se debe castear a su respectiva clase en el Modelo</returns>
        public List<Entidad> ConsultarAutosPorIdCiudad(Entidad _lugar)
        {
            List<Parametro> parametro = FabricaDatosSql.asignarListaDeParametro();
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
                parametro.Add(FabricaDatosSql.asignarParametro(RecursoDAOM19.raut_fk_ciudad_entrega, SqlDbType.Int, lugar._id.ToString(), true, false));

                //el metodo Ejecutar Store procedure recibe la lista de parametros como el query, este ultimo es el nombre del procedimietno en la BD
                tablaDeDatos = EjecutarStoredProcedure(parametro, RecursoDAOM19.procedimientoConsultarAutosCiudad);

                foreach (DataRow filaautomovil in tablaDeDatos.Rows)
                {
                    matricula = filaautomovil[RecursoDAOM19.autMatricula].ToString();
                    modelo = filaautomovil[RecursoDAOM19.autModelo].ToString();
                    fabricante = filaautomovil[RecursoDAOM19.autFabricante].ToString();
                    anio = int.Parse(filaautomovil[RecursoDAOM19.autAnio].ToString());
                    kilometraje = double.Parse(filaautomovil[RecursoDAOM19.autKilometraje].ToString());
                    cantPasajeros = int.Parse(filaautomovil[RecursoDAOM19.autCantpasajeros].ToString());
                    tipo = filaautomovil[RecursoDAOM19.autTipo].ToString();
                    precioCompra = double.Parse(filaautomovil[RecursoDAOM19.autPreciocompra].ToString());
                    precioAlquiler = double.Parse(filaautomovil[RecursoDAOM19.autPrecioalquiler].ToString());
                    penalidadDiaria = double.Parse(filaautomovil[RecursoDAOM19.autPenalidaddiaria].ToString());
                    fechaRegistro = filaautomovil[RecursoDAOM19.autFecharegistro].ToString();
                    color = filaautomovil[RecursoDAOM19.autColor].ToString();
                    disponibilidad = int.Parse(filaautomovil[RecursoDAOM19.autDisponibilidad].ToString());
                    transmision = filaautomovil[RecursoDAOM19.autTransmision].ToString();
                    idCiudad = int.Parse(filaautomovil[RecursoDAOM19.autFk_ciudad].ToString());
                    automovil = FabricaEntidad.inicializarAutomovil(matricula, modelo, fabricante, anio, kilometraje, cantPasajeros, tipo, precioCompra, precioAlquiler, penalidadDiaria, fechaRegistro, color, disponibilidad, transmision, idCiudad);
                    listaDeAutomovil.Add(automovil);
                }

                return listaDeAutomovil;
            }
            catch (Exception)
            {

                throw;
            }
        }
        /// <summary>
        /// Metodo para agregar reserva de automovil
        /// </summary>
        /// <param name="_reserva"></param>
        /// <returns>Se retorna true si fue exitoso</returns>
        public bool Crear(Entidad _reserva)
        {
            CReservaAutomovilModelo res = (CReservaAutomovilModelo)_reserva;
            List<Parametro> listaParametro = FabricaDatosSql.asignarListaDeParametro();

            try
            {
                listaParametro.Add(FabricaDatosSql.asignarParametro(RecursoDAOM19.raut_fecha_ini, SqlDbType.VarChar, res._fecha_ini, false, false));
                listaParametro.Add(FabricaDatosSql.asignarParametro(RecursoDAOM19.raut_fecha_fin, SqlDbType.VarChar, res._fecha_fin, false, false));
                listaParametro.Add(FabricaDatosSql.asignarParametro(RecursoDAOM19.raut_hora_ini, SqlDbType.VarChar, res._hora_ini, false, false));
                listaParametro.Add(FabricaDatosSql.asignarParametro(RecursoDAOM19.raut_hora_fin, SqlDbType.VarChar, res._hora_fin, false, false));
                listaParametro.Add(FabricaDatosSql.asignarParametro(RecursoDAOM19.raut_fk_usuario, SqlDbType.Int, res._idUsuario.ToString(), false, false));
                listaParametro.Add(FabricaDatosSql.asignarParametro(RecursoDAOM19.raut_fk_automovil, SqlDbType.VarChar, res._idAutomovil, false, false));
                listaParametro.Add(FabricaDatosSql.asignarParametro(RecursoDAOM19.raut_fk_ciudad_devolucion, SqlDbType.Int, res._idLugarDest.ToString(), false, false));
                listaParametro.Add(FabricaDatosSql.asignarParametro(RecursoDAOM19.raut_fk_ciudad_entrega, SqlDbType.Int, res._idLugarOri.ToString(), false, false));
                listaParametro.Add(FabricaDatosSql.asignarParametro(RecursoDAOM19.raut_estatus, SqlDbType.Int, res._estatus.ToString(), false, false));

                EjecutarStoredProcedure(RecursoDAOM19.procedimientoAgregar, listaParametro);
            }
            catch (Exception)
            {

                throw;
            }
            System.Diagnostics.Debug.WriteLine(res._fecha_ini);

            return true;
        }

        /// <summary>
        /// Metodo para eliminar reserva de automovil
        /// Se encarga de eliminar la reserva de automovil por su identificador
        /// </summary>
        /// <param name="_reserva"></param>
        /// <returns>Retorna true si fue exitoso</returns>
        public bool Eliminar(Entidad _reserva)
        {
            CReservaAutomovilModelo res = (CReservaAutomovilModelo)_reserva;
            List<Parametro> parametro = FabricaDatosSql.asignarListaDeParametro();

            try
            {   
                parametro.Add(FabricaDatosSql.asignarParametro(RecursoDAOM19.raut_id, SqlDbType.Int, res._id.ToString(), true, false));
                EjecutarStoredProcedure(RecursoDAOM19.procedimientoEliminar, parametro);
            }
            catch (Exception)
            {

                throw;
            }
            return false;
        }

        /// <summary>
        /// Metodo para retornar lista de Lugares
        /// </summary>
        /// <returns>Se retorna una lista de entidad que luego debe ser casteada a su respectiva clase en el Modelo</returns>
        public List<Entidad> ListarLugar()
        {
            List<Parametro> parametro = FabricaDatosSql.asignarListaDeParametro();
            List<Entidad> listaDeLugares = FabricaEntidad.asignarListaDeEntidades();
            Entidad lugar;
            DataTable tablaDeDatos;
            int idLugar;
            String nombreLugar;

            try
            {
                tablaDeDatos = EjecutarStoredProcedure(parametro, RecursoDAOM19.procedimientoConsultarLugar);
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
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Metodo para modificar reserva
        /// </summary>
        /// <param name="_reserva"></param>
        /// <returns>Se retorna true de ser exitoso</returns>
        public bool Modificar(Entidad _reserva)
        {
            CReservaAutomovilModelo resv = (CReservaAutomovilModelo)_reserva;
            List<Parametro> listaParametro = FabricaDatosSql.asignarListaDeParametro();

            try
            {
                listaParametro.Add(FabricaDatosSql.asignarParametro(RecursoDAOM19.raut_id, SqlDbType.Int, resv._id.ToString(), true, false));
                listaParametro.Add(FabricaDatosSql.asignarParametro(RecursoDAOM19.raut_fecha_ini, SqlDbType.VarChar, resv._fecha_ini, false, false));
                listaParametro.Add(FabricaDatosSql.asignarParametro(RecursoDAOM19.raut_fecha_fin, SqlDbType.VarChar, resv._fecha_fin, false, false));
                listaParametro.Add(FabricaDatosSql.asignarParametro(RecursoDAOM19.raut_hora_ini, SqlDbType.VarChar, resv._hora_ini, false, false));
                listaParametro.Add(FabricaDatosSql.asignarParametro(RecursoDAOM19.raut_hora_fin, SqlDbType.VarChar, resv._hora_fin, false, false));
                listaParametro.Add(FabricaDatosSql.asignarParametro(RecursoDAOM19.raut_fk_usuario, SqlDbType.Int, resv._idUsuario.ToString(), false, false));
                listaParametro.Add(FabricaDatosSql.asignarParametro(RecursoDAOM19.raut_fk_automovil, SqlDbType.VarChar, resv._idAutomovil, false, false));
                listaParametro.Add(FabricaDatosSql.asignarParametro(RecursoDAOM19.raut_fk_ciudad_devolucion, SqlDbType.Int, resv._idLugarOri.ToString(), false, false));
                listaParametro.Add(FabricaDatosSql.asignarParametro(RecursoDAOM19.raut_fk_ciudad_entrega, SqlDbType.Int, resv._idLugarDest.ToString(), false, false));
                listaParametro.Add(FabricaDatosSql.asignarParametro(RecursoDAOM19.raut_estatus, SqlDbType.Int, resv._estatus.ToString(), false, false));

                EjecutarStoredProcedure(RecursoDAOM19.procedimientoActualizar, listaParametro);
            }
            catch (Exception)
            {

                throw;
            }

            return true;
        }
    }
}