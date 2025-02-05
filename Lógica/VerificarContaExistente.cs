using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using prjTCC.Classe;
using MySql.Data.MySqlClient;

namespace prjTCC.Lógica
{
    public class VerificarContaExistente: Banco
    {
        private Cliente cliente = new Cliente();
        public Cliente VerificarExistencia (string email)
        {
            try
            {
                Conectar();
                List<Parametro> parametro = new List<Parametro>();
                parametro.Add(new Parametro("vEmail", email));
                MySqlDataReader dados = Consultar("VerificarExistenciaCliente", parametro);
                if (dados.Read())
                {
                    Cliente clienteTemp = new Cliente();
                    clienteTemp.Existencia = dados.GetBoolean(0);
                    cliente = clienteTemp;
                }
                if (!dados.IsClosed) { dados.Close(); }
            }
            catch
            {
                throw new Exception("Não foi possível verificar se a conta existe.");
            }
            finally
            {
                Desconectar();
            }
            return cliente;
        }
    }
}