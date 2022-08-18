<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Subject.aspx.cs" Inherits="SchoolManagementSystem.Setup.Subject" %>

<%@ Register Src="~/ResponseMessage.ascx" TagPrefix="uc1" TagName="ResponseMessage" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="content-wrapper">
        <div class="container">
            <!-- general form elements -->
            <div class="card card-primary">
                <div class="card-header">
                    <h3 class="card-title">Subject Info</h3>
                </div>
                <uc1:ResponseMessage runat="server" ID="rmSubj" />
                <!-- /.card-header -->
                <!-- form start -->

                <div class="card-body">
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group ">
                                <label class="form-label">Subject Name</label>
                                <asp:TextBox ID="txtSubject" runat="server" placeholder="Enter Subject" CssClass="form-control"></asp:TextBox>
                            </div>

                        </div>
                        <div class="col-md-2">
                            <div class="form-group ">
                                <label class="form-label">&nbsp;</label>
                                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary form-control" Text="Save" OnClick="btnSave_Click1"/>
                            </div>

                        </div>
                    </div>


                </div>

                <div class="card-header ">
                    <h3 class="card-title text-center">Subject List</h3>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group ">
                                <asp:HiddenField ID="hdnUpdateSId" runat="server" />
                                <asp:GridView ID="gvSubject" runat="server" CssClass="table table-bordered table-striped" AutoGenerateColumns="False" OnRowCommand="gvSubject_RowCommand">
                                    <columns>
                                        <asp:TemplateField HeaderText="Subject Name">
                                            <itemtemplate>
                                                <asp:Label ID="lblSubject" runat="server" Text='<%# Eval("SubjectName") %>'></asp:Label>
                                            </itemtemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="Action">
                                            <itemtemplate>
                                                <asp:HiddenField ID="hdnSubjectId" runat="server" Value='<%# Eval("SubjectId") %>' />
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
