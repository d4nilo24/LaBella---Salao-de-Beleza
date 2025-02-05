<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dona_recompensa_expandido.aspx.cs" Inherits="prjTCC.dona_recompensa_expandido" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
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
                    <img src="imagens/logotipo.png" alt="logo do site">
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
        <a href="dona_agenda.aspx"><img src="imagens/agenda.png">Agenda</a>
        <a href="dona_servicos.aspx"><img src="imagens/secador.png">Serviços</a>
        <a href="dona_funcionarios.aspx"><img src="imagens/usuario.png">Funcionários</a>
        <a href="dona_recompensas.aspx" class="active"><img src="imagens/presente.png">Recompensas</a>
          <a href="dona_banner.aspx">
                <img src="imagens/galeria.png" />Banners</a>
            <a href="estoque.aspx">
                <img src="imagens/pacote.png" />Estoque</a>
          <a href="logout.aspx">
                <img src="imagens/logout.png" />Sair</a>
      </div>    

      <article>
         <!--<div class="titulo">
            <h1>Recompensa</h1>    
        </div>-->
      
        <div class="dados-servico">
            <div>
                <div class="logo-form">
                  <img src="imagens/logotipo.png"/>
                </div>
            </div>

            <asp:Panel ID="pnlFormCupom" Visible="false" runat="server">
                <label>Código:</label>
                <asp:TextBox ID="txtCodPremioCupom" ReadOnly="true" runat="server" Enabled="false"></asp:TextBox>

                <label>Tipo de recompensa:</label>
                <asp:TextBox ID="txtTipoRecompensa" ReadOnly="true" runat="server" Enabled="false"></asp:TextBox>

                <label>Nome de recompensa:</label>
                <asp:TextBox ID="txtNomePremio" runat="server"></asp:TextBox>

                <div class="inputs-separadas">
                    <p>
                      <label>Codigo do cupom:</label>
                      <asp:TextBox ID="txtCodCupomDesconto" ReadOnly="true" runat="server" Enabled="false"></asp:TextBox>
                    </p>

                    <p>
                        <label>Serviço ao cupom:</label>
                        <asp:DropDownList ID="cmbServicoCupom" runat="server"></asp:DropDownList>
                    </p>

                    <p>
                        <label>Categoria ao cupom:</label>
                        <asp:DropDownList ID="cmbCategoria" runat="server"></asp:DropDownList>
                    </p>

                    <p>
                      <label>Desconto (em %):</label>
                      <asp:TextBox ID="txtPorcentagemCupomDesconto" TextMode="Number" runat="server" min="0" max="100"></asp:TextBox>
                    </p>

                    <p>
                        <label>Pontos necessários:</label>
                        <asp:TextBox ID="txtPontoNecessariosCupomDesconto" runat="server" TextMode="Number" min="0"></asp:TextBox>
                    </p>
                </div>

                <label>Descrição:</label>
                <asp:TextBox ID="txtDescricaoCupomDesconto" TextMode="MultiLine" Rows="3"  runat="server" MaxLength="45"></asp:TextBox>

                 <label>Escolha uma imagem para a recompensa:</label>
                <asp:FileUpload ID="flUploadRecompensaCupom" runat="server" />

                <asp:Button ID="btnAdicionarImagem" CssClass="botoes" runat="server" Text="Adicionar Imagem" OnClick="btnAdicionarImagem_Click"/>
                <!--<div class="cls"></div>-->

                <asp:Panel ID="pnlImagensContainer" runat="server">
                    <asp:Panel ID="pnlListaImagens" CssClass="pnlListaImagens" runat="server"></asp:Panel>
                </asp:Panel>

                <asp:Literal ID="litAvisoCupomDesconto" runat="server"></asp:Literal>

                <div class="fr">
                    <asp:Button ID="btnEditarRecompensaCupom" CssClass="botoes" runat="server" Text="Editar dados" OnClick="btnEditarRecompensaCupom_Click1"/>
                    <asp:Button ID="btnExcluirRecompensaCupom" CssClass="botoes excluir" runat="server" Text="Excluir" OnClick="btnExcluirRecompensaCupom_Click" />
                </div>

                <div class="cls"></div>
            </asp:Panel>

            <asp:Panel ID="pnlFormProduto" Visible="false" runat="server">
                <label>Código:</label>
                <asp:TextBox ID="txtCodPremioProduto" ReadOnly="true" runat="server" Enabled="false"></asp:TextBox>

                <label>Tipo de recompensa:</label>
                <asp:TextBox ID="txtNomeTipoRecompensaProduto" ReadOnly="true" runat="server" Enabled="false"></asp:TextBox>

                <label>Nome da recompensa:</label>
                <asp:TextBox ID="txtNomeRecompensaProduto" runat="server"></asp:TextBox>

                <label>Pontos necessários:</label>
                <asp:TextBox ID="txtPontosNecesariosProduto" runat="server" TextMode="Number" min="0"></asp:TextBox>

                <label>Descrição:</label>
                <asp:TextBox ID="txtxDescricaoProduto" TextMode="MultiLine" Rows="3"  runat="server" MaxLength="45"></asp:TextBox>

                <asp:Literal ID="litAvisoProduto" runat="server"></asp:Literal>

                <label>Escolha uma imagem para a recompensa:</label>
                <asp:FileUpload ID="flUploadRecompensaProduto" runat="server"/>

                <asp:Button ID="btnAdicionaImagemProduto" CssClass="botoes" runat="server" Text="Adicionar Imagem" OnClick="btnAdicionaImagemProduto_Click"/>
                <!--<div class="cls"></div>-->

                <asp:Panel ID="pnlImagensProdutoContainer" runat="server">
                    <asp:Panel ID="pnlListaImagensProduto" CssClass="pnlListaImagens" runat="server"></asp:Panel>
                </asp:Panel>

                <div class="fr">
                    <asp:Button ID="btnEditarProduto" CssClass="botoes" runat="server" Text="Editar dados" OnClick="btnEditarProduto_Click"/>
                    <asp:Button ID="btnExcluirProduto" CssClass="botoes excluir" runat="server" Text="Excluir"  OnClick="btnExcluirRecompensaCupom_Click"/>
                </div>

                <div class="cls"></div>
            </asp:Panel>
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
    <script type="text/javascript" src="js/carrosselServico.js"></script>
</body>
</html>
