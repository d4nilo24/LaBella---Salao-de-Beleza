using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjTCC.Classe
{
    public class Funcionario
    {
        #region Dados de Funcionário
        public string CPF { get; set; }
        public int Codigo { get; set; }
        //Código
        public TipoFuncionario TipoFuncionario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public Imagem Imagem { get; set; }
        #endregion
        #region Dado da procedure ListarTodosAgendamentosPorDia (agendamentos)
        public List<Agendamento> Agendamentos { get; set; }
        #endregion

        public Funcionario(){}
        public Funcionario(string cPF, TipoFuncionario tipoFuncionario, string nome, string email, string senha, Imagem imagem)
        {
            this.CPF = cPF;
            this.TipoFuncionario = tipoFuncionario;
            this.Nome = nome;
            this.Email = email;
            this.Senha = senha;
            this.Imagem = imagem;
        }
    }
}