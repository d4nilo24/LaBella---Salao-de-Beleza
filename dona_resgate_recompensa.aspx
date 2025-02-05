<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dona_resgate_recompensa.aspx.cs" Inherits="prjTCC.resgate_recompensa" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
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
            <a href="dona_agenda.aspx">
                <div class="logo-container">
                    <img src="imagens/logotipo.png" alt="logo do site"/>
                </div>
            </a>
            <div class="usuario-container">
                <a href="index.aspx">
                    <i class="fa-regular fa-eye"></i>
                    <p>Mudar para visão do cliente</p>
                </a>
            </div>
        </header>

        <div class="sidebar">
            <a href="dona_agenda.aspx">
                <img src="imagens/agenda.png">Agenda</a>
            <a href="dona_servicos.aspx">
                <img src="imagens/secador.png">Serviços</a>
            <a href="dona_funcionarios.aspx">
                <img src="imagens/usuario.png">Funcionários</a>
            <a href="dona_recompensas.aspx" class="active">
                <img src="imagens/presente.png">Recompensas</a>
            <a href="dona_banner.aspx">
                <img src="imagens/galeria.png" />Banners</a>
            <a href="estoque.aspx">
                <img src="imagens/pacote.png" />Estoque</a>
            <a href="logout.aspx">
                <img src="imagens/logout.png" />Sair</a>
        </div>

        <article>
            <div class="itens-flex">
                <h1>Resgate de Recompensas</h1>

                <div class="filtra">
                    <asp:TextBox ID="txtFiltroPremios" CssClass="txtFiltrar" placeholder="Filtre pelo prêmio ou email do cliente" runat="server"></asp:TextBox>
                    <asp:Button ID="btnFiltraRecompensas" CssClass="btnPesquisar" runat="server" Text="Buscar" OnClick="btnFiltraRecompensas_Click"/>
                    <asp:Literal ID="litAviso" runat="server"></asp:Literal>
                    <button class="btnAdicionar"><i class="fa-solid fa-plus"></i></button>
                </div>

            </div>

            <div class="link-tabela">
                 <asp:HyperLink ID="hplinkVoltarRecompensas" runat="server">HyperLink</asp:HyperLink>
            </div>

            <asp:GridView ID="grdPremiosClientes" CssClass="tabelas" runat="server" AutoGenerateColumns="False" OnRowCommand="grdPremiosClientes_RowCommand">
                <Columns>
                    <asp:BoundField DataField="cdpremio" HeaderText="C&#243;digo">
                        <HeaderStyle CssClass="thRadiusRight"></HeaderStyle>
                    </asp:BoundField>
                    <asp:BoundField DataField="nmpremio" HeaderText="Recompensa"></asp:BoundField>
                    <asp:BoundField DataField="logincli" HeaderText="Cliente"></asp:BoundField>
                    
                  <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="btnResgatar" runat="server" CommandName="Retirar" CommandArgument='<%# String.Format("{0},{1}", Eval("cdpremio"), Eval("logincli")) %>' Text="Retirar" />
                            </ItemTemplate>
                        </asp:TemplateField>
                </Columns>
            </asp:GridView>

        </article>

         <asp:Panel ID="pnlConfirmarExclusao" runat="server" CssClass="fundo" Visible="false">
            <div class="aviso">
                <p>Você tem certeza de que deseja retirar?</p>
                <asp:Button ID="btnSim" CssClass="botoes" runat="server" Text="Sim" OnClick="btnSim_Click" />
                <asp:Button ID="btnNao" CssClass="botoes btn-cancelar" runat="server" Text="Não" OnClick="btnNao_Click" />
            </div>
        </asp:Panel>
    </form>
</body>
</html>
