jQuery(document).ready(function () {

    // INICIO DE AVIONES
    $("#gestionAviones").click(function (e) {
        e.preventDefault();
        var url = '/gestion_aviones/M02_GestionAviones';
        var method = 'GET';
        var data = '';
        $.ajax(
            {
                url: url,
                type: method,
                data: data,
                success: function (data, textStatus, jqXHR) {
                    $("#contenido").empty();
                    $("#contenido").append(data);
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert(errorThrown);
                }
            });
    });
    $("#m02_agregaravion").click(function (e) {
        e.preventDefault();
        var url = '/gestion_aviones/M02_AgregarAvion';
        var method = 'GET';
        var data = '';
        $.ajax(
           {
               url: url,
               type: method,
               data: data,
               success: function (data, textStatus, jqXHR) {
                   $("#contenido").empty();
                   $("#contenido").append(data);
               },
               error: function (jqXHR, textStatus, errorThrown) {
                   alert(errorThrown);
               }

           }); 
    });
    
    $("#m02_VisualizarAvion").click(function (e) {
        e.preventDefault();
        var url = '/gestion_aviones/M02_VisualizarAviones';
        var method = 'GET';
        var data = '';
        $.ajax(
            {
                url: url,
                type: method,
                data: data,
                success: function (data, textStatus, jqXHR) {
                    $("#contenido").empty();
                    $("#contenido").append(data);
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert(errorThrown);
                }
            });

    });

    //FIN DE AVIONES

    //INICIO DE RUTAS
    $("#m03AgregarRuta").click(function (e) {
        e.preventDefault();
        var url = '/gestion_ruta_comercial/AgregarRutasComerciales';
        var method = 'GET';
        var data = '';
        $.ajax(
            {
                url: url,
                type: method,
                data: data,
                success: function (data, textStatus, jqXHR) {
                    $("#contenido").empty();
                    $("#contenido").append(data);
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert(errorThrown);
                }
            });
    });

    $("#m03VisualizarRutas").click(function (e) {
        e.preventDefault();
        var url = '/gestion_ruta_comercial/VisualizarRutasComerciales';
        var method = 'GET';
        var data = '';
        $.ajax(
            {
                url: url,
                type: method,
                data: data,
                success: function (data, textStatus, jqXHR) {
                    $("#contenido").empty();
                    $("#contenido").append(data);
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert(errorThrown);
                }
            });
    });
    //FIN DE RUTAS
 
    //INICIO AUTOMOVILES
 
    $("#m08AgregarAutomovil").click(function (e) {
        e.preventDefault();
        var url = '/gestion_automoviles/M08_AgregarAutomovil';
        var method = 'GET';
        var data = '';
        $.ajax(

            alert("Se esta procesando tu solicitud, por favor espere"),
 
            {
                url: url,
                type: method,
                data: data,
                success: function (data, textStatus, jqXHR) {
                    $("#contenido").empty();
                    $("#contenido").append(data);
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert(errorThrown);
                }
            });
    });

    $("#m08VisualizarAutomoviles").click(function (e) {
        e.preventDefault();

        var url = '/gestion_automoviles/M08_VisualizarAutomoviles';
        var method = 'GET';
        var data = '';
        $.ajax(
        alert("Se esta procesando tu solicitud, por favor espere"),
            {
                url: url,
                type: method,
                data: data,
                success: function (data, textStatus, jqXHR) {
                    $("#contenido").empty();
                    $("#contenido").append(data);
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert(errorThrown);
                }
            });
    });
    //FIN DE AUTOMOVILES

    //INICIO M06_Gestion_Comida
    $("#gestionComida").click(function (e) {
        //M06_AgregarComida
        e.preventDefault();
        var url = '/gestion_comida_vuelo/M06_AgregarComida';
        var method = 'GET';
        var data = '';
        $.ajax(
            {
                url: url,
                type: method,
                data: data,
                success: function (data, textStatus, jqXHR) {

                    $("#contenido").empty();
                    $("#contenido").append(data);
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert(errorThrown);
                }
            });
    });

    $("#visualizarVuelosComidas").click(function (e) {
        //M06_VisualizarVuelosComidas
        e.preventDefault();
        var url = '/gestion_comida_vuelo/M06_VisualizarVuelosComidas';
        var method = 'GET';
        var data = '';
        $.ajax(
            {
                url: url,
                type: method,
                data: data,
                success: function (data, textStatus, jqXHR) {
                    $("#contenido").empty();
                    $("#contenido").append(data);
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert(errorThrown);
                }
            });
    });

    $("#gestionComidaVuelo").click(function (e) {
        //M06_AgregarPorVuelo
        e.preventDefault();
        var url = '/gestion_comida_vuelo/M06_AgregarPorVuelo';
        var method = 'GET';
        var data = '';
        $.ajax(
            {
                url: url,
                type: method,
                data: data,
                success: function (data, textStatus, jqXHR) {

                    $("#contenido").empty();
                    $("#contenido").append(data);
                }
            });
    });
    $("#visualizarComidas").click(function (e) {
        //M06_AgregarPorVuelo
        e.preventDefault();
        var url = '/gestion_comida_vuelo/M06_VisualizarComidas';
        var method = 'GET';
        var data = '';

        $.ajax(
            {
                url: url,
                type: method,
                data: data,
                success: function (data, textStatus, jqXHR) {

                    $("#contenido").empty();
                    $("#contenido").append(data);
                }
            });
    });
    //FIN M06_Gestion_Comida


    // Inicio M09_Gestion_Hoteles_Por_Ciudad
    $("#M09_crear_hotel").click(function (e) {
        e.preventDefault();
        var url = '/gestion_hoteles/M09_AgregarHotel';
        var method = 'GET';
        var data = '';
        $.ajax(
            {
                url: url,
                type: method,
                data: data,
                success: function (data, textStatus, jqXHR) {

                    $("#contenido").empty();
                    $("#contenido").append(data);
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert(errorThrown);
                }
            });
    });

    $("#M09_consultar_hoteles").click(function (e) {
        e.preventDefault();
        var url = '/gestion_hoteles/M09_GestionHoteles_Visualizar';
        var method = 'GET';
        var data = '';

        $.ajax(
            {
                url: url,
                type: method,
                data: data,
                success: function (data, textStatus, jqXHR) {

                    $("#contenido").empty();
                    $("#contenido").append(data);
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert(errorThrown);
                }
            });

    });
    $("#consultarhotel").click(function (e) {
        e.preventDefault();
        var url = '/gestion_hoteles/M09_GestionHoteles_Visualizar';
        var method = 'GET';
        var data = '';

        $.ajax(
            {
                url: url,
                type: method,
                data: data,
                success: function (data, textStatus, jqXHR) {

                    $("#contenido").empty();
                    $("#contenido").append(data);
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert(errorThrown);
                }
            });

    });
    // FIN DE HOTELES

    /* INICIO M10 RESTAURANTES BO */
    $("#verRestaurantes").click(function (e) {
        e.preventDefault();
        var url = '/gestion_restaurantes/M10_GestionRestaurantes_Ver';
        var method = 'GET';
        var data = '';

        $.ajax(
            {
                url: url,
                type: method,
                data: data,
                success: function (data, textStatus, jqXHR) {

                    $("#contenido").empty();
                    $("#contenido").append(data);
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert(errorThrown);
                }
            });
    });
    $("#agregarRestaurantes").click(function (e) {
        e.preventDefault();
        var url = '/gestion_restaurantes/M10_GestionRestaurantes_Agregar';
        var method = 'GET';
        var data = '';

        $.ajax(
            {
                url: url,
                type: method,
                data: data,
                success: function (data, textStatus, jqXHR) {

                    $("#contenido").empty();
                    $("#contenido").append(data);
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert(errorThrown);
                }
            });
    });
    /* FIN M10 RESTAURANTES BO */

    //M05 Boletos y checkin

    $("#m05VerReserva").click(function (e) {
        e.preventDefault();
        var url = '/gestion_boletos/M05_VerReserva';
        var method = 'GET';
        var data = '';

        $.ajax(
            {
                url: url,
                type: method,
                data: data,
                success: function (data, textStatus, jqXHR) {

                    $("#contenido").empty();
                    $("#contenido").append(data);
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert(errorThrown);
                }
            });
    });

    $("#m05VisualizarBoletos").click(function (e) {
        e.preventDefault();
        var url = '/gestion_boletos/M05_VisualizarBoletos';
        var method = 'GET';
        var data = '';

        $.ajax(
            {
                url: url,
                type: method,
                data: data,
                success: function (data, textStatus, jqXHR) {

                    $("#contenido").empty();
                    $("#contenido").append(data);
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert(errorThrown);
                }
            });
    });

    $("#m05CheckIn").click(function (e) {
        e.preventDefault();
        var url = '/gestion_check_in/M05_CheckIn';
        var method = 'GET';
        var data = '';

        $.ajax(
            {
                url: url,
                type: method,
                data: data,
                success: function (data, textStatus, jqXHR) {

                    $("#contenido").empty();
                    $("#contenido").append(data);
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert(errorThrown);
                }
            });
    });

    $("#m05RegistroEquipaje").click(function (e) {
    e.preventDefault();
    var url = '/gestion_check_in/M05_RegistroEquipaje';
    var method = 'GET';
    var data = '';

    $.ajax(
        {
            url: url,
            type: method,
            data: data,
            success: function (data, textStatus, jqXHR) {

                $("#contenido").empty();
                $("#contenido").append(data);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                alert(errorThrown);
            }
        });

      });
    //FIN M05

    //M13 ROLES
    $("#m13VisualizarRol").click(function (e) {
        e.preventDefault();
        var url = '/gestion_roles/M13_VisualizarRol';
        var method = 'GET';
        var data = '';

        $.ajax(
            {
                url: url,
                type: method,
                data: data,
                success: function (data, textStatus, jqXHR) {

                    $("#contenido").empty();
                    $("#contenido").append(data);
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert(errorThrown);
                }
            });
    });
    //M13 ROLES
    $("#m13ModificarRol").click(function (e) {
        e.preventDefault();
        var url = '/gestion_roles/M13_ModificarRol';
        var method = 'GET';
        var data = '';

        $.ajax(
            {
                url: url,
                type: method,
                data: data,
                success: function (data, textStatus, jqXHR) {

                    $("#contenido").empty();
                    $("#contenido").append(data);
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert(errorThrown);
                }
            });
    });
    $("#m13AgregarRol").click(function (e) {
        e.preventDefault();
        var url = '/gestion_roles/M13_AgregarRol';
        var method = 'GET';
        var data = '';

        $.ajax(
            {
                url: url,
                type: method,
                data: data,
                success: function (data, textStatus, jqXHR) {

                    $("#contenido").empty();
                    $("#contenido").append(data);
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert(errorThrown);
                }
            });
    });
    //FIN M13 ROLES

    // Comienzo M12 Usuarios
    $("#indexUsuarios").click(function (e) {
        e.preventDefault();
        var url = '/gestion_usuarios/M12_Index';
        var method = 'GET';
        var data = '';
        $.ajax(
            {
                url: url,
                type: method,
                data: data,
                success: function (data, textStatus, jqXHR) {
                    $("#contenido").empty();
                    $("#contenido").append(data);
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert(errorThrown);
                }
            });
    });

    $("#agregarUsuarios").click(function (e) {
        e.preventDefault();
        var url = '/gestion_usuarios/M12_AgregarUsuario';
        var method = 'GET';
        var data = '';

        $.ajax(
            {
                url: url,
                type: method,
                data: data,
                success: function (data, textStatus, jqXHR) {

                    $("#contenido").empty();
                    $("#contenido").append(data);
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert(errorThrown);
                }
            });

    });

    //Fin M12 Usuarios
    //Inicio M04 Vuelos
    $("#m04_crearvuelo").click(function (e) {
        e.preventDefault();
        var url = '/gestion_vuelo/M04_GestionVuelo_Crear';
        var method = 'GET';
        var data = '';
        $.ajax(
           {
               url: url,
               type: method,
               data: data,
               success: function (data, textStatus, jqXHR) {
                   $("#contenido").empty();
                   $("#contenido").append(data);
               },
               error: function (jqXHR, textStatus, errorThrown) {
                   alert(errorThrown);
               }
           });
    });

    $("#m04_visualizarvuelo").click(function (e) {
        e.preventDefault();
        var url = '/gestion_vuelo/M04_GestionVuelo_Visualizar';
        var method = 'GET';
        var data = '';
        $.ajax(
            {
                url: url,
                type: method,
                data: data,
                success: function (data, textStatus, jqXHR) {
                    $("#contenido").empty();
                    $("#contenido").append(data);
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert(errorThrown);
                }
            });

    });


    //Fin M04 Vuelos



    //M11 Gestion Ofertas y Paquetes
    $("#agregarOferta").unbind('click');
    $("#agregarOferta").click(function (e) {
        e.preventDefault();
        var url = '/gestion_ofertas/M11_AgregarOferta';
        var method = 'GET';
        $.ajax(
            {
                url: url,
                type: method,
                success: function (data, textStatus, jqXHR) {

                    $("#contenido").empty();
                    $("#contenido").append(data);
                    getPaquetesFromDB();
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert(errorThrown);
                }
            });
    });


    $("#modificarOferta").click(function (e) {
        e.preventDefault();
        var url = '/gestion_ofertas/M11_ModificarOferta';
        var method = 'GET';
        var data = '';

        $.ajax(
            {
                url: url,
                type: method,
                data: data,
                success: function (data, textStatus, jqXHR) {

                    $("#contenido").empty();
                    $("#contenido").append(data);
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert(errorThrown);
                }
            });
    });

    $("#consultarOferta").click(function (e) {
        e.preventDefault();
        var url = '/gestion_ofertas/M11_VisualizarOferta';
        var method = 'GET';
        var data = '';

        $.ajax(
            {
                url: url,
                type: method,
                data: data,
                success: function (data, textStatus, jqXHR) {

                    $("#contenido").empty();
                    $("#contenido").append(data);
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert(errorThrown);
                }
            });
    });

    $("#agregarPaquete").click(function (e) {
        e.preventDefault();
        var url = '/gestion_ofertas/M11_AgregarPaquete';
        var method = 'GET';
        var data = '';

        $.ajax(
            {
                url: url,
                type: method,
                data: data,
                success: function (data, textStatus, jqXHR) {

                    $("#contenido").empty();
                    $("#contenido").append(data);
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert(errorThrown);
                }
            });
    });

    $("#modificarPaquete").click(function (e) {
        e.preventDefault();
        var url = '/gestion_ofertas/M11_ModificarPaquete';
        var method = 'GET';
        var data = '';

        $.ajax(
            {
                url: url,
                type: method,
                data: data,
                success: function (data, textStatus, jqXHR) {

                    $("#contenido").empty();
                    $("#contenido").append(data);
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert(errorThrown);
                }
            });
    });

    $("#consultarPaquete").click(function (e) {
        e.preventDefault();
        var url = '/gestion_ofertas/M11_VisualizarPaquete';
        var method = 'GET';
        var data = '';

        $.ajax(
            {
                url: url,
                type: method,
                data: data,
                success: function (data, textStatus, jqXHR) {

                    $("#contenido").empty();
                    $("#contenido").append(data);
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert(errorThrown);
                }
            });
    });

    //Fin M11

    //Inicio Modulo 24 Cruceros
    $("#m24_agregarcrucero").click(function (e) {
        e.preventDefault();
        var url = '/gestion_cruceros/M24_GestionCruceros';
        var method = 'GET';
        var data = '';

        $.ajax(
            {
                url: url,
                type: method,
                data: data,
                success: function (data, textStatus, jqXHR) {

                    $("#contenido").empty();
                    $("#contenido").append(data);
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert(errorThrown);
                }
            });
    });

    $("#m24_listarcrucero").click(function (e) {
        e.preventDefault();
        var url = '/gestion_cruceros/M24_ListarCruceros';
        var method = 'GET';
        var data = '';

        $.ajax(
            {
                url: url,
                type: method,
                data: data,
                success: function (data, textStatus, jqXHR) {

                    $("#contenido").empty();
                    $("#contenido").append(data);
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert(errorThrown);
                }
            });
    });

    $("#m24_agregarcabina").click(function (e) {
        e.preventDefault();
        var url = '/gestion_cruceros/M24_AgregarCabinas';
        var method = 'GET';
        var data = '';
        console.log("x");
        $.ajax(
            {
                url: url,
                type: method,
                data: data,
                success: function (data, textStatus, jqXHR) {

                    $("#contenido").empty();
                    $("#contenido").append(data);
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert(errorThrown);
                }
            });
    });

    $("#m24_agregarcamarote").click(function (e) {
        e.preventDefault();
        var url = '/gestion_cruceros/M24_AgregarCamarote';
        var method = 'GET';
        var data = '';
        console.log("xjjj");
        $.ajax(
            {
                url: url,
                type: method,
                data: data,
                success: function (data, textStatus, jqXHR) {

                    $("#contenido").empty();
                    $("#contenido").append(data);
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert(errorThrown);
                }
            });
    });

    $("#m24_agregaritinerario").click(function (e) {
        e.preventDefault();
        var url = '/gestion_cruceros/M24_AgregarItinerario';
        var method = 'GET';
        var data = '';

        $.ajax(
            {
                url: url,
                type: method,
                data: data,
                success: function (data, textStatus, jqXHR) {

                    $("#contenido").empty();
                    $("#contenido").append(data);
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert(errorThrown);
                }
            });
    });

    $("#m24_listaritinerario").click(function (e) {
        e.preventDefault();
        var url = '/gestion_cruceros/M24_ListarItinerario';
        var method = 'GET';
        var data = '';

        $.ajax(
            {
                url: url,
                type: method,
                data: data,
                success: function (data, textStatus, jqXHR) {

                    $("#contenido").empty();
                    $("#contenido").append(data);
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    alert(errorThrown);
                }
            });
    });


    //Fin Modulo 24 Cruceros

});

