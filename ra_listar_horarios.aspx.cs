using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Script.Serialization;
using prjTCC.Lógica;
using prjTCC.Classe;

namespace prjTCC
{
    public partial class ra_listar_horarios : System.Web.UI.Page
    {
        string codigoServico = null;
        string codigoFuncionario = null;
        string codigoDiaDaSemana = null;
        string dataSelecionada = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ContentType = "application/json";

            if (!String.IsNullOrEmpty(Request.QueryString.Get("servico")))
            {
                codigoServico = Request.QueryString.Get("servico");
            }   
            if (!String.IsNullOrEmpty(Request.QueryString.Get("funcionario")))
            {
                codigoFuncionario = Request.QueryString.Get("funcionario");
            }
            if (!String.IsNullOrEmpty(Request.QueryString.Get("diadasemana")))
            {
                codigoDiaDaSemana = Request.QueryString.Get("diadasemana");
            }
            if (!String.IsNullOrEmpty(Request.QueryString.Get("data")))
            {
                dataSelecionada = Request.QueryString.Get("data");
            }


            ListarHorarioFuncionario listarHorarioFuncionario = new ListarHorarioFuncionario();
            
            List<FuncionarioServicoDiaDeTrabalho> funcionarioServicoDiaDeTrabalho = listarHorarioFuncionario.listarHorarioFuncionario(codigoServico, codigoFuncionario, codigoDiaDaSemana, dataSelecionada);

            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            string dadosJSON = jsSerializer.Serialize(funcionarioServicoDiaDeTrabalho);
            Response.Write(dadosJSON);
        }
    }
}