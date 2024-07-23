<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="eliminarVotante.aspx.cs" Inherits="Examen__2.Capas.votantes.votanteseliminar" %>

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
            <h2>Eliminar Votante</h2>
            <div class="form-group">
                <label for="txtCedula">Cédula:</label>
                <asp:TextBox ID="txtCedula" runat="server" CssClass="input-field"></asp:TextBox>
                <asp:Button ID="ButtonBuscar" runat="server" Text="Buscar" CssClass="btn" OnClick="ButtonBuscar_Click" />
            </div>
            <div class="form-group">
                <label for="txtNombre">Nombre:</label>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="input-field" Enabled="False"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtContraseña">Contraseña:</label>
                <asp:TextBox ID="txtContraseña" runat="server" CssClass="input-field" Enabled="False"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtFechaNacimiento">Fecha de Nacimiento:</label>
                <asp:TextBox ID="txtFechaNacimiento" runat="server" CssClass="input-field" Enabled="False"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtDireccion">Dirección:</label>
                <asp:TextBox ID="txtDireccion" runat="server" CssClass="input-field" Enabled="False"></asp:TextBox>
            </div>
            <div class="form-group">
                <label for="txtCorreo">Correo:</label>
                <asp:TextBox ID="txtCorreo" runat="server" CssClass="input-field" Enabled="False"></asp:TextBox>
            </div>
            <asp:Button ID="ButtonEliminar" runat="server" Text="Eliminar" CssClass="btn" OnClick="ButtonEliminar_Click" />
   
        </div>
        <asp:Button ID="ButtonRegresar" runat="server" Text="Regresar" CssClass="btn" OnClick="ButtonRegresar_Click" />
    </form>
</body>
</html>