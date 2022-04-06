<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Subasta_detalle.aspx.cs" Inherits="CdisMart.CdisMart.Subasta_detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <asp:Label runat="server" ID="lblInfo" Visible="true">Informacion de la subasta</asp:Label>
    <br />
    <br />

    <table>
        <tr>
            <td>ID: </td>
            <td>
                <asp:Label runat="server" ID="lblID"></asp:Label></td>
        </tr>
        <tr>
            <td>Nombre: </td>
            <td>
                <asp:Label runat="server" ID="lblName"></asp:Label></td>
        </tr>
        <tr>
            <td>Description: </td>
            <td>
                <asp:Label runat="server" ID="lblDescription"></asp:Label></td>
        </tr>
        <tr>
            <td>Fecha de inicio: </td>
            <td>
                <asp:Label runat="server" ID="lblFechaInicio"></asp:Label></td>
        </tr>
        <tr>
            <td>Fecha de fin: </td>
            <td>
                <asp:Label runat="server" ID="lblFechaFin"></asp:Label></td>
        </tr>
        <tr>
            <td>Oferta mas alta: </td>
            <td>
                <asp:Label runat="server" ID="lblMejorOferta"></asp:Label></td>
        </tr>
        <tr>
            <td>Ganador: </td>
            <td>
                <asp:Label runat="server" ID="lblWinner"></asp:Label></td>
        </tr>
        <tr>
            <td>Propietario: </td>
            <td>
                <asp:Label runat="server" ID="lblUserId"></asp:Label></td>
        </tr>
        <%--<tr>
            <td></td>
            <td>   
    <asp:Button runat="server" ID="btnPrueba" Text="prueba" OnClick="btnPrueba_Click" /></td>
        </tr>--%>
    </table>


    <br />
    <asp:Label runat="server" ID="lblFechaExpirada" Visible="false">Esta subasta ha expirado <br /></asp:Label>
    <asp:Label runat="server" ID="lblUserOferta" Visible="false">Nota: No puede ofertar en su propia subasta <br /></asp:Label>
    <asp:Label runat="server" ID="lblFueraDeRango" Visible="false"> Fuera de rango <br /></asp:Label>
    <asp:Label runat="server" ID="lblOfertaDebeSerMejor" Visible="false"> La oferta debe ser mayor que la mejor oferta <br /></asp:Label>
    <asp:Label runat="server" ID="lblOfertaInfo" Visible="true">Su oferta</asp:Label>
    <br />
    <table>
        <tr>
            <td>
                <asp:Label runat="server" ID="lblOferta" Text="Cantidad a ofertar:"></asp:Label></td>
            <td>
                <asp:TextBox runat="server" ID="TextOferta" TextMode="Number"></asp:TextBox></td>
        </tr>
        <tr>
            <td></td>
            <td><asp:Button runat="server" ID="btnAgregarApuesta" Text="Ofertar!" OnClick="btnAgregarApuesta_Click"/></td>
        </tr>
    </table>
</asp:Content>
