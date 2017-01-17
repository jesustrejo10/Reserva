using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.LogicaReserva
{
    /// <summary>
    /// Clase Abstracta para el patron comando
    /// Comando<T> es una lista generica de c#
    /// permite crear una lista segun la clase que se requiera 
    /// sea tipo de dato primitivo o tipo de dato abstracto
    /// </summary>
    /// <typeparam name="T">T es Generico, el nombre puede ser cambiado</typeparam>
    public abstract class Comando<T>
    {
        public abstract T Ejecutar();
    }
}