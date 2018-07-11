#region Usings
using Intech.Lib.Util.Date;
using Intech.PrevSystem.Entidades;
using Intech.PrevSystem.Negocio.Proxy;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq; 
#endregion

namespace Intech.PrevSystem.Preves.Negocio
{
    public class Recadastramento
    {
        public FuncionarioEntidade Funcionario { get; set; }
        public EntidadeEntidade Entidade { get; set; }
        public PlanoVinculadoEntidade Plano { get; set; }
        public DadosPessoaisEntidade DadosPessoais { get; set; }
        public EmpresaEntidade Empresa { get; set; }
        public BancoAgEntidade Banco { get; set; }

        public List<RecadastramentoPassoEntidade> ListaPassos { get; set; } = new List<RecadastramentoPassoEntidade>();

        public string CdFundacao => Funcionario.CD_FUNDACAO;
        public string CdEmpresa => Funcionario.CD_EMPRESA;
        public string CdPlano => Plano.CD_PLANO;
        public string Matricula => Funcionario.NUM_MATRICULA;
        public string Inscricao => Funcionario.NUM_INSCRICAO;

        public Recadastramento(FuncionarioEntidade funcionario, EntidadeEntidade entidade, DadosPessoaisEntidade dadosPessoais, EmpresaEntidade empresa, PlanoVinculadoEntidade plano, BancoAgEntidade banco)
        {
            Funcionario = funcionario;
            Entidade = entidade;
            Plano = plano;
            DadosPessoais = dadosPessoais;
            Empresa = empresa;
            Banco = banco;

            MontarEstrutura();
        }

        public void MontarEstrutura()
        {
            ListaPassos.Add(CriarPasso1());
            ListaPassos.Add(CriarPasso2());
            ListaPassos.Add(CriarPasso3());
            ListaPassos.Add(CriarPasso4());
            ListaPassos.Add(CriarPasso5());
            ListaPassos.Add(CriarPasso6());
            ListaPassos.Add(CriarPasso7());
        }

        public List<RecadastramentoPassoEntidade> BuscarPassos()
        {
            return ListaPassos;
        }

        public RecadastramentoPassoEntidade BuscarPasso(int indexPasso)
        {
            return ListaPassos[indexPasso];
        }

        public RecadastramentoSolicitacaoEntidade BuscarFinalizada()
        {
            var ultimo = new RecadastramentoSolicitacaoProxy().BuscarFechada(CdFundacao, CdEmpresa, CdPlano, Matricula);
            return ultimo;
        }

        public void NovaSolicitacao(string numeroProtocolo)
        {
            var proxySolicitacaoValor = new RecadastramentoSolicitacaoValorProxy();
            var proxySolicitacao = new RecadastramentoSolicitacaoProxy();

            var solicitacao = proxySolicitacao.BuscarPorCodIdentificador(numeroProtocolo);

            proxySolicitacaoValor.DeletePorOidSolicitacao(solicitacao.OID_SOLICITACAO);
            proxySolicitacao.DeletePorOidSolicitacao(solicitacao.OID_SOLICITACAO);
        }

        public void Salvar(List<RecadastramentoPassoEntidade> passos)
        {
            var proxySolicitacao = new RecadastramentoSolicitacaoProxy();
            var proxySolicitacaoValor = new RecadastramentoSolicitacaoValorProxy();

            var protocolo = Matricula.TrimStart('0') + DateTime.Now.ToString("ddMMyyyyhhmmss");

            var solicitacao = new RecadastramentoSolicitacaoEntidade
            {
                DTA_SOLICITACAO = DateTime.Now,
                DTA_RECADASTRO = null,
                NUM_MATRICULA = Matricula,
                CD_EMPRESA = CdEmpresa,
                CD_FUNDACAO = CdFundacao,
                CD_PLANO = CdPlano,
                COD_IDENTIFICADOR = protocolo,
                IND_FECHADA = "SIM",
                IND_RECUSADA = "NAO",
                TXT_MOTIVO = ""
            };

            var oidSolicitacao = proxySolicitacao.Inserir(solicitacao);

            foreach (var passo in passos)
            {
                foreach (var grupo in passo.GrupoCampos)
                {
                    for (int i = 0; i < grupo.Campos.Count; i++)
                    {
                        var valor = grupo.Campos[i].TipoCampo == TipoCampo.Texto ? grupo.Campos[i].NovoValor : grupo.Campos[i].NovoValorCombo;

                        var solicitacaoValor = new RecadastramentoSolicitacaoValorEntidade
                        {
                            COD_CAMPO = grupo.Campos[i].ID,
                            COD_GRUPO = grupo.ID,
                            NUM_PASSO = passo.Numero,
                            OID_SOLICITACAO = oidSolicitacao,
                            TXT_ARQUIVO = grupo.Campos[i].Arquivo,
                            TXT_DESCRICAO = grupo.Campos[i].Titulo,
                            TXT_VALOR_ANTIGO = grupo.Campos[i].ValorAntigo,
                            TXT_VALOR_NOVO = valor
                        };

                        proxySolicitacaoValor.Inserir(solicitacaoValor);
                    }
                }
            }
        }

