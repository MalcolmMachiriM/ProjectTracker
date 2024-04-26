<%@ Page Title="" Language="C#" MasterPageFile="~/ProjectManager.Master" AutoEventWireup="true" CodeBehind="document-add.aspx.cs" Inherits="ProjectTrackingApp.PM.document_add" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="main-content" class="">
        <section class="wrapper">

            <div class="row">
                <div class="col-lg-12">
                    <section class="panel">
                        <header class="panel-heading">
                            Add Document
                        </header>
                        <div class="panel-body">
                            <div class="position-center">
                                <form role="form" runat="server">

                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="txtDescription">Description of Document</label>
                                                <asp:TextBox ID="txtDescription" runat="server" class="form-control" Style="color: black; font-weight: bold;"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="drpProjects">Select Project</label>
                                                <asp:DropDownList ID="drpProjects" runat="server" class="form-control" Style="color: black; font-weight: bold;"></asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">

                                        <div class="form-group">
                                            
                                            <div class="col-md-6">
                                                <label for="drpProjects">Select File</label>
                                                <asp:FileUpload ID="flDocx" runat="server" CssClass="form-control" Style="color: black; font-weight: bold;" />

                                            </div>
                                        </div>
                                    </div>
                                    <br />
                                    <div class="row">

                                    <div class="col-md-6">
                                        <asp:Button ID="btnSave" runat="server" Text="Save Document" class="btn btn-success mt-3" OnClick="btnSave_Click" />

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
