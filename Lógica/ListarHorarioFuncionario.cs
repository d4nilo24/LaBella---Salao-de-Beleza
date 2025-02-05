using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using prjTCC.Classe;
using MySql.Data.MySqlClient;

namespace prjTCC.Lógica
{
    public class ListarHorarioFuncionario : Banco
    {
        private List<FuncionarioServicoDiaDeTrabalho> funcionarioServicoDiaDeTrabalho = new List<FuncionarioServicoDiaDeTrabalho>();
        public List<FuncionarioServicoDiaDeTrabalho> listarHorarioFuncionario(string codigoServico, string codigoFuncionario, string codigoDiaDaSemana, string dataSelecionada)
        {
            try
            {
                Conectar();
                List<Parametro> parametros = new List<Parametro>();
                parametros.Add(new Parametro("vCodigoServico", codigoServico));
                parametros.Add(new Parametro("vCodigoFuncionario", codigoFuncionario));
                parametros.Add(new Parametro("vCodigoDiaDeTrabalho", codigoDiaDaSemana));
                parametros.Add(new Parametro("vDataSelec", dataSelecionada));
                MySqlDataReader dados = Consultar("ListarDadosMinimosParaAgendar", parametros);
                while(dados.Read())
                {
                    FuncionarioServicoDiaDeTrabalho funcionarioServicoTrabalho = new FuncionarioServicoDiaDeTrabalho();
                    funcionarioServicoTrabalho.DiaDeTrabalho = new DiaDeTrabalho();
                    funcionarioServicoTrabalho.Funcionario = new Funcionario();
                    funcionarioServicoTrabalho.Funcionario.Imagem = new Imagem();
                    funcionarioServicoTrabalho.Funcionario.Codigo = dados.GetInt32(0);
                    funcionarioServicoTrabalho.Funcionario.Nome = dados.GetString(1);
                    if (!dados.IsDBNull(2))
                    {
                        funcionarioServicoTrabalho.Funcionario.Imagem.Nome = dados.GetString(2);
                        funcionarioServicoTrabalho.Funcionario.Imagem.Pasta = dados.GetString(3);
                    }
                    funcionarioServicoTrabalho.Horas = dados[4].ToString().Split(',');
                    funcionarioServicoTrabalho.DiaDeTrabalho.Nome = dados[5].ToString();
                    funcionarioServicoTrabalho.HorarioAgendado = dados[6].ToString().Split(',');
                    funcionarioServicoTrabalho.DataProxima = dados.GetDateTime(7).ToString("yyyy-MM-dd");
                    funcionarioServicoDiaDeTrabalho.Add(funcionarioServicoTrabalho);
                }
                if (!dados.IsClosed) { dados.Close(); }
            }
            catch
            {
                throw new Exception("Não foi possível listar os horários do(s) funcionário(s).");
            }
            finally
            {
                Desconectar();
            }
            return funcionarioServicoDiaDeTrabalho;
        }
    }
}