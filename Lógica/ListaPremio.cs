using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using prjTCC.Classe;
using prjTCC.Lógica;
using MySql.Data.MySqlClient;

namespace prjTCC.Lógica
{
    public class ListaPremio:Banco
    {
        private List<Premio> premios = new List<Premio>();
        public List<Premio> ListarProdutos (string filtro, string emailCliente)
        {
            try
            {
                Conectar();
                List<Parametro> parametros = new List<Parametro>();
                parametros.Add(new Parametro("vFiltro", filtro));
                parametros.Add(new Parametro("vLogin", emailCliente));
                MySqlDataReader dados = Consultar("ListarPremiosPorFiltro", parametros); 
                while (dados.Read())
                {
                    Premio premio = new Premio();
                    premio.Imagem = new Imagem();
                    //premio.Temporada = new Temporada();
                    premio.Codigo = dados.GetInt32(0);
                    premio.Nome = dados.GetString(1);
                    premio.Pontos = dados.GetInt32(2);
                    //premio.DataFinalTemporada = dados.GetString(3);
                    //premio.Temporada.Codigo = dados.GetInt32(4);
                    premio.Descricao = dados.GetString(3);
                    premio.Imagem.Pasta = dados.GetString(4);
                    premio.Imagem.Nome = dados.GetString(5);
                    if (!dados.IsDBNull(6))
                    premio.Resgatavel = dados.GetBoolean(6);
                    premio.CondicaoPremio = dados.GetString(7);
                    premios.Add(premio);
                }
                if (!dados.IsClosed) { dados.Close(); }
            }
            catch
            {
                throw new Exception("Não foi possível listar os prêmios.");
            }
            finally
            {
                Desconectar();
            }
            return premios;
        }
    }
}