<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User_Alta.aspx.cs" Inherits="CdisMart.User_Alta" %>

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
                    <td>Nombre completo:</td>
                    <td>
                        <asp:TextBox ID="TextNombre" runat="server"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td>Email:</td>
                    <td>
                        <asp:TextBox ID="TextEmail" runat="server"></asp:TextBox>
                    </td>
                </tr>
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
                    <td>Confirmar contraseña:</td>
                    <td>
                        <asp:TextBox ID="TextPassword2" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnregistrarse" Text="Registrarse" runat="server" OnClick="btnregistrarse_Click"/>
                    </td>
                </tr>
            </table>
        </div>
         <a href="Login.aspx">Iniciar Sesion</a>
    </form>
</body>
</html>
