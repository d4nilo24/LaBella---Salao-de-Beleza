using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using prjTCC.Lógica;
using prjTCC.Classe;


namespace prjTCC
{
    public partial class funcionario_editar : System.Web.UI.Page
    {
        Funcionario funcionario = new Funcionario();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] == null)
            {
                Response.Redirect("login_cookie.html?url=" + HttpContext.Current.Request.Url.AbsoluteUri);
            }
            else if (Session["tipo"].ToString() != "1")
            {
                Response.Redirect("index.aspx");
            }

            EdicaoDona dadosFuncionario = new EdicaoDona();
            funcionario = dadosFuncionario.mostrarDadosFuncionario(Session["login"].ToString());

            hpEditarHorario.NavigateUrl = "dona_funcionario_adicionar_horario_servico.aspx?cdfuncionario=" + funcionario.Codigo;
            hpEditarHorario.Text = "Visualizar os seus horários";
            hpEditarHorario.ForeColor = System.Drawing.ColorTranslator.FromHtml("#b36684");
            hpEditarHorario.NavigateUrl = "~/funcionario_visualizar_horario.aspx";
            hpEditarHorario.CssClass = "fr";

            carregarImagemFuncionario();
            
            if (!IsPostBack)
            {
                try
                {
                    funcionario = dadosFuncionario.mostrarDadosFuncionario(Session["login"].ToString());

                    txtCodFuncionario.Text = funcionario.Codigo.ToString();
                    txtNomeCompletoFuncionario.Text = funcionario.Nome.ToString();
                    txtEmailFuncionario.Text = funcionario.Email.ToString();

                    if (funcionario.TipoFuncionario.Codigo == 1)
                    {
                        txtTipoFuncionario.Text = "Funcionário";
                    }
                    else
                    {
                        txtTipoFuncionario.Text = "Gerente";
                    }

                    
                    carregarImagemFuncionario();
                }

                catch (Exception)
                {
                    Response.Redirect("erro.aspx");
                }
            }
        }

        void carregarImagemFuncionario()
        {
            pnlListaImagens.Controls.Clear();

            if (!string.IsNullOrEmpty(funcionario.Imagem.Nome) || !string.IsNullOrEmpty(funcionario.Imagem.Pasta))
            {
                string caminhoBase = "";

                caminhoBase = Request.PhysicalApplicationPath + @"imagens\" + funcionario.Imagem.Pasta;
                string caminhoDaImagem = Path.Combine(caminhoBase, funcionario.Imagem.Nome);

                if (File.Exists(caminhoDaImagem))
                {
                    string imagemTag = $"imagens/{funcionario.Imagem.Pasta}/{funcionario.Imagem.Nome}";

                    Panel panel = new Panel();
                    panel.CssClass = "pnlImagens";

                    Image image = new Image();
                    image.ImageUrl = imagemTag;

                    panel.Controls.Add(image);
                    pnlListaImagens.Controls.Add(panel);
                }
            }

            Panel fimFloat = new Panel();
            fimFloat.ID = "limparFloat";
            fimFloat.CssClass = "cls";
            pnlListaImagens.Controls.Add(fimFloat);
        }

        /* protected void btnEditarFuncionario_Click(object sender, EventArgs e)
         {
             try
             {
                 FuncionarioEdicao funcionarioEdicao = new FuncionarioEdicao();

                 EdicaoDona dadosFuncionario = new EdicaoDona();
                 funcionario = dadosFuncionario.mostrarDadosFuncionario(Session["login"].ToString());

                 if (String.IsNullOrEmpty(txtNomeCompletoFuncionario.Text))
                 {
                     litAviso.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> Nome não pode ficar vazio</p></div>";
                     txtNomeCompletoFuncionario.Focus();
                     return;
                 }

                 else if (String.IsNullOrEmpty(txtEmailFuncionario.Text))
                 {
                     litAviso.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> E-mail não pode ficar vazio</p></div>";
                     txtEmailFuncionario.Focus();
                     return;
                 }

                 else if (txtEmailFuncionario.Text != funcionario.Email.ToString() || txtNomeCompletoFuncionario.Text != funcionario.Nome.ToString())
                 {
                     funcionarioEdicao.EditarFuncionario(Session["login"].ToString(), txtNomeCompletoFuncionario.Text);
                     litAviso.Text = "<div class='acerto'><p><i class=\"fa-solid fa-check\"></i> Dado(s) alterado(s) com sucesso</p></div>";
                     return;
                 }

                 else
                 {
                     litAviso.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> Nenhum dado foi alterado</p></div>";
                     return;
                 }
             }

             catch (Exception)
             {
                 throw new Exception("Erro ao alterar os dados");
             }
         }*/
    }
}