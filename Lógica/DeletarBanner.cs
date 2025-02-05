using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using prjTCC.Classe;

namespace prjTCC.Lógica
{
    public class DeletarBanner : Banco
    {
        public void Deletar(string nomeDesktop, string nomeMobile)
        {
            try
            {
                Conectar();
                List<Parametro> parametros = new List<Parametro>();
                parametros.Add(new Parametro("vNomeDesktop", nomeDesktop));
                parametros.Add(new Parametro("vNomeMobile", nomeMobile));
                Executar("DeletarBanner",parametros);
            }
            finally
            {
                Desconectar();
            }
        }
    }
}