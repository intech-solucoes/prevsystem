/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2008                    */
/* Created on:     09/07/2020 16:06:20                          */
/*==============================================================*/


IF EXISTS (SELECT 1
            FROM  SYSOBJECTS
           WHERE  ID = OBJECT_ID('GB_ESPECIE_INSS')
            AND   TYPE = 'U')
   DROP TABLE GB_ESPECIE_INSS
go

IF EXISTS (SELECT 1
            FROM  SYSOBJECTS
           WHERE  ID = OBJECT_ID('WEB_RECAD_CAMPANHA')
            AND   TYPE = 'U')
   DROP TABLE WEB_RECAD_CAMPANHA
go

IF EXISTS (SELECT 1
            FROM  SYSOBJECTS
           WHERE  ID = OBJECT_ID('WEB_RECAD_DADOS')
            AND   TYPE = 'U')
   DROP TABLE WEB_RECAD_DADOS
go

IF EXISTS (SELECT 1
            FROM  SYSOBJECTS
           WHERE  ID = OBJECT_ID('WEB_RECAD_BENEFICIARIO')
            AND   TYPE = 'U')
   DROP TABLE WEB_RECAD_BENEFICIARIO
go

IF EXISTS (SELECT 1
            FROM  SYSOBJECTS
           WHERE  ID = OBJECT_ID('WEB_RECAD_DEPENDENTE_IR')
            AND   TYPE = 'U')
   DROP TABLE WEB_RECAD_DEPENDENTE_IR
go

IF EXISTS (SELECT 1
            FROM  SYSOBJECTS
           WHERE  ID = OBJECT_ID('WEB_RECAD_DOCUMENTO')
            AND   TYPE = 'U')
   DROP TABLE WEB_RECAD_DOCUMENTO
go

IF EXISTS (SELECT 1
            FROM  SYSOBJECTS
           WHERE  ID = OBJECT_ID('WEB_RECAD_PUBLICO_ALVO')
            AND   TYPE = 'U')
   DROP TABLE WEB_RECAD_PUBLICO_ALVO
go


/*==============================================================*/
/* Table: GB_ESPECIE_INSS                                       */
/*==============================================================*/
CREATE TABLE GB_ESPECIE_INSS (
   CD_ESPECIE_INSS      VARCHAR(2)           NOT NULL,
   DS_ESPECIE_INSS      VARCHAR(100)         NOT NULL,
   CONSTRAINT GB_ESPECIE_INSS_PK PRIMARY KEY NONCLUSTERED (CD_ESPECIE_INSS)
)
go

/*==============================================================*/
/* Table: WEB_RECAD_CAMPANHA                                    */
/*==============================================================*/
CREATE TABLE WEB_RECAD_CAMPANHA (
   OID_RECAD_CAMPANHA   NUMERIC(10)          IDENTITY,
   CD_FUNDACAO          VARCHAR(2)           NOT NULL,
   NOM_CAMPANHA         VARCHAR(100)         NOT NULL,
   DTA_INICIO           DATETIME             NOT NULL,
   DTA_TERMINO          DATETIME             NOT NULL,
   IND_ATIVO            VARCHAR(3)           NOT NULL
      CONSTRAINT CKC_IND_ATIVO_WEB_RECA CHECK (IND_ATIVO IN ('SIM','NAO') AND IND_ATIVO = UPPER(IND_ATIVO)),
   CONSTRAINT WEB_RECAD_CAMPANHA_PK PRIMARY KEY NONCLUSTERED (OID_RECAD_CAMPANHA)
)
go

/*==============================================================*/
/* Index: WEB_RECAD_CAMPANHA_UK01                               */
/*==============================================================*/
CREATE UNIQUE INDEX WEB_RECAD_CAMPANHA_UK01 ON WEB_RECAD_CAMPANHA (
CD_FUNDACAO ASC,
NOM_CAMPANHA ASC
)
go

