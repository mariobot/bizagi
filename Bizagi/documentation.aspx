<%@ Page Title="" Language="C#" MasterPageFile="~/Page.Master" AutoEventWireup="true" CodeBehind="documentation.aspx.cs" Inherits="Bizagi.documentation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderName" runat="server">
    Documentacion
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder" runat="server">
    <p></p>
    <h2>Sample 1</h2> 
    <h3>Style0115</h3>
    <p>Una tirar evento intermedio debe ser etiquetado</p>
    <h2>Sample 2</h2>
    <h3>BPMN 0102</h3>
    <p>Todos flujo objetos distintos de los eventos extremos y actividades de compensación debe tener un flujo de secuencia de salida, si el nivel de proceso incluye los eventos de inicio o fin.</p>
    <h2>Sample 3</h2>
    <h3>Style 0104</h3>
    <p>Dos actividades en el mismo proceso no deben tener el mismo nombre. (Use la actividad mundial de reutilizar una sola actividad en un proceso.)</p>
    <h2>Sample 4</h2>
    <h3>Style 0122</h3>
    <p>Un evento de captura de mensajes debe tener un flujo de mensaje entrante.</p>
    <h3>Style 0123</h3>
    <p>Un evento que lanza mensaje debe tener un flujo de mensajes salientes.</p>
</asp:Content>
