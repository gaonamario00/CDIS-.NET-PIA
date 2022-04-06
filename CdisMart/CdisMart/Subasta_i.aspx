<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Subasta_i.aspx.cs" Inherits="CdisMart.CdisMart.Subasta_i" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <br />
    <asp:Label runat="server" Text="Crea tu subasta y gana!"></asp:Label>
    <br />
    <br />
    <table>
        <tr>
            <td>Nombre: </td>
            <td>
                <asp:TextBox runat="server" ID="TextName" MaxLength="50"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_nombre" runat="server" ControlToValidate="TextName"
                    ErrorMessage="Campo nombre es obligatorio" ValidationGroup="vlg1" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>

        </tr>
        <tr>
            <td>Descripcion: </td>
            <td>
                <asp:TextBox runat="server" ID="TextDescription" MaxLength="100"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_descripcion" runat="server" ControlToValidate="TextDescription"
                    ErrorMessage="Campo descrpcion es obligatorio" ValidationGroup="vlg1" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>

        </tr>
        <tr>
            <td>Fecha de inicio: </td>
            <td>
                <asp:TextBox runat="server" ID="TextFechaInicio"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_fechaInicio" runat="server" ControlToValidate="TextFechaInicio"
                    ErrorMessage="Campo fecha de inicio es obligatorio" ValidationGroup="vlg1" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>

        </tr>
        <tr>
            <td>Fecha de fin: </td>
            <td>
                <asp:TextBox runat="server" ID="TextFechaFin"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_fechaFin" runat="server" ControlToValidate="TextFechaFin"
                    ErrorMessage="Campo fecha de inicio es obligatorio" ValidationGroup="vlg1" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>

        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button runat="server" ID="btnAgregar" Text="Agregar subasta" OnClick="btnAgregar_Click" ValidationGroup="vlg1" />
            </td>

        </tr>
    </table>

</asp:Content>
