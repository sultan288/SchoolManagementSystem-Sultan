<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMaster.Master" AutoEventWireup="true" CodeBehind="User_List.aspx.cs" Inherits="SchoolManagementSystem.dashboard.User_List" %>

<%@ Register Src="~/ResponseMessage.ascx" TagPrefix="uc1" TagName="ResponseMessage" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <div class="content-wrapper">
        <div class="container">
            <!-- general form elements -->
            <div class="card card-primary">
                <div class="card-header">
                    <h3 class="card-title">Student Info</h3>
                </div>

                <uc1:ResponseMessage runat="server" ID="rmUlist" />


                <div class="card-body">
                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">User Name</label>
                                <asp:TextBox ID="txtUserName" runat="server" placeholder="Enter Registration No" CssClass="form-control"></asp:TextBox>
                            </div>

                        </div>
                        <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">User Type</label>
                                <asp:DropDownList ID="txtUserType" runat="server" CssClass="form-control">
                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                    <asp:ListItem>Admin</asp:ListItem>
                                    <asp:ListItem>Moderator 1</asp:ListItem>
                                    <asp:ListItem>Moderator 2</asp:ListItem>
                                    <asp:ListItem>Editor</asp:ListItem>
                                    <asp:ListItem>Guest</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">Login Time</label>
                                <asp:TextBox ID="txtLoginTime" runat="server" placeholder="Enter Last Name" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div>
                            <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="btn btn-success" />
                        </div>
                    </div>
                </div>


                <div class="card-header ">
                    <h3 class="card-title text-center">Student Information</h3>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group ">
                                <asp:HiddenField ID="hdnUpdateULId" runat="server" />
                                <asp:GridView ID="gvUserList" runat="server" CssClass="table table-bordered table-striped" AutoGenerateColumns="False" OnRowCommand="gvClass_RowCommand">
                                    <columns>
                                        <asp:TemplateField HeaderText="User Name">
                                            <itemtemplate>
                                                <asp:Label ID="lblUser" runat="server" Text='<%# Eval("UserName") %>'></asp:Label>
                                            </itemtemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Login Time">
                                            <itemtemplate>
                                                 <asp:Label ID="lblLoginTime" runat="server" Text='<%# Eval("LoginTime") %>'></asp:Label>
                                            </itemtemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="User Type">
                                            <itemtemplate>
                                                 <asp:Label ID="lblUserType" runat="server" Text='<%# Eval("UserType") %>'></asp:Label>
                                            </itemtemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="Action">
                                            <itemtemplate>
                                                <asp:HiddenField ID="hdnULId" runat="server" Value='<%# Eval("UserID") %>' />
                                                <asp:ImageButton ID="imgEdit" runat="server" ImageUrl="~/assets/site/images/ico_information.png" CommandName="editc" CommandArgument='<%# Container.DataItemIndex %>' Width="25px" />
                                                <asp:ImageButton ID="imgDelete" runat="server" ImageUrl="~/assets/img/cancel.png" CommandName="deletec" CommandArgument='<%# Container.DataItemIndex %>' OnClientClick="if ( ! ConfirmationMsg()) return false;" meta:resourcekey="imgDelete" Width="25px" />
                                            </itemtemplate>
                                        </asp:TemplateField>
                                    </columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- /.card -->
        </div>
    </div>


</asp:Content>
