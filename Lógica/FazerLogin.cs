using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using prjTCC.Classe;
using MySql.Data.MySqlClient;

namespace prjTCC.Lógica
{
    public class FazerLogin : Banco
    {
        public string[] Logar (string email, string senha)
        {
            string loginUsuario = "";
            string nomeUsuario = "";
            string tipoUsuario = "";
            try
            {
                Conectar();
                List<Parametro> parametros = new List<Parametro> ();
                parametros.Add(new Parametro("vEmail", email));
                parametros.Add(new Parametro("vSenha", senha));
                MySqlDataReader dados = Consultar("LogarUsuario", parametros);

                if (dados.Read())
                {
                    loginUsuario = dados.GetString(0);
                    nomeUsuario = dados.GetString(1);
                    tipoUsuario = dados.GetInt32(2).ToString();
                    /*if (nomeUsuario == "Usuário não encontrado")
                    {
                        
                    }
                    else
                    {
                            
                    }*/
                }
                if (!dados.IsClosed) { dados.Close(); }
            }
            catch
            {
                loginUsuario = "Usuário não encontrado";
            }
            finally
            {
                Desconectar();
            }
            return new string[] {loginUsuario, nomeUsuario, tipoUsuario};
        }
    }
}