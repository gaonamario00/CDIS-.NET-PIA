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
                        <asp:TextBox ID="TextUsuario" runat="server" MaxLength="10"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_usuario" runat="server" ControlToValidate="TextUsuario"
                            ErrorMessage="Campo de nombre de usuario es obligatorio" ValidationGroup="vlg1" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="rev_usuario" runat="server" ErrorMessage="Debe de contener solo numeros y/o letras ( de 4 a 10 caracteres)"
                            ControlToValidate="TextUsuario" ValidationExpression="^[a-zA-Z0-9]{4,10}"
                            ValidationGroup="vlg1" Display="Dynamic"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>Contraseña:</td>
                    <td>
                        <asp:TextBox ID="TextPassword" runat="server" TextMode="Password" MaxLength="10"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_password" runat="server" ControlToValidate="TextPassword"
                            ErrorMessage="Campo de contraseña es obligatorio" ValidationGroup="vlg1" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="rev_password" runat="server" ErrorMessage="Debe de contener solo numeros y/o letras ( de 6 a 10 caracteres)"
                            ControlToValidate="TextPassword" ValidationExpression="^[a-zA-Z0-9]{6,10}"
                            ValidationGroup="vlg1" Display="Dynamic"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnIngresar" Text="Ingresar" runat="server" OnClick="btnIngresar_Click" ValidationGroup="vlg1"/>
                    </td>
                </tr>
            </table>
        </div>
        <a href="User_Alta.aspx">Registrarse</a>
    </form>
</body>
</html>
