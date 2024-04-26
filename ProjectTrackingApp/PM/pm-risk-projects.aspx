﻿<%@ Page Title="" Language="C#" MasterPageFile="~/ProjectManager.Master" AutoEventWireup="true" CodeBehind="pm-risk-projects.aspx.cs" Inherits="ProjectTrackingApp.PM.pm_risk_projects" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <section id="main-content" class="">
     <section class="wrapper">

         <div class="row">
             <div class="col-lg-12">
                 <section class="panel">
                     <header class="panel-heading">
                         View Projects 
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
                                                 <asp:BoundField DataField="ProjectName" HeaderText="ProjectName"></asp:BoundField>
                                                 <asp:BoundField DataField="StartDate" HeaderText="StartDate"></asp:BoundField>
                                                 <asp:BoundField DataField="EndDate" HeaderText="EndDate"></asp:BoundField>
                                                 <asp:BoundField DataField="ProjectManager" HeaderText="ProjectManager"></asp:BoundField>
                                                 <asp:BoundField DataField="ProjectStatus" HeaderText="ProjectStatus"></asp:BoundField>
                                                 <asp:TemplateField HeaderText="View">
                                                     <ItemTemplate>
                                                         <asp:LinkButton ID="btnEdit" runat="server" CssClass="btn btn-success btn-icon btn-sm " CommandName="editrecord" CommandArgument='<%#Eval("ID")%>'>
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