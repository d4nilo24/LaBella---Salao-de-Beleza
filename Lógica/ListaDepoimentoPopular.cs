using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using prjTCC.Classe;
using MySql.Data.MySqlClient;

namespace prjTCC.Lógica
{
    public class ListaDepoimentoPopular : Banco
    {
        private List<Depoimento> depoimentos = new List<Depoimento>();
        public List<Depoimento> ListarPrincipaisDepoimentos ()
        {
            Conectar();
            try
            {
                MySqlDataReader dados = Consultar("AvaliacoesPopulares");
                while (dados.Read())
                {
                    Depoimento depoimento = new Depoimento();
                    depoimento.NomeCliente = dados.GetString(0);
                    depoimento.Avaliacao = dados.GetInt32(1);
                    depoimento.Descricao = dados.GetString(2);
                    depoimentos.Add(depoimento);
                }
                if (!dados.IsClosed) { dados.Close(); }
            }
            catch
            {
                throw new Exception("Não foi possível acessar os principais depoimentos.");
            }
            finally
            {
                Desconectar();
            }
            return depoimentos;
        }
    }
}