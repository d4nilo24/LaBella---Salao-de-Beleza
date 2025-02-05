using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using prjTCC.Lógica;

namespace prjTCC
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] != null)
            {
                litIconeUsuario.Text = "<i class='fa-solid fa-circle-user'></i>";
                hpLogin.NavigateUrl = "~/minha_conta_agendamentos.aspx";
                hpLoginResponsivo.NavigateUrl = "~/minha_conta_agendamentos.aspx";
                litLoginResponsivo.Text = "Minha conta";
                Response.Redirect("~/index.aspx");
            }
            else
            {
                litIconeUsuario.Text = "<i class='fa-solid fa-right-to-bracket'></i>";
                hpLogin.NavigateUrl = "login_cookie.html?url=" + Request.Url.PathAndQuery;
                hpLoginResponsivo.NavigateUrl = "login_cookie.html?url=" + Request.Url.PathAndQuery;
                litLoginResponsivo.Text = "Fazer login";
            }
            loading_spinner.Visible = false;
        }
        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            loading_spinner.Visible = true;
            if (txtEmailLogin.Text == "")
            {
                litAviso.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> Login não foi preenchido</p></div>";
                loading_spinner.Visible = false;
                return;
            }
            else if (txtSenhaLogin.Text == "")
            {
                litAviso.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> Senha não foi preenchida</p></div>";
                loading_spinner.Visible = false;
                return;
            }

            try
            { 
                FazerLogin login = new FazerLogin();
                string[] loginInfo = login.Logar(txtEmailLogin.Text, txtSenhaLogin.Text);

                if (loginInfo[0] == "Usuário não encontrado")
                {


                    litAviso.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> Login e/ou senha inválido(s)</p></div>";
                    txtSenhaLogin.Text = "";
                    loading_spinner.Visible = false;
                    return;
                }
                else
                {
                    Session["login"] = loginInfo[0];
                    Session["nome"] = loginInfo[1];
                    Session["tipo"] = loginInfo[2];

                    /*if (loginInfo[1].Replace(" ","") != loginInfo[1])
                    {
                        int posicaoDoNome = Session["nome"].ToString().IndexOf(' ');
                        Session["nome"] = Session["nome"].ToString().Substring(0, posicaoDoNome);
                    }*/

                    if (Session["tipo"].ToString() == "2")
                    {
                        Response.Redirect("dona_agenda.aspx");
                    }
                    else if (Session["tipo"].ToString() == "1")
                    {
                        Response.Redirect("funcionario_agenda.aspx");
                    }
                    if (Request.Cookies["ultimaUrl"] != null)
                    {
                        string ultimaUrl = Request.Cookies["ultimaUrl"].Value;
                        Response.Redirect(ultimaUrl);
                    }
                    else
                    {
                        Response.Redirect("~/index.aspx");
                    }
                }
            }
            catch (Exception ex)
            {
                HttpContext.Current.Items["ErroTipo"] = "500 - Erro no servidor interno";
                HttpContext.Current.Items["ErroMensagem"] = ex.Message;
                Server.Transfer("~/erro.aspx");
            }
        }
    }
}