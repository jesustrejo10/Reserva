//FUNCIONES EN COMUN


function contar(s1, letter) {
    return (s1.match(RegExp(letter, 'g')) || []).length;
}

function checkpaginaweb(field) {
    var expression = /[-a-zA-Z0-9@:%_\+.~#?&//=]{2,256}\.[a-z]{2,4}\b(\/[-a-zA-Z0-9@:%_\+.~#?&//=]*)?/gi;
    var regex = new RegExp(expression);
    var t = $('#hot_web').val();
    if (t != '') {
        if (t.match(regex)) {
            if (contar(t, '\\.') === 1) {
                alert("No tiene formato de pagina web");
                field.value = '';
            } else {
                if (t.split(".", 2).pop(-1) === "") {
                    alert("No tiene formato de pagina web");
                    field.value = '';
                }
            }
        } else {
            alert("No tiene formato de pagina web");
            field.value = '';
        }
    }
}



function checkTextField(field) {
    var nombre = $('#hot_nombre').val();
    if (/[^a-z0-9_ ]/gi.test(nombre)) {
        alert("No puede contener caracteres especiales");
        field.value = '';
    } 
}


function validateEmail(email) {
    var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(email);
}

function checkcorreo(field) {
    var email = $("#hot_email").val();
    if (email != '') {
        if (!validateEmail(email)) {
            alert(email + " no es un correo valido");
            field.value = '';
        }
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



