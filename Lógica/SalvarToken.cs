using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using prjTCC.Classe;
using MySql.Data.MySqlClient;

namespace prjTCC.Lógica
{
    public class SalvarToken : Banco
    {
        public void Salvar(string codigoToken, string emailCliente)
        {
            try
            {
                Conectar();
                List<Parametro> parametros = new List<Parametro>();
                parametros.Add(new Parametro("vToken", codigoToken));
                parametros.Add(new Parametro("vEmail", emailCliente));
                Executar("SalvarToken", parametros);
            }
            catch
            {
                throw new Exception("Não foi possível verificar se a conta existe.");
            }
            finally
            {
                Desconectar();
            }
        }
    }
}