CREATE TABLE Personagem 
(
	COD_PER INT PRIMARY KEY IDENTITY NOT NULL,
	COD_CAR_PER INT,
	NOME_PER VARCHAR(50) NOT NULL,
	IMG_PER INT NOT NULL;
	RACA_PER VARCHAR(20) NOT NULL,
	FORCA_PER INT NOT NULL,
	TIPO_PER VARCHAR(20) NOT NULL,
	NIVEL_PER INT NOT NULL,
	HAB_PER INT NOT NULL,
	RES_PER  INT NOT NULL,
	ARM_PER INT NOT NULL,
	PV_PER INT NOT NULL,
	PDF_PER INT  NOT NULL
)

CREATE TABLE Caracteristica
(
	COD_CAR INT PRIMARY KEY IDENTITY NOT NULL,
	COD_CAR_PER INT,
	NOME_CAR VARCHAR(50),
	MOD_CAR INT,
	TIPO_CAR VARCHAR(20)
)

CREATE TABLE Jogador
(
	COD_JOGADOR INT PRIMARY KEY IDENTITY NOT NULL,
--	COD_PARTIDA_PER INT NOT NULL,
	NOME VARCHAR(70) NOT NULL,
	EMAIL VARCHAR(100) NOT NULL,
	SENHA VARCHAR (20) NOT NULL,
	PERFIL VARCHAR(15) NOT NULL,
	ATIVO INT NOT NULL
)

CREATE TABLE Aventura
(
	COD_AVENTURA INT PRIMARY KEY IDENTITY NOT NULL,
	AVENTURA TEXT NOT NULL
)

CREATE TABLE Partida
(
	COD_PARTIDA INT PRIMARY KEY IDENTITY NOT NULL,
	COD_JOGADOR INT NOT NULL,
	COD_PARTIDA_PER INT NOT NULL,
	DESCRICAO TEXT NOT NULL,
	SENHA VARCHAR(20) NOT NULL,
)

CREATE TABLE Resultados
(
	COD_RESULTADOS INT PRIMARY KEY IDENTITY NOT NULL,
	COD_PARTIDA_PER INT NOT NULL,
	DATA DATETIME NOT NULL,
	RESULTADO INT NOT NULL
)

CREATE TABLE Partida_Sessao
(
	COD_PARTIDA_PER INT PRIMARY KEY IDENTITY NOT NULL,
	COD_PARTIDA INT NOT NULL,
	COD_PERSONAGEM INT NOT NULL,
	COD_JOGADOR INT NOT NULL
)

CREATE TABLE Caracteristica_Per
(
	COD_CAR_PER INT PRIMARY KEY IDENTITY NOT NULL,
	COD_PER INT NOT NULL,
	COD_CAR INT NOT NULL
)


-- ADD PK_PARTIDA_PERSONAGEM
ALTER TABLE Resultados
ADD CONSTRAINT fk_ResSessao
FOREIGN KEY (COD_PARTIDA_PER)
REFERENCES Partida_Sessao(COD_PARTIDA_PER)

ALTER TABLE Jogador
ADD CONSTRAINT fk_JogSessao
FOREIGN KEY (COD_PARTIDA_PER)
REFERENCES Partida_Sessao(COD_PARTIDA_PER)

ALTER TABLE Partida
ADD CONSTRAINT fk_ParSessao
FOREIGN KEY (COD_PARTIDA_PER)
REFERENCES Partida_Sessao(COD_PARTIDA_PER)

-- ADD PK_JOGADOR
ALTER TABLE Partida
ADD CONSTRAINT fk_Partida
FOREIGN KEY (COD_JOGADOR)
REFERENCES Jogador(COD_JOGADOR)

-- ADD PK_PERSONAGEM 
ALTER TABLE Caracteristica
ADD CONSTRAINT fk_CaracteristicaPer
FOREIGN KEY (COD_CAR_PER)
REFERENCES Caracteristica_Per (COD_CAR_PER)

ALTER TABLE Personagem
ADD CONSTRAINT fk_PersonagemCar
FOREIGN KEY (COD_CAR_PER)
REFERENCES Caracteristica_Per (COD_CAR_PER)
