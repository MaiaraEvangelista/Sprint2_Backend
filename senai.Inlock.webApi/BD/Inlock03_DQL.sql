--DQL
USE Inlock;
GO

SELECT * FROM Estudio;
GO

SELECT * FROM TiposUsuario;
GO

SELECT * FROM Usuario;
GO

SELECT * FROM Jogos;
GO

--Lista todos os jogos e seus est�dios
SELECT J.idJogo, J.nomeJogo, J.descricao, J.dataLancamento, J.valor, J.idEstudio, E.nomeEstudio FROM Jogos J
INNER JOIN Estudio E
ON J.idEstudio = E.idEstudio;
GO

--Faz a listagem trazendo at� os nulos
SELECT E.idEstudio, E.nomeEstudio, J.nomeJogo, J.descricao, J.dataLancamento, J.valor FROM Estudio E
LEFT JOIN Jogos J
ON E.idEstudio = J.idEstudio;
GO

--Busca um usu�rio pelo email e senha
SELECT idUsuario, email, U.idTipoUsuario, TU.Titulo FROM Usuario U
INNER JOIN TiposUsuario TU
ON U.idTipoUsuario = TU.idTipoUsuario
WHERE email = 'admin@admin.com' AND senha = 'admin';
GO

--Busca um jogo e seu est�dio pelo id do jogo
SELECT J.idJogo, J.nomeJogo, J.descricao, J.dataLancamento, J.valor, J.idEstudio, E.nomeEstudio FROM Jogos J
INNER JOIN Estudio E
ON J.idEstudio = E.idEstudio
WHERE J.idJogo = 1;
GO