<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dona_servico_adicionar.aspx.cs" Inherits="prjTCC.dona_servico_adicionar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Open+Sans&display=swap" rel="stylesheet">
    <title>La Bella</title>
    <meta charset="utf-8">
    <link rel="stylesheet" type="text/css" href="css/estiloDona.css">
    <script src="https://kit.fontawesome.com/f9a95042e5.js" crossorigin="anonymous"></script>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
</head>
<body>

    <form id="form1" runat="server">
        <header>
            <div class="logo-container">
                <a href="dona_agenda.html">
                    <img src="imagens/logotipo.png" alt="logo do site">
                </a>
            </div>
        </header>

        <div class="sidebar">
            <a href="dona_agenda.aspx">
                <img src="imagens/agenda.png" />Agenda</a>
            <a href="dona_servicos.aspx" class="active">
                <img src="imagens/secador.png" />Serviços</a>
            <a href="dona_funcionarios.aspx" >
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
                        <img src="imagens/logotipo.png"/>
                    </div>
                </div>

                <!--<h2>Adicionar serviço</h2>-->

                <label>Nome do serviço:</label>
                <asp:TextBox ID="txtNomeServico" runat="server" Type="text" MaxLength="45"></asp:TextBox>

                <div class="inputs-separadas">
                    <p>
                        <label>Valor:</label>
                        <asp:TextBox ID="txtValor" runat="server" Type="number" min="0" max="999999" MaxLength="12" step="0.01" pattern="\d+(\.\d{1,2})?"></asp:TextBox>

                    </p>
                    <p>
                        <label>Duração:</label>
                        <asp:TextBox ID="txtDuracao" runat="server" Type="time"></asp:TextBox>
                    </p>

                    <p>
                        <label>Categoria:</label>
                        <asp:DropDownList ID="ddlCategoria" runat="server"></asp:DropDownList>
                    </p>

                    <p>
                        <label>Pontos:</label>
                        <asp:TextBox ID="txtPontos" runat="server" Type="number" min="0"></asp:TextBox>
                    </p>
                </div>

                <label>Descrição do serviço:</label>
                <asp:TextBox ID="txtDescricao" runat="server" TextMode="MultiLine" Rows="5" MaxLength="255" cols="20"></asp:TextBox>

                <asp:Label ID="lblImagem" runat="server" Text="Imagem (é possível adicionar mais de uma)" Visible="true"></asp:Label>
                <asp:FileUpload ID="fluImagem" runat="server" AllowMultiple="true" max="9" onchange="mostrarImagens()" />
                <asp:Label ID="lblObs" runat="server" Text="<i class='fa-solid fa-triangle-exclamation'></i> Se não houver nenhuma imagem, o serviço não aparecerá ao cliente."></asp:Label>

                <asp:Panel ID="divPreview" CssClass="pnlListaImagens" runat="server"></asp:Panel>
                
                <div class="fr">
                    <asp:Button ID="btnAdicionar" CssClass="botoes" runat="server" Text="Adicionar" OnClick="btnAdicionar_Click" />
                    <asp:Button ID="btnCancelar" CssClass="botoes" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
                </div>
                <div class="cls"></div>
                <asp:Literal ID="litAviso" runat="server"></asp:Literal>
            </div>
        </article>
    </form>
    <script src="<%=ResolveUrl("~/js/previsualizarImagem.js") %>" type="text/javascript"></script>
    <script src="<%=ResolveUrl("~/js/maxArquivo.js") %>" type="text/javascript"></script>
</body>
</html>
