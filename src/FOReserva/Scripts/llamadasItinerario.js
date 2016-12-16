//CARGAR COMBO DE DESTINO Y FECHAS
$("#ciudadO").change(function () {
    var cID = $(ciudadO).val();
    console.log("destino");

   $.getJSON('/gestion_planificacion_vacaciones/cargarFechas', { ciudadO: cID },
           function (data) {
               var select = $("#fecha");
               console.log("FECHA!!!");
               select.empty();
               select.append($('<option/>', {
                   value: 0,
                   text: "Seleccione el dia"
               }));
               $.each(data, function (index, itemData) {
                   select.append($('<option/>', {
                       value: itemData.Value,
                       text: itemData.Text
                   }));
               });
           });
});
//EVENTO PARA AGREGAR UN ITINERARIO
$("#aceptarItinerario").click(function (e) {
    console.log("hola!");
    e.preventDefault();
    var form = $("#formbuscarDestino");
    $.ajax({
        url: '/gestion_planificacion_vacaciones/guardarItinerario',
        data: form.serialize(),
        type: 'POST',
        success: function (data) {
            alert("Se agregó el Itinerario");
          //  $('#formbuscarDestino')[0].reset();
        }
        , error: function (xhr, textStatus, exceptionThrown) {
            //muestro el texto del error
            alert(xhr.responseText);
        }
    });
});

   


//GUARDAR ITINERARIO
$("#aceptarItinerario").click(function (e) {
    e.preventDefault();
    var form = $("#formbuscarDestino");
    var actividad = $('#actividad').val();
    var fecha = $('#fecha').find(":selected").text();
    var ciudadO = $('#ciudadO').find(":selected").text();
});
//ELIMINAR ITINERARIO
$("#eliminarItinerario").click(function (e) {
    console.log("hola!");
    e.preventDefault();
    var form = $("#formbuscarDestino");
    $.ajax({
        url: '/gestion_planificacion_vacaciones/eliminarItinerario',
        data: form.serialize(),
        type: 'POST',
        success: function (data) {
            alert("Se elimino el Itinerario");
            $('#formbuscarDestino')[0].reset();
        }
        , error: function (xhr, textStatus, exceptionThrown) {
            //muestro el texto del error
            alert(xhr.responseText);
        }
    });
});

//EVENTO PARA ELIMINAR ITINERARIO
$("#eliminarItinerario").click(function (e) {
    e.preventDefault();
    var form = $("#formbuscarDestino");
    var actividad = $('#actividad').val();
    var fecha = $('#fecha').find(":selected").text();
    var ciudadO = $('#ciudadO').find(":selected").text();
});

//MODIFICAR
$("#modificarItinerario").click(function (e) {
    console.log("hola!");
    e.preventDefault();
    var form = $("#formbuscarDestino");
    $.ajax({
        url: '/gestion_planificacion_vacaciones/modificarItinerario',
        data: form.serialize(),
        type: 'POST',
        success: function (data) {
            alert("Se ha modificado su Itinerario");
           // $('#formbuscarDestino')[0].reset();
          
        }
        , error: function (xhr, textStatus, exceptionThrown) {
            //muestro el texto del error
            alert(xhr.responseText);
        }
    });
});

//EVENTO QUE MODIFICA
$("#modificarItinerario").click(function (e) {
    e.preventDefault();
    var form = $("#formbuscarDestino");
    var actividad = $('#actividad').val();
    var fecha = $('#fecha').find(":selected").text();
    var ciudadO = $('#ciudadO').find(":selected").text();
});
//evento consultar actividad
$("#consultarItinerario").click(function (e) {
    console.log("hola!");
    e.preventDefault();
    var form = $("#formbuscarDestino");
    $.ajax({
        url: '/gestion_planificacion_vacaciones/consultarActividad',
        data: form.serialize(),
        type: 'GET',
        success: function (data) {
            $("#actividad").empty();
            $("#actividad").append(data);
           // $('#formbuscarDestino')[0].reset();
       
        }
        , error: function (xhr, textStatus, exceptionThrown) {
            //muestro el texto del error
            alert("Ud no cuenta con Itinerarios para consultar");
           // alert(xhr.responseText);
        }
    });
});


$("#consultarItinerario").click(function (e) {
    e.preventDefault();
    var form = $("#formbuscarDestino");
    var actividad = $('#actividad').val();
    var fecha = $('#fecha').find(":selected").text();
    var ciudadO = $('#ciudadO').find(":selected").text();
});