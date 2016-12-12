
//EVENTO PARA AGREGAR UNA OFERTA
$("#btnGuardarOferta").click(function (e) {
    e.preventDefault();
    var form = $("#formGuardarOferta");

    //Si el usuario selecciono paquetes
    var selectedValues = [];
    $("#paquetesMultiselect :selected").each(function () {
        selectedValues.push($(this).val());
    });
    
    $.ajax({
        url: "gestion_ofertas/guardarOferta",
        data: form.serialize() + "&estadoOferta=" + $("#estadoOferta").val(),
        //data: { 'nombreOferta': $("#nombreOferta").val(), 'fInicio': $("#fInicio").val(), 'fFin': $("#fFin").val(), 'porcentajeOferta': $("#porcentajeOferta").val() },
        type: 'POST',
        success: function (data) {
            if (selectedValues.length > 0) {
                asociarPaquetesOferta(selectedValues);
            }
            else {
                $('#formGuardarOferta')[0].reset();
                alert("La oferta ha sido creada");
            }
        }
        , error: function (xhr, textStatus, exceptionThrown) {
            //muestro el texto del error
            alert(xhr.responseText);
        }
    });

});

function asociarPaquetesOferta(idsPaquetes) {
    $.ajax({
        url: "gestion_ofertas/asociarPaquetesOferta",
        data: { idsPaquetes: idsPaquetes },
        type: 'POST',
        success: function (data) {
            alert("La oferta ha sido creada");
            $('#formGuardarOferta')[0].reset();
        }
        , error: function (xhr, textStatus, exceptionThrown) {
            //muestro el texto del error
            alert(xhr.responseText);
        }
    });
}

function getPaquetesFromDB() {
    $.ajax(
       {
           url: '/gestion_ofertas/M11_CargarPaquetesSelect',
           type: 'POST',
           success: function (data) {
               console.log(data);
               mostrarPaquetesMultiselect(data);
           },
           error: function (jqXHR, textStatus, errorThrown) {
               alert(errorThrown);
           }
       });
}

function mostrarPaquetesMultiselect(data) {
    for (var i in data) {
        var idPaquete = data[i]._idPaquete;
        var nombrePaquete = data[i]._nombrePaquete;
        $("#paquetesMultiselect").append('<option value="' + idPaquete + '">' + nombrePaquete + '</option>');
    }
}

function getSelected() {
    var selectedValues = [];
    $("#paquetesMultiselect :selected").each(function () {
        selectedValues.push($(this).val());
    });
    alert(selectedValues);
    return false;
}