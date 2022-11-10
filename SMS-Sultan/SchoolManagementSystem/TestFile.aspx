<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestFile.aspx.cs" Inherits="SchoolManagementSystem.TestFile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>    

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.6.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.13/js/select2.min.js" integrity="sha512-2ImtlRlf2VVmiGZsjm9bEyhjGW4dU7B6TNwh/hx/iSByxNENtj3WVE6o/9Lj4TJeVXPi4bnOIMXFIJJAeufa0A==" crossorigin="anonymous" referrerpolicy="no-referrer"></script>
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/select2/4.0.13/css/select2.min.css" integrity="sha512-nMNlpuaDPrqlEls3IX/Q56H36qvBASwb3ipuo3MxeWbsQB1881ox0cRv7UPTgBlriqoynt35KjEwgGUeUXIPnw==" crossorigin="anonymous" referrerpolicy="no-referrer" />

    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous"/>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>

    <script src="JsFile.js"></script>
    <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
<%--            <select id="select2div" class="form-control">
                <option value="0">Select...</option>
                <option value="1">Dhaka</option>
                <option value="2">Khulna</option>
                <option value="3">Sylhet</option>
                <option value="4">Rangpur</option>
                <option value="5">Barisal</option>
                <option value="6">Chattogram</option>
                <option value="7">Rajshahi</option>
                <option value="8">Mymensing</option>
            </select>--%>

            <asp:DropDownList ID="ddlasp" runat="server">
                <asp:ListItem Value="0">Select...</asp:ListItem>
                <asp:ListItem Value="1">Primary</asp:ListItem>
                <asp:ListItem Value="2">Secondary</asp:ListItem>
                <asp:ListItem Value="3">College</asp:ListItem>
                <asp:ListItem Value="4">Public University</asp:ListItem>
                <asp:ListItem Value="5">Private University</asp:ListItem>
                <asp:ListItem Value="6">National University</asp:ListItem>
                <asp:ListItem Value="7">Madrasa</asp:ListItem>
                <asp:ListItem Value="8">Technical</asp:ListItem>
            </asp:DropDownList>


        </div>
        <div>
            <asp:Button ID="Button1" runat="server" Text="Alert" OnClick="Button1_Click" />
        </div>

    </form>
</body>
</html>
