using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using prjTCC.Classe;

namespace prjTCC.Lógica
{
    public class Agendar : Banco
    {
        public string EfetuarAgendamento (string dataAgendamento, string emailCliente, string codigoFuncionario, string codigoServico, string horaFuncionarioServicoDiaDeTrabalho, string codigoDiaDeTrabalho, string codigoCupom)
        {
            try
            {
                Conectar();

                List<Parametro> parametros = new List<Parametro>();
                parametros.Add(new Parametro("vCodServico", codigoServico));
                parametros.Add(new Parametro("vHoraSelec", horaFuncionarioServicoDiaDeTrabalho));
                parametros.Add(new Parametro("vEmailCliente", emailCliente));
                parametros.Add(new Parametro("vDataSelec", dataAgendamento));
                parametros.Add(new Parametro("vCodigoFuncionario", codigoFuncionario));
                parametros.Add(new Parametro("vCodDiaTrabalho", codigoDiaDeTrabalho));
                parametros.Add(new Parametro("vCodCupom", codigoCupom));

                Executar("EfetuarAgendamento", parametros);
            }
            catch (Exception ex)
            {
                if (ex.Message == "Erro ao realizar o comando")
                {
                    return "Erro ao realizar o agendamento.";
                }
                else
                {
                    return ex.Message;
                }
            }
            finally
            {
                Desconectar();
            }
            return "Agendamento realizado com sucesso.";
        }
    }
}