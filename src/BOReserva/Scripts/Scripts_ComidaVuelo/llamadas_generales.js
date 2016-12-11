$("#aceptarPlato").click(function (e) {
    console.log("hola!");
    e.preventDefault();
    var form = $("#formGuardarPlato");
    $.ajax({
        url: "gestion_comida_vuelo/guardarPlato",
        data: form.serialize(),
        type: 'POST',
        success: function (data) {
            alert("Se guardo");
            $('#formGuardarPlato')[0].reset();
        }
        , error: function (xhr, textStatus, exceptionThrown) {
            //muestro el texto del error
            alert(xhr.responseText);
        }
    });
});