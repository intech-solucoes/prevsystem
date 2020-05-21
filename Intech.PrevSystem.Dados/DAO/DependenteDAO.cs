﻿using Dapper;
using Intech.Lib.Dapper;
using Intech.Lib.Web;
using Intech.PrevSystem.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Intech.PrevSystem.Dados.DAO
{
	public abstract class DependenteDAO : BaseDAO<DependenteEntidade>
	{
		public virtual void AtualizarDependente(string CD_FUNDACAO, string NUM_INSCRICAO, decimal NUM_SEQ_DEP, string NOME_DEP, string CD_GRAU_PARENTESCO, string SEXO_DEP, DateTime DT_NASC_DEP, string ABATIMENTO_IRRF, DateTime DT_VALIDADE_DEP, string CD_MOT_PERDA_VALIDADE, DateTime DT_INCLUSAO_DEP, DateTime? DT_INIC_IRRF, DateTime? DT_TERM_IRRF, string PECULIO, string NUM_PROTOCOLO, string CPF, string IDENTIDADE, string ORGAO_EXP, DateTime? DT_EXPEDICAO, string CD_PLANO, string CD_NACIONALIDADE, string CD_ESTADO_CIVIL, string NATURALIDADE, string UF_NATURALIDADE, string EMAIL_DEP, string FONE_CELULAR, string NUM_BANCO, string NUM_CONTA, string NUM_AGENCIA, string END_DEP, string COMP_END_DEP, string BAIRRO_DEP, string CID_DEP, string UF_DEP, string CD_PAIS, string FONE_DEP, string CEP_DEP)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					Conexao.Execute("UPDATE CS_DEPENDENTE  SET NOME_DEP = @NOME_DEP, CD_GRAU_PARENTESCO = @CD_GRAU_PARENTESCO, SEXO_DEP = @SEXO_DEP, DT_NASC_DEP = @DT_NASC_DEP, ABATIMENTO_IRRF = @ABATIMENTO_IRRF,  DT_VALIDADE_DEP = @DT_VALIDADE_DEP, CD_MOT_PERDA_VALIDADE = @CD_MOT_PERDA_VALIDADE, DT_INCLUSAO_DEP = @DT_INCLUSAO_DEP, DT_INIC_IRRF = @DT_INIC_IRRF,  DT_TERM_IRRF = @DT_TERM_IRRF, PECULIO = @PECULIO, NUM_PROTOCOLO = @NUM_PROTOCOLO, CPF = @CPF, IDENTIDADE = @IDENTIDADE, ORGAO_EXP = @ORGAO_EXP,  DT_EXPEDICAO = @DT_EXPEDICAO, CD_PLANO = @CD_PLANO, CD_NACIONALIDADE = @CD_NACIONALIDADE, CD_ESTADO_CIVIL = @CD_ESTADO_CIVIL, NATURALIDADE = @NATURALIDADE,  UF_NATURALIDADE = @UF_NATURALIDADE, EMAIL_DEP = @EMAIL_DEP, FONE_CELULAR = @FONE_CELULAR, NUM_BANCO = @NUM_BANCO, NUM_CONTA = @NUM_CONTA, NUM_AGENCIA = @NUM_AGENCIA,  END_DEP = @END_DEP, COMP_END_DEP = @COMP_END_DEP, BAIRRO_DEP = @BAIRRO_DEP, CID_DEP = @CID_DEP, UF_DEP = @UF_DEP, CD_PAIS = @CD_PAIS,  FONE_DEP = @FONE_DEP, CEP_DEP = @CEP_DEP   WHERE CD_FUNDACAO = @CD_FUNDACAO     AND NUM_INSCRICAO = @NUM_INSCRICAO    AND NUM_SEQ_DEP = @NUM_SEQ_DEP", new { CD_FUNDACAO, NUM_INSCRICAO, NUM_SEQ_DEP, NOME_DEP, CD_GRAU_PARENTESCO, SEXO_DEP, DT_NASC_DEP, ABATIMENTO_IRRF, DT_VALIDADE_DEP, CD_MOT_PERDA_VALIDADE, DT_INCLUSAO_DEP, DT_INIC_IRRF, DT_TERM_IRRF, PECULIO, NUM_PROTOCOLO, CPF, IDENTIDADE, ORGAO_EXP, DT_EXPEDICAO, CD_PLANO, CD_NACIONALIDADE, CD_ESTADO_CIVIL, NATURALIDADE, UF_NATURALIDADE, EMAIL_DEP, FONE_CELULAR, NUM_BANCO, NUM_CONTA, NUM_AGENCIA, END_DEP, COMP_END_DEP, BAIRRO_DEP, CID_DEP, UF_DEP, CD_PAIS, FONE_DEP, CEP_DEP });
				else if (AppSettings.IS_ORACLE_PROVIDER)
					Conexao.Execute("UPDATE CS_DEPENDENTE SET NOME_DEP=:NOME_DEP, CD_GRAU_PARENTESCO=:CD_GRAU_PARENTESCO, SEXO_DEP=:SEXO_DEP, DT_NASC_DEP=:DT_NASC_DEP, ABATIMENTO_IRRF=:ABATIMENTO_IRRF, DT_VALIDADE_DEP=:DT_VALIDADE_DEP, CD_MOT_PERDA_VALIDADE=:CD_MOT_PERDA_VALIDADE, DT_INCLUSAO_DEP=:DT_INCLUSAO_DEP, DT_INIC_IRRF=:DT_INIC_IRRF, DT_TERM_IRRF=:DT_TERM_IRRF, PECULIO=:PECULIO, NUM_PROTOCOLO=:NUM_PROTOCOLO, CPF=:CPF, IDENTIDADE=:IDENTIDADE, ORGAO_EXP=:ORGAO_EXP, DT_EXPEDICAO=:DT_EXPEDICAO, CD_PLANO=:CD_PLANO, CD_NACIONALIDADE=:CD_NACIONALIDADE, CD_ESTADO_CIVIL=:CD_ESTADO_CIVIL, NATURALIDADE=:NATURALIDADE, UF_NATURALIDADE=:UF_NATURALIDADE, EMAIL_DEP=:EMAIL_DEP, FONE_CELULAR=:FONE_CELULAR, NUM_BANCO=:NUM_BANCO, NUM_CONTA=:NUM_CONTA, NUM_AGENCIA=:NUM_AGENCIA, END_DEP=:END_DEP, COMP_END_DEP=:COMP_END_DEP, BAIRRO_DEP=:BAIRRO_DEP, CID_DEP=:CID_DEP, UF_DEP=:UF_DEP, CD_PAIS=:CD_PAIS, FONE_DEP=:FONE_DEP, CEP_DEP=:CEP_DEP WHERE CD_FUNDACAO=:CD_FUNDACAO AND NUM_INSCRICAO=:NUM_INSCRICAO AND NUM_SEQ_DEP=:NUM_SEQ_DEP", new { CD_FUNDACAO, NUM_INSCRICAO, NUM_SEQ_DEP, NOME_DEP, CD_GRAU_PARENTESCO, SEXO_DEP, DT_NASC_DEP, ABATIMENTO_IRRF, DT_VALIDADE_DEP, CD_MOT_PERDA_VALIDADE, DT_INCLUSAO_DEP, DT_INIC_IRRF, DT_TERM_IRRF, PECULIO, NUM_PROTOCOLO, CPF, IDENTIDADE, ORGAO_EXP, DT_EXPEDICAO, CD_PLANO, CD_NACIONALIDADE, CD_ESTADO_CIVIL, NATURALIDADE, UF_NATURALIDADE, EMAIL_DEP, FONE_CELULAR, NUM_BANCO, NUM_CONTA, NUM_AGENCIA, END_DEP, COMP_END_DEP, BAIRRO_DEP, CID_DEP, UF_DEP, CD_PAIS, FONE_DEP, CEP_DEP });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual List<DependenteEntidade> BuscarPorFundacaoInscricao(string CD_FUNDACAO, string NUM_INSCRICAO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<DependenteEntidade>("SELECT *,  TB_GRAU_PARENTESCO.DS_GRAU_PARENTESCO    FROM CS_DEPENDENTE  INNER JOIN TB_GRAU_PARENTESCO ON TB_GRAU_PARENTESCO.CD_GRAU_PARENTESCO = CS_DEPENDENTE.CD_GRAU_PARENTESCO  WHERE CD_FUNDACAO = @CD_FUNDACAO    AND NUM_INSCRICAO = @NUM_INSCRICAO  ORDER BY NOME_DEP", new { CD_FUNDACAO, NUM_INSCRICAO }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<DependenteEntidade>("SELECT *, TB_GRAU_PARENTESCO.DS_GRAU_PARENTESCO FROM CS_DEPENDENTE INNER  JOIN TB_GRAU_PARENTESCO  ON TB_GRAU_PARENTESCO.CD_GRAU_PARENTESCO=CS_DEPENDENTE.CD_GRAU_PARENTESCO WHERE CD_FUNDACAO=:CD_FUNDACAO AND NUM_INSCRICAO=:NUM_INSCRICAO ORDER BY NOME_DEP", new { CD_FUNDACAO, NUM_INSCRICAO }).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual List<DependenteEntidade> BuscarPorFundacaoInscricaoPlano(string CD_FUNDACAO, string NUM_INSCRICAO, string CD_PLANO)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<DependenteEntidade>("SELECT *,  TB_GRAU_PARENTESCO.DS_GRAU_PARENTESCO    FROM CS_DEPENDENTE  INNER JOIN TB_GRAU_PARENTESCO ON TB_GRAU_PARENTESCO.CD_GRAU_PARENTESCO = CS_DEPENDENTE.CD_GRAU_PARENTESCO  WHERE CD_FUNDACAO = @CD_FUNDACAO    AND NUM_INSCRICAO = @NUM_INSCRICAO    AND CD_PLANO = @CD_PLANO  ORDER BY NOME_DEP", new { CD_FUNDACAO, NUM_INSCRICAO, CD_PLANO }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<DependenteEntidade>("SELECT *, TB_GRAU_PARENTESCO.DS_GRAU_PARENTESCO FROM CS_DEPENDENTE INNER  JOIN TB_GRAU_PARENTESCO  ON TB_GRAU_PARENTESCO.CD_GRAU_PARENTESCO=CS_DEPENDENTE.CD_GRAU_PARENTESCO WHERE CD_FUNDACAO=:CD_FUNDACAO AND NUM_INSCRICAO=:NUM_INSCRICAO AND CD_PLANO=:CD_PLANO ORDER BY NOME_DEP", new { CD_FUNDACAO, NUM_INSCRICAO, CD_PLANO }).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual List<DependenteEntidade> BuscarPorFundacaoInscricaoSeqDep(string CD_FUNDACAO, string NUM_INSCRICAO, string NUM_SEQ_DEP)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					return Conexao.Query<DependenteEntidade>("SELECT *,  TB_GRAU_PARENTESCO.DS_GRAU_PARENTESCO    FROM CS_DEPENDENTE  INNER JOIN TB_GRAU_PARENTESCO ON TB_GRAU_PARENTESCO.CD_GRAU_PARENTESCO = CS_DEPENDENTE.CD_GRAU_PARENTESCO  WHERE CD_FUNDACAO = @CD_FUNDACAO    AND NUM_INSCRICAO = @NUM_INSCRICAO    AND NUM_SEQ_DEP = @NUM_SEQ_DEP  ORDER BY NOME_DEP", new { CD_FUNDACAO, NUM_INSCRICAO, NUM_SEQ_DEP }).ToList();
				else if (AppSettings.IS_ORACLE_PROVIDER)
					return Conexao.Query<DependenteEntidade>("SELECT *, TB_GRAU_PARENTESCO.DS_GRAU_PARENTESCO FROM CS_DEPENDENTE INNER  JOIN TB_GRAU_PARENTESCO  ON TB_GRAU_PARENTESCO.CD_GRAU_PARENTESCO=CS_DEPENDENTE.CD_GRAU_PARENTESCO WHERE CD_FUNDACAO=:CD_FUNDACAO AND NUM_INSCRICAO=:NUM_INSCRICAO AND NUM_SEQ_DEP=:NUM_SEQ_DEP ORDER BY NOME_DEP", new { CD_FUNDACAO, NUM_INSCRICAO, NUM_SEQ_DEP }).ToList();
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual void ExcluirDependente(string CD_FUNDACAO, string NUM_INSCRICAO, decimal NUM_SEQ_DEP)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					Conexao.Execute("DELETE FROM CS_DEPENDENTE   WHERE CD_FUNDACAO = @CD_FUNDACAO    AND NUM_INSCRICAO =@NUM_INSCRICAO    AND NUM_SEQ_DEP = @NUM_SEQ_DEP", new { CD_FUNDACAO, NUM_INSCRICAO, NUM_SEQ_DEP });
				else if (AppSettings.IS_ORACLE_PROVIDER)
					Conexao.Execute("DELETE FROM CS_DEPENDENTE WHERE CD_FUNDACAO=:CD_FUNDACAO AND NUM_INSCRICAO=:NUM_INSCRICAO AND NUM_SEQ_DEP=:NUM_SEQ_DEP", new { CD_FUNDACAO, NUM_INSCRICAO, NUM_SEQ_DEP });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

		public virtual void IncluirDependente(string CD_FUNDACAO, string NUM_INSCRICAO, decimal NUM_SEQ_DEP, string NOME_DEP, string CD_GRAU_PARENTESCO, string SEXO_DEP, DateTime DT_NASC_DEP, string ABATIMENTO_IRRF, DateTime DT_VALIDADE_DEP, string CD_MOT_PERDA_VALIDADE, DateTime DT_INCLUSAO_DEP, string PLANO_ASSISTENCIAL, string PLANO_PREVIDENCIAL, DateTime? DT_INIC_IRRF, DateTime? DT_TERM_IRRF, string PECULIO, string NUM_PROTOCOLO, string CPF, string IDENTIDADE, string ORGAO_EXP, DateTime? DT_EXPEDICAO, string CD_PLANO, string CD_NACIONALIDADE, string CD_ESTADO_CIVIL, string NATURALIDADE, string UF_NATURALIDADE, string EMAIL_DEP, string FONE_CELULAR, string NUM_BANCO, string NUM_CONTA, string NUM_AGENCIA, string END_DEP, string COMP_END_DEP, string BAIRRO_DEP, string CID_DEP, string UF_DEP, string CD_PAIS, string FONE_DEP, string CEP_DEP)
		{
			try
			{
				if (AppSettings.IS_SQL_SERVER_PROVIDER)
					Conexao.Execute("INSERT INTO CS_DEPENDENTE   ( CD_FUNDACAO, NUM_INSCRICAO, NUM_SEQ_DEP, NOME_DEP, CD_GRAU_PARENTESCO, SEXO_DEP, DT_NASC_DEP,    ABATIMENTO_IRRF, DT_VALIDADE_DEP, DT_INCLUSAO_DEP, PLANO_ASSISTENCIAL, PLANO_PREVIDENCIAL, CD_MOT_PERDA_VALIDADE, DT_INIC_IRRF,   DT_TERM_IRRF, PECULIO, NUM_PROTOCOLO, CPF, IDENTIDADE, ORGAO_EXP, DT_EXPEDICAO, CD_PLANO,    CD_NACIONALIDADE, CD_ESTADO_CIVIL, NATURALIDADE, UF_NATURALIDADE, EMAIL_DEP, FONE_CELULAR,    NUM_BANCO, NUM_CONTA, NUM_AGENCIA, END_DEP, COMP_END_DEP, BAIRRO_DEP, CID_DEP, UF_DEP, CD_PAIS, FONE_DEP, CEP_DEP  )  VALUES  (   @CD_FUNDACAO, @NUM_INSCRICAO, @NUM_SEQ_DEP, @NOME_DEP, @CD_GRAU_PARENTESCO, @SEXO_DEP, @DT_NASC_DEP,    @ABATIMENTO_IRRF, @DT_VALIDADE_DEP, @DT_INCLUSAO_DEP, @PLANO_ASSISTENCIAL, @PLANO_PREVIDENCIAL, @CD_MOT_PERDA_VALIDADE, @DT_INIC_IRRF,   @DT_TERM_IRRF, @PECULIO, @NUM_PROTOCOLO, @CPF, @IDENTIDADE, @ORGAO_EXP, @DT_EXPEDICAO, @CD_PLANO,    @CD_NACIONALIDADE, @CD_ESTADO_CIVIL, @NATURALIDADE, @UF_NATURALIDADE, @EMAIL_DEP, @FONE_CELULAR,    @NUM_BANCO, @NUM_CONTA, @NUM_AGENCIA, @END_DEP, @COMP_END_DEP, @BAIRRO_DEP, @CID_DEP, @UF_DEP, @CD_PAIS, @FONE_DEP, @CEP_DEP  )", new { CD_FUNDACAO, NUM_INSCRICAO, NUM_SEQ_DEP, NOME_DEP, CD_GRAU_PARENTESCO, SEXO_DEP, DT_NASC_DEP, ABATIMENTO_IRRF, DT_VALIDADE_DEP, CD_MOT_PERDA_VALIDADE, DT_INCLUSAO_DEP, PLANO_ASSISTENCIAL, PLANO_PREVIDENCIAL, DT_INIC_IRRF, DT_TERM_IRRF, PECULIO, NUM_PROTOCOLO, CPF, IDENTIDADE, ORGAO_EXP, DT_EXPEDICAO, CD_PLANO, CD_NACIONALIDADE, CD_ESTADO_CIVIL, NATURALIDADE, UF_NATURALIDADE, EMAIL_DEP, FONE_CELULAR, NUM_BANCO, NUM_CONTA, NUM_AGENCIA, END_DEP, COMP_END_DEP, BAIRRO_DEP, CID_DEP, UF_DEP, CD_PAIS, FONE_DEP, CEP_DEP });
				else if (AppSettings.IS_ORACLE_PROVIDER)
					Conexao.Execute("INSERT INTO CS_DEPENDENTE (CD_FUNDACAO, NUM_INSCRICAO, NUM_SEQ_DEP, NOME_DEP, CD_GRAU_PARENTESCO, SEXO_DEP, DT_NASC_DEP, ABATIMENTO_IRRF, DT_VALIDADE_DEP, DT_INCLUSAO_DEP, PLANO_ASSISTENCIAL, PLANO_PREVIDENCIAL, CD_MOT_PERDA_VALIDADE, DT_INIC_IRRF, DT_TERM_IRRF, PECULIO, NUM_PROTOCOLO, CPF, IDENTIDADE, ORGAO_EXP, DT_EXPEDICAO, CD_PLANO, CD_NACIONALIDADE, CD_ESTADO_CIVIL, NATURALIDADE, UF_NATURALIDADE, EMAIL_DEP, FONE_CELULAR, NUM_BANCO, NUM_CONTA, NUM_AGENCIA, END_DEP, COMP_END_DEP, BAIRRO_DEP, CID_DEP, UF_DEP, CD_PAIS, FONE_DEP, CEP_DEP) VALUES (:CD_FUNDACAO, :NUM_INSCRICAO, :NUM_SEQ_DEP, :NOME_DEP, :CD_GRAU_PARENTESCO, :SEXO_DEP, :DT_NASC_DEP, :ABATIMENTO_IRRF, :DT_VALIDADE_DEP, :DT_INCLUSAO_DEP, :PLANO_ASSISTENCIAL, :PLANO_PREVIDENCIAL, :CD_MOT_PERDA_VALIDADE, :DT_INIC_IRRF, :DT_TERM_IRRF, :PECULIO, :NUM_PROTOCOLO, :CPF, :IDENTIDADE, :ORGAO_EXP, :DT_EXPEDICAO, :CD_PLANO, :CD_NACIONALIDADE, :CD_ESTADO_CIVIL, :NATURALIDADE, :UF_NATURALIDADE, :EMAIL_DEP, :FONE_CELULAR, :NUM_BANCO, :NUM_CONTA, :NUM_AGENCIA, :END_DEP, :COMP_END_DEP, :BAIRRO_DEP, :CID_DEP, :UF_DEP, :CD_PAIS, :FONE_DEP, :CEP_DEP)", new { CD_FUNDACAO, NUM_INSCRICAO, NUM_SEQ_DEP, NOME_DEP, CD_GRAU_PARENTESCO, SEXO_DEP, DT_NASC_DEP, ABATIMENTO_IRRF, DT_VALIDADE_DEP, CD_MOT_PERDA_VALIDADE, DT_INCLUSAO_DEP, PLANO_ASSISTENCIAL, PLANO_PREVIDENCIAL, DT_INIC_IRRF, DT_TERM_IRRF, PECULIO, NUM_PROTOCOLO, CPF, IDENTIDADE, ORGAO_EXP, DT_EXPEDICAO, CD_PLANO, CD_NACIONALIDADE, CD_ESTADO_CIVIL, NATURALIDADE, UF_NATURALIDADE, EMAIL_DEP, FONE_CELULAR, NUM_BANCO, NUM_CONTA, NUM_AGENCIA, END_DEP, COMP_END_DEP, BAIRRO_DEP, CID_DEP, UF_DEP, CD_PAIS, FONE_DEP, CEP_DEP });
				else
					throw new Exception("Provider não suportado!");
			}
			finally
			{
				Conexao.Close();
			}
		}

	}
}
