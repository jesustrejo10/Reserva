using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Models.gestion_ruta_comercial
{
    public class CRuta
    {
        private int _id;
        private String _origen;
        private String _destino;
        private String _estado;
        private String _tipo;
        private int _distancia;

        public CRuta(int id,String origen, String destino, String estado, String tipo, int distancia)
        {
            _id = id;
            _origen = origen;
            _destino = destino;
            _estado = estado;
            _tipo = tipo;
            _distancia = distancia;
        }

        public int idRuta
        {
            get { return _id; }
            set { _id = value; }
        }

        public String origenRuta
        {
            get { return _origen; }
            set { _origen = value; }
        }

        public String destinoRuta
        {
            get { return _destino; }
            set { _destino = value; }
        }
        public String tipoRuta
        {
            get { return _tipo; }
            set { _tipo = value; }
        }
        public String estadoRuta
        {
            get { return _estado; }
            set { _estado = value; }
        }
        public int distanciaRuta
        {
            get { return _distancia; }
            set { _distancia = value; }
        }



    }
}