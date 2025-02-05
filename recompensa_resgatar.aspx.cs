using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using prjTCC.Classe;
using prjTCC.Lógica;

namespace prjTCC
{
    public partial class recompensa_resgatar : System.Web.UI.Page
    {
        string codigoPremio = "";
        string emailCliente = null;
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
                    emailCliente = Session["login"].ToString();
                }
                else if (Session["tipo"].ToString() == "2")
                {
                    Response.Redirect("index.aspx");
                }
                else if (Session["tipo"].ToString() == "1")
                {
                    Response.Redirect("index.aspx");
                }
            }
            else
            {
                litIconeUsuario.Text = "<i class='fa-solid fa-right-to-bracket'></i>";
                hpLogin.NavigateUrl = "login_cookie.html?url=" + Request.Url.PathAndQuery;
                hpLoginResponsivo.NavigateUrl = "login_cookie.html?url=" + Request.Url.PathAndQuery;
                litLoginResponsivo.Text = "Fazer login";
            }

            if (!String.IsNullOrEmpty(Request.QueryString.Get("premio")))
            {
                codigoPremio = Request.QueryString.Get("premio");
            }

            try
            {
                DadosMinimosPremioEspecifico dadosMinimosPremio = new DadosMinimosPremioEspecifico();
                Premio premio = dadosMinimosPremio.DadosMinimosPremio(codigoPremio);

                PegarPontuacaoCliente pontuacaoCliente = new PegarPontuacaoCliente();
                int pontosCliente = pontuacaoCliente.PontuacaoCliente(emailCliente);
                litPontos.Text = "Você possui " + pontosCliente + " pontos";

                if (premio.Pontos > pontosCliente)
                {
                    HttpContext.Current.Items["ErroTipo"] = "403 - Acesso negado";
                    HttpContext.Current.Items["ErroMensagem"] = "Você possui quantidade de pontos insuficiente para esse resgatar prêmio.";
                    Server.Transfer("~/erro.aspx");
                }

                litImagemPremio.Text = $"<img src='imagens/{premio.Imagem.Pasta}/{premio.Imagem.Nome}' alt='Imagem do serviço selecionado pelo cliente'/>";
                litTituloPremio.Text = premio.Nome;
                litTipoPremio.Text = premio.TipoPremio.Nome;
                litPontosPremio.Text = premio.Pontos.ToString();
                litDescricaoPremio.Text = premio.Descricao;
                if (premio.Servico != null)
                {
                    if (!String.IsNullOrEmpty(premio.Servico.Nome))
                    {
                        litServicoAtrelado.Text = "<p>Aplicável ao serviço: <h3>" + premio.Servico.Nome.ToString() + "</h3></p>";
                    }
                }
                if (premio.Categoria != null)
                {
                    if (!String.IsNullOrEmpty(premio.Categoria.Nome))
                    {
                        litCategoriaAtrelada.Text = "<p>Aplicável à categoria de serviço: <h3>" + premio.Categoria.Nome.ToString() + "</h3></p>";
                    }
                }
                
                //litDataFimPremio.Text = premio.DataFinalTemporada;
            }
            catch (Exception ex)
            {
                HttpContext.Current.Items["ErroTipo"] = "500 - Erro no servidor interno";
                HttpContext.Current.Items["ErroMensagem"] = ex.Message;
                Server.Transfer("~/erro.aspx");
            }
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                ResgatarPremio resgatarPremio = new ResgatarPremio();
                resgatarPremio.ResgatarRecompensa(codigoPremio, emailCliente);
                Response.Redirect("minha_conta_recompensas.aspx");
            }
            catch (Exception ex)
            {
                litErro.Text = ex.Message;
            }
        }
    }
}