/*==============================================================*/
/* Table: WEB_GRUPO_USUARIO                                     */
/*==============================================================*/
CREATE TABLE WEB_GRUPO_USUARIO (
   OID_GRUPO_USUARIO    NUMERIC(10)          IDENTITY,
   NOM_GRUPO_USUARIO    VARCHAR(50)          NOT NULL,
   IND_ADMINISTRADOR    VARCHAR(3)           NULL
      CONSTRAINT CKC_IND_ADMINISTRADOR_WEB_GRUP CHECK (IND_ADMINISTRADOR IS NULL OR (IND_ADMINISTRADOR IN ('SIM','NAO') AND IND_ADMINISTRADOR = UPPER(IND_ADMINISTRADOR))),
   IND_ATIVO            VARCHAR(3)           NOT NULL,
   CONSTRAINT WEB_GRUPO_USUARIO_PK PRIMARY KEY (OID_GRUPO_USUARIO)
)
go

INSERT INTO WEB_GRUPO_USUARIO (NOM_GRUPO_USUARIO, IND_ADMINISTRADOR, IND_ATIVO) 
VALUES ('ADMINISTRADORES', 'SIM', 'SIM')
go

/*==============================================================*/
/* Index: WEB_GRUPO_USUARIO_UK01                                */
/*==============================================================*/
CREATE UNIQUE INDEX WEB_GRUPO_USUARIO_UK01 ON WEB_GRUPO_USUARIO (
NOM_GRUPO_USUARIO ASC
)
go


/*==============================================================*/
/* Table: WEB_USUARIO_GRUPO                                     */
/*==============================================================*/
CREATE TABLE WEB_USUARIO_GRUPO (
   OID_USUARIO_GRUPO    NUMERIC(10)          IDENTITY,
   OID_GRUPO_USUARIO    NUMERIC(10)          NOT NULL,
   OID_USUARIO          NUMERIC(10)          NOT NULL,
   CONSTRAINT WEB_USUARIO_GRUPO_PK PRIMARY KEY (OID_USUARIO_GRUPO)
)
go

/*==============================================================*/
/* Index: WEB_USUARIO_GRUPO_UK01                                */
/*==============================================================*/
CREATE UNIQUE INDEX WEB_USUARIO_GRUPO_UK01 ON WEB_USUARIO_GRUPO (
OID_USUARIO ASC
)
go

ALTER TABLE WEB_USUARIO_GRUPO
   ADD CONSTRAINT WEB_USUARIO_GRUPO_FK01 FOREIGN KEY (OID_GRUPO_USUARIO)
      REFERENCES WEB_GRUPO_USUARIO (OID_GRUPO_USUARIO)
go

ALTER TABLE WEB_USUARIO_GRUPO
   ADD CONSTRAINT WEB_USUARIO_GRUPO_FK02 FOREIGN KEY (OID_USUARIO)
      REFERENCES WEB_USUARIO (OID_USUARIO)
go

/*==============================================================*/
/* Table: WEB_ACESSO_GRUPO_USUARIO                              */
/*==============================================================*/
CREATE TABLE WEB_ACESSO_GRUPO_USUARIO (
   OID_ACESSO_GRUPO_USUARIO NUMERIC(10)          IDENTITY,
   OID_GRUPO_USUARIO    NUMERIC(10)          NOT NULL,
   OID_FUNCIONALIDADE   NUMERIC(10)          NOT NULL,
   IND_ACESSO           VARCHAR(3)           NULL
      CONSTRAINT CKC_IND_ACESSO_WEB_ACES CHECK (IND_ACESSO IS NULL OR (IND_ACESSO IN ('SIM','NAO') AND IND_ACESSO = UPPER(IND_ACESSO))),
   CONSTRAINT WEB_ACESSO_GRUPO_USUARIO_PK PRIMARY KEY (OID_ACESSO_GRUPO_USUARIO)
)
go

/*==============================================================*/
/* Index: WEB_ACESSO_GRUPO_USUARIO_UK01                         */
/*==============================================================*/
CREATE UNIQUE INDEX WEB_ACESSO_GRUPO_USUARIO_UK01 ON WEB_ACESSO_GRUPO_USUARIO (
OID_GRUPO_USUARIO ASC,
OID_FUNCIONALIDADE ASC
)
go

ALTER TABLE WEB_ACESSO_GRUPO_USUARIO
   ADD CONSTRAINT WEB_ACESSO_GRUPO_USUARIO_FK01 FOREIGN KEY (OID_GRUPO_USUARIO)
      REFERENCES WEB_GRUPO_USUARIO (OID_GRUPO_USUARIO)
go

ALTER TABLE WEB_ACESSO_GRUPO_USUARIO
   ADD CONSTRAINT WEB_ACESSO_GRUPO_USUARIO_FK02 FOREIGN KEY (OID_FUNCIONALIDADE)
      REFERENCES WEB_FUNCIONALIDADE (OID_FUNCIONALIDADE)
go

INSERT INTO WEB_FUNCIONALIDADE VALUES(11, 'Contratação de Empréstimo', 'NAO', 'SIM');
INSERT INTO WEB_FUNCIONALIDADE VALUES(12, 'Efetiva Transações', 'NAO', 'SIM');
INSERT INTO WEB_FUNCIONALIDADE VALUES(13, 'Painel de Controle', 'NAO', 'SIM');
INSERT INTO WEB_FUNCIONALIDADE VALUES(14, 'Usuários e Grupos', 'NAO', 'SIM');
INSERT INTO WEB_FUNCIONALIDADE VALUES(15, 'Listar Participantes', 'NAO', 'SIM');
INSERT INTO WEB_FUNCIONALIDADE VALUES(16, 'Criar Mensagem', 'NAO', 'SIM');
INSERT INTO WEB_FUNCIONALIDADE VALUES(17, 'Criar Documento', 'NAO', 'SIM');