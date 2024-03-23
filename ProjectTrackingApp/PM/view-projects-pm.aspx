<%@ Page Title="" Language="C#" MasterPageFile="~/ProjectManager.Master" AutoEventWireup="true" CodeBehind="view-projects-pm.aspx.cs" Inherits="ProjectTrackingApp.PM.view_projects_pm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="main-content" class="">
        <section class="wrapper">

            <div class="row">
                <div class="col-lg-12">
                    <section class="panel">
                        <header class="panel-heading">
                            View Project And Risks
                        </header>
                        <div class="panel-body">
                            <div class="position-center">
                                <form role="form" runat="server">
                                    <div class="row">
                                        <asp:HiddenField ID="txtid" runat="server" />
                                    </div>

                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="txtFirstName">Project Name</label>
                                                <asp:TextBox ID="txtProjectName" runat="server" ReadOnly="true" class="form-control" Style="color: black; font-weight: bold;"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="drpProjectCategory">Project Category</label>
                                                <asp:DropDownList ID="drpProjectCategory" CssClass="form-control dropdown" runat="server" Enabled="false" Style="color: black; font-weight: bold;"></asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="txtEmail">Project Manager</label>
                                                <asp:DropDownList ID="drpProjectManager" CssClass="form-control dropdown" runat="server" Enabled="false" Style="color: black; font-weight: bold;"></asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="txtEmail">Project Status</label>
                                                <asp:DropDownList ID="drpStatus" CssClass="form-control dropdown" runat="server" Enabled="false" Style="color: black; font-weight: bold;"></asp:DropDownList>
                                            </div>
                                        </div>

                                    </div>


                                    <table style="width: 100%">
                                        <tr>
                                            <td>
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Predicted Risks
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="12">
                                                <asp:GridView ID="grdPredictedRisks" ClientIDMode="Static" Width="100%" runat="server"
                                                    AutoGenerateColumns="False" AutoGenerateSelectButton="false"
                                                    DataKeyNames="ID"
                                                    CssClass="table table-condensed" GridLines="None" role="grid" aria-describedby="DataTables_Table_0_info"
                                                    Style="border-collapse: collapse !important"
                                                    AllowPaging="true" AllowSorting="True" OnRowCommand="grdPredictedRisks_RowCommand">
                                                    <Columns>

                                                        <asp:BoundField DataField="ID" HeaderText="ID"></asp:BoundField>
                                                        <asp:BoundField DataField="Risk" HeaderText="Predicted Risks"></asp:BoundField>

                                                        <%--<asp:TemplateField HeaderText="Remove">
                                                            <ItemTemplate>

                                                                <asp:LinkButton ID="btnReject" runat="server" CssClass="btn btn-success btn-icon btn-sm" CommandName="selectrecord" OnClientClick="return confirm('Are you sure want you want to add risk to project?');" CommandArgument='<%#Eval("ID")%>'>
                                                    <i class="fa fa-archive"></i>
                                                                </asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>--%>
                                                    </Columns>
                                                </asp:GridView>

                                            </td>

                                        </tr>

                                    </table>


                                    <div class="row">

                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="txtEmail">Other Risks Observed</label>
                                                <asp:TextBox ID="txtRisk" runat="server" class="form-control" Style="color: black; font-weight: bold;"></asp:TextBox>
                                            </div>
                                        </div>

                                    </div>
                                    <div class="row">

                                        <div class="col-md-6">
                                            <asp:Button ID="btnSave" runat="server" Text="Add Risk" class="btn btn-success" OnClick="btnSave_Click" />
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
