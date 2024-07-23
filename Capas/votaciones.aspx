<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="votaciones.aspx.cs" Inherits="Examen__2.Capas.votaciones" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../css/StyleVotaciones.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1 class="title">Votaciones</h1>
            <div class="group">
                <asp:Repeater ID="rptCandidatos" runat="server">
                    <ItemTemplate>
                        <div class="grid-1-5">
                            <h2><%# Eval("Nombre") %></h2>
                            <p><strong>Partido Político:</strong> <%# Eval("PartidoPolitico") %></p>
                            <p><strong>Plataforma:</strong> <%# Eval("Plataforma") %></p>
                            <asp:Button ID="btnVotar" runat="server" Text="Votar" CssClass="button" CommandArgument='<%# Eval("CandidatoID") %>' OnClick="btnVotar_Click" />
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
        <div class="results-final">
            <asp:Button ID="ButtonRegresar" runat="server" Text="Regresar" CssClass="button" OnClick="ButtonRegresar_Click" />
        </div>
        <asp:Label ID="VotacionStatus" runat="server" CssClass="votacion-status"></asp:Label>
    </form>
</body>
</html>