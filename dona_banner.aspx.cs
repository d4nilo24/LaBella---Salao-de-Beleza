using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using prjTCC.Lógica;
using prjTCC.Classe;
using MySql.Data.MySqlClient;
using System.Data;
using System.IO;

namespace prjTCC
{
    public partial class dona_banner : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] == null)
            {
                Response.Redirect("login_cookie.html?url=" + HttpContext.Current.Request.Url.AbsoluteUri);
            }
            else if (Session["tipo"].ToString() != "2")
            {
                Response.Redirect("index.aspx");
            }

            ListasDona lista = new ListasDona();
            List<Banner> banners = lista.listarBanners();

            if(banners.Count > 0)
            {
                foreach (Banner banner in banners)
                {
                    string htmlPremio = $@"<div class='recompensa-container-informacoes-textos'> </div>";

                    Panel pnlBanners = new Panel();
                    pnlBanners.CssClass = "recompensa-container";

                    Panel pnlImagemDesktop = new Panel();
                    Panel pnlImagemMobile = new Panel();

                    Panel pnlImagem = new Panel();
                    pnlImagem.CssClass = "banner-imagem";

                    Panel panelInformacoes = new Panel();
                    panelInformacoes.CssClass = "recompensa-container-informacoes";

                    Label nomeImagem1 = new Label();
                    nomeImagem1.Text = "Imagem para telas grandes";

                    Image imagemDesktop = new Image();
                    imagemDesktop.AlternateText = "Imagem do Banner";
                    imagemDesktop.ImageUrl = "imagens/" + banner.ImagemDesktop.Pasta + "/" + banner.ImagemDesktop.Nome;

                    Image imagemMobile = new Image();
                    imagemMobile.AlternateText = "Imagem do Banner";
                    imagemMobile.ImageUrl = "imagens/" + banner.ImagemMobile.Pasta + "/" + banner.ImagemMobile.Nome;

                    Literal litExtrutura = new Literal();
                    litExtrutura.Text = htmlPremio;

                   
                    Label nomeImagem2 = new Label();
                    nomeImagem2.Text = "Imagem para telas pequenas";

                    Button btnExcluir = new Button();
                    btnExcluir.Text = "Excluir";
                    btnExcluir.CssClass = "botoes excluir";
                    btnExcluir.CommandArgument = banner.ImagemDesktop.Nome + "," + banner.ImagemMobile.Nome;
                    btnExcluir.Command += btnExcluir_Click;

                    pnlImagemDesktop.Controls.Add(nomeImagem1);
                    pnlImagemDesktop.Controls.Add(imagemDesktop);
                    pnlImagemMobile.Controls.Add(nomeImagem2);
                    pnlImagemMobile.Controls.Add(imagemMobile);
                    pnlImagem.Controls.Add(pnlImagemDesktop);
                    pnlImagem.Controls.Add(pnlImagemMobile);
                    pnlBanners.Controls.Add(pnlImagem);
                    panelInformacoes.Controls.Add(litExtrutura);
                    panelInformacoes.Controls.Add(btnExcluir);
                    pnlBanners.Controls.Add(pnlImagem);
                    pnlBanners.Controls.Add(panelInformacoes);

                    pnlBanner.Controls.Add(pnlBanners);
                }
            }
            else
            {
                litAviso.Text = "<p>Não foi colocado nenhum banner.</p>";
            }
        }

        private void btnExcluir_Click(object sender, CommandEventArgs e)
        {
            string[] imagens = e.CommandArgument.ToString().Split(',');
            for (int i = 0; i < imagens.Length; i++)
            {
                string caminhoBase = Server.MapPath("~/imagens/Banners/") + imagens[i];

                if (File.Exists(caminhoBase))
                {
                    File.Delete(caminhoBase);
                }                
            }
            DeletarBanner banner = new DeletarBanner();
            banner.Deletar(imagens[0], imagens[1]);
            Response.Redirect(Request.RawUrl); 
        }
    }
}