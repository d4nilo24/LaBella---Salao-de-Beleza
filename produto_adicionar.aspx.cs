using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using prjTCC.Classe;
using prjTCC.Lógica;
using MySql.Data.MySqlClient;

namespace prjTCC
{
    public partial class produto_adicionar : System.Web.UI.Page
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

            /*if (!IsPostBack)
            {
                EdicaoDona dadosFuncionario = new EdicaoDona();
                using (MySqlDataReader reader = dadosFuncionario.listarTipoFuncionario())
                {
                    if (reader != null)
                    {
                        cmbTipoFuncionario.DataSource = reader;
                        cmbTipoFuncionario.DataTextField = "nm_tipo_funcionario";
                        cmbTipoFuncionario.DataValueField = "cd_tipo_funcionario";
                        cmbTipoFuncionario.DataBind();
                    }
                    reader.Close();
                    dadosFuncionario.FecharConexao();
                }
            }*/
        }
        protected void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtNome.Text.Trim(' ')))
            {
                litAviso.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> Por favor, preencha o campo Nome.</p></div>";
                txtNome.Text = "";
                txtNome.Focus();
                return;
            }
            else if (txtNome.Text.Any(char.IsDigit))
            {
                litAviso.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> Nome não pode conter números.</p></div>";
                txtNome.Text = "";
                txtNome.Focus();
                return;
            }
         
            else if (String.IsNullOrEmpty(txtQuantidade.Text.Trim(' ')))
            {
                litAviso.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> Por favor, preencha o campo Quantidade.</p></div>";
                txtQuantidade.Text = "";
                txtQuantidade.Focus();
                return;
            }

            else if (String.IsNullOrEmpty(drpCodTipo.Text.Trim(' ')))
            {
                litAviso.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> Por favor, preencha o campo E-mail.</p></div>";
                drpCodTipo.Focus();
                return;
            }

            adicionarProduto addFunc = new adicionarProduto();
            addFunc.AdicionarProduto(txtNome.Text, txtQuantidade.Text, txtDescricao.Text, drpCodTipo.SelectedValue);
            Response.Redirect("estoque.aspx");
            }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("estoque.aspx");
        }
    }
    }