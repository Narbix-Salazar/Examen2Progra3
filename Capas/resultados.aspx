<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="resultados.aspx.cs" Inherits="Examen__2.Capas.resultados" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../css/StyleResultados.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1 class="title">Resultados de las Votaciones</h1>
            <div class="results-final">
                <asp:Button ID="ButtonResultados" runat="server" Text="Resultados" CssClass="button" OnClick="ButtonResultados_Click" />
                <asp:Button ID="ButtonRegresar" runat="server" Text="Regresar" CssClass="button" OnClick="ButtonRegresar_Click" />
            </div>
            <div class="group">
                <asp:Repeater ID="rptResultados" runat="server">
                    <ItemTemplate>
                        <div class="grid-1-5">
                            <h2><%# Eval("Nombre") %></h2>
                            <p><strong>Votos Totales:</strong> <%# Eval("VotosTotales") %></p>
                            <p><strong>Porcentaje de Votos:</strong> <%# Eval("PorcentajeVotos") %></p>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <asp:Panel ID="resultsPanel" runat="server" CssClass="results-info grid-1-5 results-box" Visible="false">
                    <h2>Resultados Finales</h2>
                    <p><strong>Ganador:</strong> <asp:Label ID="lblGanador" runat="server" CssClass="result-label" /></p>
                    <p><strong>Total de Votos:</strong> <asp:Label ID="lblTotalVotos" runat="server" CssClass="result-label" /></p>
                </asp:Panel>
            </div>
        </div>
    </form>
</body>
</html>