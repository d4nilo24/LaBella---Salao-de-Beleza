using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjTCC.Classe
{
    public class Temporada
    {
        public int Codigo { get; set; }
        public string DataInicio { get; set; }
        public string DataFinal { get; set; }
        public Temporada() { }
        public Temporada(int codigo, string dataInicio, string dataFinal)
        {
            this.Codigo = codigo;
            this.DataInicio = dataInicio;
            this.DataFinal = dataFinal;
        }
    }
}