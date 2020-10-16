/*==============================================================*/
/* DBMS name:      ORACLE Version 11g                           */
/* Created on:     15/09/2020 16:36:13                          */
/*==============================================================*/


CREATE SEQUENCE S_REC_SOLICITACAO;

CREATE SEQUENCE S_REC_SOLICITACAO_VALOR;

CREATE SEQUENCE S_WEB_ACESSO_GRUPO_USUARIO;

CREATE SEQUENCE S_WEB_ADESAO;

CREATE SEQUENCE S_WEB_ADESAO_CONTRIB;

CREATE SEQUENCE S_WEB_ADESAO_DEPENDENTE;

CREATE SEQUENCE S_WEB_ADESAO_DOCUMENTO;

CREATE SEQUENCE S_WEB_ADESAO_EMPRESA_PLANO;

CREATE SEQUENCE S_WEB_ADESAO_PLANO;

CREATE SEQUENCE S_WEB_AREA_FUNDACAO;

CREATE SEQUENCE S_WEB_ASSUNTO;

CREATE SEQUENCE S_WEB_BLOQUEIO_FUNC;

CREATE SEQUENCE S_WEB_CALENDARIO_PGT;

CREATE SEQUENCE S_WEB_CONTRIBUICAO;

CREATE SEQUENCE S_WEB_DISPOSITIVO;

CREATE SEQUENCE S_WEB_DOCUMENTO;

CREATE SEQUENCE S_WEB_DOCUMENTO_PASTA;

CREATE SEQUENCE S_WEB_DOCUMENTO_PLANO;

CREATE SEQUENCE S_WEB_DOC_ATU_CADASTRAL;

CREATE SEQUENCE S_WEB_FATOR_ATUARIAL;

CREATE SEQUENCE S_WEB_FATOR_RISCO;

CREATE SEQUENCE S_WEB_FUNCIONALIDADE;

CREATE SEQUENCE S_WEB_GRUPO_USUARIO;

CREATE SEQUENCE S_WEB_LGPD_CONSENTIMENTO;

CREATE SEQUENCE S_WEB_LIMITE_CONTRIBUICAO;

CREATE SEQUENCE S_WEB_MAXIMO_BASICA;

CREATE SEQUENCE S_WEB_MENSAGEM;

CREATE SEQUENCE S_WEB_PERC_CONTRIBUICAO;

CREATE SEQUENCE S_WEB_PROTOCOLO;

CREATE SEQUENCE S_WEB_PROTOCOLO_PW;

CREATE SEQUENCE S_WEB_RECAD_BENEFICIARIO;

CREATE SEQUENCE S_WEB_RECAD_CAMPANHA;

CREATE SEQUENCE S_WEB_RECAD_DADOS;

CREATE SEQUENCE S_WEB_RECAD_DEPENDENTE_IR;

CREATE SEQUENCE S_WEB_RECAD_DOCUMENTO;

CREATE SEQUENCE S_WEB_RECAD_PUBLICO_ALVO;

CREATE SEQUENCE S_WEB_RELACIONAMENTO;

CREATE SEQUENCE S_WEB_USUARIO;

CREATE SEQUENCE S_WEB_USUARIO_GRUPO;

/*==============================================================*/
/* Table: WEB_ACESSO_GRUPO_USUARIO                              */
/*==============================================================*/
CREATE TABLE WEB_ACESSO_GRUPO_USUARIO 
(
   OID_ACESSO_GRUPO_USUARIO NUMBER(10)           NOT NULL,
   OID_GRUPO_USUARIO    NUMBER(10)           NOT NULL,
   OID_FUNCIONALIDADE   NUMBER(10)           NOT NULL,
   IND_ACESSO           VARCHAR2(3)         
      CONSTRAINT CKC_IND_ACESSO_WEB_ACES CHECK (IND_ACESSO IS NULL OR (IND_ACESSO IN ('SIM','NAO') AND IND_ACESSO = UPPER(IND_ACESSO))),
   CONSTRAINT WEB_ACESSO_GRUPO_USUARIO_PK PRIMARY KEY (OID_ACESSO_GRUPO_USUARIO)
);

/*==============================================================*/
/* Index: WEB_ACESSO_GRUPO_USUARIO_UK01                         */
/*==============================================================*/
CREATE UNIQUE INDEX WEB_ACESSO_GRUPO_USUARIO_UK01 ON WEB_ACESSO_GRUPO_USUARIO (
   OID_GRUPO_USUARIO ASC,
   OID_FUNCIONALIDADE ASC
);

