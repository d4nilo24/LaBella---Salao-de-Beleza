using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using prjTCC.Classe;

namespace prjTCC.Lógica
{
    public class AdicionarImagem : Banco 
    {
        public void Imagem(string imagem, string pasta)
        {
            try
            {
                Conectar();
                List<Parametro> parametros = new List<Parametro>();
                parametros.Add(new Parametro("vImagem", imagem));
                parametros.Add(new Parametro("vPasta", pasta));
                Executar("AdicionarImagem",parametros);
            }
            finally
            {
                Desconectar();
            }
        }
    }
}