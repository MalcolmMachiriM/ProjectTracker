<%@ Page Title="" Language="C#" MasterPageFile="~/ProjectManager.Master" AutoEventWireup="true" CodeBehind="ProjectMembers.aspx.cs" Inherits="ProjectTrackingApp.PM.ProjectMembers" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="main-content" class="">
    <section class="wrapper">

        <div class="row">
            <div class="col-lg-12">
                <section class="panel">
                    <header class="panel-heading">
                        View Team Members
                    </header>
                    <div class="panel-body">
                        <form runat="server">
                            <table style="width: 100%">

                                <tr>
                                    <td colspan="12">
                                        <asp:GridView ID="grdTasks" ClientIDMode="Static" Width="100%" runat="server"
                                            AutoGenerateColumns="False" AutoGenerateSelectButton="false"
                                            DataKeyNames="ID" 
                                            CssClass="table table-condensed" GridLines="None" role="grid" aria-describedby="DataTables_Table_0_info"
                                            Style="border-collapse: collapse !important"
                                            AllowPaging="true" AllowSorting="True" OnRowCommand="grdTasks_RowCommand">
                                            <Columns>

                                                <asp:BoundField DataField="ID" HeaderText="ID"></asp:BoundField>
                                                <asp:BoundField DataField="FirstName" HeaderText="Project Name"></asp:BoundField>
                                                <asp:BoundField DataField="LastName" HeaderText="Task Name"></asp:BoundField>
                                                <asp:BoundField DataField="Email" HeaderText="Start Date"></asp:BoundField>
                                                <asp:BoundField DataField="Mobile" HeaderText="End Date"></asp:BoundField>
                                                <asp:TemplateField HeaderText="Assign">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnAssign" runat="server" CssClass="btn btn-primary btn-icon btn-sm " CommandName="assignrecord" CommandArgument='<%#Eval("ID")%>'>
                                                <i class="fa fa-share-square-o"></i>
                                                        </asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Discard">
                                                    <ItemTemplate>

                                                        <asp:LinkButton ID="btnReject" runat="server" CssClass="btn btn-danger btn-icon btn-sm" CommandName="deleterecord" OnClientClick="return confirm('Are you sure want you want to delete project?');" CommandArgument='<%#Eval("ID")%>'>
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
