
//EVENTO PARA AGREGAR UNA OFERTA
$("#btnGuardarOferta").click(function (e) {
    e.preventDefault();
    if (validarCamposVacios() && validarEstarFechas() && compararFechas()) {
        var form = $("#formGuardarOferta");

        //Si el usuario selecciono paquetes
        var selectedValues = [];
        $("#paquetesMultiselect :selected").each(function () {
            selectedValues.push($(this).val());
        });

        $.ajax({
            url: "gestion_ofertas/guardarOferta",
            data: form.serialize() + "&estadoOferta=" + $("#estadoOferta").val(),
            type: 'POST',
            success: function (data) {
                if (selectedValues.length > 0) {
                    asociarPaquetesOferta(selectedValues);
                }
                else {
                    $('#formGuardarOferta')[0].reset();
                    alert("La oferta ha sido creada");
                    irVisualizarOferta();
                }
            }
            , error: function (xhr, textStatus, exceptionThrown) {
                //muestro el texto del error
                alert(xhr.responseText);
            }
        });
    }
});

function asociarPaquetesOferta(idsPaquetes) {
    $.ajax({
        url: "gestion_ofertas/asociarPaquetesOferta",
        data: { idsPaquetes: idsPaquetes },
        type: 'POST',
        success: function (data) {
            alert("La oferta ha sido creada");
            $('#formGuardarOferta')[0].reset();
            irVisualizarOferta();
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

//Devuelve id seleccionados de multiselect
function getSelected() {
    var selectedValues = [];
    $("#paquetesMultiselect :selected").each(function () {
        selectedValues.push($(this).val());
    });
    return false;
}

function irVisualizarOferta() {
    var url = '/gestion_ofertas/M11_VisualizarOferta';
    var method = 'GET';
    var data = '';

    $.ajax(
        {
            url: url,
            type: method,
            data: data,
            success: function (data, textStatus, jqXHR) {

                $("#contenido").empty();
                $("#contenido").append(data);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                alert(errorThrown);
            }
        });
}