using MySql.Data.MySqlClient;
using prjTCC.Classe;
using prjTCC.Lógica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjTCC
{
    public partial class resgate_recompensa : System.Web.UI.Page
    {
        Premio premio = new Premio();
        static string codigoRetirar = null;
        static string emailClientePremio = null;
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
                hplinkVoltarRecompensas.Text = "<i class=\"fa-solid fa-arrow-left\"></i>" + " " + "Voltar para recompensas";
                hplinkVoltarRecompensas.ForeColor = System.Drawing.ColorTranslator.FromHtml("#b36684");
                hplinkVoltarRecompensas.NavigateUrl = "~/dona_recompensas.aspx";

                ResgateRecompensa listadeRecompensasCliente = new ResgateRecompensa();

                if(!IsPostBack)
                {
                    using (MySqlDataReader reader = listadeRecompensasCliente.listarPremiosAResgatar())
                    {
                        if (reader != null)
                        {
                            grdPremiosClientes.DataSource = reader;
                            grdPremiosClientes.DataBind();
                        }
                        reader.Close();
                        listadeRecompensasCliente.FecharConexao();
                    }
                }
            }
        }

        protected void btnFiltraRecompensas_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtFiltroPremios.Text))
            {
                litAviso.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> Campo vazio</p></div>";
                txtFiltroPremios.Focus();
                return;
            }

            else
            {
                ResgateRecompensa listadeRecompensasCliente = new ResgateRecompensa();

                using (MySqlDataReader reader = listadeRecompensasCliente.filtrarPremiosCliente(txtFiltroPremios.Text))
                {
                    if (reader != null)
                    {
                        grdPremiosClientes.DataSource = reader;
                        grdPremiosClientes.DataBind();
                    }
                    reader.Close();
                    listadeRecompensasCliente.FecharConexao();
                }
            }
        }

        protected void grdPremiosClientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Retirar")
            {
                string argument = e.CommandArgument.ToString();
                string[] parametros = argument.Split(',');

                if (parametros.Length >= 2)
                {
                    string codigoPremio = parametros[0];
                    string emailCliente = parametros[1];

                    codigoRetirar = codigoPremio;
                    emailClientePremio = emailCliente;
                   
                    pnlConfirmarExclusao.Visible = true;
                }

            }
        }

        protected void btnNao_Click(object sender, EventArgs e)
        {
            pnlConfirmarExclusao.Visible = false;
        }

        protected void btnSim_Click(object sender, EventArgs e)
        {
            ResgateRecompensa resgateRecompesa = new ResgateRecompensa();
            resgateRecompesa.registrarResgateRecompensa(codigoRetirar, emailClientePremio);

            ResgateRecompensa listadeRecompensasCliente = new ResgateRecompensa();

            using (MySqlDataReader reader = listadeRecompensasCliente.listarPremiosAResgatar())
            {
                if (reader != null)
                {
                    grdPremiosClientes.DataSource = reader;
                    grdPremiosClientes.DataBind();
                }
                reader.Close();
                listadeRecompensasCliente.FecharConexao();
            }
            
            pnlConfirmarExclusao.Visible = false;
            codigoRetirar = null;
            emailClientePremio = null;
        }
    }
}