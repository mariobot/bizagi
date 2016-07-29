<%@ Page Title="" Language="C#" MasterPageFile="~/Page.Master" AutoEventWireup="true" CodeBehind="Page2.aspx.cs" Inherits="Bizagi.Page2" ValidateRequest="false" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderName" runat="server">
    
    Verificar Archivo
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <strong>Verificando: </strong> 
    <asp:Label Text="" ID="lblFile" Font-Size="Larger" ForeColor="Gray" runat="server" />
    <br />
    <asp:TextBox ID="txtConsole" runat="server" TextMode="MultiLine" Columns="60" Rows="12" ></asp:TextBox>
    <table>
        <tr>
            <td>
                <asp:Button Text="Validar Archivo" runat="server" ID="btnValidate" OnClick="btnValidate_Click" />
            </td>
            <td></td>
            <td></td>
            <td></td>
            <td>
                <asp:Button ID="btnClear" Text="Borrar" runat="server" OnClick="btnClear_Click" />
            </td>
        </tr>
    </table>
    <hr />
    <asp:TextBox ID="txtResult" runat="server"  TextMode="MultiLine" Columns="60" Rows="4" />
    <asp:Button ID="btnVerificar" Text="Verificar" CausesValidation="false" runat="server" OnClick="btnVerificar_Click" />
    <hr />
    <br />
    <br />
    <asp:Label ID="lblInfo" Text="" runat="server" />
</asp:Content>
