﻿$("#ciudadO").change(function () {
    var cID = $(ciudadO).val();    
    $.getJSON("gestion_ruta_comercial/cargarDestinos", { ciudadO: cID },
           function (data) {
               var select = $("#ciudadD");
               select.empty();
               select.append($('<option/>', {
                   value: 0,
                   text: "Seleccione una ciudad destino"
               }));
               $.each(data, function (index, itemData) {
                   select.append($('<option/>', {
                       value: itemData.Value,
                       text: itemData.Text
                   }));
               });
           });
});

$("#enviar").click(function (e) {
    e.preventDefault();
    var form = $("#formGuardarRuta");
    var origen = $('#rutaOrigen').find(":selected").text();
    var destino = $('#rutaDestino').find(":selected").text();

    if (confirm("¿Esta conforme con la información suministrada?") == true) {
        alert("Agregando ruta, por favor espere...");
        $.ajax({
            url: "gestion_ruta_comercial/guardarRuta",
            data: form.serialize(),
            type: 'POST',
            success: function (data) {
                alert("Ruta guardada exitosamente");
                $('#formGuardarRuta')[0].reset();
            }, error: function (xhr, textStatus, exceptionThrown) {
                //muestro el texto del error
                alert(xhr.responseText);
            }

        });
    }
});


$("#VisualizarRutasComerciales").click(function (e) {
    e.preventDefault();
    var url = '/gestion_ruta_comercial/VisualizarRutasComerciales';
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


$(document).ready(function () {
    //e.preventDefault();
    $(".m03DetalleRutas").click(function () {
        var identificador = $(this).parent().parent().parent().attr("id");
        jQuery.ajax({
            type: "GET",
            url: "/gestion_ruta_comercial/DetalleRutasComerciales",
            data: { idRuta:identificador }//valor = es el nombre q recibes en el método es decir public ActionResult ModificarRutasComerciales(string valor)
        }).done(function (data) {          

            $("#contenido").empty();
            $("#contenido").append(data);
        }).fail(function () {
            alert("No Funcionó")
        });
    });
});

$(document).ready(function () {
    //e.preventDefault();
    $(".m03EditarRutas").click(function () {
        var identificador = $(this).parent().parent().parent().attr("id");
        jQuery.ajax({
            type: "GET",
            url: "/gestion_ruta_comercial/ModificarRutasComerciales",
            data: { idRuta:identificador }//valor = es el nombre q recibes en el método es decir public ActionResult ModificarRutasComerciales(string valor)
        }).done(function (data) {          

            $("#contenido").empty();
            $("#contenido").append(data);
        }).fail(function () {
            alert("No Funcionó")
        });
    });
});



$("#Modificar").click(function (e) {
    e.preventDefault();
    var form = $("#formGuardarRuta");
    if (confirm("¿Esta conforme con la información suministrada?") == true) {
        alert("Modificando ruta, por favor espere...");
        $.ajax({
            url: "gestion_ruta_comercial/modificarRuta",
            data: form.serialize(),
            type: 'POST',
            success: function (data) {
                alert("Ruta modificada exitosamente");
                $('#formGuardarRuta')[0].reset();
                var url = '/gestion_ruta_comercial/VisualizarRutasComerciales';
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
            }, error: function (xhr, textStatus, exceptionThrown) {
                //muestro el texto del error
                alert(xhr.responseText);
            }

        });
    }
});

// Validaciones de distancia

$('#distanciaRuta').keyup(function () {
    var numbers = $(this).val();
    $(this).val(numbers.replace(/\D/, ''));
});

$('#distanciaRuta').focusout(function () {
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

$(document).ready(function () {
    //e.preventDefault();
    $(".activar").click(function () {
        var identificador = $(this).parent().parent().parent().attr("id");
        jQuery.ajax({
            type: "POST",
            url: "/gestion_ruta_comercial/HabilitarRuta",
            data: { idRuta: identificador }//valor = es el nombre q recibes en el método es decir public ActionResult M08_VisualizarAutomoviles(string valor)


        }).done(function (data) {

                //$("#sdssss").append(data);
                var url1 = '/gestion_ruta_comercial/VisualizarRutasComerciales';
                var method = 'GET';
                var data1 = '';

                $.ajax(
                    {
                        url: url1,
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
        }).fail(function () {
            alert("no funciono")
        });
    });
});


$(document).ready(function () {
    //e.preventDefault();
    $(".desactivar").click(function () {
        var identificador = $(this).parent().parent().parent().attr("id");
        jQuery.ajax({
            type: "POST",
            url: "/gestion_ruta_comercial/InhabilitarRuta",
            data: { idRuta: identificador }//valor = es el nombre q recibes en el método es decir public ActionResult M08_VisualizarAutomoviles(string valor)
        }).done(function (data) {

                //$("#sdssss").append(data);
                var url1 = '/gestion_ruta_comercial/VisualizarRutasComerciales';
                var method = 'GET';
                var data1 = '';

                $.ajax(
                    {
                        url: url1,
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
        }).fail(function () {
            alert("no funciono")
        });
    });
});