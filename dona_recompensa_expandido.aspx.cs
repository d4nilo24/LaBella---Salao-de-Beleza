using prjTCC.Classe;
using prjTCC.Lógica;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Management;
using System.Web.Services.Description;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace prjTCC
{
    public partial class dona_recompensa_expandido : System.Web.UI.Page
    {
        Premio recompensa = new Premio();
        string recompensaQuery = null;
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
            else
            {
                if (Request.QueryString.Get("cdrecompensa") != null)
                {
                    recompensaQuery = Request.QueryString.Get("cdrecompensa");
                }
                else
                {
                    HttpContext.Current.Items["ErroTipo"] = "404 - Página não encontrada";
                    HttpContext.Current.Items["ErroMensagem"] = "Não foi encontrada nenhum prêmio.";
                    Server.Transfer("~/erro.aspx");
                }
            }
                

            /*if (recompensaQuery == null)
            {
                Response.Redirect("dona_recompensas.aspx");
            }*/
            

            EdicaoDona dadosRecompensa = new EdicaoDona();
            recompensa = dadosRecompensa.mostrarDadosRecompensa(recompensaQuery);
            carregarImagens();
            
            if (!IsPostBack)
            {
                if (recompensa.TipoPremio.Nome == "Produto")
                {
                    if (recompensa.Imagem != null)
                        btnAdicionaImagemProduto.Text = "Substituir Imagem";

                    pnlFormProduto.Visible = true;

                    txtCodPremioProduto.Text = recompensa.Codigo.ToString();
                    txtNomeTipoRecompensaProduto.Text = recompensa.TipoPremio.Nome;
                    txtNomeRecompensaProduto.Text = recompensa.Nome;
                    txtPontosNecesariosProduto.Text = recompensa.Pontos.ToString();
                    txtxDescricaoProduto.Text = recompensa.Descricao;

                    carregarImagens();
                }

                else
                {
                    if (recompensa.Imagem != null)
                        btnAdicionarImagem.Text = "Substituir Imagem";

                    pnlFormCupom.Visible = true;

                    txtCodPremioCupom.Text = recompensa.Codigo.ToString();
                    txtNomePremio.Text = recompensa.Nome;
                    txtTipoRecompensa.Text = recompensa.TipoPremio.Nome;
                    txtCodCupomDesconto.Text = recompensa.Cupom.Codigo.ToString();
                    txtPorcentagemCupomDesconto.Text = recompensa.Cupom.Valor.ToString();
                    txtDescricaoCupomDesconto.Text = recompensa.Descricao;
                    ListarTodosServicos listaDeServicos = new ListarTodosServicos();
                    using (MySqlDataReader dados = listaDeServicos.ListarServicosCmb())
                    {
                        
                        if (dados != null)
                        {
                            cmbServicoCupom.DataSource = dados;
                            cmbServicoCupom.DataValueField = "cd_servico";
                            cmbServicoCupom.DataTextField = "nm_servico";
                            cmbServicoCupom.DataBind();
                        }
                        dados.Close();
                        listaDeServicos.FecharConexao();

                        cmbServicoCupom.Items.Insert(0, new ListItem("Nenhum serviço.", "0"));
                        if (recompensa.Servico != null)
                        {
                            cmbServicoCupom.SelectedValue = recompensa.Servico.Codigo.ToString();
                        }
                        else
                        {
                            cmbServicoCupom.SelectedValue = "0";
                        }
                    }
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

                        cmbCategoria.Items.Insert(0, new ListItem("Nenhuma categoria.","0"));
                        if (recompensa.Categoria != null)
                        {
                            cmbCategoria.SelectedValue = recompensa.Categoria.Codigo.ToString();
                        }
                        else
                        {
                            cmbCategoria.SelectedValue = "0";
                        }
                    }
                    txtNomePremio.Text = recompensa.Nome;
                    txtPontoNecessariosCupomDesconto.Text = recompensa.Pontos.ToString();
                    txtDescricaoCupomDesconto.Text = recompensa.Descricao;

                    carregarImagens();
                }
            }
        }

        string caminhoBase = "";
        void carregarImagens()
        {
            pnlListaImagens.Controls.Clear();
            pnlListaImagensProduto.Controls.Clear();

            if (recompensa.Imagem == null)
            {
                EdicaoDona dadosRecompensa = new EdicaoDona();
                recompensa = dadosRecompensa.mostrarDadosRecompensa(recompensaQuery);
            }

            else
            {
                caminhoBase = Request.PhysicalApplicationPath + @"imagens\" + recompensa.Imagem.Pasta;

                string caminhoDaImagem = Path.Combine(caminhoBase, recompensa.Imagem.Nome);
                if (File.Exists(caminhoDaImagem))
                {
                    string imagemTag = $"imagens/{recompensa.Imagem.Pasta}/{recompensa.Imagem.Nome}";

                    Panel panel = new Panel();
                    panel.CssClass = "pnlImagens";

                    Image image = new Image();
                    image.ImageUrl = imagemTag;
  
                    panel.Controls.Add(image);

                    if (pnlFormCupom.Visible)
                        pnlListaImagens.Controls.Add(panel);

                    else
                        pnlListaImagensProduto.Controls.Add(panel);
                }
            }

            Panel fimFloat = new Panel();
            fimFloat.ID = "limparFloat";
            fimFloat.CssClass = "cls";
            pnlListaImagens.Controls.Add(fimFloat);
        }

        protected void btnAdicionarImagem_Click(object sender, EventArgs e)
        {
            if (flUploadRecompensaCupom.PostedFile != null)
            {
                string NomeOriginalArq = Path.GetFileName(flUploadRecompensaCupom.PostedFile.FileName);

                string TipoArq = flUploadRecompensaCupom.PostedFile.ContentType;

                if (NomeOriginalArq == "")
                {
                    litAvisoCupomDesconto.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> Nenhum arquivo foi selecionado.</p></div>";
                    return;
                }

                if (TipoArq != "image/jpeg" && TipoArq != "image/jpg" && TipoArq != "image/png")
                {
                    litAvisoCupomDesconto.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> Arquivo não permitido! Somente jpeg, jpg ou png.</p></div>";
                    return;
                }

                int TamanhoArq = flUploadRecompensaCupom.PostedFile.ContentLength;

                if (TamanhoArq <= 0)
                    litAvisoCupomDesconto.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> A tentativa de upLoad do arquivo " + NomeOriginalArq + " falhou!</p></div>";

                else
                {
                    string novoNome = NovoNomeArquivo(recompensa.Imagem.Nome);
                    string imagemAntiga = Request.PhysicalApplicationPath + @"imagens\\" + recompensa.Imagem.Pasta + "\\" + recompensa.Imagem.Nome;
                    
                    if (File.Exists(imagemAntiga))
                    {
                        File.Delete(imagemAntiga);
                    }

                    flUploadRecompensaCupom.PostedFile.SaveAs(Request.PhysicalApplicationPath + @"imagens\\Premios\\" + novoNome);
                    litAvisoCupomDesconto.Text = "";

                    ManipulacaoImagemRecompensa substituicaodeImagem = new ManipulacaoImagemRecompensa();
                    substituicaodeImagem.substituirImagem("Premios", novoNome, recompensaQuery.ToString());

                    carregarImagens();
                    Response.Redirect(Request.RawUrl);
                    //Response.Redirect("dona_servico_expandido.aspx?servico" + Request["servico"].ToString());
                }
            }
        }

        protected void btnEditarProduto_Click(object sender, EventArgs e)
        {
            EdicaoDona edicaoPremioProduto = new EdicaoDona();

            if (string.IsNullOrEmpty(txtNomeRecompensaProduto.Text))
            {
                litAvisoProduto.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> O nome do prêmio não pode ficar vazio!</p></div>";
                txtNomeRecompensaProduto.Focus();
                return;
            }   

            else if (string.IsNullOrEmpty(txtPontosNecesariosProduto.Text))
            {
                litAvisoProduto.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> A quantidade de pontos não pode ficar vazia!</p></div>";
                txtPontosNecesariosProduto.Focus();
                return;
            }

            else if (string.IsNullOrEmpty(txtxDescricaoProduto.Text))
            {
                litAvisoProduto.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> A descrição não pode ficar vazia!</p></div>";
                txtxDescricaoProduto.Focus();
                return;
            }

            else
            {
                if (txtNomeRecompensaProduto.Text == recompensa.Nome && txtPontosNecesariosProduto.Text == recompensa.Pontos.ToString() && txtxDescricaoProduto.Text == recompensa.Descricao)
                {
                    litAvisoProduto.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> Nenhum dado foi alterado.</p></div>";
                    txtNomeRecompensaProduto.Focus();
                    return;
                }

                else
                {
                    edicaoPremioProduto.editarDadosProdutoPremio(recompensaQuery.ToString(), txtNomeRecompensaProduto.Text, txtPontosNecesariosProduto.Text, txtxDescricaoProduto.Text);
                    litAvisoProduto.Text = "<div class='acerto'><p><i class=\"fa-solid fa-check\"></i> Dado(s) alterado(s) com sucesso</p></div>";
                    return;
                }
            }
        }

        protected void btnEditarRecompensaCupom_Click1(object sender, EventArgs e)
        {
            EdicaoDona edicaoPremioCupom = new EdicaoDona();

            if (string.IsNullOrEmpty(txtNomePremio.Text))
            {
                litAvisoCupomDesconto.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> O nome do prêmio não pode ficar vazio!</p></div>";
                txtNomePremio.Focus();
                return;
            }

            else if (string.IsNullOrEmpty(cmbServicoCupom.SelectedValue))
            {
                litAvisoCupomDesconto.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> O serviço não pode ficar vazio!</p></div>";
                cmbServicoCupom.Focus();
                return;
            }

            else if (string.IsNullOrEmpty(txtPorcentagemCupomDesconto.Text))
            {
                litAvisoCupomDesconto.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> O valor do desconto não pode ficar vazio!</p></div>";
                txtPorcentagemCupomDesconto.Focus();
                return;
            }

            else if (string.IsNullOrEmpty(txtPontoNecessariosCupomDesconto.Text))
            {
                litAvisoCupomDesconto.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> A quantidade de pontos não pode ficar vazia!</p></div>";
                txtPontoNecessariosCupomDesconto.Focus();
                return;
            }

            else if (string.IsNullOrEmpty(txtDescricaoCupomDesconto.Text))
            {
                litAvisoCupomDesconto.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> A quantidade de pontos não pode ficar vazia!</p></div>";
                txtDescricaoCupomDesconto.Focus();
                return;
            }
            else if (cmbServicoCupom.SelectedValue == "0" && cmbCategoria.SelectedValue == "0")
            {

                litAvisoCupomDesconto.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> É preciso ao menos algum serviço ou categoria atrelado ao cumpom</p></div>";
                cmbServicoCupom.Focus();
                return;
            }

            else
            {
                if (txtNomePremio.Text == recompensa.Nome && (recompensa.Servico != null ? cmbServicoCupom.SelectedValue == recompensa.Servico.Codigo.ToString() : cmbServicoCupom.SelectedValue == "0") && (recompensa.Categoria != null ? cmbCategoria.SelectedValue == recompensa.Categoria.Codigo.ToString() : cmbCategoria.SelectedValue == "0") && txtPorcentagemCupomDesconto.Text == recompensa.Cupom.Valor.ToString() && txtPontoNecessariosCupomDesconto.Text == recompensa.Pontos.ToString() && txtDescricaoCupomDesconto.Text == recompensa.Descricao)
                {
                    litAvisoCupomDesconto.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> Nenhum dado foi alterado.</p></div>";
                    txtNomePremio.Focus();
                    return;
                }

                else
                {
                   if (cmbServicoCupom.SelectedValue == "0")
                    {
                        edicaoPremioCupom.editarDadosCupomDescontoPremio(recompensaQuery.ToString(), txtNomePremio.Text, null, cmbCategoria.SelectedValue, txtPorcentagemCupomDesconto.Text, txtPontoNecessariosCupomDesconto.Text, txtDescricaoCupomDesconto.Text);
                    }
                   else if (cmbCategoria.SelectedValue == "0")
                    {
                        edicaoPremioCupom.editarDadosCupomDescontoPremio(recompensaQuery.ToString(), txtNomePremio.Text, cmbServicoCupom.SelectedValue, null, txtPorcentagemCupomDesconto.Text, txtPontoNecessariosCupomDesconto.Text, txtDescricaoCupomDesconto.Text);
                    }
                   else
                    {
                        edicaoPremioCupom.editarDadosCupomDescontoPremio(recompensaQuery.ToString(), txtNomePremio.Text, cmbServicoCupom.SelectedValue, cmbCategoria.SelectedValue, txtPorcentagemCupomDesconto.Text, txtPontoNecessariosCupomDesconto.Text, txtDescricaoCupomDesconto.Text);
                    }

                    recompensa = edicaoPremioCupom.mostrarDadosRecompensa(recompensaQuery);
                    txtCodCupomDesconto.Text = recompensa.Cupom.Codigo.ToString();
                    litAvisoCupomDesconto.Text = "<div class='acerto'><p><i class=\"fa-solid fa-check\"></i> Dado(s) alterado(s) com sucesso</p></div>";
                    return;
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

        protected void btnExcluirRecompensaCupom_Click(object sender, EventArgs e)
        {
            pnlConfirmarExclusao.Visible = true;
        }

        protected void btnSim_Click(object sender, EventArgs e)
        {
            try
            {
                EdicaoDona excluirRecompensa = new EdicaoDona();
                Premio recompensaExcluida = excluirRecompensa.excluirRecompensa(recompensa.Codigo.ToString());

                string caminhoBase = Request.PhysicalApplicationPath + @"\imagens\";
                string imagemCaminho = recompensaExcluida.Imagem.Pasta + "\\" + recompensaExcluida.Imagem.Nome;

                if (File.Exists(Path.Combine(caminhoBase, imagemCaminho)))
                {
                    File.Delete(Path.Combine(caminhoBase, imagemCaminho));
                }

                Response.Redirect("dona_recompensas.aspx");
            }
            catch
            {
                HttpContext.Current.Items["ErroTipo"] = "500 - Erro no servidor interno";
                HttpContext.Current.Items["ErroMensagem"] = "Houve um erro ao deletar a recompensa.";
                Server.Transfer("~/erro.aspx");
            }
        }

        protected void btnNao_Click(object sender, EventArgs e)
        {
            pnlConfirmarExclusao.Visible = false;
        }

        protected void btnAdicionaImagemProduto_Click(object sender, EventArgs e)
        {
            if (flUploadRecompensaProduto.PostedFile != null)
            {
                string NomeOriginalArq = Path.GetFileName(flUploadRecompensaProduto.PostedFile.FileName);

                string TipoArq = flUploadRecompensaProduto.PostedFile.ContentType;

                if (NomeOriginalArq == "")
                {
                    litAvisoProduto.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> Nenhum arquivo foi selecionado.</p></div>";
                    return;
                }

                if (TipoArq != "image/jpeg" && TipoArq != "image/jpg" && TipoArq != "image/png")
                {
                    litAvisoProduto.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> Arquivo não permitido! Somente jpeg, jpg ou png.</p></div>";
                    return;
                }

                int TamanhoArq = flUploadRecompensaProduto.PostedFile.ContentLength;

                if (TamanhoArq <= 0)
                    litAvisoProduto.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> A tentativa de upLoad do arquivo " + NomeOriginalArq + " falhou!</p></div>";

                else
                {
                    string novoNome = NovoNomeArquivo(recompensa.Imagem.Nome);
                    string imagemAntiga = Request.PhysicalApplicationPath + @"imagens\\" + recompensa.Imagem.Pasta + "\\" + recompensa.Imagem.Nome;

                    if (File.Exists(imagemAntiga))
                    {
                        File.Delete(imagemAntiga);
                    }

                    flUploadRecompensaProduto.PostedFile.SaveAs(Request.PhysicalApplicationPath + @"imagens\\Premios\\" + novoNome);
                    litAvisoProduto.Text = "";

                    ManipulacaoImagemRecompensa substituicaodeImagem = new ManipulacaoImagemRecompensa();
                    substituicaodeImagem.substituirImagem("Premios", novoNome, recompensaQuery.ToString());

                    carregarImagens();
                    Response.Redirect(Request.RawUrl);
                    //Response.Redirect("dona_servico_expandido.aspx?servico" + Request["servico"].ToString());
                }
            }
        }

        /*public void BotaoClick(object sender, CommandEventArgs e)
        {
            caminhoBase = Request.PhysicalApplicationPath + @"\imagens\";
            string imagem = "Premios\\" + e.CommandArgument.ToString();

            if (File.Exists(Path.Combine(caminhoBase, imagem)))
            {
                File.Delete(Path.Combine(caminhoBase, imagem));

                ManipulacaoImagemServico deletaImagem = new ManipulacaoImagemServico();
                deletaImagem.deletarImagem("Premios", e.CommandArgument.ToString(), Request["servico"].ToString());
                Response.Redirect(Request.RawUrl);
            }

            EdicaoDona listarDadosServico = new EdicaoDona();
            servico = listarDadosServico.MostrarDadosServico(Request["servico"].ToString());
            carregarImagens();
        }*/
    }
}