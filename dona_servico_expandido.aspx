<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dona_servico_expandido.aspx.cs" Inherits="prjTCC.dona_servico_expandido" %>

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
            <a href="dona_servicos.aspx" class="active">
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
        </div>

        <article>
            <div class="dados-servico">

                <div class="logo-form">
                    <img src="imagens/logotipo.png" />
                </div>

                <label>Código:</label>
                <asp:TextBox ID="txtCodigoServico" ReadOnly="true" runat="server" Enabled="false"></asp:TextBox>

                <label>Nome:</label>
                <asp:TextBox ID="txtNomeServico" runat="server" MaxLength="45"></asp:TextBox>

                <label>Valor:</label>
                <asp:TextBox ID="txtServicoValor" runat="server"></asp:TextBox>

                <label>Descrição:</label>
                <asp:TextBox ID="txtDescricaoServico" runat="server" TextMode="MultiLine" Rows="6" MaxLength="255"></asp:TextBox>

                <label>Duração:</label>
                <asp:TextBox ID="txtDuracaoServico" TextMode="Time" runat="server"></asp:TextBox>

                <label>Código de categoria:</label>
                <asp:TextBox ID="txtCodigoCategoria" ReadOnly="true" runat="server" Enabled="false"></asp:TextBox>

                <label>Categoria:</label>
                <asp:DropDownList ID="cmbCategoria" runat="server"></asp:DropDownList>
              
                <label>Quantidade de pontos:</label>
                <asp:TextBox ID="txtPontos" runat="server" type="number" min="0"></asp:TextBox>

                <label>Escolha imagem(ns) para o serviço:</label>
                <asp:FileUpload ID="flImagensServico" runat="server" />

                <asp:Button ID="btnAdicionarImagem" CssClass="botoes" runat="server" Text="Adicionar Imagem" OnClick="btnAdicionarImagem_Click" />
                <!--<div class="cls"></div>-->

                <asp:Panel ID="pnlImagensContainer" runat="server">
                    <asp:Panel ID="pnlListaImagens" CssClass="pnlListaImagens" runat="server"></asp:Panel>
                </asp:Panel>

                <asp:Literal ID="litAviso" runat="server"></asp:Literal>

                <div class="fr">
                    <asp:Button ID="btnEditar" CssClass="botoes" runat="server" Text="Editar" OnClick="btnEditar_Click" />
                    <asp:Button ID="btnExcluir" CssClass="botoes excluir" runat="server" Text="Excluir" OnClick="btnExcluir_Click" />
                </div>

                <div class="cls"></div>
            </div>
        </article>
        <asp:Panel ID="pnlConfirmarExclusao" runat="server" CssClass="fundo" Visible="false">
            <div class="aviso">
                <p>Você tem certeza de que deseja excluir?</p>
                <asp:Button ID="btnSim" CssClass="botoes" runat="server" Text="Sim" OnClick="btnSim_Click" />
                <asp:Button ID="btnNao" CssClass="botoes btn-cancelar" runat="server" Text="Não" OnClick="btnNao_Click" />
            </div>
        </asp:Panel>
    </form>
</body>
</html>