        #region Passo 1 - Dados Empresa/Plano

        RecadastramentoPassoEntidade CriarPasso1()
        {
            var passo = new RecadastramentoPassoEntidade
            {
                Numero = 1,
                Titulo = "Passo 1",
                Subtitulo = "Dados Empresa/Plano",
                MensagemInicio = "",
                MensagemFim = ""
            };

            var dtAdmissao = Funcionario.DT_ADMISSAO?.ToString("dd/MM/yyyy");

            passo.GrupoCampos.Add(new RecadastramentoGrupoEntidade
            {
                ID = "Basico",
                Campos = new List<RecadastramentoCampoEntidade>
                {
                    new RecadastramentoCampoEntidade("Empresa", "Empresa", TipoCampo.Texto, false, Empresa.NOME_ENTID, 500, ""),
                    new RecadastramentoCampoEntidade("Matricula", "Matrícula", TipoCampo.Texto, false, Funcionario.NUM_MATRICULA, 500, ""),
                    new RecadastramentoCampoEntidade("Nome", "Nome", TipoCampo.Texto, true, Funcionario.NOME_ENTID, 60, "", true, true),
                    new RecadastramentoCampoEntidade("Admissao", "Admissão", TipoCampo.Texto, false, dtAdmissao, 500, ""),
                    new RecadastramentoCampoEntidade("Plano", "Plano", TipoCampo.Texto, false, Plano.DS_PLANO, 500, ""),
                    new RecadastramentoCampoEntidade("InscricaoPlano", "Inscrição Plano", TipoCampo.Texto, false, Plano.DT_INSC_PLANO.ToString("dd/MM/yyyy"), 500, ""),
                    new RecadastramentoCampoEntidade("SituacaoPlano", "Situação no Plano", TipoCampo.Texto, false, Plano.DS_CATEGORIA, 500, ""),
                    new RecadastramentoCampoEntidade("Observacao", "Observação", TipoCampo.Texto, true, string.Empty, 100, "")
                }
            });

            return passo;
        }

        #endregion

        #region Passo 2 - Dados Pessoais

