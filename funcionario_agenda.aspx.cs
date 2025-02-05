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
    public partial class funcionario_agenda : System.Web.UI.Page
    {
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

            try
            {
                if (!IsPostBack)
                {
                   
                    txtData.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    // alterado
                    MostrarAgenda();
                    //tblAgendamento.Visible = false;
                    tblAgendamento.Visible = true;
                }
                else
                {
                    tblAgendamento.Visible = true;
                    MostrarAgenda();
                }

            }
            catch (Exception ex)
            {
                HttpContext.Current.Items["ErroTipo"] = "500 - Erro no servidor interno";
                HttpContext.Current.Items["ErroMensagem"] = ex.Message;
                Server.Transfer("~/erro.aspx");
            }
        }
        public void MostrarAgenda()
        {
            try
            {
                string[] horasDoDia = {
                "00", "01", "02", "03", "04", "05", "06", "07",
                "08", "09", "10", "11", "12", "13", "14", "15",
                "16", "17", "18", "19", "20", "21", "22", "23"};

                DateTime diaSelecionado = new DateTime();
                diaSelecionado = DateTime.Parse(txtData.Text);

                ListaAgendamentosPorSemana listaAgendamentoPorSemana = new ListaAgendamentosPorSemana();
                List<Agendamento> agendamentos = listaAgendamentoPorSemana.ListarAgendamentosPorSemana(diaSelecionado.Date.ToString("yyyy-MM-dd"), Session["login"].ToString());
                int indiceAgendamento = 0;

                List<TableRow> rowsHora = new List<TableRow>();

                for (int i = 0; i < horasDoDia.Length; i++)
                {
                    TableRow rowHora = new TableRow();
                    TableCell cellHora = new TableCell();
                    cellHora.CssClass = "fixed-hora";

                    cellHora.Text = horasDoDia[i];
                    rowHora.Cells.Add(cellHora);

                    rowsHora.Add(rowHora);
                    tblAgendamento.Rows.Add(rowsHora[i]);
                }

                bool repetirAgendamento = false;
                TimeSpan tsAgendamentoUltrapassado = new TimeSpan();
                TimeSpan tsDuracaoUltrapassada = new TimeSpan();

                for (int i = 0; i < 7; i++)
                {
                    TableHeaderCell cellDia = new TableHeaderCell();
                    cellDia.Text = diaSelecionado.Date.ToString("dd/MM");
                    tbrDias.Cells.Add(cellDia);

                    if (agendamentos.Count == 0)
                    {
                        for (int b = 0; b < horasDoDia.Length; b++)
                        {
                            TableCell cellVazia = new TableCell();
                            rowsHora[b].Cells.Add(cellVazia);
                        }
                    }
                    else
                    {

                        for (int a = indiceAgendamento; a < agendamentos.Count; a++)
                        {
                            indiceAgendamento = a;

                            if (agendamentos[a].Data != diaSelecionado.Date.ToString("yyyy-MM-dd") && !repetirAgendamento)
                            {
                                for (int b = 0; b < horasDoDia.Length; b++)
                                {
                                    TableCell cellVazia = new TableCell();
                                    rowsHora[b].Cells.Add(cellVazia);
                                }
                                break;
                            }
                            else
                            {
                                for (int b = 0; b < horasDoDia.Length; b++)
                                {
                                    TimeSpan tsHoraDoDia = TimeSpan.Parse(horasDoDia[b] + ":00:00");
                                    TimeSpan tsHoraDoDiaMaisUmaHora = tsHoraDoDia.Add(new TimeSpan(1, 0, 0));

                                    if (a < agendamentos.Count)
                                    {
                                        TimeSpan tsAgendamento = TimeSpan.Parse(agendamentos[a].FuncionarioServicoDiaDeTrabalho.Hora);
                                        TimeSpan duracao = TimeSpan.FromMinutes(double.Parse(agendamentos[a].Servico.Duracao));
                                        if (repetirAgendamento || (tsAgendamento >= tsHoraDoDia && tsAgendamento < tsHoraDoDiaMaisUmaHora))
                                        {
                                            TableCell cellHorario = new TableCell();
                                            Button divHorario = new Button();
                                            divHorario.CommandArgument = agendamentos[a].Codigo;
                                            divHorario.Command += InformacoesDoAgendamento;
                                            TimeSpan tsHorarioFinal = tsAgendamento + duracao;
                                            string horarioFinal = tsHorarioFinal.ToString(@"hh\:mm");
                                            divHorario.Text = agendamentos[a].Servico.Nome + "\n" + agendamentos[a].FuncionarioServicoDiaDeTrabalho.Hora + " - " + horarioFinal;
                                            if (agendamentos[a].AgendamentoConcluido)
                                            {
                                                divHorario.CssClass = "btn_horario_desativado";
                                            }
                                            else
                                            {
                                                divHorario.CssClass = "btn_horario";
                                            }

                                            if (tsAgendamento != tsHoraDoDia && !repetirAgendamento)
                                            {
                                                int diferenca = (int)(tsAgendamento - tsHoraDoDia).TotalMinutes;
                                                divHorario.Style.Add("top", diferenca + "px");
                                            }

                                            if (repetirAgendamento)
                                            {
                                                TimeSpan horaRecortada = TimeSpan.FromDays(1) - tsAgendamentoUltrapassado;

                                                tsAgendamentoUltrapassado = tsAgendamentoUltrapassado + horaRecortada;
                                                tsAgendamentoUltrapassado = new TimeSpan(tsAgendamentoUltrapassado.Hours, tsAgendamentoUltrapassado.Minutes, 0);
                                                tsDuracaoUltrapassada = duracao - horaRecortada;

                                                divHorario.Style.Add("height", horaRecortada.TotalMinutes + "px");

                                                if (tsAgendamentoUltrapassado + tsDuracaoUltrapassada > TimeSpan.FromDays(1))
                                                {
                                                    repetirAgendamento = true;
                                                    b = horasDoDia.Length;
                                                }
                                                else
                                                {
                                                    tsAgendamentoUltrapassado = TimeSpan.Zero;
                                                    tsDuracaoUltrapassada = TimeSpan.Zero;
                                                    repetirAgendamento = false;
                                                }

                                            }
                                            else if (tsAgendamento + duracao > TimeSpan.FromDays(1))
                                            {
                                                TimeSpan horaRecortada = TimeSpan.FromDays(1) - tsAgendamento;

                                                tsAgendamentoUltrapassado = tsAgendamento - horaRecortada;
                                                tsAgendamentoUltrapassado = new TimeSpan(tsAgendamentoUltrapassado.Hours, tsAgendamentoUltrapassado.Minutes, 0);
                                                tsDuracaoUltrapassada = duracao - horaRecortada;

                                                divHorario.Style.Add("height", horaRecortada.TotalMinutes + "px");
                                                repetirAgendamento = true;
                                            }
                                            else
                                            {
                                                divHorario.Style.Add("height", agendamentos[a].Servico.Duracao + "px");
                                            }

                                            cellHorario.Controls.Add(divHorario);
                                            rowsHora[b].Cells.Add(cellHorario);
                                            if (repetirAgendamento)
                                            {
                                                indiceAgendamento = a;
                                                break;
                                            }
                                            else
                                            {
                                                a++;
                                            }
                                        }
                                        else
                                        {
                                            TableCell cellVazia = new TableCell();
                                            rowsHora[b].Cells.Add(cellVazia);
                                        }
                                    }
                                    else
                                    {
                                        TableCell cellVazia = new TableCell();
                                        rowsHora[b].Cells.Add(cellVazia);
                                    }
                                }
                            }
                        }
                    }
                    diaSelecionado = diaSelecionado.AddDays(1);
                }
            }
            catch (Exception ex)
            {
                HttpContext.Current.Items["ErroTipo"] = "500 - Erro no servidor interno";
                HttpContext.Current.Items["ErroMensagem"] = ex.Message;
                Server.Transfer("~/erro.aspx");
            }
        }
        public void InformacoesDoAgendamento(object sender, CommandEventArgs e)
        {
            Response.Redirect("confirmar_agendamento.aspx?agendamento=" + e.CommandArgument.ToString());
        }

        protected void btnMostrarAgenda_Click(object sender, EventArgs e)
        {
            tblAgendamento.Visible = true;
            //MostrarAgenda();
        }
    }
}
