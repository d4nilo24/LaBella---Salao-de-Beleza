using MySql.Data.MySqlClient;
using prjTCC.Classe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjTCC.Lógica
{
    public class adicaoRecompensa : Banco
    {
        public MySqlDataReader escolherProdutoRecompensa()
        {
            try
            {
                Conectar();

                string procedure = "escolherProdutoRecompensa";

                return Consultar(procedure);
            }

            catch (Exception)
            {
                throw new Exception("Erro na listagem de produtos.");
            }
        }

        public MySqlDataReader escolherTipoPremio()
        {
            try
            {
                Conectar();

                string procedure = "escolherTipoPremio";

                return Consultar(procedure);
            }

            catch (Exception)
            {
                throw new Exception("Erro ao listar tipos de prêmios.");
            }
        }

        public MySqlDataReader escolherServico()
        {
            try
            {
                Conectar();

                string procedure = "escolherServicoRecompensa";

                return Consultar(procedure);
            }

            catch (Exception)
            {
                throw new Exception("Erro ao listar serviços.");
            }
        }

        public MySqlDataReader escolherCategoriaServico()
        {
            try
            {
                Conectar();

                string procedure = "escolherCategoriaServicoRecompensa";

                return Consultar(procedure);
            }

            catch (Exception)
            {
                throw new Exception("Erro ao listar categorias.");
            }
        }

        public MySqlDataReader escolherCupom()
        {
            try
            {
                Conectar();

                string procedure = "escolherCupomRecompensa";

                return Consultar(procedure);
            }

            catch (Exception)
            {
                throw new Exception("Erro ao listar cupons.");
            }
        }

        public bool adicionarRecompensaProduto(string CodTipoPremio, string CodProdutoPremio, string nomePremio, 
            string qtPontosNecessarios, string descricaoPremio, string nomeImagem, string nomePasta)
        {
            try
            {
                Conectar();

                string procedure = "adicionarRecompensaProduto";

                List<Parametro> parametros = new List<Parametro>();

                parametros.Add(new Parametro("pCodTipoPremio", CodTipoPremio));
                parametros.Add(new Parametro("pCodProduto", CodProdutoPremio));
                parametros.Add(new Parametro("vNomePremio", nomePremio));
                parametros.Add(new Parametro("vQtPontosPremio", qtPontosNecessarios));
                parametros.Add(new Parametro("vDescricaoPremio", descricaoPremio));
                parametros.Add(new Parametro("pNomeImagem", nomeImagem));
                parametros.Add(new Parametro("pNomePasta", nomePasta));

                Consultar(procedure, parametros);
                return true;
            }

            catch (Exception)
            {
                throw new Exception("Houve um erro ao adicionar o prêmio.");
            }
        }

        public bool adicionarRecompensaCupom(string CodTipoPremio, string CodCupomDesconto, string CodServico,
            string codCategoriaServico, string NomePremio, string qtPontosNecesaaarios, string DescricaoPremioCupom,
            string nomeImagem, string nomePasta)
        {
            try
            {
                Conectar();

                string procedure = "adicionarRecompensaCupom";

                List<Parametro> parametros = new List<Parametro>();

                parametros.Add(new Parametro("pCodTipoPremio", CodTipoPremio));
                parametros.Add(new Parametro("pValorCupom", CodCupomDesconto));
                parametros.Add(new Parametro("vCodServico", CodServico));
                parametros.Add(new Parametro("vCodCategoriaServico", codCategoriaServico));
                parametros.Add(new Parametro("vNomePremio", NomePremio));
                parametros.Add(new Parametro("vQtPontosPremio", qtPontosNecesaaarios));
                parametros.Add(new Parametro("vDescricaoPremio", DescricaoPremioCupom));
                parametros.Add(new Parametro("pNomeImagem", nomeImagem));
                parametros.Add(new Parametro("pNomePasta", nomePasta));

                Consultar(procedure, parametros);
                return true;
            }

            catch (Exception)
            {
                throw new Exception("Houve um erro na adição de recompensa do tipo cupom.");
            }
        }
    }
}