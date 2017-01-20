using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BOReserva.Views.gestion_restaurantes.Fabrica
{
    public static class FabricaVista
    {
        public static SelectList asignarItemsComboBox(IEnumerable lista,String Text, String Value)
        {
           return new SelectList(lista,Text,Value); 
        }

        public static SelectList asignarItemsComboBoxConPosicion(IEnumerable lista, String Text, String Value, Object posicion)
        {
            return new SelectList(lista, Text, Value, posicion);
        }
    }
}