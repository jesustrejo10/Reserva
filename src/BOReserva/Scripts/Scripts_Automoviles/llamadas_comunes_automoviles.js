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
                            alert("Esa matricula ya esta registrada");
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
                    alert("No puedes colocar numeros negativos");
                    field.value = '';
                }
                if (field.value > 999999999) {
                    alert("No puedes exceder los 10 digitos");
                    field.value = '';
                }
            }
        }



        function checktarifapenalidad(field) {
            if (field.value != '') {
                if (field.value <= 0) {
                    alert("No puedes colocar numeros negativos o que sea igual a cero");
                    field.value = '';
                }
                if (field.value > 9999) {
                    alert("No puedes colocar un precio mayor a 4 digitos");
                    field.value = '';
                }
            }
        }



        function checkprecio(field) {
            if (field.value != '') {
                if (field.value <= 0) {
                    alert("No puedes colocar numeros negativos o que sea igual a cero");
                    field.value = '';
                }
                if (field.value > 999999999) {
                    alert("No puedes exceder los 10 digitos");
                    field.value = '';
                }
            }
        }



        function checkanio(field) {
            var str = $('#vehi_registro').val();
            var date = new Date(str);
            var year = date.getFullYear();
            if ((year <= 1999) || (year > 2016)) {
                alert('El valor ingresado no es valido');
                $("#vehi_registro").val("");
            }
        }



