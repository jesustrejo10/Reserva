using BOReserva.DataAccess.Domain;
using BOReserva.Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Models.gestion_automoviles
{

    /// <summary>
    /// Clase que maneja los vehículos que exiten en el sistema
    /// </summary>
    public class Automovil : Entidad
    {
        #region Atributos
        private String _matricula;
        private String _modelo;
        private String _fabricante;
        private int _anio;
        private String _tipovehiculo;
        private double _kilometraje;
        private int _cantpasajeros;
        private double _preciocompra;
        private double _precioalquiler;
        private double _penalidaddiaria;
        private DateTime _fecharegistro;
        private String _color;
        private int _disponibilidad;
        private String _transmision;
        private String _pais;
        private String _ciudad;
        #endregion

        #region Constructores
        /// <summary>
        /// Constructor de la clase Automovil
        /// </summary>
        /// <param name="matricula">Matrícula del vehículo</param>
        /// <param name="modelo">Modelo del vehículo</param>
        /// <param name="fabricante">Febricante del vehículo</param>
        /// <param name="anio">Año de creación del vehículo</param>
        /// <param name="tipovehiculo">Tipo del vehículo</param>
        /// <param name="kilometraje">Kilometraje del vehículo</param>
        /// <param name="cantpasajeros">Cantidad de pasajeros del vehículo</param>
        /// <param name="preciocompra">Precio de compra del vehículo</param>
        /// <param name="precioalquiler">Precio de alquiler del vehículo</param>
        /// <param name="penalidaddiaria">Penalidad diaria del vehículo</param>
        /// <param name="fecharegistro">Fecha de registro del vehículo</param>
        /// <param name="color">Color del vehículo</param>
        /// <param name="disponibilidad">Estatus del vehículo</param>
        /// <param name="transmision">Transmisión del vehículo</param>
        /// <param name="pais">País donde se ubica el vehículo</param>
        /// <param name="ciudad">Ciudad donde se ubica el vehículo</param>
        public Automovil(String matricula, String modelo, String fabricante, int anio, String tipovehiculo, double kilometraje, int cantpasajeros,
                       double preciocompra, double precioalquiler, double penalidaddiaria, DateTime fecharegistro, String color, int disponibilidad,
                       String transmision, String pais, String ciudad)
        {
            _matricula = matricula;
            _modelo = modelo;
            _fabricante = fabricante;
            _anio = anio;
            _tipovehiculo = tipovehiculo;
            _kilometraje = kilometraje;
            _cantpasajeros = cantpasajeros;
            _preciocompra = preciocompra;
            _precioalquiler = precioalquiler;
            _penalidaddiaria = penalidaddiaria;
            _fecharegistro = fecharegistro;
            _color = color;
            _disponibilidad = disponibilidad;
            _transmision = transmision;
            _pais = pais;
            _ciudad = ciudad;
        }
        #endregion

        #region Get y Set
        public String matricula
        {
            get { return this._matricula; }
            set { this._matricula = value; }
        }

        public String modelo
        {
            get { return this._modelo; }
            set { this._modelo = value; }
        }

        public String fabricante
        {
            get { return this._fabricante; }
            set { this._fabricante = value; }
        }

        public int anio
        {
            get { return this._anio; }
            set { this._anio = value; }
        }

        public String tipovehiculo
        {
            get { return this._tipovehiculo; }
            set { this._tipovehiculo = value; }
        }

        public double kilometraje
        {
            get { return this._kilometraje; }
            set { this._kilometraje = value; }
        }

        public int cantpasajeros
        {
            get { return this._cantpasajeros; }
            set { this._cantpasajeros = value; }
        }

        public double preciocompra
        {
            get { return this._preciocompra; }
            set { this._preciocompra = value; }
        }
 
        public double precioalquiler
        {
            get { return this._precioalquiler; }
            set { this._precioalquiler = value; }
        }

        public double penalidaddiaria
        {
            get { return this._penalidaddiaria; }
            set { this._penalidaddiaria = value; }
        }

        public DateTime fecharegistro
        {
            get { return this._fecharegistro; }
            set { this._fecharegistro = value; }
        }

        public String color
        {
            get { return this._color; }
            set { this._color = value; }
        }

        public int disponibilidad
        {
            get { return this._disponibilidad; }
            set { this._disponibilidad = value; }
        }
        
        public String transmision
        {
            get { return this._transmision; }
            set { this._transmision = value; }
        }

        public String pais
        {
            get { return this._pais; }
            set { this._pais = value; }
        }

        public String ciudad
        {
            get { return this._ciudad; }
            set { this._ciudad = value; }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Método para agregar un vehículo
        /// </summary>
        /// <param name="vehiculo">Vehículo a agregar</param>
        /// <param name="id">Identificador de la ciudad donde se ubica</param>
        /// <returns>Retorna 1 se agrego correctamente y la excepcion si no puede</returns>
        //public String MAgregaraBD(Automovil vehiculo, int id)
        //{
        //    manejadorSQL agregar = new manejadorSQL();
        //    return agregar.MAgregarVehiculoBD(vehiculo, id);
        //}


        /// <summary>
        /// Método para retornar lista de vehículos 
        /// </summary>
        /// <returns>Retorna de una Lista de tipo Automovil</returns>
        //public List<Automovil> MListarvehiculos()
        //{
        //    manejadorSQL listar = new manejadorSQL();
        //    return listar.MListarvehiculosBD();
        //}


        /// <summary>
        /// Método para consultar un vehículo en particular
        /// </summary>
        /// <param name="matricula">Matrículo del vehículo a consultar</param>
        /// <returns>Retorna el vehículo de que se consulto</returns>
        //public Automovil MConsultarvehiculo(String matricula)
        //{
        //    manejadorSQL consultar = new manejadorSQL();
        //    return consultar.MMostrarvehiculoBD(matricula);
        //}



        /// <summary>
        /// Método para modificar el estatus de un vehículo
        /// </summary>
        /// <param name="matricula">Matrícula del vehículo del cual se cambiará el estatus</param>
        /// <param name="activar_o_desactivar">Estatus a colocar en el vehículo</param>
        /// <returns>Retorna si se logra modificar o no</returns>
        //public String MDisponibilidadVehiculoBD(String matricula, int activar_o_desactivar)
        //{
        //    manejadorSQL consultar = new manejadorSQL();
        //    return consultar.MDisponibilidadVehiculoBD(matricula, activar_o_desactivar);
        //}

        /// <summary>
        /// Método para modificar un vehículo
        /// </summary>
        /// <param name="vehiculo">Matrícula del vehículo que se modificará</param>
        /// <param name="id">Identificador de la ciudad donde se ubica el vehículo</param>
        /// <returns>Retorna si se logra modificar o no</returns>
        //public String MModificarvehiculoBD(Automovil vehiculo, int id)
        //{
        //    manejadorSQL modificar = new manejadorSQL();
        //    return modificar.MModificarVehiculoBD(vehiculo, id);
        //}



        /// <summary>
        /// Método para eliminar un vehículo
        /// </summary>
        /// <param name="vehiculo">Mátricula del vehículo a eliminar</param>
        /// <returns>Retorna si se logra eliminar o no</returns>
        //public String MBorrarvehiculoBD(String vehiculo) //METODO PARA MODIFICAR UN VEHICULO
        //{
        //    manejadorSQL modificar = new manejadorSQL();
        //    return modificar.MBorrarvehiculoBD(vehiculo);
        //}
        #endregion

    }
}