/*==============================================================*/
/* Table: WEB_ADESAO                                            */
/*==============================================================*/
CREATE TABLE WEB_ADESAO 
(
   OID_ADESAO           NUMBER(10)           NOT NULL,
   COD_FUNDACAO         VARCHAR2(20)         NOT NULL,
   COD_CPF              VARCHAR2(11)         NOT NULL,
   NOM_PESSOA           VARCHAR2(100)        NOT NULL,
   DTA_NASCIMENTO       DATE                 NOT NULL,
   COD_EMPRESA          VARCHAR2(20)         NOT NULL,
   DES_EMPRESA          VARCHAR2(100)        NOT NULL,
   COD_MATRICULA        VARCHAR2(20)         NOT NULL,
   DTA_ADMISSAO         DATE                 NOT NULL,
   COD_EMAIL            VARCHAR2(100)        NOT NULL,
   COD_CARGO            VARCHAR2(20),
   DES_CARGO            VARCHAR2(100),
   COD_SEXO             VARCHAR2(3)          NOT NULL,
   DES_SEXO             VARCHAR2(20),
   COD_NACIONALIDADE    VARCHAR2(20),
   DES_NACIONALIDADE    VARCHAR2(100),
   COD_NATURALIDADE     VARCHAR2(20),
   DES_NATURALIDADE     VARCHAR2(100),
   COD_UF_NATURALIDADE  VARCHAR2(2),
   DES_UF_NATURALIDADE  VARCHAR2(100),
   COD_RG               VARCHAR2(20),
   DES_ORGAO_EXPEDIDOR  VARCHAR2(100),
   DTA_EXPEDICAO_RG     DATE,
   COD_ESTADO_CIVIL     VARCHAR2(20),
   DES_ESTADO_CIVIL     VARCHAR2(100),
   NOM_MAE              VARCHAR2(100)        NOT NULL,
   NOM_PAI              VARCHAR2(100),
   COD_CEP              VARCHAR2(8)          NOT NULL,
   DES_END_LOGRADOURO   VARCHAR2(100)        NOT NULL,
   DES_END_NUMERO       VARCHAR2(50),
   DES_END_COMPLEMENTO  VARCHAR2(100),
   DES_END_BAIRRO       VARCHAR2(100)        NOT NULL,
   DES_END_CIDADE       VARCHAR2(100)        NOT NULL,
   COD_END_UF           VARCHAR2(2)          NOT NULL,
   DES_END_UF           VARCHAR2(100)        NOT NULL,
   COD_TELEFONE_FIXO    VARCHAR2(20),
   COD_TELEFONE_CELULAR VARCHAR2(20),
   COD_BANCO            VARCHAR2(3),
   DES_BANCO            VARCHAR2(100),
   COD_AGENCIA          VARCHAR2(20),
   COD_DV_AGENCIA       VARCHAR2(2),
   COD_CONTA_CORRENTE   VARCHAR2(20),
   COD_DV_CONTA_CORRENTE VARCHAR2(2),
   IND_PPE              VARCHAR2(3)          NOT NULL,
   IND_PPE_FAMILIAR     VARCHAR2(3)          NOT NULL,
   IND_FATCA            VARCHAR2(3)          NOT NULL,
   IND_SIT_ADESAO       VARCHAR2(3)          NOT NULL,
   DTA_CRIACAO          DATE                 NOT NULL,
   CONSTRAINT WEB_ADESAO_PK PRIMARY KEY (OID_ADESAO)
);

/*==============================================================*/
/* Table: WEB_ADESAO_CONTRIB                                    */
/*==============================================================*/
CREATE TABLE WEB_ADESAO_CONTRIB 
(
   OID_ADESAO_CONTRIB   NUMBER(10)           NOT NULL,
   OID_ADESAO_PLANO     NUMBER(10)           NOT NULL,
   COD_CONTRIBUICAO     VARCHAR2(20)         NOT NULL,
   DES_CONTRIBUICAO     VARCHAR2(100)        NOT NULL,
   VAL_CONTRIBUICAO     NUMBER(15,8)         NOT NULL,
   IND_VALOR_PERC       VARCHAR2(3)          NOT NULL,
   CONSTRAINT PK_WEB_ADESAO_CONTRIB PRIMARY KEY (OID_ADESAO_CONTRIB)
);

/*==============================================================*/
/* Table: WEB_ADESAO_DEPENDENTE                                 */
/*==============================================================*/
CREATE TABLE WEB_ADESAO_DEPENDENTE 
(
   OID_ADESAO_DEPENDENTE NUMBER(10)           NOT NULL,
   OID_ADESAO           NUMBER(10)           NOT NULL,
   NOM_DEPENDENTE       VARCHAR2(100)        NOT NULL,
   COD_GRAU_PARENTESCO  VARCHAR2(20)         NOT NULL,
   DES_GRAU_PARENTESCO  VARCHAR2(100)        NOT NULL,
   DTA_NASCIMENTO       DATE                 NOT NULL,
   COD_SEXO             VARCHAR2(3)          NOT NULL,
   DES_SEXO             VARCHAR2(100)        NOT NULL,
   COD_CPF              VARCHAR2(11),
   COD_PERC_RATEIO      NUMBER(15,8),
   IND_PENSAO           VARCHAR2(3)          NOT NULL,
   CONSTRAINT WEB_ADESAO_DEPENDENTE_PK PRIMARY KEY (OID_ADESAO_DEPENDENTE)
);

/*==============================================================*/
/* Table: WEB_ADESAO_DOCUMENTO                                  */
/*==============================================================*/
CREATE TABLE WEB_ADESAO_DOCUMENTO 
(
   OID_ADESAO_DOCUMENTO NUMBER(10)           NOT NULL,
   OID_ADESAO           NUMBER(10)           NOT NULL,
   TXT_TITULO           VARCHAR2(100)        NOT NULL,
   TXT_NOME_FISICO      VARCHAR2(100)        NOT NULL,
   CONSTRAINT WEB_ADESAO_DOCUMENTO_PK PRIMARY KEY (OID_ADESAO_DOCUMENTO)
);

/*==============================================================*/
/* Table: WEB_ADESAO_EMPRESA_PLANO                              */
/*==============================================================*/
CREATE TABLE WEB_ADESAO_EMPRESA_PLANO 
(
   OID_ADESAO_EMPRESA_PLANO NUMBER(10)           NOT NULL,
   CD_FUNDACAO          VARCHAR2(2)          NOT NULL,
   CD_EMPRESA           VARCHAR2(4)          NOT NULL,
   CD_PLANO             VARCHAR2(4)          NOT NULL,
   CONSTRAINT PK_WEB_ADESAO_EMPRESA_PLANO_PK PRIMARY KEY (OID_ADESAO_EMPRESA_PLANO)
);

/*==============================================================*/
/* Index: WEB_ADESAO_EMPRESA_PLANO_UK01                         */
/*==============================================================*/
CREATE UNIQUE INDEX WEB_ADESAO_EMPRESA_PLANO_UK01 ON WEB_ADESAO_EMPRESA_PLANO (
   CD_FUNDACAO ASC,
   CD_EMPRESA ASC,
   CD_PLANO ASC
);

