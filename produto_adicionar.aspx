<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="produto_adicionar.aspx.cs" Inherits="prjTCC.produto_adicionar" %>

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
                <div>
                    <div class="logo-form">
                        <img src="imagens/logotipo.png">
                    </div>
                </div>

                <label>Nome do Produto</label>
                <asp:TextBox ID="txtNome" runat="server" type="name"></asp:TextBox>

                <label>Quantidade do Produto</label>
                <asp:TextBox ID="txtQuantidade" runat="server" type="name"></asp:TextBox>

                <label>Descrição do Produto</label>
                <asp:TextBox ID="txtDescricao" runat="server" type="name"></asp:TextBox>

                <label>Tipo Produto</label>
                <asp:DropDownList ID="drpCodTipo" runat="server">
                    <asp:ListItem Value="1">Uso em quantidade</asp:ListItem>
                    <asp:ListItem Value="2">Uso único</asp:ListItem>
                </asp:DropDownList>

                <div class="fr">
                    <asp:Button class="botoes" ID="btnAdicionar" runat="server" Text="Adicionar" OnClick="btnAdicionar_Click" />
                    <asp:Button class="botoes excluir" ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
                </div>
                <asp:Literal ID="litAviso" runat="server"></asp:Literal>
                <div class="cls"></div>
            </div>
        </article>
    </form>
    <script src="<%=ResolveUrl("~/js/previsualizarImagem.js") %>" type="text/javascript"></script>
</body>
</html>
