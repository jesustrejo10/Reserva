
    //EVENTO PARA AGREGAR UN HOTEL
    $("#aceptarhotel").click(function (e) {
        console.log("hola!");
        e.preventDefault();
        var form = $("#formCrearHotel");
        $.ajax({
            url: "gestion_hoteles/crearhotel",
            data: form.serialize(),
            type: 'POST',
            success: function (data) {
                alert("Se guardo");
                $('#formCrearHotel')[0].reset();
            }
            , error: function (xhr, textStatus, exceptionThrown) {
                //muestro el texto del error
                alert(xhr.responseText);
            }
        });
    });


        //Dropdownlist Selectedchange event
   /* $("#Country").change(function () {
        console.log("hola!");
        $("#State").empty();
        console.log("hola!");
        $.ajax({
            type: 'POST',
            url: "gestion_hoteles/GetCiudades", // we are calling json method

            dataType: 'json',

            data: { pais: $("#Country").Text() },
            // here we are get value of selected country and passing same value
            //    as inputto json method GetStates.

            success: function (states) {
                // states contains the JSON formatted list
                // of states passed from the controller

                $.each(states, function (i, state) {
                    $("#State").append('<option value="' + state.Value + '">' +
                         state.Text + '</option>');
                    // here we are adding option for States

                });
            },
            error: function (ex) {
                alert('Failed to retrieve states.' + ex);
            }
        });
        return false;
    });

    /*$('#Country').change(function () {
        console.log("hola!");
            $.ajax({  
                type: "post",  
                url: "/gestion_hoteles/GetCiudades",  
                data: { pais: $('#Country').Text() },  
                datatype: "json",  
                traditional: true,  
                success: function (data) {  
                    var district = "<select id='State'>";  
                    district = district + '<option value="">--Select--</option>';  
                    for (var i = 0; i < data.length; i++)  
                    {  
                        district = district + '<option value=' + data[i].Value + '>' + data[i].Text + '</option>';  
                    }  
                    district = district + '</select>';  
                    $('#State').html(district);  
                }  
            });  
        });  
  

//Dropdownlist Selectedchange event
    $(function () {
        $("#Country").change(function () {
            console.log("hola!");
            $("#regionForm").sumbit();
            
        });
        $("#State").change(function () {
            $("#territoryForm").sumbit();
        });
    });*/