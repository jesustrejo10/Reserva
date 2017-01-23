
/// <summary>
/// Evento para agregar un avion
/// </summary>
$("#aceptarAvion").click(function (e) {
    console.log("hola!");
    e.preventDefault();
    var form = $("#formGuardarAvion");
    $.ajax({
        url: "gestion_aviones/guardarAvion",
        data: form.serialize(),
        type: 'POST',
        success: function (data) {
            alert("Se agregó el avión");
            $('#formGuardarAvion')[0].reset();
        }
        , error: function (xhr, textStatus, exceptionThrown) {
            //muestro el texto del error
            alert(xhr.responseText);
        }
    });
});

/// <summary>
/// evento para aceptar el avion al agregar
/// </summary>
$("#aceptarAvion").click(function (e) {
    e.preventDefault();
    var form = $("#formGuardarAvion");
    var matricula = $('#matriculaAvion').val();
    var modelo = $('#modeloAvion').val();
    var distancia = $('#distanciaMaximaVuelo').val();
    var velocidad = $('#velocidadMaximaVuelo').val();
    var combustible = $('#capacidadCombustible').val();
    var equipaje = $('#capacidadEquipaje').val();
    var turista = $('#capacidadTurista').val();
    var Ejecutiva = $('#capacidadEjecutiva').val();
    var VIP = $('#capacidadVIP').val();
});

/// <summary>
/// validacion de caracteres para el atributo matricula
/// </summary>
$('#matriculaAvion').keyup(function () {
    var matricula = $('#matriculaAvion').val();
    if (/[^a-z0-9/-]/gi.test(matricula)) {  // Valido que no tenga caracteres especiales ni espacios
        alert("La matrícula no puede contener caracteres especiales ni espacios en blanco, unicamente se permite '-'");
        $('#matriculaAvion').val('');
    }
});

/// <summary>
/// validacion de caracteres para el atributo modelo avion
/// </summary>
$('#modeloAvion').keyup(function () {
    var modelo = $('#modeloAvion').val();
    if (/[^a-z0-9/-]/gi.test(modelo)) {
        alert("El modelo no puede contener caracteres especiales ni espacios, unicamente se permite '-'");
        $('#modeloAvion').val('');
    }
});

/// <summary>
/// validacion de caracteres para el atributo capacidad turistica
/// </summary>
$('#capacidadTurista').keyup(function () {
    var numbers = $(this).val();
    $(this).val(numbers.replace(/\D/, ''));
});

/// <summary>
/// validacion de caracteres para el atributo capacidad turista
/// </summary>
$('#capacidadTurista').focusout(function () {
    var numbers = $(this).val();
    if (numbers > 999999999) {
        $(this).val('');
        alert("Debe ingresar un valor válido");
    }
    if (numbers <= 0) {
        $(this).val('');
        alert("Debe ingresar un valor mayor a cero");
    }
});

/// <summary>
/// validacion de caracteres para el atributo capacidad ejecutiva
/// </summary>
$('#capacidadEjecutiva').keyup(function () {
    var numbers = $(this).val();
    $(this).val(numbers.replace(/\D/, ''));
});

/// <summary>
/// validacion de caracteres para el atributo capacidad ejecutiva
/// </summary>
$('#capacidadEjecutiva').focusout(function () {
    var numbers = $(this).val();
    if (numbers > 999999999) {
        $(this).val('');
        alert("Debe ingresar un valor válido");
    }
    if (numbers <= 0) {
        $(this).val('');
        alert("Debe ingresar un valor mayor a cero");
    }
});

/// <summary>
/// validacion de caracteres para el atributo capacidad VIP
/// </summary>
$('#capacidadVIP').keyup(function () {
    var numbers = $(this).val();
    $(this).val(numbers.replace(/\D/, ''));
});

/// <summary>
/// validacion de caracteres para el atributo capacidad VIP
/// </summary>
$('#capacidadVIP').focusout(function () {
    var numbers = $(this).val();
    if (numbers > 999999999) {
        $(this).val('');
        alert("Debe ingresar un valor válido");
    }
    if (numbers <= 0) {
        $(this).val('');
        alert("Debe ingresar un valor mayor a cero");
    }
});

