<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dona_funcionario_atribuicao_servicos.aspx.cs" Inherits="prjTCC.dona_funcionario_atribuicao_servicos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="preconnect" href="https://fonts.googleapis.com"/>
    <link rel="preconnect" href="https://fonts.gstatic.com"/>
    <link href="https://fonts.googleapis.com/css2?family=Open+Sans&display=swap" rel="stylesheet"/>
    <title>La Bella</title>
    <meta charset="utf-8"/>
    <link rel="stylesheet" type="text/css" href="css/estiloDona.css"/>
    <script src="https://kit.fontawesome.com/f9a95042e5.js" crossorigin="anonymous"></script>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <div class="logo-container">
                <a href="dona_agenda.aspx">
                    <img src="imagens/logotipo.png" alt="logo do site" />
                </a>
            </div>
            <div class="usuario-container">
                <a href="index.aspx">
                    <i class="fa-regular fa-eye"></i>
                    <p>Mudar para visão do cliente</p>
                </a>
            </div>
        </header>

        <div class="sidebar">
            <a href="dona_agenda.aspx">
                <img src="imagens/agenda.png" />Agenda</a>
            <a href="dona_servicos.aspx">
                <img src="imagens/secador.png" />Serviços</a>
            <a href="dona_funcionarios.aspx" class="active">
                <img src="imagens/usuario.png" />Funcionários</a>
            <a href="dona_recompensas.aspx">
                <img src="imagens/presente.png" />Recompensas</a>
            <a href="dona_banner.aspx">
                <img src="imagens/galeria.png" />Banners</a>
            <a href="estoque.aspx">
                <img src="imagens/pacote.png" />Estoque</a>
            <a href="logout.aspx">
                <img src="imagens/logout.png" />Sair</a>
        </div>

        <article>
            <div class="dados-servico">

                <div class="logo-form">
                    <img src="imagens/logotipo.png" />
                </div>

                <label>Escolha um serviço para atribuir ao funcionário:</label>
                <asp:DropDownList ID="cmbServicos" EnableViewState="true" runat="server"></asp:DropDownList>

                <div class="fr">
                    <asp:HyperLink ID="hpEditarHorario" runat="server"></asp:HyperLink>
                </div>

                <div class="cls"></div>

                <asp:Literal ID="litAviso" runat="server"></asp:Literal>

                <div class="fr">
                    <asp:Button ID="btnAtribuir" CssClass="botoes" runat="server" Text="Atribuir" OnClick="btnAtribuir_Click" />
                    <!--<asp:Button ID="btnVoltar" CssClass="botoes excluir" runat="server" Text="Voltar" />-->
                </div>

                <div class="cls"></div>
            </div>

            <div class="dados-servico dados-servico-embaixo">

                <asp:Label ID="lblServico" runat="server" Text=""></asp:Label>

                <asp:GridView ID="grdServicosRealizadosPeloFuncionario" CssClass="tabelas" runat="server" AutoGenerateColumns="False" OnRowCommand="grdServicosRealizadosPeloFuncionario_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="nmservico" HeaderText="Servi&#231;os realizados">
                            <HeaderStyle CssClass="thRadiusRight"></HeaderStyle>
                        </asp:BoundField>

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="btnExcluir" runat="server" CommandName="Excluir" CommandArgument='<%# Eval("cdservico") %>' Text="Excluir" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

                <div class="cls"></div>
            </div>
        </article>
    </form>
</body>
</html>