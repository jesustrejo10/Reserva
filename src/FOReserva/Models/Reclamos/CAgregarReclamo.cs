using FOReserva.DataAccess.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.Models.Reclamos
{
    /// <summary>
    /// Clase base de agregar un reclamo a la vista
    /// </summary>
    public class CAgregarReclamo
    {
        /// <summary>
        /// Atributo titulo reclamo
        /// </summary>
        public String _tituloReclamo { get; set; }
        /// <summary>
        /// Atributo detalle reclamo
        /// </summary>
        public String _detalleReclamo { get; set; }
        /// <summary>
        /// Atributo Fecha reclamo
        /// </summary>
        public String _fechaReclamo { get; set; }
        /// <summary>
        /// Atributo Usuario reclamo
        /// </summary>
        public int _usuarioReclamo { get; set; }
        /// <summary>
        /// Atributo Lista de reclamos
        /// </summary>
        public List<Reclamo> _listaDeReclamos {get; set;}
    }
}