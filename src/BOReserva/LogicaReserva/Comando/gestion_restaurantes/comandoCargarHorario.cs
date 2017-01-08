using BOReserva.Datos.Fabrica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.LogicaReserva.Comando.gestion_restaurantes
{
    public class comandoCargarHorario : Comando<List<String>>
    {

        public override List<string> Ejecutar()
        {
            return FabricaDatosSql.listarHorario();
        }
    }
}