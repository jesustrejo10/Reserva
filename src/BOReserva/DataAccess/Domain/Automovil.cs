using BOReserva.Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.DataAccess.Domain
{

    /// <summary>
    /// Dominio del objeto autimovil del sistema
    /// </summary>
    public class Automovil : Entidad
    {
        #region Atributos
        private String _matricula;
        private String _modelo;
        private String _fabricante;
        private int _anio;
        private String _tipovehiculo;
        private Decimal _kilometraje;
        private int _cantpasajeros;
        private Decimal _preciocompra;
        private Decimal _precioalquiler;
        private Decimal _penalidaddiaria;
        private DateTime _fecharegistro;
        private String _color;
        private int _disponibilidad;
        private String _transmision;
        private String _pais;
        private String _ciudad;
        private int _fk_ciudad;
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
        public Automovil(String matricula, String modelo, String fabricante, String anio, String tipovehiculo, String kilometraje, String cantpasajeros,
                       String preciocompra, String precioalquiler, String penalidaddiaria, String fecharegistro, String color, String disponibilidad,
                       String transmision, String pais, String ciudad, String fk_ciudad)
        {
            _matricula       = Convert.ToString(matricula);
            _modelo          = Convert.ToString(modelo);
            _fabricante      = Convert.ToString(fabricante);
            _anio            = Convert.ToInt32(anio);
            _tipovehiculo    = Convert.ToString(tipovehiculo);
            _kilometraje     = Convert.ToDecimal(kilometraje);
            _cantpasajeros   = Convert.ToInt32(cantpasajeros);
            _preciocompra    = Convert.ToDecimal(preciocompra);
            _precioalquiler  = Convert.ToDecimal(precioalquiler);
            _penalidaddiaria = Convert.ToDecimal(penalidaddiaria);
            _fecharegistro   = Convert.ToDateTime(fecharegistro);
            _color           = Convert.ToString(color);
            _disponibilidad  = Convert.ToInt32(disponibilidad);
            _transmision     = Convert.ToString(transmision);
            _pais            = Convert.ToString(pais);
            _ciudad          = Convert.ToString(ciudad);
            _fk_ciudad        = Convert.ToInt32(fk_ciudad);
        }

        public Automovil() { }
        #endregion

        #region Get y Set
        public String matricula
        {
            get { return this._matricula; }
            set { this._matricula = Convert.ToString(value); }
        }

        public String modelo
        {
            get { return this._modelo; }
            set { this._modelo = Convert.ToString(value); }
        }

        public String fabricante
        {
            get { return this._fabricante; }
            set { this._fabricante = Convert.ToString(value); }
        }

        public int anio
        {
            get { return this._anio; }
            set { this._anio = Convert.ToInt32(value); }
        }

        public String tipovehiculo
        {
            get { return this._tipovehiculo; }
            set { this._tipovehiculo = Convert.ToString(value); }
        }

        public Decimal kilometraje
        {
            get { return this._kilometraje; }
            set { this._kilometraje = Convert.ToDecimal(value); }
        }

        public int cantpasajeros
        {
            get { return this._cantpasajeros; }
            set { this._cantpasajeros = Convert.ToInt32(value); }
        }

        public Decimal preciocompra
        {
            get { return this._preciocompra; }
            set { this._preciocompra = Convert.ToDecimal(value); }
        }
 
        public Decimal precioalquiler
        {
            get { return this._precioalquiler; }
            set { this._precioalquiler = value; }
        }

        public Decimal penalidaddiaria
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
            set { this._color = Convert.ToString(value); }
        }

        public int disponibilidad
        {
            get { return this._disponibilidad; }
            set { this._disponibilidad = Convert.ToInt32(value); }
        }
        
        public String transmision
        {
            get { return this._transmision; }
            set { this._transmision = Convert.ToString(value); }
        }

        public String pais
        {
            get { return this._pais; }
            set { this._pais = Convert.ToString(value); }
        }

        public String ciudad
        {
            get { return this._ciudad; }
            set { this._ciudad = Convert.ToString(value); }
        }
        public int fk_ciudad
        {
            get { return this._fk_ciudad; }
            set { this._fk_ciudad = Convert.ToInt32(value); }
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