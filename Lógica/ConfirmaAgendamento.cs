using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using prjTCC.Classe;
using MySql.Data.MySqlClient;

namespace prjTCC.Lógica
{
    public class ConfirmaAgendamento:Banco
    {
        public void ConfirmarAgendamento (string codigoAgendamento,bool presencaFuncionario, bool presencaCliente)
        {
            try
            {
                Conectar();
                List<Parametro> parametros = new List<Parametro>();
                parametros.Add(new Parametro("vCodAgendamento", codigoAgendamento));
                parametros.Add(new Parametro("vPresencaFuncionario", presencaFuncionario ? "1":"0"));
                parametros.Add(new Parametro("vPresencaCliente", presencaCliente ? "1" : "0"));
                Executar("ConfirmarAgendamento", parametros);
            }
            catch
            {
                throw new Exception("Não foi possível confirmar o agendamento.");
            }
            finally
            {
                Desconectar();
            }
        }

        public string TipoProduto (string produto)
        {
            string tipoProduto = "1";
            try
            {
                Conectar();
                List<Parametro> parametros = new List<Parametro>();
                parametros.Add(new Parametro("vCodProduto", produto));
                MySqlDataReader dados = Consultar("ConfirmarTipoProduto", parametros);
                if (dados.Read())
                {
                    tipoProduto = dados.GetString(0);
                }
            }
            catch
            {
                throw new Exception("Não foi possível confirmar o tipo de produto.");
            }
            finally
            {
                Desconectar();
            }
            return tipoProduto;
        }
        public void CriarProdutoAgendamento(List<Produto> produtos, string codigoAgendamento)
        {
            try
            {
                Conectar();
                List<Parametro> parametros = new List<Parametro>();
                for (int i = 0; i < produtos.Count; i ++)
                {
                    parametros.Clear();
                    parametros.Add(new Parametro("vCodProduto", produtos[i].Codigo));
                    parametros.Add(new Parametro("vCodAgendamento", codigoAgendamento));                    
                    parametros.Add(new Parametro("vQtProduto", produtos[i].Quantidade));
                    Executar("VerificarProdutoAgendamento", parametros);
                }

                for (int i = 0; i < produtos.Count; i++)
                {
                    parametros.Clear();
                    parametros.Add(new Parametro("vCodProduto", produtos[i].Codigo));
                    parametros.Add(new Parametro("vCodAgendamento", codigoAgendamento));
                    parametros.Add(new Parametro("vQtProduto", produtos[i].Quantidade));
                    Executar("AdicionarProdutoAgendamento", parametros);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Desconectar();
            }
        }
    }
}