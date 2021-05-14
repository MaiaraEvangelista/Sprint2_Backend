CREATE DATABASE MedicalGroup;
GO

USE MedicalGroup;
GO

CREATE TABLE tiposUsuarios
(
	idTiposUsuario INT PRIMARY KEY IDENTITY
	,tipos		   VARCHAR(100) UNIQUE NOT NULL
);
GO

CREATE TABLE usuarios
(
	idUsuario		INT PRIMARY KEY IDENTITY
	,idTiposUsuario INT FOREIGN KEY REFERENCES tiposUsuarios(idTiposUsuario)
	,email			VARCHAR(100) UNIQUE NOT NULL
	,senha			VARCHAR(100) NOT NULL
);
GO

CREATE TABLE pacientes
(
	idPaciente		INT PRIMARY KEY IDENTITY
	,idUsuario		INT FOREIGN KEY REFERENCES usuarios(idUsuario)
	,nomePaciente	VARCHAR(60) UNIQUE NOT NULL
	,RG				VARCHAR(12) UNIQUE NOT NULL
	,CPF			VARCHAR(12) UNIQUE NOT NULL
	,telefone		VARCHAR(12) NOT NULL
	,dataNascimento VARCHAR(9) NOT NULL
	,endereco		VARCHAR(100) NOT NULL
);
GO

CREATE TABLE especialidades
(
	idEspecialidade INT PRIMARY KEY IDENTITY
	,tipos			VARCHAR(100) NOT NULL
);
GO

CREATE TABLE situacoes
(
	idSituacao INT PRIMARY KEY IDENTITY
	,situacao  VARCHAR(100) NOT NULL
);
GO

CREATE TABLE clinicas
(
	idClinica          INT PRIMARY KEY IDENTITY
	,razaoSocial       VARCHAR(100) NOT NULL
	,nomeFantasia      VARCHAR(100) NOT NULL
	,CNPJ              VARCHAR(100) NOT NULL
	,endereco		   VARCHAR(100) NOT NULL
	,telefone		   VARCHAR(50) NOT NULL
	,horarioAbertura   VARCHAR(20) NOT NULL
	,horarioFechamento VARCHAR(20) NOT NULL
);
GO

CREATE TABLE medicos
(
	idMedico		 INT PRIMARY KEY IDENTITY
	,idUsuario		 INT FOREIGN KEY REFERENCES usuarios(idUsuario)
	,idEspecialidade INT FOREIGN KEY REFERENCES especialidades(idEspecialidade)
	,idClinica		 INT FOREIGN KEY REFERENCES clinicas(idClinica)
	,nomeMedico		 VARCHAR(50) NOT NULL
	,CRM			 VARCHAR(30) UNIQUE NOT NULL 
);
GO

CREATE TABLE consultas
(
	idConsulta    INT PRIMARY KEY IDENTITY 
	,idPaciente   INT FOREIGN KEY REFERENCES pacientes(idPaciente)
	,idMedico     INT FOREIGN KEY REFERENCES medicos(idMedico)
	,idSituacao   INT FOREIGN KEY REFERENCES situacoes(idSituacao)
	,horario	  VARCHAR(10) NOT NULL
	,dataConsulta VARCHAR(10) NOT NULL
	,descricao	  VARCHAR(100) UNIQUE NOT NULL
);
GO