/*==============================================================*/
/* Table: WEB_ADESAO_PLANO                                      */
/*==============================================================*/
CREATE TABLE WEB_ADESAO_PLANO 
(
   OID_ADESAO_PLANO     NUMBER(10)           NOT NULL,
   OID_ADESAO           NUMBER(10)           NOT NULL,
   COD_PLANO            VARCHAR2(20)         NOT NULL,
   DES_PLANO            VARCHAR2(100)        NOT NULL,
   IND_REGIME_TRIBUTACAO VARCHAR2(3)          NOT NULL,
   CONSTRAINT PK_WEB_ADESAO_PLANO PRIMARY KEY (OID_ADESAO_PLANO)
);

/*==============================================================*/
/* Table: WEB_AREA_FUNDACAO                                     */
/*==============================================================*/
CREATE TABLE WEB_AREA_FUNDACAO 
(
   OID_AREA_FUNDACAO    NUMBER(10)           NOT NULL,
   CD_FUNDACAO          VARCHAR2(2)          NOT NULL,
   DES_AREA_FUNDACAO    VARCHAR2(100)        NOT NULL,
   TXT_EMAIL            VARCHAR2(300)        NOT NULL,
   IND_ATIVO            VARCHAR2(3)          NOT NULL
      CONSTRAINT CKC_IND_ATIVO_WEB_AREA CHECK (IND_ATIVO IN ('SIM','NAO') AND IND_ATIVO = UPPER(IND_ATIVO)),
   CONSTRAINT WEB_AREA_FUNDACAO_PK PRIMARY KEY (OID_AREA_FUNDACAO)
);

/*==============================================================*/
/* Index: WEB_AREA_FUNDACAO_UK01                                */
/*==============================================================*/
CREATE INDEX WEB_AREA_FUNDACAO_UK01 ON WEB_AREA_FUNDACAO (
   CD_FUNDACAO ASC,
   DES_AREA_FUNDACAO ASC
);

/*==============================================================*/
/* Table: WEB_ASSUNTO                                           */
/*==============================================================*/
CREATE TABLE WEB_ASSUNTO 
(
   OID_ASSUNTO          NUMBER(10)           NOT NULL,
   OID_AREA_FUNDACAO    NUMBER(10)           NOT NULL,
   CD_FUNDACAO          VARCHAR2(2)          NOT NULL,
   TXT_ASSUNTO          VARCHAR2(200)        NOT NULL,
   IND_ATIVO            VARCHAR2(3)          NOT NULL
      CONSTRAINT CKC_IND_ATIVO_WEB_ASSU CHECK (IND_ATIVO IN ('SIM','NAO') AND IND_ATIVO = UPPER(IND_ATIVO)),
   CONSTRAINT WEB_ASSUNTO_PK PRIMARY KEY (OID_ASSUNTO)
);

/*==============================================================*/
/* Index: WEB_ASSUNTO_UK01                                      */
/*==============================================================*/
CREATE UNIQUE INDEX WEB_ASSUNTO_UK01 ON WEB_ASSUNTO (
   CD_FUNDACAO ASC,
   TXT_ASSUNTO ASC
);

/*==============================================================*/
/* Table: WEB_BLOQUEIO_FUNC                                     */
/*==============================================================*/
CREATE TABLE WEB_BLOQUEIO_FUNC 
(
   OID_BLOQUEIO_FUNC    NUMBER(10)           NOT NULL,
   OID_FUNCIONALIDADE   NUMBER(10)           NOT NULL,
   CD_FUNDACAO          VARCHAR2(2)          NOT NULL,
   CD_EMPRESA           VARCHAR2(4),
   CD_PLANO             VARCHAR2(4),
   NUM_MATRICULA        VARCHAR2(9),
   DTA_INICIO           DATE,
   DTA_FIM              DATE,
   DTA_CRIACAO          DATE                 NOT NULL,
   TXT_MOTIVO_BLOQUEIO  VARCHAR2(4000),
   NOM_USUARIO          VARCHAR2(100)        NOT NULL,
   CONSTRAINT WEB_BLOQUEIO_FUNC_PK PRIMARY KEY (OID_BLOQUEIO_FUNC)
);

/*==============================================================*/
/* Table: WEB_CALENDARIO_PGT                                    */
/*==============================================================*/
CREATE TABLE WEB_CALENDARIO_PGT 
(
   OID_CALENDARIO_PGT   NUMBER(10)           NOT NULL,
   DES_MES              VARCHAR2(50)         NOT NULL,
   NUM_DIA              NUMBER(10)           NOT NULL,
   CD_PLANO             VARCHAR2(4),
   CONSTRAINT WEB_CALENDARIO_PGT_PK PRIMARY KEY (OID_CALENDARIO_PGT)
);

/*==============================================================*/
/* Table: WEB_CONTRIBUICAO                                      */
/*==============================================================*/
CREATE TABLE WEB_CONTRIBUICAO 
(
   OID_CONTRIBUICAO     NUMBER(10)           NOT NULL,
   CD_FUNDACAO          VARCHAR2(2)          NOT NULL,
   CD_PLANO             VARCHAR2(4),
   CD_TIPO_CONTRIBUICAO VARCHAR2(2),
   COD_GRUPO_CONTRIBUICAO VARCHAR2(10),
   CONSTRAINT WEB_CONTRIBUICAO_PK PRIMARY KEY (OID_CONTRIBUICAO)
);

/*==============================================================*/
/* Table: WEB_DISPOSITIVO                                       */
/*==============================================================*/
CREATE TABLE WEB_DISPOSITIVO 
(
   OID_DISPOSITIVO      NUMBER(10)           NOT NULL,
   COD_ENTID            NUMBER(10)           NOT NULL,
   TXT_ID_DISPOSITIVO   VARCHAR2(100)        NOT NULL,
   CONSTRAINT WEB_DISPOSITIVO_PK PRIMARY KEY (OID_DISPOSITIVO)
);

