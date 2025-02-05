using prjTCC.Classe;
using prjTCC.Lógica;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjTCC
{
    public partial class ra_dados_minimos : System.Web.UI.Page
    {
        string codigoServico;
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ContentType = "application/json";

            codigoServico = Request.QueryString.Get("servico");

            DadosMinimosServicoEspecifico dadosServico = new DadosMinimosServicoEspecifico();
            Servico servico = dadosServico.DadosMinimosServico(codigoServico);

            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            string dadosJSON = jsSerializer.Serialize(servico);
            Response.Write(dadosJSON);
        }
    }
}