<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dona_funcionario_adicionar_horario_servico.aspx.cs" Inherits="prjTCC.dona_funcionario_adicionar_horario_servico" %>

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
            <div class="titulo">
                <h1>Funcionário</h1>
            </div>

            <div class="dados-servico">
                <div>
                    <div class="logo-form">
                        <img src="imagens/logotipo.png" />
                    </div>
                </div>

                <label>Selecionar o serviço para listar horário:</label>
                <asp:DropDownList ID="cmbServicos" runat="server"></asp:DropDownList>

                <div class="filtros-lista-horario">
                    <asp:Button runat="server" ID="btnDomingo" Text="Domingo" CommandArgument="1" OnCommand="MudarDiaDaSemana" CssClass="botao_filtro_horario" />

                    <asp:Button runat="server" ID="btnSegunda" Text="Segunda-Feira" CommandArgument="2" OnCommand="MudarDiaDaSemana" CssClass="botao_filtro_horario" />

                    <asp:Button runat="server" ID="btnTerca" Text="Terça-Feira" CommandArgument="3" OnCommand="MudarDiaDaSemana" CssClass="botao_filtro_horario" />
                    <asp:Button runat="server" ID="btnQuarta" Text="Quarta-Feira" CommandArgument="4" OnCommand="MudarDiaDaSemana" CssClass="botao_filtro_horario" />
                    <asp:Button runat="server" ID="btnQuinta" Text="Quinta-Feira" CommandArgument="5" OnCommand="MudarDiaDaSemana" CssClass="botao_filtro_horario" />
                    <asp:Button runat="server" ID="btnSexta" Text="Sexta-Feira" CommandArgument="6" OnCommand="MudarDiaDaSemana" CssClass="botao_filtro_horario" />
                    <asp:Button runat="server" ID="btnSabado" Text="Sábado" CommandArgument="7" OnCommand="MudarDiaDaSemana" CssClass="botao_filtro_horario" />
                </div>

                <div class="div_horario">
                    <label>Horários:</label>
                    <hr />
                    <div class="div_horarios">
                        <asp:Repeater ID="rpHorarios" runat="server">
                            <ItemTemplate>
                                <div class="horario_tag">
                                    <p><%# DataBinder.Eval(Container.DataItem, "Hora") %></p>
                                    <asp:Button runat="server" Text="X" CssClass="fechar_tag" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Hora") %>' OnCommand="ExcluirHorario" />
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                        <asp:Button ID="btnAbrirAdicionarHorario" CssClass="btnAdicionar" runat="server" Text="+" OnClick="btAdicionarHorario_Click" />
                    </div>
                    <asp:Literal ID="litAvisoHorario" runat="server"></asp:Literal>
                </div>

                <div class="fr">
                    <asp:Button ID="btnListarHorarios" CssClass="botoes" runat="server" Text="Listar horários" OnClick="ListarHorarioBtn" />
                </div>
                <div class="cls"></div>
            </div>

            <asp:Panel ID="pnlNovoHorario" CssClass="fundo" runat="server" Visible="false">
                <div class="dados-servico aviso dados-novo-horario">
                    <label>Novo horário:</label>
                    <asp:TextBox ID="txtDataHoraFuncionario" Rows="2" TextMode="Time" runat="server"></asp:TextBox>

                    <div class="fr">
                        <asp:Button ID="btnAdicionarHorario" CssClass="botoes" runat="server" Text="Adicionar" OnClick="AdicionarHorario" />
                        <asp:Button ID="btnCancelar" CssClass="botoes" runat="server" Text="Cancelar" OnClick="CancelarAdicionarHorario" />

                    </div>

                    <div class="cls"></div>
                </div>
            </asp:Panel>
        </article>
    </form>
</body>
</html>
