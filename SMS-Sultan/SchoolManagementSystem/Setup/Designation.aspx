<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Designation.aspx.cs" Inherits="SchoolManagementSystem.Setup.Designation" %>

<%@ Register Src="~/ResponseMessage.ascx" TagPrefix="uc1" TagName="ResponseMessage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="content-wrapper">
        <div class="container">
            <!-- general form elements -->
            <div class="card card-primary">
                <div class="card-header">
                    <h3 class="card-title">Designation Info</h3>
                </div>
                <uc1:ResponseMessage runat="server" ID="rmDesignation" />
                <!-- /.card-header -->
                <!-- form start -->

                <asp:Button ID="btns" runat="server" Text="Sweetbox" />

                <div class="card-body">
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group ">
                                <label class="form-label">Designation Name</label>
                                <asp:TextBox ID="TxtDesignation" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <label class="form-label">Position</label>
                                <asp:TextBox ID="TxtPosition" runat="server" placeholder="Enter Position" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group ">
                                <label class="form-label">&nbsp;</label>
                                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary form-control" Text="Save" OnClick="btnSave_Click" />
                            </div>
                        </div>
                      
                    </div>
                </div>

                <div class="card-header ">
                    <h3 class="card-title text-center">Class List</h3>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group ">
                                <asp:HiddenField ID="hdnUpdateDesignationId" runat="server" />
                                <asp:GridView ID="gvDesignation" runat="server" CssClass="table table-bordered table-striped" AutoGenerateColumns="False" OnRowCommand="gvDesignation_RowCommand">
                                    <columns>
                                        <asp:TemplateField HeaderText="Designation Name">
                                            <itemtemplate>
                                                <asp:Label ID="lblDesignation" runat="server" Text='<%# Eval("DesignationName") %>'></asp:Label>                 
                                            </itemtemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Position">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPosition" runat="server" Text='<%# Eval("Position") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Action">
                                            <itemtemplate>
                                                <asp:HiddenField ID="hdnDesignationId" runat="server" Value='<%# Eval("DesignationId") %>' />
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
