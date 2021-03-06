/*==============================================================*/
/* Table: WEB_LIMITE_CONTRIBUICAO                               */
/*==============================================================*/
CREATE TABLE WEB_LIMITE_CONTRIBUICAO (
   OID_LIMITE_CONTRIBUICAO NUMERIC(10)          IDENTITY,
   CD_FUNDACAO          VARCHAR(2)           NOT NULL,
   CD_PLANO             VARCHAR(4)           NOT NULL,
   VAL_PERC_MINIMO_PART NUMERIC(15,4)        NOT NULL,
   VAL_PERC_MAXIMO_PART NUMERIC(15,4)        NOT NULL,
   VAL_PERC_MINIMO_PATROC NUMERIC(15,4)        NOT NULL,
   VAL_PERC_MAXIMO_PATROC NUMERIC(15,4)        NOT NULL,
   CONSTRAINT WEB_LIMITE_CONTRIBUICAO_PK PRIMARY KEY (OID_LIMITE_CONTRIBUICAO)
)
go

INSERT INTO WEB_LIMITE_CONTRIBUICAO (CD_FUNDACAO, CD_PLANO, VAL_PERC_MINIMO_PART, VAL_PERC_MAXIMO_PART, VAL_PERC_MINIMO_PATROC, VAL_PERC_MAXIMO_PATROC) VALUES ('01', '0002', 2, 100, 2, 6); --CONTRIBUICAO DEFINIDA
INSERT INTO WEB_LIMITE_CONTRIBUICAO (CD_FUNDACAO, CD_PLANO, VAL_PERC_MINIMO_PART, VAL_PERC_MAXIMO_PART, VAL_PERC_MINIMO_PATROC, VAL_PERC_MAXIMO_PATROC) VALUES ('01', '0003', 6, 100, 6, 8); --CONTRIBUICAO VARIAVEL
INSERT INTO WEB_LIMITE_CONTRIBUICAO (CD_FUNDACAO, CD_PLANO, VAL_PERC_MINIMO_PART, VAL_PERC_MAXIMO_PART, VAL_PERC_MINIMO_PATROC, VAL_PERC_MAXIMO_PATROC) VALUES ('01', '0004', 3, 100, 3, 4); --CD-METRO
INSERT INTO WEB_LIMITE_CONTRIBUICAO (CD_FUNDACAO, CD_PLANO, VAL_PERC_MINIMO_PART, VAL_PERC_MAXIMO_PART, VAL_PERC_MINIMO_PATROC, VAL_PERC_MAXIMO_PATROC) VALUES ('01', '0005', 3, 100, 3, 6); --PLANO CD-05
