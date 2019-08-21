DROP VIEW VW_APP_INSTITUCIONAL_NOTICIA;

CREATE VIEW VW_APP_INSTITUCIONAL_NOTICIA
AS select dt_publicacao,
       institucional_nome,
       institucional_texto,
       link_portal,
       institucional_id,
       secao_id_principal
  from ( select DTA_CRIACAO AS dt_publicacao,
                TXT_TITULO AS institucional_nome,
                TXT_CONTEUDO AS institucional_texto,
                '' AS link_portal,
                OID_NOTICIA AS institucional_id,
                OID_NOTICIA AS secao_id_principal
           from WEB_NOTICIA
          order by DTA_CRIACAO desc
        );