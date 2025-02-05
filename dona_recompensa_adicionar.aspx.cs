using prjTCC.Classe;
using prjTCC.Lógica;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace prjTCC
{
    public partial class dona_recompensa_adicionar : System.Web.UI.Page
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

            else
            {
                if (!IsPostBack)
                {
                    adicaoRecompensa produtosDisponiveis = new adicaoRecompensa();

                    cmbTipoRecompensa.DataSource = produtosDisponiveis.escolherTipoPremio();
                    cmbTipoRecompensa.DataTextField = "nm_tipo_premio";
                    cmbTipoRecompensa.DataValueField = "cd_tipo_premio";
                    cmbTipoRecompensa.DataBind();
                    cmbTipoRecompensa.Items.Insert(0, new ListItem("Escolha um tipo de prêmio", "0"));

                    cmbProdutosRecompensa.DataSource = produtosDisponiveis.escolherProdutoRecompensa();
                    cmbProdutosRecompensa.DataTextField = "nm_produto";
                    cmbProdutosRecompensa.DataValueField = "cd_produto";
                    cmbProdutosRecompensa.DataBind();
                }

                adicaoRecompensa produtosDisponiveis2 = new adicaoRecompensa();

                cmbServicoAtribuidoCupom.DataSource = produtosDisponiveis2.escolherServico();
                cmbServicoAtribuidoCupom.DataTextField = "nm_servico";
                cmbServicoAtribuidoCupom.DataValueField = "cd_servico";
                cmbServicoAtribuidoCupom.DataBind();
                cmbServicoAtribuidoCupom.Items.Insert(0, new ListItem("Escolha serviço do cupom", "0"));

                cmbCategoriaServicoAtribuidoCupom.DataSource = produtosDisponiveis2.escolherCategoriaServico();
                cmbCategoriaServicoAtribuidoCupom.DataTextField = "nm_categoria_servico";
                cmbCategoriaServicoAtribuidoCupom.DataValueField = "cd_categoria_servico";
                cmbCategoriaServicoAtribuidoCupom.DataBind();
                cmbCategoriaServicoAtribuidoCupom.Items.Insert(0, new ListItem("Escolha uma categoria do cupom", "0"));

                /*cmbCupons.DataSource = produtosDisponiveis2.escolherCupom();
                cmbCupons.DataTextField = "vl_porcentagem_de_desconto";
                cmbCupons.DataValueField = "cd_cupom_desconto";
                cmbCupons.DataBind();*/

                if (cmbTipoRecompensa.SelectedValue.ToString() == "2")
                {
                    pnlAdicaoRecompensaCupom.Visible = false;
                    pnlAdicaoRecompensaProduto.Visible = true;
                }

                else if (cmbTipoRecompensa.SelectedValue.ToString() == "1")
                {
                    pnlAdicaoRecompensaProduto.Visible = false;
                    pnlAdicaoRecompensaCupom.Visible = true;
                }
                else
                {
                    pnlAdicaoRecompensaProduto.Visible = false;
                    pnlAdicaoRecompensaCupom.Visible = false;
                }
            }
        }

        protected void btnAdicaoImagemPremioProduto_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtNomePremioProduto.Text))
            {
                litAvisoRecompensaProduto.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> Nome do prêmio não pode ficar vazio</p></div>";
                txtNomePremioProduto.Focus();
                return;
            }

            else if (String.IsNullOrEmpty(txtPontosNecessariosProduto.Text))
            {
                litAvisoRecompensaProduto.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> Pontos não pode ficar vazio</p></div>";
                txtPontosNecessariosProduto.Focus();
                return;
            }

            else if (String.IsNullOrEmpty(txtDescricaoPremioProduto.Text))
            {
                litAvisoRecompensaProduto.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> Descrição do prêmio não pode ficar vazia</p></div>";
                txtDescricaoPremioProduto.Focus();
                return;
            }

            else if (cmbProdutosRecompensa.SelectedIndex == 0)
            {
                litAvisoRecompensaProduto.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> Nenhum produto foi selecionado</p></div>";
                cmbProdutosRecompensa.Focus();
                return;
            }

            else if (fluImagem.PostedFile == null)
            {
                litAvisoRecompensaProduto.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> Adicione uma imagem</p></div>";
                fluImagem.Focus();
                return;
            }

            else
            {
                if (fluImagem.PostedFile != null)
                {
                    string NomeOriginalArq = Path.GetFileName(fluImagem.PostedFile.FileName);

                    string TipoArq = fluImagem.PostedFile.ContentType;

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

                    int TamanhoArq = fluImagem.PostedFile.ContentLength;

                    if (TamanhoArq <= 0)
                        litAviso.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> A tentativa de upLoad do arquivo " + NomeOriginalArq + " falhou!</p></div>";

                    else
                    {
                        string novoNomeArquivo = NovoNomeArquivo(NomeOriginalArq);
                        fluImagem.PostedFile.SaveAs(Request.PhysicalApplicationPath + @"imagens\\Premios\\" + novoNomeArquivo);
                        litAviso.Text = "";
                        //carregarImagemRecompensa();

                        try
                        {
                            adicaoRecompensa adicaoRecompensa = new adicaoRecompensa();
                            adicaoRecompensa.adicionarRecompensaProduto(cmbTipoRecompensa.SelectedValue.ToString(), cmbProdutosRecompensa.SelectedValue.ToString(), txtNomePremioProduto.Text, txtPontosNecessariosProduto.Text, txtDescricaoPremioProduto.Text, novoNomeArquivo, "Premios");
                        }

                        catch (Exception)
                        {
                            litAvisoRecompensaProduto.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> Já existe uma recompensa com essa imagem.</p></div>";
                            return;
                        }

                        Response.Redirect("dona_recompensas.aspx");
                    }
                }  
            }

            /*void carregarImagemRecompensa()
            {
                fluImagem.Controls.Clear();
                string caminhoBase = "";

                caminhoBase = Request.PhysicalApplicationPath + @"imagens\" + funcionario.Imagem.Pasta;
                string caminhoDaImagem = Path.Combine(caminhoBase, funcionario.Imagem.Nome);

                if (File.Exists(caminhoDaImagem))
                {
                    string imagemTag = $"imagens/{funcionario.Imagem.Pasta}/{funcionario.Imagem.Nome}";
                    imgPreview.ImageUrl = imagemTag;
                }
            }*/
        }

        protected void btnAdicaoImagemPremioCupom_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtNomePremioCupom.Text))
            {
                litAvisoRecompensaCupom.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> Nome do prêmio não pode ficar vazio</p></div>";
                txtNomePremioCupom.Focus();
                return;
            }

            else if (String.IsNullOrEmpty(txtPontosNecessarioCupom.Text))
            {
                litAvisoRecompensaCupom.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> Pontos não pode ficar vazio</p></div>";
                txtPontosNecessarioCupom.Focus();
                return;
            }

            else if (String.IsNullOrEmpty(txtDescricaoCupom.Text))
            {
                litAvisoRecompensaCupom.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> Descrição do prêmio não pode ficar vazia</p></div>";
                txtDescricaoCupom.Focus();
                return;
            }
            else if (String.IsNullOrEmpty(txtCupomValor.Text))
            {
                litAvisoRecompensaCupom.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> Valor do cupom não pode ficar vazio</p></div>";
                txtDescricaoCupom.Focus();
                return;
            }

            else if (cmbServicoAtribuidoCupom.SelectedIndex == 0 && cmbCategoriaServicoAtribuidoCupom.SelectedIndex == 0)
            {
                litAvisoRecompensaCupom.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> Nenhum serviço ou categoria foi atribuído</p></div>";
                cmbServicoAtribuidoCupom.Focus();
                return;
            }

            else if (fluImagemCupom.PostedFile == null)
            {
                litAvisoRecompensaCupom.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> Adicione uma imagem</p></div>";
                fluImagemCupom.Focus();
                return;
            }

            else
            {
                if (fluImagemCupom.PostedFile != null)
                {
                    string NomeOriginalArq = Path.GetFileName(fluImagem.PostedFile.FileName);

                    string TipoArq = fluImagem.PostedFile.ContentType;

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

                    int TamanhoArq = fluImagemCupom.PostedFile.ContentLength;

                    if (TamanhoArq <= 0)
                        litAviso.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> A tentativa de upLoad do arquivo " + NomeOriginalArq + " falhou!</p></div>";

                    else
                    {
                        string novoNomeArquivo = NovoNomeArquivo(NomeOriginalArq);
                        fluImagemCupom.PostedFile.SaveAs(Request.PhysicalApplicationPath + @"imagens\\Premios\\" + novoNomeArquivo);
                        litAviso.Text = "";
                        //carregarImagemRecompensa();

                        try
                        {
                            adicaoRecompensa adicaoRecompensa = new adicaoRecompensa();
                            adicaoRecompensa.adicionarRecompensaCupom(cmbTipoRecompensa.SelectedValue.ToString(), txtCupomValor.Text, cmbServicoAtribuidoCupom.ToString(), 
                                cmbCategoriaServicoAtribuidoCupom.ToString(), txtNomePremioCupom.Text, txtPontosNecessarioCupom.Text, txtDescricaoCupom.Text, novoNomeArquivo, "Premios");
                        }

                        catch (Exception)
                        {
                            litAvisoRecompensaProduto.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> Já existe uma recompensa com essa imagem.</p></div>";
                            return;
                        }

                        Response.Redirect("dona_recompensas.aspx");
                    }
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