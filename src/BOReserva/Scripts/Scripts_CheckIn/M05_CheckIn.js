$("#siguiente").click(function (e) {
    if (pasaporte == "" || pasaporte == undefined || !pasaporte.match(carnum)) {
        $("#pasaporte").addClass("has-error");
        $("#pass_empty").fadeIn();
        win = false;
    }
    else {
        e.preventDefault();
        var form = $("#formPasaporte");
        $.ajax({
            url: "gestion_check_in/buscarBoletos",
            data: form.serialize(),
            type: 'POST',
            success: function (data) {

                $("#contenido").empty();
                $("#contenido").append(data);
            }
               , error: function (xhr, textStatus, exceptionThrown) {

                   alert(xhr.responseText);
               }
        });
    }
});
