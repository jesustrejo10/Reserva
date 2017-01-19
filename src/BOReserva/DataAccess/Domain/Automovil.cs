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
        #region Atributos Getter and Setter
        private String _matricula { get; set; }
        private String _modelo { get; set; }
        private String _fabricante { get; set; }
        private int _anio { get; set; }
        private String _tipovehiculo { get; set; }
        private double _kilometraje { get; set; }
        private int _cantpasajeros { get; set; }
        private double _preciocompra { get; set; }
        private double _precioalquiler { get; set; }
        private double _penalidaddiaria { get; set; }
        private DateTime _fecharegistro { get; set; }
        private String _color { get; set; }
        private int _disponibilidad { get; set; }
        private String _transmision { get; set; }
        private String _pais { get; set; }
        private String _ciudad { get; set; }
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