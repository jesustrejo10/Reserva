var timoutWarning = 60000; //Muestra pop up al usuario al minuto restante de cierre de sesion
var timoutNow = 120000; // Cierra la sesion a los 2 min 
//var logoutUrl = 'gestion_seguridad_ingreso/M01_Login' // redirige al landing page Login.
var logoutUrl = 'Home/Index'
var warningTimer;
var timeoutTimer;

// Se Setean los timer de mensaje Popup y tiempo de Sesion
function StartTimers() {
    warningTimer = setTimeout("IdleWarning()", timoutWarning);
    timeoutTimer = setTimeout("IdleTimeout()", timoutNow);

}

// Se resetean los timer en caso de extender sesion.
function ResetTimers() {
    clearTimeout(warningTimer);
    clearTimeout(timeoutTimer);
    StartTimers();
    $("#timeout").dialog('close');
}

// Funcion que muestra ventana Popup en caso de extender sesion.
function IdleWarning() {
    if (confirm("¿Desea Extender Sesión?") == true) {
        ResetTimers();
    }

    $("#timeout").dialog({
        modal: true
    });
}

// Cierre de Sesion automatico.
function IdleTimeout() {
    window.location = logoutUrl;
}
