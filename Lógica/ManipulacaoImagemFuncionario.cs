using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using prjTCC.Classe;
using MySql.Data.MySqlClient;

namespace prjTCC.Lógica
{
    public class ManipulacaoImagemFuncionario : Banco
    {
        public bool substituirImagem(string pastaImagem, string nomeImagem, string codFuncionario)
        {
            try
            {
                Conectar();

                string procedure = "substituirImagemFuncionario";

                List<Parametro> parametros = new List<Parametro>();

                parametros.Add(new Parametro("pNomePasta", pastaImagem));
                parametros.Add(new Parametro("pNomeImagem", nomeImagem));
                parametros.Add(new Parametro("pCodFuncionario", codFuncionario));

                Executar(procedure, parametros);
                return true;
            }

            catch (Exception)
            {
                throw new Exception("Houve um erro ao deletar a imagem.");
            }

            finally
            {
                Desconectar();
            }
        }
    }
}