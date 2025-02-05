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
    public partial class ra_banner : System.Web.UI.Page
    {
        string bannerTipo = "0";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Request.QueryString.Get("banner")))
            {
                bannerTipo = Request.QueryString.Get("banner");
            }
            List<Banner> banners = new List<Banner>();
            ListasDona listasDona = new ListasDona();
            if (bannerTipo == "0")
            {
                banners = listasDona.listarBanners(false);
            }
            else
            {
                banners = listasDona.listarBanners(true);
            }

            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            string dadosJSON = jsSerializer.Serialize(banners);
            Response.Write(dadosJSON);
        }
    }
}