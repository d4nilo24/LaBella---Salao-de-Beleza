using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using prjTCC.Classe;

namespace prjTCC.Lógica
{
    public class ListarDias : Banco
    {
        private List<DiaDeTrabalho> diaDeTrabalhos = new List<DiaDeTrabalho>();
        public List<DiaDeTrabalho> ListarDiasDeTrabalho()
        {
            try
            {
                Conectar();
                MySqlDataReader dados = Consultar("ListarDias");
                while (dados.Read())
                {
                    DiaDeTrabalho dias = new DiaDeTrabalho();
                    dias.Codigo = dados.GetInt32(0);
                }
                if (!dados.IsClosed) { dados.Close(); }
            }
            catch
            {
                throw new Exception("Não foi possível acessar o banco de dados para listar os Dias. Tente novamente.");
            }
            finally
            {
                Desconectar();
            }
            return diaDeTrabalhos;
        }

    }
}