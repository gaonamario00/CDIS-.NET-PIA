<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Subasta_historial.aspx.cs" Inherits="CdisMart.CdisMart.Subasta_historial" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <table>
        <tr>
            <td class="texto">Producto: </td>
            <td><asp:Label runat="server" ID="lblProductoName" CssClass="textoLigth"></asp:Label></td>
        </tr>
        <tr>
            <td class="texto">Descripcion: &nbsp;</td>
            <td><asp:Label runat="server" ID="lblDescription" CssClass="textoLigth"></asp:Label></td>
        </tr>
    </table>
    <br />
    <asp:Label runat="server" ID="lblMisOfertas" Visible="false" CssClass="texto">Mis ofertas</asp:Label>
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
            <td><asp:Label runat="server" ID="lblUser" Visible="false">Usuario: &nbsp;</asp:Label></td>
            <td>
                <asp:DropDownList ID="ddlUsuarios" CssClass="listaDropDown" runat="server" 
                    AutoPostBack="true" OnSelectedIndexChanged="ddlUsuarios_SelectedIndexChanged" Width="150"></asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td><asp:Label runat="server" ID="lbl" Visible="true"></asp:Label></td>
            <td></td>
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

           <%-- $("#<%=grd_misOfertas.ClientID %> tr").each((a) => {
                console.log(a)
            });--%>

            calcularSumaOfertas();

            function calcularSumaOfertas() {

                var isTheTh = true;
                var suma = 0;

                $("#<%=grd_historial.ClientID %> tr").each((e, f) => {

                    if (!isTheTh) {

                        var listAmount = f.children;

                        suma += listAmount[1].innerHTML;

                        //console.log(listAmount[1].innerHTML);

                            
                    } else {
                            isTheTh = false;
                    }
                });
                // TODO
                //Setear valor del label
                $("#MainContent_lbl").attr("value") = suma;

                console.log($("#MainContent_lbl").attr("value"));

                <%--var grid = document.getElementById("<%=grd_misOfertas.ClientID%>");
                var suma = 0;
                //for (var i = 0; i < grid.rows.length; i++) {
                    if (!this.rowIndex) return;
                    //var Cell = grid.rows[i].getElementsByTagName("input");
                    //console.log(grid.rows[i].getElementById);
                    suma += $(this).find("td:last").html();
                    console.log(suma);
                //}--%>
            }

        });

        var manager = Sys.WebForms.PageRequestManager.getInstance();

        manager.add_endRequest(function () {
            $(".listaDropDown").chosen();
        //    $("#ddlUsuarios").css.apply("");
        });

    </script>

</asp:Content>
