<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Examen__2.Capas.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<title>Login</title>
    <link href="../css/Style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="top"></div>
            <div class="bottom"></div>
            <div class="center">
                <div class="logo-container">
                    <img src="../imagenes/image.jpg" alt="Logo" class="logo" />
                </div>
                
                <h2>Bienvenido!</h2>
                <p>Ingresa con tu usuario y contraseña:</p>
                <div class="input-fields">
                    <asp:TextBox ID="Usuario" runat="server" CssClass="input-line full-width" Placeholder="Identificación del Usuario"></asp:TextBox>
                    <asp:TextBox ID="Contraseña" runat="server" CssClass="input-line full-width" TextMode="Password"></asp:TextBox>
                </div>
                <p>Si no tienes usuario o contraseña comunicate con el Administrador</p>
                <div>
                    <asp:Button ID="ButtonIngresar" runat="server" Text="Ingresar" CssClass="btn-morado" OnClick="ButtonIngresar_Click" />
                    <asp:Button ID="ButtonAdminLogin" runat="server" Text="Administrador Login" CssClass="btn-morado" OnClick="ButtonAdminLogin_Click"/>
                </div>
                <asp:Label ID="LoginStatus" runat="server" CssClass="login-status"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
