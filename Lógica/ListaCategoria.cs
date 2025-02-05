using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using prjTCC.Classe;
using MySql.Data.MySqlClient;

namespace prjTCC.Lógica
{
    public class ListaCategoria : Banco
    {
        private List<Categoria> categorias = new List<Categoria>();
        public List<Categoria> ListarCategorias (bool filtroTodos)
        {
            Conectar();
            try
            {
                MySqlDataReader dados = Consultar("ListarCategorias");

                if (filtroTodos)
                {
                    Categoria categoriaTodos = new Categoria();
                    categoriaTodos.Codigo = 0;
                    categoriaTodos.Nome = "Todos";
                    categorias.Add(categoriaTodos);
                }

                while (dados.Read())
                {
                    Categoria categoria = new Categoria();
                    Imagem imagem = new Imagem();
                    categoria.Codigo = dados.GetInt32(0);
                    categoria.Nome = dados.GetString(1);
                    imagem.Nome = dados.GetString(2);
                    imagem.Pasta = dados.GetString(3);
                    categoria.Imagem = imagem;
                    categorias.Add(categoria);
                }
                if (!dados.IsClosed) { dados.Close(); }
            }
            catch
            {
                throw new Exception("Não foi possível acessar o banco de dados para listar as categorias.");
            }
            finally
            {
                Desconectar();
            }
            return categorias;
        }
    }
}