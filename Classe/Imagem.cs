using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjTCC.Classe
{
    public class Imagem
    {
        public string Nome { get; set; }
        public string Pasta { get; set; }
        public Imagem() { }
        public Imagem(string nome, string pasta)
        {
            this.Nome = nome;
            this.Pasta = pasta;
        }
    }
}