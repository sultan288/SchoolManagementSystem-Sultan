<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMaster.Master" AutoEventWireup="true" CodeBehind="EmployeeInfo2.aspx.cs" Inherits="SchoolManagementSystem.Setup.EmployeeInfo" %>

<%@ Register Src="~/ResponseMessage.ascx" TagPrefix="uc1" TagName="ResponseMessage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

     <script type="text/javascript">

        
     </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="content-wrapper">
        <div class="container">
            <!-- general form elements -->
            <div class="card card-primary">
                <div class="card-header">
                    <h3 class="card-title">Employee Info</h3>
                </div>

                <uc1:ResponseMessage runat="server" ID="rmEmployee" />
                
                <!-- /.card-header -->
                <!-- form start -->

                <div class="card-body">
                    <div class="row">
                        
                        <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">First Name</label>
                                <asp:TextBox ID="txtFirstName" runat="server" placeholder="Enter First Name" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">Last Name</label>
                                <asp:TextBox ID="txtLastName" runat="server" placeholder="Enter Last Name" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">Employee Type</label>
                                <asp:DropDownList ID="ddlEmpType" runat="server" placeholder="Enter Employee Type" CssClass="form-control">
                                    <asp:ListItem Value="0">Select...</asp:ListItem>
                                    <asp:ListItem Value="Staff">Staff</asp:ListItem>
                                    <asp:ListItem Value="General">General</asp:ListItem>
                                    <asp:ListItem Value="Clerk">Clerk</asp:ListItem>
                                    
                                </asp:DropDownList>
                               
                            </div>
                        </div>
                        
                        <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">Designation Name</label>
                                <asp:DropDownList ID="ddlDesigName" runat="server" placeholder="Enter Designation Name" CssClass="form-control"></asp:DropDownList>
                               
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">Starting Salary</label>
                                <asp:TextBox ID="txtStartingSalary" runat="server" placeholder="Enter Starting Salary" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">Nationality</label>
                                <asp:DropDownList ID="ddlNationality" runat="server" placeholder="Enter Nationality" CssClass="form-control">
                                    <asp:ListItem Value="0">Select...</asp:ListItem>
                                    <asp:ListItem Value="Bangladeshi">Bangladeshi</asp:ListItem>
                                    <asp:ListItem Value="Indian">Indian</asp:ListItem>
                                    <asp:ListItem Value="Nepal">Nepal</asp:ListItem>
                                </asp:DropDownList>                             
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">NID</label>
                                <asp:TextBox ID="txtNID" runat="server" placeholder="Enter NID No." CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">DOB</label>
                                <asp:TextBox ID="txtDOB" runat="server" placeholder="dd/mm/yyyy" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>                     
                        <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">Joining Date</label>
                                <asp:TextBox ID="txtJoiningDate" TextMode="Date" runat="server" placeholder="dd/mm/yyyy" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">Religion Name</label>
                                <asp:DropDownList ID="ddlReligion" runat="server" placeholder="Enter Religion Name" CssClass="form-control">                                  
                                </asp:DropDownList>                                
                            </div>
                        </div>                       
                        <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">District Name</label>
                                <asp:DropDownList ID="ddlDistrict" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged1" >
                         
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">Upazila Name</label>
                                <asp:DropDownList ID="ddlUpazila" runat="server" CssClass="form-control" >
                                    
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">Address</label>
                                <asp:TextBox ID="txtAddress" runat="server" placeholder="Enter Address" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                         <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">Email</label>
                                <asp:TextBox ID="txtEmail" runat="server" placeholder="Enter Email" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                         <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">Contact No</label>
                                <asp:TextBox ID="txtContactNo" runat="server" placeholder="Enter Contact No" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>     
                         <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">Gender</label>
                                <asp:DropDownList ID="ddlGender" runat="server" CssClass="form-control">
                                    <asp:ListItem Value="0">Select...</asp:ListItem>
                                    <asp:ListItem Value="Male">Male</asp:ListItem>
                                    <asp:ListItem Value="Female">Female</asp:ListItem>
                                    <asp:ListItem Value="Other">Other</asp:ListItem>
                                </asp:DropDownList>                  
                            </div>
                        </div>
                         <div class="col-md-4">
                            <div class="form-group ">
                                <label class="form-label">Blood Group</label>
                                <asp:DropDownList ID="ddlBloodGroup" runat="server" placeholder="Enter Blood Group" CssClass="form-control">
                                    <asp:ListItem Value="0">Select...</asp:ListItem>
                                    <asp:ListItem Value="0+">0+</asp:ListItem>
                                    <asp:ListItem Value="A+">A+</asp:ListItem>
                                    <asp:ListItem Value="B+">B+</asp:ListItem>
                                    <asp:ListItem Value="A-">A-</asp:ListItem>
                                    <asp:ListItem Value="B-">B-</asp:ListItem>
                                </asp:DropDownList>
                                
                            </div>
                        </div>     
                       
                        <div class="col-md-2">
                            <div class="form-group ">
                                <label class="form-label" > &nbsp;</label>
                                 <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary form-control" Text="Save" OnClick="btnSave_Click1" />
                            </div>
                        </div>

                    </div>


                </div>

                <div class="card-header ">
                    <h3 class="card-title text-center">Employee List</h3>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-12" style="overflow: scroll;">
                            <div class="form-group ">
                                <asp:HiddenField ID="hdnUpdateEmpId" runat="server" />
                                <asp:GridView ID="gvEmployee" runat="server" CssClass="table table-bordered table-striped" AutoGenerateColumns="False" OnRowCommand="gvEmployee_RowCommand" >
                                    <columns>
                                                                               
                                        <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                                        <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                                        <asp:BoundField DataField="EmployeeType" HeaderText="Employee Type" />
                                        <asp:BoundField DataField="DesignationName" HeaderText="Designation Name" />
                                        <asp:BoundField DataField="StartingSalary" HeaderText="Starting Salary" />
                                        <asp:BoundField DataField="Nationality" HeaderText="Nationality" />
                                        <asp:BoundField DataField="DOB" HeaderText="DOB" />
                                        <asp:BoundField DataField="JoiningDate" HeaderText="JoiningDate" />
                                        <asp:BoundField DataField="ReligionName" HeaderText="Religion" />
                                        <asp:BoundField DataField="DistrictName" HeaderText="District" />
                                        <asp:BoundField DataField="UpazilaName" HeaderText="Upazila" />
                                        <asp:BoundField DataField="Address" HeaderText="Address" />
                                        <asp:BoundField DataField="Email" HeaderText="Email" />
                                        <asp:BoundField DataField="ContactNo" HeaderText="ContactNo" />
                                        <asp:BoundField DataField="Gender" HeaderText="Gender" />
                                        <asp:BoundField DataField="BloodGroup" HeaderText="BloodGroup" />
                                                                                                                                                          
                                        <asp:TemplateField HeaderText="Action">
                                            <itemtemplate>
                                                <asp:HiddenField ID="hdnEmployeeId" runat="server" Value='<%# Eval("EmployeeId") %>' />
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
