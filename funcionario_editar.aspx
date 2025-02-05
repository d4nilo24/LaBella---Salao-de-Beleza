<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="funcionario_editar.aspx.cs" Inherits="prjTCC.funcionario_editar" %>


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
                    <img src="imagens/logotipo.png" alt="logo do site"/>
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
        <a href="funcionario_agenda.aspx"><img src="imagens/agenda.png">Agenda</a>
        <a href="funcionario_editar.aspx" class="active"><img src="imagens/usuario.png">Funcionário</a>
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

            <label>Código:</label>
            <asp:TextBox ID="txtCodFuncionario" ReadOnly="true" Enabled="false" runat="server"></asp:TextBox>

            <label>Nome Completo:</label>
            <asp:TextBox ID="txtNomeCompletoFuncionario" ReadOnly="true" Enabled="false" runat="server"></asp:TextBox>

            <label>E-mail:</label>
            <asp:TextBox ID="txtEmailFuncionario" ReadOnly="true" Enabled="false" runat="server"></asp:TextBox>

            <label>Tipo:</label>
            <asp:TextBox ID="txtTipoFuncionario" ReadOnly="true" Enabled="false" runat="server"></asp:TextBox>

            <asp:HyperLink ID="hpEditarHorario" runat="server">HyperLink</asp:HyperLink>
            <div class="clsLink"></div>

            <label>Foto do(a) funcionário(a):</label>
            <br />

            <asp:Panel ID="pnlImagensContainer" runat="server">
                <asp:Panel ID="pnlListaImagens" CssClass="pnlListaImagens" runat="server"></asp:Panel>
            </asp:Panel>

            <asp:Literal ID="litAviso" runat="server"></asp:Literal>

        </div>
        </article>
            <script type="text/javascript" src="js/carrosselServico.js"></script>
    </form>
</body>
</html>

