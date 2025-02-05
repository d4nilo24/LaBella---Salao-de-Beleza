using prjTCC.Lógica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace prjTCC
{
    public partial class dona_servicos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] == null)
            {
                Response.Redirect("login_cookie.html?url=" + HttpContext.Current.Request.Url.AbsoluteUri);
            }
            else if (Session["tipo"].ToString() != "2")
            {
                Response.Redirect("index.aspx");
            }
            /*if (Session["login"].ToString() == null)
            {
                Response.Redirect("login.aspx");
            }

            else if (Session["login"].ToString() != null &&  Session["tipo"].ToString() == "3" || Session["tipo"].ToString() == "1")
            {
                Response.Redirect("index.aspx");
            }

            else
            {
                listaDona listaDeServicos = new listaDona();

                grdServicos.DataSource = listaDeServicos.listarServicos();
                grdServicos.DataBind();
            }*/

            ListasDona listaDeServicos = new ListasDona();

            using (MySqlDataReader dados = listaDeServicos.listarServicos())
            {
                if (dados != null)
                {
                    grdServicos.DataSource = dados;
                    grdServicos.DataBind();
                }

                dados.Close();
                listaDeServicos.FecharConexao();
            }
        }

        protected void btnFiltraServicos_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtFiltroServico.Text))
            {
                FiltrosDona filtroDeServicos = new FiltrosDona();

                using (MySqlDataReader dados = filtroDeServicos.filtrarServicosDona(txtFiltroServico.Text))
                {
                    if (dados != null)
                    {
                        grdServicos.DataSource = dados;
                        grdServicos.DataBind();
                    }

                    dados.Close();
                    filtroDeServicos.FecharConexao();
                }
                txtFiltroServico.Text = "";
            }

            else
            {
                litAviso.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> Campo obrigatório está vazio.</p></div>";
                txtFiltroServico.Focus();
            }
        }
    }
}