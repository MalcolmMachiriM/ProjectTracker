<%@ Page Title="" Language="C#" MasterPageFile="~/ProjectMain.Master" AutoEventWireup="true" CodeBehind="edit-user.aspx.cs" Inherits="ProjectTrackingApp.Admin.edit_user" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <section id="main-content" class="">
        <section class="wrapper">

        <div class="row">
            <div class="col-lg-12">
                    <section class="panel">
                        <header class="panel-heading">
                            Edit User
                        </header>
                        <div class="panel-body">
                            <div class="position-center">
                                <form role="form" runat="server">
                                   <div class="row">
                <asp:HiddenField ID="txtid" runat="server" />
             </div>
                                <div class="form-group">
                                    <label>First Name</label>
                                    <asp:TextBox ID="txtFirstName" runat="server"  class="form-control" style="color: black; font-weight: bold;"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label>LastName</label>
                                    <asp:TextBox ID="txtLastName" runat="server"  class="form-control" style="color: black; font-weight: bold;"></asp:TextBox>
                                </div>
                                <div class="form-group">
     <label>Email</label>
     <asp:TextBox ID="txtEmail" runat="server" ReadOnly="true" class="form-control" style="color: black; font-weight: bold;"></asp:TextBox>
 </div>
                                 <div class="form-group">
     <label>Mobile</label>
     <asp:TextBox ID="txtMobile" runat="server" class="form-control" style="color: black; font-weight: bold;"></asp:TextBox>
 </div>
                                     <div class="form-group">
     <label>Role</label>
     <asp:DropDownList ID="drpRole" CssClass="form-control dropdown"  runat="server" style="color: black; font-weight: bold;"></asp:DropDownList>
 </div>
                                <asp:Button ID="btnSave" runat="server" Text="Update Details" class="btn btn-success" OnClick="btnSave_Click" />
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
