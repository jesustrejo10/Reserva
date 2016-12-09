jQuery(document).ready(function () {
    $('.boton').mouseenter(function () {
        var id = $(this).attr('id');
        $('#id_rest').val(id);
        console.log($('#id_rest').val());
    });
});
