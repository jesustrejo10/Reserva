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
$("#matAvion").click(function (e) {
    e.preventDefault();
    var aID = $(matAvion).val();
    var url = "gestion_vuelo/buscaModeloA";
    $.ajax({
        url: url,
        data: { matriAvion: aID },
        cache: false,
        type: 'POST',
        success: function (data) {
            if (data != null) {
                $("#modeloAvion").val(data);
            }
        }
        , error: function (xhr, textStatus, exceptionThrown) {
            alert(xhr.responseText);
        }
    });
});

//evento para traer la cantidad de pasajeros segun avion seleccionado en la vista CREAR
$("#matAvion").click(function (e) {
    e.preventDefault();
    var aID = $(matAvion).val();
    var url = "gestion_vuelo/buscaPasajerosA";
    $.ajax({
        url: url,
        data: { matriAvion: aID },
        cache: false,
        type: 'POST',
        success: function (data) {
            if (data != null) {
                $("#pasajerosAvion").val(data);
            }
        }
        , error: function (xhr, textStatus, exceptionThrown) {
            alert(xhr.responseText);
        }
    });
});

//evento para traer la distancia maxima que cubre segun avion seleccionado en la vista CREAR
/*$("#matAvion").click(function (e) {
    e.preventDefault();
    var aID = $(matAvion).val();
    var url = "gestion_vuelo/buscaDistanciaA";
    $.ajax({
        url: url,
        data: { matriAvion: aID },
        cache: false,
        type: 'POST',
        success: function (data) {
            if (data != null) {
                $("#distanciaMaxima").val(data);
            }
        }
        , error: function (xhr, textStatus, exceptionThrown) {
            alert(xhr.responseText);
        }
    });
});*/

//evento para traer la velocidad maxima segun avion seleccionado en la vista CREAR
$("#matAvion").click(function (e) {
    e.preventDefault();
    var aID = $(matAvion).val();
    var url = "gestion_vuelo/buscaVelocidadA";
    $.ajax({
        url: url,
        data: { matriAvion: aID },
        cache: false,
        type: 'POST',
        success: function (data) {
            if (data != null) {
                $("#velocidadMaxima").val(data._ciudadDestino);
                $("#distanciaMaxima").val(data._ciudadOrigen);
            }
        }
        , error: function (xhr, textStatus, exceptionThrown) {
            alert(xhr.responseText);
        }
    });
});

//evento para luego de haber seleccionado el estado del vuelo, se calcule la fecha del aterrizaje en la vista CREAR
$("#estadoVuelo").click(function (e) {
    e.preventDefault();
    var fID = $(fechaDespegue).val();
    var hID = $(horaDespegue).val();
    var oID = $(ciudadO).val();
    var dID = $(ciudadD).val();
    var mID = $(matAvion).val();
    var url = "gestion_vuelo/buscaFechaA";
    $.ajax({
        url: url,
        data: { fechaDes: fID, horaDes: hID, ciudadO: oID, ciudadD: dID, matriAvion: mID, opcion: 0 },
        cache: false,
        type: 'POST',
        success: function (data) {
            $("#fechaAterrizaje").val(data);
        }
        , error: function (xhr, textStatus, exceptionThrown) {
            alert(xhr.responseText);
        }
    });
});

