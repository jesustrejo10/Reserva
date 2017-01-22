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
    if (/[^a-z0-9_ ']/gi.test(nombre)) {
        alert("No puede contener caracteres especiales");
        field.value = '';
    } 
}


function CheckForRepeat(originalString, charToCheck) {
    var repeatCount = 0;
    for (var i = 0; i < originalString.length; i++) {
        if (originalString.charAt(i) == charToCheck) {
            repeatCount++;
        } else {
            repeatCount = 0;
        }
        if (repeatCount == 2) {
            return 1;
        }
    }
    return 0;
}
function checkdireccion(field) {
    var nombre = $('#hot_direccion').val();
    if (/[^a-z0-9_ .,]/gi.test(nombre)) {
        alert("No puede contener caracteres especiales");
        field.value = '';
    } else {
        var pruebapuntos = CheckForRepeat(nombre, ".");
        var pruebacoma = CheckForRepeat(nombre, ",");
        if ((pruebacoma == 1) || (pruebapuntos == 1)) {
            alert("No puedes poner 2 o mas comas o puntos de forma consecutiva");
            field.value = '';
        }
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





function checklargo(field, numero) {
    if (field.value != '') {
        if (field.value < 0) {
            alert("No puedes colocar numeros negativos");
            field.value = '';
        }
        if (field.value > numero) {
            alert("No puedes exceder los " + numero.toString().length + " digitos");
            field.value = '';
        }
    }
}



