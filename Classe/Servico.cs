using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjTCC.Classe
{
    public class Servico
    {

        #region Dados de Servico
        public int Codigo { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public string Duracao { get; set; }
        #endregion
        #region Dado de Categoria
        public Categoria Categoria { get; set; }
        #endregion
        #region Imagem_Servico (não está no banco)
        public List<Imagem> Imagem {get; set; }
        #endregion
        #region Dado de calculado de Avaliacao
        public int ValorAvaliacaoMedia { get; set; }
        public int QuantidadeAvaliacao { get; set; }
        #endregion
        #region Dado de funcionario (nome)
        public List<Funcionario> Funcionario { get; set; }
        #endregion
        #region Construtores
        public int Pontos { get; set; }
        public Servico() { }
        public Servico(int codigo, string nome, string descricao, double valor, string duracao, Categoria categoria, List<Imagem> imagem, List<Funcionario> funcionarios, int paginaTotal)
        {
            this.Codigo = codigo;
            this.Nome = nome;
            this.Descricao = descricao;
            this.Valor = valor;
            this.Duracao = duracao;
            this.Categoria = categoria;
            this.Imagem = imagem;
            this.Funcionario = funcionarios;
        }
        #endregion
    }
}