/*==============================================================*/
/* Index: WEB_DISPOSITIVO_UK01                                  */
/*==============================================================*/
CREATE UNIQUE INDEX WEB_DISPOSITIVO_UK01 ON WEB_DISPOSITIVO (
   COD_ENTID ASC,
   TXT_ID_DISPOSITIVO ASC
);

/*==============================================================*/
/* Table: WEB_DOCUMENTO                                         */
/*==============================================================*/
CREATE TABLE WEB_DOCUMENTO 
(
   OID_DOCUMENTO        NUMBER(10)           NOT NULL,
   OID_ARQUIVO_UPLOAD   NUMBER(10)           NOT NULL,
   OID_DOCUMENTO_PASTA  NUMBER(10),
   TXT_TITULO           VARCHAR2(1000)       NOT NULL,
   IND_ATIVO            VARCHAR2(3)          NOT NULL
      CONSTRAINT CKC_IND_ATIVO_WEB_DOCU CHECK (IND_ATIVO IN ('SIM','NAO') AND IND_ATIVO = UPPER(IND_ATIVO)),
   DTA_INCLUSAO         DATE,
   CONSTRAINT WEB_DOCUMENTO_PK PRIMARY KEY (OID_DOCUMENTO)
);

/*==============================================================*/
/* Index: WEB_DOCUMENTO_UK01                                    */
/*==============================================================*/
CREATE UNIQUE INDEX WEB_DOCUMENTO_UK01 ON WEB_DOCUMENTO (
   OID_ARQUIVO_UPLOAD ASC
);

/*==============================================================*/
/* Table: WEB_DOCUMENTO_PASTA                                   */
/*==============================================================*/
CREATE TABLE WEB_DOCUMENTO_PASTA 
(
   OID_DOCUMENTO_PASTA  NUMBER(10)           NOT NULL,
   OID_DOCUMENTO_PASTA_PAI NUMBER(10),
   OID_GRUPO_USUARIO    NUMBER(10),
   NOM_PASTA            VARCHAR2(50)         NOT NULL,
   DTA_INCLUSAO         DATE                 NOT NULL,
   CONSTRAINT WEB_DOCUMENTO_PASTA_PK PRIMARY KEY (OID_DOCUMENTO_PASTA)
);

/*==============================================================*/
/* Table: WEB_DOCUMENTO_PLANO                                   */
/*==============================================================*/
CREATE TABLE WEB_DOCUMENTO_PLANO 
(
   OID_DOCUMENTO_PLANO  NUMBER(10)           NOT NULL,
   OID_DOCUMENTO        NUMBER(10)           NOT NULL,
   CD_FUNDACAO          VARCHAR2(2)          NOT NULL,
   CD_PLANO             VARCHAR2(4)          NOT NULL,
   CONSTRAINT WEB_DOCUMENTO_PLANO_PK PRIMARY KEY (OID_DOCUMENTO_PLANO)
);

/*==============================================================*/
/* Index: WEB_DOCUMENTO_PLANO_UK01                              */
/*==============================================================*/
CREATE UNIQUE INDEX WEB_DOCUMENTO_PLANO_UK01 ON WEB_DOCUMENTO_PLANO (
   OID_DOCUMENTO ASC,
   CD_FUNDACAO ASC,
   CD_PLANO ASC
);

/*==============================================================*/
/* Table: WEB_DOC_ATU_CADASTRAL                                 */
/*==============================================================*/
CREATE TABLE WEB_DOC_ATU_CADASTRAL 
(
   OID_DOC_ATU_CADASTRAL NUMBER(10)           NOT NULL,
   OID_ARQUIVO_UPLOAD   NUMBER(10)           NOT NULL,
   CD_FUNDACAO          VARCHAR2(2)          NOT NULL,
   NUM_INSCRICAO        VARCHAR2(9)          NOT NULL,
   SEQ_RECEBEDOR        NUMBER(10)           NOT NULL,
   CONSTRAINT WEB_DOC_ATU_CADASTRAL_PK PRIMARY KEY (OID_DOC_ATU_CADASTRAL)
);

/*==============================================================*/
/* Table: WEB_FATOR_ATUARIAL                                    */
/*==============================================================*/
CREATE TABLE WEB_FATOR_ATUARIAL 
(
   OID_FATOR_ATUARIAL   NUMBER(10)           NOT NULL,
   COD_TABELA           VARCHAR2(20)         NOT NULL,
   DTA_INICIO_VALIDADE  DATE                 NOT NULL,
   IND_SEXO             VARCHAR2(3)          NOT NULL
      CONSTRAINT CKC_IND_SEXO_WEB_FATO CHECK (IND_SEXO IN ('MAS','FEM','AMB')),
   NUM_IDADE_ANOS       NUMBER(10)           NOT NULL,
   VAL_FATOR            NUMBER(30,8)         NOT NULL,
   CONSTRAINT WEB_FATOR_ATUARIAL_PK PRIMARY KEY (OID_FATOR_ATUARIAL)
);

/*==============================================================*/
/* Index: WEB_FATOR_ATUARIAL_UK01                               */
/*==============================================================*/
CREATE UNIQUE INDEX WEB_FATOR_ATUARIAL_UK01 ON WEB_FATOR_ATUARIAL (
   COD_TABELA ASC,
   DTA_INICIO_VALIDADE ASC,
   IND_SEXO ASC,
   NUM_IDADE_ANOS ASC
);

/*==============================================================*/
/* Table: WEB_FATOR_RISCO                                       */
/*==============================================================*/
CREATE TABLE WEB_FATOR_RISCO 
(
   OID_FATOR_RISCO      NUMBER(10)           NOT NULL,
   CD_FUNDACAO          VARCHAR2(2)          NOT NULL,
   CD_PLANO             VARCHAR2(4)          NOT NULL,
   NUM_FAIXA_INI        NUMBER(10)           NOT NULL,
   NUM_FAIXA_FIM        NUMBER(10)           NOT NULL,
   VAL_FATOR_INVALIDEZ  NUMBER(30,8)         NOT NULL,
   VAL_FATOR_MORTE      NUMBER(30,8)         NOT NULL,
   CONSTRAINT WEB_FATOR_RISCO_PK PRIMARY KEY (OID_FATOR_RISCO)
);

