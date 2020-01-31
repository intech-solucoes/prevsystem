/*==============================================================*/
/* Table: WEB_ADESAO                                            */
/*==============================================================*/
CREATE TABLE WEB_ADESAO (
   OID_ADESAO           NUMERIC(10)          IDENTITY,
   COD_FUNDACAO         VARCHAR(20)          NOT NULL,
   COD_CPF              VARCHAR(11)          NOT NULL,
   NOM_PESSOA           VARCHAR(100)         NOT NULL,
   DTA_NASCIMENTO       DATETIME             NOT NULL,
   COD_EMPRESA          VARCHAR(20)          NOT NULL,
   DES_EMPRESA          VARCHAR(100)         NOT NULL,
   COD_MATRICULA        VARCHAR(20)          NOT NULL,
   DTA_ADMISSAO         DATETIME             NOT NULL,
   COD_EMAIL            VARCHAR(100)         NOT NULL,
   COD_CARGO            VARCHAR(20)          NULL,
   DES_CARGO            VARCHAR(100)         NULL,
   COD_SEXO             VARCHAR(3)           NOT NULL,
   DES_SEXO             VARCHAR(20)          NULL,
   COD_NACIONALIDADE    VARCHAR(20)          NULL,
   DES_NACIONALIDADE    VARCHAR(100)         NULL,
   COD_NATURALIDADE     VARCHAR(20)          NULL,
   DES_NATURALIDADE     VARCHAR(100)         NULL,
   COD_UF_NATURALIDADE  VARCHAR(2)           NULL,
   DES_UF_NATURALIDADE  VARCHAR(100)         NULL,
   COD_RG               VARCHAR(20)          NULL,
   DES_ORGAO_EXPEDIDOR  VARCHAR(100)         NULL,
   DTA_EXPEDICAO_RG     DATETIME             NULL,
   COD_ESTADO_CIVIL     VARCHAR(20)          NULL,
   DES_ESTADO_CIVIL     VARCHAR(100)         NULL,
   NOM_MAE              VARCHAR(100)         NOT NULL,
   NOM_PAI              VARCHAR(100)         NULL,
   COD_CEP              VARCHAR(8)           NOT NULL,
   DES_END_LOGRADOURO   VARCHAR(100)         NOT NULL,
   DES_END_NUMERO       VARCHAR(50)          NULL,
   DES_END_COMPLEMENTO  VARCHAR(100)         NULL,
   DES_END_BAIRRO       VARCHAR(100)         NOT NULL,
   DES_END_CIDADE       VARCHAR(100)         NOT NULL,
   COD_END_UF           VARCHAR(2)           NOT NULL,
   DES_END_UF           VARCHAR(100)         NOT NULL,
   COD_TELEFONE_FIXO    VARCHAR(20)          NULL,
   COD_TELEFONE_CELULAR VARCHAR(20)          NULL,
   COD_BANCO            VARCHAR(3)           NULL,
   DES_BANCO            VARCHAR(100)         NULL,
   COD_AGENCIA          VARCHAR(20)          NULL,
   COD_DV_AGENCIA       VARCHAR(2)           NULL,
   COD_CONTA_CORRENTE   VARCHAR(20)          NULL,
   COD_DV_CONTA_CORRENTE VARCHAR(2)           NULL,
   IND_PPE              VARCHAR(3)           NOT NULL,
   IND_PPE_FAMILIAR     VARCHAR(3)           NOT NULL,
   IND_FATCA            VARCHAR(3)           NOT NULL,
   IND_SIT_ADESAO       VARCHAR(3)           NOT NULL,
   DTA_CRIACAO          DATETIME             NOT NULL,
   IPV4					VARCHAR(50)			NULL,
   IPV6					VARCHAR(100)		NULL,
   CONSTRAINT WEB_ADESAO_PK PRIMARY KEY (OID_ADESAO)
)
go

/*==============================================================*/
/* Table: WEB_ADESAO_DEPENDENTE                                 */
/*==============================================================*/
CREATE TABLE WEB_ADESAO_DEPENDENTE (
   OID_ADESAO_DEPENDENTE NUMERIC(10)          IDENTITY,
   OID_ADESAO           NUMERIC(10)          NOT NULL,
   NOM_DEPENDENTE       VARCHAR(100)         NOT NULL,
   COD_GRAU_PARENTESCO  VARCHAR(20)          NOT NULL,
   DES_GRAU_PARENTESCO  VARCHAR(100)         NOT NULL,
   DTA_NASCIMENTO       DATETIME             NOT NULL,
   COD_SEXO             VARCHAR(3)           NOT NULL,
   DES_SEXO             VARCHAR(100)         NOT NULL,
   COD_CPF              VARCHAR(11)          NULL,
   COD_PERC_RATEIO      NUMERIC(15,8)        NULL,
   IND_PENSAO           VARCHAR(3)           NOT NULL,
   CONSTRAINT WEB_ADESAO_DEPENDENTE_PK PRIMARY KEY (OID_ADESAO_DEPENDENTE)
)
go

ALTER TABLE WEB_ADESAO_DEPENDENTE
   ADD CONSTRAINT WEB_ADESAO_DEPENDENTE_FK01 FOREIGN KEY (OID_ADESAO)
      REFERENCES WEB_ADESAO (OID_ADESAO)
go


/*==============================================================*/
/* Table: WEB_ADESAO_PLANO                                      */
/*==============================================================*/
CREATE TABLE WEB_ADESAO_PLANO (
   OID_ADESAO_PLANO     NUMERIC(10)          IDENTITY,
   OID_ADESAO           NUMERIC(10)          NOT NULL,
   COD_PLANO            VARCHAR(20)          NOT NULL,
   DES_PLANO            VARCHAR(100)         NOT NULL,
   IND_REGIME_TRIBUTACAO VARCHAR(3)           NOT NULL,
   CONSTRAINT PK_WEB_ADESAO_PLANO PRIMARY KEY (OID_ADESAO_PLANO)
)
go

ALTER TABLE WEB_ADESAO_PLANO
   ADD CONSTRAINT WEB_ADESAO_PLANO_FK01 FOREIGN KEY (OID_ADESAO)
      REFERENCES WEB_ADESAO (OID_ADESAO)
go


/*==============================================================*/
/* Table: WEB_ADESAO_CONTRIB                                    */
/*==============================================================*/
CREATE TABLE WEB_ADESAO_CONTRIB (
   OID_ADESAO_CONTRIB   NUMERIC(10)          IDENTITY,
   OID_ADESAO_PLANO     NUMERIC(10)          NOT NULL,
   COD_CONTRIBUICAO     VARCHAR(20)          NOT NULL,
   DES_CONTRIBUICAO     VARCHAR(100)         NOT NULL,
   VAL_CONTRIBUICAO     NUMERIC(15,8)        NOT NULL,
   IND_VALOR_PERC       VARCHAR(3)           NOT NULL,
   CONSTRAINT PK_WEB_ADESAO_CONTRIB PRIMARY KEY (OID_ADESAO_CONTRIB)
)
go

ALTER TABLE WEB_ADESAO_CONTRIB
   ADD CONSTRAINT WEB_ADESAO_CONTRIB_FK01 FOREIGN KEY (OID_ADESAO_PLANO)
      REFERENCES WEB_ADESAO_PLANO (OID_ADESAO_PLANO)
go

INSERT INTO WEB_FUNCIONALIDADE VALUES(18, 'Adesão', 'SIM', 'SIM');
