<%@ Page Title="" Language="C#" MasterPageFile="~/ProjectMain.Master" AutoEventWireup="true" CodeBehind="create-project-category.aspx.cs" Inherits="ProjectTrackingApp.Admin.create_project_category" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="main-content" class="">
        <section class="wrapper">

            <div class="row">
                <div class="col-lg-12">
                    <section class="panel">
                        <header class="panel-heading">
                            Create Project Category
                        </header>
                        <div class="panel-body">
                            <div class="position-center">
                                <form role="form" runat="server">

                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="txtFirstName">Project Category Name</label>
                                                <asp:TextBox ID="txtProjectCategory" runat="server" class="form-control" Style="color: black; font-weight: bold;"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">

                                        <div class="col-md-6">
                                            <asp:Button ID="btnSave" runat="server" Text="Save Details" class="btn btn-success mt-3" OnClick="btnSave_Click" />

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
