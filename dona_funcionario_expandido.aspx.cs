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
    public partial class dona_funcionario_expandido : System.Web.UI.Page
    {
        Funcionario funcionario = new Funcionario();
        string funcionarioQuery = null;
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


            if (Request.QueryString.Get("cdfuncionario") != null)
            {
                funcionarioQuery = Request.QueryString.Get("cdfuncionario");
            }
            else
            {
                HttpContext.Current.Items["ErroTipo"] = "404 - Página não encontrada";
                HttpContext.Current.Items["ErroMensagem"] = "Não foi escolhido o funcionário.";
                Server.Transfer("~/erro.aspx");
            }

            EdicaoDona dadosFuncionario = new EdicaoDona();
            funcionario = dadosFuncionario.mostrarDadosFuncionario(funcionarioQuery);

            hpAtribuirServicos.NavigateUrl = "dona_funcionario_atribuicao_servicos.aspx?cdfuncionario=" + funcionario.Codigo;
            hpAtribuirServicos.Text = "Atribuir serviço(s) para " + funcionario.Nome.ToString().Split(' ')[0];
            hpAtribuirServicos.ForeColor = System.Drawing.ColorTranslator.FromHtml("#b36684");

            hpEditarHorario.NavigateUrl = "dona_funcionario_adicionar_horario_servico.aspx?cdfuncionario=" + funcionario.Codigo;
            hpEditarHorario.Text = "Atribuir horário(s) para " + funcionario.Nome.ToString().Split(' ')[0];
            hpEditarHorario.ForeColor = System.Drawing.ColorTranslator.FromHtml("#b36684");

            carregarImagemFuncionario();

            if (funcionario.Codigo == 1)
            {
                btnExcluirFuncionario.Enabled = false;
            }

            if (!IsPostBack)
            {
                try
                {
                    funcionario = dadosFuncionario.mostrarDadosFuncionario(funcionarioQuery);

                    txtCodFuncionario.Text = funcionario.Codigo.ToString();
                    txtNomeCompletoFuncionario.Text = funcionario.Nome.ToString();
                    txtEmailFuncionario.Text = funcionario.Email.ToString();

                    using (MySqlDataReader reader = dadosFuncionario.listarTipoFuncionarioEEspecifico(funcionarioQuery))
                    {
                        if (reader != null)
                        {
                            cmbTipoFuncionario.DataSource = reader;
                            cmbTipoFuncionario.DataTextField = "nm_tipo_funcionario_pCodFuncionario";
                            cmbTipoFuncionario.DataValueField = "cd_tipo_funcionario";
                            cmbTipoFuncionario.DataBind();

                            cmbTipoFuncionario.SelectedIndex = funcionario.TipoFuncionario.Codigo - 1;
                        }
                        reader.Close();
                        dadosFuncionario.FecharConexao();
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

        protected void btnEditarFuncionario_Click(object sender, EventArgs e)
        {
            try
            {
                EdicaoDona edicaoDadosFuncionarios = new EdicaoDona();

                funcionario = edicaoDadosFuncionarios.mostrarDadosFuncionario(funcionarioQuery);

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

                else if (txtEmailFuncionario.Text != funcionario.Email.ToString() || txtNomeCompletoFuncionario.Text != funcionario.Nome.ToString() || cmbTipoFuncionario.SelectedIndex != funcionario.TipoFuncionario.Codigo - 1)
                {
                    edicaoDadosFuncionarios.editarDadosFuncionarios(funcionarioQuery, txtNomeCompletoFuncionario.Text, txtEmailFuncionario.Text, (cmbTipoFuncionario.SelectedIndex + 1).ToString());
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
        }

        protected void btnExcluirFuncionario_Click(object sender, EventArgs e)
        {
            pnlConfirmarExclusao.Visible = true;
        }

        protected void btnSim_Click(object sender, EventArgs e)
        {
            try
            {
                EdicaoDona excluirFuncionario = new EdicaoDona();
                Funcionario funcionarioExcluido = excluirFuncionario.excluirFuncionario(funcionario.Codigo.ToString());

                string caminhoBase = Request.PhysicalApplicationPath + @"\imagens\";
                string imagemCaminho = funcionarioExcluido.Imagem.Pasta + "\\" + funcionarioExcluido.Imagem.Nome;

                if (File.Exists(Path.Combine(caminhoBase, imagemCaminho)))
                {
                    File.Delete(Path.Combine(caminhoBase, imagemCaminho));
                }

                Response.Redirect("dona_funcionarios.aspx");
            }
            catch
            {
                if (funcionario.Codigo == 1)
                {
                    HttpContext.Current.Items["ErroTipo"] = "403 - Acesso negado";
                    HttpContext.Current.Items["ErroMensagem"] = "Não se pode deletar o usuário padrão administrador.";
                    Server.Transfer("~/erro.aspx");
                }
            }
        }

        protected void btnNao_Click(object sender, EventArgs e)
        {
            pnlConfirmarExclusao.Visible = false;
        }

        protected void btnSubstituirImagem_Click(object sender, EventArgs e)
        {
            if (flUploadRecompensaCupom.PostedFile != null)
            {
                string NomeOriginalArq = Path.GetFileName(flUploadRecompensaCupom.PostedFile.FileName);

                string TipoArq = flUploadRecompensaCupom.PostedFile.ContentType;

                if (NomeOriginalArq == "")
                {
                    litAviso.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> Nenhum arquivo foi selecionado.</p></div>";
                    return;
                }

                if (TipoArq != "image/jpeg" && TipoArq != "image/jpg" && TipoArq != "image/png")
                {
                    litAviso.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> Arquivo não permitido! Somente jpeg, jpg ou png.</p></div>";
                    return;
                }

                int TamanhoArq = flUploadRecompensaCupom.PostedFile.ContentLength;

                if (TamanhoArq <= 0)
                    litAviso.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> A tentativa de upLoad do arquivo " + NomeOriginalArq + " falhou!</p></div>";

                else
                {
                    string novoNome = novoNome = NovoNomeArquivo(funcionario.Imagem.Nome);
                    string imagemAntiga = Request.PhysicalApplicationPath + @"imagens\\" + funcionario.Imagem.Pasta + "\\" + funcionario.Imagem.Nome;

                    if (File.Exists(imagemAntiga))
                    {
                        File.Delete(imagemAntiga);
                    }

                    flUploadRecompensaCupom.PostedFile.SaveAs(Request.PhysicalApplicationPath + @"imagens\\Funcionarios\\" + novoNome);
                    litAviso.Text = "";

                    ManipulacaoImagemFuncionario substituicaodeImagem = new ManipulacaoImagemFuncionario();
                    substituicaodeImagem.substituirImagem("Funcionarios", novoNome, funcionarioQuery.ToString());

                    Response.Redirect(Request.RawUrl);
                    //Response.Redirect("dona_servico_expandido.aspx?servico" + Request["servico"].ToString());
                }
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