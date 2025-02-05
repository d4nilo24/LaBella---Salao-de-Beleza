using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjTCC.Classe
{
    public class Depoimento
    {
        #region Dados de Depoimento
        public Agendamento Agendamento { get; set; }
        public Cliente Cliente { get; set; }
        public int Avaliacao { get; set; }
        public string Descricao { get; set; }
        public string DataAvaliacao { get; set; }
        #endregion

        #region Dado pegado por join com Cliente
        public string NomeCliente { get; set; }
        #endregion

        #region  Dado pegado por join com Funcionario (Nome) 
        public Funcionario Funcionario { get; set; }
        #endregion

        #region Construtores
        public Depoimento(){}

        public Depoimento(Agendamento agendamento, Cliente cliente, int avaliacao, string descricao, string dataAvaliacao, string nomeCliente, Funcionario funcionario)
        {
            this.Agendamento = agendamento;
            this.Cliente = cliente;
            this.Avaliacao = avaliacao;
            this.Descricao = descricao;
            this.DataAvaliacao = dataAvaliacao;
            this.NomeCliente = nomeCliente;
            this.Funcionario = funcionario;
        }


        #endregion
    }
}