using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using prjTCC.Classe;

namespace prjTCC.Lógica
{
    public class adicionarProduto: Banco
    {
        public string AdicionarProduto(string nome, string quantidade, string descricao, string codigotipo)
        {
            try
            {
                Conectar();
                List<Parametro> parametros = new List<Parametro>();
                parametros.Add(new Parametro("vNome", nome));
                parametros.Add(new Parametro("vQuantidade", quantidade));
                parametros.Add(new Parametro("vDescricao", descricao));
                parametros.Add(new Parametro("vCodigoTipoProduto", codigotipo));
                Executar("cadastrarProduto", parametros);
            }
            catch
            {
                throw new Exception ("Erro ao dicionar produto");
            }
            finally
            {
                Desconectar();
            }
            return "Produto Adicionado com sucesso";
        }

    }
}