/*==============================================================*/
/* Index: WEB_FATOR_RISCO_UK01                                  */
/*==============================================================*/
CREATE UNIQUE INDEX WEB_FATOR_RISCO_UK01 ON WEB_FATOR_RISCO (
   CD_FUNDACAO ASC,
   CD_PLANO ASC,
   NUM_FAIXA_INI ASC
);

/*==============================================================*/
/* Table: WEB_FUNCIONALIDADE                                    */
/*==============================================================*/
CREATE TABLE WEB_FUNCIONALIDADE 
(
   OID_FUNCIONALIDADE   NUMBER(10)           NOT NULL,
   NUM_FUNCIONALIDADE   NUMBER(10)           NOT NULL,
   DES_FUNCIONALIDADE   VARCHAR2(100)        NOT NULL,
   IND_ATIVO            VARCHAR2(3)          NOT NULL
      CONSTRAINT CKC_IND_ATIVO_WEB_FUNC CHECK (IND_ATIVO IN ('SIM','NAO') AND IND_ATIVO = UPPER(IND_ATIVO)),
   IND_USA_PROTOCOLO    VARCHAR2(3)          NOT NULL,
   CONSTRAINT WEB_FUNCIONALIDADE_PK PRIMARY KEY (OID_FUNCIONALIDADE)
);

/*==============================================================*/
/* Index: WEB_FUNCIONALIDADE__UK01                              */
/*==============================================================*/
CREATE UNIQUE INDEX WEB_FUNCIONALIDADE__UK01 ON WEB_FUNCIONALIDADE (
   NUM_FUNCIONALIDADE ASC
);

/*==============================================================*/
/* Index: WEB_FUNCIONALIDADE_UK02                               */
/*==============================================================*/
CREATE UNIQUE INDEX WEB_FUNCIONALIDADE_UK02 ON WEB_FUNCIONALIDADE (
   DES_FUNCIONALIDADE ASC
);

/*==============================================================*/
/* Table: WEB_GRUPO_USUARIO                                     */
/*==============================================================*/
CREATE TABLE WEB_GRUPO_USUARIO 
(
   OID_GRUPO_USUARIO    NUMBER(10)           NOT NULL,
   NOM_GRUPO_USUARIO    VARCHAR2(50)         NOT NULL,
   IND_ATIVO            VARCHAR2(3)          NOT NULL
      CONSTRAINT CKC_IND_ATIVO_WEB_GRUP CHECK (IND_ATIVO IN ('SIM','NAO') AND IND_ATIVO = UPPER(IND_ATIVO)),
   CONSTRAINT WEB_GRUPO_USUARIO_PK PRIMARY KEY (OID_GRUPO_USUARIO)
);

/*==============================================================*/
/* Index: WEB_GRUPO_USUARIO_UK01                                */
/*==============================================================*/
CREATE UNIQUE INDEX WEB_GRUPO_USUARIO_UK01 ON WEB_GRUPO_USUARIO (
   NOM_GRUPO_USUARIO ASC
);

/*==============================================================*/
/* Table: WEB_LGPD_CONSENTIMENTO                                */
/*==============================================================*/
CREATE TABLE WEB_LGPD_CONSENTIMENTO 
(
   OID_LGPD_CONSENTIMENTO NUMBER(10)           NOT NULL,
   COD_IDENTIFICADOR    VARCHAR2(25)         NOT NULL,
   CD_FUNDACAO          VARCHAR2(2)          NOT NULL,
   COD_CPF              VARCHAR2(11)         NOT NULL,
   DTA_CONSENTIMENTO    DATE                 NOT NULL,
   TXT_IPV4             VARCHAR2(15),
   TXT_IPV6             VARCHAR2(50),
   TXT_DISPOSITIVO      VARCHAR2(100),
   TXT_ORIGEM           VARCHAR2(100)        NOT NULL,
   CONSTRAINT WEB_LGPD_CONSENTIMENTO_PK PRIMARY KEY (OID_LGPD_CONSENTIMENTO)
);

/*==============================================================*/
/* Index: WEB_LGPD_CONSENTIMENTO_UK01                           */
/*==============================================================*/
CREATE UNIQUE INDEX WEB_LGPD_CONSENTIMENTO_UK01 ON WEB_LGPD_CONSENTIMENTO (
   COD_IDENTIFICADOR ASC,
   CD_FUNDACAO ASC
);

/*==============================================================*/
/* Table: WEB_LIMITE_CONTRIBUICAO                               */
/*==============================================================*/
CREATE TABLE WEB_LIMITE_CONTRIBUICAO 
(
   OID_LIMITE_CONTRIBUICAO NUMBER(10)           NOT NULL,
   CD_FUNDACAO          VARCHAR2(2)          NOT NULL,
   CD_PLANO             VARCHAR2(4)          NOT NULL,
   VAL_PERC_MINIMO_PART NUMBER(15,4)         NOT NULL,
   VAL_PERC_MAXIMO_PART NUMBER(15,4)         NOT NULL,
   VAL_PERC_MINIMO_PATROC NUMBER(15,4)         NOT NULL,
   VAL_PERC_MAXIMO_PATROC NUMBER(15,4)         NOT NULL,
   CONSTRAINT WEB_LIMITE_CONTRIBUICAO_PK PRIMARY KEY (OID_LIMITE_CONTRIBUICAO)
);

