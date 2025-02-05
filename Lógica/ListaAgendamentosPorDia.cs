using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using prjTCC.Classe;
using MySql.Data.MySqlClient;

namespace prjTCC.Lógica
{
    public class ListaAgendamentosPorDia : Banco
    {
        private List<Funcionario> agendamentosDeFuncionario = new List<Funcionario>();
        public List<Funcionario> ListarTodosAgendamentosPorDia(string data)
        {
            try
            {
                Conectar();
                List<Parametro> parametros = new List<Parametro>();
                parametros.Add(new Parametro("vDataSelec", data));
                MySqlDataReader dados = Consultar("ListarTodosAgendamentosPorDia", parametros);
                List<Funcionario> agendamentosFuncionariosTemp = new List<Funcionario>();
                while (dados.Read())
                {
                    Funcionario funcionario = new Funcionario();
                    funcionario.Agendamentos = new List<Agendamento>();

                    funcionario.Nome = dados.GetString(0);
                    string[] codigoAgendamentos = dados.GetString(1).Split(',');
                    string[] nomeServicoAgendamentos = dados.GetString(2).Split(',');
                    string[] horaFuncionarioServicoAgendamento = dados.GetString(3).Split(',');
                    string[] duracaoServicoAgendamentos = dados.GetString(4).Split(',');
                    string[] confirmadoAgendamentos = dados.GetString(5).Split(',');

                    for (int i = 0; i < codigoAgendamentos.Length; i++)
                    {
                        Agendamento agendamento = new Agendamento();
                        agendamento.Servico = new Servico();
                        agendamento.FuncionarioServicoDiaDeTrabalho = new FuncionarioServicoDiaDeTrabalho();
                        agendamento.Codigo = codigoAgendamentos[i];
                        agendamento.Servico.Nome = nomeServicoAgendamentos[i];
                        agendamento.FuncionarioServicoDiaDeTrabalho.Hora = horaFuncionarioServicoAgendamento[i];
                        agendamento.Servico.Duracao = duracaoServicoAgendamentos[i];
                        agendamento.Data = data;
                        agendamento.AgendamentoConcluido = Convert.ToBoolean(Convert.ToInt16(confirmadoAgendamentos[i]));
                        funcionario.Agendamentos.Add(agendamento);
                    }
                    agendamentosFuncionariosTemp.Add(funcionario);
                }
                agendamentosDeFuncionario = agendamentosFuncionariosTemp;
                if (!dados.IsClosed) { dados.Close(); }
            }
            catch
            {
                throw new Exception("Não foi possível listar os agendamentos");
            }
            finally
            {
                Desconectar();
            }
            return agendamentosDeFuncionario;
        }
    }
}