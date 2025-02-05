using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using prjTCC.Classe;

namespace prjTCC.Lógica
{
    public class ListarTodosServicos: Banco
    {
        private List<Servico> servicos = new List<Servico>();

        public List<Servico> ListarServicos()
        {
            Conectar();
            try
            {
                MySqlDataReader dados = Consultar("ListarServicos");
                while (dados.Read())
                {
                    Servico servico = new Servico();
                    servico.Codigo = dados.GetInt32(0);
                    servico.Nome = dados.GetString(1);
                    servicos.Add(servico);
                }
                if (!dados.IsClosed) { dados.Close(); }
            }
            catch
            {
                throw new Exception("Não foi possivel listar os serviços");
            }
            finally
            {
                Desconectar();
            }
            return servicos;
        }
        public MySqlDataReader ListarServicosCmb()
        {
            Conectar();
            
            MySqlDataReader dados = Consultar("ListarServicos");
            return dados;
        }

        public void FecharConexao ()
        {
            Desconectar();
        }
    }
}