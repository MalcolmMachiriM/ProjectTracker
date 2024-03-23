<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="ProjectTrackingApp.login" %>

<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="utf-8">

    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="">
    <meta name="author" content="ThemeBucket">
    <link rel="shortcut icon" href="images/favicon.html">

    <title>Login</title>

    <link href="../bs3/css/bootstrap.min.css" rel="stylesheet">
    <link href="../css/bootstrap-reset.css" rel="stylesheet">
    <link href="../font-awesome/css/font-awesome.css" rel="stylesheet" />

    <link href="../css/style.css" rel="stylesheet">
    <link href="../css/style-responsive.css" rel="stylesheet" />

    
</head>

  <body class="login-body">

    <div class="container">

      <form class="form-signin" runat="server">
        <h2 class="form-signin-heading">Project Tracker System</h2>
        <div class="login-wrap">
                            <div class="col-xs-12 text-center">
    <asp:Label ID="lblLoginError" runat="server" Font-Size="Small" style="font-size:15px;" ForeColor="Red"></asp:Label>
</div>
            <div class="user-login-info">
                <asp:TextBox ID="txtEmail" runat="server" placeholder="Email" class="form-control" style="color: black; font-weight: bold;"></asp:TextBox>
                <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" placeholder="Password" class="form-control" style="color: black; font-weight: bold;"></asp:TextBox>
            </div>
            
<%--            <button class="btn btn-lg btn-login btn-block" type="submit">Sign in</button>--%>
            <asp:Button ID="BtnLogin" runat="server" Text="Login" class="btn btn-lg btn-login btn-block" OnClick="BtnLogin_Click" />
                
            <div class="registration">
                Don't have a client account yet?
                <a class="" href="./create-account">
                    Create an account
                </a>
            </div>
             
        </div>


      </form>

    </div>



    <!-- Placed js at the end of the document so the pages load faster -->

    <!--Core js-->
    <script src="../js/jquery.js"></script>
    <script src="../bs3/js/bootstrap.min.js"></script>

  </body>

</html>

