<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Subastas_s.aspx.cs" Inherits="CdisMart.CdisMart.Subastas_s" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <br />

    <%--<input id="buscar" name="buscar" runat="server" onkeyup="botonOcultoEliminar()" />--%>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <br />
        <asp:GridView CssClass="contenido" ID="grd_subastas" runat="server" AutoGenerateColumns="false" OnRowCommand="grd_subastas_RowCommand">
            <columns>

                <asp:BoundField HeaderText="ID" DataField="AuctionId" />


                <asp:TemplateField>
                    <itemtemplate>
                        <asp:LinkButton runat="server" Text='<%# Eval("ProductoName") %>' CommandName="Name" CommandArgument='<%# Eval("AuctionId") %>'></asp:LinkButton>
                    </itemtemplate>
                </asp:TemplateField>

                <asp:BoundField HeaderText="Descripcion" DataField="Description" />
                <asp:BoundField HeaderText="Inicio" DataField="StartDate" />
                <asp:BoundField HeaderText="Termina" DataField="EndDate" />

                <asp:TemplateField>
                    <itemtemplate>
                        <asp:LinkButton runat="server" Text="Historial" CommandName="Historial" CommandArgument='<%# Eval("AuctionId") %>'></asp:LinkButton>
                    </itemtemplate>
                </asp:TemplateField>

            </columns>

        </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
    

    <div id="botones">

        <asp:Button ID="btnEliminar" runat="server" Text="Get" Style="display: none" OnClick="btnEliminar_Click" />

    </div>

    <script type="text/javascript">

        function botonOcultoEliminar() {

            var boton = document.getElementById('<%=btnEliminar.ClientID%>');

            boton.click();
            moveCursorToEnd();
        }


        $(document).ready(function () {
            console.log("S");

            moveCursorToEnd();

        });

        var manager = Sys.WebForms.PageRequestManager.getInstance();

        manager.add_endRequest(function () {
            var el = document.getElementById("buscar")
            el.focus()
            if (typeof el.selectionStart == "number") {
                el.selectionStart = el.selectionEnd = el.value.length;
            } else if (typeof el.createTextRange != "undefined") {
                var range = el.createTextRange();
                range.collapse(false);
                range.select();
            }
        });


    </script>

</asp:Content>

