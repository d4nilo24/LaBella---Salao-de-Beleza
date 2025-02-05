using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjTCC.Classe
{
    public class Cliente
    {
        public string Email { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public int Pontos { get; set; }
        #region Dado de VerificarExistenciaCliente
        public bool Existencia { get; set; }
        #endregion
        public Cliente() {}
        public Cliente(string email, string nome, string senha, int pontos)
        {
            this.Email = email;
            this.Nome = nome;
            this.Senha = senha;
            this.Pontos = pontos;
        }
    }
}