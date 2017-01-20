using FOReserva.Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FOReserva.DataAccess.Domain;
namespace FOReserva.Models.Diarios
{
    public class CDiarioModel : Entidad
    {
        private string   _nombre;
        private DateTime _fecha_ini;
        private DateTime _fecha_fin;
        private string   _descripcion;
        private DateTime _fecha_carga;
        private int      _calif_creador;
        private int      _rating;
        private int      _num_visita;
        private int      _fk_lugar;
        private int      _fk_usuario;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        //Para el formulario
        private int     _filtro;
       
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
             int      fk_lugar,
             int      fk_usuario)

            
        {

            this._nombre        = nombre;
            this._fecha_ini     = fecha_ini;
            this._fecha_fin     = fecha_fin;
            this._descripcion   = descripcion;
            this._fecha_carga   = fecha_carga;
            this._calif_creador = calif_creador;
            this._rating       = rating;
            this._num_visita    = num_visita;
            this._fk_lugar      = fk_lugar;
            this._fk_usuario = fk_usuario;
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

        //Fecha de carga de la publicacion
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
        public int Destino
        {
            get { return _fk_lugar; }
            set { _fk_lugar = value; }
        }
        //ID de usuario que crea el Diario
        public int Usuario
        {
            get { return _fk_usuario; }
            set { _fk_usuario = value; }
        }

        public List<SelectListItem> Lugares()
        {
            CLugar cl= new CLugar();
            return cl.diariosLugares();
        }

        public String Nombre_usuario(int id_DV)
        {
            ManejadorSQLDiarios manejador = new ManejadorSQLDiarios();
            string usr = manejador.obtenerUsuario(id_DV);
            return usr;
        }

        public String Nombre_lugar(int id_lug)
        {
            ManejadorSQLDiarios manejador = new ManejadorSQLDiarios();
            string lug = manejador.obtenerNombreLugar(id_lug);
            return lug;
        }

        public int Filtro
        {
            get { return _filtro; }
            set { _filtro = value; }
        }
    }
}