using Microsoft.SqlServer.Server;
using MySql.Data.MySqlClient;
using prjTCC.Classe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjTCC.Lógica
{
    public class FiltrosDona : Banco
    {
        public void FecharConexao()
        {
            Desconectar();
        }

        public MySqlDataReader filtrarServicosDona(string filtro)
        {
            try
            {
                Conectar();

                List<Parametro> parametros = new List<Parametro>();
                parametros.Add(new Parametro("pFiltroServico", filtro + "%"));

                MySqlDataReader dados = Consultar("filtrarServicos", parametros);

                return dados;
            }

            catch (Exception)
            {
                throw new Exception("Algo deu errado ao filtrar os serviços");
            }
        }

        public MySqlDataReader filtrarFuncionarios(string fitlro)
        {
            try
            {
                Conectar();

                string procedure = "filtrarFuncionarios";

                List<Parametro> parametros = new List<Parametro>();

                parametros.Add(new Parametro("pFiltroFuncionario", fitlro + "%"));

                MySqlDataReader dados = Consultar(procedure, parametros);

                return dados;
            }

            catch (Exception)
            {
                throw new Exception("Erro ao filtrar funcionários.");
            }
        }

        public MySqlDataReader filtrarRecompensas(string fitlro)
        {
            try
            {
                Conectar();

                string procedure = "filtrarRecompensas";

                List<Parametro> parametros = new List<Parametro>();

                parametros.Add(new Parametro("pFiltroRecompensa", fitlro + "%"));

                MySqlDataReader dados = Consultar(procedure, parametros);

                return dados;
            }

            catch (Exception)
            {
                throw new Exception("Erro ao filtrar funcionários.");
            }
        }
        public MySqlDataReader filtrarProdutos(string fitlro)
        {
            try
            {
                Conectar();

                string procedure = "filtrarProdutos";

                List<Parametro> parametros = new List<Parametro>();

                parametros.Add(new Parametro("pFiltroProdutos", fitlro + "%"));

                MySqlDataReader dados = Consultar(procedure, parametros);

                return dados;
            }

            catch (Exception)
            {
                throw new Exception("Erro ao filtrar Produtos.");
            }
        }
    }
}