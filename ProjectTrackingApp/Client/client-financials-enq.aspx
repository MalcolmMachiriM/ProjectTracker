<%@ Page Title="" Language="C#" MasterPageFile="~/ClientView.Master" AutoEventWireup="true" CodeBehind="client-financials-enq.aspx.cs" Inherits="ProjectTrackingApp.Client.client_financials_enq" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <section id="main-content" class="">
    <section class="wrapper">

        <div class="row">
            <div class="col-lg-12">
                <section class="panel">
                    <header class="panel-heading">
                        Projects
                    </header>
                    <div class="panel-body">
                        <form runat="server">
                            <table style="width: 100%">

                                <tr>
                                    <td colspan="12">
                                        <asp:GridView ID="grdProject" ClientIDMode="Static" Width="100%" runat="server"
                                            AutoGenerateColumns="False" AutoGenerateSelectButton="false"
                                            DataKeyNames="ID" OnPageIndexChanging="grdProject_PageIndexChanging"
                                            CssClass="table table-condensed" GridLines="None" role="grid" aria-describedby="DataTables_Table_0_info"
                                            Style="border-collapse: collapse !important"
                                            AllowPaging="true" AllowSorting="True" OnRowCommand="grdProject_RowCommand">
                                            <Columns>

                                                <asp:BoundField DataField="ID" HeaderText="ID"></asp:BoundField>
                                                <asp:BoundField DataField="ProjectName" HeaderText="Project Name"></asp:BoundField>
                                                <asp:BoundField DataField="StartDate" HeaderText="Start Date"></asp:BoundField>
                                                <asp:BoundField DataField="EndDate" HeaderText="End Date"></asp:BoundField>
                                                <asp:BoundField DataField="ProjectManager" HeaderText="Project Manager"></asp:BoundField>
                                                <asp:BoundField DataField="Budegt" HeaderText="Budget($)"></asp:BoundField>
                                                <asp:TemplateField HeaderText="View">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnAssign" runat="server" CssClass="btn btn-primary btn-icon btn-sm " CommandName="assignrecord" CommandArgument='<%#Eval("ID")%>'>
                                                    <i class="fa fa-eye"></i>
                                                        </asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>

                                    </td>

                                </tr>

                            </table>
                        </form>


                    </div>
                </section>

            </div>

        </div>

    </section>
</section>
</asp:Content>
