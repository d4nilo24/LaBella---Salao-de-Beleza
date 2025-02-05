<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="produto_expandido.aspx.cs" Inherits="prjTCC.produto_expandido" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
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
         <!--<div class="titulo">
            <h1>Funcionário</h1>    
        </div>-->
      
        <div class="dados-servico">
            <div>
                <div class="logo-form">
                  <img src="imagens/logotipo.png"/>
                </div>
            </div>

            <label>Código produto:</label>
            <asp:TextBox ID="txtCodProduto" ReadOnly="true" runat="server" Enabled="false"></asp:TextBox>

            <label>Nome Produto:</label>
            <asp:TextBox ID="txtNomeProduto" runat="server" MaxLength="45"></asp:TextBox>

            <label>Quantidade:</label>
            <asp:TextBox ID="txtQuantidadeProduto" runat="server" MaxLength="255"></asp:TextBox>

            <label>Descrição:</label>
            <asp:TextBox ID="txtDescricaoProduto" runat="server" MaxLength="255"></asp:TextBox>

            <label>Tipo Produto:</label>
            <asp:DropDownList ID="drpCodTipo" runat="server">
                    <asp:ListItem Value="1">Uso em quantidade</asp:ListItem>
                    <asp:ListItem Value="2">Uso único</asp:ListItem>
                </asp:DropDownList>

            <asp:Literal ID="litAvisoProduto" runat="server"></asp:Literal>


            <div class="fr">
                <asp:Button ID="btnEditarProduto" CssClass="botoes" runat="server" Text="Editar"  OnClick="btnEditarProduto_Click"/>
                <asp:Button ID="btnExcluirProduto" CssClass="botoes excluir" runat="server" Text="Excluir" OnClick="btnExcluirProduto_Click1" />
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
    <script type="text/javascript" src="js/carrosselServico.js"></script>
</body>
</html>
