using prjTCC.Classe;
using prjTCC.Lógica;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace prjTCC
{
    public partial class dona_servico_expandido : System.Web.UI.Page
    {

        Servico servico = new Servico();

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
                AtualizarDados();
            }
            else
            {
                carregarImagens();
            }
        }
        void AtualizarDados()
        {
            EdicaoDona listarDadosServico = new EdicaoDona();
            servico = listarDadosServico.MostrarDadosServico(Request["servico"].ToString());
            carregarImagens();
            txtCodigoServico.Text = servico.Codigo.ToString();
            txtNomeServico.Text = servico.Nome;
            txtServicoValor.Text = servico.Valor.ToString();
            txtDescricaoServico.Text = servico.Descricao.ToString();
            txtDuracaoServico.Text = servico.Duracao.ToString();
            txtPontos.Text = servico.Pontos.ToString();
            ListarCategoriaCmb listarCategoria = new ListarCategoriaCmb();

            using (MySqlDataReader reader = listarCategoria.ListarCategorias())
            {
                if (reader != null)
                {
                    cmbCategoria.DataSource = reader;
                    cmbCategoria.DataTextField = "nm_categoria_servico";
                    cmbCategoria.DataValueField = "cd_categoria_servico";
                    cmbCategoria.DataBind();
                }
                reader.Close();
                listarCategoria.FecharConexao();
            }
            cmbCategoria.SelectedValue = servico.Categoria.Codigo.ToString();
            //txtCategoriaServico.Text = servico.Categoria.Nome.ToString();
            txtCodigoCategoria.Text = servico.Categoria.Codigo.ToString();
            
        }

        string caminhoBase = "";

        void carregarImagens()
        {
            pnlListaImagens.Controls.Clear();

            if (servico.Imagem == null)
            {
                EdicaoDona listarDadosServico = new EdicaoDona();
                servico = listarDadosServico.MostrarDadosServico(Request["servico"].ToString());
            }

            for (int i = 0; i < servico.Imagem.Count; i++)
            {
                caminhoBase = Request.PhysicalApplicationPath + @"imagens\" + servico.Imagem[i].Pasta;

                string caminhoDaImagem = Path.Combine(caminhoBase, servico.Imagem[i].Nome);

                if (File.Exists(caminhoDaImagem))
                {
                    string imagemTag = $"imagens/{servico.Imagem[i].Pasta}/{servico.Imagem[i].Nome}";

                    Panel panel = new Panel();
                    panel.CssClass = "pnlImagens";

                    Button botao = new Button();
                    botao.CssClass = "btnDeletaImagem block";
                    botao.Text = "X";
                    botao.CommandArgument = servico.Imagem[i].Nome;
                    botao.Command += BotaoClick;

                    Image image = new Image();
                    image.ImageUrl = imagemTag;

                    Button btnSetar = new Button();
                    btnSetar.CssClass = "botoes";
                    btnSetar.Text = "Tornar principal";
                    btnSetar.CommandArgument = servico.Imagem[i].Nome;
                    btnSetar.Command += BotaoTornarPrincpial;

                    panel.Controls.Add(botao);
                    panel.Controls.Add(image);
                    panel.Controls.Add(btnSetar);

                    pnlListaImagens.Controls.Add(panel);
                }
            }

            Panel fimFloat = new Panel();
            fimFloat.ID = "limparFloat";
            fimFloat.CssClass = "cls";
            pnlListaImagens.Controls.Add(fimFloat);
        }

        public void BotaoClick(object sender, CommandEventArgs e)
        {
            caminhoBase = Request.PhysicalApplicationPath + @"\imagens\";
            string imagem = "Servicos\\" + e.CommandArgument.ToString();

            if (File.Exists(Path.Combine(caminhoBase, imagem)))
            {
                File.Delete(Path.Combine(caminhoBase, imagem));

                ManipulacaoImagemServico deletaImagem = new ManipulacaoImagemServico();
                deletaImagem.deletarImagem("Servicos", e.CommandArgument.ToString(), Request["servico"].ToString());
                Response.Redirect(Request.RawUrl);
            }

            EdicaoDona listarDadosServico = new EdicaoDona();
            servico = listarDadosServico.MostrarDadosServico(Request["servico"].ToString());
            carregarImagens();
        }

        public void BotaoTornarPrincpial(object sender, CommandEventArgs e)
        {
            caminhoBase = Request.PhysicalApplicationPath + @"\imagens/";
            string imagem = "Servicos\\" + e.CommandArgument.ToString();

            if (File.Exists(Path.Combine(caminhoBase, imagem)))
            {
                ManipulacaoImagemServico tornaImagemPrincipal = new ManipulacaoImagemServico();
                tornaImagemPrincipal.tornarImagemPrincipal("Servicos", e.CommandArgument.ToString(), Request["servico"].ToString());
                Response.Redirect(Request.RawUrl);
            }
        }

        protected void btnAdicionarImagem_Click(object sender, EventArgs e)
        {
            if (flImagensServico.PostedFile != null)
            {
                string NomeOriginalArq = Path.GetFileName(flImagensServico.PostedFile.FileName);

                string TipoArq = flImagensServico.PostedFile.ContentType;

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

                int TamanhoArq = flImagensServico.PostedFile.ContentLength;

                if (TamanhoArq <= 0)
                    litAviso.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> A tentativa de upLoad do arquivo " + NomeOriginalArq + " falhou!</p></div>";

                else
                {
                    flImagensServico.PostedFile.SaveAs(Request.PhysicalApplicationPath + @"imagens\\Servicos\\" + NomeOriginalArq);
                    litAviso.Text = "";
                    carregarImagens();

                    try
                    {
                        ManipulacaoImagemServico armazenaImagem = new ManipulacaoImagemServico();
                        armazenaImagem.adicionarImagem("Servicos", NomeOriginalArq, Request["servico"].ToString());
                    }
                    catch (Exception)
                    {
                        litAviso.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> Não foi possível adicionar a imagem. Tente alterar o nome dela.</p></div>";
                        return;
                    }

                    Response.Redirect(Request.RawUrl);
                    //Response.Redirect("dona_servico_expandido.aspx?servico" + Request["servico"].ToString());
                }
            }
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                EdicaoDona edicaoServico = new EdicaoDona();

                servico = edicaoServico.MostrarDadosServico(Request["servico"].ToString());

                if (String.IsNullOrEmpty(txtNomeServico.Text))
                {
                    litAviso.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> Nome não pode ficar vazio</p></div>";
                    txtNomeServico.Focus();
                    return;
                }

                else if (String.IsNullOrEmpty(txtServicoValor.Text))
                {
                    litAviso.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> Valor não pode ficar vazio</p></div>";
                    txtServicoValor.Focus();
                    return;
                }
                else if (!String.IsNullOrEmpty(txtServicoValor.Text))
                {
                    try
                    {
                        double.Parse(txtServicoValor.Text);
                    }
                    catch
                    {
                        litAviso.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> Valor não é numérico</p></div>";
                        txtServicoValor.Focus();
                        return;
                    }
                }

                if (String.IsNullOrEmpty(txtDescricaoServico.Text))
                {
                    litAviso.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> Descrição não pode ficar vazia</p></div>";
                    txtDescricaoServico.Focus();
                    return;
                }

                else if (String.IsNullOrEmpty(txtDuracaoServico.Text))
                {
                    litAviso.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> Duração não pode ficar vazia</p></div>";
                    txtDuracaoServico.Focus();
                    return;
                }

                else if (txtNomeServico.Text != servico.Nome.ToString() || txtServicoValor.Text != servico.Valor.ToString() || txtDescricaoServico.Text != servico.Descricao.ToString() || txtDuracaoServico.Text != servico.Duracao.ToString() || cmbCategoria.SelectedValue != servico.Categoria.Codigo.ToString() || txtPontos.Text != servico.Pontos.ToString())
                {
                    edicaoServico.editarDadosServico(Request["servico"].ToString(), txtNomeServico.Text, txtDescricaoServico.Text, double.Parse(txtServicoValor.Text.Replace(",", ".")), txtDuracaoServico.Text, cmbCategoria.SelectedValue, txtPontos.Text);
                    litAviso.Text = "<div class='acerto'><p><i class=\"fa-solid fa-check\"></i> Dado(s) alterado(s) com sucesso</p></div>";
                    AtualizarDados();
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

        protected void btnExcluir_Click(object sender, EventArgs e)
        {
            pnlConfirmarExclusao.Visible = true;
        }

        protected void btnSim_Click(object sender, EventArgs e)
        {
            EdicaoDona excluirServico = new EdicaoDona();
            Servico servicoExcluido = excluirServico.excluirServico(servico.Codigo.ToString());
            foreach (Imagem imagem  in servicoExcluido.Imagem)
            {
                caminhoBase = Request.PhysicalApplicationPath + @"\imagens\";
                string imagemCaminho = imagem.Pasta + "\\" + imagem.Nome;

                if (File.Exists(Path.Combine(caminhoBase, imagemCaminho)))
                {
                    File.Delete(Path.Combine(caminhoBase, imagemCaminho));
                }
            }
            Response.Redirect("dona_servicos.aspx");   
        }

        protected void btnNao_Click(object sender, EventArgs e)
        {
            pnlConfirmarExclusao.Visible = false;
        }
    }
}