<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Subasta_historial.aspx.cs" Inherits="CdisMart.CdisMart.Subasta_historial" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <br />
    <table>
        <tr>
            <td>Usuario: &nbsp;</td>
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

</asp:Content>
