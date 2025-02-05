<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dona_recompensa_adicionar.aspx.cs" Inherits="prjTCC.dona_recompensa_adicionar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
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
            <div class="usuario-container">
                <a href="index.aspx">
                    <i class="fa-regular fa-eye"></i>
                    <p>Mudar para visão do cliente</p>
                </a>
            </div>
        </header>

        <div class="sidebar">
            <a href="dona_agenda.aspx">
                <img src="imagens/agenda.png">Agenda</a>
            <a href="dona_servicos.aspx">
                <img src="imagens/secador.png">Serviços</a>
            <a href="dona_funcionarios.aspx">
                <img src="imagens/usuario.png">Funcionários</a>
            <a href="dona_recompensas.aspx" class="active">
                <img src="imagens/presente.png">Recompensas</a>
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

                <label>Escolha o tipo de recompensa:</label>
                <asp:DropDownList ID="cmbTipoRecompensa" EnableViewState="true" runat="server">
                    <asp:ListItem Value="0">Escolha um tipo</asp:ListItem>
                </asp:DropDownList>

                <asp:Literal ID="litAviso" runat="server"></asp:Literal>

                <div class="fr">
                    <asp:Button ID="btnAtribuir" CssClass="botoes" runat="server" Text="Continuar" />
                </div>

                <div class="cls"></div>
            </div>

            <asp:Panel ID="pnlAdicaoRecompensaProduto" Visible="false" CssClass="dados-servico dados-servico-embaixo" runat="server">
                <label>Nome Prêmio:</label>
                <asp:TextBox ID="txtNomePremioProduto" runat="server" MaxLength="45"></asp:TextBox>

                 <label>Recompensa:</label>
                <asp:DropDownList ID="cmbProdutosRecompensa" runat="server"></asp:DropDownList>

                <label>Pontos necessários:</label>
                <asp:TextBox ID="txtPontosNecessariosProduto" TextMode="Number" runat="server" MaxLength="255" min="0"></asp:TextBox>

                <label>Descrição:</label>
                <asp:TextBox ID="txtDescricaoPremioProduto" runat="server" TextMode="MultiLine" Rows="2" MaxLength="45"></asp:TextBox>

                <asp:Label ID="lblImagem" runat="server" Text="Imagem da recompensa:"></asp:Label>
                <asp:FileUpload ID="fluImagem" runat="server" CssClass="fluImagem" onchange="mostrarImagem()" />

                <div class="pnlImagens">
                    <asp:Image ID="imgPreview" CssClass="imgPreview" runat="server" />
                </div>

                <asp:Literal ID="litAvisoRecompensaProduto" runat="server"></asp:Literal>

                <div class="fr">
                    <asp:Button ID="btnAdicaoImagemPremioProduto" CssClass="botoes" runat="server" Text="Adicionar"  OnClick="btnAdicaoImagemPremioProduto_Click"/>
                </div>
                <div class="cls"></div>
            </asp:Panel>

            <asp:Panel ID="pnlAdicaoRecompensaCupom" Visible="false" CssClass="dados-servico dados-servico-embaixo" runat="server">
                <label>Nome Prêmio:</label>
                <asp:TextBox ID="txtNomePremioCupom" runat="server" MaxLength="45"></asp:TextBox>

                <label>Serviço:</label>
                <asp:DropDownList ID="cmbServicoAtribuidoCupom" runat="server"></asp:DropDownList>

                <label>Categoria de Serviço:</label>
                <asp:DropDownList ID="cmbCategoriaServicoAtribuidoCupom" runat="server"></asp:DropDownList>

                <label>Valor do cupom de desconto (em %):</label>
                 <asp:TextBox ID="txtCupomValor" runat="server" type="number" MaxLength="45" min="0" max="100"></asp:TextBox>

                <label>Pontos Necessários:</label>
                <asp:TextBox ID="txtPontosNecessarioCupom" type="number" runat="server" Rows="3" MaxLength="45" min="0"></asp:TextBox>

                <label>Descrição:</label>
                <asp:TextBox ID="txtDescricaoCupom" runat="server" TextMode="MultiLine" Rows="2" MaxLength="45"></asp:TextBox>

                <asp:Label ID="lblImagemCupom" runat="server" Text="Imagem da recompensa:"></asp:Label>
                <asp:FileUpload ID="fluImagemCupom" CssClass="fluImagem" runat="server" onchange="mostrarImagem()" />

                <div class="pnlImagens">
                    <asp:Image ID="imgPreviewCupom" CssClass="imgPreview" runat="server" />
                </div>

                <asp:Literal ID="litAvisoRecompensaCupom" runat="server"></asp:Literal>

                <div class="fr">
                    <asp:Button ID="btnAdicaoImagemPremioCupom" CssClass="botoes" runat="server" Text="Adicionar"  OnClick="btnAdicaoImagemPremioCupom_Click"/>
                </div>
                <div class="cls"></div>
            </asp:Panel>
        </article>
         <script src="<%=ResolveUrl("~/js/previsualizarImagem.js") %>" type="text/javascript"></script>
    </form>
</body>
</html>
