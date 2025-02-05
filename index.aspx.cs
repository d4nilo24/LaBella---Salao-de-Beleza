using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using prjTCC.Lógica;
using prjTCC.Classe;
using System.Web.UI.HtmlControls;
using System.Windows;

namespace prjTCC
{
    public partial class index : System.Web.UI.Page
    {
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
                

                ListaCategoria criarCategorias = new ListaCategoria();
                rpTipoServicosContainers.DataSource = criarCategorias.ListarCategorias(false);
                rpTipoServicosContainers.DataBind();

                ListaDepoimentoPopular criarDepoimentos = new ListaDepoimentoPopular();
                List<Depoimento> depoimentos = criarDepoimentos.ListarPrincipaisDepoimentos();

                if (depoimentos.Count > 0)
                {
                    string depoimentosHtml = @"
                    <section class='section-depoimentos'>
                        <div class='section-content-largura'>
                            <h1 class='centralizado'>Depoimentos</h1>
                            <p>Veja o que nossos clientes dizem</p>
                            <div class='depoimentos'>";

                    foreach (Depoimento depoimento in depoimentos)
                    {
                        depoimentosHtml += $@"
                        <div class='depoimento-container'>
                            <div>
                                <i class='fa-solid fa-quote-left aspas icone'></i>
                                <h3>{depoimento.NomeCliente}</h3>
                                <div class='estrelas-avaliativas'>";
                        for (int x = 0; x < depoimento.Avaliacao; x++)
                        {
                            depoimentosHtml += "<i class='fa-solid fa-star icone'></i>";
                        }

                        depoimentosHtml += $@" 
                            </div>
                        </div>
                        <div>
                            <p>{ depoimento.Descricao}</p>
                        </div>
                    </div>";
                    }
                    depoimentosHtml += "</div> </div> </section>";
                    litDepoimentos.Text += depoimentosHtml;
                }
            }
            catch (Exception ex)
            {
                HttpContext.Current.Items["ErroTipo"] = "500 - Erro no servidor interno";
                HttpContext.Current.Items["ErroMensagem"] = ex.Message + "\nTente novamente recarregar a página inicial clicando nesse botão:";
                Server.Transfer("~/erro.aspx");
            }
        }
    }
}