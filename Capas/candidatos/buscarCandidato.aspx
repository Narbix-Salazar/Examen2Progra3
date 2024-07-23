<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="buscarCandidato.aspx.cs" Inherits="Examen__2.Capas.candidatos.buscarCandidato" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../../css/StyleCandidatos.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="form-container">
            <h1 class="main-heading">Buscar Candidato</h1>
            
            <asp:Label ID="lblNombreBuscar" runat="server" Text="Nombre del Candidato:" AssociatedControlID="txtNombreBuscar"></asp:Label>
            <asp:TextBox ID="txtNombreBuscar" runat="server" CssClass="input-field" />
            <asp:Button ID="ButtonBuscar" runat="server" Text="Buscar" CssClass="btn" OnClick="ButtonBuscar_Click" />
            
            <asp:Label ID="lblPartidoPolitico" runat="server" Text="Partido Político:" AssociatedControlID="txtPartidoPolitico"></asp:Label>
            <asp:TextBox ID="txtPartidoPolitico" runat="server" CssClass="input-field" ReadOnly="True" />
            
            <asp:Label ID="lblPlataforma" runat="server" Text="Plataforma:" AssociatedControlID="txtPlataforma"></asp:Label>
            <asp:TextBox ID="txtPlataforma" runat="server" CssClass="input-field" ReadOnly="True" />
            
            <asp:Button ID="ButtonLimpiar" runat="server" Text="Limpiar" CssClass="btn" OnClick="ButtonLimpiar_Click" />
            <asp:Button ID="ButtonRegresar" runat="server" Text="Regresar" CssClass="btn-morado" OnClick="ButtonRegresar_Click" />
        </div>
    </form>
</body>
</html>