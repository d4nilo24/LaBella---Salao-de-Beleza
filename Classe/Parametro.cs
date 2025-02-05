using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjTCC.Classe
{
    public class Parametro
    {
        public string Nome { get; set; }
        public string Valor { get; set; }

        public Parametro() { }
        public Parametro(string nome, string valor)
        {
            this.Nome = nome;
            this.Valor = valor;
        }
    }
}