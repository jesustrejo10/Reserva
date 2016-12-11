using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.Models.Diarios
{
    using FOReserva.Servicio;
    using System.Web.Mvc;

    public class CDiarioModel : BaseEntity
    {
        private string   _nombre;
        private DateTime _fecha_ini;
        private DateTime _fecha_fin;
        private string   _descripcion;
        private DateTime _fecha_carga;
        private int      _calif_creador;
        private int     _rating;
        private int     _num_visita;
        private int     _fk_lugar;

       
        //Constructors
       
         public CDiarioModel
            (int      id, 
             string   name,
             string   nombre,
             DateTime fecha_ini,
             DateTime fecha_fin,
             string   descripcion,
             DateTime fecha_carga,
             int      calif_creador,
             int      rating,
             int      num_visita,
             int      fk_lugar)
            : base(id, name)
        {

            this._nombre        = nombre;
            this._fecha_ini     = fecha_ini;
            this._fecha_fin     = fecha_fin;
            this._descripcion   = descripcion;
            this._fecha_carga   = fecha_carga;
            this._calif_creador = calif_creador;
            this._rating        = rating;
            this._num_visita    = num_visita;

        }


        public CDiarioModel() :base (){ }
        
        //Metodos Get y Set
        
        //Nombre del Diario
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        
        //Fecha inicio del viaje
        public DateTime Fecha_ini
        {
            get { return _fecha_ini; }
            set { _fecha_ini = value; }
        }

        //Fecha del final del viaje
        public DateTime Fecha_fin
        {
            get { return _fecha_fin; }
            set { _fecha_fin = value; }
        }
        
        //Descripcion o cuerpo del diario
        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }

        //Fecha del final del viaje
        public DateTime Fecha_carga
        {
            get { return _fecha_carga; }
            set { _fecha_carga = value; }
        }

        //Calificacion dada por el creador del diario a la experiencia
        public int  Calif_creador
        {
            get { return _calif_creador; }
            set { _calif_creador = value; }
        }
        
        //Rating
        public int Rating
        {
            get { return _rating; }
            set { _rating = value; }
        }

        //Numero de visitas del diario
        public int Num_visita
        {
            get { return _num_visita; }
            set { _num_visita = value; }
        }

        //ID de lugar de viaje
        public int Lugar
        {
            get { return _fk_lugar; }
            set { _fk_lugar = value; }
        }

        public List<SelectListItem> diariosLugares()
        {
            ManejadorSQLDiarios manejador = new ManejadorSQLDiarios();
            List<CLugar> lugaresCLugar = manejador.obtenerLugares();
            List<SelectListItem> lugares = new List<SelectListItem>();
            lugares.Add(new SelectListItem { Value = "0", Text = "------ Buscar por destino de viaje ------", Selected=true});
            foreach (CLugar lug in lugaresCLugar)
            {
                SelectListItem l = new SelectListItem { Value = lug.ID.ToString(), Text = (lug.Tipo.Equals("pais") ? "" : "  --- ") + lug.Nombre };
                lugares.Add(l);
            }
            return lugares;
        }

    }
}
