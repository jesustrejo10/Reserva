using FOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.Models.gestion_reserva_automovil
{
    public class CAutomovil : Entidad
    {
        #region Get y Set
        public String _matricula { get; set; }
        public String _modelo { get; set; }
        public String _fabricante { get; set; }
        public int _anio { get; set; }
        public double _kilometraje { get; set; }
        public int _cantPasajeros { get; set; }
        public String _tipo { get; set; }
        public double _precioCompra { get; set; }
        public double _precioAlquiler { get; set; }
        public double _penalidadDiaria { get; set; }
        public String _fechaRegistro { get; set; }
        public String _color { get; set; }
        public int _disponibilidad { get; set; }
        public String _transmision { get; set; }
        public int _idCiudad { get; set; }
        public List<CAutomovil> _listaAutomoviles { get; set; }
        public String _fechaini { get; set; }
        public String _fechafin { get; set; }
        public String _horaini { get; set; }
        public String _horafin { get; set; }

        public int _ciudadorigen { get; set; }
        public int _ciudaddestino { get; set; }

        #endregion


        #region Constructores
        public CAutomovil() { }

        public CAutomovil(string matricula, string modelo, string fabricante, int anio, double kilometraje, int cantPasajeros, string tipo, double precioCompra, double precioAlquiler, double penalidadDiaria, string fechaRegistro, string color, int disponibilidad, string transmision, int idCiudad)
        {

            _matricula = matricula;
            _modelo = modelo;
            _fabricante = fabricante;
            _anio = anio;
            _kilometraje = kilometraje;
            _cantPasajeros = cantPasajeros;
            _tipo = tipo;
            _precioCompra = _precioCompra;
            _precioAlquiler = precioAlquiler;
            _penalidadDiaria = penalidadDiaria;
            _fechaRegistro = fechaRegistro;
            _color = color;
            _disponibilidad = disponibilidad;
            _transmision = transmision;
            _idCiudad = idCiudad;
            _listaAutomoviles = new List<CAutomovil>();

        }

        public CAutomovil(string matricula, string modelo, string fabricante, string tipo, string color, string transmision, int idCiudad, double precioAlquiler, int anio, int cantPasajeros, int disponibilidad, string fechaini, string fechafin, string horaini, string horafin, int ciudadorigen, int ciudaddestino)
        {

            _matricula = matricula;
            _modelo = modelo;
            _fabricante = fabricante;
            _anio = anio;
            _cantPasajeros = cantPasajeros;
            _tipo = tipo;
            _precioCompra = _precioCompra;
            _precioAlquiler = precioAlquiler;
            _color = color;
            _disponibilidad = disponibilidad;
            _transmision = transmision;
            _idCiudad = idCiudad;
            _fechaini = fechaini;
            _fechafin = fechafin;
            _horaini = horaini;
            _horafin = horafin;
            _ciudadorigen = ciudadorigen;
            _ciudaddestino = ciudaddestino;



            _listaAutomoviles = new List<CAutomovil>();

        }

        public CAutomovil(string matricula, string modelo, string fabricante, string tipo, string color, string transmision, int idCiudad, double precioAlquiler, int anio, int cantPasajeros, int disponibilidad)
        {

            _matricula = matricula;
            _modelo = modelo;
            _fabricante = fabricante;
            _anio = anio;
            _cantPasajeros = cantPasajeros;
            _tipo = tipo;
            _precioCompra = _precioCompra;
            _precioAlquiler = precioAlquiler;
            _color = color;
            _disponibilidad = disponibilidad;
            _transmision = transmision;
            _idCiudad = idCiudad;
            _listaAutomoviles = new List<CAutomovil>();

        }

        public CAutomovil(string matricula, string modelo, string fabricante)
        {

            _matricula = matricula;
            _modelo = modelo;
            _fabricante = fabricante;
        }
        public CAutomovil(string matricula)
        {
            _matricula = matricula;
        }



        #endregion

    }
}