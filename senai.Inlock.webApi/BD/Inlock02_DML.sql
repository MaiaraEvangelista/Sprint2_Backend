--DM-L
USE Inlock;
GO

--Inserção nas tabelas criadas
INSERT INTO Estudio(nomeEstudio)
VALUES			   ('Blizzard')
				  ,('Rockstar Studios')
				  ,('Square Enix');
GO

INSERT INTO TiposUsuario(Titulo)
VALUES			        ('Administrador')
					   ,('Cliente');
GO


INSERT INTO Usuario(email, senha, idTipoUsuario)
VALUES			   ('admin@admin.com', 'admin', 1)
				  ,('cliente@cliente', 'cliente', 2);
GO


INSERT INTO Jogos(nomeJogo, descricao, dataLancamento, valor, idEstudio)
VALUES			 ('Diablo 3', 'é um jogo que contém bastante ação e é viciante, seja você um novato ou um fã', '2012-05-15','99.00',1)
				,('Red Dead Redemption II','jogo eletrônico de ação-aventura western','2018-10-26','120.00',2);
GO