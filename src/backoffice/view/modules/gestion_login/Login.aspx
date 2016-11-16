<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="backoffice.view.modules.gestion_login.Login" %>

<!DOCTYPE html>
<html>
<head>
  <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <title>Reserva | Iniciar Sesión</title>
  <!-- Tell the browser to be responsive to screen width -->
  <meta content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" name="viewport">
  <!-- Bootstrap 3.3.6 -->
  <link rel="stylesheet" href="../../bootstrap/css/bootstrap.min.css">
  <!-- Font Awesome -->
  <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.5.0/css/font-awesome.min.css">
  <!-- Ionicons -->
  <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/ionicons/2.0.1/css/ionicons.min.css">
  <!-- Theme style -->
  <link rel="stylesheet" href="../../dist/css/AdminLTE.min.css">
  <!-- iCheck -->
  <link rel="stylesheet" href="../../plugins/iCheck/square/blue.css">

  <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
  <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
  <!--[if lt IE 9]>
  <script src="https://oss.maxcdn.com/html5shiv/3.7.3/html5shiv.min.js"></script>
  <script src="https://oss.maxcdn.com/respond/1.4.2/respond.min.js"></script>
  <![endif]-->
</head>
<body class="hold-transition login-page">
<div class="login-box">
  <div class="login-logo">
    <img src="../../dist/img/logo_small_50.png" alt="Logo Reserva" /><a href="../../index2.html"><b>Admin</b>Reserva</a>
  </div>
  <!-- /.login-logo -->
  <div class="login-box-body">

      <form id="form1" runat="server">
    <p class="login-box-msg">Iniciar Sesión</p>
          
          <div class="box-header">
              <asp:Label ID="Label1" runat="server" class="box-title" Text="Usuario o contraseña invalido" ForeColor ="red"></asp:Label><br>
          </div>

      <div class="form-group has-feedback">
          <asp:TextBox ID="TextBox1" runat="server" class="form-control" placeholder="Email">Correo</asp:TextBox>
        <span class="glyphicon glyphicon-envelope form-control-feedback"></span>
      </div>
      <div class="form-group has-feedback">
         <asp:TextBox ID="TextBox2" runat="server" class="form-control" placeholder="Password">Contraseña</asp:TextBox>
        <span class="glyphicon glyphicon-lock form-control-feedback"></span>
      </div>
      <div class="row">
        <div class="col-xs-8">
            <a  href="RecuperarPassword.aspx">¿Olvidaste tu contraseña?</a><br><br>
        </div>
         
        <!-- /.col -->
        <div class="col-xs-12">
          <asp:Button ID="Button1" runat="server" class="btn btn-primary btn-block btn-flat" Text="Iniciar" />
        </div>
        <!-- /.col -->
      </div>
          
        
          
      </form>

    

    

  </div>
  <!-- /.login-box-body -->
</div>
<!-- /.login-box -->

<!-- jQuery 2.2.3 -->
<script src="../../plugins/jQuery/jquery-2.2.3.min.js"></script>
<!-- Bootstrap 3.3.6 -->
<script src="../../bootstrap/js/bootstrap.min.js"></script>
<!-- iCheck -->
<script src="../../plugins/iCheck/icheck.min.js"></script>
<script>
  $(function () {
    $('input').iCheck({
      checkboxClass: 'icheckbox_square-blue',
      radioClass: 'iradio_square-blue',
      increaseArea: '20%' // optional
    });
  });
</script>
</body>
</html>