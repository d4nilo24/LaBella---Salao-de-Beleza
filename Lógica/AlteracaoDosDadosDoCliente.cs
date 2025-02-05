using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using prjTCC.Classe;

namespace prjTCC.Lógica
{
    public class AlteracaoDosDadosDoCliente : Banco 
    {
        public bool Alterar(string nome, string email)
        {
            try
            {
                Conectar();
                List<Parametro> parametros = new List<Parametro>();
                parametros.Add(new Parametro("vNovoNomeCliente", nome));
                parametros.Add(new Parametro("vEmailCliente", email));
                Executar("alterarDadosDoCliente", parametros);
            }
            catch(Exception)
            {
                return false;
            }
            finally
            {
               Desconectar();
            }

            return true;
        }

        public string AlterarSenhaComVerificacao(string senhaAn, string senhaNova, string email)
        {
            try
            {
                Conectar();
                List<Parametro> parametros = new List<Parametro>();
                parametros.Add(new Parametro("vSenhaAntiga", senhaAn));
                parametros.Add(new Parametro("vSenhaNova", senhaNova));
                parametros.Add(new Parametro("vEmailCliente", email));
                Executar("alterarSenhaDoCliente", parametros);
            }
            catch (Exception)
            {
                return "Alteração de senha incorreta";
            }
            finally
            {
                Desconectar();
            }

            return "Alteração de senha bem sucedida";
        }

        public string AlterarSenha(string token, string senhaNova)
        {
            try
            {
                Conectar();
                List<Parametro> parametros = new List<Parametro>();
                parametros.Add(new Parametro("vToken", token));
                parametros.Add(new Parametro("vSenhaNova", senhaNova));
                Executar("AlterarSenha", parametros);
            }
            catch (Exception)
            {
                return "Alteração de senha incorreta";
            }
            finally
            {
                Desconectar();
            }

            return "Alteração de senha bem sucedida";
        }
    }
}
