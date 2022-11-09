<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMaster.Master" AutoEventWireup="true" CodeBehind="SchoolProfile.aspx.cs" Inherits="SchoolManagementSystem.Setup.SchoolProfile" %>

<%@ Register Src="~/ResponseMessage.ascx" TagPrefix="uc1" TagName="ResponseMessage" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="content-wrapper">
        <div class="container">
            <!-- general form elements -->
            <div class="card card-primary mt-2">
                <div class="card-header">
                    <h3 class="card-title">Institute Info</h3>
                </div>
                <!--Error Message-->
                <uc1:responsemessage runat="server" id="rmschool" />

                <div class="card-body">
                    <div class="row">
                        <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">EIIN/Registration No</label>
                                <asp:TextBox ID="txtRegno" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>

                        </div>
                        <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">School Name</label>
                                <asp:TextBox ID="txtSchoolName" runat="server" placeholder="Enter Institute Name" CssClass="form-control"></asp:TextBox>
                            </div>

                        </div>
                        <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">Email</label>
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">Phone</label>
                                <asp:TextBox ID="txtPhone" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">District</label>
                                <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">Upazila</label>
                                <asp:DropDownList ID="ddlUpazila" runat="server" CssClass="form-control"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">Address</label>
                                <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control"></asp:TextBox>
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
                    <h3 class="card-title text-center">Institute List</h3>
                </div>

                <asp:GridView ID="gvSchool" runat="server" AutoGenerateColumns="true"></asp:GridView>

                <div class="card-body">
                    <div class="row">
                        <div class="col-md-12" style="overflow: scroll;">
                            <div class="form-group ">
                                <asp:HiddenField ID="hdnUpdateSchoolId" runat="server" />
                                <asp:GridView ID="gvSchool2" runat="server" CssClass="table table-bordered table-striped" AutoGenerateColumns="true" OnRowCommand="gvSchool_RowCommand" >
                                    <Columns>

                                        <asp:BoundField DataField="EIIN_RegistrationNo" HeaderText="Reg No" />
                                        <asp:BoundField DataField="InstituteName" HeaderText="School Name" />
                                        <asp:BoundField DataField="Email" HeaderText="Email" />
                                        <asp:BoundField DataField="Phone" HeaderText="Phone" />
                    
                                        <asp:BoundField DataField="DistrictId" HeaderText="DistrictName" />
                                        <asp:BoundField DataField="UpazilaId" HeaderText="Upazila Name" />
                                        <asp:BoundField DataField="Address" HeaderText="Address" />
                                        

                                        <asp:TemplateField HeaderText="Action">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hdnSchoolId" runat="server" Value='<%# Eval("SchoolId") %>' />
                                                <asp:ImageButton ID="imgEdit" runat="server" ImageUrl="~/assets/site/images/ico_information.png" CommandName="editc" CommandArgument='<%# Container.DataItemIndex %>' Width="25px" />
                                                <asp:ImageButton ID="imgDelete" runat="server" ImageUrl="~/assets/img/cancel.png" CommandName="deletec" CommandArgument='<%# Container.DataItemIndex %>' OnClientClick="if ( ! ConfirmationMsg()) return false;" meta:resourcekey="imgDelete" Width="25px" />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </div>

</asp:Content>
