

// Evento para agregar un vuelo a la BD CREAR
$("#agregarVuelo").click(function (e) {
    e.preventDefault();
    var form = $("#formGuardarVuelo");
    $.ajax({
        url: "gestion_vuelo/guardarVuelo",
        data: form.serialize(),
        type: 'POST',
        success: function (data) {
            alert("Se guardo el vuelo exitosamente");
            $('formGuardarVuelo')[0].reset();
        }
        , error: function (xhr, textStatus, exceptionThrown) {
            alert(xhr.responseText);
        }
    });
});



//evento para cargar los destinos disponibles segun el origen seleccionado en la vista CREAR
$("#ciudadO").change(function () {
    var cID = $(ciudadO).val();
        $.getJSON("gestion_vuelo/cargarDestinos", { ciudadO: cID },
               function (data) {
                   var select = $("#ciudadD");
                        select.empty();
                        select.append($('<option/>', {
                            value: 0,
                            text: "Seleccione una ciudad destino"
                            , error: function (xhr, textStatus, exceptionThrown) {
                                alert(xhr.responseText);
                            }
                        }));
                        $.each(data, function (index, itemData) {
                            select.append($('<option/>', {
                                value: itemData.Value,
                                text: itemData.Text
                            }));

                        });
                   
               });
});
//evento para cargar los aviones que puedan cubrir la distancia de la ruta seleccionada en la vista CREAR
$("#ciudadD").change(function () {
    var cID = $(ciudadO).val();
    var dID = $(ciudadD).val();
    $.getJSON("gestion_vuelo/validarAviones", { ciudadO: cID, ciudadD: dID },
           function (data) {
               var select = $("#matAvion");
               select.empty();
               select.append($('<option/>', {
                   value: 0,
                   text: "Seleccione un avion"
                   , error: function (xhr, textStatus, exceptionThrown) {
                       alert(xhr.responseText);
                   }
               }));
               $.each(data, function (index, itemData) {
                   select.append($('<option/>', {
                       value: itemData.Value,
                       text: itemData.Text
                   }));
               });
           });
});

//evento para traer el modelo del avion seleccionado en la vista CREAR
$("#matAvion").change(function () {
    var aID = $(matAvion).val();
    $.getJSON("gestion_vuelo/buscaModeloA", { matriAvion: aID },
           function (data) {
               $("#modeloAvion").val(data);
           });
});

//evento para traer la cantidad de pasajeros segun avion seleccionado en la vista CREAR
$("#matAvion").change(function () {
    var aID = $(matAvion).val();
    $.getJSON("gestion_vuelo/buscaPasajerosA", { matriAvion: aID },
       function (data) {
           $("#pasajerosAvion").val(data);
       });
});

//evento para traer la distancia maxima que cubre segun avion seleccionado en la vista CREAR
$("#matAvion").change(function () {
    var aID = $(matAvion).val();
    $.getJSON("gestion_vuelo/buscaDistanciaA", { matriAvion: aID },
       function (data) {
           $("#distanciaMaxima").val(data);
       });
});

//evento para traer la velocidad maxima segun avion seleccionado en la vista CREAR
$("#matAvion").change(function () {
    var aID = $(matAvion).val();
    $.getJSON("gestion_vuelo/buscaVelocidadA", { matriAvion: aID },
       function (data) {
           $("#velocidadMaxima").val(data);
       });
});

//evento para luego de haber seleccionado el estado del vuelo, se calcule la fecha del aterrizaje en la vista CREAR
$("#estadoVuelo").change(function () {
    var fID = $(fechaDespegue).val();
    var hID = $(horaDespegue).val();
    var oID = $(ciudadO).val();
    var dID = $(ciudadD).val();
    var mID = $(matAvion).val();
    $.getJSON("gestion_vuelo/buscaFechaA", { fechaDes: fID, horaDes: hID, ciudadO: oID, ciudadD: dID, matriAvion: mID, opcion: 0},
       function (data) {
           $("#fechaAterrizaje").val(data);
       });
});

//evento para luego de haber seleccionado el estado del vuelo, se calcule la hora del aterrizaje en la vista CREAR
$("#estadoVuelo").change(function () {
    var fID = $(fechaDespegue).val();
    var hID = $(horaDespegue).val();
    var oID = $(ciudadO).val();
    var dID = $(ciudadD).val();
    var mID = $(matAvion).val();
    $.getJSON("gestion_vuelo/buscaFechaA", { fechaDes: fID, horaDes: hID, ciudadO: oID, ciudadD: dID, matriAvion: mID, opcion: 1 },
       function (data) {
           $("#horaAterrizaje").val(data);
       });
});

// verificar que el campo de Codigo Vuelo no tenga caracteres especiales ni espacios
function checkTextCodigo(field) {
    var codigo = $('#codigoVuelo').val();
    if (/[^a-z0-9]/gi.test(codigo)) {  // Validando 
        alert("El codigo de vuelo no puede contener caracteres especiales ni espacios");
        field.value = '';
    }
}
//evento para el boton de return de la vista VISUALIZAR-->MOSTRAR
        $("#return").click(function (e) {
            e.preventDefault();
            var url = '/gestion_vuelo/M04_GestionVuelo_Visualizar';
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

//verificar campo de CodigoVuelo
        function checkTextField(field) {
            var _codVuelo = $('#codigoVuelo').val();
            // verificar que el campo de Codigo Vuelo no tenga caracteres especiales ni espacios
            if (/[^a-z0-9]/gi.test(codVuelo)) {// Validando 
                alert("El codigo de vuelo no puede contener caracteres especiales ni espacios");
                field.value = '';
            } else {
                var url = "/gestion_automoviles/revisarCodVuelo";
                $.ajax({
                    url: url,
                    data: { codigoVuelo: _codVuelo },
                    cache: false,
                    type: "POST",
                    success: function (data) {
                        if (data == "1") {
                            alert("Este codigo ya esta registrado");
                            field.value = '';
                        }
                    },
                    error: function (reponse) {
                        alert("error : " + reponse);
                    }
                });
            }
        }