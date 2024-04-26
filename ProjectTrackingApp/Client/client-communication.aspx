<%@ Page Title="" Language="C#" MasterPageFile="~/ClientView.Master" AutoEventWireup="true" CodeBehind="client-communication.aspx.cs" Inherits="ProjectTrackingApp.Client.client_communication" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <section id="main-content" class="">
     <section class="wrapper">

         <div class="row">
             <div class="col-lg-12">
                 <section class="panel">
                     <header class="panel-heading">
                         Communications Center
                     </header>
                     <div class="panel-body">
                         <form runat="server">

                             <table style="width: 100%">

                                 <tr>
                                     <td colspan="12">

                                         <div class="main-panel ps ps--active-y">
                                             <nav class="navbar-absolute fixed-top navbar-transparent navbar navbar-expand-lg">
                                                 <div class="container-fluid">
                                                 </div>
                                             </nav>
                                             <div class="content">
                                                 <div class="row">
                                                     <asp:HiddenField ID="txtID" runat="server" />
                                                     <asp:HiddenField ID="txtClientID" runat="server" />
                                                     <asp:HiddenField ID="txtMemberID" runat="server" />
                                                 </div>
                                                 <div class="row">
                                                     <div class="col-md-12">
                                                         <asp:Panel ID="pnlComms" runat="server">
                                                             <asp:Label ID="lblComms" runat="server" Text="" ForeColor="White" Font-Bold="True"></asp:Label>
                                                         </asp:Panel>
                                                     </div>
                                                 </div>
                                                 <div class="row col-sm-12">


                                                     <div class="col-sm-12" id="dvDash" runat="server" visible="true">

                                                         <asp:Panel ID="pnlDash" runat="server" Visible="true">
                                                             <div class="card" style="width: 100%">
                                                                 <%--<div class="card-header">Communications Center (Emails)</div>--%>

                                                                 <div class="form-block">

                                                                     <div class="form-block-body, col-sm-12">
                                                                         <div class="form-group row gutters , col-sm-12">
                                                                             <table style="width: 90%; margin: 0 auto;">

                                                                                 <tr>
                                                                                     <td colspan="2">Subject Header:</td>
                                                                                     <td colspan="8">
                                                                                         <asp:TextBox ID="txtHeader" CssClass="form-control" runat="server"></asp:TextBox>
                                                                                     </td>
                                                                                 </tr>

                                                                                 <tr id="mess" runat="server" visible="false">
                                                                                     <td colspan="2">Message Body:</td>
                                                                                     <td colspan="8">
                                                                                         <asp:TextBox ID="txtMessageBody" TextMode="MultiLine" Width="100%" runat="server"></asp:TextBox>
                                                                                     </td>
                                                                                 </tr>

                                                                                 
                                                                                 <%-- file --%>
                                                                                 <tr class="col-6">
                                                                                     <td colspan="2">Attachments</td>
                                                                                     <td colspan="8">
                                                                                         <asp:FileUpload ID="flRsvpUpload" AllowMultiple="true" EnableViewState="true" CssClass="form-control fa-upload" runat="server" />

                                                                                     </td>

                                                                                 </tr>
                                                                                 <tr>
                                                                                     <td colspan="10">
                                                                                         <hr />
                                                                                     </td>
                                                                                 </tr>
                                                                                 <tr>
                                                                                     <td colspan="10" style="text-align: center">
                                                                                         <asp:Button ID="btnSave" CssClass="btn btn-primary" OnClick="btnSave_Click" runat="server" Text="Save BroadCast Message" />
                                                                                     </td>
                                                                                 </tr>
                                                                                 <tr>
                                                                                     <td colspan="10">
                                                                                         <hr />
                                                                                     </td>
                                                                                 </tr>
                                                                                 <tr>
                                                                                     <td colspan="4">Unassigned Contacts:</td>
                                                                                     <td colspan="4">Mailing List Contacts:</td>
                                                                                 </tr>
                                                                                 <tr>
                                                                                     <td colspan="5">
                                                                                         <asp:ListBox ID="lstUnassigned" Width="100%" runat="server" SelectionMode="Multiple"></asp:ListBox>
                                                                                     </td>
                                                                                     <td colspan="2">
                                                                                         <asp:Button ID="btnAdd" OnClick="btnAdd_Click" runat="server" Text=">" />
                                                                                         <asp:Button ID="btnRemove" OnClick="btnRemove_Click" runat="server" Text="<" />
                                                                                     </td>
                                                                                     <td colspan="5">
                                                                                         <asp:ListBox ID="lstMailingList" Width="100%" SelectionMode="Multiple" runat="server"></asp:ListBox>
                                                                                     </td>
                                                                                 </tr>
                                                                                 <tr>
                                                                                     <td colspan="10" style="text-align: center">
                                                                                         <asp:Button ID="btnsend" OnClick="btnsend_Click" runat="server" Text="Send Message" CssClass="btn btn-primary" />
                                                                                     </td>
                                                                                 </tr>
                                                                             </table>
                                                                         </div>
                                                                     </div>

                                                                 </div>

                                                             </div>
                                                         </asp:Panel>

                                                     </div>
                                                 </div>
                                             </div>
                                         </div>

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
