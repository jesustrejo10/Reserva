//FUNCIONES EN COMUN



        function checkTextModelo(field) {
            var matricula = $('#vehi_modelo').val();
            if (/[^a-z0-9\.]/gi.test(matricula)) {  // anything but a-zA-Z0-9 and dot
                alert("No puede contener caracteres especiales");
                field.value = '';
            }
        }



        function checkTextField(field) {
            var matricula = $('#vehi_placa').val();

            if (/[^a-z0-9\.]/gi.test(matricula)) {
                alert("No puede contener caracteres especiales");
                field.value = '';
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
                if (field.value > $('#vehi_compra').val()) {
                    alert("No puedes colocar un precio mayor al precio de compra");
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



