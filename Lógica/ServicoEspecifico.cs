using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using prjTCC.Classe;
using MySql.Data.MySqlClient;

namespace prjTCC.Lógica
{
    public class ServicoEspecifico : Banco
    {
        private Servico servico = new Servico();
        public Servico DadosServicoEspecifico(string codigoServico)
        {
            Conectar();
            try
            {
                List<Parametro> parametro = new List<Parametro>();
                parametro.Add(new Parametro("vCodigoServico", codigoServico));
                MySqlDataReader dados = Consultar("ServicoSelecionadoInformacoesDoServicoEAvaliacaoMedia", parametro);
                if (dados.Read())
                {
                    List<Imagem> imagens = new List<Imagem>();
                    servico.Imagem = new List<Imagem>();
                    servico.Codigo = dados.GetInt32(0);
                    servico.Nome = dados.GetString(1);
                    servico.Valor = dados.GetDouble(2);
                    servico.Duracao = dados.GetString(3);
                    servico.Descricao = dados.GetString(4);
                    string[] nomeImagem = dados.GetString(5).Split(',');
                    string[] pastaImagem = dados.GetString(6).Split(',');
                    if (!dados.IsDBNull(7))
                    {
                        servico.ValorAvaliacaoMedia = dados.GetInt32(7);
                    }
                    servico.QuantidadeAvaliacao = dados.GetInt32(8);
                    
                    for (int i = 0; i < nomeImagem.Length; i++)
                    {
                        Imagem imagemTemp = new Imagem();
                        imagemTemp.Nome = nomeImagem[i];
                        imagemTemp.Pasta = pastaImagem[i];
                        servico.Imagem.Add(imagemTemp);
                    }
                }
                if (!dados.IsClosed) { dados.Close(); }
            }
            catch
            {
               throw new Exception("Não foi possível acessar os detalhes desse serviço.");
            }
            finally
            {
                Desconectar();
            }
            return servico;
        }
    }
}