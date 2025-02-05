using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjTCC.Classe
{
    public class TipoProduto
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public TipoProduto() { }
        public TipoProduto(int codigo, string nome)
        {
            this.Codigo = codigo;
            this.Nome = nome;
        }
    }
}