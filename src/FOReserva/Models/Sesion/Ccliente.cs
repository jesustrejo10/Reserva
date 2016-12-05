using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.Models.registro_autenticacion
{
    public class Ccliente
    {
        public Ccliente(String usuario, String correo, Ccontrasena contrasena, Ccodigo_Temporal codigo, Cpregunta_Respuesta preguntaRespuesta, DateTime fechaRegistro, DateTime fechaActividad, Boolean sesionActiva, Boolean estado, DateTime fechaNac)
        {
            //Constructor
            _usuario = usuario;
            _correo = correo;
            _contrasena = contrasena;
            _codigo = codigo;
            _preguntaRespuesta = preguntaRespuesta;
            _fechaRegistro = fechaRegistro;
            _fechaActiva = fechaActividad;
            _sesionActiva = sesionActiva;
            _estado = estado;
            _fechaNac = fechaNac;

        }

        public Boolean Meditar_Cliente(String usuario, String correo, String contrasena)
        {
            return false;
        }

        public Boolean Meditar_Username(String usuario)
        {
            return false;
        }

        public Boolean Meditar_Correo(String correo)
        {
            return false;
        }

        public int Mcalcular_Edad(DateTime fechaNac)
        {
            return 0;
        }

        public String _usuario { get; set; }
        public String _correo { get; set; }
        public Ccontrasena _contrasena { get; set; }
        public Ccodigo_Temporal _codigo { get; set; }
        public Cpregunta_Respuesta _preguntaRespuesta { get; set; }
        public DateTime _fechaRegistro { get; set; }
        public DateTime _fechaActiva { get; set; }
        public Boolean _sesionActiva { get; set; }
        public Boolean _estado { get; set; }
        public DateTime _fechaNac { get; set; }
    }
}