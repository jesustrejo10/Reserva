using BOReserva.Servicio.Servicio_Hoteles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BOReserva.Models.gestion_hoteles
{
    public class CGestionHoteles_SelectPaisModel
    {
        public static List<SelectListItem> pais()
        {
            CManejadorSQL_Rutas pais = new CManejadorSQL_Rutas();
            List<SelectListItem> _pais = new List<SelectListItem>();
            String[] paises = pais.MListarpaisesBD();
            int i = 0;
            bool verdad = true;
            while (verdad == true)
            {
                try
                {
                    _pais.Add(new SelectListItem
                    {
                        Text = paises[i].ToString(),
                        Value = i.ToString()
                    });
                    i++;
                }
                catch (Exception e)
                {
                    verdad = false;
                }
            }
            return _pais;
        }
    }
}