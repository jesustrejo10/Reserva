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

        if (nombre == "" || nombre == undefined || !nombre.match(caracteres)) {

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


// CÓDIGO DE VALIDACIÓN PARA CREAR LA RESERVA DE RESTAURANTES 
jQuery(document).ready(function () {
    $("#reserv_restaurante").on("click", function () {
        //clear errors
        $(".error").hide();
        $("#name_client").removeClass("has-error");
        $("#reserv_hour").removeClass("has-error");
        $("#number_person").removeClass("has-error");

        //find errors
        var nombre = $("#name_client").val();
        var hora = $("#reserv_hour").val();
        var fecha = $("#reserv_date").prop("value");
        var caracteres = /^[a-zA-Z\s]+$/;

        var win = true;

        if (nombre == "" || nombre == undefined || !nombre.match(caracteres)) {

            if (nombre == "" || nombre == undefined) {
                $("#name_client").addClass("has-error");
                $("#name_empty").fadeIn();
                win = false;
            }
            else {
                $("#name_client").addClass("has-error");
                $("#name_format").fadeIn();
                win = false;
            }
        }
        if (hora == 0) {
            var win = false;
            $("#reserv_hour").addClass("has-error");
            $("#hora_null").fadeIn();
            win = false;
        }

        if (fecha ==  null || fecha == 0) {
            var win = false;
            $("#reserv_date").addClass("has-error");
            $("#fecha_null").fadeIn();
            win = false;
        }

        if (win) {
            $("#reserva_form").submit();
        }
        else
            return false;
    });

});

