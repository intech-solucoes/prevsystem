ALTER TABLE WEB_RECAD_DADOS 
ADD  COD_PROTOCOLO        VARCHAR(100)         NOT NULL;

DROP TABLE WEB_RECAD_DEPENDENTE;

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
   IND_OPERACAO         VARCHAR(3)           NOT NULL
      CONSTRAINT CKC_IND_OPERACAO_WEB_RECA CHECK (IND_OPERACAO IN ('INC','ALT','EXC')),
   CONSTRAINT WEB_RECAD_BENEFICIARIO_PK PRIMARY KEY NONCLUSTERED (OID_RECAD_BENEFICIARIO)
);

ALTER TABLE WEB_RECAD_BENEFICIARIO
   ADD CONSTRAINT WEB_RECAD_BENEFICIARIO_FK01 FOREIGN KEY (OID_RECAD_DADOS)
      REFERENCES WEB_RECAD_DADOS (OID_RECAD_DADOS);

CREATE TABLE WEB_RECAD_DEPENDENTE_IR (
   OID_RECAD_DEPENDENTE_IR NUMERIC(10)          ,
   OID_RECAD_DADOS      NUMERIC(10)          NOT NULL,
   NUM_SEQ_DEP          NUMERIC(10)          NOT NULL,
   NOM_DEPENDENTE       VARCHAR(100)         NULL,
   COD_GRAU_PARENTESCO  VARCHAR(20)          NULL,
   DES_GRAU_PARENTESCO  VARCHAR(100)         NULL,
   DTA_NASCIMENTO       DATE            NULL,
   DTA_INICIO_IRRF      DATE             NULL,
   DTA_TERMINO_IRRF     DATE            NULL,
   COD_SEXO             VARCHAR(3)           NULL,
   DES_SEXO             VARCHAR(100)         NULL,
   COD_CPF              VARCHAR(11)          NULL,
   IND_OPERACAO         VARCHAR(3)           NOT NULL
      CONSTRAINT CKC_IND_OPERACAO_WEB_RECA CHECK (IND_OPERACAO IN ('INC','ALT','EXC')),
   CONSTRAINT WEB_RECAD_DEPENDENTE_IR_PK PRIMARY KEY NONCLUSTERED (OID_RECAD_DEPENDENTE_IR)
);

ALTER TABLE WEB_RECAD_DEPENDENTE_IR
   ADD CONSTRAINT WEB_RECAD_DEPENDENTE_IR_FK01 FOREIGN KEY (OID_RECAD_DADOS)
      REFERENCES WEB_RECAD_DADOS (OID_RECAD_DADOS);