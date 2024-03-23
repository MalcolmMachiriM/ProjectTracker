<%@ Page Title="" Language="C#" MasterPageFile="~/ProjectMain.Master" AutoEventWireup="true" CodeBehind="view-user.aspx.cs" Inherits="ProjectTrackingApp.Admin.view_user" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="main-content" class="">
        <section class="wrapper">

            <div class="row">
                <div class="col-lg-12">
                    <section class="panel">
                        <header class="panel-heading">
                            View Users
                        </header>
                        <div class="panel-body">
                            <form runat="server">
                                <table style="width: 100%">

                                    <tr>
                                        <td colspan="12">
                                            <asp:GridView ID="grdUsers" ClientIDMode="Static" Width="100%" runat="server"
                                                AutoGenerateColumns="False" AutoGenerateSelectButton="false"
                                                DataKeyNames="UserID" OnPageIndexChanging="grdUsers_PageIndexChanging"
                                                CssClass="table table-condensed" GridLines="None" role="grid" aria-describedby="DataTables_Table_0_info"
                                                Style="border-collapse: collapse !important"
                                                AllowPaging="true" AllowSorting="True" OnRowCommand="grdUsers_RowCommand">
                                                <Columns>

                                                    <asp:BoundField DataField="FirstName" HeaderText="FirstName"></asp:BoundField>
                                                    <asp:BoundField DataField="LastName" HeaderText="LastName"></asp:BoundField>
                                                    <asp:BoundField DataField="RoleName" HeaderText="RoleName"></asp:BoundField>
                                                    <asp:BoundField DataField="Email" HeaderText="Email"></asp:BoundField>
                                                    <asp:BoundField DataField="Mobile" HeaderText="Mobile"></asp:BoundField>
                                                    <asp:BoundField DataField="Status" HeaderText="Status"></asp:BoundField>
                                                    <asp:TemplateField HeaderText="View">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnEdit" runat="server" CssClass="btn btn-success btn-icon btn-sm " CommandName="editrecord" CommandArgument='<%#Eval("UserID")%>'>
                                                        <i class="fa fa-edit"></i>
                                                            </asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Suspend">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnSuspend" runat="server" CssClass="btn btn-warning btn-icon btn-sm " CommandName="suspendrecord" CommandArgument='<%#Eval("UserID")%>'>
                                                        <i class="fa fa-edit"></i>
                                                            </asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Activate">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnActivate" runat="server" CssClass="btn btn-info btn-icon btn-sm " CommandName="activaterecord" CommandArgument='<%#Eval("UserID")%>'>
                                                        <i class="fa fa-check-square"></i>
                                                            </asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Delete">
                                                        <ItemTemplate>

                                                            <asp:LinkButton ID="btnReject" runat="server" CssClass="btn btn-danger btn-icon btn-sm" CommandName="deleterecord" OnClientClick="return confirm('Are you sure want you want to delete user?');" CommandArgument='<%#Eval("userid")%>'>
                                                        <i class="fa fa-archive"></i>
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
