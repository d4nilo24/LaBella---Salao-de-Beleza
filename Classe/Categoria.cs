using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjTCC.Classe
{
    public class Categoria
    {
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public Imagem Imagem { get; set; }


        public Categoria() { }
        public Categoria(int codigo, string nome, Imagem imagem)
        {
            this.Codigo = codigo;
            this.Nome = nome;
            this.Imagem = imagem;
        }
    }
}