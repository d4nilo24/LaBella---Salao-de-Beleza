using prjTCC.Classe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjTCC.Lógica
{
    public class ManipulacaoImagemServico : Banco
    {
        public bool deletarImagem(string pastaImagem, string nomeImagem, string codServico)
        {
            try
            {
                Conectar();

                string procedure = "DeletarServicoImagem";

                List<Parametro> parametros = new List<Parametro>();

                parametros.Add(new Parametro("pCodServico", codServico));
                parametros.Add(new Parametro("pPastaImagem", pastaImagem));
                parametros.Add(new Parametro("pNomeImagem", nomeImagem));

                Executar(procedure, parametros);
                return true;
            }

            catch (Exception)
            {
                throw new Exception("Houve um erro ao deletar a imagem.");
            }

            finally
            {
                Desconectar();
            }
        }

        public bool tornarImagemPrincipal(string pastaImagem, string nomeImagem, string codServico)
        {
            try
            {
                Conectar();

                string procedure = "DefinirImagemServicoPrincipal";

                List<Parametro> parametros = new List<Parametro>();

                parametros.Add(new Parametro("pCodServico", codServico));
                parametros.Add(new Parametro("pPastaImagem", pastaImagem));
                parametros.Add(new Parametro("pNomeImagem", nomeImagem));

                Executar(procedure, parametros);
                return true;

            }

            catch (Exception)
            {

                throw new Exception("Houve um erro ao tornar a imagem principal.");
            }

            finally
            {
                Desconectar();
            }
        }

        public bool adicionarImagem(string pastaImagem, string nomeImagem, string codServico)
        {
            try
            {
                Conectar();

                string procedure = "AdicionarServicoImagem";

                List<Parametro> parametros = new List<Parametro>();

                parametros.Add(new Parametro("pCodServico", codServico));
                parametros.Add(new Parametro("pPastaImagem", pastaImagem));
                parametros.Add(new Parametro("pNomeImagem", nomeImagem));

                Executar(procedure, parametros);
                return true;
            }

            catch (Exception)
            {

                throw new Exception("Houve um erro ao adicionar a imagem ao banco.");
            }

            finally
            {
                Desconectar();
            }
        }
    }
}