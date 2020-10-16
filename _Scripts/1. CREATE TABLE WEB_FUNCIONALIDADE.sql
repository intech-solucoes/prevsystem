
CREATE TABLE WEB_FUNCIONALIDADE(
	[OID_FUNCIONALIDADE] [numeric](10, 0) IDENTITY(1,1) NOT NULL,
	[NUM_FUNCIONALIDADE] [numeric](10, 0) NOT NULL,
	[DES_FUNCIONALIDADE] [varchar](100) NOT NULL,
	[IND_ATIVO] [varchar](3) NOT NULL,
	[IND_USA_PROTOCOLO] [varchar](3) NOT NULL,
 CONSTRAINT [WEB_FUNCIONALIDADE_PK] PRIMARY KEY NONCLUSTERED 
(
	[OID_FUNCIONALIDADE] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[WEB_FUNCIONALIDADE]  WITH CHECK ADD  CONSTRAINT [CKC_IND_ATIVO_WEB_FUNC] CHECK  ((([IND_ATIVO]='NAO' OR [IND_ATIVO]='SIM') AND [IND_ATIVO]=upper([IND_ATIVO])))
GO

ALTER TABLE [dbo].[WEB_FUNCIONALIDADE] CHECK CONSTRAINT [CKC_IND_ATIVO_WEB_FUNC]
GO

