﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BOReserva.Models.gestion_automoviles
{
    public class VehicleList
    {
        private static List<CAutomovil> mVehicles { set; get; }

        public static void MAgregarvehiculo(CAutomovil carro)
        {
            mVehicles.Add(carro);
        }

    }
}