using prjTCC.Lógica;
using prjTCC.Classe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjTCC
{
    public partial class servico_expandido : System.Web.UI.Page
    {
        string codigoServico;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] != null)
            {
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

            try
            {
                codigoServico = Request.QueryString.Get("servico");

                ServicoEspecifico servicoEspecifico = new ServicoEspecifico();
                Servico servico = servicoEspecifico.DadosServicoEspecifico(codigoServico);

                rpImagemServico.DataSource = servico.Imagem;
                rpImagemServico.DataBind();

                if (servico.Imagem.Count > 1)
                {
                    for (int i = 0; i < servico.Imagem.Count; i++)
                    {
                        Panel divRBImagemServico = new Panel();
                        if (i == 0)
                            divRBImagemServico.CssClass = "btnRadio btnPreenchido";
                        else
                            divRBImagemServico.CssClass = "btnRadio btnContorno";

                        divRBImagemServico.Attributes.Add("onclick", "currentDiv(" + i.ToString() + ")");

                        btnRadios.Controls.Add(divRBImagemServico);
                    }
                }

                litNomeServico.Text = servico.Nome;
                litDuracaoServico.Text = servico.Duracao;
                litPrecoServico.Text = servico.Valor.ToString();
                litDescricaoServico.Text = servico.Descricao;

                if (servico.QuantidadeAvaliacao < 1)
                {
                    litQuantidadeAvaliacoesServico.Text = "Sem avaliações";
                }
                else
                {
                    litQuantidadeAvaliacoesServico.Text = servico.QuantidadeAvaliacao.ToString();
                    if (servico.QuantidadeAvaliacao > 1)
                        litQuantidadeAvaliacoesServico.Text += " avaliações";
                    else
                        litQuantidadeAvaliacoesServico.Text += " avaliação";

                    litEstrelasMediaServico.Text = "";
                    for (int i = 0; i < servico.ValorAvaliacaoMedia; i++)
                    {
                        litEstrelasMediaServico.Text += "<i class='fa-solid fa-star'></i>";
                    }
                }

                if (Session["tipo"] != null)
                {
                    if (Session["tipo"].ToString() != "3")
                    {
                        btnAgendar.Enabled = false;
                        btnAgendar.Visible = false;
                    }
                }

                if (!IsPostBack)
                    ListarDepoimentosComFiltro("0");
            }
            catch (Exception ex)
            {
                HttpContext.Current.Items["ErroTipo"] = "500 - Erro no servidor interno";
                HttpContext.Current.Items["ErroMensagem"] = ex.Message;
                Server.Transfer("~/erro.aspx");
            }

            loading_spinner.Visible = false;
        }
        public void ListarDepoimentosComFiltro (string filtro)
        {
            if (!IsPostBack)
            {
                if (filtro == "0")
                {
                    btnFiltroTodos.CssClass += " botaoAtivo";
                }
           }

            try
            {
                ListaDepoimentoServico criarDepoimentos = new ListaDepoimentoServico();
                List<Depoimento> depoimentos = criarDepoimentos.ListarDepoimentos(codigoServico, filtro);

                litAvaliacao.Text = "";

                if (depoimentos.Count > 0)
                {
                    for (int i = 0; i < depoimentos.Count; i++)
                    {
                        string htmlDepoimento = $@"
                    <div class='avaliacoes-container'>
                      <div class='info-avaliador-container'>
                        <div class='avaliador-icone'>
                            <i class='fa-solid fa-circle-user'></i>
                        </div>

                        <div class='info-avaliador'>
                            <h2>{depoimentos[i].NomeCliente}</h2>
                            <div class='estrelas-avaliativas fs'> <p>";
                        for (int x = 0; x < depoimentos[i].Avaliacao; x++)
                        {
                            htmlDepoimento += "<i class='fa-solid fa-star'></i>";
                        }
                        htmlDepoimento += $@"      
                            </p></div>
                        </div>

                        <div class='info-funcionario'>
                            <p>profissional <strong>{depoimentos[i].Funcionario.Nome}</strong></p>
                            <p>{depoimentos[i].DataAvaliacao}</p>
                        </div>
                    </div>
                    <div class='avaliacao-container'>
                    <p>{depoimentos[i].Descricao}</p>
                    </div>
                    </div>";

                        if (i != depoimentos.Count - 1)
                        {
                            htmlDepoimento += "<hr/>";
                        }
                        litAvaliacao.Text += htmlDepoimento;
                    }
                }
                else if (filtro == "0")
                    litAvaliacao.Text = "Ainda não há avaliações para esse serviço.";
                else if (filtro == "1")
                    litAvaliacao.Text = "Não há avaliações positivas.";
                else if (filtro == "2")
                    litAvaliacao.Text = "Não há avaliações negativas.";
            }
            catch (Exception ex)
            {
                HttpContext.Current.Items["ErroTipo"] = "500 - Erro no servidor interno";
                HttpContext.Current.Items["ErroMensagem"] = ex.Message;
                Server.Transfer("~/erro.aspx");
            }
        }
        protected void BtnListarDepoimentosComFiltro(object sender, EventArgs e)
        {
            Button btnFiltro = (Button)sender;
            ListarDepoimentosComFiltro(btnFiltro.CommandArgument);
            btnFiltroTodos.CssClass = "filtros";
            btnFiltroNegativo.CssClass = "filtros";
            btnFiltroPositivo.CssClass = "filtros";
            btnFiltro.CssClass += " botaoAtivo";
        }
        protected void btnAgendar_Click(object sender, EventArgs e)
        {
            if (Session["login"] != null)
            {
                if (Session["tipo"].ToString() == "3")
                {
                    Response.Redirect("agendamento_servico.html?servico=" + codigoServico);
                }
                else
                {
                    Response.Redirect("index.aspx");
                }
            }
            else
            {
                Response.Redirect("login_cookie.html?url=" + HttpContext.Current.Request.Url.AbsoluteUri);
            }
        }
    }
}