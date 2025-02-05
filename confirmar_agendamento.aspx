<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="confirmar_agendamento.aspx.cs" Inherits="prjTCC.dona_confirmar_agendamento" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Open+Sans&display=swap" rel="stylesheet">
    <title>La Bella</title>
    <meta charset="utf-8">
    <link rel="stylesheet" type="text/css" href="css/estiloDona.css">
    <script src="https://kit.fontawesome.com/f9a95042e5.js" crossorigin="anonymous"></script>
    <meta name="viewport" content="width=device-width, initial-scale=1">
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <div class="logo-container">
                <a href="dona_agenda.aspx">
                    <img src="imagens/logotipo.png" alt="logo do site" />
                </a>
            </div>
        </header>

        <asp:Panel ID="sdbDona" runat="server" CssClass="sidebar">
            <a href="dona_agenda.aspx" class="active">
                <img src="imagens/agenda.png" />Agenda</a>
            <a href="dona_servicos.aspx">
                <img src="imagens/secador.png" />Serviços</a>
            <a href="dona_funcionarios.aspx">
                <img src="imagens/usuario.png" />Funcionários</a>
            <a href="dona_recompensas.aspx">
                <img src="imagens/presente.png" />Recompensas</a>
            <a href="dona_banner.aspx">
                <img src="imagens/galeria.png" />Banners</a>
            <a href="estoque.aspx">
                <img src="imagens/pacote.png" />Estoque</a>
            <a href="logout.aspx">
                <img src="imagens/logout.png" />Sair</a>
        </asp:Panel>
        <asp:Panel ID="sdbFuncionario" runat="server" CssClass="sidebar">
            <a href="funcionario_agenda.aspx" class="active">
                <img src="imagens/agenda.png" />Agenda</a>
            <a href="funcionario_editar.aspx">
                <img src="imagens/usuario.png" />Funcionário</a>
            <a href="logout.aspx">
                <img src="imagens/logout.png" />Sair</a>
        </asp:Panel>

        <article>
            <div class="titulo">
            </div>

            <div>
                <!--<h1>Agendamento</h1>-->
                <div class="dados-servico">
                    <div>
                        <div class="logo-form">
                            <img src="imagens/logotipo.png" />
                        </div>
                    </div>

                    <div class="separa-inputs-agendamento">
                        <div>
                             <label>Código do agendamento:</label>
                            <asp:TextBox ID="txtCodigoAgendamento" ReadOnly="true" runat="server" Enabled="false"></asp:TextBox>

                            <label>Data do agendamento:</label>
                            <asp:TextBox ID="txtDataAgendamento" runat="server" ReadOnly="true" type="date" Enabled="false"></asp:TextBox>

                            <label>Hora do agendamento:</label>
                            <asp:TextBox ID="txtHoraAgendamento" ReadOnly="true" runat="server" type="time" Enabled="false"></asp:TextBox>

                            <label>Cliente:</label>
                            <asp:TextBox ID="txtNomeCliente" runat="server" ReadOnly="true" type="email" Enabled="false"></asp:TextBox>

                            <label>Email do cliente:</label>
                            <asp:TextBox ID="txtEmailCliente" runat="server" ReadOnly="true" type="email" Enabled="false"></asp:TextBox>
                        </div>
                       
                        <div>
                            <label>Funcionário:</label>
                            <asp:TextBox ID="txtNomeFuncionario" ReadOnly="true" runat="server" Enabled="false"></asp:TextBox>

                            <label>Serviço:</label>
                            <asp:TextBox ID="txtServico" ReadOnly="true" runat="server" Enabled="false"></asp:TextBox>

                            <label>Cupom:</label>
                            <asp:TextBox ID="txtCupom" ReadOnly="true" runat="server" Enabled="false"></asp:TextBox>

                            <label>Valor do serviço:</label>
                            <asp:TextBox ID="txtValorServico" ReadOnly="true" runat="server" Enabled="false"></asp:TextBox>

                            <label>Valor final:</label>
                            <asp:TextBox ID="txtValorFinal" ReadOnly="true" runat="server" Enabled="false"></asp:TextBox>
                        </div>
                    </div>

                    <div class="alinha-rbList">
                        <label>Presença do cliente</label>
                            <asp:RadioButtonList ID="rblPresencaCliente" CssClass="rbList" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Text=" Não" Value="0" />
                                <asp:ListItem Text=" Sim" Value="1" />
                            </asp:RadioButtonList>

                        <label>Presença do funcionário</label>
                        <asp:RadioButtonList ID="rblPresencaFuncionario" CssClass="rbList" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Text="Não" Value="0" />
                            <asp:ListItem Text="Sim" Value="1" />
                        </asp:RadioButtonList>
                    </div>

                    <asp:Panel ID="pnlConfirmarExclusao" runat="server" CssClass="fundo" Visible="false">
                        <div class="aviso dados-servico dados-novos-produtos">
                            <p>Adicionar produtos utilizados</p>
                            <label>Produtos utilizados</label>
                            <asp:DropDownList ID="drpProdutos" runat="server"></asp:DropDownList>

                            <asp:Button ID="btnAdicionarProduto" CssClass="botoes" runat="server" Text="Adicionar" OnClick="btnAdicionarProduto_Click" />
                            <asp:Literal ID="litAvisoPanelProduto" runat="server"></asp:Literal>

                            <asp:Panel ID="pnlProdutos" runat="server"></asp:Panel>

                            <div class="fr">
                                <asp:Button ID="btnConfirmarProduto" CssClass="botoes" runat="server" Text="Confirmar" OnClick="btnConfirmarProduto_Click" />
                            </div>
                        </div>
                    </asp:Panel>


                    <asp:Literal ID="litAviso" runat="server"></asp:Literal>



                    <asp:Literal ID="litAvisoProduto" runat="server"></asp:Literal>
                    <div class="fr alinha-buttons">
                        <asp:Button ID="btnRegistrarProduto" CssClass="botoes" runat="server" Text="Registrar produtos" OnClick="btnRegistrarProduto_Click" />

                        <asp:Button ID="btnConcluir" CssClass="botoes" runat="server" Text="Confirmar"/>
                    </div>


                    <div class="cls"></div>
                </div>
            </div>

        </article>
    </form>
</body>
</html>
