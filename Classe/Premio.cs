using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjTCC.Classe
{
    public class Premio
    {
        public int Codigo { get; set; }
        #region Dado de temporada (código)
        public Temporada Temporada { get; set; }
        #endregion
        #region Dado de tipo_prêmio (código)
        public TipoPremio TipoPremio { get; set; }
        #endregion
        #region Dado de cupom_servico (código de cupom e código de serviço)
        public Cupom Cupom { get; set; }
        public Servico Servico { get; set; }
        #endregion
        #region Dado de cupom_categoria (código de cupom e código de categoria)
        public Categoria Categoria { get; set; }
        #endregion
        #region Dado de produto (código)
        public Produto Produto { get; set; }
        #endregion
        public string Nome { get; set; }
        public int Pontos { get; set; }
        public string Descricao { get; set; }
        public Imagem Imagem { get; set; }
        #region Dado calculado de ListarPremiosPorFiltro 
        public string DataFinalTemporada { get; set; }
        public bool Resgatavel { get; set; }
        public string CondicaoPremio { get; set; }
        #endregion
        #region Dado de premio cliente
        public bool Resgatado { get; set; }
        #endregion
        #region 
        public string CondicaoPremioEstoque { get; set; }
        #endregion
        public Premio() { }
        public Premio(int codigo, Temporada temporada, TipoPremio tipoPremio, Cupom cupom, Servico servico, Produto produto, string nome, int pontos, string descricao, Imagem imagem)
        {
            this.Codigo = codigo;
            this.Temporada = temporada;
            this.TipoPremio = tipoPremio;
            this.Cupom = cupom;
            this.Servico = servico;
            this.Produto = produto;
            this.Nome = nome;
            this.Pontos = pontos;
            this.Descricao = descricao;
            this.Imagem = imagem;
        }
    }
}