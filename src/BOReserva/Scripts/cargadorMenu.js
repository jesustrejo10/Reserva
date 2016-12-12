jQuery(document).ready(function () {

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

                    $("#contenido").empty()
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


    $("#m08AgregarAutomovil").click(function (e) {
        e.preventDefault();
        var url = '/gestion_automoviles/M08_AgregarAutomovil';
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
    $("#m08VisualizarAutomoviles").click(function (e) {
        e.preventDefault();
        var url = '/gestion_automoviles/M08_VisualizarAutomoviles';
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
    $("#editarComida").click(function (e) {
        //M06_EditarComida
        e.preventDefault();
        var url = '/gestion_comida_vuelo/M06_EditarComida';
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
    //FIN M06_Gestion_Comida



    $("#crearhotel").click(function (e) {
        e.preventDefault();
        var url = '/gestion_hoteles/M09_GestionHoteles_Crear';
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
    $("#modificarhotel").click(function (e) {
        e.preventDefault();
        var url = '/gestion_hoteles/M09_GestionHoteles_ModificarHotel';
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

    $("#consultarOferta").click(function (e) {});
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
    $("#m13VisualizarRol").click(function (e) {
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

        $("#consultarPaquete").click(function (e) {
            e.preventDefault();
            var url = '/gestion_ofertas/M11_ConsultarPaquete';

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

        //Fin M11
        });
