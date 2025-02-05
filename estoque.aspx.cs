using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using prjTCC.Lógica;
using prjTCC.Classe;
using MySql.Data.MySqlClient;

namespace prjTCC
{
    public partial class estoques : System.Web.UI.Page
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

            ListasDona listadeProdutos = new ListasDona();

            using (MySqlDataReader dados = listadeProdutos.listarProdutos())
            {
                if (dados != null)
                {
                    grdEstoque.DataSource = dados;
                    grdEstoque.DataBind();
                }

                dados.Close();
                listadeProdutos.FecharConexao();
            }
        }

        protected void btnFiltrarProduto_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtFiltroproduto.Text))
            {
                FiltrosDona filtroDeProdutos = new FiltrosDona();

                using (MySqlDataReader dados = filtroDeProdutos.filtrarProdutos(txtFiltroproduto.Text))
                {
                    if (dados != null)
                    {
                        grdEstoque.DataSource = dados;
                        grdEstoque.DataBind();
                    }

                    dados.Close();
                    filtroDeProdutos.FecharConexao();
                }
            }

            else
            {
                //litviso.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> Campo obrigatório está vazio</p></div>";
                txtFiltroproduto.Focus();
            }
        }
    }
}