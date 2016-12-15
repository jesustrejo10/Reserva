//FUNCIONES EN COMUN



        function checkTextModelo(field) {
            var matricula = $('#vehi_modelo').val();
            if (/[^a-z0-9]/gi.test(matricula)) { 
                alert("No puede contener caracteres especiales");
                field.value = '';
            }
        }



        function checkTextField(field) {
            var _matricula = $('#vehi_placa').val();

            if (/[^a-z0-9]/gi.test(_matricula)) {
                alert("No puede contener caracteres especiales");
                field.value = '';
            } else {
                var url = "/gestion_automoviles/checkplaca";
                $.ajax({
                    url: url,
                    data: { matricula: _matricula},
                    cache: false,
                    type: "POST",
                    success: function (data) {
                        if (data == "1") {
                            alert("Esa matrícula ya esta registrada");
                            field.value = '';
                        }
                    },
                    error: function (reponse) {
                        alert("error : " + reponse);
                    }
                });
            }
        }



        function checklargo(field) {
            if (field.value != '') {
                if (field.value < 0) {
                    alert("No puedes colocar números negativos");
                    field.value = '';
                }
                if (field.value > 999999999) {
                    alert("No puedes exceder los 10 dígitos");
                    field.value = '';
                }
            }
        }



        function checktarifapenalidad(field) {
            if (field.value != '') {
                if (field.value <= 0) {
                    alert("No puedes colocar números negativos o que sea igual a cero");
                    field.value = '';
                }
                if (field.value > 9999) {
                    alert("No puedes colocar un precio mayor a 4 dígitos");
                    field.value = '';
                }
            }
        }



        function checkprecio(field) {
            if (field.value != '') {
                if (field.value <= 0) {
                    alert("No puedes colocar números negativos o que sea igual a cero");
                    field.value = '';
                }
                if (field.value > 999999999) {
                    alert("No puedes exceder los 10 dígitos");
                    field.value = '';
                }
            }
        }



        function checkanio(field) {
            var str = $('#vehi_registro').val();
            var date = new Date(str);
            var year = date.getFullYear();
            if ((year <= 1999) || (year > 2016)) {
                alert('El año ingresado no es válido');
                $("#vehi_registro").val("");
            }
        }



