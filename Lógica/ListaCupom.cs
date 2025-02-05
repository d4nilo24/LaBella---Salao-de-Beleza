using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using prjTCC.Classe;
using MySql.Data.MySqlClient;

namespace prjTCC.Lógica
{
    public class ListaCupom : Banco
    {
        private List<Cupom> cupons = new List<Cupom>();
        public List<Cupom> ListarCupom(string emailCliente, string codigoServico)
        {
            try
            {
                Conectar();
                List<Parametro> parametros = new List<Parametro>();
                parametros.Add(new Parametro("vEmail", emailCliente));
                parametros.Add(new Parametro("vCodServico", codigoServico));
                MySqlDataReader dados = Consultar("listarCuponsDoCliente", parametros);
                while (dados.Read())
                {
                    Cupom cupom = new Cupom();
                    //Código do prêmio
                    cupom.Codigo = dados.GetInt32(0);
                    cupom.Valor = dados.GetInt32(1);
                    cupons.Add(cupom);
                }
                if (!dados.IsClosed) { dados.Close(); }
            }
            catch
            {
                throw new Exception("Não foi possível listar os cupons do cliente.");
            }
            finally
            {
                Desconectar();
            }
            return cupons;
        }
    }
}