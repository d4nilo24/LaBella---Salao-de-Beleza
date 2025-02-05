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
    public partial class dona_funcionario : System.Web.UI.Page
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

           else if (Session["login"].ToString() != null && Session["tipo"].ToString() == "cliente" || Session["tipo"].ToString() == "funcionario")
           {
               Response.Redirect("index.aspx");
           }

           else
           {
           }
           */

            ListasDona listadeFuncionarios = new ListasDona();

            using (MySqlDataReader dados = listadeFuncionarios.listarFuncionarios())
            {
                if (dados != null)
                {
                    grdFuncionarios.DataSource = dados;
                    grdFuncionarios.DataBind();
                }

                dados.Close();
                listadeFuncionarios.FecharConexao();
            }    
        }

        protected void btnFiltrarFuncionario_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtFiltroFuncionario.Text))
            {
                FiltrosDona filtroDeFuncionarios = new FiltrosDona();

                using (MySqlDataReader dados = filtroDeFuncionarios.filtrarFuncionarios(txtFiltroFuncionario.Text)) 
                {
                    if (dados != null)
                    {
                        grdFuncionarios.DataSource = dados;
                        grdFuncionarios.DataBind();
                    }

                    dados.Close();
                    filtroDeFuncionarios.FecharConexao();
                }
            }

            else
            {
                //litviso.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> Campo obrigatório está vazio</p></div>";
                txtFiltroFuncionario.Focus();
            }
        }
    }
}