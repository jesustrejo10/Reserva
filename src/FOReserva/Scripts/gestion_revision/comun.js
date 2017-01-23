function agregarCargando(id) {
    $(id).append($('<div id="preloader" class="preloader" style="position: absolute;background: rgba(2, 2, 2, 0.16);"><div class="inner"><span class="loader"></span></div></div>'))
}

function borrarCargando(id) {
    $(id).children(".preloader").remove();
}
