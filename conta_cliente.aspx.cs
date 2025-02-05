using prjTCC.Lógica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjTCC
{
    public partial class conta_cliente : System.Web.UI.Page
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

            string nome = Session["nome"].ToString();
          
            litNomeBoasVindas.Text = nome.Split(' ')[0];

            if (!IsPostBack)
            {
                txtNomeCliente.Text = nome;
            }

            txtemial.Text = Session["login"].ToString();
        }

        protected void btnAlterar_Click(object sender, EventArgs e)
        {
            if (txtNomeCliente.Text.Trim(' ') == "" || String.IsNullOrEmpty(txtNomeCliente.Text) )
            {
                litAviso.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> O campo do nome não pode estar vazio.</p></div>";
                return;
            }
            else
            {
                string nome = txtNomeCliente.Text;
                if (nome == Session["nome"].ToString())
                {
                    litAviso.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> O nome não foi alterado.</p></div>";
                    return;
                }
                else if (nome.Trim(' ').Length < 2)
                {
                    litAviso.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> O nome no mínimo precisa de dois caracteres</p></div>";
                    return;
                }
                else if (nome.Any(char.IsDigit))
                {
                    litAviso.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> O nome não pode conter números.</p></div>";
                    return;
                }
                AlteracaoDosDadosDoCliente alteracao = new AlteracaoDosDadosDoCliente();
                if (alteracao.Alterar(nome, Session["login"].ToString()))
                {
                    Session["nome"] = nome;
                    litAviso.Text = "<div class='acerto'><p><i class=\"fa-solid fa-check\"></i> Nome alterado com sucesso</p></div>";
                    litNomeBoasVindas.Text = nome.Split(' ')[0];
                    //Response.Redirect(Request.RawUrl);
                }
                else
                {
                    litAviso.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> Não foi possível alterar os dados.</p></div>";
                    return;
                }
            }
        }
    }
}