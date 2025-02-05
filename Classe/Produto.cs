using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjTCC.Classe
{
    public class Produto
    {
        #region Dados de Produto
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Quantidade { get; set; }
        public string Descricao { get; set; }

        public String TipoProduto { get; set; }
        #region Uso em confirmaAgendamento
        public bool UtilizadoCompletamente { get; set; }
        #endregion
        #endregion
        public Produto() { }

        #region Construtores
        public Produto(string codigo, string nome, string quantidade, string descricao, string tipoProduto)
        {
            this.Codigo = codigo;
            this.Nome = nome;
            this.Quantidade = quantidade;
            this.Descricao = descricao;
            this.TipoProduto = tipoProduto;
        }
        #endregion

    }
}