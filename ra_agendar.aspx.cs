using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using prjTCC.Lógica;
using prjTCC.Classe;

namespace prjTCC
{
    public partial class ra_agendar : System.Web.UI.Page
    {
        string codigoServico = null;
        string horaSelecionada = null;
        string dataSelecionada = null;
        string codigoFuncionario = null;
        string codigoDiaTrabalho = null;
        string codigoCupom = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Request.QueryString.Get("servico")))
            {
                codigoServico = Request.QueryString.Get("servico");
            }
            if (!String.IsNullOrEmpty(Request.QueryString.Get("hora")))
            {
                horaSelecionada = Request.QueryString.Get("hora");
            }
            if (!String.IsNullOrEmpty(Request.QueryString.Get("data")))
            {
                dataSelecionada = Request.QueryString.Get("data");
            }
            if (!String.IsNullOrEmpty(Request.QueryString.Get("funcionario")))
            {
                codigoFuncionario = Request.QueryString.Get("funcionario");
            }
            if (!String.IsNullOrEmpty(Request.QueryString.Get("diadasemana")))
            {
                codigoDiaTrabalho = Request.QueryString.Get("diadasemana");
            }
            if (!String.IsNullOrEmpty(Request.QueryString.Get("cupom")))
            {
                codigoCupom = Request.QueryString.Get("cupom");
            }

            Agendar agendamento = new Agendar();
            string resultado = agendamento.EfetuarAgendamento(dataSelecionada, Session["login"].ToString(), codigoFuncionario, codigoServico, horaSelecionada, codigoDiaTrabalho, codigoCupom); ;
            Response.Write(resultado);
        }
    }
}