/*==============================================================*/
/* Table: WEB_RECAD_DADOS                                       */
/*==============================================================*/
CREATE TABLE WEB_RECAD_DADOS (
   OID_RECAD_DADOS      NUMERIC(10)          IDENTITY,
   OID_RECAD_PUBLICO_ALVO NUMERIC(10)          NOT NULL,
   DTA_SOLICITACAO      DATETIME             NOT NULL,
   COD_PROTOCOLO        VARCHAR(100)         NOT NULL,
   DES_ORIGEM           VARCHAR(100)         NOT NULL,
   DTA_RECUSA           DATETIME             NULL,
   TXT_MOTIVO_RECUSA    VARCHAR(4000)        NULL,
   NOM_PESSOA           VARCHAR(100)         NULL,
   DTA_NASCIMENTO       DATETIME             NULL,
   COD_CPF              VARCHAR(11)          NULL,
   COD_RG               VARCHAR(20)          NULL,
   DES_ORGAO_EXPEDIDOR  VARCHAR(100)         NULL,
   DTA_EXPEDICAO_RG     DATETIME             NULL,
   DTA_ADMISSAO         DATETIME             NULL,
   DES_NATURALIDADE     VARCHAR(100)         NULL,
   COD_UF_NATURALIDADE  VARCHAR(2)           NULL,
   DES_UF_NATURALIDADE  VARCHAR(100)         NULL,
   COD_NACIONALIDADE    VARCHAR(20)          NULL,
   DES_NACIONALIDADE    VARCHAR(100)         NULL,
   NOM_MAE              VARCHAR(100)         NULL,
   NOM_PAI              VARCHAR(100)         NULL,
   COD_ESTADO_CIVIL     VARCHAR(20)          NULL,
   DES_ESTADO_CIVIL     VARCHAR(100)         NULL,
   NOM_CONJUGE          VARCHAR(100)         NULL,
   COD_CPF_CONJUGE      VARCHAR(11)          NULL,
   DTA_NASC_CONJUGE     DATETIME             NULL,
   COD_CEP              VARCHAR(8)           NULL,
   DES_END_LOGRADOURO   VARCHAR(100)         NULL,
   DES_END_NUMERO       VARCHAR(50)          NULL,
   DES_END_COMPLEMENTO  VARCHAR(100)         NULL,
   DES_END_BAIRRO       VARCHAR(100)         NULL,
   DES_END_CIDADE       VARCHAR(100)         NULL,
   COD_END_UF           VARCHAR(2)           NULL,
   DES_END_UF           VARCHAR(100)         NULL,
   COD_PAIS             VARCHAR(20)          NULL,
   DES_PAIS             VARCHAR(100)         NULL,
   COD_EMAIL            VARCHAR(100)         NULL,
   COD_TELEFONE_FIXO    VARCHAR(20)          NULL,
   COD_TELEFONE_CELULAR VARCHAR(20)          NULL,
   COD_CARGO            VARCHAR(20)          NULL,
   DES_CARGO            VARCHAR(100)         NULL,
   COD_SEXO             VARCHAR(3)           NULL,
   DES_SEXO             VARCHAR(20)          NULL,
   COD_BANCO            VARCHAR(3)           NULL,
   DES_BANCO            VARCHAR(100)         NULL,
   COD_AGENCIA          VARCHAR(20)          NULL,
   COD_DV_AGENCIA       VARCHAR(2)           NULL,
   COD_CONTA_CORRENTE   VARCHAR(20)          NULL,
   COD_DV_CONTA_CORRENTE VARCHAR(2)           NULL,
   COD_ESPECIE_INSS     VARCHAR(2)           NULL,
   DES_ESPECIE_INSS     VARCHAR(100)         NULL,
   COD_BENEF_INSS       VARCHAR(50)          NULL,
   IND_PPE              VARCHAR(3)           NULL,
   IND_PPE_FAMILIAR     VARCHAR(3)           NULL,
   IND_FATCA            VARCHAR(3)           NULL,
   CONSTRAINT WEB_RECAD_DADOS_PK PRIMARY KEY NONCLUSTERED (OID_RECAD_DADOS)
)
go

/*==============================================================*/
/* Index: WEB_RECAD_DADOS_UK01                                  */
/*==============================================================*/
CREATE UNIQUE INDEX WEB_RECAD_DADOS_UK01 ON WEB_RECAD_DADOS (
OID_RECAD_PUBLICO_ALVO ASC,
DTA_SOLICITACAO ASC
)
go

/*==============================================================*/
/* Table: WEB_RECAD_BENEFICIARIO                               */
/*==============================================================*/
CREATE TABLE WEB_RECAD_BENEFICIARIO (
   OID_RECAD_BENEFICIARIO NUMERIC(10)          ,
   OID_RECAD_DADOS      NUMERIC(10)          NOT NULL,
   COD_PLANO            VARCHAR(4)           NOT NULL,
   NUM_SEQ_DEP          NUMERIC(10)          NOT NULL,
   NOM_DEPENDENTE       VARCHAR(100)         NULL,
   COD_GRAU_PARENTESCO  VARCHAR(20)          NULL,
   DES_GRAU_PARENTESCO  VARCHAR(100)         NULL,
   DTA_NASCIMENTO       DATE             NULL,
   COD_SEXO             VARCHAR(3)           NULL,
   DES_SEXO             VARCHAR(100)         NULL,
   COD_CPF              VARCHAR(11)          NULL,
   COD_PERC_RATEIO      NUMERIC(15,8)        NULL,
   IND_OPERACAO         VARCHAR(3)           NOT NULL,
   IND_VALIDO           VARCHAR(3)           NOT NULL
      CONSTRAINT CKC_IND_OPERACAO_WEB_RECA CHECK (IND_OPERACAO IN ('INC','ALT','EXC')),
   CONSTRAINT WEB_RECAD_BENEFICIARIO_PK PRIMARY KEY NONCLUSTERED (OID_RECAD_BENEFICIARIO)
);

ALTER TABLE WEB_RECAD_BENEFICIARIO
   ADD CONSTRAINT WEB_RECAD_BENEFICIARIO_FK01 FOREIGN KEY (OID_RECAD_DADOS)
      REFERENCES WEB_RECAD_DADOS (OID_RECAD_DADOS);

