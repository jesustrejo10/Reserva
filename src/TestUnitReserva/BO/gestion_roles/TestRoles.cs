using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using BOReserva.Models.gestion_roles;
using BOReserva.Servicio;
using System.Diagnostics;
using System.Data.SqlClient;
using System.Web;
using System.Web.Mvc;


namespace TestUnitReserva.BO.gestion_roles
{
    [TestFixture]
    class TestRoles
    {
        manejadorSQL prueba = new manejadorSQL();
        //Test para probar que se logra hacer un insert de 
        [Test]
        public void M13_InsertarRol()
        {
            CRoles rol = new CRoles();

            rol.Nombre_rol = "TestRol";

            Boolean resultadoRol = prueba.insertarRol(rol);
            Assert.AreEqual(resultadoRol, true);

        }
        //Test para probar el metodo que te devuelve el id de un permiso
        [Test]
        public void M13_BuscarIdPermiso()
        {
            CRoles rol = new CRoles();

            rol.Nombre_rol = "TestRol";

            String resultadoPermiso = prueba.MBuscarid_Permiso("Gestion de aviones");
            Assert.IsNotEmpty(resultadoPermiso);

        }

        //Test para probar el metodo que te devuelve el id de un RoL
        [Test]
        public void M13_BuscarIdRol()
        {

            String resultadoRol = prueba.MBuscarid_IdRol("Administrador");
            Assert.IsNotEmpty(resultadoRol);

        }


        [Test]
        public void M13_insetarPermisoRol()
        {

            Boolean resultadoRol = prueba.insertarPermisosRol("Administrador","Gestion de aviones");
            Assert.AreEqual(resultadoRol,true);

        }

        [Test]
        public void M13_consultarPerisosDeUnModulo()
        {

             CListaGenerica<CModulo_detallado> respueta = prueba.consultarPermisos("Modulo de roles");
             Assert.AreNotEqual(respueta,0 );

        }


        
    }
}
