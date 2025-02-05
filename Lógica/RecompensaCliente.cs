using MySql.Data.MySqlClient;
using prjTCC.Classe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjTCC.Lógica
{
    public class RecompensaCliente : Banco
    {
		public List<Premio> listarRecompensasCliente(string emailCliente, string tipoPremio)
        {
			try
			{
				Conectar();

				string procedure = "listarDadosMinimosPremios";

				List<Parametro> parametros = new List<Parametro>();

				parametros.Add(new Parametro("pEmailCliente", emailCliente));
				parametros.Add(new Parametro("pTipoPremio", tipoPremio));

                List<Premio> PremiosCliente = new List<Premio>();

                MySqlDataReader dados = Consultar(procedure, parametros);

                while (dados.Read())
				{
					Premio recompensa = new Premio();

					recompensa.Nome = dados.GetString(0);
					recompensa.Descricao = dados.GetString(1);
					
					recompensa.Imagem = new Imagem();

					if (!dados.IsDBNull(2))
						recompensa.Imagem.Pasta = dados.GetString(2);

					if (!dados.IsDBNull(3))
						recompensa.Imagem.Nome = dados.GetString(3);

					recompensa.Codigo = dados.GetInt32(4);
					recompensa.CondicaoPremio = dados.GetString(5);
					recompensa.CondicaoPremioEstoque = dados.GetString(6);
					PremiosCliente.Add(recompensa);
				}

				return PremiosCliente;
			}

			catch (Exception)
			{

				throw new Exception("Houve um erro ao listar os prêmios do cliente.");
			}

			finally 
			{
				Desconectar();
			}
        }

		public Premio mostrarDadosPremioparaRetirada(string codRecompensa, string emailCliente)
        {
            try
            {
				Premio recompensa = new Premio();

				Conectar();

				string procedure = "mostrarDadosRecompensaEspecificaCliente";	

				List<Parametro> parametros = new List<Parametro>();

				parametros.Add(new Parametro("pCodRecompensa", codRecompensa));
				parametros.Add(new Parametro("pEmailCliente", emailCliente));

				MySqlDataReader dados = Consultar(procedure, parametros);
				recompensa.Imagem = new Imagem();
				if (dados.Read())
                {
					if (!dados.IsDBNull(0))
						recompensa.Imagem.Pasta = dados.GetString(0);
					if (!dados.IsDBNull(1))
						recompensa.Imagem.Nome = dados.GetString(1);
					if (!dados.IsDBNull(2))
						recompensa.Nome = dados.GetString(2);
					if (!dados.IsDBNull(3))
						recompensa.Descricao = dados.GetString(3);
					if (!dados.IsDBNull(4))
					{
                        recompensa.TipoPremio = new TipoPremio();
                        recompensa.TipoPremio.Codigo = dados.GetInt32(4);
                    }	
				}

				return recompensa;
            }

            catch (Exception)
            {
                throw new Exception("Não foi possível mostrar os dados do prêmio para a retirada.");
            }
        }


		public bool retirarRecompensaCliente(string CodPremio, string EmailCliente)
		{
			try
			{
				Conectar();

				string procedure = "retirarRecompensaCliente";

                List<Parametro> parametros = new List<Parametro>();

				parametros.Add(new Parametro("pCodPremio", CodPremio));
				parametros.Add(new Parametro("pEmailCliente", EmailCliente));

				Executar(procedure, parametros);
				return true;
			}

			catch (Exception)
			{
				throw new Exception("Algo deu errado no resgate do prêmio.");
			}
		}
    }
}