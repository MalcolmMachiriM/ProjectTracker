<%@ Page Title="" Language="C#" MasterPageFile="~/ClientView.Master" AutoEventWireup="true" CodeBehind="client-dashboard.aspx.cs" Inherits="ProjectTrackingApp.Client.client_dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="main-content">
        <section class="wrapper">
            <form runat="server">
                <div class="row">
                    <div class="col-md-4">
                        <div class="mini-stat clearfix">
                            <span class="mini-stat-icon green"><i class="fa fa-eye"></i></span>
                            <div class="mini-stat-info">
                                <span>
                                    <asp:Literal ID="txtResources" runat="server"></asp:Literal>
                                </span>
                                Projects
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="mini-stat clearfix">
                            <span class="mini-stat-icon tar"><i class="fa fa-tag"></i></span>
                            <div class="mini-stat-info">
                                <span>
                                    <asp:Literal ID="txtPendingTasks" runat="server"></asp:Literal>
                                </span>
                                Pendings Tasks
                            </div>
                        </div>
                    </div>
                    <div class="col-md-4">
                        <div class="mini-stat clearfix">
                            <span class="mini-stat-icon pink"><i class="fa fa-money"></i></span>
                            <div class="mini-stat-info">
                                <span>
                                    <asp:Literal ID="txtAllocatedTasks" runat="server"></asp:Literal></span>
                                Completed Tasks
                            </div>
                        </div>
                    </div>

                </div>


                <asp:Panel ID="pnlOngoing" runat="server" Visible="false">
                    
                                    <table style="width: 100%">
                                        <tr>
                                            <td>
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Assigned Projects
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="12">
                                                <asp:GridView ID="grdProjects" ClientIDMode="Static" Width="100%" runat="server"
                                                    AutoGenerateColumns="False" AutoGenerateSelectButton="false"
                                                    DataKeyNames="ID"
                                                    CssClass="table table-condensed" GridLines="None" role="grid" aria-describedby="DataTables_Table_0_info"
                                                    Style="border-collapse: collapse !important"
                                                    AllowPaging="true" AllowSorting="True" OnRowCommand="grdMember_RowCommand">
                                                    <Columns>

                                                        <asp:BoundField DataField="ID" HeaderText="ID" Visible="false"></asp:BoundField>
                                                        <asp:BoundField DataField="ProjectName" HeaderText="Project Name"></asp:BoundField>
                                                        <asp:BoundField DataField="ProjectLocation" HeaderText="Location"></asp:BoundField>
                                                        <asp:BoundField DataField="StartDate" HeaderText="Start Date"></asp:BoundField>
                                                        <asp:BoundField DataField="EndDate" HeaderText="End Date"></asp:BoundField>

                                                        <asp:TemplateField HeaderText="Remove">
                                                            <ItemTemplate>

                                                                <asp:LinkButton ID="btnReject" runat="server" CssClass="btn btn-danger btn-icon btn-sm" CommandName="deleterecord" OnClientClick="return confirm('Are you sure want you want to remove member from project?');" CommandArgument='<%#Eval("ID")%>'>
                                                     <i class="fa fa-archive"></i>
                                                                </asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>

                                            </td>

                                        </tr>

                                    </table>
                </asp:Panel>

            </form>



        </section>
    </section>
</asp:Content>
