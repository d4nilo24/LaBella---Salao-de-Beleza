using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using prjTCC.Classe;
using MySql.Data.MySqlClient;

namespace prjTCC.Lógica
{
    public class VerificarExistenciaToken:Banco
    {
        private bool existencia = false;
        public bool VerificarExistencia(string token)
        {
            try
            {
                Conectar();
                List<Parametro> parametro = new List<Parametro>();
                parametro.Add(new Parametro("vToken", token));
                MySqlDataReader dados = Consultar("VerificarToken", parametro);
                if (dados.Read())
                {
                    existencia = dados.GetBoolean(0);
                }
                if (!dados.IsClosed) { dados.Close(); }
            }
            catch
            {
                throw new Exception("Não foi possível verificar se o token existe.");
            }
            finally
            {
                Desconectar();
            }
            return existencia;
        }
    }
}