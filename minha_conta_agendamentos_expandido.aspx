<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="minha_conta_agendamentos_expandido.aspx.cs" Inherits="prjTCC.minha_conta_agendamentos_expandido" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="preconnect" href="https://fonts.googleapis.com" />
    <link rel="preconnect" href="https://fonts.gstatic.com" />
    <link href="https://fonts.googleapis.com/css2?family=Open+Sans&display=swap" rel="stylesheet" />
    <title>La Bella</title>
    <link rel="stylesheet" type="text/css" href="css/estilo.css" />
    <script src="https://kit.fontawesome.com/f9a95042e5.js" crossorigin="anonymous"></script>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
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
                            <li class="pagina-ativa"><a href="minha_conta_agendamentos.aspx"><i class="fa-solid fa-calendar"></i>Agendamentos</a></li>
                            <li><a href="minha_conta_recompensas.aspx"><i class="fa-solid fa-award"></i>Recompensas</a></li>
                            <li><a href="alterar_senha.aspx"><i class="fa-solid fa-key"></i>Alterar senha</a></li>
                            <li><a href="conta_cliente.aspx"><i class="fa-solid fa-user"></i>Dados cadastrais</a></li>

                            <li><a href="logout.aspx"><i class="fa-solid fa-right-from-bracket"></i>Sair</a></li>
                        </ul>
                    </div>

                    <div class="menu-conta">
                        <div class="agendamentos-detalhes-container">
                            <div class="agendamentos-detalhes-foto-servico">
                                <asp:Image ID="imgServico" runat="server" />
                            </div>

                            <div class="dados-agendamentos-servico-container">
                                <div>
                                    <h2>
                                        <asp:Literal ID="litNomeServico" runat="server"></asp:Literal></h2>
                                    <p>
                                        <i class="fa-regular fa-calendar"></i>
                                        <asp:Literal ID="litDataServico" runat="server"></asp:Literal>
                                    </p>
                                    <p>
                                        <i class="fa-regular fa-clock"></i>
                                        <asp:Literal ID="litHoraServico" runat="server"></asp:Literal>
                                    </p>
                                </div>

                                <div class="situacao-agendamentos-servico">
                                    <h3>
                                        <asp:Literal ID="litSituacaoServico" runat="server"></asp:Literal></h3>
                                </div>
                            </div>
                        </div>

                        <table class="tblInfoAgendamento">
                            <thead>
                                <tr>
                                    <th class="thRadiusRight thRadiusLeft" colspan="2">Informações do agendamento</th>
                                </tr>
                            </thead>

                            <tbody>
                                <tr>
                                    <td>Código de agendamento:</td>
                                    <td>
                                        <asp:Literal ID="litCodigoAgendamento" runat="server"></asp:Literal></td>
                                </tr>

                                <tr>
                                    <td>Profissional:</td>
                                    <td>
                                        <asp:Literal ID="litNomeFuncionario" runat="server"></asp:Literal></td>
                                </tr>

                                <tr>
                                    <td>Presença do funcionário:</td>
                                    <td>
                                        <asp:Literal ID="litPresencaFuncionario" runat="server"></asp:Literal></td>
                                </tr>

                                <tr>
                                    <td>Presença do cliente:</td>
                                    <td>
                                        <asp:Literal ID="litPresencaCliente" runat="server"></asp:Literal></td>
                                </tr>
                            </tbody>
                        </table>

                        <asp:GridView ID="grdProdutos" CssClass="tabelas" runat="server" AutoGenerateColumns="False">
                            <Columns>  
                                <asp:BoundField DataField="nmproduto" HeaderStyle-CssClass="thRadiusRight" HeaderText="Nome do produto" ReadOnly="True" />
                                <asp:BoundField DataField="qtproduto" HeaderStyle-CssClass="thRadiusLeft" HeaderText="Quantidade do produto" ReadOnly="True" />
                            </Columns>
                        </asp:GridView>

                        <div class="fr">
                            <asp:Button ID="btnAvaliacao" Visible="false" CssClass="botoes" runat="server" Text="Avaliar" OnClick="btnAvaliacao_Click" />
                            <asp:Button ID="btnCancelarAgendamento" Visible="false" CssClass="botoes btnCancelar" runat="server" Text="Cancelar Agendamento" OnClick="btnCancelar_Click" />
                        </div>
                        <div class="cls"></div>
                        <asp:Panel ID="pnlConfirmarCancelamento" runat="server" CssClass="fundo" Visible="false">
                            <div class="aviso">
                                <p>Você tem certeza de que deseja cancelar?</p>
                                <asp:Button ID="btnSim" CssClass="botoes" runat="server" Text="Sim" OnClick="btnSim_Click" />
                                <asp:Button ID="btnNao" CssClass="botoes btn-cancelar" runat="server" Text="Não" OnClick="btnNao_Click" />
                            </div>
                        </asp:Panel>


                        <asp:Literal ID="litAviso" runat="server"></asp:Literal>
                    </div>
                </div>
            </div>
        </section>
        <footer>
            <div class="footer-container">
                <div class="logo-container">
                    <a href="index.aspx">
                        <img src="imagens/logotipo_branco.png" />
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
