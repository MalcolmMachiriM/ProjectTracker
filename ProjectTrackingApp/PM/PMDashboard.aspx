<%@ Page Title="" Language="C#" MasterPageFile="~/ProjectManager.Master" AutoEventWireup="true" CodeBehind="PMDashboard.aspx.cs" Inherits="ProjectTrackingApp.PM.PMDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="main-content">
        <section class="wrapper">
            <form runat="server">
                <div class="row">
                    <div class="col-md-3">
                        <div class="mini-stat clearfix">
                            <span class="mini-stat-icon orange"><i class="fa fa-gavel"></i></span>
                            <div class="mini-stat-info">
                                <span>
                                    <asp:Literal ID="txtProjects" runat="server"></asp:Literal>

                                </span>


                                Projects
                            </div>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="mini-stat clearfix">
                            <span class="mini-stat-icon tar"><i class="fa fa-tag"></i></span>
                            <div class="mini-stat-info">
                                <span>
                                    <asp:Literal ID="txtPendingTasks" runat="server"></asp:Literal>
                                </span>
                                Total Tasks
                            </div>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="mini-stat clearfix">
                            <span class="mini-stat-icon pink"><i class="fa fa-money"></i></span>
                            <div class="mini-stat-info">
                                <span><asp:Literal ID="txtCompletedTasks" runat="server"></asp:Literal></span>
                                Pending Tasks
                            </div>
                        </div>
                    </div>
                    <div class="col-md-3">
                        <div class="mini-stat clearfix">
                            <span class="mini-stat-icon green"><i class="fa fa-eye"></i></span>
                            <div class="mini-stat-info">
                                <span>
                                    <asp:Literal ID="txtMembers" runat="server"></asp:Literal>
                                </span>
                                Members
                            </div>
                        </div>
                    </div>
                </div>


            </form>



        </section>
    </section>
</asp:Content>
