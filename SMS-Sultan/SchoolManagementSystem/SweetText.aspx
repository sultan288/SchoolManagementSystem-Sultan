<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SweetText.aspx.cs" Inherits="SchoolManagementSystem.SweetText" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SweetText</title>
    

    <link rel='stylesheet' href='https://cdn.jsdelivr.net/npm/sweetalert2@7.12.15/dist/sweetalert2.min.css'></link>  

   <script type="text/javascript">    
       function successalert() {
           swal({
               title: 'Congratulations!',
               text: 'Your message has been succesfully sent',
               type: 'success'
           });
       }
   </script>    
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="button" runat="server" Text="Alert" OnClientClick="successalert()" />
        </div>
    </form>
</body>
</html>
