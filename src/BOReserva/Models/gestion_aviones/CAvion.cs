using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Models.gestion_aviones
{
    public class CAvion
    {
        public int _id { get; set; }
        public string _matricula { get; set; }
        public string _modelo { get; set; }
        public int _capacidadTurista { get; set; }
        public int _capacidadEjecutiva { get; set; }
        public int _capacidadVIP { get; set; }
        public float _capacidadEquipaje { get; set; }
        public float _distanciaMaximaVuelo { get; set; }
        public float _velocidadMaxima { get; set; }
        public float _capacidadCombustible { get; set; }
        public int _disponibilidad { get; set; }


        public CAvion() { }
        public CAvion (int id, string matricula, string modelo, int capacidadTurista, int capacidadEjecutiva, int capacidadVIP, float capacidadEquipaje, float distanciaMaximaVuelo, float velocidadMaxima, float capacidadCombustible, int disponibilidad)
        {
            _id = id;
            _matricula = matricula;
            _modelo = modelo;
            _capacidadTurista = capacidadTurista;
            _capacidadEjecutiva = capacidadEjecutiva;
            _capacidadVIP = capacidadVIP;
            _capacidadEquipaje = capacidadEquipaje;
            _distanciaMaximaVuelo = distanciaMaximaVuelo;
            _velocidadMaxima = velocidadMaxima;
            _capacidadCombustible = capacidadCombustible;
            _disponibilidad = disponibilidad;
        }

    }
}