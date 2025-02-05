using MySql.Data.MySqlClient;
using prjTCC.Classe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjTCC.Lógica
{
    public class listaAgendamentos : Banco
    {
        private List<Agendamento> listaAgendamentosFiltrado = new List<Agendamento>();

        public List<Agendamento> listarAgendamentos(string emailCliente, string filtro)
        {
            try
            {
                Conectar();

                string procedure = "listarDadosMinimosAgendamentos";

                List<Parametro> parametros = new List<Parametro>();
                parametros.Add(new Parametro("pEmailCliente", emailCliente));
                parametros.Add(new Parametro("pFiltroAgendamento", filtro));

                MySqlDataReader dados = Consultar(procedure, parametros);

                while (dados.Read())
                {
                    Agendamento agendamento = new Agendamento();

                    agendamento.Servico = new Servico();
                    agendamento.FuncionarioServicoDiaDeTrabalho = new FuncionarioServicoDiaDeTrabalho();
                    agendamento.Servico.Imagem = new List<Imagem>();

                    agendamento.Codigo = dados.GetString(6);
                    agendamento.Servico.Nome = dados.GetString(0);
                    agendamento.Data = dados.GetString(1);
                    agendamento.FuncionarioServicoDiaDeTrabalho.Hora = dados.GetString(2);
                    agendamento.Situacao = dados.GetString(3);

                    Imagem imagem = new Imagem();
                    imagem.Pasta = dados.GetString(4);
                    imagem.Nome = dados.GetString(5);

                    agendamento.Servico.Imagem.Add(imagem);
                    listaAgendamentosFiltrado.Add(agendamento);
                }
            }

            catch (Exception)
            {
                throw new Exception("Algo deu errado na listagem de agendamentos");
            }

            finally
            {
                Desconectar();
            }

            return listaAgendamentosFiltrado;
        }


        private Agendamento agendamento = new Agendamento();

        public Agendamento listarDetalhesAgendamento(string emailCliente, string codigoAgendamento)
        {
            try
            {
                Conectar();

                string procedure = "listarMaisDetalhesAgendamento";

                List<Parametro> parametros = new List<Parametro>();
                parametros.Add(new Parametro("pEmailCliente", emailCliente));
                parametros.Add(new Parametro("pCodigoAgendamento", codigoAgendamento));

                MySqlDataReader dados = Consultar(procedure, parametros);

                while (dados.Read())
                {
                    Agendamento agendamentoTemp = new Agendamento();

                    agendamentoTemp.Servico = new Servico();
                    agendamentoTemp.FuncionarioServicoDiaDeTrabalho = new FuncionarioServicoDiaDeTrabalho();
                    agendamentoTemp.Servico.Imagem = new List<Imagem>();
                    agendamentoTemp.Funcionario = new Funcionario();

                    agendamentoTemp.Codigo = dados.GetString(8);
                    agendamentoTemp.Servico.Nome = dados.GetString(0);
                    agendamentoTemp.Data = dados.GetString(1);
                    agendamentoTemp.FuncionarioServicoDiaDeTrabalho.Hora = dados.GetString(2);
                    agendamentoTemp.Funcionario.Nome = dados.GetString(3);

                    /*agendamento.PresencaFuncionario = dados.GetBoolean(5);
                    agendamento.PresencaCliente = dados.GetBoolean(6);*/

                    agendamentoTemp.CalculadoPresencaFuncionario = dados.GetString(4);
                    agendamentoTemp.CalculadoPresencaCliente = dados.GetString(5);
                    agendamentoTemp.VerificaAvaliacaoPorAgendamento = dados.GetBoolean(9);
                    agendamentoTemp.Situacao = dados.GetString(10);

                    Imagem imagem = new Imagem();
                    imagem.Pasta = dados.GetString(6);
                    imagem.Nome = dados.GetString(7);

                    agendamentoTemp.Servico.Imagem.Add(imagem);
                    agendamento = agendamentoTemp;
                }
            }

            catch (Exception)
            {
                throw new Exception("Algo deu errado na listagem de agendamentos");
            }

            finally
            {
                Desconectar();
            }

            return agendamento;
        }

        
        public MySqlDataReader listarProdutoAgendamento(string codigoAgendamento)
        {
            try
            {
                Conectar();

                string procedure = "listarProdutosDoAgendamento";

                List<Parametro> parametros = new List<Parametro>();
                parametros.Add(new Parametro("pCodigoAgendamento", codigoAgendamento));

                MySqlDataReader dados = Consultar(procedure, parametros);

                return dados;
            }

            catch (Exception)
            {
                throw new Exception("Algo deu errado na listagem dos produtos do agendamento.");
            }

            
        }

        public void FecharConexao()
        {
            Desconectar();
        }
    }
}