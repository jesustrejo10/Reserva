//EVENTO PARA EDITAR UN HOTEL
$("#aceptarhotel").click(function (e) {
    console.log("hola!");
    e.preventDefault();
    var form = $("#formEditarHotel");
    $.ajax({
        url: "gestion_hoteles/editarhotel",
        data: form.serialize(),
        type: 'POST',
        success: function (data) {
            alert("Se ha actualizado el hotel.");
            $('#formCrearHotel')[0].reset();
        }
        , error: function (xhr, textStatus, exceptionThrown) {
            //muestro el texto del error
            alert(xhr.responseText);
        }
    });
});