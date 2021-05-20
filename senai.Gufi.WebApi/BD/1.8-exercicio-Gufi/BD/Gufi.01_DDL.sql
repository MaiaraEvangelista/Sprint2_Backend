--DDL

--Criação do banco
CREATE DATABASE Gufi;
GO

--Uso do banco
USE Gufi;
GO


--Criação das tabelas 
CREATE TABLE tiposUsuario
(
	idTipoUsuario	   INT PRIMARY KEY IDENTITY
	,tituloTipoUsuario VARCHAR(200) UNIQUE NOT NULL
);
GO

CREATE TABLE usuario
(
	idUsuario		INT PRIMARY KEY IDENTITY
	,idTipoUsuario	INT FOREIGN KEY REFERENCES tiposUsuario(idTipoUsuario)
	,nomeUsuario	VARCHAR(200) NOT NULL
	,email			VARCHAR(200) UNIQUE NOT NULL
	,senha			VARCHAR(200) NOT NULL
);
GO

CREATE TABLE instituicao
(
	idInstituicao	INT PRIMARY KEY IDENTITY
	,CNPJ			CHAR(14) UNIQUE NOT NULL
	,nomeFantasia	VARCHAR (200) UNIQUE NOT NULL
	,endereco		VARCHAR(200) UNIQUE NOT NULL 
);
GO

CREATE TABLE tiposEvento
(
	idTipoEvento	INT PRIMARY KEY IDENTITY
	,tituloEvento	VARCHAR(200) UNIQUE NOT NULL
);
GO

CREATE TABLE eventos
(
	idEvento		INT PRIMARY KEY IDENTITY
	,idTipoEvento	INT FOREIGN KEY REFERENCES tiposEvento(idTipoEvento)
	,idInstituicao	INT FOREIGN KEY REFERENCES instituicao(idInstituicao)
	,nomeEvento		VARCHAR (200) NOT NULL
	,acessoLivre	BIT DEFAULT (1)
	,dataEvento		DATE NOT NULL
	,descricao		VARCHAR(200)
);
GO

CREATE TABLE presenca
(
	idPresenca	INT PRIMARY KEY IDENTITY
	,idUsuario	INT FOREIGN KEY REFERENCES usuario(idUsuario)
	,idEvento	INT FOREIGN KEY REFERENCES eventos(idEvento)
	,situacao	VARCHAR (200) NOT NULL
);
GO