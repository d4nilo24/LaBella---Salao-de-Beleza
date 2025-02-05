using prjTCC.Classe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjTCC.Lógica
{
    public class ManipulacaoImagemRecompensa : Banco
    {
        public bool substituirImagem(string pastaImagem, string nomeImagem, string codPremio)
        {
            try
            {
                Conectar();

                string procedure = "substituirImagemRecompensa";

                List<Parametro> parametros = new List<Parametro>();
   
                parametros.Add(new Parametro("pNomePasta", pastaImagem));
                parametros.Add(new Parametro("pNomeImagem", nomeImagem));
                parametros.Add(new Parametro("pCodPremio", codPremio));

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