--Criação do banco
CREATE DATABASE Inlock;
GO

--Utilização do banco
USE Inlock;
GO

--Criação das tabelas
CREATE TABLE Estudio
(
	idEstudio	 INT PRIMARY KEY IDENTITY
	,nomeEstudio VARCHAR(200) NOT NULL
);
GO

CREATE TABLE TiposUsuario
(
	idTipoUsuario INT PRIMARY KEY IDENTITY
	,Titulo		  VARCHAR (200) NOT NULL
);
GO

CREATE TABLE Usuario
(
	idUsuario INT PRIMARY KEY IDENTITY
	,email VARCHAR (200) UNIQUE NOT NULL
	,senha VARCHAR(200) NOT NULL
	,idTipoUsuario INT FOREIGN KEY REFERENCES TiposUsuario(idTipoUsuario) 
);
GO

CREATE TABLE Jogos
(
	idJogo INT PRIMARY KEY IDENTITY
	,nomeJogo VARCHAR(200) NOT NULL
	,descricao TEXT NOT NULL
	,dataLancamento DATE NOT NULL
	,valor DECIMAL (18,2) NOT NULL
	,idEstudio INT FOREIGN KEY REFERENCES Estudio(idEstudio)
);
GO