using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjTCC
{
    public partial class erro : System.Web.UI.Page
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
                if (HttpContext.Current.Items["ErroMensagem"] != null)
                {
                    string mensagemErro = HttpContext.Current.Items["ErroMensagem"].ToString();
                    litMensagemErro.Text = mensagemErro;
                }
                else
                {
                    litMensagemErro.Text = "Desculpe, esta página não foi encontrada. Tente novamente mais tarde.";
                }

                if (HttpContext.Current.Items["ErroTipo"] != null)
                {
                    string tipoErro = HttpContext.Current.Items["ErroTipo"].ToString();
                    litTipoErro.Text = tipoErro;
                }
                else
                {
                    litTipoErro.Text = "404 - Página não encontrada";
                }
            }
            catch (Exception ex)
            {
                HttpContext.Current.Items["ErroTipo"] = "500 - Erro no servidor interno";
                HttpContext.Current.Items["ErroMensagem"] = ex.Message;
                Server.Transfer("~/erro.aspx");
            }

            loading_spinner.Visible = false;
        }
    }
}