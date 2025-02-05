using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjTCC.Classe
{
    public class Agendamento
    {
        public string Codigo { get; set; }
        public string Data { get; set; }
        public bool PresencaFuncionario { get; set; }
        public bool PresencaCliente { get; set; }
        #region Dado do cliente (Email)
        public Cliente Cliente { get; set; }
        #endregion
        #region Dado de funcionário (Código)
        public Funcionario Funcionario { get; set; }
        #endregion
        #region Dado de serviço (Código)
        public Servico Servico { get; set; }
        #endregion
        #region Dado de FuncionárioServiçoDiaDeTrablho (Código e Hora)
        public FuncionarioServicoDiaDeTrabalho FuncionarioServicoDiaDeTrabalho { get; set; }
        #endregion
        #region Dado de cupom (código)
        public Cupom Cupom { get; set; }
        #endregion
        #region Situação de Agendamento (À tela de agendamentos)
        public string Situacao { get; set; }
        public string CalculadoPresencaFuncionario { get; set; }
        public string CalculadoPresencaCliente { get; set; }
        public bool VerificaAvaliacaoPorAgendamento { get; set; }
        #endregion
        #region Dado de listarAgendamentosPorSemana e DadosAgendamentoEspecifico (agendamento concluído)
        public bool AgendamentoConcluido { get; set; }
        #endregion
        #region Dado de DadosAgendamentoEspecifico (valor final)
        public double ValorFinal { get; set; }
        public bool AgendamentoIniciado { get; set; }
        #endregion
        #region Dado de Dado de produto (produto agendamento)
        public Produto Produto  { get; set; }
        #endregion
        public Agendamento() { }
        public Agendamento(string codigo, string data, bool presencaFuncionario, bool presencaCliente, Cliente cliente, Funcionario funcionario, Servico servico, FuncionarioServicoDiaDeTrabalho funcionarioServicoDiaDeTrabalho, Cupom cupom)
        {
            this.Codigo = codigo;
            this.Data = data;
            this.PresencaFuncionario = presencaFuncionario;
            this.PresencaCliente = presencaCliente;
            this.Cliente = cliente;
            this.Funcionario = funcionario;
            this.Servico = servico;
            this.FuncionarioServicoDiaDeTrabalho = funcionarioServicoDiaDeTrabalho;
            this.Cupom = cupom;
        }
    }
}