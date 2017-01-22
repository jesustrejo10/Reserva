using BOReserva.Controllers.PatronComando;
using BOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Controllers.PatronComando

{
    /// <summary>
    /// Clase abstracta Commando, todos los comandos deben heredar de ella
    /// </summary>
    /// <typeparam name="T">
    /// Su parametro de entrada es un Generico, es decir puede recibir cualquier objeto
    /// </typeparam>
    abstract public class Command<T>
    {

        /// <summary>
        /// Metodo que se encarga de ejecutar una accion.
        /// </summary>
        /// <returns>
        /// Retorna cualquier tipo de objeto dependiendo de como sea implementado
        /// </returns>
        abstract public T ejecutar();
    }
}