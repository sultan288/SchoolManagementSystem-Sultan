<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AuthMaster.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="SchoolManagementSystem.dashboard.login" %>

<%@ Register Src="~/ResponseMessage.ascx" TagPrefix="uc1" TagName="ResponseMessage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="login-box">
        <div class="login-logo">
            <a href="#"><b>KR </b>Model School</a>
        </div>
        <!-- /.login-logo -->
        <div class="card">
            <uc1:ResponseMessage runat="server" ID="rmMsg" />
            <div class="card-body login-card-body">
                <p class="login-box-msg">Sign in to start your session</p>

                <div class="input-group mb-3">
                    <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" placeholder="Username"></asp:TextBox>
                    <div class="input-group-append">
                        <div class="input-group-text">
                            <span class="fas fa-envelope"></span>
                        </div>
                    </div>
                </div>
                <div class="input-group mb-3">
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" placeholder="Password" TextMode="Password"></asp:TextBox>
                    <div class="input-group-append">
                        <div class="input-group-text">
                            <span class="fas fa-lock"></span>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-8">
                        <div class="icheck-primary">
                            <asp:CheckBox ID="chkRememberMe" runat="server" CssClass="form-check-input ml-1" />

                            <label for="remember" class="ml-4 mt-1">
                                Remember Me
                            </label>
                        </div>
                    </div>
                    <!-- /.col -->
                    <div class="col-4">
                        <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-primary btn-block" Text="Login" OnClick="btnLogin_Click" />

                    </div>
                    <!-- /.col -->
                </div>


                <%--  <div class="social-auth-links text-center mb-3">
        <p>- OR -</p>
        <a href="#" class="btn btn-block btn-primary">
          <i class="fab fa-facebook mr-2"></i> Sign in using Facebook
        </a>
        <a href="#" class="btn btn-block btn-danger">
          <i class="fab fa-google-plus mr-2"></i> Sign in using Google+
        </a>
      </div>--%>
                <!-- /.social-auth-links -->

                <p class="mb-1">
                    <a href="forgot-password.html">I forgot my password</a>
                </p>
                <p class="mb-0">
                    <%-- <a href="#RegModal" class="text-center" data-toggle="modal" data-target="#myModal"><span class="fs-4"><strong>Register</strong></span></a> a new membership--%>
                    <%--<button data-bs-toggle="modal" data-bs-target="#myModal" class="btn btn-primary">Register</button>--%>
                </p>

                <!-- Button trigger modal -->
                <button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#exampleModal">
                    Register
                </button>

                <!-- Modal -->
                <div class="modal fade rounded-3" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
                    <div class="modal-dialog">
                        <div class="modal-content">
                           
                                <div class="bg-gradient-navy">
                                    <h5 class="text-center my-1 py-1 fs-3" id="exampleModalLabel">Register Now</h5>
                                </div>
                                
                           
                            <div class="modal-body">

                                <div class="row">
                                    <div class="col-md-12">
                                        <div class="row">
                                            <div class="col-md-6">
                                                <label class="form-label">First Name</label>
                                                <asp:TextBox ID="txtFirstName" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-md-6">
                                                <label class="form-label">Last Name</label>
                                                <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <label class="form-label">User Name</label>
                                                <asp:TextBox ID="txtUName" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-md-6">
                                                <label class="form-label">Contact No.</label>
                                                <asp:TextBox ID="txtContactNo" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-md-6">
                                                <label class="form-label">Email</label>
                                                <asp:TextBox ID="TextEmail" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-md-6">
                                                <label class="form-label">Address</label>
                                                <asp:TextBox ID="TextAddress" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>


                                    </div>
                                </div>
                            </div>
                            <div class="modal-footer position-relative">                                   
                                <button type="button" class="btn-close bg-danger p-3 position-absolute bottom-0 start-0" data-bs-dismiss="modal" aria-label="Close"></button>
                                 <asp:Button ID="btnReg" runat="server" Text="Register" CssClass="btn bg-gradient-success" OnClick="btnReg_Click" />
                           </div>
                       
                            
                        </div>
                    </div>
                </div>


            </div>
            <!-- /.login-card-body -->
        </div>
    </div>
    <!-- /.login-box -->
</asp:Content>
