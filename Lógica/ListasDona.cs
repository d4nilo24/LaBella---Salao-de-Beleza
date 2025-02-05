using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using prjTCC.Classe;

namespace prjTCC.Lógica
{
    public class ListasDona : Banco
    {
        public void FecharConexao()
        {
            Desconectar();
        }

        public MySqlDataReader listarServicos()
        {
            try
            {
                string procedure = "listarDadosMinimosServicos";

                Conectar();
                MySqlDataReader dados = Consultar(procedure);
             
                return dados;
            }
            catch (Exception)
            {
                throw new Exception("Algo deu errado ao listar os dados mínimos dos serviços");
            }
            
        }

        public MySqlDataReader listarFuncionarios()
        {
            try
            {
                string procedure = "listarDadosMinimosFuncionarios";

                Conectar();

                MySqlDataReader dados = Consultar(procedure);

                if (dados != null)
                {
                    return dados;
                }

                else
                    return null;
            }
            catch
            {
                throw new Exception("Algo deu errado ao listar os dados do funcionários.");
            }
        }

        public MySqlDataReader listarRecompensas()
        {
            try
            {
                string procedure = "listarDadosMinimosRecompensas";

                Conectar();

                MySqlDataReader dados = Consultar(procedure);

                if (dados != null)
                {
                    return dados;
                }

                else
                    return null;
            }
            catch
            {
                throw new Exception("Algo deu errado ao listar os dados das recompensas.");
            }
        }
        private List<Banner> banners = new List<Banner>();
        public List<Banner> listarBanners()
        {
            try
            {
                Conectar();
                MySqlDataReader dados = Consultar("listarBanners", null);
                while (dados.Read())
                {
                    Banner banner = new Banner();
                    banner.ImagemDesktop = new Imagem();
                    banner.ImagemMobile = new Imagem();
                    banner.ImagemDesktop.Pasta = dados.GetString(0);
                    banner.ImagemDesktop.Nome = dados.GetString(1);
                    
                    banner.ImagemMobile.Nome = dados.GetString(2);
                    banner.ImagemMobile.Pasta = dados.GetString(0);
                    if (!dados.IsDBNull(3))
                    {
                        banner.link = dados.GetString(3);
                    }
                    
                    banners.Add(banner);
                }
                if (dados.IsClosed) { dados.Close(); }
            }
            catch
            {
                
            }
            finally
            {
                Desconectar();
            }
            return banners;
        }

        public List<Banner> listarBanners(bool bannerDesktop)
        {
            try
            {
                Conectar();
                MySqlDataReader dados = Consultar("listarBanners", null);
                while (dados.Read())
                {
                    Banner banner = new Banner();
                    banner.Imagem = new Imagem();
                    banner.Imagem.Pasta = dados.GetString(0);
                    if (bannerDesktop)
                    {
                        banner.Imagem.Nome = dados.GetString(1);
                    }
                    else
                    {
                        banner.Imagem.Nome = dados.GetString(2);
                    }

                    if (!dados.IsDBNull(3))
                    {
                        banner.link = dados.GetString(3);
                    }

                    banners.Add(banner);
                }
                if (dados.IsClosed) { dados.Close(); }
            }
            catch
            {

            }
            finally
            {
                Desconectar();
            }
            return banners;
        }
        public MySqlDataReader listarProdutos()
        {
            try
            {
                string procedure = "listarDadosMinimosProdutos";

                Conectar();

                MySqlDataReader dados = Consultar(procedure);

                if (dados != null)
                {
                    return dados;
                }

                else
                    return null;
            }
            catch
            {
                throw new Exception("Algo deu errado ao listar os produtos.");
            }
        }


    }
}