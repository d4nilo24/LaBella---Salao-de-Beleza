using prjTCC.Classe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjTCC.Lógica
{
    public class CancelaAgendamento : Banco
    {
        public bool CancelarServico(string emailCliente, string codigoAgendamento)
        {
            try
            {
                Conectar();

                string procedure = "cancelarAgendamento";

                List<Parametro> parametros = new List<Parametro>();
                parametros.Add(new Parametro("pEmailCliente", emailCliente));
                parametros.Add(new Parametro("pCodAgendamento", codigoAgendamento));

                Executar(procedure, parametros);

                return true;
            }

            catch (Exception)
            {
                throw new Exception("Erro ao cancelar o seu agendamento");
            }

            finally
            {
                Desconectar();
            }
        }
    }
}