using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Models.gestion_roles
{
    //Clase para guardar metodos de las listas que usaremos
    //para el manejo de roles ( Lista de los modulos generales
    // lista de modulos y sus detalles 
    public class CListaGenerica<T>
    {
        //Instancio 
        private List<T> _listaGenerica;


        public CListaGenerica() 
        {
            _listaGenerica = new List<T>();
        }

        //Método para agregar un elemento a la lista
        public void agregarElemento(T elemento)
        {
            _listaGenerica.Add(elemento);
        }
        //Método para eliminar un elemento de la lista
        public bool eliminarElemento(T elemento)
        {
            return _listaGenerica.Remove(elemento);
        }

        /// Método para obtener el enumerador de la lista
        public IEnumerator<T> GetEnumerator()
        {
            return _listaGenerica.GetEnumerator();
        }

        /// <summary>
        /// Método para obtener el enumerador de la lista
        /// </summary>
        /// <returns>Retorna el enumerador de la lista</returns>
        //IEnumerator IEnumerable.GetEnumerator()
        //{
        //    return GetEnumerator();
        //}

    }
}