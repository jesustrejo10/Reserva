using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.DataAccess.Domain
{
    public class Avion : Entidad
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

        public Avion()
        {
        }
        public Avion(int id, String matricula, String modelo, int capacidadturistica, int capacidadEjecutiva, int capacidadVIP, float capacidadEquipaje, float distanciaMaximaVuelo, float velocidadMaxima, float capacidadCombustible, int disponibilidad)
        {
            this._id = id;
            this._matricula = matricula;
            this._modelo = modelo;
            this._capacidadTurista = capacidadturistica;
            this._capacidadEjecutiva = capacidadEjecutiva;
            this._capacidadVIP = capacidadVIP;
            this._capacidadEquipaje = capacidadEquipaje;
            this._distanciaMaximaVuelo = distanciaMaximaVuelo;
            this._velocidadMaxima = velocidadMaxima;
            this._capacidadCombustible = capacidadCombustible;
            this._disponibilidad = disponibilidad;


        }
        public Avion(String matricula, String modelo, int capacidadturistica, int capacidadEjecutiva, int capacidadVIP, float capacidadEquipaje, float distanciaMaximaVuelo, float velocidadMaxima, float capacidadCombustible, int disponibilidad)
        {

            this._matricula = matricula;
            this._modelo = modelo;
            this._capacidadTurista = capacidadturistica;
            this._capacidadEjecutiva = capacidadEjecutiva;
            this._capacidadVIP = capacidadVIP;
            this._capacidadEquipaje = capacidadEquipaje;
            this._distanciaMaximaVuelo = distanciaMaximaVuelo;
            this._velocidadMaxima = velocidadMaxima;
            this._capacidadCombustible = capacidadCombustible;
            this._disponibilidad = disponibilidad;


        }
    }
}