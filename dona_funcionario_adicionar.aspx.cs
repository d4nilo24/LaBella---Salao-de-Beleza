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
    public partial class dona_funcionario_adicionar : System.Web.UI.Page
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
            }
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
            else if (String.IsNullOrEmpty(txtEmail.Text.Trim(' ')))
            {
                litAviso.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> Por favor, preencha o campo E-mail.</p></div>";
                txtEmail.Text = "";
                txtEmail.Focus();
                return;
            }
            else if (String.IsNullOrEmpty(txtSenha.Text.Trim(' ')))
            {
                litAviso.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> Por favor, preencha o campo Senha.</p></div>";
                txtSenha.Text = "";
                txtSenha.Focus();
                return;
            }
            else if (txtSenha.Text.Length < 6)
            {
                litAviso.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> A senha deve conter no mínimo 6 cacteres.</p></div>";
                txtSenha.Text = "";
                txtSenha.Focus();
                return;
            }

            else
            {
                adicionarFuncionario addFunc = new adicionarFuncionario();
                string NomeOriginalArq = null;
                string novoNomeArquivo = null;

                if (fluImagem.HasFile)
                {
                    NomeOriginalArq = Path.GetFileName(fluImagem.PostedFile.FileName);
                    novoNomeArquivo = NovoNomeArquivo(NomeOriginalArq);
                    string TipoArq = fluImagem.PostedFile.ContentType;

                    if (!fluImagem.HasFile)
                    {
                        litAviso.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> Nenhum arquivo foi selecionado.</p></div>";
                        return;
                    }

                    if (TipoArq != "image/jpeg" && TipoArq != "image/jpg" && TipoArq != "image/png")
                    {
                        litAviso.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> Arquivo não permitido! Somente jpeg, jpg ou png.</p></div>";
                        return;
                    }

                    int TamanhoArq = fluImagem.PostedFile.ContentLength;

                    if (TamanhoArq <= 0)
                    {
                        litAviso.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> A tentativa de upLoad do arquivo " + NomeOriginalArq + " falhou!</p></div>";
                        return;
                    }
                    else
                    {
                        fluImagem.PostedFile.SaveAs(Request.PhysicalApplicationPath + @"imagens\\Funcionarios\\" + novoNomeArquivo);
                    }

                }
                addFunc.AdicionarFuncionario(txtNome.Text, cmbTipoFuncionario.SelectedValue, txtEmail.Text, txtSenha.Text, novoNomeArquivo);
                Response.Redirect("dona_funcionarios.aspx");
            }
        }
        string NovoNomeArquivo(string nomeArquivo)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            string extensao = Path.GetExtension(nomeArquivo);
            string nome = Path.GetFileNameWithoutExtension(nomeArquivo);
            return nome + timestamp + extensao;
        }
    }
}