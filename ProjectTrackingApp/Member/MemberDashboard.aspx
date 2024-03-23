<%@ Page Title="" Language="C#" MasterPageFile="~/MembersView.Master" AutoEventWireup="true" CodeBehind="MemberDashboard.aspx.cs" Inherits="ProjectTrackingApp.Member.MemberDashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <section id="main-content">
        <section class="wrapper">
            <form runat="server">
                <div class="row">
                    <div class="col-md-3">
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
                    <div class="col-md-3">
                        <div class="mini-stat clearfix">
                            <span class="mini-stat-icon pink"><i class="fa fa-money"></i></span>
                            <div class="mini-stat-info">
                                <span><asp:Literal ID="txtCompletedTasks" runat="server"></asp:Literal></span>
                                Completed Tasks
                            </div>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="mini-stat clearfix">
                            <span class="mini-stat-icon green"><i class="fa fa-eye"></i></span>
                            <div class="mini-stat-info">
                                <span>
                                    <asp:Literal ID="txtResources" runat="server"></asp:Literal>
                                </span>
                                Resources
                            </div>
                        </div>
                    </div>
                </div>


            </form>



        </section>
    </section>
</asp:Content>
