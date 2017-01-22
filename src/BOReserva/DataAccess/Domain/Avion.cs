using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.DataAccess.Domain
{
    /// <summary>
    /// Clase de tipo Avion
    /// </summary>
    public class Avion : Entidad
    {
        /// <summary>
        /// Atributos propios del Avion
        /// </summary>
        private string matricula;
        private string modelo;
        private int capacidadturistica;
        private int capacidadEjecutiva;
        private int capacidadVIP;
        private float capacidadEquipaje;
        private float distanciaMaximaVuelo;
        private float velocidadMaxima;
        private float capacidadCombustible;
        private int disponibilidad;
        public String _matricula { get; set; }
        public String _modelo { get; set; }
        public int _capacidadTurista { get; set; }
        public int _capacidadEjecutiva { get; set; }
        public int _capacidadVIP { get; set; }
        public float _capacidadEquipaje { get; set; }
        public float _distanciaMaximaVuelo { get; set; }
        public float _velocidadMaxima { get; set; }
        public float _capacidadCombustible { get; set; }
        public int _disponibilidad { get; set; }

        /// <summary>
        /// Constructor del Avion
        /// </summary>
        public Avion() {
        }
        
        /// <summary>
        /// Constructor usado en la Entidad
        /// </summary>
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

        /// <summary>
        /// Constructor usado en la Entidad, no DISPONIBILIDAD
        /// </summary>
        public Avion(int id, String matricula, String modelo, int capacidadturistica, int capacidadEjecutiva, int capacidadVIP, float capacidadEquipaje, float distanciaMaximaVuelo, float velocidadMaxima, float capacidadCombustible)
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
        }


        /// <summary>
        /// Constructor usado en la Entidad, no ID
        /// </summary>
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

        /// <summary>
        /// Constructor usado en la Entidad, no ID no DiSPONIBILIDAD
        /// </summary>
        public Avion(String matricula, String modelo, int capacidadturistica, int capacidadEjecutiva, int capacidadVIP, float capacidadEquipaje, float distanciaMaximaVuelo, float velocidadMaxima, float capacidadCombustible)
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
        }
      
    }
}