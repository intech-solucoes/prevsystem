IF EXISTS (SELECT 1
            FROM  SYSOBJECTS
           WHERE  ID = OBJECT_ID('WEB_PROTOCOLO_PW')
            AND   TYPE = 'U')
   DROP TABLE WEB_PROTOCOLO_PW
go

/*==============================================================*/
/* Table: WEB_PROTOCOLO_PW                                      */
/*==============================================================*/
CREATE TABLE WEB_PROTOCOLO_PW (
   OID_PROTOCOLO_PW     NUMERIC(10)          IDENTITY,
   OID_FUNCIONALIDADE   NUMERIC(10)          NOT NULL,
   COD_IDENTIFICADOR    VARCHAR(25)          NOT NULL,
   CD_PESSOA            NUMERIC(10)          NOT NULL,
   SQ_CONTRATO_TRABALHO NUMERIC(10)          NOT NULL,
   SQ_PLANO_PREVIDENCIAL NUMERIC(10)          NOT NULL,
   DTA_SOLICITACAO      DATETIME             NOT NULL,
   DTA_EFETIVACAO       DATETIME             NULL,
   TXT_MOTIVO_RECUSA    VARCHAR(4000)        NULL,
   TXT_TRANSACAO        VARCHAR(4000)        NOT NULL,
   TXT_TRANSACAO2       VARCHAR(4000)        NULL,
   TXT_USUARIO_SOLICITACAO VARCHAR(100)         NOT NULL,
   TXT_USUARIO_EFETIVACAO VARCHAR(100)         NULL,
   TXT_IPV4             VARCHAR(15)          NULL,
   TXT_IPV6             VARCHAR(50)          NULL,
   TXT_DISPOSITIVO      VARCHAR(100)         NULL,
   TXT_ORIGEM           VARCHAR(100)         NOT NULL,
   CONSTRAINT WEB_PROTOCOLO_PW_PK PRIMARY KEY NONCLUSTERED (OID_PROTOCOLO_PW)
)
go

/*==============================================================*/
/* Index: WEB_PROTOCOLO_PW_UK01                                 */
/*==============================================================*/
CREATE UNIQUE INDEX WEB_PROTOCOLO_PW_UK01 ON WEB_PROTOCOLO_PW (
COD_IDENTIFICADOR ASC
)
go

ALTER TABLE WEB_PROTOCOLO_PW
   ADD CONSTRAINT WEB_PROTOCOLO_PW_FK01 FOREIGN KEY (OID_FUNCIONALIDADE)
      REFERENCES WEB_FUNCIONALIDADE (OID_FUNCIONALIDADE)
go
