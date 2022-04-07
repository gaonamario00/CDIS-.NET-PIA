<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Subasta_historial.aspx.cs" Inherits="CdisMart.CdisMart.Subasta_historial" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <table>
        <tr>
            <td>Producto: </td>
            <td><asp:Label runat="server" ID="lblProductoName"></asp:Label></td>
        </tr>
        <tr>
            <td>Descripcion: &nbsp;</td>
            <td><asp:Label runat="server" ID="lblDescription"></asp:Label></td>
        </tr>
    </table>
    <br />
    <asp:Label runat="server" ID="lblMisOfertas" Visible="false">Mis ofertas</asp:Label>
    <br />
    <asp:GridView ID="grd_misOfertas" AutoGenerateColumns="false" runat="server">
        <Columns>
            <asp:BoundField HeaderText="Usuario" DataField="UserId" />
            <asp:BoundField HeaderText="Monto" DataField="Amount" />
            <asp:BoundField HeaderText="Fecha" DataField="BidDate" />
        </Columns>
    </asp:GridView>
    <br />
    <asp:Label runat="server" ID="lblListIsEmpty" Visible="false"></asp:Label>
    <table>
        <tr>
            <td><asp:Label runat="server" ID="lblUser" Visible="false">Usuario: &nbsp;</asp:Label></td>
            <td>
                <asp:DropDownList ID="ddlUsuarios" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlUsuarios_SelectedIndexChanged"></asp:DropDownList>
            </td>
        </tr>
    </table>
        <br />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:GridView ID="grd_historial" AutoGenerateColumns="false" runat="server">
                <Columns>
                    <asp:BoundField HeaderText="Usuario" DataField="UserId" />
                    <asp:BoundField HeaderText="Monto" DataField="Amount" />
                    <asp:BoundField HeaderText="Fecha" DataField="BidDate" />
                </Columns>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
</asp:Content>
