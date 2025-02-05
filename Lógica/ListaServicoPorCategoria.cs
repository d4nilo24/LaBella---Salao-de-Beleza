using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using prjTCC.Classe;
using MySql.Data.MySqlClient;

namespace prjTCC.Lógica
{
    public class ListaServicoPorCategoria : Banco
    {
        private List<Servico> servicos = new List<Servico>();
        public int PaginaTotal { get; set; }
        public List<Servico> ListarServicosPorCategoria (string codigoCategoria, string paginaAtual)
        {
            Conectar();
            try 
            {
                List<Parametro> parametros = new List<Parametro>();
                parametros.Add(new Parametro("vCdCategoriaServico",codigoCategoria));
                parametros.Add(new Parametro("vPaginaAtual", paginaAtual));
                MySqlDataReader dados = Consultar("ListarServicosDaCategoria", parametros);
                while (dados.Read())
                {
                    Servico servico = new Servico();
                    Imagem imagem = new Imagem();
                    servico.Codigo = dados.GetInt32(0);
                    servico.Nome = dados.GetString(1);
                    servico.Valor = dados.GetDouble(2);
                    servico.Duracao = dados.GetString(3);
                    imagem.Nome = dados.GetString(4);
                    imagem.Pasta = dados.GetString(5);
                    servico.Imagem = new List<Imagem>();
                    servico.Imagem.Add(imagem);
                    PaginaTotal = dados.GetInt32(6);
                    servicos.Add(servico);
                }
                if (!dados.IsClosed) { dados.Close(); }
            }
            catch 
            {
                throw new Exception("Não foi possível acessar os serviços dessa categoria.");
            }
            finally
            {
                Desconectar();
            }
            return servicos;
        }
    }
}