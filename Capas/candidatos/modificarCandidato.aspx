<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="modificarCandidato.aspx.cs" Inherits="Examen__2.Capas.candidatos.modificarCandidato" %>

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
            <h1 class="main-heading">Modificar Candidato</h1>
            
            <asp:Label ID="lblNombreBuscar" runat="server" Text="Nombre del Candidato:" AssociatedControlID="txtNombreBuscar"></asp:Label>
            <asp:TextBox ID="txtNombreBuscar" runat="server" CssClass="input-field" />
            <asp:Button ID="ButtonBuscar" runat="server" Text="Buscar" CssClass="btn" OnClick="ButtonBuscar_Click" />
            
            <asp:Label ID="lblPartidoPolitico" runat="server" Text="Partido Político:" AssociatedControlID="ddlPartidoPolitico"></asp:Label>
            <asp:DropDownList ID="ddlPartidoPolitico" runat="server" CssClass="input-field">
                <asp:ListItem Value="">Seleccione un partido</asp:ListItem>
                <asp:ListItem Value="A">Partido A</asp:ListItem>
                <asp:ListItem Value="B">Partido B</asp:ListItem>
                <asp:ListItem Value="C">Partido C</asp:ListItem>
            </asp:DropDownList>
            
            <asp:Label ID="lblPlataforma" runat="server" Text="Plataforma:" AssociatedControlID="ddlPlataforma"></asp:Label>
            <asp:DropDownList ID="ddlPlataforma" runat="server" CssClass="input-field">
                <asp:ListItem Value="">Seleccione una plataforma</asp:ListItem>
                <asp:ListItem Value="Presidente">Presidente</asp:ListItem>
                <asp:ListItem Value="Vicepresidente">Vicepresidente</asp:ListItem>
                <asp:ListItem Value="Tesorero">Tesorero</asp:ListItem>
                <asp:ListItem Value="Secretario">Secretario</asp:ListItem>
                <asp:ListItem Value="Diputado">Diputado</asp:ListItem>
                <asp:ListItem Value="Fiscal">Fiscal</asp:ListItem>
            </asp:DropDownList>
            
            <asp:Button ID="ButtonModificar" runat="server" Text="Modificar" CssClass="btn" OnClick="ButtonModificar_Click" />
            <asp:Button ID="ButtonLimpiar" runat="server" Text="Limpiar" CssClass="btn" OnClick="ButtonLimpiar_Click" />
            <asp:Button ID="ButtonRegresar" runat="server" Text="Regresar" CssClass="btn-morado" OnClick="ButtonRegresar_Click" />
        </div>
    </form>
</body>
</html>