<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Menu.aspx.cs" Inherits="Examen__2.Capas.Menu" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Menú Principal</title>
    <link href="../css/Style.css" rel="stylesheet" />
    <link href="../css/StyleMenu.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="wrapper">
            <div class="content">
                <h1 class="title">Menú</h1>
                <div>
                    <asp:Button ID="btnVotar" runat="server" Text="Votar" CssClass="btn-menu" OnClick="btnVotar_Click" />
                    <asp:Button ID="btnResultados" runat="server" Text="Resultados" CssClass="btn-menu" OnClick="btnResultados_Click" />
                    <asp:Button ID="btnRegresar" runat="server" Text="Regresar al Menu" CssClass="btn-menu" OnClick="btnRegresar_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>