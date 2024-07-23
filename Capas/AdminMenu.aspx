<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminMenu.aspx.cs" Inherits="Examen__2.Capas.Admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../css/StyleMenuAdmin.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="wrapper">
            <div class="content">
                <h1 class="title">Menú de Administración</h1>
                <div class="containers">
                    <div class="container left-container">
                        <div class="menu-label" onclick="toggleMenu(event, 'candidatos-menu')">Candidatos</div>
                        <div id="candidatos-menu" class="buttons-menu">
                                <asp:Button ID="ButtonagregarCandidato" runat="server" Text="Agregar Candidato" CssClass="button" OnClick="ButtonagregarCandidato_Click" />
                                <asp:Button ID="ButtonmodificarCandidato" runat="server" Text="Modificar Candidato" CssClass="button" OnClick="ButtonmodificarCandidato_Click" />
                                <asp:Button ID="ButtonbuscarCandidato" runat="server" Text="Buscar Candidato" CssClass="button" OnClick="ButtonbuscarCandidato_Click" />
                                <asp:Button ID="ButtoneliminarCandidato" runat="server" Text="Eliminar Candidato" CssClass="button" OnClick="ButtoneliminarCandidato_Click" />
                        </div>
                    </div>
                    <div class="container right-container">
                        <div class="menu-label" onclick="toggleMenu(event, 'votantes-menu')">Votantes</div>
                        <div id="votantes-menu" class="buttons-menu">
                           <asp:Button ID="ButtonagregarVotante" runat="server" Text="Agregar Votante" CssClass="button" OnClick="ButtonagregarVotante_Click" />
                           <asp:Button ID="ButtonmodificarVotante" runat="server" Text="Modificar Votante" CssClass="button" OnClick="ButtonmodificarVotante_Click" />
                           <asp:Button ID="ButtonbuscarVotante" runat="server" Text="Buscar Votante" CssClass="button" OnClick="ButtonbuscarVotante_Click" />
                           <asp:Button ID="ButtoneliminarVotante" runat="server" Text="Eliminar Votante" CssClass="button" OnClick="ButtoneliminarVotante_Click" />
                        </div>
                    </div>
                </div>
                <asp:Button ID="ButtonRegresar" runat="server" Text="Regresar" CssClass="btn-morado" OnClick="ButtonRegresar_Click" />
            </div>
        </div>
    </form>

</body>
</html>