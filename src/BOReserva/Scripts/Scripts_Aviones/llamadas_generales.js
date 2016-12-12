    //EVENTO PARA AGREGAR UN AVION
    $("#aceptarAvion").click(function (e) {
        console.log("hola!");
        e.preventDefault();
        var form = $("#formGuardarAvion");
        $.ajax({
            url: "gestion_aviones/guardarAvion",
            data: form.serialize(),
            type: 'POST',
            success: function (data) {
                alert("Se agregó el avión");
                $('#formGuardarAvion')[0].reset();
            }
            , error: function (xhr, textStatus, exceptionThrown) {
                //muestro el texto del error
                alert(xhr.responseText);
            }
        });
    });

     
           $("#aceptarAvion").click(function (e) {
               e.preventDefault();
               var form = $("#formGuardarAvion");
               var matricula = $('#matriculaAvion').val();
               var modelo = $('#modeloAvion').val();
               var distancia = $('#distanciaMaximaVuelo').val();
               var velocidad = $('#velocidadMaximaVuelo').val();
               var combustible = $('#capacidadCombustible').val();
               var equipaje = $('#capacidadEquipaje').val();
               var turista = $('#capacidadTurista').val();
               var Ejecutiva = $('#capacidadEjecutiva').val();
               var VIP = $('#capacidadVIP').val();
           });  
         
    function checkTextMatricula(field) {
        var matricula = $('#matriculaAvion').val();
        if (/[^a-z0-9]/gi.test(matricula)) {  // Valido que no tenga caracteres especiales ni espacios
            alert("La matrícula no puede contener caracteres especiales ni espacios en blanco");
            field.value = '';
        }
    }
      
    function checkTextModelo(field) {
        var modelo = $('#modeloAvion').val();
        if (/[^a-z0-9/-]/gi.test(modelo)) {  // anything but a-zA-Z0-9 and dot
            alert("El modelo no puede contener caracteres especiales ni espacios");
            field.value = '';
        }
    }

    $('#capacidadTurista').keyup(function () {
        var numbers = $(this).val();
        $(this).val(numbers.replace(/\D/, ''));
    });

    $('#capacidadTurista').focusout(function () {
        var numbers = $(this).val();
        if (numbers > 999999999) {
            $(this).val('');
            alert("Debe ingresar un valor válido");
        }
        if (numbers <= 0) {
            $(this).val('');
            alert("Debe ingresar un valor mayor a cero");
        }
    });

    $('#capacidadEjecutiva').keyup(function () {
        var numbers = $(this).val();
        $(this).val(numbers.replace(/\D/, ''));
    });

    $('#capacidadEjecutiva').focusout(function () {
        var numbers = $(this).val();
        if (numbers > 999999999) {
            $(this).val('');
            alert("Debe ingresar un valor válido");
        }
        if (numbers <= 0) {
            $(this).val('');
            alert("Debe ingresar un valor mayor a cero");
        }
    });

    $('#capacidadVIP').keyup(function () {
        var numbers = $(this).val();
        $(this).val(numbers.replace(/\D/, ''));
    });

    $('#capacidadVIP').focusout(function () {
        var numbers = $(this).val();
        if (numbers > 999999999) {
            $(this).val('');
            alert("Debe ingresar un valor válido");
        }
        if (numbers <= 0) {
            $(this).val('');
            alert("Debe ingresar un valor mayor a cero");
        }
    });

    $('#velocidadMaximaDeVuelo').keyup(function () {
        var numbers = $(this).val();
        $(this).val(numbers.replace(/\D/, ''));
    });

    $('#velocidadMaximaDeVuelo').focusout(function () {
        var numbers = $(this).val();
        if (numbers > 999999999) {
            $(this).val('');
            alert("Debe ingresar un valor válido");
        }
        if (numbers <= 0) {
            $(this).val('');
            alert("Debe ingresar un valor mayor a cero");
        }
    });

    $('#distanciaMaximaDeVuelo').keyup(function () {
        var numbers = $(this).val();
        $(this).val(numbers.replace(/\D/, ''));
    });

    $('#distanciaMaximaDeVuelo').focusout(function () {
        var numbers = $(this).val();
        if (numbers > 999999999) {
            $(this).val('');
            alert("Debe ingresar un valor válido");
        }
        if (numbers <= 0) {
            $(this).val('');
            alert("Debe ingresar un valor mayor a cero");
        }
    });

    $('#capacidadCombustible').keyup(function () {
        var numbers = $(this).val();
        $(this).val(numbers.replace(/\D/, ''));
    });

    $('#capacidadCombustible').focusout(function () {
        var numbers = $(this).val();
        if (numbers > 999999999) {
            $(this).val('');
            alert("Debe ingresar un valor válido");
        }
        if (numbers <= 0) {
            $(this).val('');
            alert("Debe ingresar un valor mayor a cero");
        }
    });



    function NumeroEntero(field) {
        if (field != '') {
            var turista = $('#capacidadTurista').keyup(function () {
                var numbers = $(this).val();
                $(this).val(numbers.replace(/\D/,''));
            });
           // if (/[0-9]/gi.test(turista)) {  // solo numeros
             //   alert("Este campo solo admite valores enteros");
               // field.value = '';
            //}
            if (field.value > 9999999999) { //limite de digitos
                alert("No puede exceder los 10 digitos");
                field.value = '';
            }
        }
      }
    
    function checkLimite(field) {
        if (field !='') {
            alert("entro aqui en validacion de limite");
            if (isNaN(parseInt(field.value))) {
            alert("Debe introducir un valor válido");
            field.value = '';
           }
            //var velocidad = $('#velocidadMaximaVuelo').val();
            if (field.value > 9999999999) {
                alert("No puede exceder los 10 digitos");
                field.value = '';
            }
        }
    }
      
    







    $("#modificarAvion").click(function (e) {
        console.log("hola!");
        e.preventDefault();
        var form = $("#formGuardarAvion");
        $.ajax({
            url: "gestion_aviones/modificarAvion",
            data: form.serialize(),
            type: 'POST',
            success: function (data) {
                alert("Avión modificado");

                url = '/gestion_aviones/M02_VisualizarAviones';
                method = 'GET';
                data = '';

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

            }
            , error: function (xhr, textStatus, exceptionThrown) {
                //muestro el texto del error
                alert(xhr.responseText);
            }
        });
    });

    $("#cancelarModificacion").click(function (e) {
        e.preventDefault();
        var url = '/gestion_aviones/M02_VisualizarAviones';
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


