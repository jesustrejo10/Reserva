using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Models.gestion_roles
{
    public class CModulo_general
    {

        private string _nombre;

        private CListaGenerica<CModulo_detallado> _modulo_detallado;


        public CModulo_general()
        {
            
        }
       

        // Contructor que recibe el nombre del modulo general 
        public CModulo_general(string nombre)
        {
            this._nombre = nombre;
            this._modulo_detallado = new CListaGenerica<CModulo_detallado>();
        }

        // Constructor que recibe el nombre dle modulo y la lista de sus 
        // modulos especificos (Cada una de sus opciones
        public CModulo_general(string nombre, CListaGenerica<CModulo_detallado> lista_modulo_detallado)
			   :this ( nombre ) 
		{
            this._modulo_detallado = lista_modulo_detallado;
		}

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        
        public CListaGenerica<CModulo_detallado> Modulo_detallado
        {
            get { return _modulo_detallado; }
            set { _modulo_detallado = value; }
        }

    }
}