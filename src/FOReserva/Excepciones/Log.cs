using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FOReserva.Excepciones
{
 
        public class Log
        {
            /// <summary>
            /// Metodo que escribe mensajes de error en un log
            /// </summary>
            /// <param name="clase">Clase en la que ocurrio el error</param>
            /// <param name="ex">excepcion que ocurrio</param>
            public static void EscribirError(string clase, Exception ex)
            {
                if (clase != null && ex != null && clase != "")
                {
                    XmlConfigurator.Configure();
                    ILog log = LogManager.GetLogger(clase);
                    log.Error("*******************************************************");
                    log.Error("Mensaje: " + ex.Message);
                    log.Error("Origen: " + ex.Source);
                    log.Error("Metodo: " + ex.TargetSite);
                    log.Error("StackTrace: " + ex.StackTrace);
                    log.Error("InnerException: " + ex.InnerException);
                }
                else
                {
                    throw new LogException(RecursoLog.CodigoErrorLog, RecursoLog.MensajeErrorLog, new LogException());
                }
            }
            /// <summary>
            /// Metodo que escribe mensajes de info en un log
            /// </summary>
            /// <param name="clase">Clase en la que se llama</param>
            /// <param name="mensaje">mensaje a mostrar en el log</param>
            /// <param name="metodo">metodo en la que se origino</param>
            public static void EscribirInfo(string clase, string mensaje, string metodo)
            {
                if (clase != null && clase != "" && mensaje != null && mensaje != "" && metodo != null && metodo != "")
                {
                    XmlConfigurator.Configure();
                    ILog log = LogManager.GetLogger(clase);
                    log.Info("*******************************************************");
                    log.Info("Clase: " + clase);
                    log.Info("Mensaje: " + mensaje);
                    log.Info("Metodo: " + metodo);
                }
                else
                {
                    throw new LogException(RecursoLog.CodigoErrorLog, RecursoLog.MensajeErrorLog, new LogException());
                }
            }
            /// <summary>
            /// Metodo que escribe mensajes de warning en un log
            /// </summary>
            /// <param name="clase">Clase en la que se llama</param>
            /// <param name="mensaje">mensaje a mostrar en el log</param>
            /// <param name="metodo">metodo en la que se origino</param>
            public static void EscribirWarning(string clase, string mensaje, string metodo)
            {
                if (clase != null && clase != "" && mensaje != null && mensaje != "" && metodo != null && metodo != "")
                {
                    XmlConfigurator.Configure();
                    ILog log = LogManager.GetLogger(clase);
                    log.Warn("*******************************************************");
                    log.Warn("Clase: " + clase);
                    log.Warn("Mensaje: " + mensaje);
                    log.Warn("Metodo: " + metodo);
                }
                else
                {
                    throw new LogException(RecursoLog.CodigoErrorLog, RecursoLog.MensajeErrorLog, new LogException());
                }
            }
        }
    
}