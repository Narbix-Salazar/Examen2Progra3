<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="agregarVotante.aspx.cs" Inherits="Examen__2.Capas.votantes.votantesagregar" %>

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
            <h1 class="main-heading">Agregar Votante</h1>
            <div>
                <label for="txtCedula">Cédula:</label>
                <asp:TextBox ID="txtCedula" runat="server" />
            </div>
            <div>
                <label for="txtNombre">Nombre:</label>
                <asp:TextBox ID="txtNombre" runat="server" />
            </div>
            <div>
                <label for="txtContraseña">Contraseña:</label>
                <asp:TextBox ID="txtContraseña" runat="server" TextMode="Password" />
            </div>
            <div>
                <label for="txtFechaNacimiento">Fecha de Nacimiento:</label>
                <asp:TextBox ID="txtFechaNacimiento" runat="server" TextMode="Date" />
            </div>
            <div>
                <label for="txtDireccion">Dirección:</label>
                <asp:TextBox ID="txtDireccion" runat="server" />
            </div>
            <div>
                <label for="txtCorreo">Correo:</label>
                <asp:TextBox ID="txtCorreo" runat="server" TextMode="Email" />
            </div>
            <div>
                <asp:Button ID="ButtonAgregar" runat="server" Text="Agregar" OnClick="ButtonAgregar_Click" CssClass="asp-Button" />
            </div>
        </div>
        <asp:Button ID="ButtonRegresar" runat="server" Text="Regresar" CssClass="btn-regresar" OnClick="ButtonRegresar_Click" />
    </form>
</body>
</html>