using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using prjTCC.Classe;

namespace prjTCC.Lógica
{
    public class FuncionarioEdicao : Banco
    {
        public void EditarFuncionario (string codigoFuncionario, string nome)
        {
            try
            {
                Conectar();
                List<Parametro> parametro = new List<Parametro>();
                parametro.Add(new Parametro("pCodFuncionario", codigoFuncionario));
                parametro.Add(new Parametro("pNomeFuncionario", nome));
                Executar("funcionarioEditarDados", parametro);
            }
            catch
            {
                throw new Exception("Não foi possível editar os dados.");
            }
            finally
            {
                Desconectar();
            }
        }
    }
}