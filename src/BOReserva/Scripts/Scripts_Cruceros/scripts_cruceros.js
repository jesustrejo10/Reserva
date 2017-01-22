//Funcion para cargar tabla de cabinas
$("#fk_id_crucero").change(function (e) {
    e.preventDefault();
    var form = $("#formGuardarCabina");
    console.log("cambio");
    $.ajax({
        url: "gestion_cruceros/M24_ListarCabinas/" + $("#fk_id_crucero").val(),
        data: null,
        type: 'GET',
        success: function (data) {
            console.log(data)
            $("#tablaCabinas tr").remove();
            for (var index = 0; index < data.length; index++) {
                console.log(data[index])

                var statusHTML = data[index]._estatus == "activo" ? "<td class='crStatus'><i class='fa fa-circle started'></i></td>" +
                                        "<td class='crAcciones'></i> <i class='fa fa-times' onclick='cambioCabina(" + data[index]._idCabina + ")'></i></td>" : "<td class='crStatus'><i class='fa fa-circle paused'></i></td><td class='crAcciones'> <i class='fa fa-check' onclick='cambioCabina(" + data[index]._idCabina + ")'></i></td>";


                console.log(statusHTML)
                html = "<tr id='" + data[index]._idCabina + "'><td style='text-align:center'>" + data[index]._nombreCabina + "</td><td style='text-align:center'>" + data[index]._precioCabina + '$' + "</td>" + statusHTML + "</tr>";
                console.log(html)
                $("#tablaCabinas").append(html);
            }
            //$('#formGuardarCabina')[0].reset();
        },
        error: function (data) {
            console.log(data);
            $('#formGuardarCabina')[0].reset();
        }
    });
});

//Función para cascade dropdown de camarote
$("#crucero").change(function () {
    var cID = $(crucero).val();
    $.getJSON("gestion_cruceros/cargarCabinas", { crucero: cID },
           function (data) {
               var select = $("#cabina");
               select.empty();
               select.append($('<option/>', {
                   value: 0,
                   text: "Seleccione una cabina"
               }));
               $.each(data, function (index, itemData) {
                   select.append($('<option/>', {
                       value: itemData.Value,
                       text: itemData.Text
                   }));
               });
           });
});


//Función para cascade dropdown de ruta origen
$("#cruceroR").change(function () {
    var cID = $(cruceroR).val();
    $.getJSON("gestion_cruceros/cargarRutasO", { cruceroR: cID },
           function (data) {
               var select = $("#ciudadO");
               select.empty();
               select.append($('<option/>', {
                   value: 0,
                   text: "Seleccione una ruta origen"
               }));
               $.each(data, function (index, itemData) {
                   select.append($('<option/>', {
                       value: itemData.Value,
                       text: itemData.Text
                   }));
               });
           });
});


//Función para cascade dropdown de ruta destino
$("#ciudadO").change(function () {
    var cID = $(ciudadO).val();
    $.getJSON("gestion_cruceros/cargarRutasD", { ciudadO: cID },
           function (data) {
               var select = $("#ciudadD");
               select.empty();
               select.append($('<option/>', {
                   value: 0,
                   text: "Seleccione una ruta destino"
               }));
               $.each(data, function (index, itemData) {
                   select.append($('<option/>', {
                       value: itemData.Value,
                       text: itemData.Text
                   }));
               });
           });
});


$("#guardar_camarote").click(function (e) {
    e.preventDefault();
    var form = $("#formGuardarCamarote");
    $.ajax({
        url: "gestion_cruceros/guardarCamarote",
        data: form.serialize(),
        type: 'POST',
        success: function (data) {
            var statusHTML = "<td class='crStatus'><i class='fa fa-circle started'></i></td><td class='crAcciones'> <i class='fa fa-times' onclick='cambioCamarote(" + $("#idCamarote").val() + ")'></i></td>";
            html = "<tr><td style='text-align:center'>" + $("#cantidadCama").val() + "</td><td style='text-align:center'>" + $("#tipoCama").val() + "</td>" + statusHTML + "</tr>";
            console.log(html)
            $("#tablaCamarote").append(html);
            //$("#tablaCamarote").append("<tr><td>" + $("#cantidadCama").val() + "</td><td>" + $("#tipoCama").val() + "</td></tr>");
        },
        error: function (data) {
            console.log(data);
            $('#formGuardarCamarote')[0].reset();
        }
    });
});



//Funcion para cargar cb de cabinas
$("#fk_id_crucero").change(function (e) {
    e.preventDefault();
    var form = $("#formGuardarCamarote");
    console.log("cambio");
    $.ajax({
        url: "gestion_cruceros/M24_ListarCabinas/" + $("#fk_id_crucero").val(),
        data: null,
        type: 'GET',
        success: function (data) {
            $("#fk_id_cabina").empty();
            for (var index = 0; index < data.length; index++) {
                console.log(data[index])
                html = "<option id='" + data[index]._idCabina + "' value='" + data[index]._idCabina + "'>" + data[index]._nombreCabina + "</option>";
                console.log(html)
                $("#fk_id_cabina").append(html);
            }
            //$('#formGuardarCabina')[0].reset();
        },
        error: function (data) {
            console.log(data);
            $('#formGuardarCamarote')[0].reset();
        }
    });
});

//Funcion para cargar tabla de camarotes
$("#fk_id_cabina").change(function (e) {
    e.preventDefault();
    var form = $("#formGuardarCamarote");
    $.ajax({
        url: "gestion_cruceros/M24_ListarCamarotes/" + $("#fk_id_cabina").val(),
        data: null,
        type: 'GET',
        success: function (data) {
            console.log(data)
            $("#tablaCamarote tr").remove();
            for (var index = 0; index < data.length; index++) {
                console.log(data[index])

                var statusHTML = data[index]._estatus == "activo" ? "<td class='crStatus'><i class='fa fa-circle started'></i></td>" +
                                        "<td class='crAcciones'><i class='fa fa-times' onclick='cambioCamarote(" + data[index]._idCamarote + ")'></i></td>" : "<td class='crStatus'><i class='fa fa-circle paused'></i></td><td class='crAcciones'></i> <i class='fa fa-check' onclick='cambioCamarote(" + data[index]._idCamarote + ")'></i></td>";


                console.log(statusHTML)
                html = "<tr id='" + data[index]._idCamarote + "'><td style='text-align:center'>" + data[index]._cantidadCama + "</td><td style='text-align:center'>" + data[index]._tipoCama + "</td>" + statusHTML + "</tr>";
                console.log(html)
                $("#tablaCamarote").append(html);
            }
            //$('#formGuardarCabina')[0].reset();
        },
        error: function (data) {
            console.log(data);
            $('#formGuardarCabina')[0].reset();
        }
    });
});
