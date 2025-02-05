using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using prjTCC.Classe;
using MySql.Data.MySqlClient;

namespace prjTCC.Lógica
{
    public class ListaDepoimentoServico : Banco
    {
        private List<Depoimento> depoimentos = new List<Depoimento>();

        public List<Depoimento> ListarDepoimentos (string codigoServico, string filtroDepoimento)
        {
            try
            {
                Conectar();
                List<Parametro> parametro = new List<Parametro>();
                parametro.Add(new Parametro("vCodigoServico", codigoServico));
                parametro.Add(new Parametro("vFiltro", filtroDepoimento));
                MySqlDataReader dados = Consultar("ServicoSelecionadoTodasAsAvaliacaoEFiltro", parametro);
                while (dados.Read())
                {
                    Depoimento depoimento = new Depoimento();
                    depoimento.Agendamento = new Agendamento();
                    depoimento.Cliente = new Cliente();
                    depoimento.Funcionario = new Funcionario();
                    depoimento.Agendamento.Codigo = dados.GetString(0);
                    depoimento.DataAvaliacao = dados.GetString(1);
                    depoimento.NomeCliente = dados.GetString(2);
                    depoimento.Avaliacao = dados.GetInt32(3);
                    depoimento.Descricao = dados.GetString(4);
                    depoimento.Funcionario.Nome = dados.GetString(5);
                    depoimentos.Add(depoimento);
                }
                if (!dados.IsClosed) { dados.Close(); }
            }
            catch
            {
                throw new Exception("Não foi possível carregar as avaliações.");
            }
            return depoimentos;
        }
    }
}