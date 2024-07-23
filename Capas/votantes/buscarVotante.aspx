<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="buscarVotante.aspx.cs" Inherits="Examen__2.Capas.votantes.votantesbuscar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../../css/StyleVotantes.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="form-container">
            <h1>Buscar Votante</h1>
            <div>
                <label for="txtCedulaBuscar">Cédula:</label>
                <asp:TextBox ID="txtCedulaBuscar" runat="server" />
            </div>
            <asp:Button ID="ButtonBuscar" runat="server" Text="Buscar" OnClick="ButtonBuscar_Click" CssClass="btn" />
            
            <div>
                <label for="txtNombre">Nombre:</label>
                <asp:TextBox ID="txtNombre" runat="server" ReadOnly="True" />
            </div>
            <div>
                <label for="txtFechaNacimiento">Fecha de Nacimiento:</label>
                <asp:TextBox ID="txtFechaNacimiento" runat="server" TextMode="Date" ReadOnly="True" />
            </div>
            <div>
                <label for="txtDireccion">Dirección:</label>
                <asp:TextBox ID="txtDireccion" runat="server" ReadOnly="True" />
            </div>
            <div>
                <label for="txtCorreo">Correo:</label>
                <asp:TextBox ID="txtCorreo" runat="server" TextMode="Email" ReadOnly="True" />
            </div>
        </div>
        <asp:Button ID="ButtonRegresar" runat="server" Text="Regresar" CssClass="btn-morado" OnClick="ButtonRegresar_Click" />
    </form>
</body>
</html>