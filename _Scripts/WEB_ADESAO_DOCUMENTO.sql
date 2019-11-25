/*==============================================================*/
/* Table: WEB_ADESAO_DOCUMENTO                                  */
/*==============================================================*/
CREATE TABLE WEB_ADESAO_DOCUMENTO (
   OID_ADESAO_DOCUMENTO NUMERIC(10)          IDENTITY,
   OID_ADESAO           NUMERIC(10)          NULL,
   TXT_TITULO           VARCHAR(100)         NOT NULL,
   TXT_NOME_FISICO      VARCHAR(100)         NOT NULL,
   CONSTRAINT WEB_ADESAO_DOCUMENTO_PK PRIMARY KEY (OID_ADESAO_DOCUMENTO)
)
go

ALTER TABLE WEB_ADESAO_DOCUMENTO
   ADD CONSTRAINT WEB_ADESAO_DOCUMENTO_FK01 FOREIGN KEY (OID_ADESAO)
      REFERENCES WEB_ADESAO (OID_ADESAO)
go