// CÓDIGO DE VALIDACIÓN PARA LA BÚSQUEDA DE RESTAURANTES 
jQuery(document).ready(function () {
    $("#buscar_restaurante").on("click", function () {
        $(".error").hide();
        $("#search_val").removeClass("has-error");
        $("#name_rest").removeClass("has-error");
        var nombre = $("#name_rest").val();
        var tipo = $("#search_val").val();
        var caracteres = /^[a-zA-Z0-9\s]+$/;

        var win = true;

        if (nombre == "" || nombre == undefined || ! nombre.match(caracteres)) {

            if (nombre == "" || nombre == undefined) {
                $("#name_rest").addClass("has-error");
                $("#name_empty").fadeIn();
                win = false;
            }
            else {
                $("#name_rest").addClass("has-error");
                $("#name_format").fadeIn();
                win = false;
            }
        }
        if (tipo == 0) {
            var win = false;
            $("#search_val").addClass("has-error");
            $("#val_null").fadeIn();
            win = false;
        }

        if (win) {
            $("#rest_form").submit();
        }
        else
            return false;
    });

});

