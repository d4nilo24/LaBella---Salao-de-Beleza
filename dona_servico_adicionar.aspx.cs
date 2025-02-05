using prjTCC.Classe;
using prjTCC.Lógica;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Principal;
using System.IO;



namespace prjTCC
{
    public partial class dona_servico_adicionar : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            listaCategorias();
        }
        void listaCategorias()
        {
            if (!IsPostBack)
            {
                ListaCategoria criarCategorias = new ListaCategoria();

                ddlCategoria.Items.Insert(0, "Selecione uma Categoria");
                foreach (Categoria categoria in criarCategorias.ListarCategorias(false))
                {
                    ddlCategoria.Items.Add(categoria.Nome);
                }
            }
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("dona_servicos.aspx");
        }

        protected void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (fluImagem.HasFiles)
            {
                foreach (var file in fluImagem.PostedFiles)
                {
                    string TipoArq = file.ContentType;
                    if (TipoArq != "image/jpeg" && TipoArq != "image/jpg" && TipoArq != "image/png")
                    {
                        lblObs.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> Arquivo não permitido! Somente jpeg, jpg ou png.</p></div>";
                        return;
                    }

                    int TamanhoArq = file.ContentLength;

                    if (TamanhoArq <= 0)
                    {
                        lblObs.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> A tentativa de upLoad do arquivo " + file.FileName + " falhou!</p></div>";
                        return;
                    }
                }
            }

            if (String.IsNullOrEmpty(txtNomeServico.Text.Trim()))
            {
                litAviso.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> O campo Nome não pode estar vazio</p></div>";
                txtNomeServico.Text = "";
                txtNomeServico.Focus();
                return;
            }
            else if (String.IsNullOrEmpty(txtValor.Text.Trim()))
            {
                litAviso.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> O campo Valor não pode estar vazio</p></div>";
                txtValor.Text = "";
                txtValor.Focus();
                return;
            }
            else if (String.IsNullOrEmpty(txtDuracao.Text.Trim()))
            {
                litAviso.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> O campo Duração não pode estar vazio</p></div>";
                txtDuracao.Text = "";
                txtDuracao.Focus();
                return;
            }
            else if (String.IsNullOrEmpty(txtPontos.Text.Trim()))
            {
                litAviso.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> O campo Pontos não pode estar vazio</p></div>";
                txtPontos.Text = "";
                txtPontos.Focus();
                return;
            }
            else if (fluImagem.PostedFiles.Count > 9 )
            {
                litAviso.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> Só é possível colocar até 9 imagens de uma vez.</p></div>";
                fluImagem.Focus();
                return;
            }
            else
            {
                string nomeservico = txtNomeServico.Text;
                int codigocategoria = ddlCategoria.SelectedIndex;
                string tempo = txtDuracao.Text;
                string textodescricao = txtDescricao.Text;
                double valor = double.Parse(txtValor.Text);
                int pontos = int.Parse(txtPontos.Text);

                if (codigocategoria == 0)
                {
                    litAviso.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> Por favor selecione uma categoria valida</p></div>";
                    ddlCategoria.Focus();
                    return;
                }
                else
                {
                    adcionarServico adServico = new adcionarServico();
                    AdicionarImagem adImagem = new AdicionarImagem();
                    Servico servico = adServico.AdcionarServico(nomeservico, textodescricao, valor, tempo, codigocategoria, pontos);
                    
                    if (fluImagem.HasFiles)
                    {
                        

                        //List<HttpPostedFile> arquivos = new List<HttpPostedFile>();
                        List<string> arquivos = new List<string>();

                        foreach (var file in fluImagem.PostedFiles)
                        {
                            string nomeArquivo = Path.GetFileName(file.FileName);
                            string novoNomeArquivo = NovoNomeArquivo(nomeArquivo);
                            string caminhoArquivo = Server.MapPath("~/imagens/Servicos/" + novoNomeArquivo);
                            file.SaveAs(caminhoArquivo);

                            arquivos.Add(novoNomeArquivo);
                        }
                        adServico.ImagemServico(servico.Codigo.ToString(), arquivos, "Servicos");
                    }
                    Response.Redirect("dona_servicos.aspx");
                }
            }
        }
        string NovoNomeArquivo (string nomeArquivo)
        {
            string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            string extensao = Path.GetExtension(nomeArquivo);
            string nome = Path.GetFileNameWithoutExtension(nomeArquivo);
            return nome + timestamp + extensao;
        }
    }
}