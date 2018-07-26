CREATE TABLE [dbo].[WEB_USUARIO](
	[OID_USUARIO] [numeric](10, 0) IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[NOM_LOGIN] [varchar](60) NOT NULL,
	[PWD_USUARIO] [varchar](200) NOT NULL,
	[IND_BLOQUEADO] [varchar](1) NOT NULL,
	[NUM_TENTATIVA] [numeric](5, 0) NOT NULL,
	[DES_LOTACAO] [varchar](20) NULL,
	[IND_ADMINISTRADOR] [varchar](1) NOT NULL,
	[IND_ATIVO] [varchar](1) NOT NULL,
	[NOM_USUARIO_CRIACAO] [varchar](60) NULL,
	[DTA_CRIACAO] [datetime] NULL,
	[NOM_USUARIO_ATUALIZACAO] [varchar](60) NULL,
	[DTA_ATUALIZACAO] [datetime] NULL,
	[CD_EMPRESA] [varchar](4) NOT NULL,
	[SEQ_RECEBEDOR] [numeric](10, 0) NULL,
 CONSTRAINT [WEB_USUARIO_PK] PRIMARY KEY NONCLUSTERED 
(
	[OID_USUARIO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO