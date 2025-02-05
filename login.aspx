<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="prjTCC.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Open+Sans&display=swap" rel="stylesheet">
    <title>La Bella</title>
    <meta charset="utf-8">
    <link rel="stylesheet" type="text/css" href="css/estilo.css">
    <script src="https://kit.fontawesome.com/f9a95042e5.js" crossorigin="anonymous"></script>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <header>
                    <div class="logo-container">
                        <asp:HyperLink NavigateUrl="~/index.aspx" runat="server">
                        <img src="imagens/logotipo.png" alt="logo do site">
                        </asp:HyperLink>
                    </div>

                    <nav>
                        <ul>
                            <li>
                                <asp:HyperLink NavigateUrl="~/servicos.aspx" runat="server">Serviços</asp:HyperLink></li>
                            <li>
                                <asp:HyperLink NavigateUrl="~/recompensas.aspx" runat="server">Recompensas</asp:HyperLink></li>
                        </ul>
                    </nav>

                    <div class="menu-sanduiche">
                        <i class="fa-solid fa-bars"></i>
                    </div>

                    <div class="usuario-container">
                        <asp:HyperLink ID="hpLogin" runat="server">
                            <asp:Literal ID="litIconeUsuario" runat="server"></asp:Literal>
                         </asp:HyperLink>
                    </div>

                    <div class="dropdown">
                        <ul>
                            <li>
                                <asp:HyperLink NavigateUrl="~/servicos.aspx" runat="server">Serviços</asp:HyperLink></li>
                            <li>
                                <asp:HyperLink NavigateUrl="~/recompensas.aspx" runat="server">Recompensas</asp:HyperLink></li>
                            <li>
                                <asp:HyperLink ID="hpLoginResponsivo" runat="server">
                                    <div class="botoes"><asp:Literal ID="litLoginResponsivo" runat="server"></asp:Literal></div>  
                                </asp:HyperLink>
                            </li>
                        </ul>
                    </div>
                </header>

            <section class="container">
                <div class="section-content-largura">
                    <div class="login-cadastro-form-container">
                        <div class="cadastro-form">
                            <h1>Acessar conta</h1>

                            <label for="txtEmailLogin">E-mail:</label>
                            <asp:TextBox ID="txtEmailLogin" runat="server" type="email"></asp:TextBox>

                            <label for="txtSenhaLogin">Senha:</label>
                            <asp:TextBox ID="txtSenhaLogin" runat="server" type="password"></asp:TextBox>

                            <asp:Button ID="btnEntrar" CssClass="fr botoes" runat="server" Text="Entrar" OnClick="btnEntrar_Click" />
                            <div class="cls"></div>
                            <h4><a href="esqueci_senha.aspx">Esqueci a senha</a></h4>
                            <h4>Ainda não tem conta? <a href="cadastro.aspx">Criar uma</a></h4>
                            <div class="centralizado">
                            <asp:Literal ID="litAviso" runat="server"></asp:Literal>
                            </div>
                        </div>
                    </div>
                </div>
             </section>
        </div>
        <asp:Panel ID="loading_spinner" runat="server" CssClass="loading_spinner">
            <div class="spinner"></div>
        </asp:Panel>
    </form>
</body>
</html>
