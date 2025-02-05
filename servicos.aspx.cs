using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using prjTCC.Lógica;
using MySql.Data.MySqlClient;
using System.Security.Cryptography.X509Certificates;

namespace prjTCC
{
    public partial class servicos : System.Web.UI.Page
    {
        private string categoria = "";
        private static int paginaTotal = 0;
        private string paginaAtualIndice = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] != null)
            {
                if (Session["tipo"].ToString() == "3")
                {
                    litIconeUsuario.Text = "<i class='fa-solid fa-circle-user'></i>";
                    hpLogin.NavigateUrl = "~/minha_conta_agendamentos.aspx";
                    hpLoginResponsivo.NavigateUrl = "~/minha_conta_agendamentos.aspx";
                    litLoginResponsivo.Text = "Minha conta";
                }
                else if (Session["tipo"].ToString() == "2")
                {
                    litIconeUsuario.Text = "<i class='fa-solid fa-toolbox'></i> <p>Administrar</p>";
                    hpLogin.NavigateUrl = "~/dona_agenda.aspx";
                    hpLoginResponsivo.NavigateUrl = "~/dona_agenda.aspx";
                    litLoginResponsivo.Text = "Administrar";
                }
                else if (Session["tipo"].ToString() == "1")
                {
                    litIconeUsuario.Text = "<i class='fa-regular fa-calendar-days'></i><p>Agenda</p>";
                    hpLogin.NavigateUrl = "~/funcionario_agenda.aspx";
                    hpLoginResponsivo.NavigateUrl = "~/funcionario_agenda.aspx";
                    litLoginResponsivo.Text = "Abrir Agenda";
                }
            }
            else
            {
                litIconeUsuario.Text = "<i class='fa-solid fa-right-to-bracket'></i>";
                hpLogin.NavigateUrl = "login_cookie.html?url=" + Request.Url.PathAndQuery;
                hpLoginResponsivo.NavigateUrl = "login_cookie.html?url=" + Request.Url.PathAndQuery;
                litLoginResponsivo.Text = "Fazer login";
            }

            categoria = Request.QueryString.Get("categoria");
            paginaAtualIndice = Request.QueryString.Get("pag");

            if (String.IsNullOrEmpty(categoria))
            {
                categoria = "0";
            }
            if (String.IsNullOrEmpty(paginaAtualIndice))
            {
                paginaAtualIndice = "1";
            }

            try
            {
                ListaCategoria criarCategorias = new ListaCategoria();
                rpFiltrosLista.DataSource = criarCategorias.ListarCategorias(true);
                rpFiltrosLista.DataBind();
          
                ListaServicoPorCategoria criarServicos = new ListaServicoPorCategoria();
                rpListaServicos.DataSource = criarServicos.ListarServicosPorCategoria(categoria, paginaAtualIndice);
                rpListaServicos.DataBind();

                if (rpListaServicos.Items.Count < 1)
                {
                    imgErro.ImageUrl = "~/imagens/erroListarCategoria.png";
                }
                else
                {
                    imgErro.Visible = false;
                }

                paginaTotal = criarServicos.PaginaTotal;
    
                if (paginaTotal > 1)
                {
                    ListarPaginas(int.Parse(paginaAtualIndice));
                }
                else
                {
                    pnlIndice.Visible = false;
                }
            }
            catch (Exception ex)
            {
                HttpContext.Current.Items["ErroTipo"] = "500 - Erro no servidor interno";
                HttpContext.Current.Items["ErroMensagem"] = ex.Message;
                Server.Transfer("~/erro.aspx");
            }

            //loading_spinner.Visible = false;
        }
        public void ListarPaginas (int paginaAtual)
        {
            int indice = 0;
            int quantidade = 1;
            if (paginaAtual == 1)
            {
                indice = 1;
            }
            else if (paginaAtual == paginaTotal)
            {
                if (indice - 2 < 1)
                    indice = paginaAtual - 1;
                else
                    indice = paginaAtual - 2;
            }
            else
            {
                indice = paginaAtual - 1;
            }

            for (int i = indice; i <= paginaTotal; i++)
            {
                if (quantidade < 4)
                {
                    Panel pnlPagina = new Panel();
                    Literal txtIndice = new Literal();
                    txtIndice.Text = i.ToString();
                    pnlPagina.Controls.Add(txtIndice);
                    
                    if (i == int.Parse(paginaAtualIndice))
                        pnlPagina.CssClass = "paginator_selecionado";
                    else
                        pnlPagina.CssClass = "paginator";

                    HyperLink hlPagina = new HyperLink();
                    hlPagina.NavigateUrl = "servicos.aspx?categoria=" + categoria + "&pag=" + i;
                    hlPagina.Controls.Add(pnlPagina);

                    pnlIndice.Controls.Add(hlPagina);
                    quantidade++;
                }
            }
        }
    }
}   