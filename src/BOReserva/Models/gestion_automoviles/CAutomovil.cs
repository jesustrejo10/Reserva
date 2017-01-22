using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Models.gestion_automoviles
{
    public class CAutomovil
    {

        /*public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Town { get; set; }

        public Vehicle(int id, String name, String address, String town) {
            ID = id;
            Name = name;
            Address = address;
            Town = town;
        }*/


        public String _matricula { get; set; }
        public String _modelo { get; set; }
        public String _fabricante { get; set; }
        public int _anio { get; set; }
        public String _tipovehiculo { get; set; }
        public double _kilometraje { get; set; }
        public int _cantpasajeros { get; set; }
        public double _preciocompra { get; set; }
        public double _precioalquiler { get; set; }
        public double _penalidaddiaria { get; set; }
        public DateTime _fecharegistro { get; set; }
        public String _color { get; set; }
        public int _disponibilidad { get; set; }
        public String _transmision { get; set; }
        public String _pais { get; set; }
        public String _ciudad { get; set; }


        public CAutomovil(String matricula, String modelo, String fabricante, int anio, String tipovehiculo, double kilometraje, int cantpasajeros,
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

        public CAutomovil() //CONSTRUCTOR VACIO
        {

        }

        public int MAgregaraBD(CAutomovil vehiculo)
        { //METODO PARA AGREGAR A LA BASE DE DATOS
            CBasededatos_vehiculo agregar = new CBasededatos_vehiculo();
            return agregar.MAgregarVehiculoBD(vehiculo);
        }

        public List<CAutomovil> MListarvehiculos() //METODO PARA OBTENER LA LISTA DE VEHICULOS DE LA BASE DE DATOS
        {
            CBasededatos_vehiculo listar = new CBasededatos_vehiculo();
            return listar.MListarvehiculosBD();
        }

        public CAutomovil MConsultarvehiculo(String matricula) //METODO PARA OBTENER LOS DATOS DE UN VEHICULO EN ESPECIFICO DE LA BASE DE DATOS
        {
            CBasededatos_vehiculo consultar = new CBasededatos_vehiculo();
            return consultar.MMostrarvehiculoBD(matricula);
        }

        public void MActivarVehiculo()
        { //METODO PARA ACTIVAR UN VEHICULO
            _disponibilidad = 1;
        }


        public void MDesactivarVehiculo()
        { //METODO PARA DESACTIVAR UN VEHICULO
            _disponibilidad = 0;
        }

        public void MAumentarkilometraje(double kilometraje)
        { //METODO QUE AUMENTA EL KILOMETRAJE
            _kilometraje = _kilometraje + kilometraje;
        }

        public int MModificarvehiculoBD(CAutomovil vehiculo) //METODO PARA MODIFICAR UN VEHICULO
        {
            CBasededatos_vehiculo modificar = new CBasededatos_vehiculo();
            return modificar.MModificarVehiculoBD(vehiculo);
        }
    }
}