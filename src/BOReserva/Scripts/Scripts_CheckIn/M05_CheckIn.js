$("#siguiente").click(function (e) {
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
});