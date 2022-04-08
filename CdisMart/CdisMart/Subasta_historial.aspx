<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Subasta_historial.aspx.cs" Inherits="CdisMart.CdisMart.Subasta_historial" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <table>
        <tr>
            <td class="texto">Producto: </td>
            <td>
                <asp:Label runat="server" ID="lblProductoName" CssClass="textoLigth"></asp:Label></td>
        </tr>
        <tr>
            <td class="texto">Descripcion: &nbsp;</td>
            <td>
                <asp:Label runat="server" ID="lblDescription" CssClass="textoLigth"></asp:Label></td>
        </tr>
    </table>
    <br />
    <table>
        <tr>
            <td>
                <asp:Label runat="server" ID="lblMisOfertas" Visible="false" CssClass="texto">Mis ofertas</asp:Label>
            </td>
            <td>
                <asp:Label runat="server" ID="lblMiSuma" Visible="false"></asp:Label>
            </td>
        </tr>
    </table>
    <br />
    <asp:GridView ID="grd_misOfertas" CssClass="contenido" AutoGenerateColumns="false" runat="server">
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
            <td>
                <asp:Label runat="server" ID="lblUser" CssClass="texto">Usuario: &nbsp;</asp:Label></td>
            <td>
                <asp:DropDownList ID="ddlUsuarios" CssClass="listaDropDown" runat="server"
                    AutoPostBack="true" OnSelectedIndexChanged="ddlUsuarios_SelectedIndexChanged" Width="150">
                </asp:DropDownList>
            </td>
            <td>
                <asp:Label runat="server" ID="lblSuma"></asp:Label>
            </td>
        </tr>
    </table>
    <br />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:GridView ID="grd_historial" CssClass="contenido" AutoGenerateColumns="false" runat="server">
                <Columns>
                    <asp:BoundField HeaderText="Usuario" DataField="UserId" />
                    <asp:BoundField HeaderText="Monto" DataField="Amount" />
                    <asp:BoundField HeaderText="Fecha" DataField="BidDate" />
                </Columns>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />

    <script type="text/javascript">

        $(document).ready(function () {

            $(".listaDropDown").chosen();
            
            calcularMiSumaOfertas();
            calcularSumaOfertas();

            function calcularMiSumaOfertas() {

                var isTheTh = true;
                var suma = 0;

                $("#<%=grd_misOfertas.ClientID %> tr").each((e, f) => {

                    if (!isTheTh) {

                        var listAmount = f.children;

                        suma += parseInt(listAmount[1].innerHTML, 10);;

                    } else {
                        isTheTh = false;
                    }
                });

                var space = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" +
                    "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Suma:&nbsp;&nbsp;";
                $('#<%=lblMiSuma.ClientID%>').html(space+ suma.toString());
            }

            function calcularSumaOfertas() {

                var isTheTh = true;
                var suma = 0;

                $("#<%=grd_historial.ClientID %> tr").each((e, f) => {

                    if (!isTheTh) {

                        var listAmount = f.children;

                        suma += parseInt(listAmount[1].innerHTML, 10);;

                    } else {
                        isTheTh = false;
                    }
                });

                $('#<%=lblSuma.ClientID%>').html("&nbsp;&nbsp;&nbsp;&nbsp;Suma:&nbsp;&nbsp;" + suma.toString());
            }

        });

        var manager = Sys.WebForms.PageRequestManager.getInstance();

        manager.add_endRequest(function () {
            $(".listaDropDown").chosen();
        });

    </script>

</asp:Content>
