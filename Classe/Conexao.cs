using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjTCC.Classe
{
    public class Conexao
    {
        public static string getConexao()
        {
            return "SERVER=localhost;UID=root;PASSWORD=root;DATABASE=labella";
        }
    }
}