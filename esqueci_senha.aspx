<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="esqueci_senha.aspx.cs" Inherits="prjTCC.esqueci_senha" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="preconnect" href="https://fonts.googleapis.com" />
    <link rel="preconnect" href="https://fonts.gstatic.com" />
    <link href="https://fonts.googleapis.com/css2?family=Open+Sans&display=swap" rel="stylesheet" />
    <title>La Bella</title>
    <meta charset="utf-8" />
    <link rel="stylesheet" type="text/css" href="css/estilo.css" />
    <script src="https://kit.fontawesome.com/f9a95042e5.js" crossorigin="anonymous"></script>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <header>
                <div class="logo-container">
                    <asp:HyperLink NavigateUrl="~/index.aspx" runat="server">
                        <img src="imagens/logotipo.png" alt="logo do site"/>
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
                                <div class="botoes">
                                    <asp:Literal ID="litLoginResponsivo" runat="server"></asp:Literal>
                                </div>
                            </asp:HyperLink>
                        </li>
                    </ul>
                </div>
            </header>

            <section class="container">
                <div class="section-content-largura">
                    <div class="login-cadastro-form-container">
                        <asp:Panel ID="pnlFormEsqueciSenha" CssClass="cadastro-form" runat="server">
                            <h1>Recuperação de senha</h1>

                            <label for="e-mail">E-mail:</label>
                            <asp:TextBox ID="txtEmail" TextMode="Email" CssClass="txtEmail-cadastro" placeholder="email@gmail.com" runat="server"></asp:TextBox>

                            <asp:Button ID="btnEnviar" CssClass="botoes" runat="server" Text="Enviar" OnClick="btnEnviar_Click" />
                            <div class="cls"></div>

                            <span class="erro">
                                <asp:Literal ID="litAviso" runat="server"></asp:Literal></span>
                        </asp:Panel>

                        <asp:Panel ID="pnlAviso" CssClass="cadastro-form" runat="server" Visible="false">
                            <h1>Recuperação de senha</h1>

                            <p>O procedimento já foi enviado ao email digitado, acesse-o para alterar sua senha</p>
                        </asp:Panel>
                        <asp:Panel ID="pnlAlterarSenha" runat="server" CssClass="cadastro-form" Visible="false">
                            <h1>Recuperação de senha</h1>

                            <label for="senha">Senha nova:</label>
                            <asp:TextBox ID="txtSenha" TextMode="Password" placeholder="No mínimo 6 caracteres" runat="server" ></asp:TextBox>
        
                            <label for="senha">Confirme a senha nova:</label>
                            <asp:TextBox ID="txtConfirmarSenha" TextMode="Password" placeholder="Repita a senha" runat="server"></asp:TextBox>

                            <asp:Button ID="btnConfirmar"  CssClass="botoes" runat="server" Text="Confirmar" OnClick="btnConfirmar_Click" />
                        </asp:Panel>

                        
                    </div>
                </div>
            </section>
        </div>
    </form>
    <script src="<%=ResolveUrl("~/js/menu_sanduiche.js") %>" type="text/javascript"></script>
</body>
</html>
