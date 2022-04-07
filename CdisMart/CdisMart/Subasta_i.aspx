<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Subasta_i.aspx.cs" Inherits="CdisMart.CdisMart.Subasta_i" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <br />
    <asp:Label runat="server" Text="Crea tu subasta y gana!" CssClass="subtitlo"></asp:Label>

    <br />
    <br />
    <table>
        <tr>
            <td class="texto">Nombre: </td>
            <td>
                <asp:TextBox runat="server" CssClass="inputs" ID="TextName" MaxLength="50"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_nombre" runat="server" ControlToValidate="TextName"
                    ErrorMessage="Campo nombre es obligatorio" ValidationGroup="vlg1" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>

        </tr>
        <tr>
            <td class="texto">Descripcion: </td>
            <td>
                <asp:TextBox runat="server" CssClass="inputs" ID="TextDescription" MaxLength="100"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_descripcion" runat="server" ControlToValidate="TextDescription"
                    ErrorMessage="Campo descrpcion es obligatorio" ValidationGroup="vlg1" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>

        </tr>
        <tr>
            <td class="texto">Fecha de inicio:  &nbsp;</td>
            <td>
                <asp:TextBox runat="server" CssClass="inputs" ID="TextFechaInicio" AutoCompleteType="Disabled"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_fechaInicio" runat="server" ControlToValidate="TextFechaInicio"
                    ErrorMessage="Campo fecha de inicio es obligatorio" ValidationGroup="vlg1" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>

        </tr>
        <tr>
            <td class="texto">Fecha de fin: </td>
            <td>
                <asp:TextBox runat="server" CssClass="inputs" ID="TextFechaFin" AutoCompleteType="Disabled"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_fechaFin" runat="server" ControlToValidate="TextFechaFin"
                    ErrorMessage="Campo fecha de fin es obligatorio" ValidationGroup="vlg1" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>

        </tr>
        <tr>
            <td></td>
            <td colspan="2" style="text-align: center;">
                <asp:Button runat="server" CssClass="boton" ID="btnAgregrSubasta" Text="Ofertar!" OnClick="btnAgregar_Click" ValidationGroup="vlg1" />
            </td>
        </tr>
    </table>

    <script type="text/javascript">

        $(document).ready(function () {

            $.datetimepicker.setLocale('es');
            $('#MainContent_TextFechaInicio').datetimepicker({
                //value: '06/04/2022 15:30',
                step: 10,
            });

            $.datetimepicker.setLocale('es');
            $('#MainContent_TextFechaFin').datetimepicker({
                //value: '06/04/2022 15:30',
                step: 10,
            });

        });

    </script>

</asp:Content>
