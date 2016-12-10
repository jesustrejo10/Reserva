
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

       $("#ciudadO").change(function (e) {
           var cID = $(this).val(Selection);
           alert(cID);
             $.getJSON("gestion_vuelo/cargarDestinos", { COI: cID },
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