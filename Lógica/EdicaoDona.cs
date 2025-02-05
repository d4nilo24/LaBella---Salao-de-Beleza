using MySql.Data.MySqlClient;
using prjTCC.Classe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjTCC.Lógica
{
    public class EdicaoDona : Banco
    {
        private Servico servico = new Servico();

        public Servico MostrarDadosServico(string codServico)
        {
            try
            {
                Conectar();

                string procedure = "MostrarDadosServicoEspecifico";

                List<Parametro> parametros = new List<Parametro>();

                parametros.Add(new Parametro("pCodServico", codServico));

                MySqlDataReader dados = Consultar(procedure, parametros);

                if (dados.Read())
                {
                    servico.Imagem = new List<Imagem>();
                    servico.Codigo = dados.GetInt32(0);
                    servico.Nome = dados.GetString(1);
                    servico.Valor = dados.GetDouble(4);
                    servico.Duracao = dados.GetString(5);
                    servico.Descricao = dados.GetString(6);

                    servico.Categoria = new Categoria();
                    servico.Categoria.Codigo = dados.GetInt32(2);
                    servico.Categoria.Nome = dados.GetString(3);

                    servico.Pontos = dados.GetInt32(7);

                    if (!dados.IsDBNull(9))
                    {
                        string[] pastaImagem = dados.GetString(8).Split(',');
                        string[] nomeImagem = dados.GetString(9).Split(',');

                        for (int i = 0; i < nomeImagem.Length; i++)
                        {
                            Imagem imagem = new Imagem();
                            imagem.Pasta = pastaImagem[i];
                            imagem.Nome = nomeImagem[i];
                            servico.Imagem.Add(imagem);
                        }
                    }
                }
                if (!dados.IsClosed) { dados.Close(); }
            }
            catch
            {
                throw new Exception("Algo deu errado ao mostrar os dados do serviço específico.");
            }
            finally
            {
                Desconectar();
            }

            return servico;
        }

        public Funcionario mostrarDadosFuncionario(string codFuncionario)
        {
            Funcionario funcionario = new Funcionario();
            
            try
            {
                Conectar();

                string procedure = "MostrarDadosFuncionarioEspecifico";

                List<Parametro> parametros = new List<Parametro>();
                parametros.Add(new Parametro("pCodFuncionario", codFuncionario));

                MySqlDataReader dados = Consultar(procedure, parametros);

                if (dados.Read())
                {
                    funcionario.TipoFuncionario = new TipoFuncionario();
                    funcionario.Imagem = new Imagem();

                    funcionario.Codigo = dados.GetInt32(0);
                    funcionario.Nome = dados.GetString(1);
                    funcionario.Email = dados.GetString(2);

                    funcionario.TipoFuncionario.Codigo = dados.GetInt32(3);

                    if (!dados.IsDBNull(4) || !dados.IsDBNull(5)) 
                    {
                        funcionario.Imagem.Pasta = dados.GetString(4);
                        funcionario.Imagem.Nome = dados.GetString(5);
                    }
                }
                if (!dados.IsClosed) { dados.Close(); }
            }
            catch (Exception)
            {
                throw new Exception("Algo deu errado ao mostrar os dados do funcionário específico.");
            }
            finally
            {
                Desconectar();
            }
            return funcionario;
        }
        public Produto mostrarDadosProduto(string CodProduto)
        {
            Produto produto = new Produto();

            try
            {
                Conectar();

                string procedure = "MostrarDadosProdutoEspecifico";

                List<Parametro> parametros = new List<Parametro>();
                parametros.Add(new Parametro("pCodProduto", CodProduto));

                MySqlDataReader dados = Consultar(procedure, parametros);

                if (dados.Read())
                {

                    //produto.TipoProduto = new TipoProduto();
                    produto.Codigo = dados.IsDBNull(0) ? null : dados.GetString(0);
                    produto.Nome = dados.IsDBNull(1) ? null : dados.GetString(1);
                    produto.Quantidade = dados.IsDBNull(2) ? null : dados.GetString(2);
                    produto.Descricao = dados.IsDBNull(3) ? "" : dados.GetString(3);
                    produto.TipoProduto = dados.GetString(4);
                }

                return produto;
            }

            catch (Exception)
            {
                throw new Exception("Algo deu errado ao mostrar os dados do produto específico.");
            }
            finally
            {
                Desconectar();
            }
        }
        public MySqlDataReader listarServicosFuncionario(string CodFuncionnario)
        {
            try
            {
                Conectar();

                string procedure = "ListarServicosFuncionarios";

                List<Parametro> parametros = new List<Parametro>();

                parametros.Add(new Parametro("pCodFuncionario", CodFuncionnario));

                MySqlDataReader dados = Consultar(procedure, parametros);

                return dados;
            }

            catch (Exception)
            {
                throw new Exception("Não foi possível retornar serviços do Funcionário Selecionado");
            }
        }

        public MySqlDataReader listarTipoFuncionarioEEspecifico(string CodFuncionario)
        {
            try
            {
                Conectar();

                string procedure = "ListarTiposFuncionarioETipoEspecifico";

                List<Parametro> parametros= new List<Parametro>();

                parametros.Add((Parametro)new Parametro("pCodFuncionario", CodFuncionario));

                MySqlDataReader dados = Consultar(procedure, parametros);
                return dados;
            }

            catch (Exception)
            {
                throw new Exception("Não foi possível retornar o tipo do funcionário");
            }
        }
        public MySqlDataReader listarTipoFuncionario()
        {
            try
            {
                Conectar();

                string procedure = "ListarTipoFuncionario";

                List<Parametro> parametros = new List<Parametro>();

                MySqlDataReader dados = Consultar(procedure);
                return dados;
            }

            catch (Exception)
            {

                throw new Exception("Não foi possível retornar o tipo do funcionário");
            }
        }

        public bool editarDadosServico(string CodServico, string NomeServico, string DescricaoServico, double ValorServico, string DuracaoServico, string CodigoCategoria, string PontosServico)
        {
            try
            {
                Conectar();

                string procedure = "EditarDadosServico";

                List<Parametro> parametros = new List<Parametro>();

                parametros.Add((Parametro)new Parametro("pCodServico", CodServico));
                parametros.Add((Parametro)new Parametro("pNomeServico", NomeServico));
                parametros.Add((Parametro)new Parametro("pDescricao", DescricaoServico));
                parametros.Add((Parametro)new Parametro("pValorServico", ValorServico.ToString()));
                parametros.Add((Parametro)new Parametro("pDuracaoServico", DuracaoServico));
                parametros.Add((Parametro)new Parametro("pCodCategoria", CodigoCategoria));
                parametros.Add((Parametro)new Parametro("pPontosServico", PontosServico));

                Executar(procedure, parametros);   
            }
            catch (Exception)
            {
                throw new Exception("Não foi possível atualizar os dados do serviço.");
            }
            finally
            {
                Desconectar();
            }
            return true;
        }

        public bool editarDadosFuncionarios(string CodFuncionario, string NomeFuncionario, string EmailFuncionario, string TipoFuncionario)
        {
            try
            {
                Conectar();

                string procedure = "editarDadosFuncionario";

                List<Parametro> parametros = new List<Parametro>();

                parametros.Add((Parametro)new Parametro("pCodFuncionario", CodFuncionario));
                parametros.Add((Parametro)new Parametro("pNomeFuncionario", NomeFuncionario));
                parametros.Add((Parametro)new Parametro("pEmailFuncionario", EmailFuncionario));
                parametros.Add((Parametro)new Parametro("pCodTipoFuncionario", TipoFuncionario));

                Executar(procedure, parametros);

            }
            catch (Exception)
            {
                throw new Exception("Não foi possível atualizar os dados do funcionário.");
            }
            finally
            {
                Desconectar();
            }

            return true;
        }
        public bool editarDadosProdutos(string CodProduto, string NomeProduto, string QuantidadeProduto, string DescricaoProduto, string CodigoTipoProduto)
        {
            try
            {
                Conectar();

                string procedure = "editarDadosProduto";

                List<Parametro> parametros = new List<Parametro>();

                parametros.Add((Parametro)new Parametro("pCodProduto", CodProduto));
                parametros.Add((Parametro)new Parametro("pNomeProduto", NomeProduto));
                parametros.Add((Parametro)new Parametro("pQuantidadeProduto", QuantidadeProduto));
                parametros.Add((Parametro)new Parametro("pDescricaoProduto", DescricaoProduto));
                parametros.Add((Parametro)new Parametro("pCodigoTipoProduto", CodigoTipoProduto));

                Executar(procedure, parametros);

                Desconectar();

                return true;
            }

            catch (Exception)
            {
                throw new Exception("Não foi possível atualizar os dados do produto.");
            }
        }
        public List<FuncionarioServicoDiaDeTrabalho> mostrarHorariosFuncionario(string codigoDiaTrabalho, string codigoFuncionario, string codigoServico)
        {
            List<FuncionarioServicoDiaDeTrabalho> funcionarioServicoDiaDeTrabalho = new List<FuncionarioServicoDiaDeTrabalho>();
            try
            {
                Conectar();
                List<Parametro> parametros = new List<Parametro>();
                parametros.Add(new Parametro("pCodDiaTrabalho", codigoDiaTrabalho));
                parametros.Add(new Parametro("pCodFuncionario", codigoFuncionario));
                parametros.Add(new Parametro("pCodServico", codigoServico));
                MySqlDataReader dados = Consultar("ListarFuncionarioServicoDiaDeTrabalho", parametros);
                while (dados.Read())
                {
                    FuncionarioServicoDiaDeTrabalho funcionarioServicoDiaDeTrabalhoTemp = new FuncionarioServicoDiaDeTrabalho();
                    if (!dados.IsDBNull(0))
                    {
                        funcionarioServicoDiaDeTrabalhoTemp.Hora = dados.GetString(0);
                    }
                    funcionarioServicoDiaDeTrabalho.Add(funcionarioServicoDiaDeTrabalhoTemp);
                }
                if (!dados.IsClosed) { dados.Close(); }
            }
            catch
            {
                throw new Exception("Não foi possível listar os horários.");
            }
            finally
            {
                Desconectar();
            }
            return funcionarioServicoDiaDeTrabalho;
        }
        public void excluirHorario(string codigoFuncionario, string codigoServico, string hora, string codigoDiaTrabalho)
        {
            try
            {
                Conectar();
                List<Parametro> parametros = new List<Parametro>();

                parametros.Add(new Parametro("pCodFuncionario", codigoFuncionario));
                parametros.Add(new Parametro("pCodServico", codigoServico));
                parametros.Add(new Parametro("pHora", hora));
                parametros.Add(new Parametro("pCodDiaTrabalho", codigoDiaTrabalho));
                Executar("excluirFuncionarioServicoDiaDeTrabalho", parametros);
            }
            catch
            {
                throw new Exception("Não foi possível excluir o horário.");
            }
            finally
            {
                Desconectar();
            }
        }
        public void adicionarHorario(string codigoFuncionario, string codigoServico, string hora, string codigoDiaTrabalho)
        {
            try
            {
                Conectar();
                List<Parametro> parametros = new List<Parametro>();
                parametros.Add(new Parametro("pCodFuncionario", codigoFuncionario));
                parametros.Add(new Parametro("pCodServico", codigoServico));
                parametros.Add(new Parametro("pHora", hora));
                parametros.Add(new Parametro("pCodDiaTrabalho", codigoDiaTrabalho));
                Executar("adicionarFuncionarioServicoDiaDeTrabalho", parametros);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                Desconectar();
            }
        }
        public void FecharConexao ()
        {
            Desconectar();
        }

        /*DONA_RECOMPENSA*/
        public Premio mostrarDadosRecompensa(string codPremio)
        {
            Premio recompensa = new Premio();

            try
            {
                Conectar();

                string procedure = "MostrarDadosRecompensaEspecifica";

                List<Parametro> parametros = new List<Parametro>();

                parametros.Add(new Parametro("pCodPremio", codPremio));

                MySqlDataReader dados = Consultar(procedure, parametros);

                if (dados.Read())
                {
                    /*VERIFICAÇÃO PELO TIPO_PRÊMIO*/
                    recompensa.TipoPremio = new TipoPremio();
                    recompensa.TipoPremio.Nome = dados.GetString(1);

                    /*PREENCHIMENTO DE DADOS DE RECOMPENSA*/
                    if (recompensa.TipoPremio.Nome == "Produto")
                    {
                        recompensa.Codigo = dados.GetInt32(0);

                        recompensa.Nome = dados.GetString(2);
                        recompensa.Pontos = dados.GetInt32(3);
                        recompensa.Descricao = dados.GetString(4);

                        if (!dados.IsDBNull(5) && !dados.IsDBNull(6))
                        {
                            recompensa.Imagem = new Imagem();

                            string pastaImagem = dados.GetString(5);
                            string nomeImagem = dados.GetString(6);

                            recompensa.Imagem.Pasta = pastaImagem;
                            recompensa.Imagem.Nome = nomeImagem;
                        }
                    }

                    /*PREENCHIMENTO DE DADOS DE CUPOM*/
                    else
                    {
                        recompensa.Codigo = dados.GetInt32(0);

                        recompensa.Cupom = new Cupom();
                        recompensa.Cupom.Codigo = dados.GetInt32(2);
                        recompensa.Cupom.Valor = dados.GetInt32(3);

                        if (!dados.IsDBNull(4))
                        {
                            recompensa.Servico = new Servico();
                            recompensa.Servico.Codigo = dados.GetInt32(4);
                        }

                        if (!dados.IsDBNull(5))
                        {
                            recompensa.Categoria = new Categoria();
                            recompensa.Categoria.Codigo = dados.GetInt32(5);
                        }
                        recompensa.Nome = dados.GetString(6);
                        recompensa.Pontos = dados.GetInt32(7);
                        recompensa.Descricao = dados.GetString(8);

                        if (!dados.IsDBNull(9) && !dados.IsDBNull(10))
                        {
                            recompensa.Imagem = new Imagem();

                            string pastaImagem = dados.GetString(9);
                            string nomeImagem = dados.GetString(10);

                            recompensa.Imagem.Pasta = pastaImagem;
                            recompensa.Imagem.Nome = nomeImagem;
                        }
                    }
                }
                if (!dados.IsClosed) { dados.Close(); }
            }
            catch (Exception)
            {
                throw new Exception("Não foi possível mostrar os dados da recompensa selecionada.");
            }
            finally
            {
                Desconectar();
            }
            return recompensa;
        }

        public bool editarDadosProdutoPremio(string codPremio, string nomePremio, string qtPontosNecessarios, string descricaoPremioProduto)
        {
            try
            {
                Conectar();

                string procedure = "editarDadosRecompensaProdutoEspecifico";

                List<Parametro> parametros = new List<Parametro>();

                parametros.Add(new Parametro("pCodPremio", codPremio));
                parametros.Add(new Parametro("vNomeRecompensa", nomePremio));
                parametros.Add(new Parametro("vQtPontosNecessarios", qtPontosNecessarios));
                parametros.Add(new Parametro("vDescricao", descricaoPremioProduto));


                Executar(procedure, parametros);
                
            }
            catch (Exception)
            {
                throw new Exception("Houve um erro ao tentar atualizar os dados do Prêmio");
            }
            finally
            {
                Desconectar();
            }
            return true;
        }

        public bool editarDadosCupomDescontoPremio(string codPremio, string nomePremio, string servicoAtrelado, string categoriaAtrelada,
            string porcentagemDesconto, string qtPontos, string descricao)
        {
            try
            {
                Conectar();

                string procedure = "editarDadosRecompensaCupomDescontoEspecifico";

                List<Parametro> parametros = new List<Parametro>();

                parametros.Add(new Parametro("pCodPremio", codPremio));
                parametros.Add(new Parametro("vNomeRecompensa", nomePremio));
                parametros.Add(new Parametro("vServicoAtrelado", servicoAtrelado));
                parametros.Add(new Parametro("vCategoriaAtrelada", categoriaAtrelada));
                parametros.Add(new Parametro("vPorcentagemDesconto", porcentagemDesconto));
                parametros.Add(new Parametro("vQtPontosNecessarios", qtPontos));
                parametros.Add(new Parametro("vDescricao", descricao));

                Executar(procedure, parametros);
            }
            catch
            {
                throw new Exception("Não foi possível editar os dados de cupom.");
            }
            finally
            {
                Desconectar();
            }
            return true;
        }

        public Servico excluirServico(string codServico)
        {
            Servico servicoTemp = new Servico();
            
            try
            {
                Conectar();

                string procedure = "excluirServico";

                List<Parametro> parametros = new List<Parametro>();

                parametros.Add(new Parametro("pCodServico", codServico));

                MySqlDataReader dados = Consultar(procedure, parametros);

                servicoTemp.Imagem = new List<Imagem>();
                while (dados.Read())
                {
                    if (!dados.IsDBNull(0) && !dados.IsDBNull(1))
                    {
                        Imagem imagem = new Imagem();
                        imagem.Pasta = dados.GetString(0);
                        imagem.Nome = dados.GetString(1);
                        servicoTemp.Imagem.Add(imagem);
                    }
                }
                if (!dados.IsClosed) { dados.Close(); }
            }
            catch
            {
                throw new Exception("Não foi possível excluir o serviço.");
            }
            finally
            {
                Desconectar();
            }
            return servicoTemp;
        }

        public Funcionario excluirFuncionario(string codFuncionario)
        {
            Funcionario funcionarioTemp = new Funcionario();

            try
            {
                Conectar();

                string procedure = "excluirFuncionario";

                List<Parametro> parametros = new List<Parametro>();

                parametros.Add(new Parametro("pCodFuncionario", codFuncionario));

                MySqlDataReader dados = Consultar(procedure, parametros);

                funcionarioTemp.Imagem = new Imagem();
                if (dados.Read())
                {
                    if (!dados.IsDBNull(0) && !dados.IsDBNull(1))
                    {
                        Imagem imagem = new Imagem();
                        imagem.Pasta = dados.GetString(0);
                        imagem.Nome = dados.GetString(1);
                        funcionarioTemp.Imagem = imagem;
                    }
                }
                if (!dados.IsClosed) { dados.Close(); }
            }
            catch
            {
                throw new Exception("Não foi possível excluir o serviço.");
            }
            finally
            {
                Desconectar();
            }
            return funcionarioTemp;
        }

        public Premio excluirRecompensa(string codPremio)
        {
            Premio premioTemp = new Premio();

            try
            {
                Conectar();

                string procedure = "excluirRecompensa";

                List<Parametro> parametros = new List<Parametro>();

                parametros.Add(new Parametro("pCodPremio", codPremio));

                MySqlDataReader dados = Consultar(procedure, parametros);

                premioTemp.Imagem = new Imagem();
                while (dados.Read())
                {
                    if (!dados.IsDBNull(0) && !dados.IsDBNull(1))
                    {
                        Imagem imagem = new Imagem();
                        imagem.Pasta = dados.GetString(0);
                        imagem.Nome = dados.GetString(1);
                        premioTemp.Imagem = imagem;
                    }
                }
                if (!dados.IsClosed) { dados.Close(); }
            }
            catch
            {
                throw new Exception("Não foi possível excluir a recompensa.");
            }
            finally
            {
                Desconectar();
            }
            return premioTemp;
        }


        public void excluirProduto(string codProduto)
        {
            try
            {
                Conectar();

                string procedure = "excluirProduto";

                List<Parametro> parametros = new List<Parametro>();

                parametros.Add(new Parametro("pCodProduto", codProduto));

                Executar(procedure, parametros);   
            }
            catch
            {
                throw new Exception("Não foi possível excluir o produto.");
            }
            finally
            {
                Desconectar();
            }
        }
    }
}