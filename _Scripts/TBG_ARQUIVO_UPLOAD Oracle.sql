CREATE SEQUENCE S_TBG_ARQUIVO_UPLOAD START WITH 1 CREATE TABLE TBG_ARQUIVO_UPLOAD(
  OID_ARQUIVO_UPLOAD numeric(10, 0) NOT FOR REPLICATION NOT NULL,
  NOM_ARQUIVO_ORIGINAL varchar2(4000) NOT NULL,
  NOM_EXT_ARQUIVO varchar2(10) NULL,
  DTA_UPLOAD DATE NOT NULL,
  NOM_DIRETORIO_LOCAL varchar2(200) NOT NULL,
  NOM_ARQUIVO_LOCAL varchar2(4000) NOT NULL,
  OID_USUARIO numeric(10, 0) NULL,
  OID_SERVICO numeric(10, 0) NULL,
  OID_MODULO numeric(10, 0) NULL,
  OID_SISTEMA numeric(10, 0) NULL,
  IND_STATUS numeric(5, 0) DEFAULT 1 NOT NULL,
  CONSTRAINT TBG_ARQUIVO_UPLOAD_PK PRIMARY KEY (OID_ARQUIVO_UPLOAD)
);
ALTER TABLE TBG_ARQUIVO_UPLOAD WITH CHECK
ADD CONSTRAINT CKC_IND_STATUS_TB234234 CHECK (
    (
      IND_STATUS =(3)
      OR IND_STATUS =(2)
      OR IND_STATUS =(1)
    )
  );
ALTER TABLE TBG_ARQUIVO_UPLOAD CHECK CONSTRAINT CKC_IND_STATUS_TB234234;