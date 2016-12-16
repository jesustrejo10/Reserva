$(document).ready(function () {

    var nombreOk = false;
    var apellidoOk = false;
    var correoOk = false;
    var claveOk = false;
    var confirmaClaveOk = false;
    var respuesta0Ok = false;
    var respuesta1Ok = false;
    var respuesta2Ok = false;
    var compararClavesOk = false;

    var logCorreoOk = false;
    var logClaveOk = false;

    var recCorreoOk = false;

    //VALIDACIONES DEL REGISTRO***************************************************************************************************************
 
    $("#regNombre").blur(function () { validacionMensajes("regNombre", "regNombreEmpty"); });
    $("#regApellido").blur(function () { validacionMensajes("regApellido", "regApellidoEmpty"); });
    $("#regCorreo").blur(function () { validacionMensajes("regCorreo", "regCorreoEmpty"); validarCorreo("regCorreo","regCorreoFormat")});
    $("#regClave").blur(function () { validacionMensajes("regClave", "regClaveEmpty"); compararClaves("regClave", "regConfirmaClave", "regConfirmaClaveError") });
    $("#regConfirmaClave").blur(function () { validacionMensajes("regConfirmaClave", "regConfirmaClaveEmpty"); compararClaves("regClave", "regConfirmaClave", "regConfirmaClaveError") });
    $("#regRespuesta0").blur(function () { validacionMensajes("regRespuesta0", "regRespuesta0Empty"); });
    $("#regRespuesta1").blur(function () { validacionMensajes("regRespuesta1", "regRespuesta1Empty"); });
    $("#regRespuesta2").blur(function () { validacionMensajes("regRespuesta2", "regRespuesta2Empty"); });

    $("#regBotonSubmit").click(function () { validarCamposRegistro(); });
  

    //VALIDACIONES DEL LOGIN***************************************************************************************************************

    $("#logCorreo").blur(function () { validacionMensajes("logCorreo", "logCorreoEmpty"); validarCorreo("logCorreo", "logCorreoFormat") });
    $("#logClave").blur(function () { validacionMensajes("logClave", "logClaveEmpty") });

    $("#logBotonSubmit").click(function () { validarCamposLogin(); });


    //VALIDACIONES DEL RECUPERA
    $("#recCorreo").blur(function () { validacionMensajes("recCorreo", "recCorreoEmpty"); validarCorreo("recCorreo", "recCorreoFormat") });
 
    $("#linkLogin").click(function () { mostrarContenedor("1") });
    $("#linkCorreoRecupera").click(function () { mostrarContenedor("2") });
    //$("#linkRecupera").click(function () { mostrarContenedor("3") });


    //VALIDACIONES DEL CAMBIO DE CLAVE
    $("#clave0").blur(function () { validacionMensajes("clave0", "clave0Empty"); compararClaves("clave0", "clave1", "clave1Error") });
    $("#clave1").blur(function () { validacionMensajes("clave1", "clave1Empty"); compararClaves("clave0", "clave1", "clave1Error") });


    //$("#linkRecupera").click(function () { mostrarContenedor("3") });


    ///* CARGADOR DE LA VISTA DE RECUPERACION****************************************TERMINARRRRRRRRRRRRRR**************************/
    //$("#recCorreoBotonSubmit").click(function (e) {
    //    e.preventDefault();

    //    validacionMensajes("recCorreo", "recCorreoEmpty");

    //if (recCorreoOk){
    //    var url = '@Url.Action("BuscarIdPregunta", "registro_autenticacion")';
    //    var method = 'POST';
    //    var data = $("#recCorreo").val();

    //    alert(data);
        
    //    $.ajax(
    //        {
    //            url: url,
    //            type: method,
    //            data: data,
    //            success: function (data, textStatus, jqXHR) {

    //                mostrarContenedor("3");
    //                alert(data.idUsuario);
    //                alert(data["idUsuario"]);
    //                $("#valorPregunta").val(data.idPregunta);
    //                $("#valorUsuarii").val(data.idUsuario);
    //                switch ($("#valorPregunta").val()) {
    //                    case "1":
    //                        $("#recPregunta1").show();
    //                        break;
    //                    case "2":
    //                        $("#recPregunta2").show();
    //                        break;
    //                    case "3":
    //                        $("#recPregunta3").show();
    //                        break;
    //                    case "4":
    //                        $("#recPregunta4").show();
    //                        break;
    //                    case "5":
    //                        $("#recPregunta5").show();
    //                        break;
    //                    case "6":
    //                        $("#recPregunta6").show();
    //                        break;
    //                    case "7":
    //                        $("#recPregunta7").show();
    //                        break;
    //                    case "8":
    //                        $("#recPregunta8").show();
    //                        break;
    //                    case "9":
    //                        $("#recPregunta9").show();
    //                        break;
    //                }
    //            },
    //            error: function (jqXHR, textStatus, errorThrown) {
    //                alert(errorThrown);
    //            }
    //        });
    //}
    //});
    

    function mostrarContenedor(contenedor) {
        if (contenedor == "1") {
            $("#contenedorCorreoRecupera").hide();
            $("#contenedorRecupera").hide();
            $("#contenedorLogin").show();
        }
        if (contenedor == "2") {
            $("#contenedorRecupera").hide();
            $("#contenedorLogin").hide();
            $("#contenedorCorreoRecupera").show();
        }
        if (contenedor == "3") {
            $("#contenedorLogin").hide();
            $("#contenedorCorreoRecupera").hide();
            $("#contenedorRecupera").show();
        }
    }

    //VALIDACION GENERAL
    function validacionMensajes(idInput, idEmpty) {
        $(".error").hide();
        $("#" + idInput).removeClass("has-error");
        var valor = $("#" + idInput).val();
        var win = true;

        if (valor == "" || valor == undefined) {
          $("#" + idInput).addClass("has-error");
          $("#" + idEmpty).fadeIn();
          win = false;
        }
    
        if (win) {
            switch (idInput) {
                case "regNombre":
                    nombreOk = true;
                    break;
                case "regApellido":
                    apellidoOk = true
                    break;
                case "regCorreo":
                    correoOk = true;
                    break;
                case "regClave":
                    claveOk = true;
                    break;
                case "regConfirmaClave":
                    confirmaClaveOk = true;
                    break;
                case "regRespuesta0":
                    respuesta0Ok = true;
                    break;
                case "regRespuesta1":
                    respuesta1Ok = true;
                    break;
                case "regRespuesta2":
                    respuesta2Ok = true;
                    break;
                case "logCorreo":
                    logCorreoOk = true;
                    break;
                case "logClave":
                    logClaveOk = true;
                    break;
                case "recCorreo":
                    recCorreoOk = true;
                    break;
            }
        }

    }

    function validarCorreo(id, idFormat) {
        var i;
        var campo = $("#" + id);
        var string = campo.val();
        for (i = 0; i < string.length; i++) {
            if (string[i] == '@') {
                if (i == string.length) {
                    $("#" + id).addClass("has-error");
                    $("#" + idFormat).fadeIn();
                    return false;
                }
                else {
                    return true;
                }
            }
        }
        $("#" + id).addClass("has-error");
        $("#" + idFormat).fadeIn();
        return false;
    }

    function compararClaves(idClave, idConfirmaClave, idConfirmaClaveError) {
        var clave = $("#" + idClave).val();
        var confirmaClave = $("#" + idConfirmaClave).val();

        if (clave != "" && confirmaClave != "" && clave == confirmaClave) 
            return true;
        else {
            $("#" + idConfirmaClave).addClass("has-error");
            $("#" + idConfirmaClaveError).fadeIn();
            return false;
        }
    }

    function limpiarCampo(id) {
        $(id).val("");
    }


    function validarCamposRegistro() {
        compararClavesOk = compararClaves("regClave", "regConfirmaClave", "regConfirmaClaveError");

        if (nombreOk && apellidoOk && correoOk && claveOk && confirmaClaveOk && respuesta0Ok && respuesta1Ok && respuesta2Ok && compararClavesOk)
            $("#formularioRegistro").submit();
        else
            $("#regErrorEnFormulario").fadeIn();
    }
     

     function validarCamposLogin() {
            
        if (logClaveOk && logCorreoOk)
            $("#formularioLogin").submit();
        else
            $("#logErrorEnFormulario").fadeIn();
    }
})

    
