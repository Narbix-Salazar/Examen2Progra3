<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="agregarCandidato.aspx.cs" Inherits="Examen__2.Capas.candidatos.agregarCandidato" %>

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
            <h1 class="main-heading">Agregar Candidato</h1>
            <asp:Label ID="lblNombre" runat="server" Text="Nombre:" AssociatedControlID="txtNombre"></asp:Label>
            <asp:TextBox ID="txtNombre" runat="server" CssClass="input-field" />
            
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
            
            <asp:Button ID="ButtonAgregar" runat="server" Text="Agregar" CssClass="btn" OnClick="ButtonAgregar_Click" />
            <asp:Button ID="ButtonRegresar" runat="server" Text="Regresar" CssClass="btn-morado" OnClick="ButtonRegresar_Click" />
        </div>
    </form>
</body>
</html>