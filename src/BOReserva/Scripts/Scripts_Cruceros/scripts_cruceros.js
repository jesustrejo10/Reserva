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
          
                var statusHTML = data[index]._estatus == "activo" ? "<td class='crStatus'><i class='fa fa-circle started'></i></td>"+
                                        "<td class='crAcciones'><i class='fa fa-pencil'></i> <i class='fa fa-times cambioCabina'></i></td>" : "<td class='crStatus'><i class='fa fa-circle paused'></i></td>"+
                                       "<td class='crAcciones'><i class='fa fa-pencil'></i> <i class='fa fa-check cambioCabina'></i></td>";

                console.log(statusHTML)
                html = "<tr id='"+data[index]._idCabina+"'><td style='text-align:center'>" + data[index]._nombreCabina + "</td><td style='text-align:center'>" + data[index]._precioCabina + "</td>" + statusHTML + "</tr>";
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

//Funcion para cargar cb de cabinas
$("#fk_id_crucero").change(function (e) {
    e.preventDefault();
    var form = $("#formGuardarCamarote");
    console.log("cambio");
    $.ajax({
        url: "gestion_cruceros/M24_ListarCabinas/"+ $("#fk_id_crucero").val(),
        data: null,
        type: 'GET',
        success: function (data) {
            console.log(data)
            for (var index = 0; index < data.length; index++) {
                console.log(data[index])
                html = "<option id='" + data[index]._idCabina + "' value='" + data[index]._nombreCabina + "'>" + data[index]._nombreCabina + "</option>"; 
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



