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
            <asp:Label runat="server" ID="lblUserNameExist" Visible="false"></asp:Label>
            <asp:Label runat="server" ID="lblPass" Visible="false"></asp:Label>

            <table>
                <tr>
                    <td>Nombre completo: </td>
                    <td>
                        <asp:TextBox ID="TextNombre" runat="server" MaxLength="50" ></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_nombreCompleto" runat="server" ControlToValidate="TextNombre"
                             ErrorMessage="Campo de Nombre obligatorio" ValidationGroup="vlg1"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                 <tr>
                    <td>Email: </td>
                    <td>
                        <asp:TextBox ID="TextEmail" runat="server"></asp:TextBox>
                           <asp:RequiredFieldValidator ID="rfv_email" runat="server" ControlToValidate="TextEmail"
                             ErrorMessage="Campo de Email obligatorio" ValidationGroup="vlg1" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="rev_nombreCompleto" runat="server" ErrorMessage="Debe tener el formato example@something.com (las letras deben ser minusculas)"
                             ControlToValidate="TextEmail" ValidationExpression="[a-z]+[0-9]*@[a-z]+[.][a-z]+" ValidationGroup="vlg1" Display="Dynamic"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>Nombre usuario: </td>
                    <td>
                        <asp:TextBox ID="TextUsuario" runat="server" MaxLength="10"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="rfv_userName" runat="server" ControlToValidate="TextUsuario"
                             ErrorMessage="Campo de Nombre de usuario obligatorio" ValidationGroup="vlg1" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="rev_nombre" runat="server" ErrorMessage="Debe de contener solo numeros y/o letras ( de 4 a 10 caracteres)"
                            ControlToValidate="TextUsuario" ValidationExpression="^[a-zA-Z0-9]{4,10}"
                            ValidationGroup="vlg1" Display="Dynamic"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                 <tr>
                    <td>Contraseña: </td>
                    <td>
                        <asp:TextBox ID="TextPassword" runat="server" MaxLength="10" TextMode="Password"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="rfv_password" runat="server" ControlToValidate="TextPassword"
                             ErrorMessage="Campo de contraseña obligatorio" ValidationGroup="vlg1" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="rev_password" runat="server" ErrorMessage="Debe de contener solo numeros y/o letras ( de 6 a 10 caracteres)"
                            ControlToValidate="TextPassword" ValidationExpression="^[a-zA-Z0-9]{6,10}"
                            ValidationGroup="vlg1" Display="Dynamic"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                  <tr>
                    <td>Confirmar contraseña:  &nbsp;</td>
                    <td>
                        <asp:TextBox ID="TextPassword2" runat="server" MaxLength="10" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_confirmarPassword" runat="server" ControlToValidate="TextPassword2"
                             ErrorMessage="Campo de confirmar contraseña obligatorio" ValidationGroup="vlg1" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="rev_password2" runat="server" ErrorMessage="Debe de contener solo numeros y/o letras ( de 6 a 10 caracteres)"
                            ControlToValidate="TextPassword2" ValidationExpression="^[a-zA-Z0-9]{6,10}"
                            ValidationGroup="vlg1" Display="Dynamic"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnregistrarse" Text="Registrarse" runat="server" OnClick="btnregistrarse_Click" ValidationGroup="vlg1"/>
                    </td>
                </tr>
            </table>
        </div>
         <a href="Login.aspx">Iniciar Sesion</a>
    </form>
</body>
</html>
