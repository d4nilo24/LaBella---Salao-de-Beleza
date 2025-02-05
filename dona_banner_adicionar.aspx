<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dona_banner_adicionar.aspx.cs" Inherits="prjTCC.dona_banner_adicionar" %>

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
            <a href="dona_funcionarios.aspx">
                <img src="imagens/usuario.png" />Funcionários</a>
            <a href="dona_recompensas.aspx">
                <img src="imagens/presente.png" />Recompensas</a>
            <a href="dona_banner.aspx" class="active">
                <img src="imagens/galeria.png" />Banners</a>
            <a href="estoque.aspx">
                <img src="imagens/pacote.png" />Estoque</a>
            <a href="logout.aspx">
                <img src="imagens/logout.png" />Sair</a>
        </div>

        <article>
            <div class="titulo">
                <h1>Banner</h1>
            </div>

            <div class="dados-servico">
                <div>
                    <div class="logo-form">
                        <img src="imagens/logotipo.png">
                    </div>
                </div>
                
                <label>Link do Banner:</label>
                <asp:DropDownList ID="drpLink" runat="server" AutoPostBack="true" OnSelectedIndexChanged="drpLink_SelectedIndexChanged">
                    <asp:ListItem Value="index.aspx">index.aspx</asp:ListItem>
                    <asp:ListItem Value="servicos.aspx">servicos.aspx</asp:ListItem>
                    <asp:ListItem Value="servico_expandido.aspx">servico_expandido.aspx</asp:ListItem>
                    <asp:ListItem Value="recompensas.aspx">recompensas.aspx</asp:ListItem>
                    <asp:ListItem Value="login.aspx">login.aspx</asp:ListItem>
                    <asp:ListItem Value="cadastro.aspx">cadastro.aspx</asp:ListItem>
                    <asp:ListItem Value="conta_cliente.aspx">minha_conta_agendamentos.aspx</asp:ListItem>
                    <asp:ListItem Value="minha_conta_agendamentos.aspx">minha_conta_agendamentos.aspx</asp:ListItem>
                    <asp:ListItem Value="minha_conta_recompensas.aspx">minha_conta_recompensas.aspx</asp:ListItem>
                    <asp:ListItem Value="minha_conta_agendamentos.aspx">minha_conta_agendamentos.aspx</asp:ListItem>
                    <asp:ListItem Value="0">Link personalizado</asp:ListItem>
                </asp:DropDownList>

                <asp:Panel ID="pnlQuery" runat="server">
                    <label>QueryString, se houver:</label>
                    <asp:TextBox ID="txtQuery" runat="server" placeholder="?servico=1">
                    </asp:TextBox>
                </asp:Panel>

                <asp:Panel ID="pnlLinkPersonalizado" runat="server" Visible="false">
                    <label>Link de redirecionamento personalizado:</label>
                    <asp:TextBox ID="txtLinkPersonalizado" runat="server">
                    </asp:TextBox>
                </asp:Panel>

                <label>Imagens do Banner:</label>
                <br />

                <div>
                    <asp:Label ID="lblImagemDesktop" runat="server" Text="Imagem de tela grande"></asp:Label>
                    <asp:FileUpload ID="fluImagemDesktop" runat="server" onchange="mostrarImagemBanner()" />

                    <label>OBS.: ideal 1920 x 500 px :</label>

                    <div class="pnlImagensBanner">
                        <asp:Image ID="imgPreviewDesktop" runat="server" />
                    </div>
                </div>

                <div>
                    <asp:Label ID="lblImagemMobile" runat="server" Text="Imagem de tela pequena"></asp:Label>
                    <asp:FileUpload ID="fluImagemMobile" runat="server" onchange="mostrarImagemBanner()" />

                     <label>OBS.: ideal 400 x 500 px :</label>

                    <div class="pnlImagensBanner">
                        <asp:Image ID="imgPreviewMobile" runat="server" />
                    </div>

                    <asp:Panel ID="pnlImagensContainer" runat="server">
                        <asp:Panel ID="pnlListaImagens" CssClass="pnlListaImagens" runat="server"></asp:Panel>
                    </asp:Panel>
                </div>

                <asp:Literal ID="litAviso" runat="server"></asp:Literal>

                <div class="fr">
                    <asp:Button ID="btnAdicionarBanner" CssClass="botoes" runat="server" Text="Adicionar" OnClick="btnAdicionarBanner_Click" />
                    <asp:Button ID="btnCancelar" CssClass="botoes excluir" runat="server" Text="Cancelar" />
                </div>

                <div class="cls"></div>
            </div>
        </article>
    </form>
    <script src="<%=ResolveUrl("~/js/previsualizarImagem.js") %>" type="text/javascript"></script>
</body>
</html>
