<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="minha_conta_recompensas.aspx.cs" Inherits="prjTCC.minha_conta_recompensas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="preconnect" href="https://fonts.googleapis.com"/>
    <link rel="preconnect" href="https://fonts.gstatic.com"/>
    <link href="https://fonts.googleapis.com/css2?family=Open+Sans&display=swap" rel="stylesheet"/>
    <title>La Bella</title>
    <link rel="stylesheet" type="text/css" href="css/estilo.css"/>
    <script src="https://kit.fontawesome.com/f9a95042e5.js" crossorigin="anonymous"></script>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
</head>
<body>
    <form id="form1" runat="server">
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
                <asp:HyperLink NavigateUrl="~/conta_cliente.aspx" runat="server">
                         <i class="fa-solid fa-circle-user"></i>
                </asp:HyperLink>
            </div>

            <div class="dropdown">
                <ul>
                    <li>
                        <asp:HyperLink NavigateUrl="~/servicos.aspx" runat="server">Serviços</asp:HyperLink></li>
                    <li>
                        <asp:HyperLink NavigateUrl="~/recompensas.aspx" runat="server">Recompensas</asp:HyperLink></li>
                    <li>
                        <asp:HyperLink ID="hpLoginResponsivo" runat="server" NavigateUrl="~/conta_cliente.aspx">
                                <div class="botoes">
                                    Minha conta
                                </div>
                        </asp:HyperLink>
                    </li>
                </ul>
            </div>
        </header>

    <section class="container">
        <!--<div class="aviso">
            <p>Você tem certeza de que deseja cancelar?</p>
            <button class="botao">Sim</button>
            <button class="botao">Não</button>
        </div>-->
        
        <div class="info-conta-container">
            <div class="info-conta-container-flex">
                <div class="itens-menu-conta">
                    <div class="ola-nome-cliente">
                        <div>
                            <i class="fa-solid fa-circle-user"></i>
                        </div>
        
                        <div>
                            <h2>Olá, <strong><asp:Literal ID="litNomeBoasVindas" runat="server"></asp:Literal></strong></h2>
                        </div>
                    </div>

                    <ul>
                        <li><a href="minha_conta_agendamentos.aspx"><i class="fa-solid fa-calendar"></i> Agendamentos</a></li>
                        <li class="pagina-ativa"><a href="minha_conta_recompensas.aspx"><i class="fa-solid fa-award"></i> Recompensas</a></li>
                        <li><a href="alterar_senha.aspx"><i class="fa-solid fa-key"></i> Alterar senha</a></li>
                        <li><a href="conta_cliente.aspx"><i class="fa-solid fa-user"></i> Dados cadastrais</a></li>
                            
                        <li><a href="logout.aspx"><i class="fa-solid fa-right-from-bracket"></i> Sair</a></li>
                    </ul>
                </div>

                <div class="menu-conta">
                    <div class="filtros-lista-conta filtros-lista">
                        <asp:HyperLink runat="server" NavigateUrl="~/minha_conta_recompensas.aspx?tipo=0">
                                <div class="filtros" id="tipo_premio0">
                                    <p>Todos</p>
                                </div>
                            </asp:HyperLink>
                         <asp:HyperLink runat="server"  NavigateUrl="~/minha_conta_recompensas.aspx?tipo=2">
                                <div class="filtros" id="tipo_premio2">
                                    <p>Prêmios</p>
                                </div>
                            </asp:HyperLink>
                         <asp:HyperLink runat="server"  NavigateUrl="~/minha_conta_recompensas.aspx?tipo=1">
                                <div class="filtros" id="tipo_premio1">
                                    <p>Cupons</p>
                                </div>
                            </asp:HyperLink>
                        <asp:HyperLink runat="server"  NavigateUrl="~/minha_conta_recompensas.aspx?tipo=3">
                                <div class="filtros" id="tipo_premio3">
                                    <p>Retirados</p>
                                </div>
                            </asp:HyperLink>
                    </div>   

                 <asp:Repeater ID="rpRecompensa" runat="server">
                    <ItemTemplate>
                        <!--<asp:HyperLink ID="hpAgendamentoMaisDetalhes" runat="server" NavigateUrl='<# "~/minha_conta_recompensas.aspx?cdrecompensa=" + DataBinder.Eval(Container.DataItem, "Codigo") +"&tipo=" + tipoPremio%>'>-->
                            <div class="recompensa-conta-container">
                                <div class="recompensa-conta-container-foto">
                                    <asp:Image ImageUrl='<%# "~/imagens/" + DataBinder.Eval(Container.DataItem, "Imagem.Pasta") + "/" + DataBinder.Eval(Container.DataItem, "Imagem.Nome") %>' runat="server" AlternateText="Foto da Recompensa"/>
                                </div>
        
                                <div class="dados-recompensas-conta-container">
                                    <div>
                                        <h3><%# DataBinder.Eval(Container.DataItem, "Nome") %></h3>
                                        <p><%# DataBinder.Eval(Container.DataItem, "Descricao") %></p>
                                    </div>
            
                                    <div class="situacao-recompensa">
                                        <p><%# DataBinder.Eval(Container.DataItem, "CondicaoPremio") %></p>
                                        <p><%# DataBinder.Eval(Container.DataItem, "CondicaoPremioEstoque") %>
                                        </p>
                                    </div>
                                </div>
                            </div>
                        <!--</asp:HyperLink>-->
                     </ItemTemplate>
                  </asp:Repeater>
                  <asp:Image ID="imgErro" CssClass="imagem_erro" runat="server" />

                </div>
            </div>
        </div>
    </section>

    <footer>
        <div class="footer-container">
            <div class="logo-container">
                <a href="index.html">
                    <img src="imagens/logotipo_branco.png">
                </a>
                <i class="fa-brands fa-whatsapp"></i>
                <i class="fa-brands fa-instagram"></i>
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
            </div>
        </div> 
    </footer>
    </form>
        <script type="text/javascript" src="js/menu_sanduiche.js"></script>
        <script src="<%=ResolveUrl("~/js/mudaCorFiltro.js") %>" type="text/javascript"></script>
</body>
</html>