//evento para luego de haber seleccionado el estado del vuelo, se calcule la hora del aterrizaje en la vista CREAR
$("#estadoVuelo").click(function (e) {
    e.preventDefault();
    var fID = $(fechaDespegue).val();
    var hID = $(horaDespegue).val();
    var oID = $(ciudadO).val();
    var dID = $(ciudadD).val();
    var mID = $(matAvion).val();
    var url = "gestion_vuelo/buscaFechaA";
    $.ajax({
        url: url,
        data: { fechaDes: fID, horaDes: hID, ciudadO: oID, ciudadD: dID, matriAvion: mID, opcion: 1 },
        cache: false,
        type: 'POST',
        success: function (data) {
            $("#horaAterrizaje").val(data);
        }
        , error: function (xhr, textStatus, exceptionThrown) {
            alert(xhr.responseText);
        }
    });
});
//evento para el boton de return de la vista VISUALIZAR-->MOSTRAR
        $("#return").click(function (e) {
            e.preventDefault();
            var url = '/gestion_vuelo/M04_GestionVuelo_Visualizar';
            var method = 'GET';
            var data = '';
            alert("Cargando, por favor espere...");

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

        function checkTextCodigo(field) {
            var codVuelo = $('#codigoVuelo').val();
            // verificar que el campo de Codigo Vuelo no tenga caracteres especiales ni espacios
            if (/[^a-z0-9]/gi.test(codVuelo)) {// Validando 
                alert("El codigo de vuelo no puede contener caracteres especiales");
                field.value = '';
            } else {
                var url = "/gestion_vuelo/revisarCodVuelo";
                $.ajax({
                    url: url,
                    data: { codVuelo: codVuelo },
                    cache: false,
                    type: "POST",
                    success: function (data) {
                        if (data == "1") {
                            alert("Este codigo de vuelo ya esta registrado");
                            field.value = '';
                        }
                    },
                    error: function (reponse) {
                        alert("error : " + reponse);
                    }
                });
            }
        }

// VISTA VISUALIZAR = Funcion que llamara a la vista de mostrar y le pasa el id del vuelo seleccionado
        $(".mostrar").click(function () {
            var identificador = $(this).parent().parent().parent().attr("id");
            jQuery.ajax({
                type: "GET",
                url: "/gestion_vuelo/M04_GestionVuelo_Mostrar",
                data: { id: identificador }
            }).done(function (data) {
                $("#contenido").empty();
                $("#contenido").append(data);
                var url = '/gestion_vuelo/M04_GestionVuelo_Visualizar';
                var method = 'GET';
                var data = '';
                alert("Cargando, por favor espere...");
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
            }).fail(function (err) {
                alert(err)
            });


        });


// VISTA VISUALIZAR = Funcion que llamara a la vista de modificar y mostara el vuelo seleciconado a modificar
        $(".modificar").click(function () {
            var identificador = $(this).parent().parent().parent().attr("id");
            jQuery.ajax({
                type: "GET",
                url: "/gestion_vuelo/M04_GestionVuelo_Modificar", 
                data: { id: identificador }
            }).done(function (data) {
                $("#contenido").empty();
                $("#contenido").append(data);
                alert("Cargando, por favor espere...");
            }).fail(function (err) {
                alert(err)
            });


        });


//VISTA VISUALIZAR= funcion que tomara el ID de la tupla seleccionada en la tabla y procedera a desactivara en la BD
        $(".desactivar").click(function () {
            var identificador = $(this).parent().parent().parent().attr("id");
            jQuery.ajax({
                type: "GET",
                url: "/gestion_vuelo/M04_Cambiar_Status", //llama a la funcion en controller que desactivara el vuelo
                data: { idVuelo: identificador }
            }).done(function (data) {
                var url = '/gestion_vuelo/M04_GestionVuelo_Visualizar'; //vuelve a cargar la ventana actualizada
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
            }).fail(function (err) {
                alert('Fallo')
            });
        });

// VISTA VISUALIZAR= Funcion que procedera a activar un vuelo en estado inactivo
        $(".activar").click(function () {
            var identificador = $(this).parent().parent().parent().attr("id");
            jQuery.ajax({
                type: "GET",
                url: "/gestion_vuelo/M04_Cambiar_Status", //llama a la funcion que activara el vuelo en la BD
                data: { idVuelo: identificador }
            }).done(function (data) {
                var url = '/gestion_vuelo/M04_GestionVuelo_Visualizar'; //vuelve a cargar la vista con el vuelo actualizado
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
            }).fail(function (err) {
                alert('Fallo')
            });
        });

 $("#ciudadOMod").change(function () {
            var cID = $(ciudadOMod).val();
            $.getJSON("gestion_vuelo/cargarDestinosModificar", { ciudadOMod: cID },
                   function (data) {
                       var select = $("#ciudadDMod");
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
 $("#ciudadDMod").change(function () {
     var cID = $(ciudadOMod).val();
     var dID = $(ciudadDMod).val();
     $.getJSON("gestion_vuelo/validarAvionesModificar", { ciudadO: cID, ciudadD: dID },
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
