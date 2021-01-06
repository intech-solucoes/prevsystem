CREATE TABLE GB_ESPECIE_INSS (
   CD_ESPECIE_INSS      VARCHAR(2)           NOT NULL,
   DS_ESPECIE_INSS      VARCHAR(100)          NOT NULL,
   CONSTRAINT GB_ESPECIE_INSS_PK PRIMARY KEY (CD_ESPECIE_INSS)
);

INSERT INTO GB_ESPECIE_INSS (CD_ESPECIE_INSS, DS_ESPECIE_INSS) VALUES ('41', '41 - APOSENTADORIA POR IDADE');
INSERT INTO GB_ESPECIE_INSS (CD_ESPECIE_INSS, DS_ESPECIE_INSS) VALUES ('32', '32 - APOSENTADORIA POR INVALIDEZ PREVIDENCIÁRIA');
INSERT INTO GB_ESPECIE_INSS (CD_ESPECIE_INSS, DS_ESPECIE_INSS) VALUES ('42', '42 - APOSENTADORIA POR TEMPO DE CONTRIBUIÇÃO PREVIDENCIÁRIA');
INSERT INTO GB_ESPECIE_INSS (CD_ESPECIE_INSS, DS_ESPECIE_INSS) VALUES ('46', '46 - APOSENTADORIA POR TEMPO DE CONTRIBUIÇÃO ESPECIAL');
INSERT INTO GB_ESPECIE_INSS (CD_ESPECIE_INSS, DS_ESPECIE_INSS) VALUES ('21', '21 - PENSÃO POR MORTE PREVIDENCIÁRIA');
INSERT INTO GB_ESPECIE_INSS (CD_ESPECIE_INSS, DS_ESPECIE_INSS) VALUES ('91', '91 - PENSÃO POR MORTE PREVIDENCIÁRIA ACIDENTÁRIA');