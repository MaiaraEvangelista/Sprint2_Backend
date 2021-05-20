--Usando o banco
USE Gufi;
GO

--Apresentar a tabea toda
SELECT * FROM tiposUsuario;
GO

SELECT * FROM usuario;
GO

SELECT * FROM instituicao;
GO

SELECT * FROM tiposEvento;
GO

SELECT * FROM  eventos;
GO

SELECT * FROM presenca;
GO

--Busca um usuário através do seu email e senha
SELECT tituloTipoUsuario, nomeUsuario, email
FROM usuario U
INNER JOIN tiposUsuario TU
ON U.idTipoUsuario = TU.idTipoUsuario
WHERE email = 'saulo@email.com' AND senha = 'saulo123';



