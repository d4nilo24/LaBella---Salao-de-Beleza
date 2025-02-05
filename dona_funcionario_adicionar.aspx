<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dona_funcionario_adicionar.aspx.cs" Inherits="prjTCC.dona_funcionario_adicionar" %>

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

                <!--<h2>Adicionar funcionário</h2>-->

                <div class="inputs-separadas">
                    <p>
                        <label>Nome do funcionário:</label>
                        <asp:TextBox ID="txtNome" runat="server"></asp:TextBox>
                    </p>
                </div>

                <label>E-mail</label>
                <asp:TextBox ID="txtEmail" runat="server" type="email"></asp:TextBox>

                <label>Senha</label>
                <asp:TextBox ID="txtSenha" runat="server" type="password"></asp:TextBox>

                <label>Tipo de funcionário</label>
                <asp:DropDownList ID="cmbTipoFuncionario" runat="server"></asp:DropDownList>

                <asp:Label ID="lblImagem" runat="server" Text="Imagem (recomendado)"></asp:Label>
                <asp:FileUpload ID="fluImagem" runat="server" onchange="mostrarImagem()" />

                <div class="pnlImagens">
                    <asp:Image ID="imgPreview" runat="server" />
                </div>

                <div class="fr">
                    <asp:Button class="botoes" ID="btnAdicionar" runat="server" Text="Adicionar" OnClick="btnAdicionar_Click" />
                    <asp:Button class="botoes excluir" ID="btnCancelar" runat="server" Text="Cancelar" />
                </div>
                <asp:Literal ID="litAviso" runat="server"></asp:Literal>
                <div class="cls"></div>
            </div>
        </article>
    </form>
    <script src="<%=ResolveUrl("~/js/previsualizarImagem.js") %>" type="text/javascript"></script>
</body>
</html>
