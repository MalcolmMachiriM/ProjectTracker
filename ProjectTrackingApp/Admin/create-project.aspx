<%@ Page Title="" Language="C#" MasterPageFile="~/ProjectMain.Master" AutoEventWireup="true" CodeBehind="create-project.aspx.cs" Inherits="ProjectTrackingApp.Admin.create_project" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="main-content" class="">
        <section class="wrapper">

            <div class="row">
                <div class="col-lg-12">
                    <section class="panel">
                        <header class="panel-heading">
                            Create Project
                        </header>
                        <div class="panel-body">
                            <div class="position-center">
                                <form role="form" runat="server">

                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="txtFirstName">Project Name</label>
                                                <asp:TextBox ID="txtProjectName" runat="server" class="form-control" Style="color: black; font-weight: bold;"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="txtLastName">Project Location</label>
                                                <asp:TextBox ID="txtProjectLocation" runat="server" class="form-control" Style="color: black; font-weight: bold;"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="txtEmail">Start Date</label>
                                                <asp:TextBox ID="txtStartDate" runat="server" TextMode="Date" class="form-control" Style="color: black; font-weight: bold;"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="txtMobile">End Date</label>
                                                <asp:TextBox ID="txtEndDate" runat="server" TextMode="Date" class="form-control" Style="color: black; font-weight: bold;"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="txtEmail">Project Status</label>
                                                <asp:DropDownList ID="drpStatus" CssClass="form-control dropdown" runat="server" Style="color: black; font-weight: bold;"></asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="txtMobile">Project Type</label>
                                                <asp:DropDownList ID="drpType" CssClass="form-control dropdown" runat="server" Style="color: black; font-weight: bold;"></asp:DropDownList>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="txtEmail">Budget Amount</label>
                                                <asp:TextBox ID="txtBudget" runat="server" class="form-control" Style="color: black; font-weight: bold;"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="txtMobile">Currency</label>
                                                <asp:DropDownList ID="drpCurrency" CssClass="form-control dropdown" runat="server" Style="color: black; font-weight: bold;"></asp:DropDownList>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="txtEmail">Client Name</label>
                                                <asp:TextBox ID="txtClientName" runat="server" class="form-control" Style="color: black; font-weight: bold;"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="txtMobile">Client Mobile</label>
                                                <asp:TextBox ID="txtClientInfo" runat="server" class="form-control" Style="color: black; font-weight: bold;"></asp:TextBox>

                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="txtEmail">Project Manager</label>
                                                <asp:DropDownList ID="drpProjectManager" CssClass="form-control dropdown" runat="server" Style="color: black; font-weight: bold;"></asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="txtEmail">Project Category</label>
                                                <asp:DropDownList ID="drpProjectCategory" CssClass="form-control dropdown" runat="server" Style="color: black; font-weight: bold;"></asp:DropDownList>
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

