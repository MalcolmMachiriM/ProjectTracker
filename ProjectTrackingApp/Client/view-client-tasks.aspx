<%@ Page Title="" Language="C#" MasterPageFile="~/ClientView.Master" AutoEventWireup="true" CodeBehind="view-client-tasks.aspx.cs" Inherits="ProjectTrackingApp.Client.view_client_tasks" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <section id="main-content" class="">
     <section class="wrapper">

         <div class="row">
             <div class="col-lg-12">
                 <section class="panel">
                     <header class="panel-heading">
                         View Tasks
                     </header>
                     <div class="panel-body">
                         
                         <form runat="server">
                             <asp:HiddenField ID="projectId" runat="server" />
                             <table style="width: 100%">

                                 <tr>
                                     <td colspan="12">
                                         <asp:GridView ID="grdTasks" ClientIDMode="Static" Width="100%" runat="server"
                                             AutoGenerateColumns="False" AutoGenerateSelectButton="false"
                                             DataKeyNames="ID" 
                                             CssClass="table table-condensed" GridLines="None" role="grid" aria-describedby="DataTables_Table_0_info"
                                             Style="border-collapse: collapse !important"
                                             AllowPaging="true" AllowSorting="True" >
                                             <Columns>

                                                 <asp:BoundField DataField="ID" HeaderText="ID"></asp:BoundField>
                                                 <asp:BoundField DataField="ProjectName" HeaderText="Project Name"></asp:BoundField>
                                                 <asp:BoundField DataField="Name" HeaderText="Task Name"></asp:BoundField>
                                                 <asp:BoundField DataField="StartDate" HeaderText="Start Date"></asp:BoundField>
                                                 <asp:BoundField DataField="EndDate" HeaderText="End Date"></asp:BoundField>
                                                 <asp:BoundField DataField="FullName" HeaderText="Project Manager"></asp:BoundField>
                                                 <asp:BoundField DataField="Status" HeaderText="Task Status"></asp:BoundField>
                                                 <asp:TemplateField HeaderText="Assign">
                                                     <ItemTemplate>
                                                         <asp:LinkButton ID="btnAssign" runat="server" CssClass="btn btn-primary btn-icon btn-sm " CommandName="assignrecord" CommandArgument='<%#Eval("ID")%>'>
                                                 <i class="fa fa-share-square-o"></i>
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