/// <summary>
/// validacion de caracteres para el atributo velocidad maxima de vuelo
/// </summary>
$('#velocidadMaximaDeVuelo').keyup(function () {
    var numbers = $(this).val();
    $(this).val(numbers.replace(/\D/, ''));
});

/// <summary>
/// validacion de caracteres para el atributo velocidad maxima de vuelo
/// </summary>
$('#velocidadMaximaDeVuelo').focusout(function () {
    var numbers = $(this).val();
    if (numbers > 999999999) {
        $(this).val('');
        alert("Debe ingresar un valor válido");
    }
    if (numbers <= 0) {
        $(this).val('');
        alert("Debe ingresar un valor mayor a cero");
    }
});

/// <summary>
/// validacion de caracteres para el atributo distancia maxima de vuelo
/// </summary>
$('#distanciaMaximaDeVuelo').keyup(function () {
    var numbers = $(this).val();
    $(this).val(numbers.replace(/\D/, ''));
});

/// <summary>
/// validacion de caracteres para el atributo distancia maxima de vuelo
/// </summary>
$('#distanciaMaximaDeVuelo').focusout(function () {
    var numbers = $(this).val();
    if (numbers > 999999999) {
        $(this).val('');
        alert("Debe ingresar un valor válido");
    }
    if (numbers <= 0) {
        $(this).val('');
        alert("Debe ingresar un valor mayor a cero");
    }
});

/// <summary>
/// validacion de caracteres para el atributo capacidad Combustible
/// </summary>
$('#capacidadCombustible').keyup(function () {
    var numbers = $(this).val();
    $(this).val(numbers.replace(/\D/, ''));
});

/// <summary>
/// validacion de caracteres para el atributo capacidad Combustible
/// </summary>
$('#capacidadCombustible').focusout(function () {
    var numbers = $(this).val();
    if (numbers > 999999999) {
        $(this).val('');
        alert("Debe ingresar un valor válido");
    }
    if (numbers <= 0) {
        $(this).val('');
        alert("Debe ingresar un valor mayor a cero");
    }
});

/// <summary>
/// validacion de la capacidad maxima caracteres a introducir para el atributo capacidad turista
/// </summary>
function NumeroEntero(field) {
    if (field != '') {
        var turista = $('#capacidadTurista').keyup(function () {
            var numbers = $(this).val();
            $(this).val(numbers.replace(/\D/, ''));
        });
        if (field.value > 9999999999) { //limite de digitos
            alert("No puede exceder los 10 digitos");
            field.value = '';
        }
    }
}

/// <summary>
/// validacion de la capacidad maxima caracteres a introducir
/// </summary>
function checkLimite(field) {
    if (field != '') {
        alert("entro aqui en validacion de limite");
        if (isNaN(parseInt(field.value))) {
            alert("Debe introducir un valor válido");
            field.value = '';
        }
        if (field.value > 9999999999) {
            alert("No puede exceder los 10 digitos");
            field.value = '';
        }
    }
}

/// <summary>
/// Evento para modificar avion
/// </summary>
$("#modificarAvion").click(function (e) {
    console.log("hola!");
    e.preventDefault();
    var form = $("#formGuardarAvion");
    $.ajax({
        url: "gestion_aviones/modificarAvion",
        data: form.serialize(),
        type: 'POST',
        success: function (data) {
            alert("Avión modificado");

            url = '/gestion_aviones/M02_VisualizarAviones';
            method = 'GET';
            data = '';

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
        , error: function (xhr, textStatus, exceptionThrown) {
            //muestro el texto del error
            alert(xhr.responseText);
        }
    });
});

/// <summary>
/// evento para cancelar el modificar avion
/// </summary>
$("#cancelarModificacion").click(function (e) {
    e.preventDefault();
    var url = '/gestion_aviones/M02_VisualizarAviones';
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

});