using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace FOReserva.Datos
{
    public class Parametro
    {
        #region Atributos 
        private string _nombreAtributo;
        private SqlDbType _tipoDeDato;
        private string _valorAtributo;
        private bool _output;
        private bool _input;
        #endregion

        #region Constructores
        /// <summary>
        /// Metodo constructor con campos vacios
        /// </summary>
        public Parametro() { }

        /// <summary>
        /// Metodo constructor de parametros de la base de datos 
        /// </summary>
        /// <param name="nombreAtributo">etiqueta del parametro ejemplo: @nombre</param>
        /// <param name="tipoDeDato">SqlDbType con el tipo de dato del parametro 
        /// ejemplo: SqlDbType.VarChar</param>
        /// <param name="valorAtributo">valor: string con el valor que se le asigno al 
        /// parametro ejemplo: Pepe</param>
        /// <param name="input">intput: en caso de que se envien parametros al procedimiento: true, si no: false</param>
        /// <param name="output">output: en caso de que las variables del procedimiento retornan valor: true, si no: false</param>
        public Parametro(string nombreAtributo, SqlDbType tipoDeDato, string valorAtributo, bool input, bool output)
        {
            this._nombreAtributo = nombreAtributo;
            this._tipoDeDato = tipoDeDato;
            this._valorAtributo = valorAtributo;
            this.Input = input;
            this._output = output;
        }

        /// <summary>
        /// Metodo constructor sin el valor asignado, constructor preferible para consultas
        /// </summary>
        /// <param name="nombreAtributo">etiqueta del parametro ejemplo: @nombre</param>
        /// <param name="tipoDeDato">SqlDbType con el tipo de dato del parametro 
        /// ejemplo: SqlDbType.VarChar</param>  
        /// <param name="input">intput: en caso de que se envien parametros al procedimiento: true, si no: false</param>
        /// <param name="output"> si es un parametro en el store procedure devuelve resultado: true, si no: false</param>
        public Parametro(string nombreAtributo, SqlDbType tipoDeDato, bool input, bool output)
        {
            this._nombreAtributo = nombreAtributo;
            this._tipoDeDato = tipoDeDato;
            this.Input = input;
            this._output = output;
        }

        #endregion

        #region Get y Set

        public string nombreAtributo
        {
            get { return this._nombreAtributo; }
            set { this._nombreAtributo = value; }
        }

        public SqlDbType tipoDeDato
        {
            get { return this._tipoDeDato; }
            set { this._tipoDeDato = value; }
        }

        public string valorAtributo
        {
            get { return this._valorAtributo; }
            set { this._valorAtributo = value; }
        }

        public bool output
        {
            get { return this._output; }
            set { this._output = value; }
        }

        public bool Input
        {
            get
            {
                return _input;
            }

            set
            {
                _input = value;
            }
        }

        #endregion
    }
}