        RecadastramentoPassoEntidade CriarPasso2()
        {
            var passo = new RecadastramentoPassoEntidade
            {
                Numero = 2,
                Titulo = "Passo 2",
                Subtitulo = "Dados Pessoais",
                MensagemInicio = "",
                MensagemFim = ""
            };

            var nacionalidade = ListasRecadastramento.BuscaValor(ListasRecadastramento.Nacionalidade, DadosPessoais.CD_NACIONALIDADE);
            var grauInstrucao = ListasRecadastramento.BuscaValor(ListasRecadastramento.GrauInstrucao, DadosPessoais.CD_GRAU_INSTRUCAO);
            var nuIdent = DadosPessoais.NU_IDENT;
            var orgaoEmis = DadosPessoais.ORG_EMIS_IDENT;
            var dtEmisIdent = DadosPessoais.DT_EMIS_IDENT?.ToString("dd/MM/yyyy");
            var cpf = Entidade.CPF_CGC;
            var iss = Entidade.ISS;
            var naturalidade = DadosPessoais.NATURALIDADE;
            var ufNaturalidade = DadosPessoais.UF_NATURALIDADE;
            var bancoAg = Banco.DESC_BCO_AG;
            var agencia = Entidade.NUM_AGENCIA;
            var numConta = Entidade.NUM_CONTA;
            var nomePai = DadosPessoais.NOME_PAI;
            var nomeMae = DadosPessoais.NOME_MAE;

            passo.GrupoCampos.Add(new RecadastramentoGrupoEntidade
            {
                ID = "Basico",
                Campos = new List<RecadastramentoCampoEntidade>
                {
                    new RecadastramentoCampoEntidade("DataNascimento", "Data Nascimento", TipoCampo.Texto, false, Entidade.DT_NASCIMENTO?.ToString("dd/MM/yyyy"), 500, ""),
                    new RecadastramentoCampoEntidade("Sexo", "Sexo", TipoCampo.Texto, false, ListasRecadastramento.BuscaValor(ListasRecadastramento.Sexo, DadosPessoais.SEXO), 500, ""),
                    new RecadastramentoCampoEntidade("Nacionalidade", "Nacionalidade", TipoCampo.Combo, true, nacionalidade, ListasRecadastramento.Nacionalidade),
                    new RecadastramentoCampoEntidade("EstadoCivil", "Estado Civil", TipoCampo.Combo, true, ListasRecadastramento.BuscaValor(ListasRecadastramento.EstadoCivil, DadosPessoais.CD_ESTADO_CIVIL),
                                                      ListasRecadastramento.EstadoCivil, Plano.DS_CATEGORIA == "ASSISTIDO" && CdPlano == "0001" ? true : false, false),
                    new RecadastramentoCampoEntidade("GrauInstrucao", "Grau de Instrução", TipoCampo.Combo, true, grauInstrucao, ListasRecadastramento.GrauInstrucao)
                }
            });

            passo.GrupoCampos.Add(new RecadastramentoGrupoEntidade
            {
                ID = "Identidade",
                Titulo = "Identidade",
                PodeComprovar = true,
                ExigeComprovacao = false,
                Campos = new List<RecadastramentoCampoEntidade>
                {
                    new RecadastramentoCampoEntidade("RG", "RG", TipoCampo.Texto, true, nuIdent, 20, ""),
                    new RecadastramentoCampoEntidade("OrgaoEmissor", "Órgão Emissor", TipoCampo.Texto, true, orgaoEmis, 8, ""),
                    new RecadastramentoCampoEntidade("DataEmissao", "Data de Emissão", TipoCampo.Texto, true, dtEmisIdent, 10, "date"),
                    new RecadastramentoCampoEntidade("CPF", "CPF", TipoCampo.Texto, false, cpf, 500, ""),
                    new RecadastramentoCampoEntidade("PISPASEP", "PIS/PASEP", TipoCampo.Texto, true, iss, 13, "number"),
                    new RecadastramentoCampoEntidade("Naturalidade", "Naturalidade", TipoCampo.Texto, true, naturalidade, 25, ""),
                    new RecadastramentoCampoEntidade("UF", "UF", TipoCampo.Texto, true, ufNaturalidade, 2, "")
                }
            });

            passo.GrupoCampos.Add(new RecadastramentoGrupoEntidade
            {
                ID = "Banco",
                Titulo = "Banco",
                Mensagem = "Quaisquer alterações, favor informar no RecadastramentoCampoEntidade Observações abaixo.",
                Campos = new List<RecadastramentoCampoEntidade>
                {
                    new RecadastramentoCampoEntidade("Banco", "Banco", TipoCampo.Texto, false, bancoAg, 500, ""),
                    new RecadastramentoCampoEntidade("Agencia", "Agência", TipoCampo.Texto, false, agencia, 500, ""),
                    new RecadastramentoCampoEntidade("Conta", "Conta", TipoCampo.Texto, false, numConta, 500, "")
                }
            });

            passo.GrupoCampos.Add(new RecadastramentoGrupoEntidade
            {
                ID = "Filiacao",
                Titulo = "Filiação",
                Campos = new List<RecadastramentoCampoEntidade>
                {
                    new RecadastramentoCampoEntidade("Pai", "Pai", TipoCampo.Texto, true, nomePai, 70, ""),
                    new RecadastramentoCampoEntidade("Mae", "Mãe", TipoCampo.Texto, true, nomeMae, 70, "")
                }
            });

            passo.GrupoCampos.Add(new RecadastramentoGrupoEntidade
            {
                ID = "Obs",
                Campos = new List<RecadastramentoCampoEntidade>
                {
                    new RecadastramentoCampoEntidade("Observacao", "Observação", TipoCampo.Texto, true, string.Empty, 100, "")
                }
            });

            return passo;
        }

        #endregion

        #region Passo 3 - Endereço

