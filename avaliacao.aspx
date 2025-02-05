<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="avaliacao.aspx.cs" Inherits="prjTCC.avaliacao" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Open+Sans&display=swap" rel="stylesheet">
    <title>La Bella</title>
    <meta charset="utf-8">
    <link rel="stylesheet" type="text/css" href="css/estilo.css">
    <script src="https://kit.fontawesome.com/f9a95042e5.js" crossorigin="anonymous"></script>
    <meta name="viewport" content="width=device-width, initial-scale=1">
</head>
<body>
    <form id="form1" runat="server">
        <header>
            <div class="logo-container">
                <asp:HyperLink NavigateUrl="~/index.aspx" runat="server">
                        <img src="imagens/logotipo.png" alt="logo do site"/>
                </asp:HyperLink>
            </div>

            <nav>
                <ul>
                    <li>
                        <asp:HyperLink NavigateUrl="~/servicos.aspx" runat="server">Serviços</asp:HyperLink></li>
                    <li>
                        <asp:HyperLink NavigateUrl="~/recompensas.aspx" runat="server">Recompensas</asp:HyperLink></li>
                </ul>
            </nav>

            <div class="menu-sanduiche">
                <i class="fa-solid fa-bars"></i>
            </div>

            <div class="usuario-container">
                <asp:HyperLink ID="hpLogin" runat="server">
                    <asp:Literal ID="litIconeUsuario" runat="server"></asp:Literal>
                </asp:HyperLink>
            </div>

            <div class="dropdown">
                <ul>
                    <li>
                        <asp:HyperLink NavigateUrl="~/servicos.aspx" runat="server">Serviços</asp:HyperLink></li>
                    <li>
                        <asp:HyperLink NavigateUrl="~/recompensas.aspx" runat="server">Recompensas</asp:HyperLink></li>
                    <li>
                        <asp:HyperLink ID="hpLoginResponsivo" runat="server">
                            <div class="botoes">
                                <asp:Literal ID="litLoginResponsivo" runat="server"></asp:Literal>
                            </div>
                        </asp:HyperLink>
                    </li>
                </ul>
            </div>
        </header>

        <section class="container">

            <div class="section-agendamento">
                <div class="avaliacao-section">
                    <h1>Avalie a sua experiência</h1>

                    <h3>Atribua uma nota ao serviço realizado.</h3>

                    <asp:Panel ID="pnlEstrelasAvaliativas" CssClass="estrelas-avaliativas-escolher" runat="server"></asp:Panel>

                    <asp:HiddenField ID="hfEstrela" runat="server" />

                    <asp:Literal ID="litQuantidadEstrela" runat="server"></asp:Literal>

                    <h3>Descreva a sua experiência:</h3>
                    <asp:TextBox ID="txtAvaliacaoCliente" CssClass="txtAvaliacao" runat="server" TextMode="MultiLine" Rows="8"></asp:TextBox>

                    <spam class="erro">
                        <asp:Literal ID="litAviso" runat="server"></asp:Literal></spam>

                    <br />

                    <div class="fr">
                        <asp:Button ID="btnEnviar" CssClass="botoes" runat="server" Text="Enviar" OnClick="btnEnviar_Click" />
                        <asp:Button ID="btnCancelar" CssClass="botoes btn-cancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
                    </div>

                    <div class="cls"></div>
                </div>
            </div>
        </section>
    </form>
    <script type="text/javascript" src="js/menu_sanduiche.js"></script>
    <script src="<%=ResolveUrl("~/js/menu_sanduiche.js") %>" type="text/javascript"></script>
    <script src="<%=ResolveUrl("~/js/estrelaAvaliacao.js") %>" type="text/javascript"></script>
</body>
</html>
