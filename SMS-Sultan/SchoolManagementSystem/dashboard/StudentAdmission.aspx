<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMaster.Master" AutoEventWireup="true" CodeBehind="StudentAdmission.aspx.cs" Inherits="SchoolManagementSystem.dashboard.StudentAdmission" %>

<%@ Register Src="~/ResponseMessage.ascx" TagPrefix="uc1" TagName="ResponseMessage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <%--<asp:HiddenField id="hdnStuId" runat="server"></asp:HiddenField>--%>


    <div class="content-wrapper">
        <div class="container">
            <!-- general form elements -->
            <div class="card card-primary">
                <div class="card-header">
                    <h3 class="card-title">Student Info</h3>
                </div>

                <uc1:ResponseMessage runat="server" ID="rmStudent" />

                <!-- /.card-header -->
                <!-- form start -->

                <div class="card-body">
                    <div class="row">
                <div class="col-md-4 mt-3">
                    <label class="form-label">Student Name</label>
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" Text=""></asp:TextBox>
                </div>
                <div class="col-md-4 mt-3">
                    <label class="form-label">Shift</label>
                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control">
                        <asp:ListItem Value="0">--Select--</asp:ListItem>
                        <asp:ListItem>Morning</asp:ListItem>
                        <asp:ListItem>Day</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-4 mt-3">
                    <label class="form-label">Class Name</label>
                    <asp:DropDownList ID="DropDownList2" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                </div>
                <div class="col-md-4 mt-3">
                    <label class="form-label">Session Year</label>
                    <asp:DropDownList ID="DropDownList3" runat="server" CssClass="form-control" AutoPostBack="True">
                    </asp:DropDownList>
                </div>
                <div class="col-md-4 mt-3">
                    <label class="form-label">Admission Date</label>
                    <asp:TextBox ID="TextBox2" TextMode="Date" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-4 mt-3">
                    <label class="form-label">Student Registration No</label>
                    <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-4 mt-3">
                    <label class="form-label">Roll No</label>
                    <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-4 mt-3">
                    <label>&nbsp;</label>
                    <asp:Button ID="Button1" CssClass="btn btn-primary form-control" runat="server" Text="Save" />
                </div>
            </div>

                </div>

                <div class="card-header ">
                    <h3 class="card-title text-center">Student Information</h3>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-12" style="overflow: scroll;">
                            <div class="form-group ">
                                <asp:HiddenField ID="hdnUpdateStudentId" runat="server" />
                                <asp:GridView ID="gvStudent" runat="server" CssClass="table table-bordered table-striped" AutoGenerateColumns="true" Width="100%">
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
