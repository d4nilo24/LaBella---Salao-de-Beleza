using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using prjTCC.Classe;
using prjTCC.Lógica;
using MySql.Data.MySqlClient;

namespace prjTCC.Lógica
{
    public class ListarCategoriaCmb : Banco
    {
        public MySqlDataReader ListarCategorias ()
        {
            try
            {
                Conectar();
                MySqlDataReader dados = Consultar("ListarCategoriasNomeECodigo");
                return dados;
            }
            catch
            {
                throw new Exception("Não foi possível listar as categorias");
            }
        }
        public void FecharConexao()
        {
            Desconectar();
        }
    }
}