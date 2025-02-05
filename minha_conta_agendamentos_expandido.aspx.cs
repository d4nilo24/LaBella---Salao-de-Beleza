using prjTCC.Classe;
using prjTCC.Lógica;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjTCC
{
    public partial class minha_conta_agendamentos_expandido : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] == null && Session["login"] != null)
            {
                Response.Redirect("minha_conta_agendamento.aspx");
            }
            else if (Session["tipo"].ToString() != "3")
            {
                Response.Redirect("index.aspx");
            }

            else
            {
                litNomeBoasVindas.Text = Session["nome"].ToString().Split(' ')[0];

                listaAgendamentos listaDetalhesAgendamento = new listaAgendamentos();
                Agendamento agendamento = listaDetalhesAgendamento.listarDetalhesAgendamento(Session["login"].ToString(), Request["agendamento"].ToString());


                    imgServico.ImageUrl = "imagens/" + agendamento.Servico.Imagem[0].Pasta + "/" + agendamento.Servico.Imagem[0].Nome;
                    litNomeServico.Text = agendamento.Servico.Nome.ToString();
                    litDataServico.Text = agendamento.Data.ToString();
                    litHoraServico.Text = agendamento.FuncionarioServicoDiaDeTrabalho.Hora.ToString();
                    litSituacaoServico.Text = agendamento.Situacao.ToString();

                    litCodigoAgendamento.Text = agendamento.Codigo.ToString();
                    litNomeFuncionario.Text = agendamento.Funcionario.Nome.ToString();
                    litPresencaFuncionario.Text = agendamento.CalculadoPresencaFuncionario.ToString();
                    litPresencaCliente.Text = agendamento.CalculadoPresencaCliente.ToString();

                if (agendamento.CalculadoPresencaCliente == "Presente" && agendamento.CalculadoPresencaFuncionario == "Presente" && !agendamento.VerificaAvaliacaoPorAgendamento)
                {
                    btnAvaliacao.Visible = true;
                    using (MySqlDataReader reader = listaDetalhesAgendamento.listarProdutoAgendamento(Request["agendamento"].ToString()))
                    {
                        if (reader != null)
                        {
                            grdProdutos.Visible = true;
                            grdProdutos.DataSource = reader;
                            grdProdutos.DataBind();
                        }
                        else
                        {
                            grdProdutos.Visible = false;
                        }

                        reader.Close();
                        listaDetalhesAgendamento.FecharConexao();
                    }
                }
                else if (agendamento.CalculadoPresencaFuncionario == "-" && agendamento.CalculadoPresencaCliente == "-")
                    btnCancelarAgendamento.Visible = true;

                else
                {
                    btnAvaliacao.Visible = false;
                    btnCancelarAgendamento.Visible = false;
                }

            }
        }

        protected void btnAvaliacao_Click(object sender, EventArgs e)
        {
            listaAgendamentos listaDetalhesAgendamento = new listaAgendamentos();
            Agendamento agendamento = listaDetalhesAgendamento.listarDetalhesAgendamento(Session["login"].ToString(), Request["agendamento"].ToString());

            if (agendamento != null)
            {
                Response.Redirect("~/avaliacao.aspx?cdAgendamento=" + agendamento.Codigo);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            pnlConfirmarCancelamento.Visible = true;
        }

        protected void btnSim_Click(object sender, EventArgs e)
        {
            CancelaAgendamento agendamentos = new CancelaAgendamento();

            if (agendamentos.CancelarServico(Session["login"].ToString(), Request["agendamento"].ToString()))
            {
               Response.Redirect("minha_conta_agendamentos.aspx");
            }
        }

        protected void btnNao_Click(object sender, EventArgs e)
        {
            pnlConfirmarCancelamento.Visible = false;
        }
    }
}