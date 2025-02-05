using prjTCC.Classe;
using prjTCC.Lógica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjTCC
{
    public partial class minha_conta_recompensas : System.Web.UI.Page
    {
        string codigoRecompensa = null;
        public string tipoPremio = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] == null)
            {
                Response.Redirect("login.aspx");
            }

            else if (Session["tipo"].ToString() != "3")
            {
                Response.Redirect("index.aspx");
            }
            if (Request.QueryString.Get("cdrecompensa") != null)
            {
                codigoRecompensa = Request.QueryString.Get("cdrecompensa").ToString();
            }
            if (Request.QueryString.Get("tipo") != null)
            {
                tipoPremio = Request.QueryString.Get("tipo").ToString();
            }
            else
            {
                tipoPremio = "0";
            }



            litNomeBoasVindas.Text = Session["nome"].ToString().Split(' ')[0];

            RecompensaCliente listaRecompensaCliente = new RecompensaCliente();
            List<Premio> recompensas = new List<Premio>();
            recompensas = listaRecompensaCliente.listarRecompensasCliente(Session["login"].ToString(), tipoPremio);

            rpRecompensa.DataSource = recompensas;
            rpRecompensa.DataBind();
            
            if (recompensas.Count < 1)
            {
                imgErro.Visible = true;
                if (tipoPremio == "1")
                {
                    imgErro.ImageUrl = "~/imagens/semCupomRecompensa.png";
                }
                else if (tipoPremio == "2") 
                {
                    imgErro.ImageUrl = "~/imagens/semProdutosRecompensa.png";
                }
                else
                {
                    imgErro.ImageUrl = "~/imagens/semRecompensa.png";
                }
            }
            else
            {
                imgErro.Visible = false;
            }

            /*if (codigoRecompensa != null)
            {
                RecompensaCliente mostraPanelRetirada = new RecompensaCliente();

                Premio recompensa = new Premio();

                recompensa = mostraPanelRetirada.mostrarDadosPremioparaRetirada(codigoRecompensa, Session["login"].ToString());

                if (!String.IsNullOrEmpty(recompensa.Imagem.Pasta) && !String.IsNullOrEmpty(recompensa.Imagem.Nome))
                {
                    if (recompensa.TipoPremio.Codigo == 2)
                    {
                        ImgRecompensaSelecionada.ImageUrl = "imagens/" + recompensa.Imagem.Pasta + "/" + recompensa.Imagem.Nome;
                        litNomeRecompensaSelecionada.Text = recompensa.Nome;
                        litRecompensaDescricao.Text = recompensa.Descricao;
                        litAvso.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> Somente o funcionário deve fazê-lo.</p></div>";

                        pnlRetiradaCupom.Visible = false;
                        pnlRetirada.Visible = true;
                        return;
                    }

                    else
                    {
                        ImgCupom.ImageUrl = "imagens/" + recompensa.Imagem.Pasta + "/" + recompensa.Imagem.Nome;
                        litNomeCupomRecompensa.Text = recompensa.Nome;
                        litCupomDescricaoRecompensa.Text = recompensa.Descricao;
                        litAvisoCupom.Text = "<div style='margin-top: 5px;'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> Cupom utilizável ao agendar serviço.</p></div>";

                        pnlRetirada.Visible = false;
                        pnlRetiradaCupom.Visible = true;
                        return;
                    }
                }
                
                else
                    pnlRetirada.Visible = false;*/
            }
        }


        /*protected void btnRetirarRecompensa_Click(object sender, EventArgs e)
        {
            RecompensaCliente resgatePremio = new RecompensaCliente();
            
            if (resgatePremio.retirarRecompensaCliente(codigoRecompensa, Session["login"].ToString()))
                Response.Redirect("minha_conta_recompensas.aspx?tipo=" + tipoPremio);
            else
                litAvso.Text = "Algo deu errado";
        }

        protected void btnFechaRetirada_Click(object sender, EventArgs e)
        {
            pnlRetirada.Visible = false;
        }

        protected void btnFechaRetiradaCupom_Click(object sender, EventArgs e)
        {
            pnlRetiradaCupom.Visible = false;
        }*/
    }

