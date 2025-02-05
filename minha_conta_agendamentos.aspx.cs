using prjTCC.Lógica;
using prjTCC.Classe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace prjTCC
{
    public partial class minha_conta_agendamentos : System.Web.UI.Page
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

            else
            {
                if (btnFiltroTodos.CssClass == "filtros-lista-contadivs botaoAtivo")
                {
                    btnFiltroTodos.CssClass = null;
                    btnFiltroTodos.CssClass = "filtros-lista-contadivs";
                }
                else
                {
                    btnFiltroTodos.CssClass = "filtros-lista-contadivs botaoAtivo";
                }

                btnFiltroCancelados.CssClass = "filtros-lista-contadivs";
                btnFiltroPendentes.CssClass = "filtros-lista-contadivs";
                btnFiltroConcluídos.CssClass = "filtros-lista-contadivs";

                litNomeBoasVindas.Text = Session["nome"].ToString().Split(' ')[0];

                listaAgendamentos listaAgendamentos = new listaAgendamentos();
                List<Agendamento> agendamentos = listaAgendamentos.listarAgendamentos(Session["login"].ToString(), "todos");

                rpAgendamento.DataSource = agendamentos;
                rpAgendamento.DataBind();

                if (agendamentos.Count < 1)
                {
                    imgErro.Visible = true;
                    imgErro.ImageUrl = "~/imagens/semAgendamento.png";
                }
                else
                {
                    imgErro.Visible = false;
                }
            }
        }

        protected void btnFiltroTodos_Click(object sender, EventArgs e)
        {
            if (btnFiltroTodos.CssClass == "filtros-lista-contadivs botaoAtivo")
            {
                btnFiltroTodos.CssClass = null;
                btnFiltroTodos.CssClass = "filtros-lista-contadivs botaoAtivo";
            }

            else
            {
                btnFiltroTodos.CssClass = "filtros-lista-contadivs botaoAtivo";
            }
          
            btnFiltroCancelados.CssClass = "filtros-lista-contadivs";
            btnFiltroPendentes.CssClass = "filtros-lista-contadivs";
            btnFiltroConcluídos.CssClass = "filtros-lista-contadivs";

            listaAgendamentos listaAgendamentos = new listaAgendamentos();
            List<Agendamento> agendamentos = listaAgendamentos.listarAgendamentos(Session["login"].ToString(), "todos");

            rpAgendamento.DataSource = agendamentos;
            rpAgendamento.DataBind();

            if (agendamentos.Count < 1)
            {
                imgErro.Visible = true;
                imgErro.ImageUrl = "~/imagens/semAgendamento.png";
            }
            else
            {
                imgErro.Visible = false;
            }
        }

        protected void btnFiltroPendentes_Click(object sender, EventArgs e)
        {
            if (btnFiltroPendentes.CssClass == "filtros-lista-contadivs botaoAtivo")
            {
                btnFiltroPendentes.CssClass = null;
                btnFiltroPendentes.CssClass = "filtros-lista-contadivs botaoAtivo";
            }

            else
            {
                btnFiltroPendentes.CssClass = "filtros-lista-contadivs botaoAtivo";
            }

            btnFiltroTodos.CssClass = "filtros-lista-contadivs";
            btnFiltroCancelados.CssClass = "filtros-lista-contadivs";
            btnFiltroConcluídos.CssClass = "filtros-lista-contadivs";

            listaAgendamentos listaAgendamentos = new listaAgendamentos();
            List<Agendamento> agendamentos = listaAgendamentos.listarAgendamentos(Session["login"].ToString(), "em andamento");

            rpAgendamento.DataSource = agendamentos;
            rpAgendamento.DataBind();

            if (agendamentos.Count < 1)
            {
                imgErro.Visible = true;
                imgErro.ImageUrl = "~/imagens/semAgendamentoEmAndamento.png";
            }
            else
            {
                imgErro.Visible = false;
            }
        }

        protected void btnFiltroCancelados_Click(object sender, EventArgs e)
        {
            if (btnFiltroCancelados.CssClass == "filtros-lista-contadivs botaoAtivo")
            {
                btnFiltroCancelados.CssClass = null;
                btnFiltroCancelados.CssClass = "filtros-lista-contadivs botaoAtivo";
            }

            else
            {
                btnFiltroCancelados.CssClass = "filtros-lista-contadivs botaoAtivo";
            }

            btnFiltroTodos.CssClass = "filtros-lista-contadivs";
            btnFiltroPendentes.CssClass = "filtros-lista-contadivs";
            btnFiltroConcluídos.CssClass = "filtros-lista-contadivs";

            listaAgendamentos listaAgendamentos = new listaAgendamentos();
            List<Agendamento> agendamentos = listaAgendamentos.listarAgendamentos(Session["login"].ToString(), "cancelados");

            rpAgendamento.DataSource = agendamentos;
            rpAgendamento.DataBind();

            if (agendamentos.Count < 1)
            {
                imgErro.Visible = true;
                imgErro.ImageUrl = "~/imagens/semAgendamentoCancelado.png";
            }
            else
            {
                imgErro.Visible = false;
            }
        }

        protected void btnFiltroConcluídos_Click(object sender, EventArgs e)
        {
            if (btnFiltroConcluídos.CssClass == "filtros-lista-contadivs botaoAtivo")
            {
                btnFiltroConcluídos.CssClass = null;
                btnFiltroConcluídos.CssClass = "filtros-lista-contadivs botaoAtivo";
            }

            else
            {
                btnFiltroConcluídos.CssClass = "filtros-lista-contadivs botaoAtivo";
            }

            btnFiltroTodos.CssClass = "filtros-lista-contadivs";
            btnFiltroPendentes.CssClass = "filtros-lista-contadivs";
            btnFiltroCancelados.CssClass = "filtros-lista-contadivs";

            listaAgendamentos listaAgendamentos = new listaAgendamentos();
            List<Agendamento> agendamentos = listaAgendamentos.listarAgendamentos(Session["login"].ToString(), "concluidos");

            rpAgendamento.DataSource = agendamentos;
            rpAgendamento.DataBind();

            if (agendamentos.Count < 1)
            {
                imgErro.Visible = true;
                imgErro.ImageUrl = "~/imagens/semAgendamentoConcluido.png";
            }
            else
            {
                imgErro.Visible = false;
            }
        }
    }
}