/*==============================================================*/
/* Table: WEB_MAXIMO_BASICA                                     */
/*==============================================================*/
CREATE TABLE WEB_MAXIMO_BASICA 
(
   OID_MAXIMO_BASICA    NUMBER(10)           NOT NULL,
   CD_FUNDACAO          VARCHAR2(2)          NOT NULL,
   NUM_INSCRICAO        VARCHAR2(9)          NOT NULL,
   NUM_PROTOCOLO        NUMBER(10)           NOT NULL,
   DTA_OPCAO            DATE                 NOT NULL,
   IND_MAXIMO_BASICA    VARCHAR2(3)          NOT NULL,
   CD_TIPO_CONTRIB_BASICA VARCHAR2(2)          NOT NULL,
   VAL_PERC_BASICA_NOVO NUMBER(15,8)         NOT NULL,
   VAL_PERC_BASICA_ANT  NUMBER(15,8)         NOT NULL,
   IND_SUPLEMENTAR      VARCHAR2(3)          NOT NULL
      CONSTRAINT CKC_IND_SUPLEMENTAR_WEB_MAXI CHECK (IND_SUPLEMENTAR IN ('SIM','NAO') AND IND_SUPLEMENTAR = UPPER(IND_SUPLEMENTAR)),
   CD_TIPO_CONTRIB_SUPL VARCHAR2(2),
   VAL_PERC_SUPLEMENTAR_NOVO NUMBER(15,8),
   VAL_PERC_SUPLEMENTAR_ANT NUMBER(15,8),
   CD_TIPO_CONTRIB_ESPECIAL VARCHAR2(2),
   VAL_PERC_ESPECIAL    NUMBER(15,8),
   IND_SITUACAO         VARCHAR2(3)          NOT NULL
      CONSTRAINT CKC_IND_SITUACAO_WEB_MAXI CHECK (IND_SITUACAO IN ('NOV','EFE','REJ','CAN')),
   TXT_SOLICITANTE      VARCHAR2(100)        NOT NULL,
   NOM_USU_ATUALIZACAO  VARCHAR2(100),
   CONSTRAINT PK_WEB_MAXIMO_BASICA PRIMARY KEY (OID_MAXIMO_BASICA)
);

/*==============================================================*/
/* Table: WEB_MENSAGEM                                          */
/*==============================================================*/
CREATE TABLE WEB_MENSAGEM 
(
   OID_MENSAGEM         NUMBER(10)           NOT NULL,
   TXT_TITULO           VARCHAR2(100)        NOT NULL,
   TXT_CORPO            VARCHAR2(4000)       NOT NULL,
   DTA_MENSAGEM         DATE                 NOT NULL,
   DTA_EXPIRACAO        DATE,
   CD_FUNDACAO          VARCHAR2(2)          NOT NULL,
   CD_EMPRESA           VARCHAR2(4),
   CD_PLANO             VARCHAR2(4),
   CD_SIT_PLANO         VARCHAR2(2),
   COD_ENTID            NUMBER(10),
   IND_MOBILE           VARCHAR2(3)          NOT NULL
      CONSTRAINT CKC_IND_MOBILE_WEB_MENS CHECK (IND_MOBILE IN ('SIM','NAO') AND IND_MOBILE = UPPER(IND_MOBILE)),
   IND_PORTAL           VARCHAR2(3)          NOT NULL
      CONSTRAINT CKC_IND_PORTAL_WEB_MENS CHECK (IND_PORTAL IN ('SIM','NAO') AND IND_PORTAL = UPPER(IND_PORTAL)),
   IND_EMAIL            VARCHAR2(3)          NOT NULL
      CONSTRAINT CKC_IND_EMAIL_WEB_MENS CHECK (IND_EMAIL IN ('SIM','NAO') AND IND_EMAIL = UPPER(IND_EMAIL)),
   IND_SMS              VARCHAR2(3)          NOT NULL
      CONSTRAINT CKC_IND_SMS_WEB_MENS CHECK (IND_SMS IN ('SIM','NAO') AND IND_SMS = UPPER(IND_SMS)),
   CONSTRAINT WEB_MENSAGEM_PK PRIMARY KEY (OID_MENSAGEM)
);

/*==============================================================*/
/* Table: WEB_PERC_CONTRIBUICAO                                 */
/*==============================================================*/
CREATE TABLE WEB_PERC_CONTRIBUICAO 
(
   OID_PERC_CONTRIBUICAO NUMBER(10)           NOT NULL,
   CD_FUNDACAO          VARCHAR2(2)          NOT NULL,
   CD_PLANO             VARCHAR2(4)          NOT NULL,
   CD_TIPO_CONTRIBUICAO VARCHAR2(2)          NOT NULL,
   VAL_PERC_CONTRIBUICAO NUMBER(15,8)         NOT NULL,
   CONSTRAINT WEB_PERC_CONTRIBUICAO_PK PRIMARY KEY (OID_PERC_CONTRIBUICAO)
);

/*==============================================================*/
/* Index: WEB_PERC_CONTRIBUICAO_UK01                            */
/*==============================================================*/
CREATE UNIQUE INDEX WEB_PERC_CONTRIBUICAO_UK01 ON WEB_PERC_CONTRIBUICAO (
   CD_FUNDACAO ASC,
   CD_PLANO ASC,
   CD_TIPO_CONTRIBUICAO ASC
);

/*==============================================================*/
/* Table: WEB_PROTOCOLO                                         */
/*==============================================================*/
CREATE TABLE WEB_PROTOCOLO 
(
   OID_PROTOCOLO        NUMBER(10)           NOT NULL,
   OID_FUNCIONALIDADE   NUMBER(10)           NOT NULL,
   COD_IDENTIFICADOR    VARCHAR2(25)         NOT NULL,
   CD_FUNDACAO          VARCHAR2(2)          NOT NULL,
   CD_EMPRESA           VARCHAR2(4)          NOT NULL,
   CD_PLANO             VARCHAR2(4)          NOT NULL,
   NUM_MATRICULA        VARCHAR2(9)          NOT NULL,
   SEQ_RECEBEDOR        NUMBER(10),
   DTA_SOLICITACAO      DATE                 NOT NULL,
   DTA_EFETIVACAO       DATE,
   TXT_MOTIVO_RECUSA    VARCHAR2(4000),
   TXT_TRANSACAO        VARCHAR2(4000)       NOT NULL,
   TXT_TRANSACAO2       VARCHAR2(4000),
   TXT_USUARIO_SOLICITACAO VARCHAR2(100)        NOT NULL,
   TXT_USUARIO_EFETIVACAO VARCHAR2(100),
   TXT_IPV4             VARCHAR2(15),
   TXT_IPV6             VARCHAR2(50),
   TXT_DISPOSITIVO      VARCHAR2(100),
   TXT_ORIGEM           VARCHAR2(100)        NOT NULL,
   CONSTRAINT WEB_PROTOCOLO_PK PRIMARY KEY (OID_PROTOCOLO)
);

