var timoutWarning = 540000; //Muestra pop up al usuario al minuto restante de cierre de sesion
var timoutNow = 600000; // Cierra la sesion a los 10 min 
var logoutUrl = 'gestion_seguridad_ingreso/M01_Login' // redirige al landing page Login.

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
