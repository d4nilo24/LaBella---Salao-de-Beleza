<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="erro.aspx.cs" Inherits="prjTCC.erro" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link href="https://fonts.googleapis.com/css2?family=Open+Sans&display=swap" rel="stylesheet">
    <title>La Bella</title>
    <meta charset="utf-8">
    <link rel="stylesheet" type="text/css" href="css/estilo.css">
    <script src="https://kit.fontawesome.com/f9a95042e5.js" crossdorigin="anonymous"></script>
    <meta name="viewport" content="width=device-width, initial-scale=1">
</head>
<body>
    <form id="form1" runat="server">
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
                            <div class="botoes">
                                <asp:Literal ID="litLoginResponsivo" runat="server"></asp:Literal>
                            </div>
                        </asp:HyperLink>
                    </li>
                </ul>
            </div>
        </header>

        <section class="container-404 container">
            <div class="div-404">
                <h1>Erro
                    <asp:Literal ID="litTipoErro" runat="server"></asp:Literal>
                </h1>
                <p>
                    <asp:Literal ID="litMensagemErro" runat="server"></asp:Literal>
                </p>
                <asp:HyperLink runat="server" NavigateUrl="~/index.aspx">
                    <div class="botoes"><p>Página Inicial <i class="fa-solid fa-rotate-right"></i></p></div>
                </asp:HyperLink>
            </div>
        </section>

        <footer>
            <div class="footer-container">
                <div class="logo-container">
                    <asp:HyperLink NavigateUrl="~/index.aspx" runat="server">
                            <img src="imagens/logotipo_branco.png"/>
                    </asp:HyperLink>

                </div>

                <div>
                    <h1>Onde nos encontrar</h1>

                    <ul>
                       <li>Av. Antônio Emmerich, 90 - Vila Cascatinha, São Vicente - SP, 11390-160</li>
                    </ul>
                </div>

                <div>
                    <h1>Horário</h1>

                    <ul>
                        <li>De terça a sábado das 9 às 18</li>
                    </ul>
                </div>

                <div class="footer-contato-container">
                    <h1>Contato</h1>

                    <ul>
                        <li>(13) 99009-9625</li>

                    </ul>
                    <div class="contato-icones">
                        <i class="fa-brands fa-whatsapp"></i>
                        <i class="fa-brands fa-instagram"></i>
                    </div>
                </div>
            </div>
        </footer>
    </form>
    <script src="<%=ResolveUrl("~/js/menu_sanduiche.js") %>" type="text/javascript"></script>
    <asp:Panel ID="loading_spinner" runat="server" CssClass="loading_spinner">
        <div class="spinner"></div>
    </asp:Panel>
</body>
</html>
