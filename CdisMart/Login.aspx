<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CdisMart.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>Nombre usuario:</td>
                    <td>
                        <asp:TextBox ID="TextUsuario" runat="server"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td>Contraseña:</td>
                    <td>
                        <asp:TextBox ID="TextPassword" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnIngresar" Text="Ingresar" runat="server" OnClick="btnIngresar_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <a href="User_Alta.aspx">Registrarse</a>
    </form>
</body>
</html>
