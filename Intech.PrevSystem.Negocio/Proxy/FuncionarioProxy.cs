using Intech.Lib.Util.Date;
using Intech.PrevSystem.Dados.DAO;
using Intech.PrevSystem.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intech.PrevSystem.Negocio.Proxy
{
    public class FuncionarioProxy : FuncionarioDAO
    {
        public FuncionarioDados BuscarDadosPorCodEntid(string codEntid)
        {
            var tipoFunc = "";

            DateTime dataAtivoFacultativoAnterior = new DateTime(2014, 02, 05);
            var funcionario = new FuncionarioDados();

            var salarioBase = new SalarioBaseEntidade();
            var valorRgps = new IndiceValoresEntidade();

            funcionario.Funcionario = base.BuscarPorCodEntid(codEntid);
            funcionario.DadosPessoais = new DadosPessoaisProxy().BuscarPorCodEntid(codEntid);
            funcionario.Empresa = new EmpresaProxy().BuscarPorCodigo(funcionario.Funcionario.CD_EMPRESA);
            funcionario.Entidade = new EntidadeProxy().BuscarPorCodEntid(codEntid);
            funcionario.DS_ESTADO_CIVIL = new EstadoCivilProxy().BuscarPorCodigo(funcionario.DadosPessoais.CD_ESTADO_CIVIL).DS_ESTADO_CIVIL;
            funcionario.NOME_EMPRESA = funcionario.Empresa.NOME_ENTID;
            funcionario.IDADE = new Intervalo(DateTime.Now, funcionario.DadosPessoais.DT_NASCIMENTO, new CalculoAnosMesesDiasAlgoritmo2()).Anos.ToString() + " anos";
            funcionario.SEXO = funcionario.DadosPessoais.SEXO == "M" ? "MASCULINO" : "FEMININO";

            var plano = new PlanoVinculadoProxy().BuscarPorFundacaoInscricao(funcionario.Funcionario.CD_FUNDACAO, funcionario.Funcionario.NUM_INSCRICAO).FirstOrDefault();

            if (plano.CD_PLANO != "0001")
            {
                tipoFunc = "AF";
            }
            else
            {
                if (funcionario.IND_AFA_JUDICIAL == "S")
                {
                    tipoFunc = "AFA";
                }
                else 
                {
                    if ( (funcionario.Funcionario.CD_SIT_PLANO == "03" || funcionario.Funcionario.CD_SIT_PLANO == "07" || funcionario.Funcionario.CD_SIT_PLANO == "09" || 
                          funcionario.Funcionario.CD_SIT_PLANO == "13" || funcionario.Funcionario.CD_SIT_PLANO == "14" || funcionario.Funcionario.CD_SIT_PLANO == "15") && 
                          (funcionario.Funcionario.DT_ADMISSAO < dataAtivoFacultativoAnterior)) {
                        tipoFunc = "AFA";
                    }  
                    else
                    {
                        valorRgps = new IndiceProxy().BuscarUltimoPorCodigoData("RGPS");
                        salarioBase = new SalarioBaseProxy().BuscarUltimoPorFundacaoEmpresaMatricula(funcionario.Funcionario.CD_FUNDACAO, funcionario.Funcionario.CD_EMPRESA, funcionario.Funcionario.NUM_MATRICULA);

                        if (salarioBase.VL_SALARIO > valorRgps.VALOR_IND)
                        {
                            tipoFunc = "A";
                        }
                    }  
                }
            }

            funcionario.TIPO = tipoFunc;

            return funcionario;
        }

        public FuncionarioDados BuscarDadosPorCodEntidEmpresa(string codEntid, string cdEmpresa)
        {
            var funcionario = new FuncionarioDados();

            funcionario.Funcionario = base.BuscarPorCodEntid(codEntid);
            funcionario.DadosPessoais = new DadosPessoaisProxy().BuscarPorCodEntid(codEntid);
            funcionario.Empresa = new EmpresaProxy().BuscarPorCodigo(cdEmpresa);
            funcionario.Entidade = new EntidadeProxy().BuscarPorCodEntid(codEntid);
            funcionario.DS_ESTADO_CIVIL = new EstadoCivilProxy().BuscarPorCodigo(funcionario.DadosPessoais.CD_ESTADO_CIVIL).DS_ESTADO_CIVIL;
            funcionario.NOME_EMPRESA = funcionario.Empresa.NOME_ENTID;
            funcionario.IDADE = new Intervalo(DateTime.Now, funcionario.DadosPessoais.DT_NASCIMENTO, new CalculoAnosMesesDiasAlgoritmo2()).Anos.ToString() + " anos";
            funcionario.SEXO = funcionario.DadosPessoais.SEXO == "M" ? "MASCULINO" : "FEMININO";

            return funcionario;
        }

        public FuncionarioDados BuscarDadosPorCodEntidEmpresaLogin(string codEntid, string cdEmpresa, string NomLogin)
        {
            var funcionario = new FuncionarioDados();

            funcionario.Funcionario = base.BuscarPorCodEntid(codEntid);
            funcionario.DadosPessoais = new DadosPessoaisProxy().BuscarPorCodEntid(codEntid);
            funcionario.Empresa = new EmpresaProxy().BuscarPorCodigo(cdEmpresa);
            funcionario.Entidade = new EntidadeProxy().BuscarPorCodEntid(codEntid);
            funcionario.Usuario = new UsuarioProxy().BuscarPorCpf(NomLogin);
            funcionario.DS_ESTADO_CIVIL = new EstadoCivilProxy().BuscarPorCodigo(funcionario.DadosPessoais.CD_ESTADO_CIVIL).DS_ESTADO_CIVIL;
            funcionario.NOME_EMPRESA = funcionario.Empresa.NOME_ENTID;
            funcionario.IDADE = new Intervalo(DateTime.Now, funcionario.DadosPessoais.DT_NASCIMENTO, new CalculoAnosMesesDiasAlgoritmo2()).Anos.ToString() + " anos";
            funcionario.SEXO = funcionario.DadosPessoais.SEXO == "M" ? "MASCULINO" : "FEMININO";

            return funcionario;
        }

        public FuncionarioDados BuscarDadosPorCodEntidMatriculaEmpresaLogin(string codEntid, string matricula, string cdEmpresa, string NomLogin)
        {
            var funcionario = new FuncionarioDados();

            funcionario.Funcionario = base.BuscarPorMatriculaEmpresa(matricula, cdEmpresa);
            funcionario.DadosPessoais = new DadosPessoaisProxy().BuscarPorCodEntid(codEntid);
            funcionario.Empresa = new EmpresaProxy().BuscarPorCodigo(cdEmpresa);
            funcionario.Entidade = new EntidadeProxy().BuscarPorCodEntid(codEntid);
            funcionario.Usuario = new UsuarioProxy().BuscarPorCpf(NomLogin);
            funcionario.DS_ESTADO_CIVIL = new EstadoCivilProxy().BuscarPorCodigo(funcionario.DadosPessoais.CD_ESTADO_CIVIL).DS_ESTADO_CIVIL;
            funcionario.NOME_EMPRESA = funcionario.Empresa.NOME_ENTID;
            funcionario.IDADE = new Intervalo(DateTime.Now, funcionario.DadosPessoais.DT_NASCIMENTO, new CalculoAnosMesesDiasAlgoritmo2()).Anos.ToString() + " anos";
            funcionario.SEXO = funcionario.DadosPessoais.SEXO == "M" ? "MASCULINO" : "FEMININO";

            return funcionario;
        }

        public FuncionarioDados BuscarDadosPorCodEntidEmpresa(string codEntid, string codEntidFuncionario, string cdEmpresa)
        {
            var funcionario = new FuncionarioDados();

            funcionario.Funcionario = base.BuscarPorCodEntid(!string.IsNullOrEmpty(codEntidFuncionario) ? codEntidFuncionario : codEntid);
            funcionario.DadosPessoais = new DadosPessoaisProxy().BuscarPorCodEntid(codEntid);
            funcionario.Empresa = new EmpresaProxy().BuscarPorCodigo(cdEmpresa);
            funcionario.Entidade = new EntidadeProxy().BuscarPorCodEntid(codEntid);
            funcionario.Usuario = new UsuarioProxy().BuscarPorCpf(funcionario.Entidade.CPF_CGC);
            funcionario.DS_ESTADO_CIVIL = new EstadoCivilProxy().BuscarPorCodigo(funcionario.DadosPessoais.CD_ESTADO_CIVIL).DS_ESTADO_CIVIL;
            funcionario.NOME_EMPRESA = funcionario.Empresa.NOME_ENTID;
            funcionario.IDADE = new Intervalo(DateTime.Now, funcionario.DadosPessoais.DT_NASCIMENTO, new CalculoAnosMesesDiasAlgoritmo2()).Anos.ToString() + " anos";
            funcionario.SEXO = funcionario.DadosPessoais.SEXO == "M" ? "MASCULINO" : "FEMININO";

            return funcionario;
        }
    }
}
