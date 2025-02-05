using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using prjTCC.Classe;
using MySql.Data.MySqlClient;

namespace prjTCC.Lógica
{
    public class ListaFuncionarioServicoPorFiltro : Banco
    {
        private FuncionarioServicoDiaDeTrabalho funcionarioServicoDiaDeTrabalho = new FuncionarioServicoDiaDeTrabalho();
        public FuncionarioServicoDiaDeTrabalho CriarFuncionarioServicoDiaDeTrabalho (string codigoServico, string nomeFuncionario, string data, string tempo)
        {
            try
            {
                Conectar();
                
                List<Parametro> parametros = new List<Parametro>();
                parametros.Add(new Parametro("vCodigoServico", codigoServico));
                parametros.Add(new Parametro("vNomeFuncionario", nomeFuncionario));
                parametros.Add(new Parametro("vDataSelec", data));
                parametros.Add(new Parametro("vTempoSelec", tempo));
                MySqlDataReader dados = Consultar("FiltroDeFuncionariosDoServico",parametros);
                while(dados.Read())
                {
                    funcionarioServicoDiaDeTrabalho.Funcionario.TipoFuncionario = new TipoFuncionario();
                    funcionarioServicoDiaDeTrabalho.Funcionario.Nome = dados.GetString(0);
                    funcionarioServicoDiaDeTrabalho.Servico.Codigo = dados.GetInt32(1);
                    funcionarioServicoDiaDeTrabalho.Funcionario.TipoFuncionario.Codigo = dados.GetInt32(2);
                    //funcionarioServicoDiaDeTrabalho.DiaDeTrabalho.Codig 
                }
                if (!dados.IsClosed) { dados.Close(); }
            }
            catch
            {

            }
            finally
            {
                Desconectar();
            }
            return funcionarioServicoDiaDeTrabalho;
        }
    }
}