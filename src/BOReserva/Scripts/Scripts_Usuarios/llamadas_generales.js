$("#cancelarModificacion").click(function (e) {
    e.preventDefault();
    var url = '/gestion_usuarios/M12_VisualizarUsuarios';
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
});

    //$(".modificar").click(function () {
    //    alert("Se esta procesando tu solicitud, por favor espere");
    //    e.preventDefault();
    //    var form = $("#formGuardarUsuario");
    //    $.ajax({
    //        url: "/gestion_usuarios/modificarUsuario",
    //        data: form.serialize(),
    //        type: 'POST',
    //        success: function(data){
    //            alert("Usuario Modificado");

    //            url = '/gestion_usuarios/M12_VisualizarUsuario'
    //            method = 'GET';
    //            data = '';

    //            $.ajax(
    //                {
    //                    url: url,
    //                    type: method,
    //                    data: data,
    //                    success: function (data, textStatus, jqXHR){

    //                        $("#contenido").empty();
    //                        $("#contenido").append(data);
    //                    },
    //                    error: function (jqXHR, textStatus, errorThrown) {
    //                        alert(errorThrown);
    //                    }
    //                });
    //        },
    //        error: function (xhr, textStatus, exceptionThrown) {
    //            alert(xhr.responseText);
    //        }
    //    });
    //});


//$(".modificarUsuario_form").submit(function (e) {
//    console.log("hola!");
//    e.preventDefault();
//    var form = $(".modificarUsuario_form");
//    $.ajax({
//        url: "gestion_usuarios/M12_ModificarUsuario",
//        data: form.serialize(),
//        type: 'POST',
//        success: function (data) {
//            toIndex();
//        }
//    , error: function (xhr, textStatus, exceptionThrown) {
//        //muestro el texto del error
//        alert(xhr.responseText);
//    }
//    });
//});


function toIndex() {
    var url = '/gestion_usuarios/M12_VisualizarUsuarios';
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
};

$("#aceptarUsuario").click(function (e) {
    console.log("hola!");
    e.preventDefault();
    var form = $(".agregarUsuario_form");
    $.ajax({
        url: "gestion_usuarios/guardarUsuario",
        data: form.serialize(),
        type: 'POST',
        success: function (data) {
            alert("Se registro el Usuario exitosamente 2");
            $('#agregarUsuario_form')[0].reset();
        }
    , error: function (xhr, textStatus, exceptionThrown) {
        //muestro el texto del error
        alert(xhr.responseText);
    }
    });
});

$("#aceptarUsuario").click(function (e) {
    e.preventDefault();
    var form = $("#agregarUsuario_form");
    var correo = $('#correoUsuario').val();
    var nombre = $('#nombreUsuario').val();
    var apellido = $('#apellidoUsuario').val();
    var contrasena = $('#contrasena').val();
    var confContrasena = $('#confContraseña').val();
    var rol = $('#rolUsuario').val();
    var activo = $('#activoUsuario').val();

    console.log(correo);
    console.log(nombre);
    console.log(apellido);
    console.log(contrasena);
    console.log(confContrasena);
    console.log(rol);
    console.log(activo);
});

$(".modificar").click(function (e) {
    console.log("hola! modificar");
    e.preventDefault();
    var form = $(".modificarUsuario_form");
    $.ajax({
        url: "gestion_usuarios/modificarUsuario",
        data: form.serialize(),
        type: 'POST',
        success: function (data) {
            alert("Se modifico el Usuario exitosamente 2");
            $('#modificarUsuario_form')[0].reset();
        }
    , error: function (xhr, textStatus, exceptionThrown) {
        //muestro el texto del error
        alert(xhr.responseText);
    }
    });
});

$(".modificar").click(function (e) {
    e.preventDefault();
    var form = $("#modificarUsuario_form");
    var correo = $('#correoUsuario').val();
    var nombre = $('#nombreUsuario').val();
    var apellido = $('#apellidoUsuario').val();
    var contrasena = $('#contrasena').val();
    var confContrasena = $('#confContraseña').val();
    var rol = $('#rolUsuario').val();
    var activo = $('#activoUsuario').val();

    console.log(correo);
    console.log(nombre);
    console.log(apellido);
    console.log(contrasena);
    console.log(confContrasena);
    console.log(rol);
    console.log(activo);
});

function toIndexA() {
    var url = '/gestion_usuarios/M12_VisualizarUsuarios';
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
};