        RecadastramentoPassoEntidade CriarPasso3()
        {
            var passo = new RecadastramentoPassoEntidade
            {
                Numero = 3,
                Titulo = "Passo 3",
                Subtitulo = "Endereço",
                MensagemInicio = "Para alterar os dados de endereço esteja com um comprovante de residência em mãos e anexe uma foto ao aplicativo clicando no botão \"Anexar Arquivo\".",
                MensagemFim = ""
            };

            var endEntid = Entidade.END_ENTID;
            var nrEndEntid = Entidade.NR_END_ENTID;
            var compEndEntid = Entidade.COMP_END_ENTID;
            var cidEntid = Entidade.CID_ENTID;
            var cxPostal = Entidade.CX_POSTAL;
            var bairroEntid = Entidade.BAIRRO_ENTID;
            var ufEntid = Entidade.UF_ENTID;
            var cepEntid = Entidade.CEP_ENTID;
            var cdPais = ListasRecadastramento.BuscaValor(ListasRecadastramento.Pais, DadosPessoais.CD_PAIS);
            var foneEntid = Entidade.FONE_ENTID;
            var foneCelular = DadosPessoais.FONE_CELULAR;
            var foneTrab = Funcionario.FONE_TRAB;

            passo.GrupoCampos.Add(new RecadastramentoGrupoEntidade
            {
                ID = "Endereco",
                Titulo = "Endereço",
                PodeComprovar = true,
                ExigeComprovacao = false,
                Campos = new List<RecadastramentoCampoEntidade>
                {
                    new RecadastramentoCampoEntidade("Logradouro", "Logradouro", TipoCampo.Texto, true, endEntid, 60, ""),
                    new RecadastramentoCampoEntidade("Numero", "Numero", TipoCampo.Texto, true, nrEndEntid, 6, "number"),
                    new RecadastramentoCampoEntidade("Complemento", "Complemento", TipoCampo.Texto, true, compEndEntid, 30, ""),
                    new RecadastramentoCampoEntidade("Cidade", "Cidade", TipoCampo.Texto, true, cidEntid, 40, ""),
                    new RecadastramentoCampoEntidade("CaixaPostal", "Caixa Postal", TipoCampo.Texto, true, cxPostal, 10, "number"),
                    new RecadastramentoCampoEntidade("Bairro", "Bairro", TipoCampo.Texto, true, bairroEntid, 30, ""),
                    new RecadastramentoCampoEntidade("UF", "UF", TipoCampo.Texto, true, ufEntid, 2, ""),
                    new RecadastramentoCampoEntidade("CEP", "CEP", TipoCampo.Texto, true, cepEntid, 8, "number"),
                    new RecadastramentoCampoEntidade("Pais", "País", TipoCampo.Combo, true, cdPais, valores: ListasRecadastramento.Pais),
                    new RecadastramentoCampoEntidade("Telefone", "Telefone", TipoCampo.Texto, true, foneEntid, 20, ""),
                    new RecadastramentoCampoEntidade("Celular", "Celular", TipoCampo.Texto, true, foneCelular, 20, ""),
                    new RecadastramentoCampoEntidade("TelefoneComercial", "Telefone Comercial", TipoCampo.Texto, true, foneTrab, 20, ""),
                    new RecadastramentoCampoEntidade("Observacao", "Observação", TipoCampo.Texto, true, "", 100, "")
                }
            });

            var emails = new string[2] { string.Empty, string.Empty };

            if (DadosPessoais.EMAIL_AUX != null)
            {
                var split = DadosPessoais.EMAIL_AUX.Split(';');
                emails[0] = split[0];

                if (split.Length > 1)
                    emails[1] = split[1];
            }

            passo.GrupoCampos.Add(new RecadastramentoGrupoEntidade
            {
                ID = "Email",
                Titulo = "E-mail",
                Campos = new List<RecadastramentoCampoEntidade>
                {
                    new RecadastramentoCampoEntidade("Email1", "E-mail Primário", TipoCampo.Texto, true, emails[0], 30, "email"),
                    new RecadastramentoCampoEntidade("Email2", "E-mail Secundário", TipoCampo.Texto, true, emails[1], 29, "email")
                }
            });

            return passo;
        }

        #endregion

        #region Passo 4 - Dependentes

