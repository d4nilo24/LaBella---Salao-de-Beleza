using prjTCC.Lógica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using prjTCC.Classe;

namespace prjTCC
{
    public partial class cadastro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pnlFormCadastro.Visible = true;
                pnlFormCodigo.Visible = false;
            }
            /*
            else
            {
                /*bool formCadastro = ViewState["pnlFormCadastro"] != null ? (bool)ViewState["pnlFormCadastro"] : false;
                bool formCodigo = ViewState["pnlFormCodigo"] != null ? (bool)ViewState["pnlFormCodigo"] : true;

                pnlFormCadastro.Visible = false;
                pnlFormCodigo.Visible = true;
            }*/
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtNome.Text) && String.IsNullOrEmpty(txtEmail.Text) && String.IsNullOrEmpty(txtSenha.Text) && String.IsNullOrEmpty(txtConfirmarSenha.Text))
            {
                litAviso.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> Preencha todos os campos.</p></div>";
                return;
            }

            else if (String.IsNullOrEmpty(txtNome.Text))
            {
                litAviso.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> Preencha o nome.</p></div>";
                txtNome.Focus();
                return;
            }
            else if (txtNome.Text.Trim(' ').Length < 2)
            {
                litAviso.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> Nome precisa ao menos de dois caracteres.</p></div>";
                txtNome.Focus();
                return;
            }
            else if (txtNome.Text.Any(char.IsDigit))
            {
                litAviso.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> Nome não pode conter números.</p></div>";
                txtNome.Focus();
                return;
            }
            else if (String.IsNullOrEmpty(txtEmail.Text))
            {
                litAviso.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> Preencha o email.</p></div>";
                txtEmail.Focus();
                return;
            }

            else if (String.IsNullOrEmpty(txtSenha.Text))
            {
                litAviso.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> Preencha a senha.</p></div>";
                txtSenha.Focus();
                return;
            }

            else if (String.IsNullOrEmpty(txtConfirmarSenha.Text))
            {
                litAviso.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> Preencha o campo de confirmação de senha.</p></div>";
                txtConfirmarSenha.Focus();
                return;
            }

            else if (txtSenha.Text.Length < 6)
            {
                litAviso.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> A senha deve conter no mínimo 6 caracteres</p></div>";
                txtSenha.Text = "";
                txtCodigoVerificacao.Text = "";
                txtSenha.Focus();
                return;
            }

            CadastraCliente cadastroCliente = new CadastraCliente();

            if (txtSenha.Text != txtConfirmarSenha.Text)
            {
                litAviso.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> As senhas digitadas não coincidem.</p></div>";
                txtSenha.Text = "";
                txtConfirmarSenha.Text = "";
                txtSenha.Focus();
                return;
            }

            else if (cadastroCliente.enviarCodigoVerificacao(txtEmail.Text))
            {
                litAviso.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> Código enviado ao seu e-mail. Informe-o na caixa abaixo.</p></div>";
                Session["codigoEmail"] = cadastroCliente.pegarCodigo();
                txtCodigoVerificacao.Focus();
            }

            else
            {
                if (!cadastroCliente.enviarCodigoVerificacao(txtEmail.Text))
                {
                    litAviso.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> Email inválido. Por favor, informe um e-mail válido.</p></div>";
                    txtEmail.Text = "";
                    txtEmail.Focus();
                    return;
                }
            }

            if (IsPostBack)
            {
                if (Session["codigoEmail"] != null)
                {
                    pnlFormCadastro.Visible = false;
                    pnlFormCodigo.Visible = true;
                }
            }

            Session["nomeUsuario"] = txtNome.Text;
            Session["emailUsuario"] = txtEmail.Text;
            Session["senhaUsuario"] = txtSenha.Text;
        }

        protected void btnConcluir_Click(object sender, EventArgs e)
        {
            CadastraCliente cadastroCliente = new CadastraCliente();

            if (!string.IsNullOrEmpty(txtCodigoVerificacao.Text))
            {
                if (txtCodigoVerificacao.Text == Session["codigoEmail"].ToString())
                {
                    cadastroCliente.cadastrarCliente(Session["nomeUsuario"].ToString(), Session["emailUsuario"].ToString(), Session["senhaUsuario"].ToString());
                    litAviso2.Text = "Conta criada com sucesso.";
                    Response.Redirect("login.aspx");
                }

                else
                {
                    litAviso2.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> Código inválido. Verifique se digitou-o corretamente.</p></div>";
                    return;
                }
            }

            else
            {
                litAviso2.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> Digite o código enviado ao seu e-mail.</p></div>";
                return;
            }

            Session.Abandon();
        }
    }
}