//Inicio Modulo 24 Cruceros
$("#m24_agregarcrucero").click(function (e) {
    e.preventDefault();
    var url = '/gestion_cruceros/M24_GestionCruceros';
    var method = 'GET';
    var data = '';

    $.ajax(
        {
            url: url,
            type: method,
            data: data,
            success: function (data, textStatus, jqXHR) {

                $("#contenido").empty();
                $("#contenido").append(data);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                alert(errorThrown);
            }
        });
});

$("#m24_listarcrucero").click(function (e) {
    e.preventDefault();
    var url = '/gestion_cruceros/M24_ListarCruceros';
    var method = 'GET';
    var data = '';

    $.ajax(
        {
            url: url,
            type: method,
            data: data,
            success: function (data, textStatus, jqXHR) {

                $("#contenido").empty();
                $("#contenido").append(data);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                alert(errorThrown);
            }
        });
});

$("#m24_agregarcabina").click(function (e) {
    e.preventDefault();
    var url = '/gestion_cruceros/M24_AgregarCabinas';
    var method = 'GET';
    var data = '';
    console.log("x");
    $.ajax(
        {
            url: url,
            type: method,
            data: data,
            success: function (data, textStatus, jqXHR) {

                $("#contenido").empty();
                $("#contenido").append(data);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                alert(errorThrown);
            }
        });
});

