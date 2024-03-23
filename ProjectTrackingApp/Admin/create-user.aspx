<%@ Page Title="" Language="C#" MasterPageFile="~/ProjectMain.Master" AutoEventWireup="true" CodeBehind="create-user.aspx.cs" Inherits="ProjectTrackingApp.Admin.create_user" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <section id="main-content" class="">
        <section class="wrapper">

        <div class="row">
            <div class="col-lg-12">
                    <section class="panel">
                        <header class="panel-heading">
                            Create User
                        </header>
                        <div class="panel-body">
                         <div class="position-center">
    <form role="form" runat="server">

        <div class="row">
            <div class="col-md-6">
                <div class="form-group">
                    <label for="txtFirstName">First Name</label>
                    <asp:TextBox ID="txtFirstName" runat="server" class="form-control" style="color: black; font-weight: bold;"></asp:TextBox>
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <label for="txtLastName">Last Name</label>
                    <asp:TextBox ID="txtLastName" runat="server" class="form-control" style="color: black; font-weight: bold;"></asp:TextBox>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-md-6">
                <div class="form-group">
                    <label for="txtEmail">Email</label>
                    <asp:TextBox ID="txtEmail" runat="server" class="form-control" style="color: black; font-weight: bold;"></asp:TextBox>
                </div>
            </div>
            <div class="col-md-6">
                <div class="form-group">
                    <label for="txtMobile">Mobile</label>
                 <asp:TextBox ID="txtMobile" runat="server" class="form-control" style="color: black; font-weight: bold;"></asp:TextBox>

                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-md-6">
                <div class="form-group">
                    <label for="drpRole">Role</label>
                    <asp:DropDownList ID="drpRole" CssClass="form-control dropdown" runat="server" style="color: black; font-weight: bold;"></asp:DropDownList>
                </div>
            </div>
        </div>

        <div class="row">
            <div class="col-md-6">
                <asp:Button ID="btnSave" runat="server" Text="Save Details" class="btn btn-success" OnClick="btnSave_Click" />
            </div>
        </div>

    </form>
</div>


                        </div>
                    </section>

            </div>
           
        </div>
        

        <!-- page end-->
        </section>
    </section>
</asp:Content>