        RecadastramentoPassoEntidade CriarPasso4()
        {
            var passo = new RecadastramentoPassoEntidade
            {
                Numero = 4,
                Titulo = "Passo 4",
                Subtitulo = "Dependentes",
                MensagemInicio = "Para inclusão/exclusão de dependentes, favor informar no campo \"Observação\" ao final do recadastramento e anexar foto do documento comprobatório, por meio da opção Anexar Arquivo, para que a atualização seja efetivada pela Preves.",
                MensagemFim = "A FINALIZAÇÃO DO PROCESSO DE INSCRIÇÃO DO DEPENDENTE SERÁ CONCLUÍDA APÓS OBSERVADAS AS CONDIÇÕES DE ELEGIBILIDADE DO PLANO."
            };

            var dependentes = new DependenteProxy().BuscarPorFundacaoInscricaoPlano(CdFundacao, Inscricao, CdPlano);

            var listaDependentes = dependentes.ToList();

            if (CdPlano == "0001")
                listaDependentes = listaDependentes.Where(x => x.CD_PLANO == CdPlano && x.PLANO_PREVIDENCIAL == "S" || x.PECULIO == "S").ToList();
            else
                listaDependentes = listaDependentes.Where(x => x.CD_PLANO == CdPlano && x.PECULIO == "S").ToList();

            for (var i = 0; i < listaDependentes.Count; i++)
            {
                var dependente = listaDependentes[i];
                
                var planoDep = new PlanoVinculadoProxy().BuscarPorFundacaoEmpresaMatriculaPlano(CdFundacao, CdEmpresa, Matricula, dependente.CD_PLANO);

                var nomeDep = dependente.NOME_DEP;
                var sexoDep = ListasRecadastramento.BuscaValor(ListasRecadastramento.Sexo, dependente.SEXO_DEP);
                var dtNascDep = dependente.DT_NASC_DEP.ToString("dd/MM/yyyy");
                var grauParent = ListasRecadastramento.BuscaValor(ListasRecadastramento.GrauParentesco, dependente.CD_GRAU_PARENTESCO);

                var grupo = new RecadastramentoGrupoEntidade
                {
                    ID = $"Dependente_{dependente.NUM_SEQ_DEP}",
                    Titulo = "Dependente",
                    Campos = new List<RecadastramentoCampoEntidade>
                    {
                        new RecadastramentoCampoEntidade("Nome", "Nome", TipoCampo.Texto, true, nomeDep, 40, ""),
                        new RecadastramentoCampoEntidade("Sexo", "Sexo", TipoCampo.Combo, true, sexoDep, ListasRecadastramento.Sexo),
                        new RecadastramentoCampoEntidade("DataNascimento", "Data Nascimento", TipoCampo.Texto, true, dtNascDep, 10, "date"),
                        new RecadastramentoCampoEntidade("GrauParentesco", "Grau Parentesco", TipoCampo.Combo, true, grauParent, ListasRecadastramento.GrauParentesco)
                    }
                };

                if (Plano.DS_CATEGORIA != "ASSISTIDO")
                {
                    //grupo.PodeExcluir = true;
                    grupo.PodeComprovar = true;
                }

                var PlanoPrev = ListasRecadastramento.BuscaValor(ListasRecadastramento.SN, dependente.PLANO_PREVIDENCIAL);
                var peculio =ListasRecadastramento.BuscaValor(ListasRecadastramento.SN, dependente.PECULIO);

                if (CdPlano == "0001")
                    grupo.Campos.Add(new RecadastramentoCampoEntidade("PensaoMorte", "Pensão por Morte", TipoCampo.Combo, true, PlanoPrev, ListasRecadastramento.SN));

                grupo.Campos.Add(new RecadastramentoCampoEntidade("PeculioMorte", "Pecúlio por Morte", TipoCampo.Combo, true, peculio, ListasRecadastramento.SN));

                if (CdPlano != "0001" && CdPlano != "0002" && CdPlano != "0003")
                    grupo.Campos.Add(new RecadastramentoCampoEntidade("PercPeculioMorte", "Percentual do Pecúlio", TipoCampo.Texto, false, $"{dependente.PERC_PECULIO}%", 500, ""));

                grupo.Campos.Add(new RecadastramentoCampoEntidade("Plano", "Plano", TipoCampo.Texto, false, planoDep.DS_PLANO, 500, ""));

                passo.GrupoCampos.Add(grupo);
            }

            passo.GrupoCampos.Add(new RecadastramentoGrupoEntidade
            {
                ID = "Obs",
                Campos = new List<RecadastramentoCampoEntidade>
                {
                    new RecadastramentoCampoEntidade("Observacao", "Observação", TipoCampo.Texto, true, "", 100, "", true)
                }
            });

            return passo;
        }

