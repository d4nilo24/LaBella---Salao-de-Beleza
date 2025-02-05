using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using prjTCC.Classe;
using MySql.Data.MySqlClient;

namespace prjTCC.Lógica
{
    public class ListaAgendamentosPorSemana: Banco
    {
        private List<Agendamento> agendamentos = new List<Agendamento>();
        public List<Agendamento> ListarAgendamentosPorSemana (string data, string codigoFuncionario)
        {
            try
            {
                Conectar();
                List<Parametro> parametros = new List<Parametro>();
                parametros.Add(new Parametro("vDataSelec", data));
                parametros.Add(new Parametro("vCodFuncionario", codigoFuncionario));
                MySqlDataReader dados = Consultar("listarAgendamentosPorSemana", parametros);

                while (dados.Read())
                {
                    Agendamento agendamento = new Agendamento();
                    agendamento.Servico = new Servico();
                    agendamento.FuncionarioServicoDiaDeTrabalho = new FuncionarioServicoDiaDeTrabalho();
                    agendamento.Codigo = dados.GetString(0);
                    agendamento.Servico.Nome = dados.GetString(1);
                    agendamento.FuncionarioServicoDiaDeTrabalho.Hora = dados.GetString(2);
                    agendamento.Servico.Duracao = dados.GetString(3);
                    agendamento.Data = dados.GetDateTime(4).ToString("yyyy-MM-dd");
                    agendamento.AgendamentoConcluido = dados.GetBoolean(5);
                    agendamentos.Add(agendamento);
                }
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
            return agendamentos;
        }
    }
}