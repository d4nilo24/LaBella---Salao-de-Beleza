<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="conta_cliente.aspx.cs" Inherits="prjTCC.conta_cliente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="preconnect" href="https://fonts.googleapis.com"/>
    <link rel="preconnect" href="https://fonts.gstatic.com"/>
    <link href="https://fonts.googleapis.com/css2?family=Open+Sans&display=swap" rel="stylesheet"/>
    <title>La Bella</title>
    <meta charset="utf-8"/>
    <link rel="stylesheet" type="text/css" href="css/estilo.css"/>
    <script src="https://kit.fontawesome.com/f9a95042e5.js" crossorigin="anonymous"></script>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
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
            <div class="info-conta-container">
                <div class="info-conta-container-flex">
                    <div class="itens-menu-conta">
                        <div class="ola-nome-cliente">
                            <div>
                                <i class="fa-solid fa-circle-user"></i>
                            </div>

                            <div>
                                <h2>Olá, <strong>
                                    <asp:Literal ID="litNomeBoasVindas" runat="server"></asp:Literal></strong></h2>
                            </div>
                        </div>

                        <ul>
                            <li><a href="minha_conta_agendamentos.aspx"><i class="fa-solid fa-calendar"></i> Agendamentos</a></li>
                            <li><a href="minha_conta_recompensas.aspx"><i class="fa-solid fa-award"></i> Recompensas</a></li>
                            <li><a href="alterar_senha.aspx"><i class="fa-solid fa-key"></i> Alterar senha</a></li>
                            <li class="pagina-ativa"><a href="conta_cliente.aspx"><i class="fa-solid fa-user"></i> Dados cadastrais</a></li>
                            
                            <li><a href="logout.aspx"><i class="fa-solid fa-right-from-bracket"></i> Sair</a></li>
                        </ul>
                    </div>

                    <div class="menu-conta">
                        <div>
                            <div class="form-dados-cadastrais">
                                <h2>Dados cadastrais</h2>

                                <label for="txtNomeCliente">Nome:</label>
                                <asp:TextBox ID="txtNomeCliente" CssClass="inputs" runat="server" Type="text"></asp:TextBox>

                                <label for="txtemial">E-mail:</label>
                                <asp:TextBox ID="txtemial" CssClass="inputs" runat="server" Type="email" ReadOnly="true" Enabled="false"></asp:TextBox>

                                <asp:Button ID="btnAlterar" CssClass="fr botoes" runat="server" Text="Alterar dados" OnClick="btnAlterar_Click" />
                                <asp:Literal ID="litAviso" runat="server"></asp:Literal>
                                <div class="cls"></div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </section>

        <footer>
            <div class="footer-container">
                <div class="logo-container">
                    <a href="index.html">
                        <img src="imagens/logotipo_branco.png"/>
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
</body>
</html>