        #endregion

        #region Passo 5 - Tempo de Serviço

        RecadastramentoPassoEntidade CriarPasso5()
        {
            var passo = new RecadastramentoPassoEntidade
            {
                Numero = 5,
                Titulo = "Passo 5",
                Subtitulo = "Tempo Serviço",
                MensagemInicio = "Para inclusão/exclusão de tempo de serviço, favor informar no campo \"Observação\" ao final do recadastramento e anexar foto do documento comprobatório, por meio da opção Anexar Arquivo, para que a atualização seja efetivada pela Preves.",
                MensagemFim = ""
            };

            var totalTempoServico = new Intervalo();

            var tempoServico = new TempoServicoProxy().BuscarPorCodEntid(Funcionario.COD_ENTID).ToList();

            for (var i = 0; i < tempoServico.Count; i++)
            {
                var tempo = tempoServico[i];

                var empregador = new EmpregadorProxy().BuscarPorCdEmpregador(tempo.CD_EMPREGADOR.Value);

                var editavel = (Plano.DS_CATEGORIA != "ASSISTIDO" || CdPlano != "0001") && CdPlano != "0002";

                var dsEmpregador = empregador.DS_EMPREGADOR;
                var dtInic = tempo.DT_INIC_ATIVIDADE?.ToString("dd/MM/yyyy");
                var dtTerm = tempo.DT_TERM_ATIVIDADE?.ToString("dd/MM/yyyy");

                var grupo = new RecadastramentoGrupoEntidade
                {
                    ID = $"TempoServico_{tempo.NUM_SEQ_EMP}",
                    Titulo = "Tempo de Serviço",
                    Campos = new List<RecadastramentoCampoEntidade>
                    {
                        new RecadastramentoCampoEntidade("Empresa", "Empresa", TipoCampo.Texto, editavel, dsEmpregador, 60, ""),
                        new RecadastramentoCampoEntidade("Admissao", "Admissão", TipoCampo.Texto, editavel, dtInic, 10, "date"),
                        new RecadastramentoCampoEntidade("Desligamento", "Desligamento", TipoCampo.Texto, editavel && tempo.DT_TERM_ATIVIDADE.HasValue, dtTerm, 10, "date")
                    }
                };

                if ((Plano.DS_CATEGORIA != "ASSISTIDO" || CdPlano != "0001") && CdPlano != "0002")
                {
                    //grupo.PodeExcluir = true;
                    grupo.PodeComprovar = true;
                    grupo.ExigeComprovacao = false;
                }

                passo.GrupoCampos.Add(grupo);

                if (!tempo.DT_TERM_ATIVIDADE.HasValue)
                    tempo.DT_TERM_ATIVIDADE = DateTime.Today;

                var tempoServ = new Intervalo(tempo.DT_TERM_ATIVIDADE.Value, tempo.DT_INIC_ATIVIDADE.Value);

                totalTempoServico += tempoServ;
            }

            passo.GrupoCampos.Add(new RecadastramentoGrupoEntidade
            {
                ID = "TempoTotal",
                Campos = new List<RecadastramentoCampoEntidade>
                {
                    new RecadastramentoCampoEntidade("TempoServicoTotal", "Tempo de serviço total com fim na data atual", TipoCampo.Texto, false, totalTempoServico.ToShortString(), 500, "")
                }
            });

            passo.GrupoCampos.Add(new RecadastramentoGrupoEntidade
            {
                ID = "Obs",
                Campos = new List<RecadastramentoCampoEntidade>
                {
                    new RecadastramentoCampoEntidade("Observacao", "Observação", TipoCampo.Texto, true, "", 100, "", true)
                }
            });

            return passo;
        }

        #endregion

        #region Passo 6 - Politicamente Exposto

