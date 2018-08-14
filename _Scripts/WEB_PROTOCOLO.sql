IF EXISTS (SELECT 1
            FROM  SYSOBJECTS
           WHERE  ID = OBJECT_ID('WEB_PROTOCOLO')
            AND   TYPE = 'U')
   DROP TABLE WEB_PROTOCOLO
go

/*==============================================================*/
/* Table: WEB_PROTOCOLO                                         */
/*==============================================================*/
CREATE TABLE WEB_PROTOCOLO (
   OID_PROTOCOLO        NUMERIC(10)          IDENTITY,
   OID_FUNCIONALIDADE   NUMERIC(10)          NOT NULL,
   COD_IDENTIFICADOR    VARCHAR(25)          NOT NULL,
   CD_FUNDACAO          VARCHAR(2)           NOT NULL,
   CD_EMPRESA           VARCHAR(4)           NOT NULL,
   CD_PLANO             VARCHAR(4)           NOT NULL,
   NUM_MATRICULA        VARCHAR(9)           NOT NULL,
   SEQ_RECEBEDOR        NUMERIC(10)          NULL,
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
   CONSTRAINT WEB_PROTOCOLO_PK PRIMARY KEY (OID_PROTOCOLO)
)
go

/*==============================================================*/
/* Index: WEB_PROTOCOLO_UK01                                    */
/*==============================================================*/
CREATE UNIQUE INDEX WEB_PROTOCOLO_UK01 ON WEB_PROTOCOLO (
CD_FUNDACAO ASC,
COD_IDENTIFICADOR ASC
)
go

ALTER TABLE WEB_PROTOCOLO
   ADD CONSTRAINT FK_WEB_PROT_REFERENCE_WEB_FUNC FOREIGN KEY (OID_FUNCIONALIDADE)
      REFERENCES WEB_FUNCIONALIDADE (OID_FUNCIONALIDADE)
go
