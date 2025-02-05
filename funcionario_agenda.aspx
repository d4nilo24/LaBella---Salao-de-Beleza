<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="funcionario_agenda.aspx.cs" Inherits="prjTCC.funcionario_agenda" %>

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
            <a href="funcionario_agenda.aspx" class="active">
                <img src="imagens/agenda.png" />Agenda</a>
            <a href="funcionario_editar.aspx">
                <img src="imagens/usuario.png" />Funcionário</a>
             <a href="logout.aspx">
                <img src="imagens/logout.png" />Sair</a>
        </div>

        <div class="divAgenda">
            <div>
                <asp:Panel ID="pnlAgendaInformacoes" runat="server">
                    <label>Data:</label>
                    <asp:TextBox ID="txtData" runat="server" placeholder="From" type="date"></asp:TextBox>
                    <asp:Button ID="btnMostrarAgenda" runat="server" Text="Confirmar Data" OnClick="btnMostrarAgenda_Click" CssClass="botoes" />
                </asp:Panel>
            </div>

            <asp:Table ID="tblAgendamento" runat="server" CssClass="tabelas">
                <asp:TableHeaderRow runat="server" ID="tbrDias" CssClass="thRadiusRight" TableSection="TableHeader">
                    <asp:TableHeaderCell></asp:TableHeaderCell>
                </asp:TableHeaderRow>
            </asp:Table>
        </div>
    </form>
</body>
</html>

