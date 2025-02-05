<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="recompensas.aspx.cs" Inherits="prjTCC.recompensas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="preconnect" href="https://fonts.googleapis.com"/>
    <link rel="preconnect" href="https://fonts.gstatic.com"/>
    <link href="https://fonts.googleapis.com/css2?family=Open+Sans&display=swap" rel="stylesheet"/>
    <title>La Bella</title>
    <meta charset="utf-8"/>
    <link rel="stylesheet" type="text/css" href="css/estilo.css"/>
    <script src="https://kit.fontawesome.com/f9a95042e5.js" crossorigin="anonymous"></script>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
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
                <div class="section-content-largura">
                    <h1>Resgate recompensas</h1>

                    <div class="div_pontos">
                            <h3>
                                <asp:Literal ID="litPontos" runat="server"></asp:Literal>
                            </h3>
                    </div>

                    <div class="filtros-lista">
                        <asp:Repeater ID="rpFiltros" runat="server">
                            <ItemTemplate>
                                <asp:HyperLink runat="server" NavigateUrl='<%# "~/recompensas.aspx" + "?tipo=" + DataBinder.Eval(Container.DataItem, "Codigo")  %>'>
                                    <div class="filtros" id='<%# "tipo_premio" + DataBinder.Eval(Container.DataItem, "Codigo") %>'>
                                        <p><%# DataBinder.Eval(Container.DataItem, "Nome") %></p>
                                    </div>
                                </asp:HyperLink>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                  
                    
            
                    <asp:Panel ID="pnlRecompensa" runat="server" CssClass="lista-servicos">
                        <asp:Image ID="imgErro" CssClass="imagem_erro" runat="server" />
                    </asp:Panel>
                    
                </div>
            </section>
            <asp:Literal ID="lit" runat="server"></asp:Literal>
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
                            <li>Av. Antônio Emerich, 90, São Vicente-SP</li>
                        </ul>
                    </div>

                    <div>
                        <h1>Horário</h1>

                        <ul>
                            <li>De terça a sábado das 8 às 18</li>
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
        <asp:Panel ID="loading_spinner" runat="server" CssClass="loading_spinner">
            <div class="spinner"></div>
        </asp:Panel>
    </form>
     <script src="<%=ResolveUrl("~/js/menu_sanduiche.js") %>" type="text/javascript"></script>
     <script src="<%=ResolveUrl("~/js/igualarTamanho.js") %>" type="text/javascript"></script>
     <script src="<%=ResolveUrl("~/js/mudaCorFiltro.js") %>" type="text/javascript"></script>
</body>
</html>
