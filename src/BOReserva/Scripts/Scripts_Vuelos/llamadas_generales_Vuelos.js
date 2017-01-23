// Evento para agregar un vuelo a la BD CREAR
$("#formGuardarVuelo").submit(function (e) {
    e.preventDefault();
    if (validateForm1() != false) {
        var form = $("#formGuardarVuelo");
        var selectedCO = $("#ciudadO option:selected").text();
        var selectedCD = $("#ciudadD option:selected").text();
        $("#_ciudadOrigen").val(selectedCO);
        $("#_ciudadDestino").val(selectedCD);
        $.ajax({
            url: "gestion_vuelo/M04_GestionVuelo_CW2",
            data: form.serialize(),
            type: 'POST',
            success: function (data, textStatus, jqXHR) {

                $("#contenido").empty();
                $("#contenido").append(data);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                alert(errorThrown);
            }
        , error: function (xhr, textStatus, exceptionThrown) {
            //muestro el texto del error
            alert(xhr.responseText);
        }
        });
    };
});
//Formulario 2 Crear vuelo
$("#formGuardarVuelo2").submit(function (e) {
    e.preventDefault();
    var form = $("#formGuardarVuelo2");
    $.ajax({
        url: "gestion_vuelo/M04_GestionVuelo_CW3",
        data: form.serialize(),
        type: 'POST',
        success: function (data, textStatus, jqXHR) {

            $("#contenido").empty();
            $("#contenido").append(data);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert(errorThrown);
        }
    , error: function (xhr, textStatus, exceptionThrown) {
        //muestro el texto del error
        alert(xhr.responseText);
    }
    });
});
//Formulario 3 Crear vuelo
$("#formGuardarVuelo3").submit(function (e) {
    e.preventDefault();
    var form = $("#formGuardarVuelo3");
    $.ajax({
        url: "gestion_vuelo/M04_GuardarVuelo",
        data: form.serialize(),
        type: 'POST',
        success: function (data, textStatus, jqXHR) {

            $("#contenido").empty();
            $("#contenido").append(data);
            alert("Vuelo Registrado Exitosamente")
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert(errorThrown);
        }
    , error: function (xhr, textStatus, exceptionThrown) {
        //muestro el texto del error
        alert(xhr.responseText);
    }
    });
});
//Formulario 1 Modificar Vuelo
$("#formModificarVuelo").submit(function (e) {
    e.preventDefault();
    if (validateForm1() != false) {
            var form = $("#formModificarVuelo");
            var selectedCO = $("#ciudadO option:selected").text();
            var selectedCD = $("#ciudadD option:selected").text();
            $("#_ciudadOrigen").val(selectedCO);
            $("#_ciudadDestino").val(selectedCD);
            $.ajax({
            url: "gestion_vuelo/M04_GestionVuelo_MW2",
            data: form.serialize(),
            type: 'POST',
            success: function (data, textStatus, jqXHR) {

                    $("#contenido").empty();
                    $("#contenido").append(data);
        },
            error: function (jqXHR, textStatus, errorThrown) {
                    alert(errorThrown);
        }
            , error: function (xhr, textStatus, exceptionThrown) {
            //muestro el texto del error
                alert(xhr.responseText);
        }
        });
    }
});
//Formulario 2 Modificar Vuelo
$("#formModificarVuelo2").submit(function (e) {
    e.preventDefault();
    var form = $("#formModificarVuelo2");
    $.ajax({
        url: "gestion_vuelo/M04_GestionVuelo_MW3",
        data: form.serialize(),
        type: 'POST',
        success: function (data, textStatus, jqXHR) {

            $("#contenido").empty();
            $("#contenido").append(data);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert(errorThrown);
        }
    , error: function (xhr, textStatus, exceptionThrown) {
        //muestro el texto del error
        alert(xhr.responseText);
    }
    });
});
//Formulario 3 Modificar Vuelo
$("#formModificarVuelo3").submit(function (e) {
    e.preventDefault();
    var form = $("#formModificarVuelo3");
    $.ajax({
        url: "gestion_vuelo/M04_ModificarVuelo",
        data: form.serialize(),
        type: 'POST',
        success: function (data, textStatus, jqXHR) {

            $("#contenido").empty();
            $("#contenido").append(data);
            alert("Vuelo Modificado Exitosamente")
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert(errorThrown);
        }
    , error: function (xhr, textStatus, exceptionThrown) {
        //muestro el texto del error
        alert(xhr.responseText);
    }
    });
});
//al cambiar la matricula del avion carga toda la info del aterrizaje
$("#matAvion").change(function(e){
    e.preventDefault();
    var formulario = $(matAvion).val();
    var url = "gestion_vuelo/M04_DatosAterrizaje";
    if (formulario != 0) {
        $.ajax({
            url: url,
            data: { idAvion: formulario },
            cache: false,
            type: 'POST',
            success: function (data) {
                $("#modeloAvion").val(data._modeloAvion);
                $("#velocidadMaxima").val(data._velocidadMaxima);
                $("#pasajerosAvion").val(data._pasajerosAvion);
                $("#distanciaMaxima").val(data._distanciaMaxima);
            }
            , error: function (xhr, textStatus, exceptionThrown) {
                alert(xhr.responseText);
            }
        });
    }

});
//al cambiar la matricula del avion carga toda la info del aterrizaje
$("#matAvion2").change(function () {
    var formulario = $(matAvion).val();
    $.getJSON("gestion_vuelo/M04_DatosAterrizaje", { idAvion: formulario },
           function (data) {
               var select = $("#ciudadD");
               select.empty();
               select.append($('<option/>', {
                   value: 0,
                   text: "Seleccione la Ciudad de Destino"
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

//evento para cargar los destinos disponibles segun el origen seleccionado en la vista CREAR
$("#ciudadO").change(function () {
    var cID = $(ciudadO).val();
    var select1 = $("#ciudadD");
    if (cID == 0)
    {
        select1.empty();
        select1.append($('<option/>', {
            value: 0,
            text: "Seleccione la Ciudad de Destino"
            , error: function (xhr, textStatus, exceptionThrown) {
                alert(xhr.responseText);
            }
        }));
     }
        else{

        }
        $.getJSON("gestion_vuelo/cargarDestinos", { ciudadO: cID },
               function (data) {
                   var select = $("#ciudadD");
                        select.empty();
                        select.append($('<option/>', {
                            value: 0,
                            text: "Seleccione la Ciudad de Destino"
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
    var dID = $(ciudadD).val();
 
    $.getJSON("gestion_vuelo/validarAviones", { idRuta: dID },
           function (data) {
               var select = $("#matAvion");
               select.empty();
               select.append($('<option/>', {
                   value: 0,
                   text: "Seleccione un avion"
                   , error: function (jqXHR, textStatus, errorThrown) {
                       alert(jqXHR);
                   }
               }));
               $.each(data, function (index, itemData) {
                   select.append($('<option/>', {
                       value: itemData.Value,
                       text: itemData.Text
                   }));
               });
           })
        .error(function (xhr, textStatus, exceptionThrown) {
            alert(xhr.responseText);
            $('#ciudadD').val(0);
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
            $('#codigoVuelo').attr("maxlength", 12);
            // verificar que el campo de Codigo Vuelo no tenga caracteres especiales ni espacios
            if (/[^a-z0-9]/gi.test(codVuelo)) {// Validando 
                alert("El codigo de vuelo no puede contener caracteres especiales");
                field.value = '';
            } else {
                var url = "/gestion_vuelo/validarCodigo";
                $.ajax({
                    url: url,
                    data: { codVuelo: codVuelo },
                    cache: false,
                    type: "POST",
                    success: function (data) {
                    },
                    error: function (xhr, textStatus, exceptionThrown) {
                        alert(xhr.responseText);
                        $('#codigoVuelo').val('');
                    }
                });
            }
        }



$(".mostrar").click(function () {
    var identificador = $(this).parent().parent().parent().attr("id");
    jQuery.ajax({
        type: "GET",
        url: "/gestion_vuelo/M04_Ver_Vuelo",
        data: { idVuelo: identificador }
    }).done(function (data) {
        $("#contenido").empty();
        $("#contenido").append(data);
        alert("Cargando, por favor espere...");
    }).fail(function (err) {
        alert(err)
    });


});
// VISTA VISUALIZAR = Funcion que llamara a la vista de modificar y mostara el vuelo seleciconado a modificar
 $(".modificar").click(function () {
            var identificador = $(this).parent().parent().parent().attr("id");
            jQuery.ajax({
                type: "GET",
                url: "/gestion_vuelo/M04_GestionVuelo_MW1",
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
                            alert("Status del Vuelo cambiado Existosamente")
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
                            alert("Status del Vuelo cambiado Existosamente")
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
                        select.value(0);
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

 function setSelectByTextSimple(text) { //Loop through sequentially//
     var select = $("#matAvion");
     select.value = text
 }

 function setSelectByText(text, text2) { //Loop through sequentially//
     $("#ciudadO option").each(function () {
         if ($(this).text() == text) {
             $(this).attr('selected', 'selected');
         }
     });

     var cID = $(ciudadO).val();
     var select1 = $("#ciudadD");
     if (cID == 0) {
         select1.empty();
         select1.append($('<option/>', {
             value: 0,
             text: "Seleccione la Ciudad de Destino"
             , error: function (xhr, textStatus, exceptionThrown) {
                 alert(xhr.responseText);
             }
         }));
     }
     else {

     }
     $.getJSON("gestion_vuelo/cargarDestinos", { ciudadO: cID },
            function (data) {
                var select = $("#ciudadD");
                select.empty();
                select.append($('<option/>', {
                    value: 0,
                    text: "Seleccione la Ciudad de Destino"
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
                select.val(text2)
                
            });


 }

//Validaciones de campo

 $('#codigoVuelo').keyup(function () {
     var matricula = $('#codigoVuelo').val();
     if (/[^a-z0-9/-]/gi.test(matricula)) {  // Valido que no tenga caracteres especiales ni espacios
         alert("El codigo de vuelo no puede tener caracteres especiales ni espacios");
         $('#codigoVuelo').val('');
     }
 });

 function checkTextCodigo2() {
     var codVuelo = $('#codigoVuelo').val(); 
     var url = "/gestion_vuelo/validarCodigo";
    $.ajax({
        url: url,
        data: { codVuelo: codVuelo },
        cache: false,
        type: "GET",
        success: function (data) {
        },
        error:(function (xhr, textStatus, exceptionThrown) {
            alert(xhr.responseText);
        }),
    });
}

 $('#fechaDespegue').keyup(function () {
     var matricula = $('#fechaDespegue').val();
     if (/[^a-z0-9/-]/gi.test(matricula)) {  // Valido que no tenga caracteres especiales ni espacios
         alert("El codigo de vuelo no puede tener caracteres especiales ni espacios");
         $('#codigoVuelo').val('');
     }
 });
 function isDateSelected() {
     var today = new Date();
     var inputDate = new Date(document.interestForm.bday.value);
     if (inputDate.value == " ") {
         return false;
     } else if (inputDate > today) {
         return false;
     } else {
         return true;
     }
 }

 $("#fechaDespegue").keypress(function (event) { event.preventDefault(); });

 function validateForm1() {
     if ((document.getElementById("codigoVuelo").value) == ""
         || document.getElementById("ciudadO").value == "0"
         || document.getElementById("ciudadD").value == "0"
         || document.getElementById("fechaDespegue").value == ""
         || document.getElementById("horaDespegue").value == "") {
         alert("Campos Obligatorios Vacios");
         return false;
     }
 }

$(".eliminar").click(function () {
    var id = $(this).parent().parent().parent().attr("id");
    jQuery.ajax({
        type: "GET",
        url: "/gestion_vuelo/M04_Eliminar_Vuelo",
        data: { idVuelo: id }
    }).done(function (data) {
        alert("Vuelo Eliminado Exitosamente")
        $("#contenido").empty();
        $("#contenido").append(data);
    }).fail(function(xhr, textStatus, exceptionThrown) {
        alert(xhr.responseText);
    });


});