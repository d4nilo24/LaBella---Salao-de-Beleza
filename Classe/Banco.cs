using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace prjTCC.Classe
{
    public abstract class Banco
    {
        MySqlConnection conexao = null;
        MySqlCommand cSQL = null;
        string linhaConexao = "";

        public Banco()
        {
            linhaConexao = Conexao.getConexao();
        }

        protected void Conectar()
        {
            conexao = new MySqlConnection(linhaConexao);
            try
            {
                conexao.Open();
            }
            catch (Exception)
            {
                throw new Exception("Não foi possível conectar ao Servidor.");
            }
        }

        protected void Desconectar()
        {
            try
            {
                if (conexao != null)
                    if (conexao.State == System.Data.ConnectionState.Open)
                        conexao.Close();
            }
            catch
            {
                throw new Exception("Não foi possível fechar a conexão");
            }
        }

        protected MySqlDataReader Consultar(string comando, List<Parametro> parametros)
        {
            Conectar();
            try
            {
                cSQL = new MySqlCommand(comando, conexao);
                cSQL.CommandType = System.Data.CommandType.StoredProcedure;
                cSQL.Parameters.Clear();
                if (parametros != null)
                {
                    if (parametros.Count > 0)
                    {
                        for (int i = 0; i < parametros.Count; i++)
                        {
                            //cSQL.Parameters.Add(new MySqlParameter("", ""));
                            cSQL.Parameters.AddWithValue(parametros[i].Nome, parametros[i].Valor);
                        }
                    }
                }
                return cSQL.ExecuteReader();
            }
            catch (Exception)
            {
                throw new Exception("Erro ao realizar consulta");
            }
        }

        protected MySqlDataReader Consultar(string comando)
        {
            Conectar();
            try
            {
                cSQL = new MySqlCommand(comando, conexao);
                return cSQL.ExecuteReader();
            }
            catch (Exception)
            {
                throw new Exception("Não foi possível realizar a consulta");
            }
        }

        protected void Executar(string comando, List<Parametro> parametros)
        {
            Conectar();
            try
            {
                cSQL = new MySqlCommand(comando, conexao);
                cSQL.CommandType = System.Data.CommandType.StoredProcedure;
                cSQL.Parameters.Clear();
                if (parametros != null)
                {
                    if (parametros.Count > 0)
                    {
                        for (int i = 0; i < parametros.Count; i++)
                        {
                            //cSQL.Parameters.Add(new MySqlParameter("", ""));
                            cSQL.Parameters.AddWithValue(parametros[i].Nome, parametros[i].Valor);
                        }
                    }
                }
                cSQL.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1644)  
                {
                    throw new Exception(ex.Message);
                }
                else
                {
                    throw new Exception("Erro ao realizar o comando");
                }
            }
            finally
            {
                Desconectar();
            }
        }
    }
}