/*==============================================================*/
/* Table: WEB_RECAD_DEPENDENTE_IR                               */
/*==============================================================*/
CREATE TABLE WEB_RECAD_DEPENDENTE_IR (
   OID_RECAD_DEPENDENTE_IR NUMERIC(10)          IDENTITY,
   OID_RECAD_DADOS      NUMERIC(10)          NOT NULL,
   NUM_SEQ_DEP          NUMERIC(10)          NOT NULL,
   NOM_DEPENDENTE       VARCHAR(100)         NULL,
   COD_GRAU_PARENTESCO  VARCHAR(20)          NULL,
   DES_GRAU_PARENTESCO  VARCHAR(100)         NULL,
   DTA_NASCIMENTO       DATETIME             NULL,
   DTA_INICIO_IRRF      DATETIME             NULL,
   DTA_TERMINO_IRRF     DATETIME             NULL,
   COD_SEXO             VARCHAR(3)           NULL,
   DES_SEXO             VARCHAR(100)         NULL,
   COD_CPF              VARCHAR(11)          NULL,
   IND_OPERACAO         VARCHAR(3)           NOT NULL
      CONSTRAINT CKC_IND_OPERACAO_WEB_RECA CHECK (IND_OPERACAO IN ('INC','ALT','EXC')),
   CONSTRAINT WEB_RECAD_DEPENDENTE_IR_PK PRIMARY KEY NONCLUSTERED (OID_RECAD_DEPENDENTE_IR)
)
go

/*==============================================================*/
/* Table: WEB_RECAD_DOCUMENTO                                   */
/*==============================================================*/
CREATE TABLE WEB_RECAD_DOCUMENTO (
   OID_RECAD_DOCUMENTO  NUMERIC(10)          IDENTITY,
   OID_RECAD_DADOS      NUMERIC(10)          NOT NULL,
   TXT_TITULO           VARCHAR(100)         NOT NULL,
   TXT_NOME_FISICO      VARCHAR(100)         NOT NULL,
   CONSTRAINT WEB_RECAD_DOCUMENTO_PK PRIMARY KEY NONCLUSTERED (OID_RECAD_DOCUMENTO)
)
go

/*==============================================================*/
/* Table: WEB_RECAD_PUBLICO_ALVO                                */
/*==============================================================*/
CREATE TABLE WEB_RECAD_PUBLICO_ALVO (
   OID_RECAD_PUBLICO_ALVO NUMERIC(10)          IDENTITY,
   OID_RECAD_CAMPANHA   NUMERIC(10)          NOT NULL,
   CD_FUNDACAO          VARCHAR(2)           NOT NULL,
   NUM_INSCRICAO        VARCHAR(9)           NOT NULL,
   SEQ_RECEBEDOR        NUMERIC(10)          NOT NULL,
   IND_SITUACAO_RECAD   VARCHAR(3)           NOT NULL
      CONSTRAINT CKC_IND_SITUACAO_RECA_WEB_RECA CHECK (IND_SITUACAO_RECAD IN ('AGU','SOL','EFE','REC','SUS')),
   DTA_EFETIVACAO       DATETIME             NULL,
   NOM_USUARIO_ACAO     VARCHAR(100)         NOT NULL,
   CONSTRAINT WEB_RECAD_PUBLICO_ALVO_PK PRIMARY KEY NONCLUSTERED (OID_RECAD_PUBLICO_ALVO)
)
go

/*==============================================================*/
/* Index: WEB_RECAD_PUBLICO_ALVO_UK01                           */
/*==============================================================*/
CREATE UNIQUE INDEX WEB_RECAD_PUBLICO_ALVO_UK01 ON WEB_RECAD_PUBLICO_ALVO (
OID_RECAD_CAMPANHA ASC,
CD_FUNDACAO ASC,
NUM_INSCRICAO ASC,
SEQ_RECEBEDOR ASC
)
go

ALTER TABLE WEB_RECAD_DADOS
   ADD CONSTRAINT WEB_RECAD_DADOS_FK01 FOREIGN KEY (OID_RECAD_PUBLICO_ALVO)
      REFERENCES WEB_RECAD_PUBLICO_ALVO (OID_RECAD_PUBLICO_ALVO)
go

ALTER TABLE WEB_RECAD_DEPENDENTE_IR
   ADD CONSTRAINT WEB_RECAD_DEPENDENTE_IR_FK01 FOREIGN KEY (OID_RECAD_DADOS)
      REFERENCES WEB_RECAD_DADOS (OID_RECAD_DADOS)
go

ALTER TABLE WEB_RECAD_DOCUMENTO
   ADD CONSTRAINT WEB_RECAD_DOCUMENTO_FK01 FOREIGN KEY (OID_RECAD_DADOS)
      REFERENCES WEB_RECAD_DADOS (OID_RECAD_DADOS)
go

ALTER TABLE WEB_RECAD_PUBLICO_ALVO
   ADD CONSTRAINT WEB_RECAD_PUBLICO_ALVO_FK01 FOREIGN KEY (OID_RECAD_CAMPANHA)
      REFERENCES WEB_RECAD_CAMPANHA (OID_RECAD_CAMPANHA)
go