/*==============================================================*/
/* Index: WEB_PROTOCOLO_UK01                                    */
/*==============================================================*/
CREATE UNIQUE INDEX WEB_PROTOCOLO_UK01 ON WEB_PROTOCOLO (
   CD_FUNDACAO ASC,
   COD_IDENTIFICADOR ASC
);

/*==============================================================*/
/* Table: WEB_PROTOCOLO_PW                                      */
/*==============================================================*/
CREATE TABLE WEB_PROTOCOLO_PW 
(
   OID_PROTOCOLO_PW     NUMBER(10)           NOT NULL,
   OID_FUNCIONALIDADE   NUMBER(10)           NOT NULL,
   COD_IDENTIFICADOR    VARCHAR2(25)         NOT NULL,
   CD_PESSOA            NUMBER(10)           NOT NULL,
   SQ_CONTRATO_TRABALHO NUMBER(10)           NOT NULL,
   SQ_PLANO_PREVIDENCIAL NUMBER(10)           NOT NULL,
   DTA_SOLICITACAO      DATE                 NOT NULL,
   DTA_EFETIVACAO       DATE,
   TXT_MOTIVO_RECUSA    VARCHAR2(4000),
   TXT_TRANSACAO        VARCHAR2(4000)       NOT NULL,
   TXT_TRANSACAO2       VARCHAR2(4000),
   TXT_USUARIO_SOLICITACAO VARCHAR2(100)        NOT NULL,
   TXT_USUARIO_EFETIVACAO VARCHAR2(100),
   TXT_IPV4             VARCHAR2(15),
   TXT_IPV6             VARCHAR2(50),
   TXT_DISPOSITIVO      VARCHAR2(100),
   TXT_ORIGEM           VARCHAR2(100)        NOT NULL,
   CONSTRAINT WEB_PROTOCOLO_PW_PK PRIMARY KEY (OID_PROTOCOLO_PW)
);

/*==============================================================*/
/* Index: WEB_PROTOCOLO_PW_UK01                                 */
/*==============================================================*/
CREATE UNIQUE INDEX WEB_PROTOCOLO_PW_UK01 ON WEB_PROTOCOLO_PW (
   COD_IDENTIFICADOR ASC
);

/*==============================================================*/
/* Table: WEB_RELACIONAMENTO                                    */
/*==============================================================*/
CREATE TABLE WEB_RELACIONAMENTO 
(
   OID_RELACIONAMENTO   NUMBER(10)           NOT NULL,
   CD_FUNDACAO          VARCHAR2(2)          NOT NULL,
   COD_CPF              VARCHAR2(11)         NOT NULL,
   DTA_ENVIO            DATE                 NOT NULL,
   TXT_EMAIL_DESTINATARIO VARCHAR2(300)        NOT NULL,
   TXT_EMAIL_REMETENTE  VARCHAR2(100)        NOT NULL,
   OID_ASSUNTO          NUMBER(10)           NOT NULL,
   TXT_MENSAGEM         VARCHAR2(4000)       NOT NULL,
   TXT_IPV4             VARCHAR2(15),
   TXT_IPV6             VARCHAR2(50),
   TXT_DISPOSITIVO      VARCHAR2(100),
   CONSTRAINT WEB_RELACIONAMENTO_PK PRIMARY KEY (OID_RELACIONAMENTO)
);

/*==============================================================*/
/* Table: WEB_USUARIO                                           */
/*==============================================================*/
CREATE TABLE WEB_USUARIO 
(
   OID_USUARIO          NUMBER(10)           NOT NULL,
   NOM_LOGIN            VARCHAR2(60)         NOT NULL,
   PWD_USUARIO          VARCHAR2(200)        NOT NULL,
   IND_BLOQUEADO        VARCHAR2(1)          NOT NULL,
   NUM_TENTATIVA        NUMBER(5)            NOT NULL,
   DES_LOTACAO          VARCHAR2(20),
   IND_ADMINISTRADOR    VARCHAR2(1)          NOT NULL,
   IND_ATIVO            VARCHAR2(1)          NOT NULL,
   NOM_USUARIO_CRIACAO  VARCHAR2(60),
   DTA_CRIACAO          DATE,
   NOM_USUARIO_ATUALIZACAO VARCHAR2(60),
   DTA_ATUALIZACAO      DATE,
   CD_EMPRESA           VARCHAR2(4)          NOT NULL,
   SEQ_RECEBEDOR        NUMBER(10),
   IND_PRIMEIRO_ACESSO  VARCHAR2(1),
   CONSTRAINT PK_WEB_USUARIO PRIMARY KEY (OID_USUARIO)
);

/*==============================================================*/
/* Table: WEB_USUARIO_GRUPO                                     */
/*==============================================================*/
CREATE TABLE WEB_USUARIO_GRUPO 
(
   OID_USUARIO_GRUPO    NUMBER(10)           NOT NULL,
   OID_GRUPO_USUARIO    NUMBER(10)           NOT NULL,
   OID_USUARIO          NUMBER(10)           NOT NULL,
   CONSTRAINT WEB_USUARIO_GRUPO_PK PRIMARY KEY (OID_USUARIO_GRUPO)
);

