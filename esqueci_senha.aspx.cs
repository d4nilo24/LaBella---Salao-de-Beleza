using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using prjTCC.Lógica;

namespace prjTCC
{
    public partial class esqueci_senha : System.Web.UI.Page
    {
        private string token = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Get("token") != null)
            {
                token = Request.QueryString.Get("token").ToString();

                VerificarExistenciaToken verificarToken = new VerificarExistenciaToken();
                if(!verificarToken.VerificarExistencia(token))
                {
                    HttpContext.Current.Items["ErroTipo"] = "404 - Página não encontrada";
                    HttpContext.Current.Items["ErroMensagem"] = "O token é inválido.";
                    Server.Transfer("~/erro.aspx");
                    return;
                }

                pnlFormEsqueciSenha.Visible = false;
                pnlAviso.Visible = false;
                pnlAlterarSenha.Visible = true;                

            }
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            EnviarCodigoVerificao enviarCodigo = new EnviarCodigoVerificao();
            SalvarToken salvarToken = new SalvarToken();
            VerificarContaExistente verificarConta = new VerificarContaExistente();
           
            if (!String.IsNullOrEmpty(txtEmail.Text.Trim(' ')))
            {
                try
                {
                    if (verificarConta.VerificarExistencia(txtEmail.Text).Existencia)
                    {
                        enviarCodigo.EnviaCodigo(txtEmail.Text, HttpContext.Current.Request.Url.AbsoluteUri);
                        salvarToken.Salvar(enviarCodigo.PegarCodigo(), txtEmail.Text);
                        pnlFormEsqueciSenha.Visible = false;
                        pnlAviso.Visible = true;
                        pnlAlterarSenha.Visible = false;
                    }
                    else
                    {
                        litAviso.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> Esse e-mail não foi cadastrado, verifique o que foi digitado.</p></div>";
                    }
                }
                catch (Exception ex)
                {
                    litAviso.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> "+ex.Message + "</p></div>";
                }
            }
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtSenha.Text.Trim(' ')))
            {
                litAviso.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> Preencha a senha.</p></div>";
                txtSenha.Focus();
                return;
            }
            else if (txtSenha.Text.Length < 6)
            {
                litAviso.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> A senha deve conter no mínimo 6 caracteres</p></div>";
                txtSenha.Text = "";
                txtSenha.Focus();
                return;
            }
            else if (String.IsNullOrEmpty(txtConfirmarSenha.Text.Trim(' ')))
            {
                litAviso.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> Preencha o campo de confirmação de senha.</p></div>";
                txtConfirmarSenha.Focus();
                return;
            }
            else if (txtSenha.Text != txtConfirmarSenha.Text)
            {
                litAviso.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> As senhas digitadas não coincidem.</p></div>";
                txtSenha.Text = "";
                txtConfirmarSenha.Text = "";
                txtSenha.Focus();
                return;
            }
            else
            {
                AlteracaoDosDadosDoCliente alterarSenha = new AlteracaoDosDadosDoCliente();
                alterarSenha.AlterarSenha(token, txtSenha.Text);
                Response.Redirect("login.aspx");
            }
        }
    }
}
