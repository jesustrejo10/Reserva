using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.Models.Revision
{
    public class CRevision
    {

        DateTime fecha;
        string descripcion;
        int puntuacion;   // puntuacion que se le da al hotel estrellas de 1-5
        int valoracion;  // valoracion de la revision con like y dislike
        string tipo;
    }
}