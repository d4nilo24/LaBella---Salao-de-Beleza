using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjTCC.Classe
{
    public class TipoFuncionario
    {
        public int Codigo { get; set; }
        public string Nome {  get; set; }

        public TipoFuncionario() 
        { 
        }

        public TipoFuncionario(int codigo, string nome)
        {
            this.Codigo = codigo;
            this.Nome = nome;
        }
    }
}