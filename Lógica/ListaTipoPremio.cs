using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using prjTCC.Classe;
using prjTCC.Lógica;
using MySql.Data.MySqlClient;

namespace prjTCC
{
    public class ListaTipoPremio : Banco
    {
        private List<TipoPremio> tiposPremio = new List<TipoPremio>();
        public List<TipoPremio> ListarTipoPremio (bool filtroTodos)
        {
            try
            {
                Conectar();
                MySqlDataReader dados = Consultar("ListarTipoPremio");

                if (filtroTodos)
                {
                    TipoPremio tipoPremioTodos = new TipoPremio();
                    tipoPremioTodos.Codigo = 0;
                    tipoPremioTodos.Nome = "Todos";
                    tiposPremio.Add(tipoPremioTodos);
                }

                while (dados.Read())
                {
                    TipoPremio tipoPremio = new TipoPremio();
                    tipoPremio.Codigo = dados.GetInt32(0);
                    tipoPremio.Nome = dados.GetString(1);
                    tiposPremio.Add(tipoPremio);
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
            return tiposPremio;
        }
    }
}