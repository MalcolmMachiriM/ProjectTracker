<%@ Page Title="" Language="C#" MasterPageFile="~/ProjectMain.Master" AutoEventWireup="true" CodeBehind="create-resource.aspx.cs" Inherits="ProjectTrackingApp.Admin.create_resource" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="main-content" class="">
    <section class="wrapper">
        <div class="row">
            <div class="col-lg-12">
                <section class="panel">
                    <header class="panel-heading">
                        Create Resource
                    </header>
                    <div class="panel-body">
                        <div class="position-center">
                            <form role="form" runat="server">

                                <asp:HiddenField ID="txtID" runat="server" />
                                <asp:HiddenField ID="txtProjectId" runat="server" />
                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="form-group">
                                            <label for="txtName">Project Name</label>
                                            <asp:DropDownList ID="drpProject" CssClass="form-control dropdown" runat="server" Style="color: black; font-weight: bold;"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label for="txtName">Name</label>
                                            <asp:TextBox ID="txtName" runat="server" class="form-control" Style="color: black; font-weight: bold;"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-group">
                                            <label for="txtDescription">Description</label>
                                            <asp:TextBox ID="txtDescription" runat="server" class="form-control" Style="color: black; font-weight: bold;"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>


                                <div class="row">
                                    <div class="col-md-6">
                                        <asp:Button ID="btnSave" runat="server" Text="Save Resource" class="btn btn-success" OnClick="btnSave_Click" />
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
