using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using prjTCC.Classe;

namespace prjTCC.Lógica
{
    public class adcionarServico : Banco
    {
        private Servico servico = new Servico();
        public Servico AdcionarServico(string nome, string descricao, double valor, string tempoDuracao, int codCat, int pontos)
        {
            try
            {
                Conectar();
                List<Parametro> parametros = new List<Parametro>();
                parametros.Add(new Parametro("pNome", nome));
                parametros.Add(new Parametro("pDescricao", descricao));
                parametros.Add(new Parametro("pValor", valor.ToString()));
                parametros.Add(new Parametro("pDuracao", tempoDuracao));
                parametros.Add(new Parametro("pCdCategoria", codCat.ToString()));
                parametros.Add(new Parametro("pPontos", pontos.ToString()));
                MySqlDataReader dados = Consultar("adicionarServico", parametros);
                if (dados.Read())
                {
                    Servico servicoTemp = new Servico();
                    servicoTemp.Codigo = dados.GetInt32(0);
                    servico = servicoTemp;
                }
            }
            catch
            {
                throw new Exception("Erro ao adicionar o serviço.");
            }
            finally
            {
                Desconectar();
            }
            return servico;
        }

        public void ImagemServico(string codigoServico, List<string> imagem, string pasta)
        {
            try
            {
                Conectar();
                for (int i = 0; i < imagem.Count; i++)
                {
                    List<Parametro> parametros = new List<Parametro>();
                    parametros.Add(new Parametro("pCodServico", codigoServico));
                    parametros.Add(new Parametro("pPastaImagem", pasta));
                    parametros.Add(new Parametro("pNomeImagem", imagem[i]));
                    Executar("AdicionarServicoImagem", parametros);
                }
            }
            catch
            {
                throw new Exception("Não foi possível adicionar a(s) imagem(ns) de serviço.");
            }
            finally
            {
                Desconectar();
            }
        }
    }
}