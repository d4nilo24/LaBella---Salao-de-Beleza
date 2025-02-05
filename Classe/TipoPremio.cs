using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjTCC.Classe
{
    public class TipoPremio
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public TipoPremio() { }
        public TipoPremio(int codigo, string nome)
        {
            this.Codigo = codigo;
            this.Nome = nome;
        }

    }
}