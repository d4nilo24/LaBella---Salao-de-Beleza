using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using prjTCC.Lógica;
using prjTCC.Classe;

namespace prjTCC
{
    public partial class dona_confirmar_agendamento : System.Web.UI.Page
    {
        private string agendamentoUrl = "";
        private static bool produtosConfirmados = false;
        static List<Produto> produtosUtilizados = new List<Produto>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["login"] == null)
            {
                Response.Redirect("login_cookie.html?url=" + HttpContext.Current.Request.Url.AbsoluteUri);
            }
            else if (Session["tipo"].ToString() != "2" && Session["tipo"].ToString() != "1")
            {
                Response.Redirect("index.aspx");
            }

            if (Session["tipo"].ToString() == "2")
            {
                sdbDona.Visible = true;
                sdbFuncionario.Visible = false;
            }
            else
            {
                sdbDona.Visible = false;
                sdbFuncionario.Visible = true;
            }

            if (!IsPostBack)
            {
                produtosUtilizados = new List<Produto>();
            }

            try
            {
                if (Request.QueryString.Get("agendamento") != null)
                {
                    agendamentoUrl = Request.QueryString.Get("agendamento");
                }

                try
                {
                    DadosAgendamentoEspecifico dadoAgendamentoEspecifico = new DadosAgendamentoEspecifico();
                    Agendamento agendamento = dadoAgendamentoEspecifico.dadosAgendamentoEspecifico(agendamentoUrl);
                    if (!IsPostBack)
                    {
                        txtCodigoAgendamento.Text = agendamento.Codigo;
                        txtDataAgendamento.Text = agendamento.Data;
                        txtHoraAgendamento.Text = agendamento.FuncionarioServicoDiaDeTrabalho.Hora;
                        txtNomeCliente.Text = agendamento.Cliente.Nome;
                        txtEmailCliente.Text = agendamento.Cliente.Email;
                        txtNomeFuncionario.Text = agendamento.Funcionario.Nome;
                        txtServico.Text = agendamento.Servico.Nome;
                        if (agendamento.Cupom.Valor != 0)
                        {
                            txtCupom.Text = agendamento.Cupom.Valor + "% de desconto";
                        }
                        else
                        {
                            txtCupom.Text = "Sem cupom";
                        }

                        txtValorServico.Text = agendamento.Servico.Valor.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("pt-BR"));
                        txtValorFinal.Text = agendamento.ValorFinal.ToString("C", System.Globalization.CultureInfo.GetCultureInfo("pt-BR")); ;

                        adicaoRecompensa produtosDisponiveis = new adicaoRecompensa();

                        drpProdutos.DataSource = produtosDisponiveis.escolherProdutoRecompensa();
                        drpProdutos.DataTextField = "nm_produto";
                        drpProdutos.DataValueField = "cd_produto";
                        drpProdutos.DataBind();
                    }

                    if (agendamento.AgendamentoConcluido)
                    {
                        rblPresencaCliente.SelectedValue = agendamento.PresencaCliente ? "1" : "0";
                        rblPresencaFuncionario.SelectedValue = agendamento.PresencaFuncionario ? "1" : "0";
                        rblPresencaCliente.Enabled = false;
                        rblPresencaFuncionario.Enabled = false;
                        btnConcluir.Text = "Voltar";
                        btnConcluir.Click += VoltarParaAgenda;
                        btnRegistrarProduto.Enabled = false;
                    }
                    else if (!agendamento.AgendamentoIniciado)
                    {
                        litAviso.Text = "<p><i class=\"fa-solid fa-triangle-exclamation\"></i> Não está no horário desse agendamento ainda.</p>";
                        rblPresencaCliente.Enabled = false;
                        rblPresencaFuncionario.Enabled = false;
                        btnConcluir.Text = "Voltar";
                        btnConcluir.Click += VoltarParaAgenda;
                        btnRegistrarProduto.Enabled = false;
                    }
                    else
                    {
                        btnConcluir.Click += ConfirmarAgendamento;
                        btnRegistrarProduto.Enabled = true;
                    }



                    if (IsPostBack)
                    {
                        ListarProdutosUtilizados();
                        //AtualizarValores();
                    }

                    if (!agendamento.AgendamentoConcluido && agendamento.AgendamentoIniciado)
                    {
                        if (!produtosConfirmados)
                        {
                            litAvisoProduto.Text = "<p><i class='fa-solid fa-triangle-exclamation'></i> Nenhum produto foi registrado, adicione algum ou confirme que não foi usado nenhum.</p>";
                            btnConcluir.Enabled = false;
                        }
                        else
                        {
                            litAvisoProduto.Text = "";
                            btnConcluir.Enabled = true;
                        }
                    }
                }
                catch
                {
                    throw new Exception("Não foi possível listar os dados do agendamento");
                }
            }
            catch (Exception ex)
            {
                HttpContext.Current.Items["ErroTipo"] = "404 - Página não encontrada";
                HttpContext.Current.Items["ErroMensagem"] = ex.Message;
                Server.Transfer("~/erro.aspx");
            }
        }
        public void ListarProdutosUtilizados()
        {

            pnlProdutos.Controls.Clear();
            for (int i = 0; i < produtosUtilizados.Count; i++)
            {
                ConfirmaAgendamento tipoProduto = new ConfirmaAgendamento();

                Produto produtoUtilizado = new Produto();
                produtoUtilizado.Codigo = produtosUtilizados[i].Codigo;
                produtoUtilizado.Nome = produtosUtilizados[i].Nome;
                produtoUtilizado.Quantidade = produtosUtilizados[i].Quantidade;
                produtoUtilizado.TipoProduto = produtosUtilizados[i].TipoProduto;
                produtoUtilizado.UtilizadoCompletamente = produtosUtilizados[i].UtilizadoCompletamente;
                    
                Panel panelProduto = new Panel();
                panelProduto.CssClass = "novo_produto";
                Literal nomeProduto = new Literal();

                nomeProduto.Text = "<h2>" + produtoUtilizado.Nome + "</h2><hr/>";

                CheckBox produtoUtilizadoCompletamente = new CheckBox();
                produtoUtilizadoCompletamente.Text = "Produto utilizado completamente";
                produtoUtilizadoCompletamente.Checked = produtoUtilizado.UtilizadoCompletamente;
                produtoUtilizadoCompletamente.ID = "chkUtilizadoCompletamente" + i;
                produtoUtilizadoCompletamente.CssClass = "checkbox";
                produtoUtilizadoCompletamente.AutoPostBack = true;
                produtoUtilizadoCompletamente.CheckedChanged += new EventHandler(ProdutoUtilizadoCompletamente_CheckedChanged);
                produtoUtilizadoCompletamente.Attributes["parametro"] = i.ToString();

                Panel quantidadeProduto = new Panel();
                Label lblQuantidadeProduto = new Label();
                lblQuantidadeProduto.Text = "Quantidade usada";
                TextBox quantidade = new TextBox();
                quantidade.Attributes.Add("type", "number");
                quantidade.Attributes.Add("min", "0");
                quantidade.Attributes.Add("max", "999");
                quantidade.ID = "txtQuantidade" + i;
                quantidade.Text = produtoUtilizado.Quantidade;
                quantidade.Attributes["parametro"] = i.ToString();
                quantidade.TextChanged += txtQuantidade_TextChanged;
                quantidadeProduto.Controls.Add(lblQuantidadeProduto);
                quantidadeProduto.Controls.Add(quantidade);

                Button apagar = new Button();
                apagar.Text = "Deletar";
                apagar.Click += Apagar_Click;
                apagar.CommandArgument = i.ToString();
                apagar.CssClass = "botoes";

                panelProduto.Controls.Add(nomeProduto);
                if (produtoUtilizado.TipoProduto == "1")
                {
                    panelProduto.Controls.Add(produtoUtilizadoCompletamente);
                }
                if (produtoUtilizado.UtilizadoCompletamente)
                {
                    panelProduto.Controls.Add(quantidadeProduto);
                }
                panelProduto.Controls.Add(apagar);
                pnlProdutos.Controls.Add(panelProduto);
            }
        }
        protected void Apagar_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int indexDeletar = int.Parse(btn.CommandArgument.ToString());
            produtosUtilizados.RemoveAt(indexDeletar);
            pnlProdutos.Controls.Clear();
            if (produtosUtilizados.Count > 0)
            {
                ListarProdutosUtilizados();
            }
            //AtualizarValores();
        }
        public void ConfirmarAgendamento(object sender, EventArgs e)
        {
           
                if (rblPresencaCliente.SelectedItem == null)
                {
                    litAviso.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> A presença do cliente não foi definida.</p></div>";
                    return;
                }
                else if (rblPresencaFuncionario.SelectedItem == null)
                {
                    litAviso.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> A presença do funcionário não foi definida.</p></div>";
                    return;
                }
                
                ConfirmaAgendamento confirmaAgendamento = new ConfirmaAgendamento();
                bool presencaFuncionario = rblPresencaFuncionario.SelectedValue == "1" ? true : false;
                bool presencaCliente = rblPresencaCliente.SelectedValue == "1" ? true : false;
            try
            {
                confirmaAgendamento.CriarProdutoAgendamento(produtosUtilizados, agendamentoUrl);
            }
            catch (Exception ex)
            {
                if (Session["tipo"].ToString() == "2")
                {
                    if (ex.Message.Contains(" Contate o gerente, por favor."))
                    {
                        litAviso.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> " + ex.Message.Replace(" Contate o gerente, por favor.", " Verifique o estoque.") + "</p></div>";
                    }
                    else
                    {
                        litAviso.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> " + ex.Message + "</p></div>";
                    }
                }
                else
                {
                    litAviso.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> " + ex.Message + "</p></div>";
                }
                    return;
            }

            try
            {
                confirmaAgendamento.ConfirmarAgendamento(agendamentoUrl, presencaFuncionario, presencaCliente);
            }
            catch (Exception ex)
            {
                HttpContext.Current.Items["ErroTipo"] = "500 - Erro no servidor interno";
                HttpContext.Current.Items["ErroMensagem"] = ex.Message;
                Server.Transfer("~/erro.aspx");
            }
            litAviso.Text = "<div class='acerto'><p><i class=\"fa-solid fa-check\"></i> Produto(s) confirmados com sucesso</p></div>";
            Response.Redirect("dona_agenda.aspx");
        }
        public void VoltarParaAgenda(object sender, EventArgs e)
        {
            if (Session["Tipo"].ToString() == "2")
            {
                Response.Redirect("dona_agenda.aspx");
            }
            else
            {
                Response.Redirect("funcionario_agenda.aspx");
            }
        }

        protected void btnAdicionarProduto_Click(object sender, EventArgs e)
        {
            if (produtosUtilizados.Any(produto => produto.Codigo == drpProdutos.SelectedValue))
            {
                litAvisoPanelProduto.Text = "<div class='erro'><p><i class=\"fa-solid fa-triangle-exclamation\"></i> Esse produto já foi adicionado.</p></div>";
                return;
            }
            else
            {
                litAvisoPanelProduto.Text = "";
            }

            ConfirmaAgendamento tipoProduto = new ConfirmaAgendamento();

            Produto produtoUtilizado = new Produto();
            produtoUtilizado.Codigo = drpProdutos.SelectedValue;
            produtoUtilizado.Nome = drpProdutos.SelectedItem.Text;
            produtoUtilizado.Quantidade = "0";
            produtoUtilizado.TipoProduto = tipoProduto.TipoProduto(produtoUtilizado.Codigo);
            if (produtoUtilizado.TipoProduto == "2")
            {
                produtoUtilizado.UtilizadoCompletamente = true;
            }
            else
            {
                produtoUtilizado.UtilizadoCompletamente = false;
            }

            produtosUtilizados.Add(produtoUtilizado);

            if (produtosUtilizados.Count > 0)
            {
                ListarProdutosUtilizados();
            }
            //AtualizarValores();
        }
        protected void AtualizarValores()
        {
            for (int i = 0; i < produtosUtilizados.Count; i++)
            {
                Panel panelProdutoDesejado = pnlProdutos.Controls[i] as Panel;

                if (produtosUtilizados[i].TipoProduto == "1")
                {
                    produtosUtilizados[i].UtilizadoCompletamente = (panelProdutoDesejado.FindControl("chkUtilizadoCompletamente" + i) as CheckBox).Checked;
                    if (produtosUtilizados[i].UtilizadoCompletamente)
                    {
                        if ((panelProdutoDesejado.FindControl("txtQuantidade" + i) as TextBox) != null)
                        {
                            produtosUtilizados[i].Quantidade = (panelProdutoDesejado.FindControl("txtQuantidade" + i) as TextBox).Text;
                        }
                    }
                }
                else
                {
                    if ((panelProdutoDesejado.FindControl("txtQuantidade" + i) as TextBox) != null)
                    {
                        produtosUtilizados[i].Quantidade = (panelProdutoDesejado.FindControl("txtQuantidade" + i) as TextBox).Text;
                    }
                }
            }

        }
        protected void ProdutoUtilizadoCompletamente_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            int parametro = int.Parse(checkBox.Attributes["parametro"]);
            produtosUtilizados[parametro].UtilizadoCompletamente = checkBox.Checked;
            ListarProdutosUtilizados();
        }
        private void txtQuantidade_TextChanged(object sender, EventArgs e)
        {
            TextBox txtQuantidade = (TextBox)sender;
            int parametro = int.Parse(txtQuantidade.Attributes["parametro"]);
            produtosUtilizados[parametro].Quantidade = txtQuantidade.Text;
            //ListarProdutosUtilizados();
        }

        protected void btnRegistrarProduto_Click(object sender, EventArgs e)
        {
            pnlConfirmarExclusao.Visible = true;
            ListarProdutosUtilizados();
        }

        protected void btnConfirmarProduto_Click(object sender, EventArgs e)
        {
            produtosConfirmados = true;
            pnlConfirmarExclusao.Visible = false;
            btnConcluir.Enabled = true;
            litAvisoProduto.Text = "";
        }

    }
}