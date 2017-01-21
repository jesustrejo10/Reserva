//SCRIPT PARA CARGAR EL LOADER
$('.wait').click(function () {
    $("#loader").fadeIn("slow");
    $(window).ajaxComplete(function () {
        // Se oculta el loader animado
        $("#loader").hide();
    });

});