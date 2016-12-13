function Cuadro(f1, f2) {
    var aFecha1 = f1.split(' ');
    var aFecha2 = f2.split(' ');
    var aFecha3 = aFecha1[0].split('-');
    var aFecha4 = aFecha2[0].split('-');
    var fFecha1 = Date.UTC(aFecha3[0], aFecha3[1] - 1, aFecha3[2]);
    var fFecha2 = Date.UTC(aFecha4[0], aFecha4[1] - 1, aFecha4[2]);
    var dif = fFecha2 - fFecha1;
    var dias = Math.floor(dif / (1000 * 60 * 60 * 24));
    var i;
    var toView = '';
    for (i = 1; i <= dias; i++) {

        toView += '<div class="timeline-item timeline-item-bordered">';
        toView += '<div class="timeline-entry rounded">';
        toView += '<span class="size-14" style="text-transform: none"> Dia: </span>';
        toView += '<span class="size=13">';
        toView += (i);
        toView += '</span>';
        toView += '<div class="timeline-vline">';
        toView += '</div>';
        toView += '</div>';
        toView += '<h2 class="uppercase">';
        toView += '</h2>';
        toView += '<div class="fancy-form">';
        toView += '<textarea rows="7" id="area" class="form-control word-count" data-maxlength="200" data-info="textarea-words-info" placeholder="Escribe aqui...">';
        toView += '</textarea>';
        toView += '<span class="fancy-hint size-11 text-muted">';
        toView += '<span class="pull-right">';
        toView += '</span>';
        toView += '</span>';
        toView += '</div>';
        toView += '</div>';
        toView += '<div class="text-right">';
        toView += '<form id="form1" name="form1">';
        toView += '<button id="boton' + i + '" type="button" name="este" class="btn btn-primary">';
        toView += 'Modificar';
        toView += '</button> ';
        toView += '<button id="botons' + i + '" type="button" name="este1" class="btn btn-primary">';
        toView += 'Eliminar';
        toView += '</button> ';
        toView += '<button id="botun' + i + '" type="button" name="este2" class="btn btn-primary">';
        toView += 'Guardar';
        toView += '</button> ';
        toView += '</form>';
        toView += '</div>';
    }

    $('#dondepego').empty();
    $('#dondepego').append(toView);
}






