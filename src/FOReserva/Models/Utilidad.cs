using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Web;

namespace FOReserva.Models
{
    public class Utilidad
    {
        public static void RegistrarLog(Exception exception) {

            try
            {
                if (!Directory.Exists("/logs"))
                    Directory.CreateDirectory("/logs");
                using (StreamWriter w = File.AppendText("/logs/errors.log"))
                {
                    w.Write("\r\nLog Entry : ");
                    w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                        DateTime.Now.ToLongDateString());
                    w.WriteLine("  :");
                    w.WriteLine("Message :{0}", exception.Message);
                    w.WriteLine("StackTrace:{0}", exception.StackTrace);
                    w.WriteLine("-------------------------------");
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public static EventLog[] ObtenerLogs(Exception exception)
        {
            return EventLog.GetEventLogs();
        }

    }
}