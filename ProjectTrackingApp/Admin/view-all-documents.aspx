﻿<%@ Page Title="" Language="C#" MasterPageFile="~/ProjectMain.Master" AutoEventWireup="true" CodeBehind="view-all-documents.aspx.cs" Inherits="ProjectTrackingApp.Admin.view_all_documents" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <section id="main-content" class="">
     <section class="wrapper">

         <div class="row">
             <div class="col-lg-12">
                 <section class="panel">
                     <header class="panel-heading">
                         View Documents
                     </header>
                     <div class="panel-body">
                         <form runat="server">
                             <table style="width: 100%">

                                 <tr>
                                     <td colspan="12">
                                         <asp:GridView ID="grdDocuments" ClientIDMode="Static" Width="100%" runat="server"
                                             AutoGenerateColumns="False" AutoGenerateSelectButton="false"
                                             DataKeyNames="ID"
                                             CssClass="table table-condensed" GridLines="None" role="grid" aria-describedby="DataTables_Table_0_info"
                                             Style="border-collapse: collapse !important"
                                             AllowPaging="true" AllowSorting="True" OnRowCommand="grdDocuments_RowCommand">
                                             <Columns>

                                                 <asp:BoundField DataField="ID" HeaderText="ID"></asp:BoundField>
                                                 <asp:BoundField DataField="FileName" HeaderText="File Name"></asp:BoundField>
                                                 <asp:BoundField DataField="ProjectName" HeaderText="Project Name"></asp:BoundField>
                                                 <asp:BoundField DataField="Description" HeaderText="Description"></asp:BoundField>
                                                 <asp:BoundField DataField="UploadedBy" HeaderText="Uploaded By"></asp:BoundField>
                                                 <asp:TemplateField HeaderText="Download">
                                                     <ItemTemplate>
                                                         <asp:LinkButton ID="btnDownload" runat="server" CssClass="btn btn-success btn-icon btn-sm " CommandName="downloadrecord" CommandArgument='<%#Eval("ID")%>'>
                                                     <i class="fa fa-eye"></i>
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