using FOReserva.Models.Autos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FOReserva.Models.Fabrica
{
    public static class FabricaEntidad
    {

        #region Modulo 19
       /* public static CRestauranteModelo inicializarRestaurant(string nombre, string direccion, string telefono, string descripcion, string horarioApertura, string horarioCierre, int idLugar)
        {
            return new CRestauranteModelo(nombre, direccion, telefono, descripcion, horarioApertura, horarioCierre, idLugar);
        }

        public static CRestauranteModelo inicializarRestaurant(int id, string nombre, string direccion, string telefono, string descripcion, string horarioApertura, string horarioCierre, int idLugar)
        {
            return new CRestauranteModelo(id, nombre, direccion, telefono, descripcion, horarioApertura, horarioCierre, idLugar);
        }

        public static CRestauranteModelo inicializarRestaurant()
        {
            return new CRestauranteModelo();
        }

        public static Lugar inicializarLugar(int idLugar, string nombreLugar)
        {
            return new Lugar(idLugar, nombreLugar);
        }

        public static List<Lugar> inicializarListaLugar()
        {
            return new List<Lugar>();
        }

        public static List<CRestauranteModelo> inicializarListaRestarant()
        {
            return new List<CRestauranteModelo>();
        }*/

        #endregion

        #region Global

        public static List<Entidad> asignarListaDeEntidades()
        {
            return new List<Entidad>();
        }

        #endregion

    }
}