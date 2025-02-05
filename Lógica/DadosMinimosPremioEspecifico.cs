using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using prjTCC.Classe;
using MySql.Data.MySqlClient;

namespace prjTCC.Classe
{
    public class DadosMinimosPremioEspecifico : Banco
    {
        private Premio premio = new Premio();
        public Premio DadosMinimosPremio (string codigoPremio)
        {
            try
            {
                Conectar();
                List<Parametro> parametro = new List<Parametro>();
                parametro.Add(new Parametro("vCodigoPremio", codigoPremio));
                MySqlDataReader dados = Consultar("DadosMinimosPremioEspecifico",parametro);

                if (dados.Read())
                {
                    Premio recompensa = new Premio();
                    recompensa.TipoPremio = new TipoPremio();
                    //recompensa.Temporada = new Temporada();
                    recompensa.Imagem = new Imagem();
                    recompensa.Codigo = dados.GetInt32(0);
                    recompensa.Nome = dados.GetString(1);
                    recompensa.Pontos = dados.GetInt32(2);
                    //recompensa.DataFinalTemporada = dados.GetString(3);
                    //recompensa.Temporada.Codigo = dados.GetInt32(4);
                    recompensa.Descricao = dados.GetString(3);
                    recompensa.Imagem.Pasta = dados.GetString(4);
                    recompensa.Imagem.Nome = dados.GetString(5);
                    recompensa.TipoPremio.Codigo = dados.GetInt32(6);
                    recompensa.TipoPremio.Nome = dados.GetString (7);
                    if (recompensa.TipoPremio.Codigo == 1)
                    {
                        recompensa.Servico = new Servico();
                        recompensa.Categoria = new Categoria();
                        if (!dados.IsDBNull(8))
                        {
                            recompensa.Servico.Nome = dados.GetString(8);
                        }
                        if (!dados.IsDBNull(9))
                        {
                            recompensa.Categoria.Nome = dados.GetString(9);
                        }
                    }
                    premio = recompensa;
                }
                if (!dados.IsClosed) { dados.Close(); }
            }
            catch
            {
                throw new Exception("Não foi possível mostrar o prêmio específico.");
            }
            finally
            {
                Desconectar();
            }
            return premio;
        }
    }
}