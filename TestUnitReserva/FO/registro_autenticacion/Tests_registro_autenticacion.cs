using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FOReserva.Models.Sesion.Ccliente;
using FOReserva.Servicio;
using System.Threading.Tasks;

namespace TestUnitReserva.FO.registro_autenticacion
{
    //Creamos una clase Cliente Test con INT correo para probar las SQL Exception
    class CclienteTest
    {
        private int _id;
        private string _nombre;
        private string _apellido;
        private string _clave0;
        private string _clave1;
        private int _correo;

        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Nombre
        {
            get { return this._nombre; }
            set { _nombre = value; }
        }

        public string Apellido
        {
            get { return this._apellido; }
            set { _apellido = value; }
        }

        public string Clave0
        {
            get { return this._clave0; }
            set { _clave0 = value; }
        }

        public string Clave1
        {
            get { return this._clave1; }
            set { _clave1 = value; }
        }

        public int Correo
        {
            get { return this._correo; }
            set { _correo = value; }
        }
    }



    //****************************AQUI COMIENZAN LAS PRUEBAS UNITARIAS************************
    [TestFixture]
    class Tests_registro_autenticacion
    {
        manejadorSQLSesion prueba = new manejadorSQLSesion();

        Ccliente cliente = new Ccliente();
        CclienteTest clienteTest = new CclienteTest();
        CPregunta_Respuesta pregunta_respuesta = new CPregunta_Respuesta();





        [ExpectedException(typeof(ExisteUsuarioCorreoException))]
        public void ValidacionUsuarioCorreo()
        {
            cliente.Correo = "noExistoEnLaBD@hotmail.com";
            ReturnVal = prueba.ValidarUsuarioCorreo(cliente.Correo);
            //Valida que arroje la exception de Existencia de Usuario al no existir un Usuario
            Assert.IsTrue(ReturnVal is ExisteUsuarioCorreoException);
        }

        [ExpectedException(typeof(SqlException))]
        public void ValidacionUsuarioCorreo2()
        {
            clienteTest.Correo = 2;
            ReturnVal = prueba.ValidarUsuarioCorreo(clienteTest.Correo);
            //Valida que arroje la exception de SQL Exception
            Assert.IsTrue(ReturnVal is SqlException);

        }






        [ExpectedException(typeof(ExisteUsuarioCorreoException))]
        public void ValidacionRegistroCliente()
        {
            cliente.Nombre = "Mario";
            cliente.Apellido = "Luque";
            cliente.Clave0 = "mario123";
            cliente.Clave1 = "mario123";
            cliente.Correo = "noExistoEnLaBD@hotmail.com";

            ReturnVal = prueba.ValidacionRegistroCliente(cliente);
            //Valida que arroje la exception de Existencia de Usuario al no existir un Usuario
            Assert.IsTrue(ReturnVal is ExisteUsuarioCorreoException);
        }

        [ExpectedException(typeof(SqlException))]
        public void ValidacionRegistroCliente2()
        {
            clienteTest.Nombre = "Mario";
            clienteTest.Apellido = "Luque";
            clienteTest.Clave0 = "mario123";
            clienteTest.Clave1 = "mario123";
            clienteTest.Correo = 2;

            ReturnVal = prueba.ValidarUsuarioCorreo(clienteTest.Correo);
            //Valida que arroje la exception de SQL Exception
            Assert.IsTrue(ReturnVal is SqlException);
        }







        [ExpectedException(typeof(ClavesDiferentesException))]
        public void ValidacionLogin()
        {
            cliente.Correo = "noExistoEnLaBD@hotmail.com";
            cliente.Clave0 = "";
            ReturnVal = prueba.ValidacionLogin(cliente);
            //Valida que arroje la exception de ClavesDiferentes Exception si las claves no coinciden
            Assert.IsTrue(ReturnVal is ExisteUsuarioCorreoException);
        }

        [ExpectedException(typeof(ExisteUsuarioCorreoException))]
        public void ValidacionLogin2()
        {
            cliente.Correo = "noExistoEnLaBD@hotmail.com";
            ReturnVal = prueba.ValidacionLogin(cliente);
            //Valida que arroje la exception de Existencia de Usuario al no existir un Usuario
            Assert.IsTrue(ReturnVal is ExisteUsuarioCorreoException);
        }

        [ExpectedException(typeof(SqlException))]
        public void ValidacionLogin3()
        {
            clienteTest.Correo = 2;
            ReturnVal = prueba.ValidarUsuarioCorreo(clienteTest.Correo);
            //Valida que arroje la exception de SQL Exception
            Assert.IsTrue(ReturnVal is SqlException);
        }






        [ExpectedException(typeof(ExisteUsuarioCorreoException))]
        public void ValidacionUsuarioCorreoExiste()
        {
            cliente.Correo = "noExistoEnLaBD@hotmail.com";

            ReturnVal = prueba.ValidarUsuarioCorreoExiste(cliente.Correo);
            //Valida que arroje la exception de Existencia de Usuario al no existir un Usuario
            Assert.IsTrue(ReturnVal is ExisteUsuarioCorreoException);
        }

        [ExpectedException(typeof(SqlException))]
        public void ValidacionUsuarioCorreoExiste2()
        {
            clienteTest.Correo = 2;
            ReturnVal = prueba.ValidarUsuarioCorreoExiste(clienteTest.Correo);
            //Valida que arroje la exception de SQL Exception
            Assert.IsTrue(ReturnVal is SqlException);
        }





        [ExpectedException(typeof(SqlException))]
        public void CambiarClave()
        {
            cliente.Id = 2;
            cliente.Clave0 = null;

            ReturnVal = prueba.CambiarClave(cliente.Id, cliente.Clave0);
            //Valida que arroje la exception de SqlException
            Assert.IsTrue(ReturnVal is SqlException);

        }





        [ExpectedException(typeof(SqlException))]
        public void ValidarPreguntaRespuesta()
        {
            cliente.Id = 2;
            pregunta_respuesta.Pregunta = null;
            pregunta_respuesta.Respuesta = null;

            ReturnVal = prueba.ValidarPreguntaRespuesta(cliente.Id, pregunta_respuesta.Pregunta, pregunta_respuesta.Respuesta);
            //Valida que arroje la exception de SqlException
            Assert.IsTrue(ReturnVal is SqlException);

        }


    }
}
