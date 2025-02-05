using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjTCC.Classe
{
    public class Cupom
    {
        public int Codigo { get; set; }
        public int Valor { get; set; }
        public Cupom() { }
        public Cupom(int codigo, int valor)
        {
            this.Codigo = codigo;
            this.Valor = valor;
        }
    }
}