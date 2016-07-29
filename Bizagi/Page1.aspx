<%@ Page Title="" Language="C#" MasterPageFile="~/Page.Master" AutoEventWireup="true" CodeBehind="Page1.aspx.cs" Inherits="Bizagi.Page1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderName" runat="server">
     Cargar Archivo
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <p>utilice esta opcion para cargar el archivo al servidor</p>
    <hr />
    <asp:FileUpload ID="fileUploadControl" runat="server" />
    <hr />
    <asp:Button Text="Cargar Archivo" runat="server" ID="btnLoadFile" OnClick="btnLoadFile_Click" />
    <hr />
    <asp:Label Text="" ID="lblInfo" runat="server" Font-Size="Medium" />
</asp:Content>
