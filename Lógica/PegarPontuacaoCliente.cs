using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using prjTCC.Classe;
using MySql.Data.MySqlClient;

namespace prjTCC.Lógica
{
    public class PegarPontuacaoCliente : Banco
    {
        private int pontuacaoCliente = 0;
        public int PontuacaoCliente (string emailCliente)
        {
            try
            {
                Conectar();
                List<Parametro> parametro = new List<Parametro>();
                parametro.Add(new Parametro("vLogin", emailCliente));
                MySqlDataReader dados = Consultar("PegarPontuacaoCliente", parametro);
                if (dados.Read())
                {
                    pontuacaoCliente = dados.GetInt32(0);
                }
                if (!dados.IsClosed) { dados.Close(); }
            }
            catch
            {

            }
            finally
            {
                Desconectar();
            }
            return pontuacaoCliente;
        }
    }
}