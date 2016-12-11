using BOReserva.Servicio.Servicio_Hoteles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Models.gestion_hoteles
{
    public class CHotel
    {
        public int _id {get; set; }
        public String _nombre { get; set; }
        public String _paginaweb { get; set; }
        public string _email { get; set; }
        public int _canthabitaciones { get; set; }
        public String _pais { get; set; }
        public String _ciudad { get; set; }
        public String _direccion { get; set; }
        public int _estrellas { get; set; }
        public float _puntuacion { get; set; }

        public CHotel(int id, String nombre, String paginaweb, string email, int canthabitaciones, String pais, String ciudad, String direccion, int estrellas,
             float puntuacion)
        {
            _id = id;
            _nombre = nombre;
            _paginaweb = paginaweb;
            _email = email;
            _canthabitaciones = canthabitaciones;
            _pais = pais;
            _ciudad = ciudad;
            _direccion = direccion;
            _estrellas = estrellas;
            _puntuacion = puntuacion;    
        }

        public List<CHotel> MListarHoteles() //METODO PARA OBTENER LA LISTA DE HOTELES DE LA BASE DE DATOS
        {
            CManejadorSQL_Hoteles listar = new CManejadorSQL_Hoteles();
            return listar.MListarHotelesBD();
        }

    }
}