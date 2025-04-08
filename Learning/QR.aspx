<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QR.aspx.cs" Inherits="Learning.QR" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

</head>
<body>
  <form id="form1" runat="server">
        <div>
            <asp:Button ID="btnGenerate500" runat="server" Text="500 Rs" OnClick="btnGenerate500_Click" />
            <asp:Button ID="btnGenerate1000" runat="server" Text="1000 Rs" OnClick="btnGenerate1000_Click" />
            <asp:Button ID="btnGenerate2000" runat="server" Text="2000 Rs" OnClick="btnGenerate2000_Click" />
            <br /><br />
            <asp:Image ID="imgQRCode" runat="server" />
            <br /><br />
            <asp:Label ID="lblSerialNumber" runat="server" Font-Bold="True" Font-Size="Large" ForeColor="Blue" />
        </div>
    </form>
</body>
</html>
