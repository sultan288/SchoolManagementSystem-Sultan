<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AdminMaster.Master" AutoEventWireup="true" CodeBehind="RegUserList.aspx.cs" Inherits="SchoolManagementSystem.dashboard.RegUserList" %>

<%@ Register Src="~/ResponseMessage.ascx" TagPrefix="uc1" TagName="ResponseMessage" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="content-wrapper">
        <div class="container">
            <!-- general form elements -->
            <div class="card card-primary mt-2">
                <div class="card-header">
                    <h3 class="card-title text-center">User Registration Details</h3>
                </div>
                <!--Error Message-->
                <uc1:ResponseMessage runat="server" ID="rmUL" />

                <div class="card-body">
                    <div class="row">
                        
                            <asp:GridView ID="gvRegList" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-hover rounded-3"
                                OnRowCommand="gvRegList_RowCommand" 
                                OnRowCancelingEdit="gvRegList_RowCancelingEdit" 
                                OnRowEditing="gvRegList_RowEditing"
                                OnRowUpdating="gvRegList_RowUpdating"
                                >
                                <Columns>
                                    <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                                    <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                                    <asp:BoundField DataField="UserName" HeaderText="User Name" />
                                    <asp:BoundField DataField="Email" HeaderText="Email" />
                                    <asp:BoundField DataField="ContactNo" HeaderText="Contact No" />
                                    <asp:BoundField DataField="Address" HeaderText="Address" />

                                    <asp:TemplateField HeaderText="Action">
                                        <ItemTemplate>
                                            <asp:Button runat="server" Text="Edit" CommandName="editc" CommandArgument="" />
                                            <asp:Button runat="server" Text="Delete" CommandName="deletec" CommandArgument="" />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>
                            </asp:GridView>
                        
                     </div>                  
                </div>
            </div>
        </div>
    </div>


</asp:Content>
