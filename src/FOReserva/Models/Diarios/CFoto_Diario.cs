using FOReserva.Servicio;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FOReserva.Models.Diarios
{
    public class CFoto_Diario : BaseEntity
    {
        private string _nombre;
        private byte[] _datos;
        private int _fk_diario;


        //Constructors

        public CFoto_Diario
           (int id,
            string name,
            string nombre,
            byte[]  datos,
            int fk_diario)
            : base(id, name)
        {

            this._nombre = nombre;
            this._datos = datos;
            this._fk_diario = fk_diario;


        }


        public CFoto_Diario() : base() { }

        //Metodos Get y Set

        //Titulo o nombre de la foto
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        //Obtener datos de la imagen
        public byte[] Datos
        {
            get { return _datos; }
            set { _datos = value; }
        }

        public int Fk_Diario
        {
            get { return _fk_diario; }
            set { _fk_diario = value; }
        }


        /*

        public List<CFoto_Diario> diariosFotos()
        {
            ManejadorSQLDiarios manejador = new ManejadorSQLDiarios();
            List<CFoto_Diario> fotos = manejador.obtenerFotos();
            return fotos;
        }*/

    }
}
