<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Inicio.aspx.vb" Inherits="TablerosV2.Inicio" %>

<%@ Register src="Controles/ctlSalir.ascx" tagname="ctlSalir" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no"/>
    <title>Inicio</title>
    <link rel="stylesheet" href="css/generales.css" />
    <link rel="stylesheet" href="Bootstrap/css/bootstrap.min.css"/>
    <script>


        function send_whatsapp() {

            document.querySelector('#send_message').addEventListener('click', function () {

                var url = "https://web.whatsapp.com://send?text="
                var message = document.querySelector('#mensaje').value;
                window.open(url + encodeURIComponent(message));

            });

        };

    </script>
    <script src="Bootstrap/js/jquery-2.1.4.min.js"></script>
    <script src="Bootstrap/js/bootstrap.min.js"></script>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <style type="text/css">
        .navbar-default .navbar-nav > li > a, 
        .navbar-default .navbar-nav > .open > a, 
        .navbar-default .navbar-nav > .active > a {
            color: #fff;
            box-shadow: none;
        }
        .navbar-default .navbar-nav > li:hover, .navbar-default .navbar-nav > li > a:hover, .navbar-default .navbar-nav > li:focus, .navbar-default .navbar-nav > li > a:focus {
            color: #fff;
            font-weight: bold;
        }
        .navbar-default .navbar-nav > .open > a, 
        .navbar-default .navbar-nav > .open > a:hover, 
        .navbar-default .navbar-nav > .open > a:focus
        {
            background-image: none;
            background-color: transparent;
            color: #fff;
        }
        .dropdown-menu {
            background-color: #4972a5;
            border: none;
        }
        .dropdown-menu > li > a:hover, .dropdown-menu > li > a:focus {
            color: #6296D5;
            background-color: #162951;
            background-image: none;
        }
        .dropdown-menu > li > a {
            color: #fff;
        }
        .navbar-default .navbar-nav .open .dropdown-menu > li > a {
            color: #fff;
        }
        .navbar-default .navbar-nav .open .dropdown-menu > li > a:hover, 
        .navbar-default .navbar-nav .open .dropdown-menu > li > a:focus {
            color: #6296D5;
            background-color: #162951;
            background-image: none;
        }
        .navbar-default .navbar-brand, .navbar-default .navbar-brand:hover, .navbar-default .navbar-brand:focus {
            color: #fff;
        }
        .navbar-default .navbar-collapse, .navbar-default .navbar-form {
            border: none;
        }
        .navbar-collapse {
            border-top: none;
            box-shadow: none;
        }
                        
        @media only screen and (min-width:768px) {
            body {
                padding-top: 60px;
                padding-bottom: 40px;
            }

            .sidebar-nav {
                padding: 9px 0;
            }

            .dropdown-menu .sub-menu {
                left: 100%;
                position: absolute;
                top: 0;
                visibility: hidden;
                margin-top: -1px;
            }

            .dropdown-menu li:hover .sub-menu {
                visibility: visible;
            }

            .dropdown:hover .dropdown-menu {
                display: block;
            }

            .nav-tabs .dropdown-menu, .nav-pills .dropdown-menu, .navbar .dropdown-menu {
                margin-top: 0;
            }

            .navbar .sub-menu:before {
                border-bottom: 7px solid transparent;
                border-left: none;
                border-right: 7px solid rgba(0, 0, 0, 0.2);
                border-top: 7px solid transparent;
                left: -7px;
                top: 10px;
            }
            .navbar .sub-menu:after {
                border-top: 6px solid transparent;
                border-left: none;
                border-right: 6px solid #fff;
                border-bottom: 6px solid transparent;
                /*left: 10px;*/
                top: 11px;
                left: -6px;
            }
        }
        @media only screen and (min-width:992px) {
            body {
                background: url(img/plecas.png) no-repeat center center fixed;
                background-size: cover;
            }
        }
        @media only screen and (max-width:991px) {
            body {
                background: url(img/plecas.png) no-repeat center center fixed;
                background-size: contain;
            }
        }
        
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row">
                <div class="col-md-12 col-lg-12">
                    <asp:Image runat="server" ID="ImgEnca1" ImageUrl="~/img/agencialogoheader.png" />
                </div>
            </div>
            <uc1:ctlSalir ID="ctlSalir1" runat="server" />
            <div class="row">
                <div class="col-md-12 col-lg-12">
                    <nav class="navbar navbar-default" role="navigation" style="background-color: #233E5F; background-image: none;">
                        <div class="container-fluid">
                            <!-- Brand and toggle get grouped for better mobile display -->
                            <div class="navbar-header">
                                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
                                    <span class="sr-only">Toggle navigation</span>
                                    <span class="icon-bar"></span>
                                    <span class="icon-bar"></span>
                                    <span class="icon-bar"></span>
                                </button>
                                <a class="navbar-brand" href="#">Tableros</a>
<%--                                <a href="https://web.whatsapp.com://send?text=Hola Mundo" target="_blank"  style="font-size:20px;padding:5px 12px;border-radius:5px;background-color:#189D0E;color:white;text-shadow:none;"> ›› Mensaje de WhatsApp </a>
                                 --%>
                            </div>
                            <!-- Collect the nav links, forms, and other content for toggling -->
                            <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                                <ul class="nav navbar-nav" style="float: none;">
                                    <li class="dropdown">
                                        <a href="#" class="dropdown-toggle" data-toggle="dropdown" style="color: #233E5F; text-shadow: none;">Oculto <b class="caret"></b></a>
                                        <ul class="dropdown-menu" runat="server" id="ulOculto">
                                        </ul>
                                    </li>
                                    <asp:Literal ID="LiteralNavigationBar" runat="server"></asp:Literal>
                               <%--     <li><a href='http://www.google.com' target="_blank">Lavado</a></li>   --%>
                                </ul>
                            </div>
                            <!-- /.navbar-collapse -->
                    
                               
                        </div>
                        <!-- /.container-fluid -->
                    </nav>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
