
function mostrarValoracion() {
    $(".valoracion").each(function (index, item) {
        var revisiones = $(item)
        var referenciaId = revisiones.data("id")
        var referenciaTipo = revisiones.data("type")

        cargarContenido(revisiones, "POST", "/gestion_revision/obtener_valoracion", {
            id: referenciaId,
            tipo: referenciaTipo
        }, null, function () {

            $(".rateyo").each(function (index, item) {
                var valoracion = $(item)
                var estrellas = valoracion.data("estrellas")
                var only = valoracion.data("only")
                $(item).rateYo({
                    rating: estrellas,
                    readOnly: only,
                    numStars: 5,
                    precision: 2,
                    minValue: 1,
                    maxValue: 5
                })                
            }
        )})
    })
}


(function () {
    mostrarValoracion()
})();