        RecadastramentoPassoEntidade CriarPasso6()
        {
            var passo = new RecadastramentoPassoEntidade
            {
                Numero = 6,
                Titulo = "Passo 6",
                Subtitulo = "Politicamente Exposto",
                MensagemInicio = "Selecione nos campos abaixo as opções que se aplicam a você e seus familiares. A Instrução Normativa PREVIC nº 18, de 24 / 12 / 2014, disciplina a obrigatoriedade de prestação de informações relativas ao acompanhamento das operações realizadas por pessoas politicamente expostas. São consideradas pessoa politicamente exposta detentores de mandatos eletivos, ocupantes de cargo do Poder Executivo da União, Membros do Conselho Nacional de Justiça / STF e dos Tribunais Superiores(dentre outros).",
                MensagemFim = "* Detentores de mandatos eletivos, ocupantes de cargo do Poder Executivo da União, Membros do Conselho Nacional de Justiça / STF e dos Tribunais Superiores(dentre outros)."
            };

            var politExp = ListasRecadastramento.BuscaValor(ListasRecadastramento.SN, Entidade.POLIT_EXP);
            var tipoPpe = ListasRecadastramento.BuscaValor(ListasRecadastramento.SN, Entidade.TIPO_PPE);

            passo.GrupoCampos.Add(new RecadastramentoGrupoEntidade
            {
                ID = "Basico",
                Campos = new List<RecadastramentoCampoEntidade>
                {
                    new RecadastramentoCampoEntidade("PoliticamenteExposto", "Considera-se enquadrado como PESSOA POLITICAMENTE EXPOSTA* (IN SNPC 18/2014)?",
                                                     TipoCampo.Combo, true, politExp, ListasRecadastramento.SN),
                    new RecadastramentoCampoEntidade("FamiliarPoliticamenteExposto", "Há familiares (pais, filhos, cônjuge, companheira(o) ou enteado(a) que possam estar enquadrados como PESSOA POLITICAMENTE EXPOSTA na mesma situação?",
                                                     TipoCampo.Combo, true, tipoPpe, ListasRecadastramento.SN),
                    new RecadastramentoCampoEntidade("Observacao", "Observação", TipoCampo.Texto, true, "", 100, "")
                }
            });

            return passo;
        }

        #endregion

        #region Passo 7 - Fatca

        RecadastramentoPassoEntidade CriarPasso7()
        {
            var passo = new RecadastramentoPassoEntidade
            {
                Numero = 7,
                Titulo = "Passo 7",
                Subtitulo = "Fatca",
                MensagemInicio = "O FATCA é uma lei que determina que as Instituições Financeiras Estrangeiras (FFIS) devem identificar em sua base de clientes as \"US Persons\", de forma a garantir o repasse de informações anuais de operações de contas mantidas por cidadãos americanos para a receita federal dos Estados Unidos, nos termos do acordo para troca de informações assinado pelo Brasil com a receita federal americana. Serão considerados US Persons os participantes que possuam pelo menos 1(uma) das seguintes características: 1.Cidadania norte - americana, incluindo os detentores de dupla nacionalidade e passaporte norte - americano, ainda que residam fora dos Estados Unidos; 2.Detentores de Green Card; 3.Local de nascimento nos Estados Unidos; 4.Residência permanente nos Estados Unidos ou presença substancial(se ficou nos Estados Unidos pelo menos 31(trinta e um) dias no ano corrente e / ou 183 (cento e oitenta e três dias nos últimos três anos); Outras características que possam ser indicadas na regulamentação a ser publicada pela RFB.",
                MensagemFim = ""
            };

            var indFatca = ListasRecadastramento.BuscaValor(ListasRecadastramento.SN, Entidade.IND_FATCA);

            passo.GrupoCampos.Add(new RecadastramentoGrupoEntidade
            {
                ID = "Basico",
                Campos = new List<RecadastramentoCampoEntidade>
                {
                    new RecadastramentoCampoEntidade("Fatca", "Considera-se, para os devidos fins de direito sob as penas da lei, como US PERSON?",
                                                     TipoCampo.Combo, true, indFatca, ListasRecadastramento.SN),
                    new RecadastramentoCampoEntidade("Observacao", "Observação", TipoCampo.Texto, true, "", 500, "")
                }
            });

            return passo;
        }

        #endregion
    }

    #region ListasRecadastramento

    public static class ListasRecadastramento
    {
        public static List<Tuple<string, string>> SN = new List<Tuple<string, string>>
        {
            new Tuple<string, string>("N", "Não"),
            new Tuple<string, string>("S", "Sim")
        };

        public static List<Tuple<string, string>> Sexo = new List<Tuple<string, string>> {
            new Tuple<string, string>("F", "Feminino"),
            new Tuple<string, string>("M", "Masculino")
        };

