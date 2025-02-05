using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjTCC.Classe
{
    public class Token
    {
        public string Codigo { get; set; }
        #region Dado de Cliente (email)
        public Cliente Cliente { get; set; }
        #endregion
        public Token() { }
        public Token(string codigo, Cliente cliente)
        {
            this.Codigo = codigo;
            this.Cliente = cliente;
        }
    }
}