
function validarCampos()
{
    var nombreRestaurant = document.getElementById("Nombre").value;
    var direccionRestaurant = document.getElementById("Direccion").value;
    var telefonoRestaurant = document.getElementById("Telefono").value;
    var ciudadRestaurant = document.getElementById("ComboLugar").value;
    var horainiRestaurant = document.getElementById("ComboHoraIni").value;
    var horafinRestaurant = document.getElementById("ComboHoraFin").value;
 

  
    if (nombreRestaurant == "")
    {
        document.getElementById("Nombre").style.border = "1px solid red";
        document.getElementById("Nombre_Error").style.color = "red";
        document.getElementById("Nombre_Error").textContent = "Debe Ingresar Nombre del Restaurant";
   
       
    }
    else 
    { 
        document.getElementById("Nombre_Error").textContent = "";
        document.getElementById("Nombre").style.border = "";
    }

    if (direccionRestaurant == "")
    {
        document.getElementById("Direccion").style.border = "1px solid red";
        document.getElementById("Direccion_Error").style.color = "red";
        document.getElementById("Direccion_Error").textContent = "Debe Ingresar Direccion del Restaurant";
           
    }
    else
    {
        document.getElementById("Direccion_Error").textContent = "";
        document.getElementById("Direccion").style.border = "";
    }

    if (telefonoRestaurant == "")
    {
        document.getElementById("Telefono").style.border = "1px solid red";
        document.getElementById("Telefono_Error").style.color = "red";
        document.getElementById("Telefono_Error").textContent = "Debe Ingresar Telefono del Restaurant";
      
       
    }
    else
    {
        document.getElementById("Telefono_Error").textContent = "";
        document.getElementById("Telefono").style.border = "";
    }

    if (ciudadRestaurant == 0)
    {
        document.getElementById("ComboLugar").style.border = "1px solid red";
        document.getElementById("Ciudad_Error").style.color = "red";
        document.getElementById("Ciudad_Error").textContent = "Debe Seleccionar Ciudad del Restaurant";
       
       
    }
    else
    {
        document.getElementById("ComboLugar").style.border = "";
        document.getElementById("Ciudad_Error").textContent = "";
    }


    if (horainiRestaurant == "")
    {
        document.getElementById("ComboHoraIni").style.border = "1px solid red";
        document.getElementById("Hor_Ini_Error").style.color = "red";
        document.getElementById("Hor_Ini_Error").textContent = "Debe Seleccionar Hora Apertura del Restaurant";
      
        
    }
    else
    {
        document.getElementById("ComboHoraIni").style.border = "";
        document.getElementById("Hor_Ini_Error").textContent = "";
    }


    if (horafinRestaurant == "")
    {
        document.getElementById("ComboHoraFin").style.border = "1px solid red";
        document.getElementById("Hora_Fin_Error").style.color = "red";
        document.getElementById("Hora_Fin_Error").textContent = "Debe Seleccionar Hora de Cierre del Restaurant";
       
       
    }
    else
    {
        document.getElementById("ComboHoraFin").style.border = "";
        document.getElementById("Hora_Fin_Error").textContent = "";
    }

   
}

