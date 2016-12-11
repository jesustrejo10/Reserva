

// Evento para agregar un vuelo a la BD
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
    });
});

$("#ciudadO").change(function () {
    var cID = $(ciudadO).val();
        $.getJSON("gestion_vuelo/cargarDestinos", { ciudadO: cID },
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
               }));
               $.each(data, function (index, itemData) {
                   select.append($('<option/>', {
                       value: itemData.Value,
                       text: itemData.Text
                   }));
               });
           });
});


$("#matAvion").change(function () {
    var aID = $(matAvion).val();
    $.getJSON("gestion_vuelo/buscaModeloA", { matriAvion: aID },
           function (data) {
               $("#modeloAvion").val(data);
           });
});

$("#matAvion").change(function () {
    var aID = $(matAvion).val();
    $.getJSON("gestion_vuelo/buscaPasajerosA", { matriAvion: aID },
       function (data) {
           $("#pasajerosAvion").val(data);
       });
});

$("#matAvion").change(function () {
    var aID = $(matAvion).val();
    $.getJSON("gestion_vuelo/buscaDistanciaA", { matriAvion: aID },
       function (data) {
           $("#distanciaMaxima").val(data);
       });
});

$("#matAvion").change(function () {
    var aID = $(matAvion).val();
    $.getJSON("gestion_vuelo/buscaVelocidadA", { matriAvion: aID },
       function (data) {
           $("#velocidadMaxima").val(data);
       });
});

$("#estadoVuelo").change(function () {
    var fID = $(fechaDespegue).val();
    var hID = $(horaDespegue).val();
    var oID = $(ciudadO).val();
    var dID = $(ciudadD).val();
    var mID = $(matAvion).val();
    $.getJSON("gestion_vuelo/buscaFechaA", { fechaDes: fID, horaDes: hID, ciudadO: oID, ciudadD: dID, matriAvion: mID  },
       function (data) {
           $("#fechaAterrizaje").val(data);
       });
});

$("#estadoVuelo").change(function () {
    var fID = $(fechaDespegue).val();
    var hID = $(horaDespegue).val();
    var oID = $(ciudadO).val();
    var dID = $(ciudadD).val();
    var mID = $(matAvion).val();
    $.getJSON("gestion_vuelo/buscaHoraA", { fechaDes: fID, horaDes: hID, ciudadO: oID, ciudadD: dID, matriAvion: mID },
       function (data) {
           $("#horaAterrizaje").val(data);
       });
});
