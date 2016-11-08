<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="frontoffice.view.index" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">
    <title>Reserva - Vuelos y mucho más</title>
    <link rel="shortcut icon" type="image/png" href="img/favicon.ico" />

    <!-- Bootstrap Core CSS -->
    <link href="css/bootstapcss/bootstrap.min.css" rel="stylesheet">

    <!-- Theme CSS -->
    <link href="css/custom.min.css" rel="stylesheet">
    <link href="css/searchtab.min.css" rel="stylesheet">

    <!-- Custom Fonts -->
    <link href="https://fonts.googleapis.com/css?family=Roboto" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css?family=Roboto|Roboto+Slab" rel="stylesheet">
    <link href="css/font-awesome.min.css" rel="stylesheet">

</head>
<body id="page-top" class="index">
    <!-- Navigation -->
    <nav id="mainNav" class="navbar navbar-default navbar-fixed-top navbar-custom">
        <div class="container">
            <!-- Brand and toggle get grouped for better mobile display -->
            <div class="navbar-header page-scroll">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
                     <i class="fa fa-bars"></i>
                </button>
                <a class="logo" href="#page-top">
                    <img src="img/logo_big_50.png" class="img-responsive" alt="" style="margin-top: -10px;">
                </a>
            </div>
            <!-- Collect the nav links, forms, and other content for toggling -->
            <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                <ul class="nav navbar-nav navbar-right">

                    <li class="page-scroll">
                        <a class="btn-link" style="margin-top:15px;">Home</a>
                    </li>
                    <li class="page-scroll">
                        <a class="btn-link" style="margin-top:15px;">About</a>
                    </li>
                    <li class="page-scroll">
                        <a class="btn-link " style="margin-top:15px;">Contact</a>
                    </li>
                </ul>
            </div>
            <!-- /.navbar-collapse -->
        </div>
        <!-- /.container-fluid -->
    </nav>


    <!-- MAIN CONTENT -->
    <section id="portfolio row">
        <div class="container">
            <div class="row">
                <div class="col-lg-12 text-center" style="padding-top: 20px;">

                </div>
            </div>
            <div class="row">



                <div class="container">
                    <div class="row">
                        <div class="col-md-12 bhoechie-tab-container">

                            <!-- PENTANAS DE NAVEGACION-->
                            <div id="search-nav" class="col-lg-3 col-md-3 col-sm-3 col-xs-3 bhoechie-tab-menu">
                                <div class="list-group">
                                    <a href="#" class="list-group-item active text-center">
                                        <i class="fa fa-plane" aria-hidden="true"></i><br />Vuelos
                                    </a>
                                    <a href="#" class="list-group-item text-center">
                                        <i class="fa fa-ship" aria-hidden="true"></i><br />Cruceros
                                    </a>
                                    <a href="#" class="list-group-item text-center">
                                        <i class="fa fa-building" aria-hidden="true"></i><br />Hoteles
                                    </a>
                                    <a href="#" class="list-group-item text-center">
                                        <i class="fa fa-cutlery" aria-hidden="true"></i><br />Restaurantes
                                    </a>
                                    <a href="#" class="list-group-item text-center">
                                        <i class="fa fa-car" aria-hidden="true"></i><br />Carros
                                    </a>
                                </div>
                            </div>

                            <!-- SECCIONES INTERNAS -->

                            <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9 bhoechie-tab">
                                <!-- flight section -->
                                <div class="bhoechie-tab-content active">

                                </div>
                                <!-- train section -->
                                <div class="bhoechie-tab-content">

                                </div>

                                <!-- hotel search -->
                                <div class="bhoechie-tab-content">

                                </div>

                                <!-- restaurant search -->
                                <div class="bhoechie-tab-content">
                                    <form id="rest" class="form-inline" style="min-height:500px;">
                                        <div class="col-lg-12">
                                            <center> <h3>¡Reserva en los mejores restaurantes de tu ciudad!</h3></center>
                                        </div>
                                        <div class="col-lg-12">
                                            <center>
                                                <div class="input-group top_separate" style="width: 100%;">
                                                    <div class="form-group-md">
                                                        <select class="form-control rest_sel" data-selected="" style="width:20%;">
                                                            <option value="0">Bucar por:</option>
                                                            <option value="1">Ciudad</option>
                                                            <option value="2">Restaurante</option>
                                                        </select>
                                                        <input id="search_rest" class="form-control rest_inp" aria-label="" placeholder="¿Dónde quieres comer?" style="width:80%;"> 
                                                    </div>
                                                </div>
                                            </center>
                                        </div>
                                        <div class="col-lg-12">
                                            <div style="text-align:center;" class="">
                                                <button id="btn_rest" type="submit" class="btn btn_search">
                                                    <span>Buscar</span>
                                                </button>
                                            </div>
                                        </div>

                                    </form>
                                
                                </div>
                                <!-- car search-->
                                <div class="bhoechie-tab-content">

                                </div>
                            </div>
                            <div class="clear"></div>
                        </div>
                    </div>
                </div>

            </div>

        </div>
    </section>


    <!-- Footer -->
    <footer class="text-center">
        <div class="footer-above">
            <div class="container">
                <div class="row">

                </div>
            </div>
        </div>
        <div class="footer-below">
            <div class="container">
                <div class="row">
                    <div class="col-lg-12">
                        Copyright &copy; Reserva 2016
                    </div>
                </div>
            </div>
        </div>
    </footer>
    <!-- Scroll to Top Button (Only visible on small and extra-small screen sizes) -->
    <div class="scroll-top page-scroll hidden-sm hidden-xs hidden-lg hidden-md">
        <a class="btn btn-primary" href="#page-top">
            <i class="fa fa-chevron-up"></i>
        </a>
    </div>

    <!-- jQuery -->
    <script src="js/jquery.min.js"></script>
    <!-- Bootstrap Core JavaScript -->
    <script src="js/bootstrap_js/bootstrap.min.js"></script>
    <!-- Plugin JavaScript -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery-easing/1.3/jquery.easing.min.js"></script>
    <!-- Contact Form JavaScript -->
    <script src="js/jqBootstrapValidation.js"></script>
    <!-- Theme JavaScript -->
    <script src="js/freelancer.min.js"></script>
    <script>
        $(document).ready(function () {
            $("div.bhoechie-tab-menu>div.list-group>a").click(function (e) {
                e.preventDefault();
                $(this).siblings('a.active').removeClass("active");
                $(this).addClass("active");
                var index = $(this).index();
                $("div.bhoechie-tab>div.bhoechie-tab-content").removeClass("active");
                $("div.bhoechie-tab>div.bhoechie-tab-content").eq(index).addClass("active");
            });
        });
    </script>
</body>
</html>
