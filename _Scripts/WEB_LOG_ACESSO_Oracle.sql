CREATE SEQUENCE S_WEB_FUNCIONALIDADE;

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

CREATE UNIQUE INDEX WEB_FUNCIONALIDADE__UK01 ON WEB_FUNCIONALIDADE (
   NUM_FUNCIONALIDADE ASC
);

CREATE UNIQUE INDEX WEB_FUNCIONALIDADE_UK02 ON WEB_FUNCIONALIDADE (
   DES_FUNCIONALIDADE ASC
);

CREATE SEQUENCE S_WEB_LOG_ACESSO;

CREATE TABLE WEB_LOG_ACESSO (
   OID_LOG_ACESSO       NUMBER(10)          NOT NULL,
   COD_CPF              VARCHAR2(11)          NOT NULL,
   DTA_ACESSO           DATE             NOT NULL,
   IND_SUCESSO          VARCHAR2(3)           NOT NULL
      CONSTRAINT CKC_IND_SUCESSO_WEB_LOG_ CHECK (IND_SUCESSO IN ('SIM','NAO') AND IND_SUCESSO = UPPER(IND_SUCESSO)),
   TXT_MSG_ERRO         VARCHAR2(4000)        NULL,
   IND_ORIGEM           VARCHAR2(20)          NOT NULL,
   TXT_IPV4             VARCHAR2(15)          NULL,
   TXT_IPV6             VARCHAR2(50)          NULL,
   TXT_BROWSER          VARCHAR2(100)         NULL,
   TXT_SO               VARCHAR2(100)         NULL,
   TXT_LOCALIZACAO      VARCHAR2(300)         NULL,
   CONSTRAINT WEB_LOG_ACESSO_PK PRIMARY KEY (OID_LOG_ACESSO)
);

CREATE SEQUENCE S_WEB_LOG_ACESSO_FUNC;

CREATE TABLE WEB_LOG_ACESSO_FUNC (
   OID_LOG_ACESSO_FUNC  NUMBER(10)          NOT NULL,
   OID_LOG_ACESSO       NUMBER(10)          NOT NULL,
   OID_FUNCIONALIDADE   NUMBER(10)          NOT NULL,
   DTA_ACESSO_FUNC      DATE             NOT NULL,
   CONSTRAINT WEB_LOG_ACESSO_FUNC_PK PRIMARY KEY (OID_LOG_ACESSO_FUNC)
);

ALTER TABLE WEB_LOG_ACESSO_FUNC
   ADD CONSTRAINT WEB_LOG_ACESSO_FUNC_FK01 FOREIGN KEY (OID_LOG_ACESSO)
      REFERENCES WEB_LOG_ACESSO (OID_LOG_ACESSO);

ALTER TABLE WEB_LOG_ACESSO_FUNC
   ADD CONSTRAINT WEB_LOG_ACESSO_FUNC_FK02 FOREIGN KEY (OID_FUNCIONALIDADE)
      REFERENCES WEB_FUNCIONALIDADE (OID_FUNCIONALIDADE);
      
