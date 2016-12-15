using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Models.gestion_comida_vuelo
{
    public class CVuelo
    {
        public int _id { get; set; }
        public string _codigoVuelo { get; set; }
        public string _ciudadOrigen { get; set; }
        public string _ciudadDestino { get; set; }
        public int _capacidadTurista { get; set; }
        public int _capacidadEjecutiva { get; set; }
        public int _capacidadVip { get; set; }

        public CVuelo() { }
            public CVuelo(int id,string cvuelo, string corigen,string cdestino,int cturista,int cejecutiva, int cvip)
                {
                        _id = id;
                        _codigoVuelo = cvuelo;
                        _ciudadOrigen = corigen;
                        _ciudadDestino = cdestino;
                        _capacidadTurista = cturista;
                        _capacidadEjecutiva = cejecutiva;
                        _capacidadVip = cvip;
                }
    }
}