$("#m24_agregarcamarote").click(function (e) {
    e.preventDefault();
    var url = '/gestion_cruceros/M24_AgregarCamarote';
    var method = 'GET';
    var data = '';
    console.log("xjjj");
    $.ajax(
        {
            url: url,
            type: method,
            data: data,
            success: function (data, textStatus, jqXHR) {

                $("#contenido").empty();
                $("#contenido").append(data);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                alert(errorThrown);
            }
        });
});

$("#m24_agregaritinerario").click(function (e) {
    e.preventDefault();
    var url = '/gestion_cruceros/M24_AgregarItinerario';
    var method = 'GET';
    var data = '';

    $.ajax(
        {
            url: url,
            type: method,
            data: data,
            success: function (data, textStatus, jqXHR) {

                $("#contenido").empty();
                $("#contenido").append(data);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                alert(errorThrown);
            }
        });
});

$("#m24_listaritinerario").click(function (e) {
    e.preventDefault();
    var url = '/gestion_cruceros/M24_ListarItinerario';
    var method = 'GET';
    var data = '';

    $.ajax(
        {
            url: url,
            type: method,
            data: data,
            success: function (data, textStatus, jqXHR) {

                $("#contenido").empty();
                $("#contenido").append(data);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                alert(errorThrown);
            }
        });
});


//Fin Modulo 24 Cruceros



