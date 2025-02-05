using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using prjTCC.Lógica;
using prjTCC.Classe;

namespace prjTCC
{
    public partial class dona_agenda_ : System.Web.UI.Page
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

            DateTime data = new DateTime();
            if (!IsPostBack)
            {
                data = DateTime.Now;
            }
            else
            {
                data = DateTime.Parse(txtData.Text);
            }
            txtData.Text = data.ToString("yyyy-MM-dd");
            //litDiaAnterior.Text = data.AddDays(-1).ToString("dd/MM");
            //litDiaPosterior.Text = data.AddDays(1).ToString("dd/MM");
            MostrarAgenda(data.ToString("yyyy-MM-dd"), data.ToString("dd/MM"));
        }
        public void MostrarAgenda(string dataAtual, string dataMostrar)
        {
            string[] horasDoDia = {
                "00", "01", "02", "03", "04", "05", "06", "07",
                "08", "09", "10", "11", "12", "13", "14", "15",
                "16", "17", "18", "19", "20", "21", "22", "23"};

            ListaAgendamentosPorDia listaAgendamentosPorDia = new ListaAgendamentosPorDia();
            List<Funcionario> agendamentosDeFuncionario = listaAgendamentosPorDia.ListarTodosAgendamentosPorDia(dataAtual);

            if (agendamentosDeFuncionario.Count < 1)
            {
                litAviso.Text = "<p><i class=\"fa-solid fa-triangle-exclamation\"></i> Não há nenhum agendamento para esse dia.</p>";
            }
            else
            {
                litAviso.Text = "";
            }

            for (int i = 0; i < horasDoDia.Length; i++)
            {
                TableHeaderCell cellHora = new TableHeaderCell();
                cellHora.Text = horasDoDia[i];
                tbrDias.Cells.Add(cellHora);
            }

            bool diaRowSpan = false;

            foreach (Funcionario agendamentoDeFuncionario in agendamentosDeFuncionario)
            {
                int indiceAgendamentoAtual = 0;
                TimeSpan tsAgendamento = TimeSpan.Parse(agendamentoDeFuncionario.Agendamentos[indiceAgendamentoAtual].FuncionarioServicoDiaDeTrabalho.Hora);
                TimeSpan duracao = TimeSpan.FromMinutes(double.Parse(agendamentoDeFuncionario.Agendamentos[indiceAgendamentoAtual].Servico.Duracao));

                TableRow row = new TableRow();
                if (!diaRowSpan)
                {
                    TableCell cellDia = new TableCell();
                    cellDia.CssClass = "fixed-hora";
                    cellDia.RowSpan += agendamentosDeFuncionario.Count;

                    cellDia.Text = dataMostrar;
                    row.Cells.Add(cellDia);
                    diaRowSpan = true;
                }
                TableCell cellFuncionario = new TableCell();
                cellFuncionario.Text = agendamentoDeFuncionario.Nome;
                cellFuncionario.CssClass = "fixed-hora";
                row.Cells.Add(cellFuncionario);

                for (int i = 0; i < horasDoDia.Length; i++)
                {
                    TimeSpan tsHoraDoDia = TimeSpan.Parse(horasDoDia[i] + ":00:00");
                    TimeSpan tsHoraDoDiaMaisUmaHora = tsHoraDoDia.Add(new TimeSpan(1, 0, 0));

                    TableCell cellHora = new TableCell();

                    if (indiceAgendamentoAtual + 1 <= agendamentoDeFuncionario.Agendamentos.Count)
                    {
                        tsAgendamento = TimeSpan.Parse(agendamentoDeFuncionario.Agendamentos[indiceAgendamentoAtual].FuncionarioServicoDiaDeTrabalho.Hora);
                        duracao = TimeSpan.FromMinutes(double.Parse(agendamentoDeFuncionario.Agendamentos[indiceAgendamentoAtual].Servico.Duracao));
                        if (tsAgendamento >= tsHoraDoDia && tsAgendamento < tsHoraDoDiaMaisUmaHora)
                        {
                            Button divHorario = new Button();
                            divHorario.CommandArgument = agendamentoDeFuncionario.Agendamentos[indiceAgendamentoAtual].Codigo;
                            divHorario.Command += InformacoesDoAgendamento;
                            TimeSpan tsHorarioFinal = tsAgendamento + duracao;
                            string horarioFinal = tsHorarioFinal.ToString(@"hh\:mm");
                            divHorario.Text = agendamentoDeFuncionario.Agendamentos[indiceAgendamentoAtual].Servico.Nome + "\n" + agendamentoDeFuncionario.Agendamentos[indiceAgendamentoAtual].FuncionarioServicoDiaDeTrabalho.Hora + " - " + horarioFinal;
                            if (agendamentoDeFuncionario.Agendamentos[indiceAgendamentoAtual].AgendamentoConcluido)
                            {
                                divHorario.CssClass = "btn_horario_desativado btnhorario";
                            }
                            else
                            {
                                divHorario.CssClass = "btn_horario btnhorario";
                            }

                            if (tsAgendamento != tsHoraDoDia)
                            {
                                int diferenca = (int)(tsAgendamento - tsHoraDoDia).TotalMinutes;
                                divHorario.Style.Add("left", (diferenca) + "px");
                            }

                            divHorario.Style.Add("width", ((agendamentoDeFuncionario.Agendamentos[indiceAgendamentoAtual].Servico.Duracao) + "px"));

                            cellHora.Controls.Add(divHorario);
                            indiceAgendamentoAtual++;

                            if (indiceAgendamentoAtual + 1 <= agendamentoDeFuncionario.Agendamentos.Count)
                            {
                                tsAgendamento = TimeSpan.Parse(agendamentoDeFuncionario.Agendamentos[indiceAgendamentoAtual].FuncionarioServicoDiaDeTrabalho.Hora);
                                duracao = TimeSpan.FromMinutes(double.Parse(agendamentoDeFuncionario.Agendamentos[indiceAgendamentoAtual].Servico.Duracao));if (tsAgendamento >= tsHoraDoDia && tsAgendamento < tsHoraDoDiaMaisUmaHora)
                                if (tsAgendamento >= tsHoraDoDia && tsAgendamento < tsHoraDoDiaMaisUmaHora)
                                {
                                        i--;
                                }
                            }
                        }
                    }
                    row.Cells.Add(cellHora);

                    tblAgendamento.Rows.Add(row);
                }
            }
        }
            public void InformacoesDoAgendamento(object sender, CommandEventArgs e)
        {
            Response.Redirect("confirmar_agendamento.aspx?agendamento=" + e.CommandArgument.ToString());
        }
    }
}