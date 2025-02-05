using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using prjTCC.Classe;
using prjTCC.Lógica;
using MySql.Data.MySqlClient;
using System.Web.UI.HtmlControls;

namespace prjTCC
{
    public partial class dona_funcionario_adicionar_horario_servico : System.Web.UI.Page
    {
        string codigoFuncionario;
        static string codigoDiaTrabalho;
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

            if (Request.QueryString.Get("cdfuncionario") != null)
            {
                codigoFuncionario = Request.QueryString.Get("cdfuncionario");
            }

            if (!IsPostBack)
            {
                codigoDiaTrabalho = "1";
                btnDomingo.CssClass += " botaoAtivo";

                EdicaoDona listaDeServicos = new EdicaoDona();

                /*using (MySqlDataReader reader = listaDeServicos.listarServicosFuncionario(codigoFuncionario))
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
                }*/

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

                if (cmbServicos.Items.Count > 0)
                {
                    rpHorarios.DataSource = listaDeServicos.mostrarHorariosFuncionario(codigoDiaTrabalho, codigoFuncionario, cmbServicos.SelectedValue);
                    rpHorarios.DataBind();
                }
                else
                {
                    btnAbrirAdicionarHorario.Visible = false;
                }

                if (rpHorarios.Items.Count < 1)
                {
                    litAvisoHorario.Text = "<p><i class=\"fa-solid fa-triangle-exclamation\"></i> Não há horários para esse dia da semana e serviço.</p>";
                }
                else
                {
                    litAvisoHorario.Text = "";
                }
            }
        }
        public void MudarDiaDaSemana (object sender, CommandEventArgs e)
        {
            codigoDiaTrabalho = e.CommandArgument.ToString();
            btnDomingo.CssClass = "botao_filtro_horario";
            btnSegunda.CssClass = "botao_filtro_horario";
            btnTerca.CssClass = "botao_filtro_horario";
            btnQuarta.CssClass = "botao_filtro_horario";
            btnQuinta.CssClass = "botao_filtro_horario";
            btnSexta.CssClass = "botao_filtro_horario";
            btnSabado.CssClass = "botao_filtro_horario";
            Button diaBotao = (Button)sender;
            diaBotao.CssClass += " botaoAtivo";
            ListarHorario();
        }
        public void ListarHorarioBtn (object sender, EventArgs e)
        {
            ListarHorario();
        }
        public void ListarHorario()
        {
            EdicaoDona listaDeServicos = new EdicaoDona();
            if (cmbServicos.Items.Count > 0)
            {
                rpHorarios.DataSource = listaDeServicos.mostrarHorariosFuncionario(codigoDiaTrabalho, codigoFuncionario, cmbServicos.SelectedValue);
                rpHorarios.DataBind();
            }
            else
            {
                btnAbrirAdicionarHorario.Visible = false;
            }

            if (rpHorarios.Items.Count < 1)
            {
                litAvisoHorario.Text = "<p><i class=\"fa-solid fa-triangle-exclamation\"></i> Não há horários para esse dia da semana e serviço.</p>";

            }
            else
            {
                litAvisoHorario.Text = "";
            }
        }

        public void ExcluirHorario(object sender, CommandEventArgs e)
        {
            try
            {
                EdicaoDona listaDeServicos = new EdicaoDona();
                string hora = e.CommandArgument.ToString();
                listaDeServicos.excluirHorario(codigoFuncionario, cmbServicos.SelectedValue, hora, codigoDiaTrabalho);
                ListarHorario();
            }
            catch (Exception ex)
            {
                HttpContext.Current.Items["ErroTipo"] = "500 - Erro no servidor interno";
                HttpContext.Current.Items["ErroMensagem"] = ex.Message;
                Server.Transfer("~/erro.aspx");
            }
        }
    
        protected void AdicionarHorario(object sender, EventArgs e)
        {
            try
            {
                EdicaoDona adicionarHorario = new EdicaoDona();
                adicionarHorario.adicionarHorario(codigoFuncionario, cmbServicos.SelectedValue, txtDataHoraFuncionario.Text, codigoDiaTrabalho);
                txtDataHoraFuncionario.Text = null;
                pnlNovoHorario.Visible = false;
                ListarHorario();
            }
            catch (Exception ex)
            {
                litAvisoHorario.Text = ex.Message;
            }
        }

        protected void btAdicionarHorario_Click(object sender, EventArgs e)
        {
            pnlNovoHorario.Visible = true;
        }
        protected void CancelarAdicionarHorario(object sender, EventArgs e)
        {
            txtDataHoraFuncionario.Text = null;
            pnlNovoHorario.Visible = false;
        }
    }
}