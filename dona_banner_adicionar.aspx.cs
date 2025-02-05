using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using prjTCC.Lógica;

namespace prjTCC
{
    public partial class dona_banner_adicionar : System.Web.UI.Page
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

            if (!IsPostBack)
            {
                drpLink.SelectedIndex = 1;
            }
        }
       
        protected void btnAdicionarBanner_Click(object sender, EventArgs e)
        {

            adicionarBanner banner = new adicionarBanner();
            string NomeOriginalArq = null;
            string novoNomeArquivoDesktop = null;
            string novoNomeArquivoMobile = null;
            
            if (fluImagemDesktop.HasFile && fluImagemMobile.HasFile)
                {
                    NomeOriginalArq = Path.GetFileName(fluImagemDesktop.PostedFile.FileName);
                    novoNomeArquivoDesktop = NovoNomeArquivo(NomeOriginalArq);
                    string TipoArq = fluImagemDesktop.PostedFile.ContentType;

                    if (!fluImagemDesktop.HasFile)
                    {
                        litAviso.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> Nenhum arquivo foi selecionado.</p></div>";
                        return;
                    }
                    if (TipoArq != "image/jpeg" && TipoArq != "image/jpg" && TipoArq != "image/png")
                    {
                        litAviso.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> Arquivo não permitido! Somente jpeg, jpg ou png.</p></div>";
                        return;
                    }
                    int TamanhoArq = fluImagemDesktop.PostedFile.ContentLength;
                    if (TamanhoArq <= 0)
                    {
                        litAviso.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> A tentativa de upLoad do arquivo " + NomeOriginalArq + " falhou!</p></div>";
                        return;
                    }
                    else
                    {
                        fluImagemDesktop.PostedFile.SaveAs(Request.PhysicalApplicationPath + @"imagens\\Banners\\" + novoNomeArquivoDesktop);
                    }


                NomeOriginalArq = Path.GetFileName(fluImagemMobile.PostedFile.FileName);
                novoNomeArquivoMobile = NovoNomeArquivo(NomeOriginalArq);
                TipoArq = fluImagemMobile.PostedFile.ContentType;

                if (!fluImagemMobile.HasFile)
                {
                    litAviso.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> Nenhum arquivo foi selecionado.</p></div>";
                    return;
                }
                if (TipoArq != "image/jpeg" && TipoArq != "image/jpg" && TipoArq != "image/png")
                {
                    litAviso.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> Arquivo não permitido! Somente jpeg, jpg ou png.</p></div>";
                    return;
                }
                TamanhoArq = fluImagemMobile.PostedFile.ContentLength;
                if (TamanhoArq <= 0)
                {
                    litAviso.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> A tentativa de upLoad do arquivo " + NomeOriginalArq + " falhou!</p></div>";
                    return;
                }
                else
                {
                    if (fluImagemDesktop.FileName == fluImagemMobile.FileName)
                    {
                        novoNomeArquivoMobile = Path.GetFileNameWithoutExtension(novoNomeArquivoMobile) + "1" + Path.GetExtension(novoNomeArquivoMobile);
                    }
                    fluImagemMobile.PostedFile.SaveAs(Request.PhysicalApplicationPath + @"imagens\\Banners\\" + novoNomeArquivoMobile);
                }

            }
            else
            {
                litAviso.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> A(s) imagens de banner não podem estar vazias.</p></div>";
                return;
            }

            string link = null;
            if (drpLink.SelectedValue == "0")
            {
                link = txtLinkPersonalizado.Text;
            }
            else
            {
                link = drpLink.SelectedValue + txtQuery.Text;
            }

            banner.Adicionar(link, novoNomeArquivoDesktop, novoNomeArquivoMobile);
            txtLinkPersonalizado.Focus();
            pnlListaImagens.Controls.Clear();
            Response.Redirect("dona_banner.aspx");
        }
        string NovoNomeArquivo(string nomeArquivo)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            string extensao = Path.GetExtension(nomeArquivo);
            string nome = Path.GetFileNameWithoutExtension(nomeArquivo);
            return nome + timestamp + extensao;
        }

        protected void drpLink_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drpLink.SelectedValue == "0")
            {
                pnlLinkPersonalizado.Visible = true;
                pnlQuery.Visible = false;
            }
            else
            {
                pnlLinkPersonalizado.Visible = false;
                pnlQuery.Visible = true;
            }
        }
    }
}

