using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.DataAccess.Domain
{
    /// <summary>
    /// Clase base de los reclamos
    /// </summary>
    public class Reclamo: Entidad
    {
        /// <summary>
        /// Atributo id Reclamo
        /// </summary>
        public int _idReclamo { get; set; }
        /// <summary>
        /// Atributo titulo Reclamo
        /// </summary>
        public String _tituloReclamo { get; set; }
        /// <summary>
        /// Atributo  detalle Reclamo
        /// </summary>
        public String _detalleReclamo { get; set; }
        /// <summary>
        /// Atributo fecha Reclamo 
        /// </summary>
        public String _fechaReclamo { get; set; }
        /// <summary>
        /// Atributo  estado Reclamo
        /// </summary>
        public int _estadoReclamo { get; set; }
        /// <summary>
        /// Atributo  usuario Reclamo
        /// </summary>
        public int _usuarioReclamo{get; set;}
        /// <summary>
        /// Atributo  Lista de Reclamos
        /// </summary>
        public List<Reclamo> _listaDeReclamos { get; set; }
        /// <summary>
        /// Constructor del reclamo
        /// </summary>
        /// <param name="id"> id del reclamo</param>
        /// <param name="tituloReclamo"> titulo del reclamo</param>
        /// <param name="detalleReclamo">detalle del reclamo</param>
        /// <param name="fechaReclamo">fecha del reclamo</param>
        /// <param name="estadoReclamo">estado del reclamo</param>
        /// <param name="_usuarioReclamo">usuario del reclamo</param>
        public Reclamo(int id, String tituloReclamo, String detalleReclamo, String fechaReclamo, int estadoReclamo, int _usuarioReclamo)
        {
            this._idReclamo = id;
            this._tituloReclamo = tituloReclamo;
            this._detalleReclamo = detalleReclamo;
            this._fechaReclamo = fechaReclamo;
            this._estadoReclamo = estadoReclamo;
        }

        /// <summary>
        /// Constructor para cuando no se requiere utilizar la id del reclamo
        /// </summary>
        /// <param name="tituloReclamo"> titulo del reclamo</param>
        /// <param name="detalleReclamo">detalle del reclamo</param>
        /// <param name="fechaReclamo">fecha del reclamo</param>
        /// <param name="estadoReclamo">estado del reclamo</param>
        /// <param name="_usuarioReclamo">usuario del reclamo</param>
        public Reclamo(String tituloReclamo, String detalleReclamo, String fechaReclamo, int estadoReclamo, int _usuarioReclamo)
        {
            this._tituloReclamo = tituloReclamo;
            this._detalleReclamo = detalleReclamo;
            this._fechaReclamo = fechaReclamo;
            this._estadoReclamo = estadoReclamo;
            this._usuarioReclamo = _usuarioReclamo;
        }

        /// <summary>
        /// Constructor por defecto de un reclamo vacio
        /// </summary>
        public Reclamo() { }
    }
}