        public static List<Tuple<string, string>> GrauParentesco = new List<Tuple<string, string>>
        {
            new Tuple<string, string>("01", "CONJUGE"),
            new Tuple<string, string>("02", "COMPANHEIRO"),
            new Tuple<string, string>("03", "FILHO MENOR 21 ANOS"),
            new Tuple<string, string>("04", "FILHO ATE 24 ANOS UNIVERSIT."),
            new Tuple<string, string>("05", "ENTEADO MENOR  21 ANOS"),
            new Tuple<string, string>("06", "ENTEADO ATE 24 ANOS UNIVERSIT."),
            new Tuple<string, string>("07", "FILHO INVALIDO"),
            new Tuple<string, string>("08", "ENTEADO INVALIDO"),
            new Tuple<string, string>("09", "EX-CONJUGE PENSAO ALIMENTICIA"),
            new Tuple<string, string>("10", "EX-COMPANHEIRO C/ PENSAO ALIM."),
            new Tuple<string, string>("11", "MENOR SOB GUARDA E SOB TUTELA"),
            new Tuple<string, string>("12", "PAI INVALIDO COM DEP.ECONOMICA"),
            new Tuple<string, string>("13", "MAE DEPENDENTE ECONOMICA"),
            new Tuple<string, string>("14", "IRMAO DEP. ECONOM. ATE 21 ANOS"),
            new Tuple<string, string>("15", "IRMAO INVALIDO"),
            new Tuple<string, string>("16", "FILHO MAIOR DE 21 ANOS"),
            new Tuple<string, string>("17", "PAI"),
            new Tuple<string, string>("18", "MAE"),
            new Tuple<string, string>("19", "IRMAO"),
            new Tuple<string, string>("21", "DESIGNADO"),
            new Tuple<string, string>("23", "ENTEADO MAIOR DE 21 ANOS")
        };

        public static List<Tuple<string, string>> Nacionalidade = new List<Tuple<string, string>>
        {
            new Tuple<string, string>("01", "BRASILEIRA"),
            new Tuple<string, string>("02", "NATURALIZADO"),
            new Tuple<string, string>("03", "EQUIPARADO"),
            new Tuple<string, string>("05", "NORTE AMERICANA"),
            new Tuple<string, string>("10", "OUTROS"),
            new Tuple<string, string>("20", "ESTRANGEIRA")
        };

        public static List<Tuple<string, string>> EstadoCivil = new List<Tuple<string, string>>
        {
            new Tuple<string, string>("1", "SOLTEIRO"),
            new Tuple<string, string>("2", "CASADO"),
            new Tuple<string, string>("3", "VIUVO"),
            new Tuple<string, string>("4", "DESQUITADO"),
            new Tuple<string, string>("5", "DIVORCIADO"),
            new Tuple<string, string>("6", "V.MARITALMENTE"),
            new Tuple<string, string>("7", "SEPARADO"),
            new Tuple<string, string>("8", "SEPARADO"),
            new Tuple<string, string>("9", "A CONFIRMAR")
        };

        public static List<Tuple<string, string>> GrauInstrucao = new List<Tuple<string, string>>
        {
            new Tuple<string, string>("0", "A CONFIRMAR"),
            new Tuple<string, string>("1", "1 GRAU INCOMP"),
            new Tuple<string, string>("2", "1 GRAU COMP"),
            new Tuple<string, string>("3", "2 GRAU INCOMP"),
            new Tuple<string, string>("4", "2 GRAU COMP"),
            new Tuple<string, string>("5", "3 GRAU INCOMP"),
            new Tuple<string, string>("6", "3 GRAU COMP"),
            new Tuple<string, string>("7", "POS GRADUADO"),
            new Tuple<string, string>("8", "MESTRADO/DOUTOR"),
            new Tuple<string, string>("9", "ANALFABETO")
        };

        public static List<Tuple<string, string>> Pais = new List<Tuple<string, string>>
        {
            new Tuple<string, string>("001", "BRASIL"),
            new Tuple<string, string>("002", "ESTADOS UNIDOS")
        };

        public static string BuscaValor(List<Tuple<string, string>> lista, string chave)
        {
            var valor = lista.SingleOrDefault(x => x.Item1 == chave);

            if (valor != null)
                return valor.Item2;
            else
                return lista[0].Item2;
        }
    }

    #endregion
}
