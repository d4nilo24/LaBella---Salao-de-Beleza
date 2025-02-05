using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using prjTCC.Classe;

namespace prjTCC.Lógica
{
    public class adicionarBanner : Banco
    {
        public void Adicionar(string link, string imgDesktop, string imgMobile)
        {
            try
            {
              Conectar();
                List<Parametro> parametros = new List<Parametro>();
                parametros.Add(new Parametro("vLink", link));
                parametros.Add(new Parametro("vNomeImgDesktop", imgDesktop));
                parametros.Add(new Parametro("vNomeImgMobile", imgMobile));
                
                Executar("adicionarBanner", parametros);
            }
            finally
            {
              Desconectar();
            }
        }
    }
}