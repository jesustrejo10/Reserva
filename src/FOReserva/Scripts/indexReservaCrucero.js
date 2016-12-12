
function  cambiar() {
    var v1 = document.getElementById("pasajeros");
    var valor1 = v1.options[v1.selectedIndex].value;
    console.log(valor1);
    if (valor1=='1'){     console.log(valor1);
        $("#edad1").show();
        $("#edad2").hide();
        $("#edad3").hide();
        $("#edad4").hide()}
    if (valor1=='2') {
        $("#edad3").hide();
        $("#edad4").hide();
        $("#edad2").show();}
    if (valor1=='3'){
        $("#edad4").hide();
        $("#edad2").show();
        $("#edad3").show();}
    if (valor1=='4'){
        $("#edad2").show();
        $("#edad3").show();
        $("#edad4").show();}
}