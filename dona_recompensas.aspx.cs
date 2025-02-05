using MySql.Data.MySqlClient;
using prjTCC.Lógica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjTCC
{
    public partial class dona_recompensas : System.Web.UI.Page
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

            else
            {
                hplinkResgatePremio.Text = "Resgatar Recompensas do cliente" + " " + "<i class=\"fa-solid fa-arrow-right\"></i>";
                hplinkResgatePremio.ForeColor = System.Drawing.ColorTranslator.FromHtml("#b36684");
                hplinkResgatePremio.NavigateUrl = "~/dona_resgate_recompensa.aspx";

                ListasDona listaDeRecompensas = new ListasDona();

                using (MySqlDataReader reader = listaDeRecompensas.listarRecompensas())
                {
                    if (reader != null)
                    {
                        grdRecompensas.DataSource = reader;
                        grdRecompensas.DataBind();
                    }
                    reader.Close();
                    listaDeRecompensas.FecharConexao();
                }
            }
        }

        protected void btnFiltraRecompensas_Click(object sender, EventArgs e)
        {
            FiltrosDona filtroDona = new FiltrosDona();

            if (!String.IsNullOrEmpty(txtFiltroServico.Text))
            {
                using (MySqlDataReader reader = filtroDona.filtrarRecompensas(txtFiltroServico.Text))
                {
                    if (reader != null)
                    {
                        grdRecompensas.DataSource = reader;
                        grdRecompensas.DataBind();
                    }

                    else
                    {
                        litAviso.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> Nenhum resultado encontrado</p></div>";
                        txtFiltroServico.Focus();
                        return;
                    }

                    reader.Close();
                    filtroDona.FecharConexao();
                }                
            }

            else
            {
                litAviso.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> Filtro está vazio</p></div>";
                txtFiltroServico.Focus();
                return;
            }
        }
    }
}