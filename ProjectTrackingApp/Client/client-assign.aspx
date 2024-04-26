<%@ Page Title="" Language="C#" MasterPageFile="~/ProjectMain.Master" AutoEventWireup="true" CodeBehind="client-assign.aspx.cs" Inherits="ProjectTrackingApp.Client.client_assign" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <section id="main-content" class="">
        <section class="wrapper">

            <div class="row">
                <div class="col-lg-12">
                    <section class="panel">
                        <header class="panel-heading">
                            Assign Client To Project
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
                                                <label for="txtFirstName">Client Name</label>
                                                <asp:TextBox ID="txtClientName" runat="server" ReadOnly="true" class="form-control" Style="color: black; font-weight: bold;"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label for="txtLastName">Client Surname</label>
                                                <asp:TextBox ID="txtClientSurname" runat="server" ReadOnly="true" class="form-control" Style="color: black; font-weight: bold;"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    
                                    <div class="row">

                                        <div class="col-md-6">
     <div class="form-group">
         <label for="drpTeamMember">Role</label>
         <asp:DropDownList ID="drpTeamMember" CssClass="form-control dropdown" AutoPostBack="false"   runat="server" Style="color: black; font-weight: bold;"></asp:DropDownList>
     </div>

 </div>

                                    </div>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <asp:Button ID="btnSave" runat="server" Text="Add Project" class="btn btn-success" OnClick="btnSave_Click" />
                                        </div>
                                    </div>

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
