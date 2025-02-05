using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using prjTCC.Classe;
using MySql.Data.MySqlClient;

namespace prjTCC.Lógica
{
    public class DadosMinimosServicoEspecifico : Banco
    {
        public Servico DadosMinimosServico (string codigoServico)
        {
            Conectar();
            Servico servico = new Servico();
            try
            {
                List<Parametro> parametro = new List<Parametro>();
                parametro.Add(new Parametro("vCodigoServico", codigoServico));
                MySqlDataReader dados = Consultar("DadosMinimosDoServicoSelecionado", parametro);
                while (dados.Read())
                {
                    Imagem imagem = new Imagem();
                    servico.Funcionario = new List<Funcionario>();
                    servico.Imagem = new List<Imagem>();
                    servico.Codigo = dados.GetInt32(0);
                    servico.Nome = dados.GetString(1);
                    servico.Valor = dados.GetDouble(2);
                    servico.Duracao = dados.GetString(3);
                    servico.Descricao = dados.GetString(4);
                    imagem.Nome = dados.GetString(5);
                    imagem.Pasta = dados.GetString(6);
                    servico.Imagem.Add(imagem);

                    if (!dados.IsDBNull(8))
                    {
                        string[] nomeFuncionario = dados.GetString(7).Split(',');
                        string[] codigoFuncionario = dados.GetString(8).Split(',');
                        for (int i = 0; i < nomeFuncionario.Length; i++)
                        {
                            Funcionario funcionario = new Funcionario();
                            funcionario.Nome = nomeFuncionario[i];
                            funcionario.Codigo = int.Parse(codigoFuncionario[i]);
                            servico.Funcionario.Add(funcionario);
                        }
                    }
                }
                if (!dados.IsClosed) { dados.Close(); }
            }
            catch
            {
                throw new Exception("Não foi possível listar os dados mínimos do serviço específico.");
            }
            finally
            {
                Desconectar();
            }
            return servico;
        }
        
    }
}