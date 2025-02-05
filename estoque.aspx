<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="estoque.aspx.cs" Inherits="prjTCC.estoques" %>

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
            <a href="dona_funcionarios.aspx" >
                <img src="imagens/usuario.png" />Funcionários</a>
            <a href="dona_recompensas.aspx">
                <img src="imagens/presente.png" />Recompensas</a>
            <a href="dona_banner.aspx">
                <img src="imagens/galeria.png" />Banners</a>
            <a href="estoque.aspx" class="active">
                <img src="imagens/pacote.png" />Estoque</a>
            <a href="logout.aspx">
                <img src="imagens/logout.png" />Sair</a>
        </div>

        <article>
            <div class="itens-flex">
                <h1>Produtos</h1>

                <div class="filtra">
                    <asp:TextBox ID="txtFiltroproduto" CssClass="txtFiltrar" placeholder="Filtre por código ou nome." runat="server"></asp:TextBox>
                    <asp:Button ID="btnFiltroproduto" CssClass="btnPesquisar" runat="server" Text="Buscar" OnClick="btnFiltrarProduto_Click" />
                    <asp:Literal ID="litviso" runat="server"></asp:Literal>
                    <button class="btnAdicionar"><i class="fa-solid fa-plus"></i></button>
                </div>

                <div class="btnAdicionar-container">
                    <a href="produto_adicionar.aspx">
                        <div class="btnAdicionar mais"><i class="fa-solid fa-plus"></i></div>
                    </a>
                </div>
            </div>


            <asp:GridView ID="grdEstoque" CssClass="tabelas" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:HyperLinkField DataNavigateUrlFields="cdproduto" DataNavigateUrlFormatString="produto_expandido.aspx?cdproduto={0}" DataTextField="cdproduto" HeaderText="Código">
                        <HeaderStyle CssClass="thRadiusRight"></HeaderStyle>
                    </asp:HyperLinkField>
                    <asp:HyperLinkField DataNavigateUrlFields="cdproduto"  DataTextField="nmproduto" DataNavigateUrlFormatString="produto_expandido.aspx?cdproduto={0}" HeaderText="Nome"></asp:HyperLinkField>
                    <asp:HyperLinkField DataNavigateUrlFields="cdproduto"  DataTextField="qtproduto" DataNavigateUrlFormatString="produto_expandido.aspx?cdproduto={0}" HeaderText="Quantidade">
                        <HeaderStyle CssClass="thRadiusLeft"></HeaderStyle>
                    </asp:HyperLinkField>
                </Columns>
            </asp:GridView>
        </article>
    </form>
</body>
</html>