/*==============================================================*/
/* Index: WEB_USUARIO_GRUPO_UK01                                */
/*==============================================================*/
CREATE UNIQUE INDEX WEB_USUARIO_GRUPO_UK01 ON WEB_USUARIO_GRUPO (
   OID_USUARIO ASC
);

ALTER TABLE WEB_ACESSO_GRUPO_USUARIO
   ADD CONSTRAINT WEB_ACESSO_GRUPO_USUARIO_FK01 FOREIGN KEY (OID_GRUPO_USUARIO)
      REFERENCES WEB_GRUPO_USUARIO (OID_GRUPO_USUARIO);

ALTER TABLE WEB_ACESSO_GRUPO_USUARIO
   ADD CONSTRAINT WEB_ACESSO_GRUPO_USUARIO_FK02 FOREIGN KEY (OID_FUNCIONALIDADE)
      REFERENCES WEB_FUNCIONALIDADE (OID_FUNCIONALIDADE);

ALTER TABLE WEB_ADESAO_CONTRIB
   ADD CONSTRAINT WEB_ADESAO_CONTRIB_FK01 FOREIGN KEY (OID_ADESAO_PLANO)
      REFERENCES WEB_ADESAO_PLANO (OID_ADESAO_PLANO);

ALTER TABLE WEB_ADESAO_DEPENDENTE
   ADD CONSTRAINT WEB_ADESAO_DEPENDENTE_FK01 FOREIGN KEY (OID_ADESAO)
      REFERENCES WEB_ADESAO (OID_ADESAO);

ALTER TABLE WEB_ADESAO_DOCUMENTO
   ADD CONSTRAINT WEB_ADESAO_DOCUMENTO_FK01 FOREIGN KEY (OID_ADESAO)
      REFERENCES WEB_ADESAO (OID_ADESAO);

ALTER TABLE WEB_ADESAO_PLANO
   ADD CONSTRAINT WEB_ADESAO_PLANO_FK01 FOREIGN KEY (OID_ADESAO)
      REFERENCES WEB_ADESAO (OID_ADESAO);

ALTER TABLE WEB_ASSUNTO
   ADD CONSTRAINT WEB_ASSUNTO_FK01 FOREIGN KEY (OID_AREA_FUNDACAO)
      REFERENCES WEB_AREA_FUNDACAO (OID_AREA_FUNDACAO);

ALTER TABLE WEB_BLOQUEIO_FUNC
   ADD CONSTRAINT WEB_BLOQUEIO_FUNC_FK01 FOREIGN KEY (OID_FUNCIONALIDADE)
      REFERENCES WEB_FUNCIONALIDADE (OID_FUNCIONALIDADE);

ALTER TABLE WEB_DOCUMENTO
   ADD CONSTRAINT WEB_DOCUMENTO_FK01 FOREIGN KEY (OID_ARQUIVO_UPLOAD)
      REFERENCES TBG_ARQUIVO_UPLOAD;

ALTER TABLE WEB_DOCUMENTO
   ADD CONSTRAINT WEB_DOCUMENTO_FK02 FOREIGN KEY (OID_DOCUMENTO_PASTA)
      REFERENCES WEB_DOCUMENTO_PASTA (OID_DOCUMENTO_PASTA);

ALTER TABLE WEB_DOCUMENTO_PASTA
   ADD CONSTRAINT WEB_DOCUMENTO_PASTA_FK01 FOREIGN KEY (OID_DOCUMENTO_PASTA_PAI)
      REFERENCES WEB_DOCUMENTO_PASTA (OID_DOCUMENTO_PASTA);

ALTER TABLE WEB_DOCUMENTO_PASTA
   ADD CONSTRAINT WEB_DOCUMENTO_PASTA_FK02 FOREIGN KEY (OID_GRUPO_USUARIO)
      REFERENCES WEB_GRUPO_USUARIO (OID_GRUPO_USUARIO);

ALTER TABLE WEB_DOCUMENTO_PLANO
   ADD CONSTRAINT WEB_DOCUMENTO_PLANO_FK01 FOREIGN KEY (OID_DOCUMENTO)
      REFERENCES WEB_DOCUMENTO (OID_DOCUMENTO);

ALTER TABLE WEB_DOC_ATU_CADASTRAL
   ADD CONSTRAINT WEB_DOC_ATU_CADASTRAL_FK01 FOREIGN KEY (OID_ARQUIVO_UPLOAD)
      REFERENCES TBG_ARQUIVO_UPLOAD;

ALTER TABLE WEB_PROTOCOLO
   ADD CONSTRAINT FK_WEB_PROT_REFERENCE_WEB_FUNC FOREIGN KEY (OID_FUNCIONALIDADE)
      REFERENCES WEB_FUNCIONALIDADE (OID_FUNCIONALIDADE);

ALTER TABLE WEB_PROTOCOLO_PW
   ADD CONSTRAINT WEB_PROTOCOLO_PW_FK01 FOREIGN KEY (OID_FUNCIONALIDADE)
      REFERENCES WEB_FUNCIONALIDADE (OID_FUNCIONALIDADE);

ALTER TABLE WEB_RELACIONAMENTO
   ADD CONSTRAINT WEB_RELACIONAMENTO_FK01 FOREIGN KEY (OID_ASSUNTO)
      REFERENCES WEB_ASSUNTO (OID_ASSUNTO);

ALTER TABLE WEB_USUARIO_GRUPO
   ADD CONSTRAINT WEB_USUARIO_GRUPO_FK01 FOREIGN KEY (OID_GRUPO_USUARIO)
      REFERENCES WEB_GRUPO_USUARIO (OID_GRUPO_USUARIO);

ALTER TABLE WEB_USUARIO_GRUPO
   ADD CONSTRAINT WEB_USUARIO_GRUPO_FK02 FOREIGN KEY (OID_USUARIO)
      REFERENCES WEB_USUARIO (OID_USUARIO);

