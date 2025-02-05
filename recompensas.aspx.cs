using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using prjTCC.Lógica;
using prjTCC.Classe;

namespace prjTCC
{
    public partial class recompensas : System.Web.UI.Page
    {
        string tipoPremio = "";
        string emailCliente = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] != null)
            {
                emailCliente = Session["login"].ToString();
                if (Session["tipo"].ToString() == "3")
                {
                    litIconeUsuario.Text = "<i class='fa-solid fa-circle-user'></i>";
                    hpLogin.NavigateUrl = "~/minha_conta_agendamentos.aspx";
                    hpLoginResponsivo.NavigateUrl = "~/minha_conta_agendamentos.aspx";
                    litLoginResponsivo.Text = "Minha conta";
                }
                else if (Session["tipo"].ToString() == "2")
                {
                    litIconeUsuario.Text = "<i class='fa-solid fa-toolbox'></i> <p>Administrar</p>";
                    hpLogin.NavigateUrl = "~/dona_agenda.aspx";
                    hpLoginResponsivo.NavigateUrl = "~/dona_agenda.aspx";
                    litLoginResponsivo.Text = "Administrar";
                }
                else if (Session["tipo"].ToString() == "1")
                {
                    litIconeUsuario.Text = "<i class='fa-regular fa-calendar-days'></i><p>Agenda</p>";
                    hpLogin.NavigateUrl = "~/funcionario_agenda.aspx";
                    hpLoginResponsivo.NavigateUrl = "~/funcionario_agenda.aspx";
                    litLoginResponsivo.Text = "Abrir Agenda";
                }
            }
            else
            {
                litIconeUsuario.Text = "<i class='fa-solid fa-right-to-bracket'></i>";
                hpLogin.NavigateUrl = "login_cookie.html?url=" + Request.Url.PathAndQuery;
                hpLoginResponsivo.NavigateUrl = "login_cookie.html?url=" + Request.Url.PathAndQuery;
                litLoginResponsivo.Text = "Fazer login";
            }

            if (Request.QueryString.Get("tipo") != null)
            {
                tipoPremio = Request.QueryString.Get("tipo");
            }

            ListaTipoPremio listaTipoPremio = new ListaTipoPremio();
            rpFiltros.DataSource = listaTipoPremio.ListarTipoPremio(true);
            rpFiltros.DataBind();

            ListaPremio listaPremio = new ListaPremio();
            List<Premio> premios = listaPremio.ListarProdutos(tipoPremio, emailCliente);


            if (Session["tipo"] == null || Session["tipo"].ToString() != "1" && Session["tipo"].ToString() != "2")
            {
                PegarPontuacaoCliente pontuacaoCliente = new PegarPontuacaoCliente();
                litPontos.Text = "Você possui " + pontuacaoCliente.PontuacaoCliente(emailCliente) + " pontos";
            
                if (emailCliente == null)
                {
                    litPontos.Text += " (sem login)";
                }
            }

            if (premios.Count > 0)
            {
                imgErro.Visible = false;
                foreach (Premio premio in premios)
                {
                    string htmlPremio = $@"
                                        <div class='recompensa-container-informacoes-textos'>
                                        <h2 class='recompensa-container-informacoes-textos-titulo'>{premio.Nome}</h2>
                                        <h3>{premio.Pontos} pontos</h3>
                                        <p>{premio.Descricao}</p>

                                        </div>";
                    Panel panelRecompensa = new Panel();
                    panelRecompensa.CssClass = "recompensa-container";
                    Panel panelImagem = new Panel();
                    panelImagem.CssClass = "recompensa-imagem";
                    Image imagem = new Image();
                    imagem.AlternateText = "Imagem da recompensa";
                    imagem.ImageUrl = "imagens/" + premio.Imagem.Pasta + "/" + premio.Imagem.Nome;
                    Panel panelInformacoes = new Panel();
                    panelInformacoes.CssClass = "recompensa-container-informacoes";
                    Literal litInformacoes = new Literal();
                    litInformacoes.Text = htmlPremio;
                    Button btnResgatar = new Button();

                    if (Session["tipo"] == null || Session["tipo"].ToString() != "1" && Session["tipo"].ToString() != "2")
                    {
                        btnResgatar.CssClass = "botoes";
                        btnResgatar.Enabled = premio.Resgatavel;
                        btnResgatar.CommandArgument = premio.Codigo.ToString();
                        btnResgatar.Command += MudarPaginaRecompensaResgatar;
                        btnResgatar.Text = premio.CondicaoPremio;
                    }

                    panelImagem.Controls.Add(imagem);
                    panelRecompensa.Controls.Add(panelImagem);
                    panelInformacoes.Controls.Add(litInformacoes);
                    if (Session["tipo"] == null || Session["tipo"].ToString() != "1" && Session["tipo"].ToString() != "2")
                    {
                        panelInformacoes.Controls.Add(btnResgatar);
                    }
                    panelRecompensa.Controls.Add(panelImagem);
                    panelRecompensa.Controls.Add(panelInformacoes);

                    pnlRecompensa.Controls.Add(panelRecompensa);
                }
            }
            else
            {
                imgErro.ImageUrl = "~/imagens/semPremio.png";
            }
        }
        protected void MudarPaginaRecompensaResgatar(object sender, CommandEventArgs e)
        {
            Response.Redirect("recompensa_resgatar.aspx?premio=" + e.CommandArgument.ToString());
        }
    }
}