<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Subastas_s.aspx.cs" Inherits="CdisMart.CdisMart.Subastas_s" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <br />

    <asp:GridView CssClass="contenido" ID="grd_subastas" runat="server" AutoGenerateColumns="false" OnRowCommand="grd_subastas_RowCommand">

        <Columns>
           
            <asp:BoundField HeaderText="ID" DataField="AuctionId" />


            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton runat="server" Text='<%# Eval("ProductoName") %>' CommandName="Name" CommandArgument='<%# Eval("AuctionId") %>' ></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:BoundField HeaderText="Descripcion" DataField="Description" />
            <asp:BoundField HeaderText="Inicio" DataField="StartDate" />
            <asp:BoundField HeaderText="Termina" DataField="EndDate" />

             <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton runat="server" Text="Historial" CommandName="Historial" CommandArgument='<%# Eval("AuctionId") %>' ></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>

            <%-- historial --%>
        </Columns>

    </asp:GridView>

</asp:Content>

