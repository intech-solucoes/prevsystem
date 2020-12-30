UPDATE TB_GRAU_PARENTESCO SET TIPO_HERDEIRO = CASE
WHEN CD_GRAU_PARENTESCO IN ('32', '03', '02', '09', '07', '08', '42', '06', '04', '05', '41', '43', '44', '39', '13', '12') THEN 'P'
WHEN CD_GRAU_PARENTESCO IN ('28', '18', '40', '47', '24', '23', '21', '15', '19', '22', '17', '00', '0', '16', '30', '29', '45', '27', '31', '36', '20', '26', '35') THEN 'S'
ELSE '' END;