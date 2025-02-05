using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjTCC
{
    public partial class ra_verificar_login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.ContentType = "application/json";

            if (Session["login"] != null)
            {
                Response.Write(("{'logado':true, 'tipo':"+Session["tipo"]+"}").Replace("'", "\""));
            }
            else
            {
                Response.Write(("{'logado':false, 'tipo':" + Session["tipo"] + "}").Replace("'", "\""));
            }
        }
    }
}