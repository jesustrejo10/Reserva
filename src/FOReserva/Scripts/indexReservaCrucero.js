$("#pasajero").show();
$("#pasajero1").hide();
$("#pasajero2").hide();
$("#pasajero3").hide();
        
function  cambiar() {
    var v1 = document.getElementById("pasajeros");
    var valor1 = v1.options[v1.selectedIndex].value;
    console.log(valor1);
    if (valor1=='1'){     console.log(valor1);
        $("#edad1").show();
        $("#pasajero").show();
        $("#pasajero1").hide();
        $("#pasajero2").hide();
        $("#pasajero3").hide();
        $("#edad2").hide();
        $("#edad3").hide();
        $("#edad4").hide()}
    if (valor1=='2') {
        $("#pasajero").show();
        $("#pasajero1").show();
        $("#pasajero2").hide();
        $("#pasajero3").hide();
        $("#edad3").hide();
        $("#edad4").hide();
        $("#edad2").show();}
    if (valor1=='3'){
        $("#pasajero").show();
        $("#pasajero1").show();
        $("#pasajero2").show();
        $("#pasajero3").hide();
        $("#edad4").hide();
        $("#edad2").show();
        $("#edad3").show();}
    if (valor1=='4'){
        $("#pasajero").show();
        $("#pasajero1").show();
        $("#pasajero2").show();
        $("#pasajero3").show();
        $("#edad2").show();
        $("#edad3").show();
        $("#edad4").show();}
}
