using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.DataAccess.Domain
{
    public class Oferta : Entidad
    {
        public int _idOferta { get; set; }
        public String _idOfertaa { get; set; }
        public String _nombreOferta { get; set; }
        public float _porcentajeOferta { get; set; }
        public DateTime _fechaIniOferta { get; set; }
        public DateTime _fechaFinOferta { get; set; }
        public bool _estadoOferta { get; set; }
        public String _nombrePaquete { get; set; }
        public Oferta()
        {
        }

        public Oferta(String idOferta, String nombreOferta, float porcentajeOferta, DateTime fechaIniOferta, 
                      DateTime fechaFinOferta, Boolean estadoOferta)
        {
            _idOfertaa = idOferta;
            _nombreOferta = nombreOferta;
            _nombrePaquete = "";
            _porcentajeOferta = porcentajeOferta;
            _fechaIniOferta = fechaIniOferta;
            _fechaFinOferta = fechaFinOferta;
            _estadoOferta = estadoOferta;
        }

        public Oferta(int idOferta, String nombreOferta, float porcentajeOferta, DateTime fechaIniOferta,
                     DateTime fechaFinOferta, Boolean estadoOferta)
        {
            _idOferta = idOferta;
            _nombreOferta = nombreOferta;
            _nombrePaquete = "";
            _porcentajeOferta = porcentajeOferta;
            _fechaIniOferta = fechaIniOferta;
            _fechaFinOferta = fechaFinOferta;
            _estadoOferta = estadoOferta;
        }

        public Oferta(String nombre, float porcentaje, DateTime fInicio, DateTime fFin, bool estado)
        {
            _nombreOferta = nombre;
            _porcentajeOferta = porcentaje;
            _fechaIniOferta = fInicio;
            _fechaFinOferta = fFin;
            _estadoOferta = estado;
        }

        public Oferta(String idOferta, String nombreOferta, List<String> listaPaquetes, float porcentajeOferta, 
            DateTime fechaIniOferta, DateTime fechaFinOferta, Boolean estadoOferta)
        {
            _idOfertaa = idOferta;
            _nombreOferta = nombreOferta;
            _porcentajeOferta = porcentajeOferta;
            _fechaIniOferta = fechaIniOferta;
            _fechaFinOferta = fechaFinOferta;
            _estadoOferta = estadoOferta;

            try
            {
                foreach (string item in listaPaquetes)  //por cada item en listapaquetes asiganar el 
                {                                       //contenido a _nombrePaquete
                   _nombrePaquete = _nombrePaquete + item;
                }
            }
            catch (NullReferenceException e)
            {
                _nombrePaquete = "No tiene paquetes asociados";
            }

        }
/*
        public Oferta MConsultarOferta(int id)
        {
            manejadorSQL consultar = new manejadorSQL();
            return consultar.MMostrarOfertaBD(id);
        }

        public int MModificarOfertaBD(Oferta oferta, String id)
        {
            manejadorSQL modificar = new manejadorSQL();
            return modificar.MModificarOfertaBD(oferta, id);
        }

        public List<CPaquete> MBuscarPaquetesAsociadosBD(String id)
        {
            manejadorSQL buscar = new manejadorSQL();
            int idOferta = Int32.Parse(id);
            return buscar.MBuscarPaquetesDeOferta(idOferta);
        }

        public int MDesvincularPaqueteDeOfertaBD(int idPaquete) //METODO PARA MODIFICAR UN VEHICULO
        {
            manejadorSQL modificar = new manejadorSQL();
            return modificar.MDesvincularPaqueteDeOfertaBD(idPaquete);
        }*/
    }
}