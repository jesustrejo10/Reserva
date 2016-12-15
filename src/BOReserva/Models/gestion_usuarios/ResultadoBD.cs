using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Models.gestion_usuarios
{
    public class ResultadoBD
    {
        public string etiqueta { get; set; }
        public string valor { get; set; }

        /// <summary>
        /// Constructor de Resultado, no deberia existir resultado sin estos parametros
        /// </summary>
        /// <param name="etiqueta">Etiqueta del resultado ejemplo: @Nombre</param>
        /// <param name="valor">Valor del resultado, ejemplo: Pepe</param>
        public ResultadoBD(string etiqueta, string valor)
        {
            this.etiqueta = etiqueta;
            this.valor = valor;
        }
    }
}