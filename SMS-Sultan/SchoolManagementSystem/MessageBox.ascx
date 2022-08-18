<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MessageBox.ascx.cs" Inherits="SchoolManagementSystem.MessageBox" %>

<link rel="stylesheet" href="../assets/dist/css/adminlte.min.css">
<script src="//cdn.jsdelivr.net/npm/sweetalert2@11"></script>




<asp:Panel ID="pnlSuccess" runat="server">
    <div>
        <asp:Label ID="lblSuccess" runat="server" Text="Submit" CssClass="btn btn-danger"></asp:Label>
    </div>
</asp:Panel>
