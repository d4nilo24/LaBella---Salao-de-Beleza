using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using prjTCC.Classe;
using prjTCC.Lógica;
using MySql.Data.MySqlClient;

namespace prjTCC
{
    public partial class funcionario_horario_servico : System.Web.UI.Page
    {
        string codigoFuncionario;
        static string codigoDiaTrabalho;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] == null)
            {
                Response.Redirect("login_cookie.html?url=" + HttpContext.Current.Request.Url.AbsoluteUri);
            }
            else if (Session["tipo"].ToString() != "1")
            {
                Response.Redirect("index.aspx");
            }

            if (!IsPostBack)
            {
                codigoDiaTrabalho = "1";


                EdicaoDona listaDeServicos = new EdicaoDona();

                using (MySqlDataReader reader = listaDeServicos.listarServicosFuncionario(codigoFuncionario))
                {
                    if (reader != null)
                    {
                        cmbServicosFuncionario.DataSource = reader;
                        cmbServicosFuncionario.DataTextField = "nm_servico";
                        cmbServicosFuncionario.DataValueField = "cd_servico";
                        cmbServicosFuncionario.DataBind();
                    }
                    reader.Close();
                    listaDeServicos.FecharConexao();
                }

                using (MySqlDataReader reader = listaDeServicos.listarServicosFuncionario(codigoFuncionario))
                {
                    if (reader != null)
                    {
                        cmbServicos.DataSource = reader;
                        cmbServicos.DataTextField = "nm_servico";
                        cmbServicos.DataValueField = "cd_servico";
                        cmbServicos.DataBind();
                    }
                    reader.Close();
                    listaDeServicos.FecharConexao();
                }

                rpHorarios.DataSource = listaDeServicos.mostrarHorariosFuncionario(codigoDiaTrabalho, codigoFuncionario, cmbServicos.SelectedValue);
                rpHorarios.DataBind();

                if (rpHorarios.Items.Count < 1)
                {
                    litAvisoHorario.Text = "<p>Não há horários para esse dia da semana e serviço.</p>";
                }
                else
                {
                    litAvisoHorario.Text = "";
                }
            }
        }
        public void MudarDiaDaSemana(object sender, CommandEventArgs e)
        {
            codigoDiaTrabalho = e.CommandArgument.ToString();
        }
        public void ListarHorarioBtn(object sender, EventArgs e)
        {
            ListarHorario();
        }
        public void ListarHorario()
        {
            EdicaoDona listaDeServicos = new EdicaoDona();
            rpHorarios.DataSource = listaDeServicos.mostrarHorariosFuncionario(codigoDiaTrabalho, codigoFuncionario, cmbServicos.SelectedValue);
            rpHorarios.DataBind();

            if (rpHorarios.Items.Count < 1)
            {
                litAvisoHorario.Text = "<p>Não há horários para esse dia da semana e serviço.</p>";
            }
            else
            {
                litAvisoHorario.Text = "";
            }
        }

        public void ExcluirHorario(object sender, CommandEventArgs e)
        {
            EdicaoDona listaDeServicos = new EdicaoDona();
            string hora = e.CommandArgument.ToString();
            listaDeServicos.exluirHorario(codigoFuncionario, cmbServicosFuncionario.SelectedValue, hora, codigoDiaTrabalho);
            ListarHorario();
        }

    }
}