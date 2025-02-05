using MySql.Data.MySqlClient;
using prjTCC.Classe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjTCC.Lógica
{
    public class AtribuicaoServicoFuncionario : Banco
    {
        public void FecharConexao()
        {
            Desconectar();
        }

        public MySqlDataReader listarServicosDisponiveis(string codFuncionario)
        {
			try
			{
				Conectar();

				string procedure = "listarDadosServicosNaoAtribuidos";

				List<Parametro> parametros = new List<Parametro>();
				parametros.Add(new Parametro("pCodFuncionario", codFuncionario));

				MySqlDataReader dados = Consultar(procedure, parametros);

				return dados;
            }	
			catch (Exception)
			{
				throw new Exception("Houve um erro ao listar os serviços");
			}
        }

		public bool atribuirServicoFuncionario(string codFuncionario, string CodServico)
		{
			try
			{
				Conectar();

				string procedure = "funcionarioAtribuirServico";

                List<Parametro> parametros = new List<Parametro>();

				parametros.Add(new Parametro("pCodFuncionario", codFuncionario));
				parametros.Add(new Parametro("pCodServico", CodServico));

				Executar(procedure, parametros);	

				return true;
			}

			catch (Exception)
			{

				throw new Exception("Houve um erro ao atribuir este serviço ao funcionário.");
			}
		}

		public MySqlDataReader listarServicosAtribuidos(string codFuncionario)
		{
			try
			{
				Conectar();

				string procedure = "listarDadosServicosAtribuidos";

				List<Parametro> parametros = new List<Parametro>();

				parametros.Add(new Parametro("pCodFuncionario", codFuncionario));

				MySqlDataReader dados = Consultar(procedure, parametros);

				return dados;

            }

			catch (Exception)
			{
                throw new Exception("Houve um erro ao listar serviços atribuídos ao funcionário.");
            }
		}

		public bool desatribuirServicoFuncionario(string codfuncionario, string codservico)
		{
			
				Conectar();

				string procedure = "desatribuirServicoFuncionario";

                List<Parametro> parametros = new List<Parametro>();

                parametros.Add(new Parametro("pCodFuncionario", codfuncionario));
                parametros.Add(new Parametro("pCodServico", codservico));

                Executar(procedure, parametros);

				return true;
            

			/*catch (Exception)
			{

                throw new Exception("Houve um erro ao desatribuir serviço atribuído ao funcionário.");
            }*/
		}
    }
}