<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="Examen__2.Capas.AdminLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../css/Style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="top"></div>
            <div class="bottom"></div>
            <div class="center">
                <h2>Bienvenido Administrador!</h2>
                <p>Ingresa con tu usuario y contraseña:</p>
                <div class="input-fields">
                    <asp:TextBox ID="Usuario" runat="server" CssClass="input-line full-width" Placeholder="Usuario"></asp:TextBox>
                    <asp:TextBox ID="Contraseña" runat="server" TextMode="Password" CssClass="input-line full-width" Placeholder="Contraseña"></asp:TextBox>
                    <asp:Button ID="ButtonIngresar" runat="server" Text="Ingresar" CssClass="btn-morado" OnClick="ButtonIngresar_Click" />
                </div>
                <div>
                    <asp:Button ID="ButtonRegresar" runat="server" Text="Regresar" CssClass="btn-morado" OnClick="ButtonRegresar_Click" />
                </div>
            </div>
        </div>
    </form>
</body>
</html>