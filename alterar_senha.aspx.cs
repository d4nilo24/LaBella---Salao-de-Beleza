using prjTCC.Lógica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjTCC
{
    public partial class alterar_senha : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] == null)
            {
                Response.Redirect("login.aspx");
            }
            else if (Session["tipo"].ToString() != "3")
            {
                Response.Redirect("index.aspx");
            }
            else
            {
                litNomeBoasVindas.Text = Session["nome"].ToString().Split(' ')[0];
            }
        }
        protected void btnAlterarSenha_Click(object sender, EventArgs e)
        {
            if(txtSenhaAntiga.Text == "" || txtNovaSenha.Text == "" || txtConfirmacao.Text == "")
            {
               txtSenhaAntiga.Text = "";
               txtNovaSenha.Text = "";
               txtConfirmacao.Text = "";
               litAviso.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> As caixas não podem ficar vazias</p></div>";
            }
            else
            {
                // bater com a criação ocorrido na tela cadastro
                if(txtNovaSenha.Text == txtConfirmacao.Text)
                {
                    string senhaAnt = txtSenhaAntiga.Text;
                    string SenhaNova  = txtNovaSenha.Text;
                     
                    // AlteracaoDaSenha alterarsenha = new AlteracaoDaSenha();
                    AlteracaoDosDadosDoCliente alterarsenha = new AlteracaoDosDadosDoCliente();
                    string texto = alterarsenha.AlterarSenhaComVerificacao(senhaAnt, SenhaNova, Session["login"].ToString());

                    if (texto == "Alteração de senha incorreta")
                    {
                        litAviso.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> "+texto+"</p></div>"; 
                        // Response.Redirect(Request.RawUrl);
                    }
                    else
                    {
                        litAviso.Text = "<div class='acerto'><p><i class=\"fa-solid fa-check\"></i> "+texto+"</p></div>";
                    }
                }
                else
                {
                    litAviso.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> Por favor, confirme a sua senha corretamente</p></div>";
                    txtNovaSenha.Text = "";
                    txtConfirmacao.Text = "";
                    txtNovaSenha.Focus();
                }                
            }
        }
    }
}