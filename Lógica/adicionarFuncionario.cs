using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using prjTCC.Classe;

namespace prjTCC.Lógica
{
    public class adicionarFuncionario: Banco
    {
        public string AdicionarFuncionario(string nome, string tipo, string email, string senha, string imagem)
        {
            try
            {
                Conectar();
                List<Parametro> parametros = new List<Parametro>();
                parametros.Add(new Parametro("vNome", nome));
                parametros.Add(new Parametro("vTipo", tipo));
                parametros.Add(new Parametro("vEmail", email));
                parametros.Add(new Parametro("vSenha", senha));
                parametros.Add(new Parametro("vNmImagem", imagem));
                Executar("cadastrarFuncionario", parametros);
            }
           /* catch
            {
                throw new Exception ("Houve erro ao Adicionar Funcionario");
            }*/
            finally
            {
                Desconectar();
            }
            return "Funcionario Adicionado com sucesso";
        }

    }
}