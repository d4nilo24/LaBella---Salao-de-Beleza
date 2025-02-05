<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="recompensa_resgatar.aspx.cs" Inherits="prjTCC.recompensa_resgatar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Open+Sans&display=swap" rel="stylesheet">
    <title>La Bella</title>
    <meta charset="utf-8">
    <link rel="stylesheet" type="text/css" href="css/estilo.css">
    <script src="https://kit.fontawesome.com/f9a95042e5.js" crossorigin="anonymous"></script>
    <meta name="viewport" content="width=device-width, initial-scale=1">
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
                            <asp:HyperLink NavigateUrl="~/recompensas.aspx" CssClass="pagina-ativa" runat="server">Recompensas</asp:HyperLink></li>
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
                <div class="section-agendamento">
                    <h1>Você tem certeza que vai resgatar esse
                        <asp:Literal ID="litTipoPremio" runat="server"></asp:Literal>?</h1>

                    <div class="div_pontos">
                        <h3>
                            <asp:Literal ID="litPontos" runat="server"></asp:Literal>
                        </h3>
                    </div>

                    <h2>
                        <asp:Literal ID="litTituloPremio" runat="server"></asp:Literal></h2>
                    <hr />

                    <div class="recompensa-resgatar">
                        <div class="recompensa-resgatar-container">
                            <div class="agendamento-imagem">
                                <asp:Literal ID="litImagemPremio" runat="server"></asp:Literal>
                            </div>

                            <div class="agendamento-info">
                                <h3>
                                    <asp:Literal ID="litPontosPremio" runat="server"></asp:Literal>
                                    pontos
                                </h3>
                                <p>
                                    <asp:Literal ID="litDescricaoPremio" runat="server"></asp:Literal>
                                </p>

                                <asp:Literal ID="litServicoAtrelado" runat="server"></asp:Literal>

                                <asp:Literal ID="litCategoriaAtrelada" runat="server"></asp:Literal>
                                <!--<h4>Valido até
                                    <asp:Literal ID="litDataFimPremio" runat="server"></asp:Literal></h4>-->
                            </div>
                        </div>
                    </div>

                    <div class="btn_confirmar">
                        <asp:Button ID="btnConfirmar" runat="server" Text="Confirmar" OnClick="btnConfirmar_Click" CssClass="botoes" />
                    </div>

                    <asp:Literal ID="litErro" runat="server"></asp:Literal>
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
        </div>
        <!--<asp:Panel ID="loading_spinner" runat="server" CssClass="loading_spinner">
            <div class="spinner"></div>
        </asp:Panel>-->
    </form>
    <script src="<%=ResolveUrl("~/js/menu_sanduiche.js") %>" type="text/javascript"></script>
</body>
</html>
