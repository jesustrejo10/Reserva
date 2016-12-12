using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Models.gestion_aviones
{
    public class CModificarAvion
    {
        public int _id { get; set; }
        public String _matriculaAvion { get; set; }
        public String _modeloAvion { get; set; }
        public int _capacidadPasajerosTurista { get; set; }
        public int _capacidadPasajerosEjecutiva { get; set; }
        public int _capacidadPasajerosVIP { get; set; }
        public float _capacidadMaximaCombustible { get; set; }
        public float _capacidadEquipaje { get; set; }
        public float _distanciaMaximaVuelo { get; set; }
        public float _velocidadMaximaDeVuelo { get; set; }
        public int _disponibilidad { get; set; }


        //Constructor por default por si acaso
        public CModificarAvion() { }

        //Constructor para pasarle los valores a la vista
        public CModificarAvion(CAvion avion)
        {
            _id = avion._id;
            _matriculaAvion = avion._matricula;
            _modeloAvion = avion._modelo;
            _capacidadPasajerosTurista = avion._capacidadTurista;
            _capacidadPasajerosEjecutiva = avion._capacidadEjecutiva;
            _capacidadPasajerosVIP = avion._capacidadVIP;
            _capacidadMaximaCombustible = avion._capacidadCombustible;
            _capacidadEquipaje = avion._capacidadEquipaje;
            _distanciaMaximaVuelo = avion._distanciaMaximaVuelo;
            _velocidadMaximaDeVuelo = avion._velocidadMaxima;
            _disponibilidad = avion._disponibilidad;
        }
    }
}