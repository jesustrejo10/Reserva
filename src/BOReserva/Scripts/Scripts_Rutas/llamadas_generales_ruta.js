$("#ciudadO").change(function () {
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