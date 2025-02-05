using MySql.Data.MySqlClient;
using prjTCC.Classe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjTCC.Lógica
{
    public class ResgateRecompensa : Banco
    {
        Premio recompensa = new Premio();

        public void FecharConexao()
        {
            Desconectar();
        }

        public MySqlDataReader listarPremiosAResgatar()
        {
			try
			{
				Conectar();

				string procedure = "listarPremiosClienteParaResgate";

				MySqlDataReader dados = Consultar(procedure, null);

				return dados;
            }

			catch (Exception)
			{
				throw new Exception("Algo deu errado ao listar os prêmios dos clientes.s");
			}
        }

        public MySqlDataReader filtrarPremiosCliente(string fitlro)
        {
            try
            {
                Conectar();

                string procedure = "filtrarPremiosCliente";

                List<Parametro> parametros = new List<Parametro>();

                parametros.Add(new Parametro("pFiltroPremioCliente", fitlro + "%"));

                MySqlDataReader dados = Consultar(procedure, parametros);

                return dados;
            }

            catch (Exception)
            {
                throw new Exception("Erro ao filtrar prêmios dos clientes.");
            }
        }

        public Premio mostrarDadosPremioSelecionado(string codPremio)
        {
            try
            {
                Conectar();

                string procedure = "mostrarPremioDetalhes";

                List<Parametro> parametros = new List<Parametro>();

                parametros.Add(new Parametro("pCodPremio", codPremio));
                MySqlDataReader dados = Consultar(procedure, parametros);

                if (dados.Read())
                {
                    recompensa.Nome = dados.GetString(0);
                    recompensa.Descricao = dados.GetString(1);

                    recompensa.Imagem = new Imagem();
                    recompensa.Imagem.Pasta = dados.GetString(2);
                    recompensa.Imagem.Nome = dados.GetString(3);
                }

               
            }

            catch (Exception)
            {

                throw new Exception("Algo deu errado");
            }
            finally
            {
                Desconectar();
            }
            return recompensa;
        }

        public bool registrarResgateRecompensa(string codPremio, string emailCliente)
		{
			try
			{
				Conectar();

				string procedure = "registrarResgatePremiosCliente";

				List<Parametro> parametros = new List<Parametro>();

				parametros.Add(new Parametro("pCodPremio", codPremio));
				parametros.Add(new Parametro("pEmailCliente", emailCliente));

				Executar(procedure, parametros);
            }
			catch (Exception)
			{
				throw new Exception("Houve um erro ao resgatar o prêmio.");
			}
            finally
            {
                Desconectar();
            }

            return true;
        }

    }
}