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
    public partial class ra_cupom : System.Web.UI.Page
    {
        string codigoServico = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Request.QueryString.Get("servico")))
            {
                codigoServico = Request.QueryString.Get("servico");
            }

            ListaCupom listarCupom = new ListaCupom();
            List<Cupom> cupons = listarCupom.ListarCupom(Session["login"].ToString(), codigoServico);

            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            string dadosJSON = jsSerializer.Serialize(cupons);
            Response.Write(dadosJSON);
        }
    }
}