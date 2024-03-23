<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="create-account.aspx.cs" Inherits="ProjectTrackingApp.create_account" %>

<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="utf-8">

    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="">
    <meta name="author" content="ThemeBucket">
    <link rel="shortcut icon" href="../images/favicon.html">

    <title>Login</title>

    <!--Core CSS -->
    <link href="../bs3/css/bootstrap.min.css" rel="stylesheet">
    <link href="../css/bootstrap-reset.css" rel="stylesheet">
    <link href="../font-awesome/css/font-awesome.css" rel="stylesheet" />

    <!-- Custom styles for this template -->
    <link href="../css/style.css" rel="stylesheet">
    <link href="../css/style-responsive.css" rel="stylesheet" />

</head>
  <body class="login-body">

    <div class="container">

      <form class="form-signin" runat="server">
        <h2 class="form-signin-heading">Register Client Acount</h2>
        <div class="login-wrap">
                                        <div class="col-xs-12 text-center">
    <asp:Label ID="lblLoginError" runat="server" Font-Size="Small" style="font-size:15px;" ForeColor="Red"></asp:Label>
</div>
             <div class="col-xs-12 text-center">
     <asp:Label ID="lblSuccess" runat="server" Font-Size="Small" Style="font-size: 15px;" ForeColor="green"></asp:Label>
 </div>
            <p style="font-weight: bold; color: black;">Enter your personal details below</p>

            <asp:TextBox ID="txtFirstName" runat="server" placeholder="First Name" class="form-control" style="color: black; font-weight: bold;"></asp:TextBox>
            <asp:TextBox ID="txtLastName" runat="server" placeholder="Last Name" class="form-control" style="color: black; font-weight: bold;"></asp:TextBox>
            <asp:TextBox ID="txtEmail" runat="server" placeholder="Email" class="form-control" style="color: black; font-weight: bold;"></asp:TextBox>
            <asp:TextBox ID="txtMobile" runat="server" placeholder="Mobile" class="form-control" style="color: black; font-weight: bold;"></asp:TextBox>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" placeholder="Password" class="form-control" style="color: black; font-weight: bold;"></asp:TextBox>
            <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" placeholder="Confirm Password" class="form-control" style="color: black; font-weight: bold;"></asp:TextBox>
            <asp:Button ID="btnRegister" runat="server" Text="Register" class="btn btn-lg btn-login btn-block" OnClick="btnRegister_Click" />
            <div class="registration">
                Already Registered.
                <a class="" href="./login">
                    Login
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
