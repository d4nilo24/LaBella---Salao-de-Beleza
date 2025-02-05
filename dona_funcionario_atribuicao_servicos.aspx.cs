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
    public partial class dona_funcionario_atribuicao_servicos : System.Web.UI.Page
    {
        Funcionario funcionario = new Funcionario();
        string funcionarioQuery = null;
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
                funcionarioQuery = Request.QueryString.Get("cdfuncionario");
            }
            else
            {
                HttpContext.Current.Items["ErroTipo"] = "404 - Página não encontrada";
                HttpContext.Current.Items["ErroMensagem"] = "Não foi escolhido o funcionário.";
                Server.Transfer("~/erro.aspx");
            }

            EdicaoDona dadosFuncionario = new EdicaoDona();
            funcionario = dadosFuncionario.mostrarDadosFuncionario(funcionarioQuery);

            hpEditarHorario.NavigateUrl = "dona_funcionario_adicionar_horario_servico.aspx?cdfuncionario=" + funcionario.Codigo;
            hpEditarHorario.Text = "Atribuir horário(s) para " + funcionario.Nome.ToString().Split(' ')[0];
            hpEditarHorario.ForeColor = System.Drawing.ColorTranslator.FromHtml("#b36684");

            if (!IsPostBack)
            {
                ListarServicosFuncionario();
            }

            AtualizarLabelGridview();

            if (!IsPostBack)
            {
                PreencherComboBoxServicosDisponiveis();
            }

            if (Request["cdfuncionario"] != null && Request["cdservico"] != null)
            {
                
            }
        }

        protected void btnAtribuir_Click(object sender, EventArgs e)
        {
            AtribuicaoServicoFuncionario atribuicaoServicoFuncionario = new AtribuicaoServicoFuncionario();
            atribuicaoServicoFuncionario.atribuirServicoFuncionario(funcionarioQuery, cmbServicos.SelectedValue);
            litAviso.Text = "<div class='acerto'><p><i class=\"fa-solid fa-check\"></i> Dado(s) alterado(s) com sucesso</p></div>";

            using (MySqlDataReader dados = atribuicaoServicoFuncionario.listarServicosAtribuidos(funcionarioQuery))
            {
                if (dados != null)
                {
                    grdServicosRealizadosPeloFuncionario.DataSource = dados;
                    grdServicosRealizadosPeloFuncionario.DataBind();
                }
                dados.Close();
                atribuicaoServicoFuncionario.FecharConexao();
            }

            AtualizarLabelGridview();
            PreencherComboBoxServicosDisponiveis();
            ListarServicosFuncionario();
        }

        private void PreencherComboBoxServicosDisponiveis()
        {
            AtribuicaoServicoFuncionario servicosNaoAtribuidos = new AtribuicaoServicoFuncionario();

            using (MySqlDataReader dados = servicosNaoAtribuidos.listarServicosDisponiveis(funcionarioQuery))
            {
                if (dados != null)
                {
                    cmbServicos.DataSource = dados;
                    cmbServicos.DataTextField = "nm_servico";
                    cmbServicos.DataValueField = "cd_servico";
                    cmbServicos.DataBind();
                }
                dados.Close();
                servicosNaoAtribuidos.FecharConexao();
            }
        }

        private void AtualizarLabelGridview()
        {
            if (grdServicosRealizadosPeloFuncionario.Rows.Count <= 0)
            {
                lblServico.Text = "Nenhum serviço atribuído";
            }
            else
            {
                lblServico.Text = "Serviços realizados por " + funcionario.Nome.Split(' ')[0] + ":";
            }
        }
        protected void grdServicosRealizadosPeloFuncionario_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Excluir")
            {
                AtribuicaoServicoFuncionario desatribuicaoServicoFuncionario = new AtribuicaoServicoFuncionario();

                desatribuicaoServicoFuncionario.desatribuirServicoFuncionario(funcionarioQuery, e.CommandArgument.ToString());

                AtualizarLabelGridview();
                PreencherComboBoxServicosDisponiveis();
                ListarServicosFuncionario();
            }
        }

        void ListarServicosFuncionario ()
        {
            AtribuicaoServicoFuncionario atribuicaoServicoFuncionario = new AtribuicaoServicoFuncionario();

            using (MySqlDataReader dados = atribuicaoServicoFuncionario.listarServicosAtribuidos(funcionarioQuery))
            {
                if (dados != null)
                {
                    grdServicosRealizadosPeloFuncionario.DataSource = dados;
                    grdServicosRealizadosPeloFuncionario.DataBind();
                }

                dados.Close();
                atribuicaoServicoFuncionario.FecharConexao();
            }
        }
    }
}