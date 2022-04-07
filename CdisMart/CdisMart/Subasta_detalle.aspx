<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Subasta_detalle.aspx.cs" Inherits="CdisMart.CdisMart.Subasta_detalle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <asp:Label runat="server" ID="lblInfo" Visible="true" CssClass="texto">Informacion de la subasta</asp:Label>
    <br />
    <br />

    <table>
        <tr>
            <td class="texto" >ID: </td>
            <td>
                <asp:Label runat="server" ID="lblID" CssClass="textoLigth"></asp:Label></td>
        </tr>
        <tr>
            <td class="texto">Producto: </td>
            <td>
                <asp:Label runat="server" ID="lblName" CssClass="textoLigth"></asp:Label></td>
        </tr>
        <tr>
            <td class="texto">Descripcion: </td>
            <td>
                <asp:Label runat="server" ID="lblDescription" CssClass="textoLigth"></asp:Label></td>
        </tr>
        <tr>
            <td class="texto">Fecha de inicio:  &nbsp;</td>
            <td>
                <asp:Label runat="server" ID="lblFechaInicio" CssClass="textoLigth"></asp:Label></td>
        </tr>
        <tr>
            <td class="texto">Fecha de fin: </td>
            <td>
                <asp:Label runat="server" ID="lblFechaFin" CssClass="textoLigth"></asp:Label></td>
        </tr>
        <tr>
            <td class="texto">Oferta mas alta: </td>
            <td>
                <asp:Label runat="server" ID="lblMejorOferta" CssClass="textoLigth"></asp:Label></td>
        </tr>
        <tr>
            <td class="texto">Ganador: </td>
            <td>
                <asp:Label runat="server" ID="lblWinner" CssClass="textoLigth"></asp:Label></td>
        </tr>
        <tr>
            <td class="texto">Propietario: </td>
            <td>
                <asp:Label runat="server" ID="lblPropiertario" CssClass="textoLigth"></asp:Label></td>
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
    <asp:Label runat="server" ID="lblOfertaInfo" Visible="true" CssClass="texto">Su oferta</asp:Label>
    <br />
    <table>
        <tr>
            <td>
                <asp:Label runat="server" ID="lblOferta" Text="Cantidad a ofertar:  &nbsp;" class="texto"></asp:Label></td>
            <td>
                <asp:TextBox runat="server" ID="TextOferta" TextMode="Number" CssClass="inputs"></asp:TextBox></td>
        </tr>
        <tr>
            <td></td>
            <td colspan="2" style="text-align: center;"><asp:Button runat="server" ID="btnAgregarApuesta" CssClass="boton" Text="Ofertar!" OnClick="btnAgregarApuesta_Click"/></td>
        </tr>
    </table>
</asp:Content>
