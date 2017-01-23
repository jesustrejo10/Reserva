using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.Models.Autos
{
    /*Clase del modelo Automovil
      Atributos: 
       _modelo: Modelo del carro
       _fabricante: Fabricante - Marca del carro
       _tipo: Tipo del carro - Camioneta, Sedan...
       _color: Color del carro
       _transmision: Automatica - Secuencial
       _ciudad: Ciudad de origen del carro
       _precio: Precio de alquiler
       _anio: Anio del carro
       _pasajeros: Cantidad de pasajeros que admite el carro
       _uso: Disponibilidad para el uso - Se maneja con 0 y 1    
     */

    public class CBusquedaModel : BaseEntity
    {
        private string _matricula;
        private string _modelo;
        private string _fabricante;
        private string _tipo;
        private string _color;
        private string _transmision;
        private int _ciudad;
        private decimal _precio;
        private int _anio;
        private int _pasajeros;
        private int _disponibilidad;

        /* Constructor Completo */
        public CBusquedaModel(string matricula, string modelo, string fabricante, string tipo, string color, string transmision, int ciudad, decimal precio, int anio, int pasajero, int disponibilidad)
        {
            this._matricula = matricula;
            this._modelo = modelo;
            this._fabricante = fabricante;
            this._tipo = tipo;
            this._color = color;
            this._transmision = transmision;
            this._ciudad = ciudad;
            this._precio = precio;
            this._anio = anio;
            this._pasajeros = pasajero;
            this._disponibilidad = disponibilidad;
        }

        public CBusquedaModel() : base() { }

        /* Metodos Get y Set para la matricula del carro */
        public string Matricula
        {
            get { return _matricula; }
            set { _matricula = value; }
        }

        /* Metodos Get y Set para el modelo del carro */
        public string Modelo
        {
            get { return _modelo; }
            set { _modelo = value; }
        }

        /* Metodos Get y Set para el fabricante del carro */
        public string Fabricante
        {
            get { return _fabricante; }
            set { _fabricante = value; }
        }

        /* Metodos Get y Set para el tipo del carro */
        public string Tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }

        /* Metodos Get y Set para el color del carro */
        public string Color
        {
            get { return _color; }
            set { _color = value; }
        }

        /* Metodos Get y Set para el modelo del carro */
        public string Transmision
        {
            get { return _transmision; }
            set { _transmision = value; }
        }

        /* Metodos Get y Set para la ciudad del carro */
        public int Ciudad
        {
            get { return _ciudad; }
            set { _ciudad = value; }
        }

        /* Metodos Get y Set para el precio del carro */
        public decimal Precio
        {
            get { return _precio; }
            set { _precio = value; }
        }

        /* Metodos Get y Set para el anio del carro */
        public int Anio
        {
            get { return _anio; }
            set { _anio = value; }
        }

        /* Metodos Get y Set para el pasajeros del carro */
        public int Pasajeros
        {
            get { return _pasajeros; }
            set { _pasajeros = value; }
        }

        /* Metodos Get y Set para el disponibilidad de uso del carro */
        public int Disponibilidad
        {
            get { return _disponibilidad; }
            set { _disponibilidad = value; }
        }
    }
}