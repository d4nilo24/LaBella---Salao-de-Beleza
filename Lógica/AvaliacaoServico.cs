using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using prjTCC.Classe;

namespace prjTCC.Lógica
{
    public class AvaliacaoServico : Banco
    {
        public void avaliarServico(string codigoAgendamento, string emailCliente, string qtdEstrelas, string Descricao)
        {
            Conectar();

            try
            {
                List<Parametro> parametros = new List<Parametro>();

                parametros.Add(new Parametro("pCodAgendamento", codigoAgendamento));
                parametros.Add(new Parametro("pEmailCliente", emailCliente));
                parametros.Add(new Parametro("pQtdEstrelas", qtdEstrelas));
                parametros.Add(new Parametro("pDescricao", Descricao));

                Executar("AvaliarServico", parametros);
            }

            /*catch (Exception)
            {

                throw new Exception("Algo deu errado ao adicionar a avaliação. Tente novamente.");
            }*/

            finally 
            { 
                Desconectar(); 
            }
        }
    }
}