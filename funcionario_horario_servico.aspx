<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="funcionario_horario_servico.aspx.cs" Inherits="prjTCC.funcionario_horario_servico" %>

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
                    <img src="imagens/logotipo.png" alt="logo do site"/>
                </a>
            </div>
        </header>

        <div class="sidebar">
            <a href="dona_agenda.aspx">
                <img src="imagens/agenda.png">Agenda</a>
            <a href="dona_servicos.aspx">
                <img src="imagens/secador.png">Serviços</a>
            <a href="dona_funcionarios.aspx" class="active">
                <img src="imagens/usuario.png">Funcionários</a>
            <a href="dona_recompensas.aspx">
                <img src="imagens/presente.png">Recompensas</a>
        </div>

        <article>
            <div class="titulo">
                <h1>Funcionário</h1>
            </div>

            <div class="dados-servico">
                <div>
                    <div class="logo-form">
                        <img src="imagens/logotipo.png">
                    </div>
                </div>

                <label>Horário de trabalho:</label>

                <div class="filtros-lista">
                    <asp:Button runat="server" Text="Domingo" CommandArgument="1" OnCommand="MudarDiaDaSemana" />

                    <asp:Button runat="server" Text="Segunda-Feira" CommandArgument="2" OnCommand="MudarDiaDaSemana" />

                    <asp:Button runat="server" Text="Terça-Feira" CommandArgument="3" OnCommand="MudarDiaDaSemana" />
                    <asp:Button runat="server" Text="Quarta-Feira" CommandArgument="4" OnCommand="MudarDiaDaSemana" />
                    <asp:Button runat="server" Text="Quinta-Feira" CommandArgument="5" OnCommand="MudarDiaDaSemana" />
                    <asp:Button runat="server" Text="Sexta-Feira" CommandArgument="6" OnCommand="MudarDiaDaSemana" />
                    <asp:Button runat="server" Text="Sábado" CommandArgument="7" OnCommand="MudarDiaDaSemana" />
                </div>

                <label>Selecionar o serviço para listar horário:</label>
                <asp:DropDownList ID="cmbServicos" runat="server"></asp:DropDownList>

                <label>Horários:</label>
                <div class="div_horario">
                    <asp:Repeater ID="rpHorarios" runat="server">

                        <ItemTemplate>
                            <div class="horario_tag">
                                <p><%# DataBinder.Eval(Container.DataItem, "Hora") %></p>
                                <asp:Button runat="server" Text="X" CssClass="fechar_tag" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Hora") %>' OnCommand="ExcluirHorario" />
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <asp:Literal ID="litAvisoHorario" runat="server"></asp:Literal>

                <div class="fr">
                    <asp:Button ID="btnListarHorarios" CssClass="botoes" runat="server" Text="Listar Horário" OnClick="ListarHorarioBtn" />
                </div>
                <div class="cls"></div>
            </div>

            <div class="dados-servico dados-servico-embaixo">

                <label>Selecionar o serviço para adicionar o horário:</label>
                <asp:DropDownList ID="cmbServicosFuncionario" runat="server"></asp:DropDownList>

                <label>Novo horário:</label>
                <asp:TextBox ID="txtDataHoraFuncionario" Rows="2" TextMode="Time" runat="server"></asp:TextBox>

                <div class="fr">
                    <asp:Button ID="btnAdicionarFuncionario" CssClass="botoes" runat="server" Text="Adicionar   " />
                </div>

                <div class="cls"></div>
            </div>
        </article>
    </form>
</body>
</html>
