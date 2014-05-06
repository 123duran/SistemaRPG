SELECT ca.NOME AS Nome, ca.EMAIL AS Email, p.NOME_PER AS Personagem, p.RACA_PER AS Raça, p.FORCA_PER AS Força, p.TIPO_PER AS 'Tipo de Personagem', 
                                                p.NIVEL_PER AS Nível, p.HAB_PER AS Habilidade, p.RES_PER AS Resistência, p.ARM_PER AS Armadura, p.PV_PER AS 'Pontos de Vida', 
                                                p.PDF_PER AS 'Poder de Fogo', c.NOME_CARAC AS Característica, c.MOD_CARAC AS 'MOD', c.TIPO_CARAC AS 'Tipo de Caracteristica'
                                                FROM Cadastro ca, Personagem p, Caracteristica c, Personagem_Caracteristica pc 
                                                WHERE ca.COD_LOGIN = p.COD_LOGIN 
                                                AND p.COD_PER = pc.COD_PER
                                                AND c.COD_CARAC = pc.COD_CARAC
                                                ORDER BY ca.NOME

SELECT * FROM Cadastro c, Personagem p WHERE c.COD_lOGIN = p.COD_LOGIN
SELECT * FROM Personagem
SELECT * FROM Cadastro
SELECT * FROM Caracteristica
SELECT * FROM Personagem_Caracteristica

INSERT INTO Personagem_Caracteristica (COD_CAR, COD_PER) VALUES (1, 1)
INSERT INTO Personagem_Caracteristica (COD_CAR, COD_PER) VALUES (2, 2)
INSERT INTO Personagem_Caracteristica (COD_CAR, COD_PER) VALUES (3, 1)
INSERT INTO Personagem_Caracteristica (COD_CAR, COD_PER) VALUES (4, 2)
