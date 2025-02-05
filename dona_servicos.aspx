<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dona_servicos.aspx.cs" Inherits="prjTCC.dona_servicos" %>

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
            <div class="itens-flex">
                <h1>Serviços</h1>

                <div class="filtra">
                    <asp:TextBox ID="txtFiltroServico" CssClass="txtFiltrar" placeholder="Filtre por código, nome ou categoria." runat="server"></asp:TextBox>
                    <asp:Button ID="btnFiltraServicos" CssClass="btnPesquisar" runat="server" Text="Buscar" OnClick="btnFiltraServicos_Click" />
                    <asp:Literal ID="litAviso" runat="server"></asp:Literal>
                    <button class="btnAdicionar"><i class="fa-solid fa-plus"></i></button>
                </div>

                <div class="btnAdicionar-container">
                    <a href="dona_servico_adicionar.aspx">
                        <div class="btnAdicionar mais"><i class="fa-solid fa-plus"></i></div>
                    </a>
                </div>
            </div>

            <asp:GridView ID="grdServicos" CssClass="tabelas" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:HyperLinkField DataNavigateUrlFields="cdservico" DataNavigateUrlFormatString="dona_servico_expandido.aspx?servico={0}" DataTextField="nmservico" HeaderText="Servi&#231;o">
                        <HeaderStyle CssClass="thRadiusRight"></HeaderStyle>
                    </asp:HyperLinkField>
                    <asp:HyperLinkField DataNavigateUrlFields="cdservico" DataNavigateUrlFormatString="dona_servico_expandido.aspx?servico={0}" DataTextField="nmcategoria" HeaderText="Categoria"></asp:HyperLinkField>
                    <asp:HyperLinkField DataNavigateUrlFields="cdservico" DataNavigateUrlFormatString="dona_servico_expandido.aspx?servico={0}" DataTextField="vlservico" HeaderText="Valor">
                        <HeaderStyle CssClass="thRadiusLeft"></HeaderStyle>
                    </asp:HyperLinkField>
                </Columns>
            </asp:GridView>
        </article>
    </form>
</body>
</html>
