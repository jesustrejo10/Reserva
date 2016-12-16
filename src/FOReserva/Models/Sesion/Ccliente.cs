using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.Models.Sesion
{
    public class Ccliente
    {
        private int _id;
        private string _nombre;
        private string _apellido;
        private string _usuario;
        private string _clave0;
        private string _clave1;
        private string _correo;
        private string _genero;
        private string _estado;
        private string _telefono;
        private string _codigo_area; 

        private DateTime _fechaNacimiento;
        private Cpregunta_Respuesta _preguntaRespuesta0;
        private Cpregunta_Respuesta _preguntaRespuesta1;
        private Cpregunta_Respuesta _preguntaRespuesta2;
        

        public int Id {
            get { return _id; }
            set { _id = value; }
        }

        public String Codigo_Area
        {
            get { return _codigo_area; }
            set { _codigo_area = value; }
        }

        public string Genero {
            get { return this._genero; }
            set { _genero = value; }
        }

        public string Estado
        {
            get { return this._estado; }
            set { _estado = value; }
        }

        public DateTime FechaNacimiento
        {
            get { return this._fechaNacimiento; }
            set { _fechaNacimiento = value; }
        }

        public string Telefono
        {
            get { return this._telefono; }
            set { _telefono = value; }
        }

        public string Nombre {
            get { return this._nombre; }
            set { _nombre = value; }    
        } 

        public string Apellido {
            get { return this._apellido; }
            set { _apellido = value; }
        }

        public string Usuario {
            get { return this._usuario; }
            set { _usuario = value; }
        }

        public string Clave0 {
            get { return this._clave0; }
            set { _clave0 = value; }
        }

        public string Clave1 {
            get { return this._clave1; }
            set { _clave1 = value; }
        }

        public string Correo {
            get { return this._correo; }
            set { _correo = value; }
        }

        public Cpregunta_Respuesta PreguntaRespuesta0 {
            get { return this._preguntaRespuesta0; }
            set { _preguntaRespuesta0 = value; }
        }

        public Cpregunta_Respuesta PreguntaRespuesta1 {
            get { return this._preguntaRespuesta1; }
            set { _preguntaRespuesta1 = value; }
        }

        public Cpregunta_Respuesta PreguntaRespuesta2 {
            get { return this._preguntaRespuesta2; }
            set { _preguntaRespuesta2 = value; }
        }
    }
}