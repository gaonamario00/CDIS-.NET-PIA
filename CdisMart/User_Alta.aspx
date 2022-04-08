<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User_Alta.aspx.cs" Inherits="CdisMart.User_Alta" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <link href="Content/user_alta.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
             <div class="input-group">
                <span id="sizing-addon2">
                    <asp:Image ID="imgWarning" runat="server" ImageUrl="../icons/advertencia.png" Height="20px" Width="20px" Visible="false" />
                </span>
                <asp:Label runat="server" ID="lblError" Visible="false"></asp:Label>
            </div>
            <%--<asp:Label runat="server" CssClass="center">Registrarse</asp:Label>--%>
            
            <table>
                <tr>
                    <td class="texto">Nombre:</td>
                    <td>
                        <asp:TextBox ID="TextNombre" CssClass="inputs" runat="server" MaxLength="50"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_nombreCompleto" runat="server" ControlToValidate="TextNombre"
                            ValidationGroup="vlg1"></asp:RequiredFieldValidator>
                    </td>
                    <td>
                        <asp:Image runat="server" ImageUrl="icons/informacion.png" Height="20px" Width="20px" ToolTip="Campo obligatorio" /></td>

                </tr>
                <tr>
                    <td class="texto">Email: </td>
                    <td>
                        <asp:TextBox ID="TextEmail" CssClass="inputs" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_email" runat="server" ControlToValidate="TextEmail"
                            ValidationGroup="vlg1" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="rev_nombreCompleto" runat="server"
                            ControlToValidate="TextEmail" ValidationExpression="[a-z]+[0-9]*@[a-z]+[.][a-z]+" ValidationGroup="vlg1" Display="Dynamic"></asp:RegularExpressionValidator>
                    </td>
                    <td>
                        <asp:Image runat="server" ImageUrl="icons/informacion.png" Height="20px" Width="20px" ToolTip="Debe tener el formato example@something.com (las letras deben ser minusculas)" />
                    </td>
                </tr>
                <tr>
                    <td class="texto">Nombre usuario: </td>
                    <td>
                        <asp:TextBox ID="TextUsuario" CssClass="inputs" runat="server" MaxLength="10"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_userName" runat="server" ControlToValidate="TextUsuario"
                             ValidationGroup="vlg1" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="rev_nombre" runat="server"
                            ControlToValidate="TextUsuario" ValidationExpression="^[a-zA-Z0-9]{4,10}"
                            ValidationGroup="vlg1" Display="Dynamic"></asp:RegularExpressionValidator>
                    </td>
                    <td>
                        <asp:Image runat="server" ImageUrl="icons/informacion.png" Height="20px" Width="20px" ToolTip="Debe de contener solo numeros y/o letras ( de 4 a 10 caracteres)" /></td>

                </tr>
                <tr>
                    <td class="texto">Contraseña: </td>
                    <td>
                        <asp:TextBox ID="TextPassword" CssClass="inputs" runat="server" MaxLength="10" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_password" runat="server" ControlToValidate="TextPassword"
                             ValidationGroup="vlg1" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="rev_password" runat="server"
                            ControlToValidate="TextPassword" ValidationExpression="^[a-zA-Z0-9]{6,10}"
                            ValidationGroup="vlg1" Display="Dynamic"></asp:RegularExpressionValidator>
                    </td>
                    <td>
                        <asp:Image runat="server" ImageUrl="icons/informacion.png" Height="20px" Width="20px" ToolTip="Debe de contener solo numeros y/o letras ( de 6 a 10 caracteres)" /></td>

                </tr>
                <tr>
                    <td class="texto">Confirmar contraseña:</td>
                    <td>
                        <asp:TextBox ID="TextPassword2" CssClass="inputs" runat="server" MaxLength="10" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv_confirmarPassword" runat="server" ControlToValidate="TextPassword2"
                             ValidationGroup="vlg1" Display="Dynamic"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="rev_password2" runat="server"
                            ControlToValidate="TextPassword2" ValidationExpression="^[a-zA-Z0-9]{6,10}"
                            ValidationGroup="vlg1" Display="Dynamic"></asp:RegularExpressionValidator>
                    </td>
                    <td>
                        <asp:Image runat="server" ImageUrl="icons/informacion.png" Height="20px" Width="20px" ToolTip="Debe de coincidir con el campo anterior" /></td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnRegistrar" Text="Registrarse" runat="server" OnClick="btnregistrarse_Click"  />
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <a style="padding:7px" href="Login.aspx">Iniciar Sesion</a>
                    </td>
                    <td></td>
                </tr>
            </table>
        </div>
        
    </form>
</body>
</html>
