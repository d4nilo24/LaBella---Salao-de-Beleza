using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjTCC.Classe
{
    public class FuncionarioServicoDiaDeTrabalho
    {
        public string Hora { get; set; }
       
        #region Dado de Funcionario (CPF e Nome [para procedure FiltroDeFuncionariosDoServico])
        public Funcionario Funcionario { get; set; }
        #endregion
        #region Dado de Servico (Codigo)
        public Servico Servico { get; set; }
        #endregion
        #region Dado de Dia de Trabalho ()
        public DiaDeTrabalho DiaDeTrabalho { get; set; }
        #endregion
        #region Dado da procedure ListarDadosMinimosParaAgendar
        public string[] HorarioAgendado { get; set; }
        public string[] Horas { get; set; }
        public string DataProxima { get; set;}
        #endregion

        public FuncionarioServicoDiaDeTrabalho() { }
        public FuncionarioServicoDiaDeTrabalho(string hora,Funcionario funcionario, Servico servico, DiaDeTrabalho diaDeTrabalho, string[] horarioAgendado, string[] horas, string dataProxima)
        {
            this.Hora = hora;
            this.Funcionario = funcionario;
            this.Servico = servico;
            this.DiaDeTrabalho = diaDeTrabalho;
            this.HorarioAgendado = horarioAgendado;
            this.Horas = horas;
            this.DataProxima = dataProxima;
        }

    }
}