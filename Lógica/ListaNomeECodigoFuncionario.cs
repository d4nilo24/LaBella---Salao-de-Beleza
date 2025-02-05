using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using prjTCC.Classe;
using MySql.Data.MySqlClient;

namespace prjTCC.Lógica
{
    public class ListaNomeECodigoFuncionario:Banco
    {
        private Funcionario funcionario = new Funcionario();

        public Funcionario listarNomeECodigoFuncionario ()
        {
            try
            {
                Conectar();
                MySqlDataReader dados = Consultar("listarNomeECodigoFuncionario");
                while (dados.Read())
                {
                    Funcionario funcionarioTemp = new Funcionario();
                    funcionarioTemp.Codigo = dados.GetInt32(0);
                    funcionarioTemp.Nome = dados.GetString(1);
                    funcionarioTemp = funcionario;
                }
            }
            catch
            {
                throw new Exception("Não foi possível listar os funcionários.");
            }
            finally
            {
                Desconectar();
            }
            return funcionario;
        }

        public List<KeyValuePair<int, string>> listarNomeECodigoFuncionarioValuePair()
        {
            List<KeyValuePair<int, string>> funcionarios = new List<KeyValuePair<int, string>>();

            try
            {
                Conectar();
                MySqlDataReader dados = Consultar("listarNomeECodigoFuncionario");

                while (dados.Read())
                {
                    int codigo = dados.GetInt32(0); // Suponha que o código esteja na coluna 0
                    string nome = dados.GetString(1); // Suponha que o nome esteja na coluna 1
                    funcionarios.Add(new KeyValuePair<int, string>(codigo, nome));
                }
            }
            catch
            {
                throw new Exception("Não foi possível listar os funcionários.");
            }
            finally
            {
                Desconectar();
            }

            return funcionarios;
        }
    }
}