using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.Models.Sesion
{
    public class Cpregunta_Respuesta
    {
        private string _pregunta;
        private string _respuesta;

        public Cpregunta_Respuesta() {
            _pregunta = "";
            _respuesta = "";
        }

        public Cpregunta_Respuesta(string _pregunta, string _respuesta) {
            this._pregunta = _pregunta;
            this._respuesta = _respuesta;
        }

        public string Pregunta {
            get { return this._pregunta; }
            set { this._pregunta = value; }
        }

        public string Respuesta {
            get { return this._respuesta; }
            set { this._respuesta = value; }
        }

    }
}