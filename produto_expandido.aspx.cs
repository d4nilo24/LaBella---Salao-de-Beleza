using prjTCC.Classe;
using prjTCC.Lógica;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace prjTCC
{
    public partial class produto_expandido : System.Web.UI.Page
    {
        Produto produto = new Produto();
        string produtoQuery = null;
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


            if (Request.QueryString.Get("cdproduto") != null)
            {
                produtoQuery = Request.QueryString.Get("cdproduto");
            }
             else
            {
              HttpContext.Current.Items["ErroTipo"] = "404 - Página não encontrada";
              HttpContext.Current.Items["ErroMensagem"] = "Não foi escolhido o produto.";
              Server.Transfer("~/erro.aspx");
            }

            if (!IsPostBack)
            {
                try
                {
                    //produto = dadosProduto.mostrarDadosProduto(produtoQuery);
                    EdicaoDona dadosProduto = new EdicaoDona();
                    produto = dadosProduto.mostrarDadosProduto(produtoQuery);
                    txtCodProduto.Text = produto.Codigo.ToString();
                    txtNomeProduto.Text = produto.Nome.ToString();
                    txtQuantidadeProduto.Text = produto.Quantidade.ToString();
                    txtDescricaoProduto.Text = produto.Descricao.ToString();
                    drpCodTipo.SelectedValue = produto.TipoProduto.ToString();
                }

                catch (Exception)
                {
                    Response.Redirect("erro.aspx");
                }
            }
            
        }

        protected void btnEditarProduto_Click(object sender, EventArgs e)
        {
            try
            {
                EdicaoDona edicaoDadosProdutos = new EdicaoDona();

                produto = edicaoDadosProdutos.mostrarDadosProduto(produtoQuery);

                if (String.IsNullOrEmpty(txtNomeProduto.Text))
                {
                    litAvisoProduto.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> Nome não pode ficar vazio</p></div>";
                    txtNomeProduto.Focus();
                    return;
                }
                else if (String.IsNullOrEmpty(txtQuantidadeProduto.Text))
                {
                    litAvisoProduto.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> Quantidade não pode ficar vazio</p></div>";
                    txtQuantidadeProduto.Focus();
                    return;
                }

                else if (txtQuantidadeProduto.Text != produto.Quantidade.ToString() || txtNomeProduto.Text != produto.Nome.ToString() || txtDescricaoProduto.Text != produto.Descricao.ToString() || txtCodProduto.Text != produto.Codigo.ToString() || drpCodTipo.Text != produto.TipoProduto.ToString())
                {
                    edicaoDadosProdutos.editarDadosProdutos(produtoQuery, txtNomeProduto.Text, txtQuantidadeProduto.Text, txtDescricaoProduto.Text, drpCodTipo.Text);
                    litAvisoProduto.Text = "<div class='acerto'><p><i class=\"fa-solid fa-check\"></i> Dado(s) alterado(s) com sucesso</p></div>";
                    return;
                }

                else
                {
                    litAvisoProduto.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> Nenhum dado foi alterado</p></div>";
                    return;
                }
            }

            catch (Exception)
            {
                throw new Exception("Erro ao alterar os dados");
            }

        }
        protected void btnSim_Click(object sender, EventArgs e)
        {
            EdicaoDona edicaoDadosProdutos = new EdicaoDona();
            edicaoDadosProdutos.excluirProduto(produto.Codigo);
            Response.Redirect("estoque.aspx");
        }

        protected void btnNao_Click(object sender, EventArgs e)
        {
            pnlConfirmarExclusao.Visible = false;
        }

        protected void btnExcluirProduto_Click1(object sender, EventArgs e)
        {
            pnlConfirmarExclusao.Visible = true;
        }
    }
}