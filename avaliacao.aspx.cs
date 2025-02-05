using prjTCC.Lógica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace prjTCC
{
    public partial class avaliacao : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 5; i++)
            {
                HtmlGenericControl estrela = new HtmlGenericControl("i");
                estrela.Attributes["class"] = "fa-solid fa-star";
                estrela.Attributes.Add("onclick", $"mudarEstrela({i})");
                pnlEstrelasAvaliativas.Controls.Add(estrela);
            }
        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {
                AvaliacaoServico avaliacaoServico = new AvaliacaoServico();

                if (String.IsNullOrEmpty(txtAvaliacaoCliente.Text))
                {
                    litAviso.Text = "Preencha o campo obrigatório.";
                }

                else
                {
                    avaliacaoServico.avaliarServico(Request["cdAgendamento"].ToString(), Session["login"].ToString(), hfEstrela.Value.ToString(), txtAvaliacaoCliente.Text);
                    litAviso.Text = "Avaliação Adicionada com sucesso!";
                    Response.Redirect("minha_conta_agendamentos.aspx");
                }
            }
            catch (Exception ex)
            {
                HttpContext.Current.Items["ErroTipo"] = "500 - Erro no servidor interno";
                HttpContext.Current.Items["ErroMensagem"] = ex.Message;
                Server.Transfer("~/erro.aspx");
            }
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("minha_conta_agendmentos.aspx");
        }
    }
}