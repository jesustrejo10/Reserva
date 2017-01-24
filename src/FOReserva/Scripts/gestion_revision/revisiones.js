
function mostrarReviciones() {
    $(".revisiones").each(function (index, item) {
        var revisiones = $(item)
        var referenciaId = revisiones.data("id")
        var referenciaTipo = revisiones.data("type")
        
        cargarContenido(revisiones, "POST", "/gestion_revision/obtener_revisiones", {
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
                    precision: 0,
                    minValue: 1,
                    maxValue: 5
                })
                .on("rateyo.set", function () { console.log("rateyo.set"); })
            }
        )
        })
    })    
}


function mostrarFormularioRevicion() {
    $(".form-revision").each(function (index, item) {
        var revisiones = $(item)
        var referenciaId = revisiones.data("id")
        var referenciaTipo = revisiones.data("type")
        
        cargarContenido(revisiones, "POST", "/gestion_revision/form_revision", {
            "Id" : 0,
            "Tipo" : referenciaTipo,
            "Referencia._id" : referenciaId,
            "Propietario._id" : 0
        }, null, function () {

            $(".rateyo").each(function (index, item) {
                var valoracion = $(item)
                var estrellas = valoracion.data("estrellas")
                var only = valoracion.data("only")
                
                $(item).rateYo({
                    rating: estrellas,
                    readOnly: only,
                    numStars: 5,
                    precision: 0,
                    minValue: 1,
                    maxValue: 5
                })
                .on("rateyo.set", function (rate, value) {
                    var idToSet = $(rate.currentTarget).data("setout")
                    if (idToSet != null && idToSet != "")
                        $(idToSet).val(value.rating)
                })
            }
        )
        })
    })    
}

function btnAgregarRevision(boton) {
    if (!$(boton).hasClass("disabled")) {
        $(boton).addClass("disabled")
        var form = $(boton).parent().parent()
        console.log(form.serialize())
        $.ajax({
            url: '/gestion_revision/guardar_revision',
            data: form.serialize(),
            type: 'POST',
            success: function (data) {
                form.find("input[type=text], textarea").val("");
                $(boton).removeClass("disabled")
            }
            , error: function (xhr, textStatus, exceptionThrown) {
                alert(xhr.responseText);
                $(boton).removeClass("disabled")
            }
        });
    }
}

function btnEditarRevision(boton) {
    var revision = $(boton).parent().parent()
    if (!$(boton).hasClass("editing")) {
        $(boton).addClass("editing")

        var valor = $(revision.find(".rev_mensaje")).html()
        $(revision.find(".rev_mensaje")).html($("<textarea />", { id: "valor", html: "va", style: "width:100%" }))
        $(revision.find(".rev_puntuacion > span")).rateYo("option", "readOnly", false)
    }
    else
        $(boton).removeClass("editing")

    if (!$(boton).hasClass("disabled") && !$(boton).hasClass("editing")) {
        $(boton).addClass("disabled")        
        var revisionId = revision.data("id")
        var revisionPropietario = revision.data("propietario")
        var revisionReferencia = revision.data("referencia")
        var revisionTipo = revision.data("tipo")
        var revisionMensaje = $(revision.find(".rev_mensaje #valor")).val()
        var revisionPuntuacion = $(revision.find(".rev_puntuacion > span")).rateYo("option", "rating")
        $.ajax({
            url: '/gestion_revision/guardar_revision',
            data: {
                "Id": revisionId,
                "Tipo": revisionTipo,
                "Mensaje": revisionMensaje,
                "Estrellas": revisionPuntuacion,
                "Referencia._id": revisionReferencia,
                "Propietario._id": revisionPropietario
            },
            type: 'POST',
            success: function (data) {                
                $(revision.find(".rev_puntuacion > span")).rateYo("option", "readOnly", true)
                $(revision.find(".rev_mensaje")).html(revisionMensaje)
                $(boton).removeClass("disabled")
            }
            , error: function (xhr, textStatus, exceptionThrown) {
                alert(xhr.responseText);
                $(boton).removeClass("disabled")
            }
        });
    }
}


function btnBorrarRevision(boton) {
    if (!$(boton).hasClass("disabled")) {
        $(boton).addClass("disabled")
        var revision = $(boton).parent().parent()
        var revisionId = revision.data("id")
        var revisionPropietario = revision.data("propietario")

        $.ajax({
            url: '/gestion_revision/borrar_revision',
            data: {
                "Id": revisionId,
                "Propietario._id": revisionPropietario
            },
            type: 'POST',
            success: function (data) {
                $(boton).parent().parent().remove()
                $(boton).removeClass("disabled")
            }
            , error: function (xhr, textStatus, exceptionThrown) {
                alert(xhr.responseText);
                $(boton).removeClass("disabled")
            }
        });
    }
}

function btnResetRevision(boton) {
    $("#form-revision").find("input[type=text], textarea").val("");
}

(function () {
    mostrarReviciones()
    mostrarFormularioRevicion()
})();