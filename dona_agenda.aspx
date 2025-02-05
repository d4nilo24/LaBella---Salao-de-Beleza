<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dona_agenda.aspx.cs" Inherits="prjTCC.dona_agenda_" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="preconnect" href="https://fonts.googleapis.com" />
    <link rel="preconnect" href="https://fonts.gstatic.com" />
    <link href="https://fonts.googleapis.com/css2?family=Open+Sans&display=swap" rel="stylesheet" />
    <title>La Bella</title>
    <meta charset="utf-8" />
    <link rel="stylesheet" type="text/css" href="css/estiloDona.css" />
    <script src="https://kit.fontawesome.com/f9a95042e5.js" crossorigin="anonymous"></script>
    <meta name="viewport" content="width=device-width, initial-scale=1" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
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
            <a href="dona_agenda.aspx" class="active">
                <img src="imagens/agenda.png" />Agenda</a>
            <a href="dona_servicos.aspx">
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
            <div class="divAgenda">
            <div class="div_dias_dona_agenda">
                
                <div id="centro">
                    <p>
                        <asp:Label ID="lblData" runat="server" Text="Data da agenda"></asp:Label>
                        <asp:TextBox ID="txtData" runat="server" placeholder="From" type="date" AutoPostBack="true"></asp:TextBox></p>
                </div>
            </div>

            <div class="divTabelaAgenda">
                <asp:Table ID="tblAgendamento" runat="server" CssClass="tabelas tabelaDona">
                    <asp:TableHeaderRow runat="server" ID="tbrDias" CssClass="thRadiusRight" TableSection="TableHeader">
                        <asp:TableHeaderCell>Dia</asp:TableHeaderCell>
                        <asp:TableHeaderCell>Funcionários</asp:TableHeaderCell>
                    </asp:TableHeaderRow>
                </asp:Table>
            </div>
            <asp:Literal ID="litAviso" runat="server"></asp:Literal>
                </div>
        </div>
    </form>
</body>
</html>
<script src="<%=ResolveUrl("~/js/ajustarTamanhoDivAgenda.js") %>" type="text/javascript"></script>
