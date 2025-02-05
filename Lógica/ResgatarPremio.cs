using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using prjTCC.Classe;

namespace prjTCC.Lógica
{
    public class ResgatarPremio :Banco
    {
        public void ResgatarRecompensa (string codigoPremio, string emailCliente)
        {
            try
            {
                Conectar();

                List<Parametro> parametros = new List<Parametro>();
                parametros.Add(new Parametro("vCodPremio", codigoPremio));
                parametros.Add(new Parametro("vEmailCliente", emailCliente));

                Executar("RegistrarRecolhimentoDePremio", parametros);
            }   
            catch
            {
                throw new Exception("Não foi possível resgatar esse prêmio.");
            }
            finally
            {
                Desconectar();
            }
        }
    }
}