using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using prjTCC.Classe;
using MySql.Data.MySqlClient;

namespace prjTCC.Lógica
{
    public class DadosAgendamentoEspecifico : Banco
    {
        private Agendamento agendamento = new Agendamento();
        public Agendamento dadosAgendamentoEspecifico (string codigoAgendamento)
        {
            try
            {
                Conectar();
                List<Parametro> parametros = new List<Parametro>();
                parametros.Add(new Parametro("vCodAgendamento", codigoAgendamento));
                MySqlDataReader dados = Consultar("DadosAgendamentoEspecifico",parametros);

                if (dados.Read())
                {
                    Agendamento agendamentoTemp = new Agendamento();
                    agendamentoTemp.FuncionarioServicoDiaDeTrabalho = new FuncionarioServicoDiaDeTrabalho();
                    agendamentoTemp.Cliente = new Cliente();
                    agendamentoTemp.Funcionario = new Funcionario();
                    agendamentoTemp.Servico = new Servico();
                    agendamentoTemp.Cupom = new Cupom();
                    agendamentoTemp.Codigo = dados.GetString(0);
                    agendamentoTemp.Data = dados.GetString(1);
                    agendamentoTemp.FuncionarioServicoDiaDeTrabalho.Hora = dados.GetString(2);
                    agendamentoTemp.Cliente.Nome = dados.GetString(3);
                    agendamentoTemp.Cliente.Email = dados.GetString(4);
                    agendamentoTemp.Funcionario.Nome = dados.GetString(5);
                    agendamentoTemp.Servico.Nome = dados.GetString(6);
                    if (!dados.IsDBNull(7))
                    {
                        agendamentoTemp.Cupom.Valor = dados.GetInt32(7);
                    }
                    if (!dados.IsDBNull(8))
                    {
                        agendamentoTemp.PresencaCliente = dados.GetBoolean(8);
                        agendamentoTemp.PresencaFuncionario = dados.GetBoolean(9);
                    }
                    agendamentoTemp.AgendamentoConcluido = dados.GetBoolean(10);
                    agendamentoTemp.Servico.Valor = dados.GetDouble(11);
                    agendamentoTemp.ValorFinal = dados.GetDouble(12);
                    agendamentoTemp.AgendamentoIniciado = dados.GetBoolean(13);
                    agendamento = agendamentoTemp;
                }
                if (!dados.IsClosed) { dados.Close(); }
            }
            finally
            {
                Desconectar();
            }
            return agendamento;
        }
    }
}